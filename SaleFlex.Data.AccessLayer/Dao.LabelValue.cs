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
        // Retrieves a label value based on the label name and the current culture information.
        public string strGetLabelValues(string prm_strLabelName)
        {
            // Initialize the label value data model to store the retrieved label information.
            LabelValueDataModel xLabelValuesDataModel = new LabelValueDataModel();

            // Get the current culture info, which is stored in the JsonParameter singleton instance.
            string strCultureInfo = JsonParameter.xGetInstance().prop_strIsoCultureName;

            try
            {
                // Execute a query to select the label value from the TableLabelValue based on the label name and culture info.
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable(
                    string.Format("SELECT * FROM TableLabelValue WHERE Key='{0}' and CultureInfo='{1}'", prm_strLabelName, strCultureInfo)
                );

                // If the DataTable is not null and contains rows, iterate over the rows to extract label information.
                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xDataRow != null)
                        {
                            // Populate the LabelValueDataModel with the data from the DataRow.
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
                // In case of an exception, log the error and return the label name as the fallback value.
                xException.strTraceError();
                xLabelValuesDataModel.strValue = prm_strLabelName;
            }

            // Return the retrieved label value or the label name if no value is found.
            return xLabelValuesDataModel.strValue;
        }

        // Inserts a new label value into the TableLabelValue.
        public void vSaveLabelValue(ServiceDataModel.LabelValueModel prm_xLabelValueDataModel)
        {
            try
            {
                // Execute an insert query to save the new label value into the TableLabelValue.
                Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteVoidDataTable(
                    string.Format("INSERT INTO TableLabelValue (Name, CultureInfo, Key) VALUES('{0}','{1}','{2}');",
                    prm_xLabelValueDataModel.Value,
                    prm_xLabelValueDataModel.CultureInfo,
                    prm_xLabelValueDataModel.Key)
                );
            }
            catch (Exception xException)
            {
                // Log any exceptions that occur during the save operation.
                xException.strTraceError();
            }
        }
    }
}
