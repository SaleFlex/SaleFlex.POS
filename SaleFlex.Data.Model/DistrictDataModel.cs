using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class DistrictDataModel
    {
        public DistrictDataModel()
        {
            xCityDataModel = new CityDataModel();
        }

        public int iId { get; set; }
        public string strCode { get; set; }
        public string strName { get; set; }
        public string strShortName { get; set; }
        public int iNumericCode { get; set; }
        public CityDataModel xCityDataModel { get; set; }
        public bool bDefault { get; set; }
    }
}
