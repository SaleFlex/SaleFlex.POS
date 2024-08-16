using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class StockUnitDataModel
    {
        public int StockUnitId { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Coefficient { get; set; }

    }
}
