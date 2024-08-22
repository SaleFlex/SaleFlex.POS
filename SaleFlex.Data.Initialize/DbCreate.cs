using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleFlex.Data;
using SaleFlex.CommonLibrary;
using SaleFlex.Windows;

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
            bool bReturnValue = true;

            if (!File.Exists(CommonProperty.prop_strDatabasePosFileName))
                SQLiteConnection.CreateFile(CommonProperty.prop_strDatabasePosFileName);        // Create the file which will be hosting our database

            var methods = new List<Func<bool>>
            {
                bCreateTablePos,
                bCreateTableCashier,
            };

            foreach (var method in methods)
            {
                if (!method())
                {
                    bReturnValue = false; 
                    break;
                }
            }

            return bReturnValue;
        }

        private static bool bCreateTablePos() 
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


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileName)))
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
                                xSQLiteCommand.CommandText = "INSERT INTO TablePos (Name, SerialNumber, MacAddress, ForceToWorkOnline) " +
                                                            $"VALUES ('SaleFlex POS','{Api.GetDriveSerialNumber()}','{Api.GetMacAddress()}', 0)";
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

        private static bool bCreateTableCashier()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableCashier (
                        Id                      INTEGER PRIMARY KEY ASC AUTOINCREMENT
                                                        UNIQUE
                                                        NOT NULL,
                        No                      INTEGER NOT NULL,
                        Name                    TEXT    NOT NULL,
                        LastName                TEXT    NOT NULL,
                        Password                TEXT    NOT NULL,
                        IdentityNumber          TEXT,
                        Description             TEXT,
                        IsAdministrator         INTEGER NOT NULL
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabasePosFileName)))
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
                                xSQLiteCommand.CommandText = "INSERT INTO TableCashier (No, Name, LastName, Password, IsAdministrator) " +
                                                            $"VALUES (1, 'CASHIER 1','','1234', 0)";
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
