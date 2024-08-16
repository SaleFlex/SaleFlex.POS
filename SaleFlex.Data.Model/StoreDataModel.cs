using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class StoreDataModel
    {
        public int iId { get; set; }
        public string strStoreManagerUserName { get; set; }
        public string strStoreManagerPassword { get; set; }
        public string strStoreName { get; set; }
        public int iStoreNumber { get; set; }
        public string strStoreAddress { get; set; }
        public string strTelephone { get; set; }
        public string strResponsibleNameSurname { get; set; }
        public string ResponsibleTelephone { get; set; }
        public string strStoreIP1 { get; set; }
        public string strStoreIP2 { get; set; }
        public string strStorePort1 { get; set; }
        public string strStorePort2 { get; set; }
    }
}
