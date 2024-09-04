using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public List<CountryDataModel> xListGetCountries()
        {
            try
            {
                List<CountryDataModel> xListCountryDataModel = null;

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable("SELECT * FROM TableCountry ORDER BY Id");

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListCountryDataModel == null)
                            xListCountryDataModel = new List<CountryDataModel>();

                        if (xDataRow != null)
                        {
                            CountryDataModel xCashierDataModel = new CountryDataModel();

                            xCashierDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xCashierDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                            xCashierDataModel.strCode = Convert.ToString(xDataRow["Code"]) ?? string.Empty;
                            xCashierDataModel.strShortName = Convert.ToString(xDataRow["ShortName"]) ?? string.Empty;
                            xCashierDataModel.iNumericCode = Convert.ToInt32(xDataRow["NumericCode"]);

                            xListCountryDataModel.Add(xCashierDataModel);
                        }

                    }
                }

                return xListCountryDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }
    }
}
