using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class PluSubGroupDataModel
    {
        public PluSubGroupDataModel()
        {
            xPluMainGroupDataModel = new PluMainGroupDataModel();
        }

        public int iId { get; set; }
        public int iFkPluMainGroupId { get; set; }
        public int iNo { get; set; }
        public string strName { get; set; }
        public string strDescription { get; set; }
        public int iDiscountPercent { get; set; }
        public PluMainGroupDataModel xPluMainGroupDataModel { get; set; }
    }
}
