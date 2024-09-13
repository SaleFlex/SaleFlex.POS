using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    // This class represents a data model for storing information about a city in the SaleFlex system.
    public class CityDataModel
    {
        // Constructor to initialize the CityDataModel class, creating a new instance of the CountryDataModel.
        public CityDataModel()
        {
            xCountryDataModel = new CountryDataModel();
        }

        // Unique identifier for the city.
        public int iId { get; set; }

        // Code representing the city, likely used for identification purposes.
        public string strCode { get; set; }

        // Name of the city.
        public string strName { get; set; }

        // Short name or abbreviation for the city.
        public string strShortName { get; set; }

        // Numeric code associated with the city, possibly for internal use or standardization.
        public int iNumericCode { get; set; }

        // An instance of CountryDataModel, representing the country to which the city belongs.
        public CountryDataModel xCountryDataModel { get; set; }

        // Indicates whether the city is the default city (true) or not (false).
        public bool bDefault { get; set; }
    }
}
