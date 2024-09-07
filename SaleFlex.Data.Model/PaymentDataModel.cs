using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class PaymentDataModel
    {
        public PaymentDataModel()
        {
            xPaymentTypeDataModel = new PaymentTypeDataModel();
        }

        public long lId { get; set; }
        public TransactionHeadDataModel xTransactionHeadDataModel { get; set; }
        public PaymentTypeDataModel xPaymentTypeDataModel { get; set; }
        public long lAmount;
    }
}
