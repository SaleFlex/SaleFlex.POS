using System.Collections.Generic;

namespace SaleFlex.Data.Models
{
    public class StockDataModel
    {
        public int PluId { get; set; }
        public int BarcodeId { get; set; }
        //public long FkPluMainGroupId { get; set; }
        public string Barcode { get; set; }
        public string Code { get; set; }
        public string ShortName { get; set; }
        public int Stock { get; set; }
        public int StockUnitNo {   get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int No { get; set; }
        public long IncomewithStock { get; set; }


    }
}
