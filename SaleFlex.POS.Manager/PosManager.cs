using System;
using System.Collections.Generic;
using System.Linq;

using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;

namespace SaleFlex.POS.Manager
{
    public partial class PosManager
    {
        protected bool m_bServieModeActive = false;
        protected bool m_bLoginSuccess = false;
        protected bool m_bAuthSuccess = false;
        protected List<EnumFormType> m_xListFormType = new List<EnumFormType>();
        private static PosManager m_xGlobalsInstance = new PosManager();

        public static PosManager xGetInstance()
        {
            if (m_xGlobalsInstance == null)
                m_xGlobalsInstance = new PosManager();
            return m_xGlobalsInstance;
        }

        public PosManager()
        {
        }

        public void vPosManagerInitialize()
        {
            m_xListFormType.Add(CommonProperty.prop_enumStartFormType);

            WebApi xWebApi = new WebApi();
            xWebApi.vAskForUpdateThread();
        }

        public string strCurrentFormName
        {
            get
            {
                if (m_bServieModeActive == true)
                {
                    return EnumFormType.SERVICE.ToString();
                }

                if (m_xListFormType.Count > 0)
                {
                    EnumFormType enumFormType = m_xListFormType.LastOrDefault();
                    FormFunctionDataModel xFormFunctionDataModel = Dao.xGetInstance().xGetFormFunction(enumFormType);

                    if (xFormFunctionDataModel != null)
                    {
                        if (xFormFunctionDataModel.bNeedAuth == true && m_bAuthSuccess == false)
                        {
                            return EnumFormType.LOGIN_SERVICE.ToString();
                        }
                        else if (xFormFunctionDataModel.bNeedLogin == true && m_bLoginSuccess == false)
                        {
                            if (enumFormType == EnumFormType.SALE)
                                return EnumFormType.LOGIN.ToString();
                            else
                                return EnumFormType.LOGIN_EXT.ToString();
                        }
                        else
                        {
                            return enumFormType.ToString();
                        }
                    }
                    else
                    {
                        return EnumFormType.LOGIN.ToString();
                    }
                }
                else
                {
                    return EnumFormType.LOGIN.ToString();
                }
            }
        }

        public bool bServiceModeActive
        {
            get
            {
                return m_bServieModeActive;
            }
            set
            {
                m_bServieModeActive = value;
            }
        }

