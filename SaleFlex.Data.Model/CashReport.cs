using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class CashReportDataModel
    {
        public string Day { get; set; }
        public string ReceiptTotal { get; set; }
        public string CashWithoutVat { get; set; }
        public string ReturnProductCash { get; set; }
        public string PurchasePrice { get; set; }
        public string Profit { get; set; }
        public string CashPayment { get; set; }
        public string CardPayment { get; set; }
        public string OtherPayment { get; set; }
    }
}
