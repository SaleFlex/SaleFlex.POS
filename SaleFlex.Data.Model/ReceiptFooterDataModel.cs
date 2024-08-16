using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class ReceiptFooterDataModel
    {
        public ReceiptFooterDataModel()
        {
            xListFooterLine = new List<string>();
        }

        public int iId { get; set; }
        public List<string> xListFooterLine { get; set; }
    }
}
