﻿using System;
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
        public static bool bCreateCustomerDb()
        {
            bool bReturnValue = true;

            if (!File.Exists(CommonProperty.prop_strDatabaseCustomersFileNameAndPath))
                SQLiteConnection.CreateFile(CommonProperty.prop_strDatabaseCustomersFileNameAndPath);        // Create the file which will be hosting our database

            var DbTableCreateMethods = new List<Func<bool>>
            {
                bCreateTableCustomer
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

        private static bool bCreateTableCustomer()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableCustomer (
                        Id                     INTEGER PRIMARY KEY
                                                       UNIQUE
                                                       NOT NULL,
                        Code                   TEXT,
                        Name                   TEXT,
                        LasName                TEXT,
                        Description            TEXT,
                        AddressLine1           TEXT,
                        AddressLine2           TEXT,
                        AddressLine3           TEXT,
                        ZipCode                TEXT,
                        FkDistrict             INTEGER,
                        FkCity                 INTEGER,
                        FkCountry              INTEGER,
                        Bonus                  INTEGER,
                        NationalIdentityNumber TEXT,
                        TaxOffice              TEXT,
                        TaxNumber              TEXT,
                        EmailAddress           TEXT,
                        PhoneNumber            TEXT
                    );";


                using (SQLiteConnection xSQLiteConnection = new SQLiteConnection(strCreateConnectionString(CommonProperty.prop_strDatabaseCustomersFileNameAndPath)))
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
    }
}
