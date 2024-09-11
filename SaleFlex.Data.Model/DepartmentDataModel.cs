using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class DepartmentDataModel
    {
        public DepartmentDataModel()
        {
            xVat = new VatDataModel();
        }

        public int iId { get; set; }
        public int iNo { get; set; }
        public string strName { get; set; }
        public long lDefaultPrice { get; set; }
        public long lDefaultQuantity { get; set; }
        public long lMaxPrice { get; set; }
        public VatDataModel xVat { get; set; }
        public string strKeyboardValue { get; set; }
    }
}
