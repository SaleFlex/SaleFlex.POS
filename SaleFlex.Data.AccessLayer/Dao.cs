using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;
using SaleFlex.Data.SQLite;
using System.Data;

namespace SaleFlex.Data.AccessLayer
{
    // Data Access Object (DAO) class for accessing database operations in SaleFlex system.
    public partial class Dao
    {
        // Singleton instance managed by Lazy<T> for thread safety and lazy initialization.
        private static readonly Lazy<Dao> m_xGlobalsInstance = new Lazy<Dao>(() => new Dao());

        // Connection string for database access
        private string m_strConnectionString = string.Empty;

        // Private constructor to prevent direct instantiation of Dao class (Singleton pattern)
        Dao()
        {
            try
            {
                // Initialization of database connection or other resources can go here.
                // If any exception occurs, it is caught and logged.
            }
            catch (Exception xException)
            {
                // Log the exception and throw a new exception to indicate a database connection failure
                xException.strTraceError();
                throw new ApplicationException("DB CONNECTION FAILED");
            }
        }

        // Get the singleton instance of Dao.
        public static Dao xGetInstance()
        {
            return m_xGlobalsInstance.Value;  // Lazy<T> manages instantiation
        }

        // Method to get the next sequence value based on a given sequence name
        // In this basic version, it always returns 1 (not implemented to retrieve actual sequences from DB)
        public long lGetSequence(string prm_strSequenceName)
        {
            // This method is a placeholder and should be replaced with logic to retrieve the next sequence number from the database.
            return 1;
        }

        // Retrieve the design of a transaction document based on its type ID
        public TransactionDocumentDesignDataModel xGetTransactionDocumentDesign(int prm_iTransactionDocumentTypeDataModelId)
        {
            // Creates and returns a default (empty) TransactionDocumentDesignDataModel.
            // Currently, it does not interact with the database to fetch actual data.
            TransactionDocumentDesignDataModel xTransactionDocumentDesignDataModel = new TransactionDocumentDesignDataModel();
            return xTransactionDocumentDesignDataModel;
        }

        // Retrieves form function data for a given form type (EnumFormType).
        public FormFunctionDataModel xGetFormFunction(EnumFormType prm_enumFormType)
        {
            // Retrieve data from the 'TableForm' table based on the provided form type.
            DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable(
                $"SELECT * FROM TableForm WHERE Function='{prm_enumFormType.ToString()}' ORDER BY Id"
            );

            // List to hold form function data models
            List<FormFunctionDataModel> xListFormFunctionDataModel = null;

            // If the data table contains rows, iterate through each row
            if (xDataTable != null && xDataTable.Rows.Count > 0)
            {
                foreach (DataRow xDataRow in xDataTable.Rows)
                {
                    // Initialize the list if it hasn't been created yet
                    if (xListFormFunctionDataModel == null)
                    {
                        xListFormFunctionDataModel = new List<FormFunctionDataModel>();
                    }

                    // Create a new FormFunctionDataModel and populate it with data from the current DataRow
                    FormFunctionDataModel xFormFunctionDataModel = new FormFunctionDataModel();
                    xFormFunctionDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                    xFormFunctionDataModel.strName = Convert.ToString(xDataRow["Name"]);
                    xFormFunctionDataModel.bNeedAuth = Convert.ToBoolean(xDataRow["NeedAuth"]);
                    xFormFunctionDataModel.bNeedLogin = Convert.ToBoolean(xDataRow["NeedLogin"]);
                    xFormFunctionDataModel.iNo = Convert.ToInt32(xDataRow["FormNo"]);

                    // Add the populated FormFunctionDataModel to the list
                    xListFormFunctionDataModel.Add(xFormFunctionDataModel);
                }
            }

            // Return the first form function data model in the list, or null if no data was found
            return xListFormFunctionDataModel?.FirstOrDefault();
        }
    }
}
