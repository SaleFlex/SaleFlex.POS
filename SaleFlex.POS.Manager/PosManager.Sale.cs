using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.CommonLibrary;

namespace SaleFlex.POS.Manager
{
    public partial class PosManager
    {
        private bool bStartReceipt()
        {
            bool bReturnValue = false;

            if (m_xPosManagerData.xTransactionDataModel == null)
            {
                m_xPosManagerData.xTransactionDataModel = new TransactionDataModel();
            }

            m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber = Dao.xGetInstance().iGetLastRecieptNo() + 1;

            if (m_xPosManagerData.xTransactionDataModel.bTransactionStarted == false)
            {
                if (bInsertTransactionHead() == true)
                {
                    if (m_xPosManagerData.xTransactionDataModel.bTransactionStarted == true)
                    {
                        m_enumDocumentState = EnumDocumentState.OPENED;
                        bReturnValue = true;
                    }
                    else
                    {
                        m_enumDocumentResult = EnumDocumentResult.NONE;
                    }
                }
            }
            else
            {
                bReturnValue = true;
            }

            return bReturnValue;
        }

        private bool bInsertTransactionHead()
        {
            TransactionHeadDataModel xTransactionHeadDataModel = new TransactionHeadDataModel();
            TransactionDocumentTypeDataModel xTransactionDocumentTypeDataModel = xFindTransactionDocumentType(m_enumDocumentType);

            long lSequenceNumber = lGetTransactionSequenceNumber(xTransactionDocumentTypeDataModel.strName);

            xTransactionHeadDataModel.iFkCashierId = m_xPosManagerData.xCashierDataModel.iId;
            xTransactionHeadDataModel.xCashierDataModel = m_xPosManagerData.xCashierDataModel;
            xTransactionHeadDataModel.xTransactionDateTime = DateTime.Now;
            xTransactionHeadDataModel.iFkTransactionDocumentTypeId = xTransactionDocumentTypeDataModel.iId;
            xTransactionHeadDataModel.iTransactionDocumentTypeNo = xTransactionDocumentTypeDataModel.iNo;
            xTransactionHeadDataModel.xTransactionDocumentTypeDataModel = xTransactionDocumentTypeDataModel;
            xTransactionHeadDataModel.iFkCustomerId = 0;
            xTransactionHeadDataModel.xCustomerDataModel = null;
            xTransactionHeadDataModel.strTransactionNo = string.Format("{0}", lSequenceNumber);
            xTransactionHeadDataModel.iReceiptNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber;
            xTransactionHeadDataModel.iZNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber;
            xTransactionHeadDataModel.lReceiptTotalPrice = 0;
            xTransactionHeadDataModel.lReceiptTotalVat = 0;
            xTransactionHeadDataModel.lTotalDiscountAmount = 0;
            xTransactionHeadDataModel.lTransactionsDiscountAmount = 0;
            xTransactionHeadDataModel.lCustomerTotalDiscountAmount = 0;
            xTransactionHeadDataModel.lPromotionTotalDiscountAmount = 0;
            xTransactionHeadDataModel.lSurchargeAmount = 0;
            xTransactionHeadDataModel.lPaymentAmount = 0;
            xTransactionHeadDataModel.lChangeAmount = 0;
            xTransactionHeadDataModel.lRoundAmount = 0;
            xTransactionHeadDataModel.bIsVoided = false;

            if (Dao.xGetInstance().bInsertTransactionHead(ref xTransactionHeadDataModel) == true)
            {
                m_xPosManagerData.xTransactionDataModel.bTransactionStarted = true;
                m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel = xTransactionHeadDataModel;
            }

            return m_xPosManagerData.xTransactionDataModel.bTransactionStarted;
        }

        private bool bUpdateTransactionHead(TransactionHeadDataModel prm_xTransactionHeadDataModel)
        {

            if (Dao.xGetInstance().bUpdateTransactionHead(prm_xTransactionHeadDataModel) == false)
            {
                return false;
            }
            return true;
        }

        private bool bCancelTransactionDetail(ref TransactionDetailDataModel prm_xTransactionDetailDataModel)
        {
            int iId = prm_xTransactionDetailDataModel.iId;

            if (Dao.xGetInstance().bCancelTransactionDetail(iId) == false)
            {
                return false;
            }

            prm_xTransactionDetailDataModel.bCanceled = true;

            return true;
        }

