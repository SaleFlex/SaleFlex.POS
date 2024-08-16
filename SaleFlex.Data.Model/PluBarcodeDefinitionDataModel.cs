using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class PluBarcodeDefinitionDataModel
    {
        public int iId { get; set; }
        public string strName { get; set; }
        public int iLengthOfBarcode { get; set; }
        public string strStartingDigits { get; set; }
        public int iLengthOfProductCode { get; set; }
        public int iLengthOfQuantity { get; set; }
        public int iLengthOfPrice { get; set; }
        public string strDescription { get; set; }
    }
}
