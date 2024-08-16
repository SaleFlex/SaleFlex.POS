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
            decReceiptTotalSurcharge = 0;
            decReceiptTotalDiscount = 0;

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

        public long decReceiptTotalPayment { get; set; }
        public long decTotalPrice { get; set; }

        public long decReceiptTotalPrice
        {
            get
            {
                return xTransactionDataModel.xTransactionHeadDataModel.decReceiptTotalPrice;
            }
            set
            {
                xTransactionDataModel.xTransactionHeadDataModel.decReceiptTotalPrice = value;
            }
        }

        public long decReceiptTotalVat
        {
            get
            {
                return xTransactionDataModel.xTransactionHeadDataModel.decReceiptTotalVat;
            }
            set
            {
                xTransactionDataModel.xTransactionHeadDataModel.decReceiptTotalVat = value;
            }
        }

        public long decReceiptTotalDiscount
        {
            get
            {
                return xTransactionDataModel.xTransactionHeadDataModel.decTotalDiscountAmount;
            }
            set
            {
                xTransactionDataModel.xTransactionHeadDataModel.decTotalDiscountAmount = value;
            }
        }

        public long decReceiptTotalSurcharge
        {
            get
            {
                return xTransactionDataModel.xTransactionHeadDataModel.decSurchargeAmount;
            }
            set
            {
                xTransactionDataModel.xTransactionHeadDataModel.decSurchargeAmount = value;
            }
        }

        public long decReceiptTotalQuantity
        {
            get
            {
                long decTotalQuantity = 0;

                foreach (TransactionDetailDataModel xTransactionDetailDataModel in xTransactionDataModel.xListTransactionDetailDataModel)
                {
                    if (xTransactionDetailDataModel.bCanceled == false)
                        decTotalQuantity += xTransactionDetailDataModel.decQuantity;
                }

                return decTotalQuantity;
            }
           
        }
    }
}
