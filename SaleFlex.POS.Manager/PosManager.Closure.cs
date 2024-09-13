using SaleFlex.Data.AccessLayer;
using SaleFlex.Data.Models;
using SaleFlex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFlex.POS.Manager
{
    public partial class PosManager
    {
        public bool bClosure(EnumPaymentType prm_enumType, long prm_lPaymentAmount)
        {
            return true;
        }
    }
}
