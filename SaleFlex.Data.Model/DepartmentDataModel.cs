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
        public long decDefaultPrice { get; set; }
        public long decDefaultQuantity { get; set; }
        public long decMaxPrice { get; set; }
        public VatDataModel xVat { get; set; }
        public string strKeyboardValue { get; set; }
    }
}
