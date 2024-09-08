using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class InfoBoxPaymentDetail : Form
    {
        int m_iSelectedIndex = 0;

        public InfoBoxPaymentDetail(PosManagerData prm_xPosManagerData)
        {
            InitializeComponent();

            try
            {
                labelTotalAmount.Text = string.Format(" NET SATIŞ: {0:#,0.00} {1}", Convert.ToDecimal(prm_xPosManagerData.decReceiptTotalPrice)/100, LabelTranslations.strGet("CurrencySymbol"));
                if (prm_xPosManagerData.decReceiptTotalPrice <prm_xPosManagerData.decReceiptTotalPayment)
                    labelBalanceAmount.Text = string.Format("PARA ÜSTÜ: {0:#,0.00} {1}", (Convert.ToDecimal(prm_xPosManagerData.decReceiptTotalPayment - prm_xPosManagerData.decReceiptTotalPrice)/100), LabelTranslations.strGet("CurrencySymbol"));
                else
                    labelBalanceAmount.Text = string.Empty;

                if (prm_xPosManagerData != null && prm_xPosManagerData.xTransactionDataModel != null && prm_xPosManagerData.xTransactionDataModel.xListPaymentDataModel != null)
                    foreach (PaymentDataModel xPaymentDataModel in prm_xPosManagerData.xTransactionDataModel.xListPaymentDataModel)
                    {
                        bAddPayment(xPaymentDataModel);
                    }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (dataGridViewPayments.Rows.Count > 0 && m_iSelectedIndex > 0)
            {
                m_iSelectedIndex--;
                dataGridViewPayments.Rows[m_iSelectedIndex].Selected = true;
                dataGridViewPayments.FirstDisplayedScrollingRowIndex = m_iSelectedIndex;
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (dataGridViewPayments.Rows.Count > 0 && m_iSelectedIndex < dataGridViewPayments.Rows.Count - 1)
            {
                m_iSelectedIndex++;
                dataGridViewPayments.Rows[m_iSelectedIndex].Selected = true;
                dataGridViewPayments.FirstDisplayedScrollingRowIndex = m_iSelectedIndex;
            }
        }

        private bool bAddPayment(PaymentDataModel prm_xPaymentDataModel)
        {
            if (prm_xPaymentDataModel == null)
                return false;

            int iRowIndex = dataGridViewPayments.Rows.Add(prm_xPaymentDataModel.xPaymentTypeDataModel.strTypeName, decimal.Parse(prm_xPaymentDataModel.lAmount.ToString())/100);
            dataGridViewPayments.Rows[iRowIndex].Selected = true;
            dataGridViewPayments.FirstDisplayedScrollingRowIndex = iRowIndex;

            m_iSelectedIndex = iRowIndex;

            return true;
        }

        private void InfoBoxPaymentDetail_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewPayments.BackgroundColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
                dataGridViewPayments.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //xEventHandlerGetPrice.Invoke(this, e);
            TransactionHeadDataModel xTransactionHeadDataModel = new TransactionHeadDataModel();
            
           
            //xTransactionHeadDataModel.iFkCashierId = 0;
            //xTransactionHeadDataModel.xTransactionDateTime = DateTime.Now;
            //xTransactionHeadDataModel.iFkTransactionDocumentTypeId = 0;
            //xTransactionHeadDataModel.iFkCustomerId = 0;
            //xTransactionHeadDataModel.xCustomerDataModel = null;
            //xTransactionHeadDataModel.strTransactionNo = "1";
            //xTransactionHeadDataModel.iReceiptNumber = 0;
            //xTransactionHeadDataModel.iZNumber = 0;
            //xTransactionHeadDataModel.decReceiptTotalPrice = 0;
            //xTransactionHeadDataModel.decReceiptTotalVat = 0;
            //xTransactionHeadDataModel.decTotalDiscountAmount = 0;
            //xTransactionHeadDataModel.decTransactionsDiscountAmount = 0;
            //xTransactionHeadDataModel.decCustomerTotalDiscountAmount = 0;
            //xTransactionHeadDataModel.decPromotionTotalDiscountAmount = 0;
            //xTransactionHeadDataModel.decSurchargeAmount = 0;
            //xTransactionHeadDataModel.decPaymentAmount = 0;
            //xTransactionHeadDataModel.decChangeAmount = 0;
            //xTransactionHeadDataModel.decRoundAmount = 0;
            //xTransactionHeadDataModel.bIsVoided = true;
            SaleFlex.Data.AccessLayer.Dao.xGetInstance().bUpdateTransactionHead(xTransactionHeadDataModel);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
