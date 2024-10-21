using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFlex.Data.Models
{
    // Basic Warehouse Model: Defines each warehouse.
    internal class WarehouseDataModel
    {
        public WarehouseDataModel()
        {
            xListWarehouseProductDataModel = new List<WarehouseProductDataModel>();
        }

        // Warehouse Id
        public int iId { get; set; }

        // Warehouse Name
        public string strName { get; set; }

        // Warehouse Location
        public string strLocation { get; set; }

        // Warehouse Type (Main Warehouse, Branch Warehouse, etc.)
        public string strType { get; set; }

        // List of products in the warehouse
        public List<WarehouseProductDataModel> xListWarehouseProductDataModel { get; set; }
    }
}
