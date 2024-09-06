using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class PluDataModel
    {
        public PluDataModel()
        {
            xPluSubGroupDataModel = new PluSubGroupDataModel();
            xVat = new VatDataModel();
            xListPluBarcodeDataModel = new List<PluBarcodeDataModel>();
            xManufacturerDataModel = new PluManufacturerDataModel();
        }

        public int iId { get; set; }
        public long FkServerId { get; set; }
        public string strCode { get; set; }
        public string strOldCode { get; set; }
        public string strShelfCode { get; set; }
        public int iPurchasePrice { get; set; }
        public int iSalePrice { get; set; }
        public string strName { get; set; }
        public string strShortName { get; set; }
        public string strDescription { get; set; }
        public string strDescriptionOnScreen { get; set; }
        public string strDescriptionOnShelf { get; set; }
        public string strDescriptionOnScale { get; set; }
        public int iFkPluSubGroupId { get; set; }
        public PluSubGroupDataModel xPluSubGroupDataModel { get; set; }
        public int iFkVatId { get; set; }
        public int iVatNo { get; set; }
        public VatDataModel xVat { get; set; }
        public string strKeyboardValue { get; set; }
        public bool bScalable { get; set; }
        public bool bAllowDiscount { get; set; }
        public int iDiscountPercent { get; set; }
        public bool bAllowNegativeStock { get; set; }
        public bool bAllowReturn { get; set; }
        public List<PluBarcodeDataModel> xListPluBarcodeDataModel { get; set; }
        public int iStock { get; set; }
        public string strStockUnit { get; set; }
        public int StockUnitNo { get; set; }
        public StockUnitDataModel xStockUnitDataModel { get; set; }
        public int iMinStock { get; set; }
        public int iMaxStock { get; set; }
        public int iFkManufacturerId { get; set; }
        public PluManufacturerDataModel xManufacturerDataModel { get; set; }
    }
}
