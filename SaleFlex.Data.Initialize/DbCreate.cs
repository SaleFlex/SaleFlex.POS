using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleFlex.Data;
using SaleFlex.CommonLibrary;

namespace SaleFlex.Data.Initialize
{
    public class DbCreate
    {

        private static string strCreateConnectionString(string prm_strDatabaseFileName)
        {
            string strConnectionString = string.Format("Data Source={0}; Version=3; UseUTF16Encoding=True;", prm_strDatabaseFileName);
            return strConnectionString;
        }

        public static bool bDo()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TablePos (
                        Id                      INTEGER PRIMARY KEY ASC AUTOINCREMENT
                                                        UNIQUE
                                                        NOT NULL,
                        Name                    TEXT    NOT NULL,
                        SerialNumber            TEXT,
                        Brand                   TEXT,
                        Model                   TEXT,
                        OperatingSystemVersion  TEXT,
                        OwnerNationalIdNumber   TEXT,
                        OwnerTaxIdNumber        TEXT,
                        OwnerMersisIdNumber     TEXT,
                        OwnerComercialRecordNo  TEXT,
                        OwnerWebAdress          TEXT,
                        OwnerRegistrationNumber TEXT,
                        MacAddress              TEXT,
                        CashierScreenType       TEXT,
                        CustomerScreenType      TEXT,
                        CustomerDisplayType     TEXT,
                        CustomerDisplayPort     TEXT,
                        RecieptPrinterType      TEXT,
                        RecieptPrinterPortName  TEXT,
                        InvoicePrinterType      TEXT,
                        InvoicePrinterPortName  TEXT,
                        ScaleType               TEXT,
                        ScalePortName           TEXT,
                        BarcodeReaderPort       TEXT,
                        ServerIp1               TEXT,
                        ServerPort1             TEXT,
                        ServerIp2               TEXT,
                        ServerPort2             TEXT,
                        ForceToWorkOnline       INTEGER,
                        FkDefaultCountryId      INTEGER
                    );";


                SQLiteConnection.CreateFile(CommonProperty.prop_strDatabasePosFileName);        // Create the file which will be hosting our database
                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileName)))
                {
                    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(xSQLiteConnection))
                    {
                        xSQLiteConnection.Open();                           // Open the connection to the database

                        xSQLiteCommand.CommandText = strCreateTableQuery;   // Set CommandText to our query that will create the table
                        int iResult = xSQLiteCommand.ExecuteNonQuery();                   // Execute the query

                //        xSQLiteCommand.CommandText = "INSERT INTO MyTable (Key,Value) Values ('key one','value one')";     // Add the first entry into our database 
                //        xSQLiteCommand.ExecuteNonQuery();      // Execute the query
                //        xSQLiteCommand.CommandText = "INSERT INTO MyTable (Key,Value) Values ('key two','value value')";   // Add another entry into our database 
                //        xSQLiteCommand.ExecuteNonQuery();      // Execute the query

                //        xSQLiteCommand.CommandText = "Select * FROM MyTable";      // Select all rows from our database table

                //        using (SQLiteDataReader reader = com.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                Console.WriteLine(reader["Key"] + " : " + reader["Value"]);     // Display the value of the key and value column for every row
                //            }
                //        }
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
