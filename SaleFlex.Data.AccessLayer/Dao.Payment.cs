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
        /// <summary>
        /// Retrieves the list of payment types from the database.
        /// </summary>
        /// <returns></returns>
        public List<PaymentTypeDataModel> xListGetPaymentTypes()
        {
            List<PaymentTypeDataModel> xListPaymentTypeDataModel = null;

            try
            {
                // Execute the SQL query to get payment types, ordered by TypeNo.
                string query = "SELECT * FROM TablePaymentType ORDER BY TypeNo";
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable(query);

                // If there are rows in the DataTable, populate the list of payment types.
                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListPaymentTypeDataModel == null)
                            xListPaymentTypeDataModel = new List<PaymentTypeDataModel>();

                        if (xDataRow != null)
                        {
                            PaymentTypeDataModel xPaymentTypeDataModel = new PaymentTypeDataModel();

                            xPaymentTypeDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xPaymentTypeDataModel.iTypeNo = Convert.ToInt32(xDataRow["TypeNo"]);
                            xPaymentTypeDataModel.strTypeName = Convert.ToString(xDataRow["TypeName"]) ?? string.Empty;
                            xPaymentTypeDataModel.strTypeDescription = Convert.ToString(xDataRow["TypeDescription"]) ?? string.Empty;

                            xListPaymentTypeDataModel.Add(xPaymentTypeDataModel);
                        }
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError(); // Log the exception
            }

            return xListPaymentTypeDataModel; // Return the populated list of payment types (or empty if no results)
        }

        /// <summary>
        /// Saves a new payment type to the database
        /// </summary>
        /// <param name="prm_xPaymentTypeDataModel"></param>
        public void vSavePaymentType(ServiceDataModel.PaymentTypeModel prm_xPaymentTypeDataModel)
        {
            try
            {
                // Execute the SQL query with parameters
                Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteVoidDataTable(
                    string.Format("INSERT INTO TablePaymentType (TypeNo, TypeName, TypeDescription) VALUES({0},'{1}','{2}');",
                    prm_xPaymentTypeDataModel.TypeNo,
                    prm_xPaymentTypeDataModel.TypeName,
                    prm_xPaymentTypeDataModel.TypeDescription));
            }
            catch (Exception xException)
            {
                xException.strTraceError(); // Log the exception if something goes wrong
            }
        }

        // Suspended transaction list, managing transactions that are temporarily paused.
        public List<int> xSuspendedListValues;

        /// <summary>
        /// Adds a transaction to the suspended list, returns true if successful.
        /// </summary>
        /// <param name="prm_iTransactionHeadId"></param>
        /// <returns></returns>
        public bool bAddSuspendedList(int prm_iTransactionHeadId)
        {
            bool bReturnValue = false;  // Default return value is false
            int iMaxSuspendListSize = 1;    // Maximum limit for the suspend list size
            try
            {
                if (xSuspendedListValues == null || xSuspendedListValues.Count == 0)
                {
                    xSuspendedListValues = new List<int>(1);
                }
                else if (xSuspendedListValues[0] == prm_iTransactionHeadId)
                {
                    bReturnValue = true;
                }
                if (!(xSuspendedListValues.Count >= iMaxSuspendListSize))
                {
                    if (!xSuspendedListValues.Contains(prm_iTransactionHeadId))
                    {
                        xSuspendedListValues.Add(prm_iTransactionHeadId);
                    }
                    bReturnValue = true;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError(); // Log the exception if something goes wrong
                throw;  // Re-throw the exception after logging
            }

            return bReturnValue;
        }

        /// <summary>
        /// Removes a transaction from the suspended list based on the transaction ID.
        /// </summary>
        /// <param name="prm_iTransactionHeadId"></param>
        public void vRemoveFromSuspendedList(int prm_iTransactionHeadId)
        {
            // Remove the transaction ID from the suspended list, if present.
            if (xSuspendedListValues.Contains(prm_iTransactionHeadId))
                xSuspendedListValues.Remove(prm_iTransactionHeadId);
        }
    }
}