        public PluDataModel xFindPlu(string prm_strPluBarcode)
        {
            PluDataModel xPluDataModel = null;

            try
            {
                xPluDataModel = Dao.xGetInstance().xGetPluByCode(prm_strPluBarcode);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xPluDataModel;
        }

        public PluDataModel xFindPlu(int prm_iPluNo)
        {
            PluDataModel xPluDataModel = null;

            try
            {
                xPluDataModel = Dao.xGetInstance().xGetPlu(prm_iPluNo.ToString());
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xPluDataModel;
        }

        public TransactionTypeDataModel xFindTransactionType(int prm_iTransactionTypeNo)
        {
            foreach (var xTransactionType in m_xPosManagerData.xListTransactionTypeDataModel)
            {
                if (xTransactionType.iNo == prm_iTransactionTypeNo)
                {
                    return xTransactionType;
                }
            }

            return null;
        }

        public TransactionDocumentTypeDataModel xFindTransactionDocumentType(EnumDocumentType prm_enumTransactionDocumentTypeNo)
        {
            foreach (var xTransactionDocumentType in m_xPosManagerData.xListTransactionDocumentTypeDataModel)
            {
                if (xTransactionDocumentType.iNo == (int)prm_enumTransactionDocumentTypeNo)
                {
                    return xTransactionDocumentType;
                }
            }

            return null;
        }

        public EnumDocumentType enumChangeDocumentType(EnumDocumentType prm_enumToDocumentType = EnumDocumentType.FiscalReceipt)
        {
            EnumDocumentType enumDocumentTypeTemp = m_enumDocumentType;

            if (m_enumDocumentType == EnumDocumentType.FiscalReceipt && prm_enumToDocumentType != EnumDocumentType.FiscalReceipt && m_enumDocumentState == EnumDocumentState.OPENED)
            {
                bCancelReceipt();
            }

            m_enumDocumentType = prm_enumToDocumentType;

            if (m_xPosManagerData.xTransactionDataModel == null)
                m_xPosManagerData.xTransactionDataModel = new TransactionDataModel();

            TransactionDocumentTypeDataModel xTransactionDocumentTypeDataModel = xFindTransactionDocumentType(prm_enumToDocumentType);
            m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.xTransactionDocumentTypeDataModel = xTransactionDocumentTypeDataModel;

            if (m_xPosManagerData.xTransactionDataModel.bTransactionStarted == true && Dao.xGetInstance().bUpdateTransactionHead(m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel) == false)
            {
                m_enumDocumentType = enumDocumentTypeTemp;
            }

            return m_enumDocumentType;
        }

        public bool bLogin(string prm_strCashierName, string prm_strCashierPassword, string prm_strAdminPassword)
        {
            bool bLoginSuccessfull = false;

            EnumFormType enumFormType = m_xListFormType.LastOrDefault();
            if (enumFormType == 0) enumFormType = EnumFormType.SALE;

            CashierDataModel xCashierDataModel = Dao.xGetInstance().xGetCashierByFullname(prm_strCashierName);
            if (xCashierDataModel != null)
            {
                if (enumFormType == EnumFormType.SALE && xCashierDataModel.strPassword == prm_strCashierPassword)
                {
                    bLoginSuccessfull = true;
                }
                else if (enumFormType == EnumFormType.SERVICE)
                {
                    m_bAuthSuccess = true;
                    bLoginSuccessfull = true;
                }
                else if (enumFormType == EnumFormType.REPORT && xCashierDataModel.bIsAdministrator == true && xCashierDataModel.strPassword == prm_strCashierPassword)
                {
                    bLoginSuccessfull = true;
                    CommonProperty.prop_strLastLoginAdminPassword = prm_strCashierPassword;
                }

                if (bLoginSuccessfull == true)
                {
                    m_bServieModeActive = false;

                    if (enumFormType != EnumFormType.SERVICE)
                    {
                        m_xPosManagerData.xCashierDataModel = xCashierDataModel;

                        CommonProperty.prop_strLastLoginUserName = string.Format("{0} {1}", m_xPosManagerData.xCashierDataModel.strName, m_xPosManagerData.xCashierDataModel.strLastName);
                        CommonProperty.prop_iLastLoginUserNo = xCashierDataModel.iNo;
                        CommonProperty.prop_strLastLoginPassword = prm_strCashierPassword;

                        m_bLoginSuccess = true;
                    }

                    return true;
                }
            }

            return false;
        }

        public void vLogout()
        {
            m_xListFormType.Clear();
            m_xListFormType.Add(EnumFormType.FUNCTION);

            m_xPosManagerData.xCashierDataModel = null;

            m_bServieModeActive = false;
            m_bAuthSuccess = false;
            m_bLoginSuccess = false;
        }

        public void vBackToPreviousForm()
        {
            if (m_xListFormType.Count > 0)
                m_xListFormType.RemoveAt(m_xListFormType.Count - 1);

            if (m_xListFormType.Count == 0)
            {
                m_xListFormType.Add(EnumFormType.SALE);
                m_bAuthSuccess = false;
                m_bLoginSuccess = false;

                m_xPosManagerData.xCashierDataModel = null;

                m_bServieModeActive = false;
            }
        }

        public void vChangeForm(EnumFormType prm_enumFormType)
        {
            FormFunctionDataModel xFormFunctionDataModel = Dao.xGetInstance().xGetFormFunction((int)prm_enumFormType);

            if (xFormFunctionDataModel != null)
            {
                if (xFormFunctionDataModel.bNeedAuth == true)
                    m_bAuthSuccess = false;

                if (xFormFunctionDataModel.bNeedLogin == true)
                    m_bLoginSuccess = false;

                m_xListFormType.Add(prm_enumFormType);
            }
        }

        public void vUpdatePluStock(List<StockDataModel> updatedStockList)
        {
            try
            {
                if (updatedStockList == null || updatedStockList.Count == 0)
                {
                    throw new Exception("StockListCanNotBeNull");
                }
                Dao.xGetInstance().SavePluStock(updatedStockList);
                ExternalService externalService = new ExternalService();
                var pluStockList = new List<ServiceDataModel.PluStockModel>();

                foreach (var updatedStock in updatedStockList)
                {
                    if (!string.IsNullOrEmpty(updatedStock.Barcode))
                    {
                        var pluStock = new ServiceDataModel.PluStockModel
                        {
                            Id = updatedStock.PluId,
                            BarcodeId = updatedStock.BarcodeId,
                            Barcode = updatedStock.Barcode,
                            Code = updatedStock.Code,
                            MinStock = updatedStock.MinStock,
                            PurchasePrice = Convert.ToInt32(updatedStock.PurchasePrice),
                            SalePrice = Convert.ToInt32(updatedStock.SalePrice),
                            ShortName = updatedStock.ShortName,
                            StockUnitNo = updatedStock.StockUnitNo,
                            Stock = updatedStock.Stock,
                            FkPluMainGroupId = 1,
                            VatNo = updatedStock.No
                        };
                        pluStockList.Add(pluStock);
                    }
                    else
                    {
                        throw new ArgumentException("BarcodeCanNotBeNull!");
                    }
                }
                var pluListSaveResponse = externalService.vSavePluList(pluStockList);
                Dao.xGetInstance().UpdatePluForSendServer(pluListSaveResponse);
            }
            catch (Exception ex)
            {
                Trace.vInsertError(ex);
                throw ex;
            }
        }

        public bool bUpdateFormControlName(int formControlId, string formControlName)
        {
            try
            {
               return Dao.xGetInstance().bUpdateFormControlName(formControlId, formControlName);
            }
            catch
            {
                return false;
            }
        }

        public void UpdateTransactionForSendServer(ServiceDataModel.TransactionListResponseModel transactionListResponse)
        {
            try
            {
                foreach (var transaction in transactionListResponse.transactionHeadList)
                {
                    Dao.xGetInstance().UpdateTransactionForSendServer(transaction);
                }
            }
            catch(Exception ex)
            {
                Trace.vInsertError(ex);
            }
        }

        public string GetBarcodeByBarcodeId(long barcodeId)
        {
            try
            {
                return Dao.xGetInstance().GetBarcodeByBarcodeId(barcodeId);
            }
            catch
            {
                return "0";
            }
        }

    }
}