        private bool bInsertTransactionDetail(DepartmentDataModel prm_xSaledDepartmentDataModel, long prm_decPrice, long prm_decQuantity)
        {
            TransactionDetailDataModel xTransactionDetailDataModel = new TransactionDetailDataModel();

            if (prm_xSaledDepartmentDataModel != null)
                xTransactionDetailDataModel.xDepartmentDataModel = prm_xSaledDepartmentDataModel;
            else
                return false;

            xTransactionDetailDataModel.iFkDepartmentId = prm_xSaledDepartmentDataModel.iId;
            xTransactionDetailDataModel.xDepartmentDataModel = prm_xSaledDepartmentDataModel;
            xTransactionDetailDataModel.iFkTransactionHeadId = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId;
            xTransactionDetailDataModel.decQuantity = prm_decQuantity;
            xTransactionDetailDataModel.decPrice = prm_decPrice;
            xTransactionDetailDataModel.decTotalPrice = prm_decPrice * prm_decQuantity;
            xTransactionDetailDataModel.decTotalVat = xTransactionDetailDataModel.decTotalPrice * prm_xSaledDepartmentDataModel.xVat.iRate / 100;
            xTransactionDetailDataModel.decTotalPriceWithoutVat = xTransactionDetailDataModel.decTotalPrice - xTransactionDetailDataModel.decTotalVat;

            if (Dao.xGetInstance().bInsertTransactionDetail(ref xTransactionDetailDataModel) == true)
            {
                m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel.Add(xTransactionDetailDataModel);

                m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice += xTransactionDetailDataModel.decTotalPrice;
                m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat += xTransactionDetailDataModel.decTotalVat;

                return true;
            }

            return false;
        }

        private bool bInsertTransactionDetail(PluDataModel prm_xSaledPluDataModel, long prm_decPrice, long prm_decQuantity)
        {
            TransactionDetailDataModel xTransactionDetailDataModel = new TransactionDetailDataModel();

            if (prm_xSaledPluDataModel != null)
                xTransactionDetailDataModel.xPluDataModel = prm_xSaledPluDataModel;
            else
                return false;

            xTransactionDetailDataModel.iFkPluId = prm_xSaledPluDataModel.iId;
            xTransactionDetailDataModel.xPluDataModel = prm_xSaledPluDataModel;
            xTransactionDetailDataModel.iFkTransactionHeadId = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId;
            xTransactionDetailDataModel.decQuantity = prm_decQuantity;
            xTransactionDetailDataModel.decPrice = prm_decPrice;
            xTransactionDetailDataModel.decTotalPrice = prm_xSaledPluDataModel.StockUnitNo == 1 ? Convert.ToInt32(Convert.ToDecimal(prm_decPrice * prm_decQuantity) / 1000) : (prm_decPrice * prm_decQuantity);
            xTransactionDetailDataModel.decTotalVat = xTransactionDetailDataModel.decTotalPrice * prm_xSaledPluDataModel.xVat.iRate / 100;
            xTransactionDetailDataModel.decTotalPriceWithoutVat = xTransactionDetailDataModel.decTotalPrice - xTransactionDetailDataModel.decTotalVat;

            if (Dao.xGetInstance().bInsertTransactionDetail(ref xTransactionDetailDataModel) == true)
            {
                m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel.Add(xTransactionDetailDataModel);

                m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice += xTransactionDetailDataModel.decTotalPrice;
                m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat += xTransactionDetailDataModel.decTotalVat;

                return true;
            }

            return false;
        }

        private bool bInsertTransactionDetail(DepartmentDataModel prm_xSaledDepartmentDataModel, PluDataModel prm_xSalesPluDataModel)
        {
            Trace.vInsert(enumTraceLevel.Unnecessary, "bInsertTransactionDetail Called.");
            TransactionDetailDataModel xTransactionDetailDataModel = m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel.Last();

            if (prm_xSaledDepartmentDataModel != null)
                xTransactionDetailDataModel.xDepartmentDataModel = prm_xSaledDepartmentDataModel;
            else if (prm_xSalesPluDataModel != null)
                xTransactionDetailDataModel.xPluDataModel = prm_xSalesPluDataModel;
            else
                return false;

            if ((prm_xSaledDepartmentDataModel != null && Dao.xGetInstance().bSaleDepartment(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId, ref xTransactionDetailDataModel) == true) ||
                (prm_xSalesPluDataModel != null && Dao.xGetInstance().bSalePlu(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId, ref xTransactionDetailDataModel) == true))
            {
                m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel[m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel.Count - 1] = xTransactionDetailDataModel;
                return true;
            }

            return false;
        }

        public bool bClearCustomer()
        {
            m_xPosManagerData.xTransactionDataModel.xCustomerDataModel = null;
            return true;
        }

        public bool bSetCustomer(CustomerDataModel prm_xCustomerDataModel)
        {
            m_xPosManagerData.xTransactionDataModel.xCustomerDataModel = prm_xCustomerDataModel;
            m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iFkCustomerId = prm_xCustomerDataModel.iId;
            return bUpdateTransactionHead(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel);
        }

        public bool bClearTransaction()
        {
            m_xPosManagerData.xTransactionDataModel = new TransactionDataModel();
            m_xPosManagerData.xTransactionDataModel.bTransactionStarted = false;
            m_xPosManagerData.decReceiptTotalPrice = 0;
            m_xPosManagerData.decReceiptTotalVat = 0;
            m_xPosManagerData.decReceiptTotalPayment = 0;
            m_xPosManagerData.decTotalPrice = 0;


            return true;
        }

