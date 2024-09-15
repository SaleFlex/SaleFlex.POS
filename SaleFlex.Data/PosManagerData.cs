using System;
using System.Collections.Generic;
using System.Linq;
using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;

namespace SaleFlex.Data
{
    public class PosManagerData
    {
        public PosManagerData()
        {
            // Initialize only essential properties; others will be initialized lazily
            xTransactionDataModel = new TransactionDataModel { bTransactionStarted = false };
        }

        // Properties

        public PosDataModel xPosDataModel { get; set; }

        private CashierDataModel _xCashierDataModel;
        public CashierDataModel xCashierDataModel
        {
            get
            {
                if (_xCashierDataModel == null)
                {
                    _xCashierDataModel = new CashierDataModel(); // Lazily initialize if null
                }
                return _xCashierDataModel;
            }
            set => _xCashierDataModel = value;
        }

        public TransactionDataModel xTransactionDataModel { get; set; }

        // Lazy initialization to improve performance by creating lists only when needed
        private List<VatDataModel> _xListVatDataModel;
        public List<VatDataModel> xListVatDataModel
        {
            get
            {
                if (_xListVatDataModel == null)
                {
                    _xListVatDataModel = new List<VatDataModel>(); // Lazily initialize list
                }
                return _xListVatDataModel;
            }
            set => _xListVatDataModel = value;
        }

        private List<DepartmentDataModel> _xListDepartmentDataModel;
        public List<DepartmentDataModel> xListDepartmentDataModel
        {
            get
            {
                if (_xListDepartmentDataModel == null)
                {
                    _xListDepartmentDataModel = new List<DepartmentDataModel>(); // Lazily initialize list
                }
                return _xListDepartmentDataModel;
            }
            set => _xListDepartmentDataModel = value;
        }

        private List<PaymentTypeDataModel> _xListPaymentTypeDataModel;
        public List<PaymentTypeDataModel> xListPaymentTypeDataModel
        {
            get
            {
                if (_xListPaymentTypeDataModel == null)
                {
                    _xListPaymentTypeDataModel = new List<PaymentTypeDataModel>(); // Lazily initialize list
                }
                return _xListPaymentTypeDataModel;
            }
            set => _xListPaymentTypeDataModel = value;
        }

        private List<TransactionTypeDataModel> _xListTransactionTypeDataModel;
        public List<TransactionTypeDataModel> xListTransactionTypeDataModel
        {
            get
            {
                if (_xListTransactionTypeDataModel == null)
                {
                    _xListTransactionTypeDataModel = new List<TransactionTypeDataModel>(); // Lazily initialize list
                }
                return _xListTransactionTypeDataModel;
            }
            set => _xListTransactionTypeDataModel = value;
        }

        private List<TransactionDocumentTypeDataModel> _xListTransactionDocumentTypeDataModel;
        public List<TransactionDocumentTypeDataModel> xListTransactionDocumentTypeDataModel
        {
            get
            {
                if (_xListTransactionDocumentTypeDataModel == null)
                {
                    _xListTransactionDocumentTypeDataModel = new List<TransactionDocumentTypeDataModel>(); // Lazily initialize list
                }
                return _xListTransactionDocumentTypeDataModel;
            }
            set => _xListTransactionDocumentTypeDataModel = value;
        }

        private List<CountryDataModel> _xListCountryDataModel;
        public List<CountryDataModel> xListCountryDataModel
        {
            get
            {
                if (_xListCountryDataModel == null)
                {
                    _xListCountryDataModel = new List<CountryDataModel>(); // Lazily initialize list
                }
                return _xListCountryDataModel;
            }
            set => _xListCountryDataModel = value;
        }

        private List<CityDataModel> _xListCityDataModel;
        public List<CityDataModel> xListCityDataModel
        {
            get
            {
                if (_xListCityDataModel == null)
                {
                    _xListCityDataModel = new List<CityDataModel>(); // Lazily initialize list
                }
                return _xListCityDataModel;
            }
            set => _xListCityDataModel = value;
        }

