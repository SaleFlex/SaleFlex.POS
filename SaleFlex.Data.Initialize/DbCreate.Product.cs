﻿using System;
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
                bCreateTablePlu,
                bCreateTablePluBarcode,
                bCreateTablePluBarcodeDefinition,
                bCreateTablePluMainGroup,
                bCreateTablePluManufacturer,
                bCreateTablePluSubGroup,
                bCreateTableVat,
                bCreateTableDepartment
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

        private static bool bCreateTablePlu()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TablePlu (
                        Id                  INTEGER NOT NULL
                                                    UNIQUE
                                                    PRIMARY KEY ASC AUTOINCREMENT,
                        Code                TEXT    NOT NULL,
                        OldCode             TEXT,
                        ShelfCode           TEXT,
                        PurchasePrice       INTEGER,
                        SalePrice           INTEGER,
                        Name                TEXT    NOT NULL,
                        ShortName           TEXT,
                        Description         TEXT,
                        DescriptionOnScreen TEXT,
                        DescriptionOnShelf  TEXT,
                        DescriptionOnScale  TEXT,
                        FkPluSubGroupId     INTEGER NOT NULL,
                        FkVatId             INTEGER NOT NULL,
                        KeyboardValue       TEXT,
                        Scalable            BOOLEAN NOT NULL,
                        AllowDiscount       BOOLEAN NOT NULL,
                        DiscountPercent     INTEGER,
                        AllowNegativeStock  BOOLEAN NOT NULL,
                        AllowReturn         BOOLEAN NOT NULL,
                        Stock               INTEGER NOT NULL,
                        MinStock            INTEGER,
                        MaxStock            INTEGER,
                        StockUnit           TEXT    NOT NULL,
                        FkPluManufacturerId INTEGER NOT NULL
                                                    DEFAULT (1) 
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
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (1, 1, '', 100, 110, 'Baguette', 'Baguette', 'Baguette', 'Baguette', 'Baguette', '', 1, 1, '', 0, 0, 0, 1, 0, 100, 10, 100, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (2, 2, '', 50, 55, 'Granny Smith Apple', 'Apple', 'Granny Smith Apple', 'Granny Smith Apple', 'Granny Smith Apple', 'Granny Smith Apple', 1, 1, '', 1, 0, 0, 0, 1, 100, 10, 100, 'KG', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (3, 3, '', 90, 95, 'Cavendish Banana', 'Banana', 'Cavendish Banana', 'Cavendish Banana', 'Cavendish Banana', 'Cavendish Banana', 1, 1, '', 1, 0, 0, 0, 1, 100, 10, 100, 'KG', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (4, 4, '', 0, 0, 'Heinz Tomato Ketchup', 'Heinz Ketchup', 'Heinz Tomato Ketchup (460g)', 'Heinz Tomato Ketchup (460g)', 'Heinz Tomato Ketchup (460g)', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (5, 5, '', 0, 0, 'Cadbury Dairy Milk Chocolate Bar', 'Chocolate Bar', 'Cadbury Dairy Milk Chocolate Bar (110g)', 'Cadbury Dairy Milk Chocolate Bar (110g)', 'Cadbury Dairy Milk Chocolate Bar (110g)', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (6, 6, '', 0, 0, 'Walkers Ready Salted Crisps', 'Walkers Crisps', 'Walkers Ready Salted Crisps (25g x 6 pack)', 'Walkers Ready Salted Crisps (25g x 6 pack)', 'Walkers Ready Salted Crisps (25g x 6 pack)', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (7, 7, '', 0, 0, 'PG Tips Tea Bags', 'PG Tea Bags', 'PG Tips Tea Bags (80 Bags)', 'PG Tips Tea Bags (80 Bags)', 'PG Tips Tea Bags (80 Bags)', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (8, 8, '', 0, 0, 'Coca-Cola Original Taste', 'Coca-Cola', 'Coca-Cola Original Taste (1.5L Bottle)', 'Coca-Cola Original Taste (1.5L Bottle)', 'Coca-Cola Original Taste (1.5L Bottle)', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (9, 9, '', 0, 0, 'Beard Butter Original', 'Beard Butter', 'Beard Butter Original Formula', 'Beard Butter Original Formula', 'Beard Butter Original Formula', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (10, 10, '', 0, 0, 'Cadbury Dairy Milk Chocolate', 'Milk Chocolate', 'Cadbury Dairy Milk Chocolate 180g', 'Cadbury Dairy Milk Chocolate 180g', 'Cadbury Dairy Milk Chocolate 180g', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (11, 11, '', 0, 0, 'Walkers Ready Salted Crisps', 'Salted Crisps', 'Walkers Ready Salted Crisps 6 Pack', 'Walkers Ready Salted Crisps 6 Pack', 'Walkers Ready Salted Crisps 6 Pack', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (12, 12, '', 0, 0, 'Heinz Baked Beans', 'Baked Beans', 'Heinz Baked Beans 415g', 'Heinz Baked Beans 415g', 'Heinz Baked Beans 415g', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (13, 13, '', 0, 0, 'Warburtons Sliced White Bread', 'Sliced White Bread', 'Warburtons Medium Sliced White Bread 800g', 'Warburtons Medium Sliced White Bread 800g', 'Warburtons Medium Sliced White Bread 800g', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (14, 14, '', 0, 0, 'Lurpak Butter Spreadable', 'Butter Spreadable', 'Lurpak Butter Spreadable 500g', 'Lurpak Butter Spreadable 500g', 'Lurpak Butter Spreadable 500g', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (15, 15, '', 0, 0, 'Ariel Washing Powder', 'Washing Powder', 'Ariel Washing Powder 40 Washes', 'Ariel Washing Powder 40 Washes', 'Ariel Washing Powder 40 Washes', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (16, 16, '', 0, 0, 'Domestos Thick Bleach', 'Thick Bleach', 'Domestos Thick Bleach 750ml', 'Domestos Thick Bleach 750ml', 'Domestos Thick Bleach 750ml', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
                                    "INSERT INTO TablePlu (Code, OldCode, ShelfCode, PurchasePrice, SalePrice, Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId)  VALUES (17, 17, '', 0, 0, 'Tropicana Orange Juice', 'Orange Juice', 'Tropicana Smooth Orange Juice 1L', 'Tropicana Smooth Orange Juice 1L', 'Tropicana Smooth Orange Juice 1L', '', 1, 1, '', 0, 0, 0, 1, 0, 1000, 10, 1000, 'PC', 1)",
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

        private static bool bCreateTablePluBarcode()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TablePluBarcode (
                        Id                       INTEGER NOT NULL
                                                         UNIQUE
                                                         PRIMARY KEY ASC AUTOINCREMENT,
                        FkPluId                  INTEGER NOT NULL,
                        Barcode                  TEXT    NOT NULL,
                        OldBarcode               TEXT,
                        PurchasePrice            INTEGER,
                        SalePrice                INTEGER NOT NULL
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
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (4, '5000157070008', '5000157070008', 100, 110)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (5, '7622210449283', '7622210449283', 80, 88)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (6, '5000328721575', '5000328721575', 150, 165)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (7, '8711200334532', '8711200334532', 200, 220)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (8, '5449000000996', '5449000000996', 172, 190)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (9, '0746817004304', '0746817004304', 350, 385)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (10, '7622210700394', '7622210700394', 180, 200)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (11, '5000328355037', '5000328355037', 135, 150)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (12, '5000157077916', '5000157077916', 110, 120)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (13, '5010044003089', '5010044003089', 136, 150)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (14, '5740900802725', '5740900802725', 455, 500)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (15, '8001090390021', '8001090390021', 546, 600)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (16, '8714100852703', '8714100852703', 91, 100)",
                                    "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, PurchasePrice, SalePrice)  VALUES (17, '5000171054815', '5000171054815', 272, 300)",
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

        private static bool bCreateTablePluManufacturer()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TablePluManufacturer (
                        Id   INTEGER UNIQUE
                                     NOT NULL
                                     PRIMARY KEY ASC AUTOINCREMENT,
                        Name TEXT    NOT NULL
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
                                xSQLiteCommand.CommandText = "INSERT INTO TablePluManufacturer (Name)  VALUES ('General Manufacturer')";
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
                                xSQLiteCommand.CommandText = "INSERT INTO TablePluSubGroup (FkPluMainGroupId, No, Name, DiscountPercent, Description)  VALUES (1, 1, 'General Subproduct', 0, 'Default sub product entry for general sales transactions without specific product identification.')";
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

        private static bool bCreateTableDepartment()
        {
            bool bReturnValue = false;
            try
            {
                string strCreateTableQuery =
                    @"CREATE TABLE If Not Exists TableDepartment (
                        Id              INTEGER NOT NULL
                                                UNIQUE
                                                PRIMARY KEY ASC AUTOINCREMENT,
                        No              INTEGER NOT NULL,
                        Name            TEXT    NOT NULL,
                        DefaultPrice    INTEGER NOT NULL,
                        DefaultQuantity INTEGER NOT NULL,
                        MaxPrice        INTEGER,
                        FkVatId         INTEGER NOT NULL,
                        KeyboardValue   TEXT
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
                                    "INSERT INTO TableDepartment (No, Name, DefaultPrice, DefaultQuantity, MaxPrice, FkVatId)  VALUES (1, 'FOOD', 100, 1, 100, 1)",
                                    "INSERT INTO TableDepartment (No, Name, DefaultPrice, DefaultQuantity, MaxPrice, FkVatId)  VALUES (2, 'TOBACCO', 200, 1, 200, 3)",
                                    "INSERT INTO TableDepartment (No, Name, DefaultPrice, DefaultQuantity, MaxPrice, FkVatId)  VALUES (3, 'INDIVIDUAL', 300, 1, 300, 3)"
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