        public bool bSaleDepartment(int prm_iDepartmentNo, long prm_decPrice, long prm_decQuantity)
        {
            if (m_xPosManagerData.xCashierDataModel == null)
            {
                m_enumErrorCode = EnumErrorCode.NEED_CASHIER_LOGIN;
                return false;
            }

            long decPrice = 0;
            long decQuantity = 1;
            DepartmentDataModel xSaledDepartmentDataModel = null;

            foreach (DepartmentDataModel xDepartmentDataModel in m_xPosManagerData.xListDepartmentDataModel)
            {
                if (xDepartmentDataModel.iNo == prm_iDepartmentNo)
                {
                    decPrice = prm_decPrice.bOverflowAmountCheck() == true ? xDepartmentDataModel.lDefaultPrice : prm_decPrice;
                    decQuantity = prm_decQuantity;
                    xSaledDepartmentDataModel = xDepartmentDataModel;

                    break;
                }
            }

            if (xSaledDepartmentDataModel == null)
            {
                m_enumErrorCode = EnumErrorCode.DEPARTMENT_NOT_FOUND;
                return false;
            }

            if (bStartReceipt() == false)
            {
                m_enumErrorCode = EnumErrorCode.DEPARTMENT_NOT_FOUND;
                return false;
            }

            if (bInsertTransactionDetail(xSaledDepartmentDataModel, decPrice, decQuantity) == false)
            {
                m_enumErrorCode = EnumErrorCode.DEPARTMENT_NOT_FOUND;
                return false;
            }

            if (bUpdateTransactionHead(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel) == false)
            {
                m_enumErrorCode = EnumErrorCode.DEPARTMENT_NOT_FOUND;
                return false;
            }

            return true;
        }

        public bool bSalePluByCode(string prm_strPluCode, long prm_decPrice, long prm_lQuantity)
        {
            Trace.vInsert(enumTraceLevel.Unnecessary, "bSalePlu Called.");

            if (m_xPosManagerData.xCashierDataModel == null)
            {
                m_enumErrorCode = EnumErrorCode.NEED_CASHIER_LOGIN;
                return false;
            }

            long decPrice = 0;
            long decQuantity = 1;

            PluDataModel xSalesPluDataModel = Dao.xGetInstance().xGetPluByCode(prm_strPluCode);

            if (xSalesPluDataModel == null)
            {
                m_enumErrorCode = EnumErrorCode.PLU_NOT_FOUND;
                return false;
            }

            Enum.TryParse(xSalesPluDataModel.strStockUnit, true, out EnumStockUnit enumStockUnit);
            int iStock = (int)(prm_lQuantity / (int)enumStockUnit);
            //prm_lQuantity = xSalesPluDataModel.StockUnitNo == 2 ? (prm_lQuantity / 1000) : prm_lQuantity;
            //int iStock = Convert.ToInt32(Dao.xGetInstance().xGetStockUnitByNo(xSalesPluDataModel.StockUnitNo).Coefficient * (Convert.ToDecimal(prm_lQuantity)/1000));
            //int iStock = Convert.ToInt32(xSalesPluDataModel.StockUnitNo == 1 ? prm_lQuantity : (prm_lQuantity / 1000));
            if (prop_enumDocumentType != EnumDocumentType.Return)
            {
                if (xSalesPluDataModel.bAllowNegativeStock == true && xSalesPluDataModel.iStock < iStock)
                {
                    m_enumErrorCode = EnumErrorCode.INSUFFICIENT_STOCK;
                    return false;
                }
            }

            decPrice = prm_decPrice.bOverflowAmountCheck() == true ? (xSalesPluDataModel.xListPluBarcodeDataModel == null ? xSalesPluDataModel.iSalePrice : xSalesPluDataModel.xListPluBarcodeDataModel[0].decSalePrice) : prm_decPrice;
            decQuantity = iStock;

            if (bStartReceipt() == false)
            {
                m_enumErrorCode = EnumErrorCode.PLU_NOT_FOUND;
                return false;
            }

            if (bInsertTransactionDetail(xSalesPluDataModel, decPrice, decQuantity) == false)
            {
                m_enumErrorCode = EnumErrorCode.PLU_NOT_FOUND;
                return false;
            }

            if (bUpdateTransactionHead(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel) == false)
            {
                m_enumErrorCode = EnumErrorCode.PLU_NOT_FOUND;
                return false;
            }

            if (prop_enumDocumentType != EnumDocumentType.Return)
            {
                Dao.xGetInstance().bSetPluStockByCode(prm_strPluCode, (int)(xSalesPluDataModel.iStock - iStock));
            }
            else
            {
                Dao.xGetInstance().bSetPluStockByCode(prm_strPluCode, (int)(xSalesPluDataModel.iStock + iStock));
            }
            //Trace.vInsert(enumTraceLevel.Unnecessary, "bSalePlu Ended");

            return true;
        }

        public bool bSalePlu(string prm_strPluBarcode, long prm_decPriceOfOneProduct, long prm_decQuantityOfProduct)
        {
            var strPluCode = Dao.xGetInstance().strGetPluCode(prm_strPluBarcode);

            if (strPluCode == string.Empty)
            {
                m_enumErrorCode = EnumErrorCode.PLU_NOT_FOUND;
                return false;
            }

            return bSalePluByCode(strPluCode, prm_decPriceOfOneProduct, prm_decQuantityOfProduct);
        }

