using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class PaymentTypeDataModel
    {
        public int iId { get; set; }
        public int iTypeNo { get; set; }
        public string strTypeName { get; set; }
        public string strTypeDescription { get; set; }
    }
}