        private List<DistrictDataModel> _xListDistrictDataModel;
        public List<DistrictDataModel> xListDistrictDataModel
        {
            get
            {
                if (_xListDistrictDataModel == null)
                {
                    _xListDistrictDataModel = new List<DistrictDataModel>(); // Lazily initialize list
                }
                return _xListDistrictDataModel;
            }
            set => _xListDistrictDataModel = value;
        }

        private List<CurrencyDataModel> _xListCurrencyDataModel;
        public List<CurrencyDataModel> xListCurrencyDataModel
        {
            get
            {
                if (_xListCurrencyDataModel == null)
                {
                    _xListCurrencyDataModel = new List<CurrencyDataModel>(); // Lazily initialize list
                }
                return _xListCurrencyDataModel;
            }
            set => _xListCurrencyDataModel = value;
        }

        private List<CashierDataModel> _xListCashierDataModel;
        public List<CashierDataModel> xListCashierDataModel
        {
            get
            {
                if (_xListCashierDataModel == null)
                {
                    _xListCashierDataModel = new List<CashierDataModel>(); // Lazily initialize list
                }
                return _xListCashierDataModel;
            }
            set => _xListCashierDataModel = value;
        }

        // Represents the total payment made during the receipt process.
        public long lReceiptTotalPayment { get; set; }

        // Represents the total price of items in the transaction.
        public long lTotalPrice { get; set; }

        // Property: lReceiptTotalPrice
        // Gets or sets the total receipt price. Uses null checks to avoid null reference exceptions.
        public long lReceiptTotalPrice
        {
            get => xTransactionDataModel?.xTransactionHeadDataModel?.lReceiptTotalPrice ?? 0; // Return 0 if null.
            set
            {
                if (xTransactionDataModel?.xTransactionHeadDataModel != null)
                    xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalPrice = value; // Set value if object exists.
            }
        }

        // Property: lReceiptTotalVat
        // Gets or sets the total VAT amount in the receipt.
        public long lReceiptTotalVat
        {
            get => xTransactionDataModel?.xTransactionHeadDataModel?.lReceiptTotalVat ?? 0; // Return 0 if null.
            set
            {
                if (xTransactionDataModel?.xTransactionHeadDataModel != null)
                    xTransactionDataModel.xTransactionHeadDataModel.lReceiptTotalVat = value; // Set value if object exists.
            }
        }

        // Property: lReceiptTotalDiscount
        // Gets or sets the total discount applied to the receipt.
        public long lReceiptTotalDiscount
        {
            get => xTransactionDataModel?.xTransactionHeadDataModel?.lTotalDiscountAmount ?? 0; // Return 0 if null.
            set
            {
                if (xTransactionDataModel?.xTransactionHeadDataModel != null)
                    xTransactionDataModel.xTransactionHeadDataModel.lTotalDiscountAmount = value; // Set value if object exists.
            }
        }

        // Property: lReceiptTotalSurcharge
        // Gets or sets the total surcharge applied to the receipt.
        public long lReceiptTotalSurcharge
        {
            get => xTransactionDataModel?.xTransactionHeadDataModel?.lSurchargeAmount ?? 0; // Return 0 if null.
            set
            {
                if (xTransactionDataModel?.xTransactionHeadDataModel != null)
                    xTransactionDataModel.xTransactionHeadDataModel.lSurchargeAmount = value; // Set value if object exists.
            }
        }

        // Property: lReceiptTotalQuantity
        // Gets the total quantity of items in the transaction, excluding canceled items.
        public long lReceiptTotalQuantity
        {
            get
            {
                // Use LINQ to sum the total quantity of items that are not canceled.
                return xTransactionDataModel?.xListTransactionDetailDataModel?
                    .Where(detail => !detail.bCanceled)
                    .Sum(detail => detail.lQuantity) ?? 0; // Return 0 if no valid data.
            }
        }
    }
}