        public bool bCancelReceipt()
        {
            int iReceiptNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber;
            int iZNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber;
            decimal decReceiptTotalPrice = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice;
            decimal decReceiptTotalVat = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat;

            if (m_xPosManagerData.xCashierDataModel == null)
            {
                m_enumErrorCode = EnumErrorCode.CAN_NOT_CANCEL_DOCUMENT;
                return false;
            }

            if (m_xPosManagerData.xTransactionDataModel.bTransactionStarted == false)
            {
                m_enumErrorCode = EnumErrorCode.CAN_NOT_CANCEL_DOCUMENT;
                return false;
            }

            if (Dao.xGetInstance().bCancelTransaction(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId) == false)
            {
                m_enumErrorCode = EnumErrorCode.CAN_NOT_CANCEL_DOCUMENT;
                return false;
            }

            if (Dao.xGetInstance().xSuspendedListValues != null && Dao.xGetInstance().xSuspendedListValues.Contains(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId))
            {
                Dao.xGetInstance().vRemoveFromSuspendedList(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId);
            }


            foreach (var xTransactionDetail in m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel)
            {
                PluDataModel plu = Dao.xGetInstance().xGetPluById(xTransactionDetail.iFkPluId);
                if (prop_enumDocumentType != EnumDocumentType.Return)
                {
                    Dao.xGetInstance().bSetPluStockByCode(plu.strCode, (int)(plu.iStock + xTransactionDetail.decQuantity));
                }
                else
                {
                    Dao.xGetInstance().bSetPluStockByCode(plu.strCode, (int)(plu.iStock - xTransactionDetail.decQuantity));
                }
            }

            m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber = iReceiptNumber++;
            m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber = iZNumber;
            m_xPosManagerData.decReceiptTotalPrice = 0;
            m_xPosManagerData.decReceiptTotalVat = 0;

            m_enumDocumentResult = EnumDocumentResult.CANCELED_BY_CASHIER;
            m_enumDocumentState = EnumDocumentState.CLOSED;

            return true;
        }

        public bool bSuspendReceipt()
        {
            int iReceiptNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber;
            int iZNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber;
            decimal decReceiptTotalPrice = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice;
            decimal decReceiptTotalVat = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat;

            if (m_xPosManagerData.xCashierDataModel == null)
            {
                m_enumErrorCode = EnumErrorCode.CAN_NOT_CANCEL_DOCUMENT;
                return false;
            }

            if (m_xPosManagerData.xTransactionDataModel.bTransactionStarted == false)
            {
                m_enumErrorCode = EnumErrorCode.CAN_NOT_CANCEL_DOCUMENT;
                return false;
            }

            if (!Dao.xGetInstance().bAddSuspendedList(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId))
            {
                m_enumErrorCode = EnumErrorCode.SUSPEND_QUEUE_FULL;
                return false;
            }

            m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber = iReceiptNumber++;
            m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber = iZNumber;
            m_xPosManagerData.decReceiptTotalPrice = 0;
            m_xPosManagerData.decReceiptTotalVat = 0;

            m_enumDocumentResult = EnumDocumentResult.SUSPENDED;
            m_enumDocumentState = EnumDocumentState.SUSPENDED;

            return true;
        }

        public bool bBacktoReceipt()
        {
            bool bReturnValue = false;
            m_enumErrorCode = EnumErrorCode.NONE;
            int iTransactionHeadId = 0;
            if (m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId == 0)
            {
                if (Dao.xGetInstance().xSuspendedListValues.Count == 1)
                {
                    iTransactionHeadId = Dao.xGetInstance().xSuspendedListValues[0];
                }
                else if (Dao.xGetInstance().xSuspendedListValues.Count == 0)
                {
                    m_enumErrorCode = EnumErrorCode.SUSPEND_NOT_FOUND;
                    return false;
                }
                else
                {
                    iTransactionHeadId = Dao.xGetInstance().xSuspendedListValues[0] > Dao.xGetInstance().xSuspendedListValues[1] ? Dao.xGetInstance().xSuspendedListValues[1] : Dao.xGetInstance().xSuspendedListValues[0];
                }
                //1) iTransactionHeadId'ye göre veri getirilip doldurulacak.
                //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel = Dao.xGetInstance().xGetTransactionHeader(iTransactionHeadId);
                m_xPosManagerData.xTransactionDataModel = Dao.xGetInstance().xGetTransactionDataModelByHeadId(iTransactionHeadId);
                m_xPosManagerData.xTransactionDataModel.bTransactionStarted = true;
                m_xPosManagerData.decReceiptTotalPrice = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice;
                m_xPosManagerData.decReceiptTotalVat = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat;
                bReturnValue = true;

            }
            else
            {
                if (Dao.xGetInstance().xSuspendedListValues.Contains(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId))
                {
                    for (int i = 0; i < Dao.xGetInstance().xSuspendedListValues.Count; i++)
                    {
                        if (!(Dao.xGetInstance().xSuspendedListValues[i] == m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId))
                        {
                            iTransactionHeadId = Dao.xGetInstance().xSuspendedListValues[i];

                            //1) komple boşaltılacak.?
                            //2) iTransactionHeadId'ye göre veri getirilip doldurulacak.
                            m_xPosManagerData.xTransactionDataModel = Dao.xGetInstance().xGetTransactionDataModelByHeadId(iTransactionHeadId);
                            m_xPosManagerData.xTransactionDataModel.bTransactionStarted = true;
                            m_xPosManagerData.decReceiptTotalPrice = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice;
                            m_xPosManagerData.decReceiptTotalVat = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat;
                            bReturnValue = true;
                        }
                        else
                        {
                            m_enumErrorCode = EnumErrorCode.SUSPEND_NOT_FOUND;
                            return false;
                        }
                    }
                }
                else
                {
                    m_enumErrorCode = EnumErrorCode.NEED_SUSPEND;
                    return false;
                }
            }
            return bReturnValue;
        }

