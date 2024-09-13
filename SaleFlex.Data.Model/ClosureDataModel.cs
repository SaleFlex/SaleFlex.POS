using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class ClosureDataModel
    {
        public ClosureDataModel()
        {
            xListClosurePaymentTypeSummaryDataModel = new List<ClosurePaymentTypeSummaryDataModel>();
        }

        public long lId { get; set; }
        public int iZNumber { get; set; }
        public int iReceiptNumber { get; set; }
        public DateTime xClosureDateTime { get; set; }
        public long lFkPosId { get; set; }
        public long lFkCashierId { get; set; }
        public int iTotalTransactionCount { get; set; }
        public long lTotalTransactionAmount { get; set; }
        public long lTotalVatAmount { get; set; }
        public int iTotalDiscountCount { get; set; }
        public long lTotalDiscountAmount { get; set; }
        public int iTotalSurchargeCount { get; set; }
        public long lTotalSurchargeAmount { get; set; }
        public int iTotalChangeCount { get; set; }
        public long lTotalChangeAmount { get; set; }
        public long lTotalRoundAmount { get; set; }
        public long lCumulativeTotalAmount { get; set; }
        public long lCumulativeVatAmount { get; set; }
        public List<ClosurePaymentTypeSummaryDataModel> xListClosurePaymentTypeSummaryDataModel { get; set; }
        public bool bCanceled { get; set; }
        public bool bDeleted { get; set; }
    }

    public class ClosurePaymentTypeSummaryDataModel
    {
        public ClosurePaymentTypeSummaryDataModel()
        {
        }

        public long lFkClosureId { get; set; }
        public long FkPaymentType { get; set; }
        public long iTotalCount { get; set; }
        public long lTotalAmount { get; set; }
    }
}
