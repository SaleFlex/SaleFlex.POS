using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class ReceiptHeaderDataModel
    {
        public ReceiptHeaderDataModel()
        {
            xListHeaderLine = new List<string>();
        }

        public int iId { get; set; }
        public List<string> xListHeaderLine { get; set; }
    }
}
