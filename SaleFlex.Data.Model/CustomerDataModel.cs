using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class CustomerDataModel
    {
        public CustomerDataModel()
        {
        }

        public int iId { get; set; }
        public string strCode { get; set; }
        public string strName { get; set; }
        public string strLasName { get; set; }
        public string strDescription { get; set; }
        public string strAddressLine1 { get; set; }
        public string strAddressLine2 { get; set; }
        public string strAddressLine3 { get; set; }
        public string strZipCode { get; set; }
        public DistrictDataModel xDistrictDataModel { get; set; }
        public CityDataModel xCityDataModel { get; set; }
        public CountryDataModel xCountryDataModel { get; set; }
        public long lBonus { get; set; }
        public string strNationalIdentityNumber { get; set; }
        public string strTaxOffice { get; set; }
        public string strTaxNumber { get; set; }
        public string strEmailAddress { get; set; }
    }
}
