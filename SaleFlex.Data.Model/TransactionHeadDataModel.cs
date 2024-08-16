using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class TransactionHeadDataModel
    {
        public TransactionHeadDataModel()
        {
            xCashierDataModel = new CashierDataModel();
        }

        public int iId { get; set; }
        public int iFkCashierId { get; set; }
        public CashierDataModel xCashierDataModel { get; set; }
        public DateTime xTransactionDateTime { get; set; }
        public int iFkTransactionDocumentTypeId { get; set; }
        public int iTransactionDocumentTypeNo { get; set; }
        public TransactionDocumentTypeDataModel xTransactionDocumentTypeDataModel { get; set; }
        public int iFkCustomerId { get; set; }
        public CustomerDataModel xCustomerDataModel { get; set; }
        public string strTransactionNo { get; set; }
        public int iReceiptNumber { get; set; }
        public int iZNumber { get; set; }
        public long decReceiptTotalPrice { get; set; }
        public long decReceiptTotalVat { get; set; }
        public long decTotalDiscountAmount { get; set; }              // Belgeye uygulanan toplam indirim (toplamdan sonraki indirimler)
        public long decTransactionsDiscountAmount { get; set; }       // Satırlara yapılmış toplam indirim
        public long decCustomerTotalDiscountAmount { get; set; }      // Müşteri için yapılmış indirimler
        public long decPromotionTotalDiscountAmount { get; set; }     // Promosyon nedeni ile yapılmış indirimler
        public long decSurchargeAmount { get; set; }                  // Artırım Tutarı
        public long decPaymentAmount { get; set; }
        public long decChangeAmount { get; set; }                     // Kalan
        public long decRoundAmount { get; set; }                      // Yuvarlama
        public bool bIsVoided { get; set; }                             // İptalmi?
    }
}
