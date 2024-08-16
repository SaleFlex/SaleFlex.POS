using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class LimitDataModel
    {
        public int iId { get; set; }
        public int iMaxOfflineWorkHourLimit { get; set; }
        public decimal decMaxTransactionLimit { get; set; }
    }
}