        public bool bPayment(EnumPaymentType prm_enumType, long prm_lPaymentAmount)
        {
            //int iReceiptNumber;
            //int iZNumber;
            //decimal lReceiptTotalPrice;
            //decimal lReceiptTotalVat;
            //decimal decReceiptRemainingTotal;

            PaymentDataModel xPaymentDataModel = new PaymentDataModel();

            if (m_xPosManagerData.xCashierDataModel == null)
            {
                m_enumErrorCode = EnumErrorCode.NEED_CASHIER_LOGIN;
                return false;
            }

            if (m_xPosManagerData.decReceiptTotalPrice <= 0)
            {
                m_enumErrorCode = EnumErrorCode.PAYMENT_NOT_POSSIBLE;
                return false;
            }

            if (prm_enumType == EnumPaymentType.NONE || prm_lPaymentAmount == 0)
            {
                m_enumErrorCode = EnumErrorCode.PAYMENT_NOT_POSSIBLE;
                return false;
            }

            foreach (PaymentTypeDataModel xDataModel in m_xPosManagerData.xListPaymentTypeDataModel)
            {
                if (xDataModel.iTypeNo == (int)prm_enumType)
                {
                    xPaymentDataModel.xPaymentTypeDataModel = xDataModel;
                    break;
                }
            }

            if (xPaymentDataModel.xPaymentTypeDataModel == null)
            {
                m_enumErrorCode = EnumErrorCode.NEED_CASHIER_LOGIN;
                return false;
            }

            xPaymentDataModel.lId = 0;
            xPaymentDataModel.lAmount = prm_lPaymentAmount;

            if (Dao.xGetInstance().bPaymentTemp(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId, ref xPaymentDataModel) == false)
            {
                m_enumErrorCode = EnumErrorCode.PAYMENT_NOT_POSSIBLE;
                return false;
            }

            m_xPosManagerData.decReceiptTotalPayment += prm_lPaymentAmount;

            if (Dao.xGetInstance().bPayment(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId, ref xPaymentDataModel) == false)
            {
                m_enumErrorCode = EnumErrorCode.PAYMENT_NOT_POSSIBLE;
                return false;
            }

            m_xPosManagerData.xTransactionDataModel.xListPaymentDataModel.Add(xPaymentDataModel);

            if (m_xPosManagerData.decReceiptTotalPrice - m_xPosManagerData.decReceiptTotalPayment <= 0)
            {
                if (Dao.xGetInstance().bCloseTransaction(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId) == false)
                {
                    m_enumErrorCode = EnumErrorCode.PLU_NOT_FOUND;
                    return false;
                }

                if (Dao.xGetInstance().xSuspendedListValues != null && Dao.xGetInstance().xSuspendedListValues.Contains(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId))
                {
                    Dao.xGetInstance().vRemoveFromSuspendedList(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId);
                }

                m_enumDocumentState = EnumDocumentState.CLOSED;

                return true;
            }

            return true;
        }

        public bool bRepeatTransaction(TransactionDetailDataModel prm_xTransactionDetailDataModel)
        {
            return true;
        }

        public bool bCancelDepartment(DepartmentDataModel prm_xDepartmentDataModel)
        {
            return false;
        }

        public bool bCancelPlu(PluDataModel prm_xPluDataModel)
        {
            return false;
        }

