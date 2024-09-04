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

            if (!File.Exists(CommonProperty.prop_strDatabaseSalesFileNameAndPath))
                SQLiteConnection.CreateFile(CommonProperty.prop_strDatabaseSalesFileNameAndPath);        // Create the file which will be hosting our database

            var DbTableCreateMethods = new List<Func<bool>>
            {
                bCreateTableTransactionHead,
                bCreateTableTransactionDetail,
                bCreateTableTransactionDocumentType
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
                    @"CREATE TABLE If Not Exists TableTransactionHead (
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


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabaseSalesFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                            bReturnValue = true;

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


        private static bool bCreateTableTransactionDetail()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableTransactionDetail (
                    Id                        INTEGER  PRIMARY KEY AUTOINCREMENT,
                    FkTransactionHeadId       INTEGER,
                    FkPluId                   INTEGER,
                    FkDepartmentId            INTEGER,
                    Price                     REAL,
                    Quantity                  REAL,
                    TotalPrice                REAL,
                    TotalPriceWithoutVat      REAL,
                    TotalVat                  REAL,
                    Canceled                  BOOLEAN  DEFAULT (0),
                    TransactionDetailDateTime DATETIME
                );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabaseSalesFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                            bReturnValue = true;
                        
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

        private static bool bCreateTableTransactionDocumentType()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableTransactionDocumentType (
                        Id          INTEGER PRIMARY KEY ASC AUTOINCREMENT
                                            UNIQUE
                                            NOT NULL,
                        No          INTEGER NOT NULL,
                        Name        TEXT    NOT NULL,
                        DisplayName TEXT,
                        Description TEXT
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabaseSalesFileNameAndPath)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();     // Execute the create table query

                        if (iResult >= 0)
                        {
                            bReturnValue = true;
                            if (CommonProperty.prop_bIsOfflinePos)
                            {
                                string[] straCountries = new string[]
                                {
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (1, 'FISCAL_RECEIPT', 'Reciept', 'Fiscal Reciept');",
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (2, 'NONE_FISCAL_RECEIPT', 'Reciept', 'Non Fiscal Reciept');",
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (3, 'NONE_FISCAL_INVOICE', 'Invoice', 'Printed Invoice');",
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (4, 'NONE_FISCAL_E_INVOICE', 'E Invoice', 'Electronic Invoice');",
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (5, 'NONE_FISCAL_E_ARCHIVE_INVOICE', 'E Archive Invoice', 'Electronic Archive Invoice');",
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (6, 'NONE_FISCAL_DIPLOMATIC_RECEIPT', 'Diplomatic Invoice', 'Diplomatic Invoice');",
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (7, 'NONE_FISCAL_WAYBILL', 'Waybill', 'Waybill');",
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (8, 'NONE_FISCAL_DELIVERY_NOTE', 'Delivery Note', 'Delivery Note');",
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (9, 'NONE_FISCAL_CASH_OUT_FLOW', 'Cash Out flow', 'Cash Out flow');",
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (10, 'NONE_FISCAL_CASH_IN_FLOW', 'Cash In flow', 'Cash In flow');",
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (11, 'NONE_FISCAL_RETURN', 'Return', 'Return');",
                                    "INSERT INTO TableTransactionDocumentType (No, Name, DisplayName, Description) VALUES (12, 'NONE_FISCAL_SELF_BILLING_INVOICE', 'Self Billing Invoice', 'Self Billing Invoice');",
                                };

                                foreach (string strCountry in straCountries)
                                {
                                    xSQLiteCommand.CommandText = strCountry;
                                    iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
                                }
                            }
                        }

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
