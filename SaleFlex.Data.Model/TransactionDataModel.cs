using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class TransactionDataModel
    {
        public TransactionDataModel()
        {
            xTransactionHeadDataModel = new TransactionHeadDataModel();
            xListTransactionDetailDataModel = new List<TransactionDetailDataModel>();
            xListDiscountSurchargeDataModel = new List<DiscountSurchargeDataModel>();
            xListPaymentDataModel = new List<PaymentDataModel>();

            xTransactionHeadDataModel.iReceiptNumber = 0;
            xTransactionHeadDataModel.iZNumber = 0;
            bTransactionStarted = false;

            xCustomerDataModel = null;
        }

        public int iId { get; set; }
        public bool bTransactionStarted { get; set; }
        public TransactionHeadDataModel xTransactionHeadDataModel { get; set; }
        public List<TransactionDetailDataModel> xListTransactionDetailDataModel { get; set; }
        public List<DiscountSurchargeDataModel> xListDiscountSurchargeDataModel { get; set; }
        public List<PaymentDataModel> xListPaymentDataModel { get; set; }
        public CustomerDataModel xCustomerDataModel { get; set; }
        public CashierDataModel xCashierDataModel { get; set; }
    }
}
