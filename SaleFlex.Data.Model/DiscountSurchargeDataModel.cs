using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class DiscountSurchargeDataModel
    {
        public DiscountSurchargeDataModel()
        {
        }

        public bool bIsDiscount { get; set; }
        public long decDiscountAmount { get; set; }
        public int iDiscountPercentage { get; set; }
        public long decSurchargeAmount { get; set; }
        public int iSurchargePercentage { get; set; }
        public long decDiscountSurchargeResult { get; set; }
    }
}
