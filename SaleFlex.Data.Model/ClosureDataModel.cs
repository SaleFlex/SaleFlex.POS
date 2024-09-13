using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    // This class represents a data model for storing information related to a sales closure in the SaleFlex system.
    public class ClosureDataModel
    {
        // Constructor to initialize the ClosureDataModel, setting up the list for payment type summaries.
        public ClosureDataModel()
        {
            xListClosurePaymentTypeSummaryDataModel = new List<ClosurePaymentTypeSummaryDataModel>();
        }

        // Unique identifier for the closure record.
        public long lId { get; set; }

        // Z-number (group number) associated with the closure (likely related to cash register operations).
        public int iZNumber { get; set; }

        // The last receipt number processed during this closure.
        public int iReceiptNumber { get; set; }

        // The date and time when the closure was performed.
        public DateTime xClosureDateTime { get; set; }

        // Foreign key referencing the POS (Point of Sale) system related to this closure.
        public long lFkPosId { get; set; }

        // Foreign key referencing the cashier responsible for the closure.
        public long lFkCashierId { get; set; }

        // Total number of transactions processed during this closure.
        public int iTotalTransactionCount { get; set; }

        // Total transaction amount for all transactions processed during the closure.
        public long lTotalTransactionAmount { get; set; }

        // Total VAT (Value Added Tax) amount for all transactions.
        public long lTotalVatAmount { get; set; }

        // Total number of discounts applied during the closure.
        public int iTotalDiscountCount { get; set; }

        // Total discount amount for the closure period.
        public long lTotalDiscountAmount { get; set; }

        // Total number of surcharges applied during the closure.
        public int iTotalSurchargeCount { get; set; }

        // Total surcharge amount for the closure period.
        public long lTotalSurchargeAmount { get; set; }

        // Total number of changes (such as cash returns) processed during the closure.
        public int iTotalChangeCount { get; set; }

        // Total change amount (e.g., cash returned to customers).
        public long lTotalChangeAmount { get; set; }

        // Total rounding amount applied to transactions (for rounding off final totals).
        public long lTotalRoundAmount { get; set; }

        // Cumulative total transaction amount up to this closure.
        public long lCumulativeTotalAmount { get; set; }

        // Cumulative total VAT amount up to this closure.
        public long lCumulativeVatAmount { get; set; }

        // A list that stores the summary of transactions grouped by payment types (e.g., cash, credit).
        public List<ClosurePaymentTypeSummaryDataModel> xListClosurePaymentTypeSummaryDataModel { get; set; }

        // Indicates whether the closure has been canceled (true if canceled, false otherwise).
        public bool bCanceled { get; set; }

        // Indicates whether the closure has been deleted (true if deleted, false otherwise).
        public bool bDeleted { get; set; }
    }

    // This class represents a summary of transactions by payment type for a specific closure.
    public class ClosurePaymentTypeSummaryDataModel
    {
        // Constructor to initialize the ClosurePaymentTypeSummaryDataModel class.
        public ClosurePaymentTypeSummaryDataModel()
        {
        }

        // Foreign key referencing the closure this summary belongs to.
        public long lFkClosureId { get; set; }

        // Payment type identifier (e.g., cash, card).
        public long FkPaymentType { get; set; }

        // Total number of transactions processed with this payment type.
        public long iTotalCount { get; set; }

        // Total amount processed with this payment type.
        public long lTotalAmount { get; set; }
    }
}
