using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class KeyboardTypeFirstDataModel
    {
        public int iId { get; set; }
        public int iKeyboardType { get; set; }
        public string strDefaultButtonName { get; set; }
        public string strDefaultButtonText { get; set; }
        public string strDefinedButtonText { get; set; }
        public string strCategory { get; set; }
        public string strKeyboardValue { get; set; }
        public bool bDeleted { get; set; }
    }
}
