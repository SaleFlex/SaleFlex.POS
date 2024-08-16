using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class CityDataModel
    {
        public CityDataModel()
        {
            xCountryDataModel = new CountryDataModel();
        }

        public int iId { get; set; }
        public string strCode { get; set; }
        public string strName { get; set; }
        public string strShortName { get; set; }
        public CountryDataModel xCountryDataModel { get; set; }
        public bool bDefault { get; set; }
    }
}