        public bool bErrorCorrection(TransactionDetailDataModel prm_xTransactionDetailDataModel)
        {
            //int iReceiptNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber;
            //int iZNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber;
            //decimal decTotalPrice = 0;
            //decimal lReceiptTotalPrice = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice;
            //decimal lReceiptTotalVat = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat;
            //decimal decDiscoundSurchargeAmount = 0;
            //decimal decDiscountAmount = 0;
            //decimal lSurchargeAmount = 0;

            //if (m_xFloppy.bCancelLastTransaction(out iReceiptNumber, out iZNumber, out decTotalPrice, out lReceiptTotalPrice, out lReceiptTotalVat) == false)
            //{
            //    CustomMessageBox.Show(m_xFloppy.strGetLastResponseDescription());
            //    return false;
            //}
            ////return bCancelTransaction(prm_xTransactionDetailDataModel);


            //foreach (var xDiscountSurchargeDataModel in prm_xTransactionDetailDataModel.xDiscountSurchargeDataModel)
            //{
            //    if (xDiscountSurchargeDataModel.decDiscountAmount != 0)
            //    {
            //        decDiscoundSurchargeAmount -= xDiscountSurchargeDataModel.decDiscountAmount;
            //        decDiscountAmount += xDiscountSurchargeDataModel.decDiscountAmount;
            //        xDiscountSurchargeDataModel.decDiscountAmount = 0m;
            //    }
            //    else if (xDiscountSurchargeDataModel.lSurchargeAmount != 0)
            //    {
            //        decDiscoundSurchargeAmount += xDiscountSurchargeDataModel.lSurchargeAmount;
            //        lSurchargeAmount += xDiscountSurchargeDataModel.lSurchargeAmount;
            //        xDiscountSurchargeDataModel.lSurchargeAmount = 0m;
            //    }
            //    else if (xDiscountSurchargeDataModel.iDiscountPercentage != -1)
            //    {
            //        decDiscoundSurchargeAmount -= xDiscountSurchargeDataModel.decDiscountSurchargeResult;
            //        decDiscountAmount += xDiscountSurchargeDataModel.decDiscountSurchargeResult;
            //        xDiscountSurchargeDataModel.decDiscountSurchargeResult = 0m;
            //    }
            //    else if (xDiscountSurchargeDataModel.iSurchargePercentage != -1)
            //    {
            //        decDiscoundSurchargeAmount += xDiscountSurchargeDataModel.decDiscountSurchargeResult;
            //        lSurchargeAmount += xDiscountSurchargeDataModel.decDiscountSurchargeResult;
            //        xDiscountSurchargeDataModel.decDiscountSurchargeResult = 0m;
            //    }
            //}

            //int iIndex = m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel.FindIndex(
            //      delegate (TransactionDetailDataModel xTransactionDetailDataModel)
            //      {
            //          return xTransactionDetailDataModel.lId == prm_xTransactionDetailDataModel.lId;
            //      });
            //m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel[iIndex] = prm_xTransactionDetailDataModel;

            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber = iReceiptNumber;
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber = iZNumber;
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice = lReceiptTotalPrice.lConvertToLong();
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat = lReceiptTotalVat.lConvertToLong();
            //m_xPosManagerData.decReceiptTotalDiscount -= decDiscountAmount;
            //m_xPosManagerData.decReceiptTotalSurcharge -= lSurchargeAmount;

            //if (bUpdateTransactionHead(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel) == false)
            //{
            //    //return false;
            //}

            //m_xPosManagerData.decTotalPrice = decTotalPrice;
            //m_xPosManagerData.lReceiptTotalPrice = lReceiptTotalPrice;
            //m_xPosManagerData.lReceiptTotalVat = lReceiptTotalVat;

            //OnTotalValuesChanged(new FiscalModuleEventArgs(m_xPosManagerData, m_enumDocumentType, m_enumDocumentResult));

            return true;
        }

