using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public List<CurrencyDataModel> xListGetCurrency()
        {
            return xListGetCurrency(0);
        }

        public List<CurrencyDataModel> xListGetCurrency(int prm_iCurrencyNo)
        {

            try
            {
                List<CurrencyDataModel> xListCurrencyDataModel = null;

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable("SELECT * FROM TableCountry ORDER BY Id");

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListCurrencyDataModel == null)
                            xListCurrencyDataModel = new List<CurrencyDataModel>();

                        if (xDataRow != null)
                        {
                            CurrencyDataModel xCurrencyDataModel = new CurrencyDataModel();

                            xCurrencyDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xCurrencyDataModel.iNo = Convert.ToInt32(xDataRow["No"]);
                            xCurrencyDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                            xCurrencyDataModel.lRateOfCurrency = Convert.ToInt32(xDataRow["RateOfCurrency"]);
                            xCurrencyDataModel.iCurrencyCode = Convert.ToInt32(xDataRow["CurrencyCode"]);
                            xCurrencyDataModel.strSign = Convert.ToString(xDataRow["Sign"]) ?? string.Empty;
                            xCurrencyDataModel.strSignDirection = Convert.ToString(xDataRow["SignDirection"]) ?? string.Empty;
                            xCurrencyDataModel.strCurrencySymbol = Convert.ToString(xDataRow["CurrencySymbol"]) ?? string.Empty;

                            xListCurrencyDataModel.Add(xCurrencyDataModel);
                        }
                    }
                }

                return xListCurrencyDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveCurrency(CurrencyDataModel prm_xCurrencyDataModel)
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
    }
}
