using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFlex.Data.Models
{
    // Warehouse Transactions: Used to record warehouse entries and exits.
    public class WarehouseTransactionDataModel
    {
        // Transaction Id
        public int iId { get; set; }

        // Warehouse Id
        public int iFkWarehouseId { get; set; }

        // Product Id (related to PLU)
        public int iFkProductId { get; set; }

        // Transaction Type (Entry, Exit, Transfer)
        public string strTransactionType { get; set; }

        // Transaction quantity (can be positive or negative)
        public int iQuantity { get; set; }

        // Transaction date
        public DateTime dtTransactionDate { get; set; }

        // Transaction description (details such as why it was made, by whom)
        public string strDescription { get; set; }
    }
}
