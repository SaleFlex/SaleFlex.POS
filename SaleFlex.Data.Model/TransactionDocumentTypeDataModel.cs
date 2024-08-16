using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class TransactionDocumentTypeDataModel
    {
        public int iId { get; set; }
        public int iNo { get; set; }
        public string strName { get; set; }
        public string strDisplayName { get; set; }
        public string strDescription { get; set; }
    }
}
