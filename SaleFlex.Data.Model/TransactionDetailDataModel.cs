using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class TransactionDetailDataModel
    {
        public TransactionDetailDataModel()
        {
            bCanceled = false;
        }

        public int iId { get; set; }
        public int iFkTransactionHeadId { get; set; }
        public int iFkPluId { get; set; }
        public PluDataModel xPluDataModel { get; set; }
        public int iFkDepartmentId { get; set; }
        public DepartmentDataModel xDepartmentDataModel { get; set; }
        public long decPrice { get; set; }
        public long decQuantity { get; set; }
        public SubTotalDataModel xSubTotalDataModel { get; set; }
        public List<DiscountSurchargeDataModel> xDiscountSurchargeDataModel { get; set; }
        public long decTotalPrice { get; set; }
        public long decTotalPriceWithoutVat { get; set; }
        public long decTotalVat { get; set; }
        public bool bCanceled { get; set; }
        public DateTime xTransactionDetailDateTime { get; set; }
    }
}
