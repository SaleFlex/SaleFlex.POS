using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using SaleFlex.CommonLibrary;

namespace SaleFlex.Data.Initialize
{
    public partial class DbCreate
    {
        public static bool bCreateProductDb()
        {
            bool bReturnValue = true;

            if (!File.Exists(CommonProperty.prop_strDatabaseProductsFileNameAndPath))
                SQLiteConnection.CreateFile(CommonProperty.prop_strDatabaseProductsFileNameAndPath);        // Create the file which will be hosting our database

            var DbTableCreateMethods = new List<Func<bool>>
            {
                bCreateTablePluBarcodeDefinition,
                bCreateTablePluMainGroup,
                bCreateTablePluSubGroup,
                bCreateTableVat
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

        private static bool bCreateTablePluBarcodeDefinition()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TablePluBarcodeDefinition (
                        Id                  INTEGER NOT NULL
                                                    UNIQUE
                                                    PRIMARY KEY ASC AUTOINCREMENT,
                        Name                TEXT    NOT NULL,
                        LengthOfBarcode     INTEGER NOT NULL,
                        StartingDigits      TEXT    NOT NULL,
                        LengthOfProductCode INTEGER NOT NULL,
                        LengthOfQuantity    INTEGER,
                        LengthOfPrice       INTEGER,
                        Description         TEXT
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabaseProductsFileNameAndPath)))
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
                                xSQLiteCommand.CommandText = "INSERT INTO TablePluBarcodeDefinition (Name, LengthOfBarcode, StartingDigits, LengthOfProductCode, LengthOfQuantity)  VALUES ('WEIGHED GOODS', 13, '1', 6, 6)";
                                iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
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

        private static bool bCreateTablePluMainGroup()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TablePluMainGroup (
                        Id              INTEGER NOT NULL
                                                UNIQUE
                                                PRIMARY KEY ASC AUTOINCREMENT,
                        No              INTEGER NOT NULL,
                        Name            TEXT    NOT NULL,
                        DiscountPercent INTEGER NOT NULL,
                        MaxPrice        REAL,
                        Description     TEXT
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabaseProductsFileNameAndPath)))
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
                                xSQLiteCommand.CommandText = "INSERT INTO TablePluMainGroup (No, Name, DiscountPercent, Description)  VALUES (1, 'General Product', 0, 'Default product entry for general sales transactions without specific product identification.')";
                                iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
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

        private static bool bCreateTablePluSubGroup()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TablePluSubGroup (
                        Id               INTEGER NOT NULL
                                                 UNIQUE
                                                 PRIMARY KEY ASC AUTOINCREMENT,
                        FkPluMainGroupId INTEGER NOT NULL,
                        No               INTEGER NOT NULL,
                        Name             TEXT    NOT NULL,
                        DiscountPercent  INTEGER NOT NULL,
                        Description      TEXT
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabaseProductsFileNameAndPath)))
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
                                xSQLiteCommand.CommandText = "INSERT INTO TablePluSubGroup (No, Name, DiscountPercent, Description)  VALUES (1, 'General Subproduct', 0, 'Default sub product entry for general sales transactions without specific product identification.')";
                                iResult = xSQLiteCommand.ExecuteNonQuery();      // Execute the insert query
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

        private static bool bCreateTableVat()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableVat (
                        Id          INTEGER NOT NULL
                                            UNIQUE
                                            PRIMARY KEY ASC AUTOINCREMENT,
                        No          INTEGER NOT NULL,
                        Name        TEXT    NOT NULL,
                        Rate        INTEGER NOT NULL,
                        Description TEXT
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabaseProductsFileNameAndPath)))
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
                                string[] straQueries = new string[]
                                {
                                    "INSERT INTO TableVat (No, Name, Rate, Description)  VALUES (1, '%0', 0, 'Zero VAT Rate (0%)')",
                                    "INSERT INTO TableVat (No, Name, Rate, Description)  VALUES (2, '%5', 5, 'Reduced VAT Rate (5%)')",
                                    "INSERT INTO TableVat (No, Name, Rate, Description)  VALUES (3, '%20', 20, 'Standard VAT Rate (20%)')"
                                };

                                foreach (string strQuery in straQueries)
                                {
                                    xSQLiteCommand.CommandText = strQuery;
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
