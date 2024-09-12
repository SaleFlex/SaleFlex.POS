using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class TransactionHeadDataModel
    {
        // This class represents the transaction header information in the database
        public TransactionHeadDataModel()
        {
            // Constructor that initializes the CashierDataModel
            xCashierDataModel = new CashierDataModel();
        }

        // Unique ID for the transaction
        public int iId { get; set; }

        // Foreign key referencing the cashier ID associated with the transaction
        public int iFkCashierId { get; set; }

        // Cashier data model object, holding information about the cashier
        public CashierDataModel xCashierDataModel { get; set; }

        // Date and time of the transaction
        public DateTime xTransactionDateTime { get; set; }

        // Foreign key referencing the transaction document type
        public int iFkTransactionDocumentTypeId { get; set; }

        // Transaction document type number (could be invoice, receipt, etc.)
        public int iTransactionDocumentTypeNo { get; set; }

        // Data model for the transaction document type
        public TransactionDocumentTypeDataModel xTransactionDocumentTypeDataModel { get; set; }

        // Foreign key referencing the customer ID associated with the transaction
        public int iFkCustomerId { get; set; }

        // Customer data model object, holding information about the customer
        public CustomerDataModel xCustomerDataModel { get; set; }

        // Unique transaction number
        public string strTransactionNo { get; set; }

        // Receipt number associated with the transaction
        public int iReceiptNumber { get; set; }

        // Z-number, which may be related to the daily or period-based sales report
        public int iZNumber { get; set; }

        // Total price on the receipt, including all items and services
        public long lReceiptTotalPrice { get; set; }

        // Total VAT (Value Added Tax) amount applied to the transaction
        public long lReceiptTotalVat { get; set; }

        // Total discount applied after calculating the total price (overall discounts)
        public long lTotalDiscountAmount { get; set; }

        // Total discount applied to individual line items in the transaction
        public long lTransactionsDiscountAmount { get; set; }

        // Total discount applied for the customer, if any
        public long lCustomerTotalDiscountAmount { get; set; }

        // Total discount given due to promotions
        public long lPromotionTotalDiscountAmount { get; set; }

        // Surcharge amount applied to the transaction (any additional charges)
        public long lSurchargeAmount { get; set; }

        // Total amount paid by the customer
        public long lPaymentAmount { get; set; }

        // Amount of change returned to the customer
        public long lChangeAmount { get; set; }

        // Rounded amount, typically to adjust to a preferred rounding policy
        public long lRoundAmount { get; set; }

        // Indicates if the transaction has been voided/canceled
        public bool bIsVoided { get; set; }
    }
}
