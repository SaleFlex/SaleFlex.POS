using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class CashierDataModel
    {
        public int iId { get; set; }
        public int iNo { get; set; }
        public string strName { get; set; }
        public string strLastName { get; set; }
        public string strPassword { get; set; }
        public string strIdentityNumber { get; set; }
        public string strDescription { get; set; }
        public bool bIsAdministrator { get; set; }
    }
}
