using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;
using SaleFlex.Data.SQLite;
using System.Data;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public bool bCheckCustomersDb()
        {
            bool returnvalue = false;

            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseCustomersFileNameAndPath).xExecuteDataTable("SELECT count(*) FROM sqlite_master WHERE type='table'");

                if (xDataTable.Rows.Count > 0)
                {
                    int iTableCount = Convert.ToInt32(xDataTable.Rows[0][0]) - 1;

                    if (iTableCount == 1)
                    {
                        returnvalue = true;
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return returnvalue;
        }

        public List<CountryDataModel> xListGetCountry()
        {
            return xListGetCountry(string.Empty);
        }

        public List<CountryDataModel> xListGetCountry(string prm_strCountryName)
        {
            try
            {
                List<CountryDataModel> xListCountryDataModel = null;

                if (xListCountryDataModel == null)
                    xListCountryDataModel = new List<CountryDataModel>();

                return xListCountryDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<CountryDataModel> xListGetDefaultCountry()
        {
            try
            {
                List<CountryDataModel> xListCountryDataModel = null;

                return xListCountryDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<CityDataModel> xListGetCity()
        {
            return xListGetCity(string.Empty, 0);
        }

        public List<CityDataModel> xListGetCity(string prm_strCityName)
        {
            return xListGetCity(prm_strCityName, 0);
        }

        public List<CityDataModel> xListGetCity(int prm_iCountryId)
        {
            return xListGetCity(string.Empty, prm_iCountryId);
        }

        public List<CityDataModel> xListGetCity(string prm_strCityName, long prm_lCountryId)
        {
            try
            {
                List<CityDataModel> xListCityDataModel = null;

                if (xListCityDataModel == null)
                    xListCityDataModel = new List<CityDataModel>();

                return xListCityDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<DistrictDataModel> xListGetDistricts()
        {
            return xListGetDistricts(string.Empty, 0);
        }

        public List<DistrictDataModel> xListGetDistricts(long prm_lCityId)
        {
            return xListGetDistricts(string.Empty, prm_lCityId);
        }

        public List<DistrictDataModel> xListGetDistricts(string prm_strDistrictName)
        {
            return xListGetDistricts(prm_strDistrictName, 0);
        }

        public List<DistrictDataModel> xListGetDistricts(string prm_strDistrictName, long prm_lCityId)
        {
            try
            {
                List<DistrictDataModel> xListDistrictDataModel = null;

                if (xListDistrictDataModel == null)
                    xListDistrictDataModel = new List<DistrictDataModel>();

                return xListDistrictDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<CustomerDataModel> xListGetCustomers(string prm_strCustomerCode, string prm_strCustomerName, string prm_strCustomerLastName, long prm_lId = 0)
        {
            try
            {
                List<CustomerDataModel> xListCustomerDataModel = null;

                    if (xListCustomerDataModel == null)
                        xListCustomerDataModel = new List<CustomerDataModel>();

                return xListCustomerDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveCustomer(CustomerDataModel prm_xCustomerDataModel)
        {
            try
            {
                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public int iGetLastCustomerId()
        {
           
            return 0;
        }

        public List<CustomerDataModel> xListGetCustomers()
        {
            return xListGetCustomers(string.Empty, string.Empty, string.Empty, 0);
        }
    }
}
