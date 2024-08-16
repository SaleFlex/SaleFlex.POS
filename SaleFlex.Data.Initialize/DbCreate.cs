using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite;

using SaleFlex.CommonLibrary;

namespace SaleFlex.Data.Initialize
{
    public class DbCreate
    {
        public static bool bDo()
        {
            bool bReturnValue = false;
            try
            {
                //string createTableQuery = 
                //    @"CREATE TABLE IF NOT EXISTS [MyTable] (
                //      [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                //      [Key] NVARCHAR(2048)  NULL,
                //      [Value] VARCHAR(2048)  NULL
                //      )";

                //SQLiteConnection.CreateFile("SaleFlex.DB.SALES.db3");        // Create the file which will be hosting our database
                //using (SQLiteConnection xSQLiteConnection = new SQLiteConnection("data source=SaleFlex.DB.DB3"))
                //{
                //    using (SQLiteCommand xSQLiteCommand = new System.Data.SQLite.SQLiteCommand(con))
                //    {
                //        xSQLiteConnection.Open();                             // Open the connection to the database

                //        xSQLiteCommand.CommandText = createTableQuery;     // Set CommandText to our query that will create the table
                //        xSQLiteCommand.ExecuteNonQuery();                  // Execute the query

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
                //        xSQLiteConnection.Close();        // Close the connection to the database
                //    }
                //}
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }
    }
}
