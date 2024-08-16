using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class PluBarcodeDataModel
    {
        public int iId { get; set; }
        public int iFkPluId { get; set; }
        public string strBarcode { get; set; }
        public string strOldBarcode { get; set; }
        public int iFkPluBarcodeDefinitionId { get; set; }
        public PluBarcodeDefinitionDataModel xPluBarcodeDefinitionDataModel { get; set; }
        public long decPurchasePrice { get; set; }
        public long decSalePrice { get; set; }
    }
}
