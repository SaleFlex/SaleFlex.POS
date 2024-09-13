using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;
using SaleFlex.Data.AccessLayer;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public string strGetLabelValues(string prm_strLabelName)
        {

            LabelValueDataModel xLabelValuesDataModel = new LabelValueDataModel();

            string strCultureInfo = JsonParameter.xGetInstance().prop_strIsoCultureName;

            try
            {

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable(string.Format("SELECT * FROM TableLabelValue WHERE Key='{0}' and CultureInfo='{1}'", prm_strLabelName, strCultureInfo));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xDataRow != null)
                        {
                            xLabelValuesDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xLabelValuesDataModel.strKey = Convert.ToString(xDataRow["Key"]);
                            xLabelValuesDataModel.strValue = Convert.ToString(xDataRow["Value"]);
                            xLabelValuesDataModel.strCultureInfo = Convert.ToString(xDataRow["CultureInfo"]);
                        }

                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                xLabelValuesDataModel.strValue = prm_strLabelName;
            }

            return xLabelValuesDataModel.strValue;
        }

        public void vSaveLabelValue(ServiceDataModel.LabelValueModel prm_xLabelValueDataModel)
        {
            try
            {
                Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteVoidDataTable(
                    string.Format("INSERT INTO TableLabelValue (Name, CultureInfo, Key) VALUES('{0}','{1}','{2}');",
                    prm_xLabelValueDataModel.Value,
                    prm_xLabelValueDataModel.CultureInfo,
                    prm_xLabelValueDataModel.Key));
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

    }
}