        public bool bCancelTransaction(TransactionDetailDataModel prm_xTransactionDetailDataModel)
        {
            int iReceiptNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber;
            int iZNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber;
            long decTotalPrice = 0;
            long decReceiptTotalPrice = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice;
            long decReceiptTotalVat = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat;
            long decDiscoundSurchargeAmount = 0;
            long decDiscountAmount = 0;
            long decSurchargeAmount = 0;

            if (prm_xTransactionDetailDataModel.xDepartmentDataModel != null)
            {
                foreach (var xDiscountSurchargeDataModel in prm_xTransactionDetailDataModel.xDiscountSurchargeDataModel)
                {
                    if (xDiscountSurchargeDataModel.decDiscountAmount != 0)
                    {
                        decDiscoundSurchargeAmount -= xDiscountSurchargeDataModel.decDiscountAmount;
                        decDiscountAmount += xDiscountSurchargeDataModel.decDiscountAmount;

                    }
                    else if (xDiscountSurchargeDataModel.decSurchargeAmount != 0)
                    {
                        decDiscoundSurchargeAmount += xDiscountSurchargeDataModel.decSurchargeAmount;
                        decSurchargeAmount += xDiscountSurchargeDataModel.decSurchargeAmount;
                    }
                    else if (xDiscountSurchargeDataModel.iDiscountPercentage != -1)
                    {
                        decDiscoundSurchargeAmount -= xDiscountSurchargeDataModel.decDiscountSurchargeResult;
                        decDiscountAmount += xDiscountSurchargeDataModel.decDiscountSurchargeResult;
                    }
                    else if (xDiscountSurchargeDataModel.iSurchargePercentage != -1)
                    {
                        decDiscoundSurchargeAmount += xDiscountSurchargeDataModel.decDiscountSurchargeResult;
                        decSurchargeAmount += xDiscountSurchargeDataModel.decDiscountSurchargeResult;
                    }
                }
            }
            else if (prm_xTransactionDetailDataModel.xPluDataModel != null)
            {
                foreach (var xListPluBarcodeDataModel in prm_xTransactionDetailDataModel.xPluDataModel.xListPluBarcodeDataModel)
                {
                    decReceiptTotalPrice -= prm_xTransactionDetailDataModel.decTotalPrice;//xListPluBarcodeDataModel.decSalePrice
                    decReceiptTotalVat -= xListPluBarcodeDataModel.decPurchasePrice * prm_xTransactionDetailDataModel.xPluDataModel.xVat.iRate;
                }
            }
            else
            {
                m_enumErrorCode = EnumErrorCode.CAN_NOT_CANCEL_TRANSACTION;
                return false;
            }

            if (bCancelTransactionDetail(ref prm_xTransactionDetailDataModel) == false)
            {
                m_enumErrorCode = EnumErrorCode.CAN_NOT_CANCEL_TRANSACTION;
                return false;
            }

            int iIndex = m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel.FindIndex(
                delegate (TransactionDetailDataModel xTransactionDetailDataModel)
                {
                    return xTransactionDetailDataModel.iId == prm_xTransactionDetailDataModel.iId;
                });
            m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel[iIndex] = prm_xTransactionDetailDataModel;

            m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber = iReceiptNumber;
            m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber = iZNumber;
            m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice = decReceiptTotalPrice;
            m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat = decReceiptTotalVat;
            m_xPosManagerData.decReceiptTotalDiscount -= decDiscountAmount;
            m_xPosManagerData.decReceiptTotalSurcharge -= decSurchargeAmount;

            if (bUpdateTransactionHead(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel) == false)
            {
                m_enumErrorCode = EnumErrorCode.CAN_NOT_CANCEL_TRANSACTION;
                return false;
            }

            m_xPosManagerData.decTotalPrice = decTotalPrice;
            m_xPosManagerData.decReceiptTotalPrice = decReceiptTotalPrice;
            m_xPosManagerData.decReceiptTotalVat = decReceiptTotalVat;

            return true;
        }

        public bool bDiscountByAmount(decimal prm_decDiscountAmount, out DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel)
        {
            prm_xDiscountSurchargeDataModel = null;
            //int iReceiptNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber;
            //int iZNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber;
            //decimal lReceiptTotalPrice = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice;
            //decimal lReceiptTotalVat = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat;

            //if (m_xFloppy.bAmountDiscount(prm_decDiscountAmount, out iReceiptNumber, out iZNumber, out lReceiptTotalPrice, out lReceiptTotalVat) == false)
            //{
            //    CustomMessageBox.Show(m_xFloppy.strGetLastResponseDescription());
            //    return false;
            //}

            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber = iReceiptNumber;
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber = iZNumber;
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice = lReceiptTotalPrice.lConvertToLong();
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat = lReceiptTotalVat.lConvertToLong();

            //if (bUpdateTransactionHead(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel) == false)
            //{
            //    //return false;
            //}

            //DiscountSurchargeDataModel xDiscountSurchargeDataModel = new DiscountSurchargeDataModel();
            //xDiscountSurchargeDataModel.bIsDiscount = true;
            //xDiscountSurchargeDataModel.decDiscountAmount = prm_decDiscountAmount;
            //xDiscountSurchargeDataModel.lSurchargeAmount = 0m;
            //xDiscountSurchargeDataModel.iDiscountPercentage = -1;
            //xDiscountSurchargeDataModel.iSurchargePercentage = -1;
            //xDiscountSurchargeDataModel.decDiscountSurchargeResult = prm_decDiscountAmount;

            //m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel[m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel.Count - 1].xDiscountSurchargeDataModel.Add(xDiscountSurchargeDataModel);
            //prm_xDiscountSurchargeDataModel = xDiscountSurchargeDataModel;

            //OnNewDiscountAdded(new FiscalModuleEventArgs(m_xPosManagerData, m_enumDocumentType, m_enumDocumentResult));

            //m_xPosManagerData.decReceiptTotalDiscount += prm_decDiscountAmount;
            //m_xPosManagerData.decTotalPrice = prm_decDiscountAmount;
            //m_xPosManagerData.lReceiptTotalPrice = lReceiptTotalPrice;
            //m_xPosManagerData.lReceiptTotalVat = lReceiptTotalVat;

            //OnTotalValuesChanged(new FiscalModuleEventArgs(m_xPosManagerData, m_enumDocumentType, m_enumDocumentResult));

            return true;
        }

        public bool bSurchargeByAmount(decimal prm_decSurchargeAmount)
        {
            return false;
        }

