using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.CommonLibrary;

namespace SaleFlex.POS.Manager
{
    public partial class PosManager
    {
        private bool m_bCouldBeChangeSettings = false;
        public bool bCouldBeChangeSettings
        {
            get
            {
                return m_bCouldBeChangeSettings;
            }
            set
            {
                m_bCouldBeChangeSettings = value;
            }
        }

        public bool bGetAllCashiers(out List<CashierDataModel> prm_xListCashierDataModel)
        {
            prm_xListCashierDataModel = null;

            bool bReturnValue = bReadAllCashiers(out prm_xListCashierDataModel);

            return bReturnValue;
        }

        public bool bReadAllCashiers(out List<CashierDataModel> prm_xListCashierDataModel)
        {
            prm_xListCashierDataModel = null;

            try
            {
                prm_xListCashierDataModel = Dao.xGetInstance().xListGetCashiers();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bGetPos(out PosDataModel prm_xPosDataModel)
        {
            prm_xPosDataModel = null;
            try
            {
                m_xPosManagerData.xPosDataModel = prm_xPosDataModel = Dao.xGetInstance().xGetPosDataModel();

                if (prm_xPosDataModel != null)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool bReadPos()
        {

            try
            {
                m_xPosManagerData.xPosDataModel = Dao.xGetInstance().xGetPosDataModel();
                if (m_xPosManagerData.xPosDataModel != null)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool bReadAllDepartments(out List<DepartmentDataModel> prm_xListDepartmentDataModel)
        {
            prm_xListDepartmentDataModel = null;

            try
            {
                m_xPosManagerData.xListDepartmentDataModel = prm_xListDepartmentDataModel = Dao.xGetInstance().xListGetDepartments();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bReadAllDepartments()
        {
            try
            {
                m_xPosManagerData.xListDepartmentDataModel = Dao.xGetInstance().xListGetDepartments();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bGetAllDepartments(out List<DepartmentDataModel> prm_xListDepartmentDataModel)
        {
            prm_xListDepartmentDataModel = null;

            bool bReturnValue = bReadAllDepartments(out prm_xListDepartmentDataModel);

            return bReturnValue;
        }

        public bool bGetRecieptFooter(out string[] prm_out_straFooterLines)
        {
            prm_out_straFooterLines = null;
            ReceiptFooterDataModel xReceiptFooterDataModel = null;

            bool bReturnValue = bReadRecieptFooter(out xReceiptFooterDataModel);

            if (bReturnValue == true)
            {
                prm_out_straFooterLines = new string[xReceiptFooterDataModel.xListFooterLine.Count];
                for (int iIndex = 0; iIndex < xReceiptFooterDataModel.xListFooterLine.Count; iIndex++)
                {
                    prm_out_straFooterLines[iIndex] = xReceiptFooterDataModel.xListFooterLine[iIndex];
                }
            }

            return bReturnValue;
        }

        public bool bReadRecieptFooter(out ReceiptFooterDataModel prm_xReceiptFooterDataModel)
        {
            prm_xReceiptFooterDataModel = null;

            try
            {
                prm_xReceiptFooterDataModel = Dao.xGetInstance().xGetReceiptFooter();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool bGetRecieptHeader(out string[] prm_out_straHeaderLines)
        {
            prm_out_straHeaderLines = null;
            ReceiptHeaderDataModel xReceiptHeaderDataModel = null;

            bool bReturnValue = bReadRecieptHeader(out xReceiptHeaderDataModel);

            if (bReturnValue == true)
            {
                prm_out_straHeaderLines = new string[xReceiptHeaderDataModel.xListHeaderLine.Count];
                for (int iIndex = 0; iIndex < xReceiptHeaderDataModel.xListHeaderLine.Count; iIndex++)
                {
                    prm_out_straHeaderLines[iIndex] = xReceiptHeaderDataModel.xListHeaderLine[iIndex];
                }
            }
            return bReturnValue;
        }

        public bool bReadRecieptHeader(out ReceiptHeaderDataModel prm_xRecieptHeaderDataModel)
        {
            prm_xRecieptHeaderDataModel = null;

            try
            {
                prm_xRecieptHeaderDataModel = Dao.xGetInstance().xGetReceiptHeader();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool bGetAllCurrency(out List<CurrencyDataModel> prm_xListCurrencyDataModel)
        {
            return bReadAllCurrency(out prm_xListCurrencyDataModel);
        }

        public bool bReadAllCurrency(out List<CurrencyDataModel> prm_xListCurrencyDataModel)
        {
            prm_xListCurrencyDataModel = null;

            try
            {
                m_xPosManagerData.xListCurrencyDataModel = prm_xListCurrencyDataModel = Dao.xGetInstance().xListGetCurrency();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bReadAllCurrency()
        {
            try
            {
                m_xPosManagerData.xListCurrencyDataModel = Dao.xGetInstance().xListGetCurrency();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bGetAllVats(out List<VatDataModel> prm_xListVatDataModel)
        {
            return bReadAllVats(out prm_xListVatDataModel);

        }

        public bool bReadAllVats(out List<VatDataModel> prm_xListVatDataModel)
        {
            prm_xListVatDataModel = null;

            try
            {
                m_xPosManagerData.xListVatDataModel = prm_xListVatDataModel = Dao.xGetInstance().xListGetVats();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bReadAllVats()
        {
            try
            {
                m_xPosManagerData.xListVatDataModel = Dao.xGetInstance().xListGetVats();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ServiceDataModel.VatModel> GetVatListForCombo()
        {
            try
            {
                return Dao.xGetInstance().GetVatListForCombo();
            }
            catch
            {
                return new List<ServiceDataModel.VatModel>();}
        }

        public object GetStockUnitListForCombo()
        {
            try
            {
                var list = Dao.xGetInstance().GetStockUnitListForCombo();
                var obj = list.Select(s => new {StockUnitNo = s.No, Name = s.Name}).ToList();
                return obj;
            }
            catch
            {
                return new object();
            }
        }

        public bool bGetDisplayBrightness(out int prm_out_iDisplayBrightness)
        {
            prm_out_iDisplayBrightness = 0;

            try
            {
                //prm_out_iDisplayBrightness = Dao.xGetInstance().iGetDisplayBrightness();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bGetPrinterIntensity(out int prm_out_iPrinterIntensity)
        {
            prm_out_iPrinterIntensity = 0;

            try
            {
                //prm_out_iPrinterIntensity = Dao.xGetInstance().iGetPrinterIntensity();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bGetDiscountRate(ref int prm_iDiscountPercentage)
        {
            prm_iDiscountPercentage = 1000;

            try
            {
                //prm_iDiscountPercentage = Dao.xGetInstance().iGetDiscountRate();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bGetSurchargeRate(ref int prm_iSurchargePercentage)
        {
            prm_iSurchargePercentage = 1000;

            try
            {
                //prm_iSurchargePercentage = Dao.xGetInstance().iGetSurchargeRate();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bGetIdleMessage(out string prm_out_strIdleMessage)
        {
            prm_out_strIdleMessage = string.Empty;

            try
            {
                prm_out_strIdleMessage = "TEST";
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bGetSupervisorPassword(out string prm_out_strSupervisorPassword)
        {
            prm_out_strSupervisorPassword = string.Empty;

            try
            {
                prm_out_strSupervisorPassword = "1234";
                return true;
            }
            catch
            {
                return false;
            }
        }

        public PluDataModel xGetPlu(int prm_iPluCode)
        {
            PluDataModel xPluDataModel = null;

            try
            {
                xPluDataModel = Dao.xGetInstance().xGetPlu(prm_iPluCode.ToString());
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xPluDataModel;
        }

        public PluDataModel xGetPluById(long pluId)
        {
            PluDataModel xPluDataModel = null;

            try
            {
                xPluDataModel = Dao.xGetInstance().xGetPluById(pluId);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xPluDataModel;
        }

        public bool bReadListPlu(out List<PluDataModel> prm_xListPluDataModel)
        {
            prm_xListPluDataModel = null;

            try
            {
                prm_xListPluDataModel = Dao.xGetInstance().xListGetPlu();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bGetListPaymentTypes(out List<PaymentTypeDataModel> prm_xListPaymentTypeDataModel)
        {
            prm_xListPaymentTypeDataModel = null;
            try
            {
                return bReadListPaymentTypes(out prm_xListPaymentTypeDataModel);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListPaymentTypes(out List<PaymentTypeDataModel> prm_xListPaymentTypeDataModel)
        {
            prm_xListPaymentTypeDataModel = null;

            try
            {
                m_xPosManagerData.xListPaymentTypeDataModel = prm_xListPaymentTypeDataModel = Dao.xGetInstance().xListGetPaymentTypes();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListPaymentTypes()
        {
            try
            {
                m_xPosManagerData.xListPaymentTypeDataModel = Dao.xGetInstance().xListGetPaymentTypes();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bGetListTransactionTypes(out List<TransactionTypeDataModel> prm_xListTransactionTypeDataModel)
        {
            prm_xListTransactionTypeDataModel = null;
            try
            {
                return bReadListTransactionTypes(out prm_xListTransactionTypeDataModel);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListTransactionTypes(out List<TransactionTypeDataModel> prm_xListTransactionTypeDataModel)
        {
            prm_xListTransactionTypeDataModel = null;

            try
            {
                m_xPosManagerData.xListTransactionTypeDataModel = prm_xListTransactionTypeDataModel = Dao.xGetInstance().xListGetTransactionTypes();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListTransactionTypes()
        {
            try
            {
                m_xPosManagerData.xListTransactionTypeDataModel = Dao.xGetInstance().xListGetTransactionTypes();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bGetListTransactionDocumentTypes(out List<TransactionDocumentTypeDataModel> prm_xListTransactionDocumentTypeDataModel)
        {
            prm_xListTransactionDocumentTypeDataModel = null;
            try
            {
                return bReadListTransactionDocumentTypes(out prm_xListTransactionDocumentTypeDataModel);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListTransactionDocumentTypes(out List<TransactionDocumentTypeDataModel> prm_xListTransactionDocumentTypeDataModel)
        {
            prm_xListTransactionDocumentTypeDataModel = null;

            try
            {
                m_xPosManagerData.xListTransactionDocumentTypeDataModel = prm_xListTransactionDocumentTypeDataModel = Dao.xGetInstance().xListGetTransactionDocumentTypes();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListTransactionDocumentTypes()
        {
            try
            {
                m_xPosManagerData.xListTransactionDocumentTypeDataModel = Dao.xGetInstance().xListGetTransactionDocumentTypes();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bGetListCountries(out List<CountryDataModel> prm_xListCountryDataModel)
        {
            prm_xListCountryDataModel = null;
            try
            {
                return bReadListCountries(out prm_xListCountryDataModel);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListCountries(out List<CountryDataModel> prm_xListCountryDataModel)
        {
            prm_xListCountryDataModel = null;

            try
            {
                m_xPosManagerData.xListCountryDataModel = prm_xListCountryDataModel = Dao.xGetInstance().xListGetCountry();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListCountries()
        {
            try
            {
                m_xPosManagerData.xListCountryDataModel = Dao.xGetInstance().xListGetCountry();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bGetListCities(out List<CityDataModel> prm_xListCityDataModel)
        {
            prm_xListCityDataModel = null;

            try
            {
                return bReadListCities(out prm_xListCityDataModel);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListCities(out List<CityDataModel> prm_xListCityDataModel)
        {
            prm_xListCityDataModel = null;

            try
            {
                m_xPosManagerData.xListCityDataModel = prm_xListCityDataModel = Dao.xGetInstance().xListGetCity();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListCities()
        {
            try
            {
                m_xPosManagerData.xListCityDataModel = Dao.xGetInstance().xListGetCity();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bGetListDistricts(out List<DistrictDataModel> prm_xListDistrictDataModel)
        {
            prm_xListDistrictDataModel = null;

            try
            {
                return bReadListDistricts(out prm_xListDistrictDataModel);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListDistricts(out List<DistrictDataModel> prm_xListDistrictDataModel)
        {
            prm_xListDistrictDataModel = null;

            try
            {
                m_xPosManagerData.xListDistrictDataModel = prm_xListDistrictDataModel = Dao.xGetInstance().xListGetDistricts();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListDistricts()
        {
            try
            {
                m_xPosManagerData.xListDistrictDataModel = Dao.xGetInstance().xListGetDistricts();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bGetListCashiers(out List<CashierDataModel> prm_xListCashierDataModel)
        {
            prm_xListCashierDataModel = null;

            try
            {
                return bReadListCashiers(out prm_xListCashierDataModel);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListCashiers(out List<CashierDataModel> prm_xListCashierDataModel)
        {
            prm_xListCashierDataModel = null;

            try
            {
                m_xPosManagerData.xListCashierDataModel = prm_xListCashierDataModel = Dao.xGetInstance().xListGetCashiers();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadListCashiers()
        {
            try
            {
                m_xPosManagerData.xListCashierDataModel = Dao.xGetInstance().xListGetCashiers();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bGetDefaultCashier(out CashierDataModel prm_xCashierDataModel)
        {
            prm_xCashierDataModel = null;

            try
            {
                foreach (CashierDataModel xCashierDataModel in m_xPosManagerData.xListCashierDataModel)
                {
                    if (xCashierDataModel.iNo == JsonParameter.xGetInstance().prop_iDefaultCashierNo)
                    {
                        m_xPosManagerData.xCashierDataModel = prm_xCashierDataModel = xCashierDataModel;

                        return true;
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return false;
        }

        public bool bReadDefaultCashier()
        {
            try
            {
                foreach (CashierDataModel xCashierDataModel in m_xPosManagerData.xListCashierDataModel)
                {
                    if (xCashierDataModel.iNo == JsonParameter.xGetInstance().prop_iDefaultCashierNo)
                    {
                        m_xPosManagerData.xCashierDataModel = xCashierDataModel;

                        return true;
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return false;
        }

        public bool bGetLastOpenTransaction(out TransactionDataModel prm_xTransactionDataModel)
        {
            prm_xTransactionDataModel = null;

            try
            {
                return bReadLastOpenTransaction(out prm_xTransactionDataModel);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadLastOpenTransaction(out TransactionDataModel prm_xTransactionDataModel)
        {
            prm_xTransactionDataModel = null;

            try
            {
                m_xPosManagerData.xTransactionDataModel = prm_xTransactionDataModel = Dao.xGetInstance().xGetLastOpenTransaction();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadLastOpenTransaction()
        {
            try
            {
                m_xPosManagerData.xTransactionDataModel = Dao.xGetInstance().xGetLastOpenTransaction();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bReadTransactionSequences()
        {
            try
            {
                // If there is no previous transaction, create an empty transaction.
                if (m_xPosManagerData.xTransactionDataModel==null)
                    m_xPosManagerData.xTransactionDataModel = new TransactionDataModel();
                if (m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel == null)
                    m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel = new TransactionHeadDataModel();

                m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iReceiptNumber = Dao.xGetInstance().iGetLastRecieptNumber();
                m_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iZNumber = Dao.xGetInstance().iGetLastZNumber();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bGetForm(out EnumFormType prm_out_enumFormType)
        {
            prm_out_enumFormType = EnumFormType.SALE;
            return true;
        }

        public List<StockDataModel> xGetPluStock()
        {
            try
            {
                return Dao.xGetInstance().xGetPluStock();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }

        }


        public List<StockDataModel> xGetSearchData(string prm_xBarcode)
        {
            try
            {
                return Dao.xGetInstance().xGetSearchPluStock(prm_xBarcode);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }
        public bool xSaveStock(List<StockDataModel> prm_xStock)
        {
            try
            {
                Dao.xGetInstance().SavePluStock(prm_xStock);
                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public ServiceDataModel.TransactionHeadModel GetTransactionByHeadId(long transactionHeadId)
        {
            try
            {
                var transaction = Dao.xGetInstance().GetTransactionByHeadId(transactionHeadId);
                transaction.FkPosId = CommonProperty.prop_lPosId;

                foreach (var transactionDetail in transaction.TransactionDetailList)
                {
                    transactionDetail.FkServerPluId = Dao.xGetInstance().xGetPluById(transactionDetail.FkPluId).FkServerId;
                }
                return transaction;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<ServiceDataModel.TransactionHeadModel> GetUnsendTransactionList()
        {
            try
            {
                var transactionList = Dao.xGetInstance().GetUnsendTransactionList();
                foreach (var transaction in transactionList)
                {
                    transaction.FkPosId = CommonProperty.prop_lPosId;

                    foreach (var transactionDetail in transaction.TransactionDetailList)
                    {
                        transactionDetail.FkServerPluId = Dao.xGetInstance().xGetPluById(transactionDetail.FkPluId).FkServerId;
                    }
                }
                return transactionList;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }
    }
}
