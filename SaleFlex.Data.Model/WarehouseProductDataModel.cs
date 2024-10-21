using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFlex.Data.Models
{
    // Products in the Warehouse: Contains details of each product in the warehouse.
    internal class WarehouseProductDataModel
    {
        public WarehouseProductDataModel()
        {
            xProductDataModel = new PluDataModel();
        }

        // Warehouse Product Id
        public int iId { get; set; }

        // Associated Warehouse Id
        public int iFkWarehouseId { get; set; }

        // Product Id (related to PLU)
        public int iFkProductId { get; set; }

        // Product Details
        public PluDataModel xProductDataModel { get; set; }

        // Current stock quantity in the warehouse
        public int iStock { get; set; }

        // Minimum stock level
        public int iMinStock { get; set; }

        // Maximum stock level
        public int iMaxStock { get; set; }

        // Last updated date of the product (stock or information change)
        public DateTime dtLastUpdated { get; set; }
    }
}