        public bool bDiscountByPercent(int prm_iDiscountPercentage, out DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel)
        {
            prm_xDiscountSurchargeDataModel = null;
            //int iReceiptNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber;
            //int iZNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber;
            //decimal decTotalPrice = 0;
            //decimal lReceiptTotalPrice = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice;
            //decimal lReceiptTotalVat = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat;

            //if (m_xFloppy.bPercentDiscountOrSurcharge(prm_iDiscountPercentage * -1, out iReceiptNumber, out iZNumber, out decTotalPrice, out lReceiptTotalPrice, out lReceiptTotalVat) == false)
            //{
            //    CustomMessageBox.Show(m_xFloppy.strGetLastResponseDescription());
            //    return false;
            //}

            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber = iReceiptNumber;
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber = iZNumber;
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice = lReceiptTotalPrice.lConvertToLong();
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat = lReceiptTotalVat.lConvertToLong();

            //if (bUpdateTransactionHead(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel) == false)
            //{
            //    //return false;
            //}

            //DiscountSurchargeDataModel xDiscountSurchargeDataModel = new DiscountSurchargeDataModel();
            //xDiscountSurchargeDataModel.bIsDiscount = true;
            //xDiscountSurchargeDataModel.decDiscountAmount = 0m;
            //xDiscountSurchargeDataModel.lSurchargeAmount = 0m;
            //xDiscountSurchargeDataModel.iDiscountPercentage = prm_iDiscountPercentage;
            //xDiscountSurchargeDataModel.iSurchargePercentage = -1;
            //xDiscountSurchargeDataModel.decDiscountSurchargeResult = decTotalPrice;

            //m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel[m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel.Count - 1].xDiscountSurchargeDataModel.Add(xDiscountSurchargeDataModel);
            //prm_xDiscountSurchargeDataModel = xDiscountSurchargeDataModel;

            //OnNewDiscountAdded(new FiscalModuleEventArgs(m_xPosManagerData, m_enumDocumentType, m_enumDocumentResult));

            //m_xPosManagerData.decReceiptTotalDiscount += decTotalPrice;
            //m_xPosManagerData.decTotalPrice = decTotalPrice;
            //m_xPosManagerData.lReceiptTotalPrice = lReceiptTotalPrice;
            //m_xPosManagerData.lReceiptTotalVat = lReceiptTotalVat;

            //OnTotalValuesChanged(new FiscalModuleEventArgs(m_xPosManagerData, m_enumDocumentType, m_enumDocumentResult));

            return true;
        }

        public bool bSurchargeByPercent(int prm_iSurchargePercentage, out DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel)
        {
            prm_xDiscountSurchargeDataModel = null;
            //int iReceiptNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber;
            //int iZNumber = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber;
            //decimal decTotalPrice = 0;
            //decimal lReceiptTotalPrice = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice;
            //decimal lReceiptTotalVat = m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat;

            //if (m_xFloppy.bPercentDiscountOrSurcharge(prm_iSurchargePercentage, out iReceiptNumber, out iZNumber, out decTotalPrice, out lReceiptTotalPrice, out lReceiptTotalVat) == false)
            //{
            //    CustomMessageBox.Show(m_xFloppy.strGetLastResponseDescription());
            //    return false;
            //}

            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber = iReceiptNumber;
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber = iZNumber;
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice = lReceiptTotalPrice.lConvertToLong();
            //m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat = lReceiptTotalVat.lConvertToLong();

            //if (bUpdateTransactionHead(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel) == false)
            //{
            //    //return false;
            //}

            //DiscountSurchargeDataModel xDiscountSurchargeDataModel = new DiscountSurchargeDataModel();
            //xDiscountSurchargeDataModel.bIsDiscount = false;
            //xDiscountSurchargeDataModel.decDiscountAmount = 0m;
            //xDiscountSurchargeDataModel.lSurchargeAmount = 0m;
            //xDiscountSurchargeDataModel.iDiscountPercentage = -1;
            //xDiscountSurchargeDataModel.iSurchargePercentage = prm_iSurchargePercentage;
            //xDiscountSurchargeDataModel.decDiscountSurchargeResult = decTotalPrice;

            //m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel[m_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel.Count - 1].xDiscountSurchargeDataModel.Add(xDiscountSurchargeDataModel);
            //prm_xDiscountSurchargeDataModel = xDiscountSurchargeDataModel;

            //OnNewDiscountAdded(new FiscalModuleEventArgs(m_xPosManagerData, m_enumDocumentType, m_enumDocumentResult));

            //m_xPosManagerData.decReceiptTotalSurcharge += decTotalPrice;
            //m_xPosManagerData.decTotalPrice = decTotalPrice;
            //m_xPosManagerData.lReceiptTotalPrice = lReceiptTotalPrice;
            //m_xPosManagerData.lReceiptTotalVat = lReceiptTotalVat;

            //OnTotalValuesChanged(new FiscalModuleEventArgs(m_xPosManagerData, m_enumDocumentType, m_enumDocumentResult));

            return true;
        }

        public bool bSubTotal()
        {
            if (bUpdateTransactionHead(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel) == false)
            {
                m_enumErrorCode = EnumErrorCode.CAN_NOT_CANCEL_TRANSACTION;
                return false;
            }
            return true;
        }

        public long lGetTransactionSequenceNumber(string prm_strTransactionDocumentTypeName)
        {
            return Dao.xGetInstance().lGetSequence(prm_strTransactionDocumentTypeName);
        }
    }
}
