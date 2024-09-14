using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;

namespace SaleFlex.Data
{
    public class PosManagerData
    {
        public PosManagerData()
        {
            xTransactionDataModel = new TransactionDataModel();
            xListVatDataModel = new List<VatDataModel>();
            xListDepartmentDataModel = new List<DepartmentDataModel>();
            xListCurrencyDataModel = new List<CurrencyDataModel>();
            xListPaymentTypeDataModel = new List<PaymentTypeDataModel>();
            xListTransactionTypeDataModel = new List<TransactionTypeDataModel>();
            xListTransactionDocumentTypeDataModel = new List<TransactionDocumentTypeDataModel>();
            xListCountryDataModel = new List<CountryDataModel>();
            xListCityDataModel = new List<CityDataModel>();
            xListDistrictDataModel = new List<DistrictDataModel>();
            xCashierDataModel = null;
            lReceiptTotalSurcharge = 0;
            lReceiptTotalDiscount = 0;

            xTransactionDataModel.bTransactionStarted = false;
        }

        public PosDataModel xPosDataModel { get; set; }
        public CashierDataModel xCashierDataModel { get; set; }
        public TransactionDataModel xTransactionDataModel { get; set; }
        public List<VatDataModel> xListVatDataModel { get; set; }
        public List<DepartmentDataModel> xListDepartmentDataModel { get; set; }
        public List<PaymentTypeDataModel> xListPaymentTypeDataModel { get; set; }
        public List<TransactionTypeDataModel> xListTransactionTypeDataModel { get; set; }
        public List<TransactionDocumentTypeDataModel> xListTransactionDocumentTypeDataModel { get; set; }
        public List<CountryDataModel> xListCountryDataModel { get; set; }
        public List<CityDataModel> xListCityDataModel { get; set; }
        public List<DistrictDataModel> xListDistrictDataModel { get; set; }
        public List<CurrencyDataModel> xListCurrencyDataModel { get; set; }
        public List<CashierDataModel> xListCashierDataModel { get; set; }

        public long lReceiptTotalPayment { get; set; }
        public long lTotalPrice { get; set; }

        public long lReceiptTotalPrice
        {
            get
            {
                return xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice;
            }
            set
            {
                xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice = value;
            }
        }

        public long lReceiptTotalVat
        {
            get
            {
                return xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat;
            }
            set
            {
                xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat = value;
            }
        }

        public long lReceiptTotalDiscount
        {
            get
            {
                return xTransactionDataModel.xTransactionHeadDataModel.lTotalDiscountAmount;
            }
            set
            {
                xTransactionDataModel.xTransactionHeadDataModel.lTotalDiscountAmount = value;
            }
        }

        public long lReceiptTotalSurcharge
        {
            get
            {
                return xTransactionDataModel.xTransactionHeadDataModel.lSurchargeAmount;
            }
            set
            {
                xTransactionDataModel.xTransactionHeadDataModel.lSurchargeAmount = value;
            }
        }

        public long lReceiptTotalQuantity
        {
            get
            {
                long lTotalQuantity = 0;

                foreach (TransactionDetailDataModel xTransactionDetailDataModel in xTransactionDataModel.xListTransactionDetailDataModel)
                {
                    if (xTransactionDetailDataModel.bCanceled == false)
                        lTotalQuantity += xTransactionDetailDataModel.lQuantity;
                }

                return lTotalQuantity;
            }
           
        }
    }
}
