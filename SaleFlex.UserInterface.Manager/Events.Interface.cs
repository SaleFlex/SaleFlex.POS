﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.BoxForm;
using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.POS.Manager;
using SaleFlex.POS.Device.Manager;
using SaleFlex.GATE.Manager;

namespace SaleFlex.UserInterface.Manager
{
    public partial class Events
    {
        void vTotalValuesChanges()
        {
            if (m_xLastCustomForm != null)
            {
                m_xLastCustomForm.bSetStatusBarZNoLabel(string.Format("{0}", prop_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber));
                m_xLastCustomForm.bSetStatusBarReceiptNoLabel(string.Format("{0}", prop_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber));
                m_xLastCustomForm.bSetStatusBarPriceLabel(Convert.ToDecimal(prop_xPosManagerData.lReceiptTotalPrice) / 100);
                m_xLastCustomForm.bSetStatusBarQuantityLabel(prop_xPosManagerData.lReceiptTotalQuantity);

                foreach (Control xControl in m_xLastCustomForm.Controls)
                {
                    if (xControl is CustomAmountsTable)
                    {
                        ((CustomAmountsTable)xControl).decReceiptTotalPrice = Convert.ToDecimal(prop_xPosManagerData.lReceiptTotalPrice) / 100;
                        ((CustomAmountsTable)xControl).decReceiptTotalPayment = Convert.ToDecimal(prop_xPosManagerData.lReceiptTotalPayment) / 100;
                        ((CustomAmountsTable)xControl).decDiscountTotalAmount = Convert.ToDecimal(prop_xPosManagerData.lReceiptTotalDiscount) / 100;
                        ((CustomAmountsTable)xControl).decSurchargeTotalAmount = Convert.ToDecimal(prop_xPosManagerData.lReceiptTotalSurcharge) / 100;
                        ((CustomAmountsTable)xControl).vUpdateAndRefreshFormControls();

                        break;
                    }
                }
            }

            Application.DoEvents();
        }

        void vNewTransactionAdded()
        {
            m_xLastCustomForm.bSetStatusBarZNoLabel(string.Format("{0}", prop_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber));
            m_xLastCustomForm.bSetStatusBarReceiptNoLabel(string.Format("{0}", prop_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber));

            if (m_xLastCustomForm != null)
            {
                Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale Expected");
                m_xLastCustomForm.bAddSale(prop_xPosManagerData.xTransactionDataModel);
                Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale Ended");
            }

            Application.DoEvents();
        }
        void vSuspendedTransactionAdded()
        {
            m_xLastCustomForm.bSetStatusBarZNoLabel(string.Format("{0}", prop_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber));
            m_xLastCustomForm.bSetStatusBarReceiptNoLabel(string.Format("{0}", prop_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber));

            if (m_xLastCustomForm != null)
            {
                Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale Expected");
                m_xLastCustomForm.bAddSaleFromSuspended(prop_xPosManagerData.xTransactionDataModel);
                Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale Ended");
            }

            Application.DoEvents();
        }
        void vNewPaymentAdded()
        {
            if (prop_xPosManagerData == null)
                return;

            m_xLastCustomForm.bSetStatusBarZNoLabel(string.Format("{0}", prop_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber));
            m_xLastCustomForm.bSetStatusBarReceiptNoLabel(string.Format("{0}", prop_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber));

            if (m_xLastCustomForm != null)
            {
                m_xLastCustomForm.bAddPayment(prop_xPosManagerData.xTransactionDataModel);
            }

            Application.DoEvents();
        }

        void vReceiptClosed(long prm_lReceiptTotalPrice, long prm_lReceiptTotalPayment, List<PaymentDataModel> prm_xListPaymentDataModel, bool prm_bIsCancelled = false)
        {
            try
            {
                if (prm_bIsCancelled == false)
                {
                    if (prm_lReceiptTotalPrice - prm_lReceiptTotalPayment <= 0)
                    {
                        InfoBoxPaymentDetail xMessageBoxPaymentDetail = new InfoBoxPaymentDetail(prm_lReceiptTotalPrice, prm_lReceiptTotalPayment, prm_xListPaymentDataModel);
                        xMessageBoxPaymentDetail.ShowDialog();
                        DeviceManager.xGetInstance().bOpenCashDrawer();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            PosManager.xGetInstance().bClearTransaction();

            if (m_xLastCustomForm != null)
            {
                m_xLastCustomForm.bClearLists();
                DeviceManager.xGetInstance().bOpenCashDrawer();

                if (m_xLastCustomForm != null)
                {
                    bool bSetResult = m_xLastCustomForm.bSetStatusBarDocumentTypeLabel(PosManager.xGetInstance().prop_enumDocumentType = EnumDocumentType.FiscalReceipt);
                }

            }

            Application.DoEvents();
        }

        public bool SendTransactionToServer(long transactionHeadId)
        {
            var xGateManager = new GateManager();
            ServiceDataModel.TransactionListRequestModel transactionRequest = new ServiceDataModel.TransactionListRequestModel();
            transactionRequest.TransactionHeadList = new List<ServiceDataModel.TransactionHeadModel>();
            ServiceDataModel.HeaderModel header = new ServiceDataModel.HeaderModel
            {
                AppToken = CommonProperty.prop_strAppToken
            };
            transactionRequest.HeaderModel = header;

            ServiceDataModel.TransactionHeadModel transactionHead = PosManager.xGetInstance().GetTransactionByHeadId(transactionHeadId);

            transactionRequest.TransactionHeadList.Add(transactionHead);

            ServiceDataModel.TransactionListResponseModel transactionListResponse = xGateManager.vSaveTransactionList(transactionRequest);
            PosManager.xGetInstance().UpdateTransactionForSendServer(transactionListResponse);

            return true;
        }

        public bool SendUnsendTransactionsToServer()
        {
            var xGateManager = new GateManager();

            ServiceDataModel.TransactionListRequestModel transactionRequest = new ServiceDataModel.TransactionListRequestModel();
            ServiceDataModel.HeaderModel header = new ServiceDataModel.HeaderModel();

            header.AppToken = CommonProperty.prop_strAppToken;
            transactionRequest.HeaderModel = header;
            transactionRequest.TransactionHeadList = PosManager.xGetInstance().GetUnsendTransactionList();

            ServiceDataModel.TransactionListResponseModel transactionListResponse = xGateManager.vSaveTransactionList(transactionRequest);
            PosManager.xGetInstance().UpdateTransactionForSendServer(transactionListResponse);

            return true;
        }

        public bool UpdateTransactionIsSend(long transactionHeadId)
        {
            return Dao.xGetInstance().bUpdateTransactionIsSend(transactionHeadId);
        }

        void vPrintReceipt()
        {
            if (prop_xPosManagerData.lReceiptTotalPrice - prop_xPosManagerData.lReceiptTotalPayment <= 0)
            {
            }
        }
    }
}
