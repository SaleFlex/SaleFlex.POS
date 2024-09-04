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
                bCreateTablePluBarcodeDefinition
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
    }
}
