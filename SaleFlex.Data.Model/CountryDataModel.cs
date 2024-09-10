using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class CountryDataModel
    {
        public CountryDataModel()
        {
        }

        public int iId { get; set; }
        public string strCode { get; set; }
        public string strName { get; set; }
        public string strShortName { get; set; }
        public int iNumericCode { get; set; }
        public bool bDefault { get; set; }
    }
}
