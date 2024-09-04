using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleFlex.CommonLibrary;

namespace SaleFlex.Data.Initialize
{
    public partial class DbCreate
    {
        public static bool bCreateSalesDb()
        {
            bool bReturnValue = true;

            if (!File.Exists(CommonProperty.prop_strDatabaseSalesFileName))
                SQLiteConnection.CreateFile(CommonProperty.prop_strDatabaseSalesFileName);        // Create the file which will be hosting our database

            var DbTableCreateMethods = new List<Func<bool>>
            {
                bCreateTableTransactionHead
            };

            foreach (var DbTableCreateMethod in DbTableCreateMethods)
            {
                if (!DbTableCreateMethod())
                {
                    bReturnValue = false;
                    break;
                }
            }

            return bReturnValue;
        }

        private static bool bCreateTableTransactionHead()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE TableTransactionHead (
                        Id                           INTEGER  PRIMARY KEY ASC AUTOINCREMENT
                                                              UNIQUE
                                                              NOT NULL,
                        FkCashierId                  INTEGER  NOT NULL,
                        TransactionDateTime          DATETIME NOT NULL,
                        FkTransactionDocumentTypeId  INTEGER  NOT NULL,
                        FkCustomerId                 INTEGER,
                        TransactionNo                TEXT     NOT NULL,
                        ReceiptNumber                INTEGER  NOT NULL,
                        ZNumber                      INTEGER  NOT NULL,
                        ReceiptTotalPrice            REAL,
                        ReceiptTotalVat              REAL,
                        TotalDiscountAmount          REAL,
                        TransactionsDiscountAmount   REAL,
                        CustomerTotalDiscountAmount  REAL,
                        PromotionTotalDiscountAmount REAL,
                        SurchargeAmount              REAL,
                        PaymentAmount                REAL,
                        ChangeAmount                 REAL,
                        RoundAmount                  REAL,
                        IsVoided                     BOOLEAN  NOT NULL
                                                              DEFAULT (0) 
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabaseSalesFileName)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        xSQLiteConnection.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }
    }
}
