using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public partial class EndOfDayDataModel
    {
        public EndOfDayDataModel()
        {
            xListPayment = new List<PaymentDataModel>();
        }

        public long lId { get; set; }
        public DateTime dtEndOfDayDateTime { get; set; }
        public long lfkCashRegisterId { get; set; }
        public long lfkCashierId { get; set; }
        public int iReceiptNumber { get; set; }
        public int iZNumber { get; set; }
        public DateTime dtDailyStartDate { get; set; }
        public DateTime dtZStartDateTime { get; set; }
        public List<PaymentDataModel> xListPayment { get; set; }
        public decimal decTotal { get; set; }
        public decimal decVat { get; set; }
        public decimal decCumulativeTotal { get; set; }
        public decimal decCumulativeVat { get; set; }
        public bool bCanceled { get; set; }
        public bool bDeleted { get; set; }
    }
}
