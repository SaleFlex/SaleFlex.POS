using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;
using SaleFlex.Data.AccessLayer;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public bool bCheckPluDb()
        {
            bool returnvalue = false;

            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable("SELECT count(*) FROM sqlite_master WHERE type='table'");

                if (xDataTable.Rows.Count > 0)
                {
                    int iTableCount = Convert.ToInt32(xDataTable.Rows[0][0]) - 1;

                    if (iTableCount == 7)
                    {
                        returnvalue = true;
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return returnvalue;
        }

        public PluDataModel xGetPluByCode(string prm_strPluCode)
        {
            PluDataModel xPluDataModel = null;

            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format("SELECT * FROM TablePlu WHERE Code = '{0}' ORDER BY Code", prm_strPluCode));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xDataRow != null)
                        {
                            xPluDataModel = new PluDataModel();

                            xPluDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xPluDataModel.strCode = Convert.ToString(xDataRow["Code"]);
                            xPluDataModel.strOldCode = Convert.ToString(xDataRow["OldCode"]);
                            xPluDataModel.strShelfCode = Convert.ToString(xDataRow["ShelfCode"]);
                            xPluDataModel.iPurchasePrice = Convert.ToInt32(xDataRow["PurchasePrice"]);
                            xPluDataModel.iSalePrice = Convert.ToInt32(xDataRow["SalePrice"]);
                            xPluDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                            xPluDataModel.strShortName = Convert.ToString(xDataRow["ShortName"]) ?? string.Empty;
                            xPluDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnScreen = Convert.ToString(xDataRow["DescriptionOnScreen"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnShelf = Convert.ToString(xDataRow["DescriptionOnShelf"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnScale = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                            xPluDataModel.iFkPluSubGroupId = Convert.ToInt32(xDataRow["FkPluSubGroupId"]);
                            xPluDataModel.iFkVatId = Convert.ToInt32(xDataRow["FkVatId"]);
                            xPluDataModel.strKeyboardValue = Convert.ToString(xDataRow["KeyboardValue"]) ?? string.Empty;
                            xPluDataModel.bScalable = Convert.ToBoolean(xDataRow["Scalable"]);
                            xPluDataModel.bAllowDiscount = Convert.ToBoolean(xDataRow["AllowDiscount"]);
                            xPluDataModel.iDiscountPercent = Convert.ToInt32(xDataRow["DiscountPercent"]);
                            xPluDataModel.bScalable = Convert.ToBoolean(xDataRow["AllowNegativeStock"]);
                            xPluDataModel.bAllowDiscount = Convert.ToBoolean(xDataRow["AllowReturn"]);
                            xPluDataModel.iStock = Convert.ToInt32(xDataRow["Stock"]);
                            xPluDataModel.iMinStock = Convert.ToInt32(xDataRow["MinStock"]);
                            xPluDataModel.iMaxStock = Convert.ToInt32(xDataRow["MaxStock"]);
                            xPluDataModel.strStockUnit = Convert.ToString(xDataRow["StockUnit"]);
                            xPluDataModel.iFkManufacturerId = Convert.ToInt32(xDataRow["FkPluManufacturerId"]);
                            xPluDataModel.xPluSubGroupDataModel = xGetPluSubGroupById(xPluDataModel.iFkPluSubGroupId);
                            xPluDataModel.xListPluBarcodeDataModel = xListGetPluBarcode(xPluDataModel.iId);

                            break;
                        }

                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xPluDataModel;
        }

        public PluDataModel xGetPluById(long prm_iPluId)
        {
            PluDataModel xPluDataModel = new PluDataModel();

            try
            {
                var query = string.Format("SELECT * FROM TablePlu WHERE Id = {0}", prm_iPluId);
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(query);

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xDataRow != null)
                        {
                            xPluDataModel = new PluDataModel();

                            xPluDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xPluDataModel.FkServerId = Convert.ToInt32(xDataRow["FkServerId"]);
                            xPluDataModel.strCode = Convert.ToString(xDataRow["Code"]);
                            xPluDataModel.strOldCode = Convert.ToString(xDataRow["OldCode"]);
                            xPluDataModel.strShelfCode = Convert.ToString(xDataRow["ShelfCode"]);
                            xPluDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                            xPluDataModel.strShortName = Convert.ToString(xDataRow["ShortName"]) ?? string.Empty;
                            xPluDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnScreen = Convert.ToString(xDataRow["DescriptionOnScreen"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnShelf = Convert.ToString(xDataRow["DescriptionOnShelf"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnScale = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                            xPluDataModel.iFkPluSubGroupId = Convert.ToInt32(xDataRow["FkPluSubGroupId"]);
                            xPluDataModel.iFkVatId = Convert.ToInt32(xDataRow["FkVatId"]);
                            xPluDataModel.strKeyboardValue = Convert.ToString(xDataRow["KeyboardValue"]) ?? string.Empty;
                            xPluDataModel.bScalable = Convert.ToBoolean(xDataRow["Scalable"]);
                            xPluDataModel.bAllowDiscount = Convert.ToBoolean(xDataRow["AllowDiscount"]);
                            xPluDataModel.iDiscountPercent = Convert.ToInt32(xDataRow["DiscountPercent"]);
                            xPluDataModel.bScalable = Convert.ToBoolean(xDataRow["AllowNegativeStock"]);
                            xPluDataModel.bAllowDiscount = Convert.ToBoolean(xDataRow["AllowReturn"]);
                            xPluDataModel.iStock = Convert.ToInt32(xDataRow["Stock"]);
                            xPluDataModel.strStockUnit = Convert.ToString(xDataRow["StockUnit"]) ?? string.Empty;
                            xPluDataModel.StockUnitNo = Convert.ToInt32(xDataRow["StockUnitNo"]);
                            xPluDataModel.iFkManufacturerId = Convert.ToInt32(xDataRow["FkPluManufacturerId"]);
                            xPluDataModel.xPluSubGroupDataModel = xGetPluSubGroupById(xPluDataModel.iFkPluSubGroupId);
                            xPluDataModel.xVat = xGetVatByNo(Convert.ToInt32(xDataRow["VatNo"]));
                            xPluDataModel.xListPluBarcodeDataModel = xListGetPluBarcode(xPluDataModel.iId);

                            break;
                        }

                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xPluDataModel;
        }

        public string strGetPluCode(string prm_strPluBarcode)
        {
            string strPluCode = string.Empty;

            try
            {
                var query = $"SELECT Code FROM TablePluBarcode LEFT JOIN TablePlu ON TablePlu.Id=TablePluBarcode.FkPluId WHERE Barcode=\'{prm_strPluBarcode}\' ORDER BY Barcode";

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(query);

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xDataRow != null)
                        {
                            strPluCode = xDataRow["Code"].ToString();
                            break;
                        }
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return strPluCode;
        }

        public string GetBarcodeByBarcodeId(long barcodeId)
        {
            string barcode = string.Empty;

            try
            {
                var query = string.Format("SELECT Barcode FROM TablePluBarcode WHERE Id = {0}", barcodeId);

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(query);

                if (xDataTable != null)
                {
                    barcode = xDataTable.Rows[0]["Barcode"].ToString();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return barcode;
        }

        public List<PluBarcodeDataModel> xListGetPluBarcode(int prm_iFkPluId)
        {
            List<PluBarcodeDataModel> xListPluBarcodeDataModel = null;

            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable($"SELECT * FROM TablePluBarcode WHERE FkPluId={prm_iFkPluId} ORDER BY Barcode");

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListPluBarcodeDataModel == null)
                            xListPluBarcodeDataModel = new List<PluBarcodeDataModel>();

                        if (xDataRow != null)
                        {
                            PluBarcodeDataModel xPluBarcodeDataModel = new PluBarcodeDataModel();

                            xPluBarcodeDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xPluBarcodeDataModel.iFkPluId = Convert.ToInt32(xDataRow["FkPluId"]);
                            xPluBarcodeDataModel.strBarcode = Convert.ToString(xDataRow["Barcode"]) ?? string.Empty;
                            xPluBarcodeDataModel.strOldBarcode = Convert.ToString(xDataRow["OldBarcode"]) ?? string.Empty;
                            xPluBarcodeDataModel.decPurchasePrice = Convert.ToInt64(xDataRow["PurchasePrice"]);
                            xPluBarcodeDataModel.decSalePrice = Convert.ToInt64(xDataRow["SalePrice"]);

                            xListPluBarcodeDataModel.Add(xPluBarcodeDataModel);
                        }

                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xListPluBarcodeDataModel;
        }

        public PluDataModel xGetPlu(string prm_strBarcode)
        {
            List<PluDataModel> xListPluDataModel = xListGetPlu(string.Empty, prm_strBarcode, 0);

            if (xListPluDataModel == null)
                return null;

            return xListPluDataModel.First();
        }

        public List<PluDataModel> xListGetPlusByMainGroupId(int prm_iPluMainGroupId)
        {
            return xListGetPlu(string.Empty, string.Empty, prm_iPluMainGroupId);
        }

        public List<PluDataModel> xListGetPlu()
        {
            try
            {
                List<PluDataModel> xListPluDataModel = null;

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable("SELECT * FROM TablePlu ORDER BY Code");

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListPluDataModel == null)
                            xListPluDataModel = new List<PluDataModel>();

                        if (xDataRow != null)
                        {
                            PluDataModel xPluDataModel = new PluDataModel();

                            xPluDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xPluDataModel.strCode = Convert.ToString(xDataRow["Code"]);
                            xPluDataModel.strOldCode = Convert.ToString(xDataRow["OldCode"]);
                            xPluDataModel.strShelfCode = Convert.ToString(xDataRow["ShelfCode"]);
                            xPluDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                            xPluDataModel.strShortName = Convert.ToString(xDataRow["ShortName"]) ?? string.Empty;
                            xPluDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnScreen = Convert.ToString(xDataRow["DescriptionOnScreen"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnShelf = Convert.ToString(xDataRow["DescriptionOnShelf"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnScale = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                            xPluDataModel.iFkPluSubGroupId = Convert.ToInt32(xDataRow["FkPluSubGroupId"]);
                            xPluDataModel.iFkVatId = Convert.ToInt32(xDataRow["FkVatId"]);
                            xPluDataModel.strKeyboardValue = Convert.ToString(xDataRow["KeyboardValue"]) ?? string.Empty;
                            xPluDataModel.bScalable = Convert.ToBoolean(xDataRow["Scalable"]);
                            xPluDataModel.bAllowDiscount = Convert.ToBoolean(xDataRow["AllowDiscount"]);
                            xPluDataModel.iDiscountPercent = Convert.ToInt32(xDataRow["DiscountPercent"]);
                            xPluDataModel.bScalable = Convert.ToBoolean(xDataRow["AllowNegativeStock"]);
                            xPluDataModel.bAllowDiscount = Convert.ToBoolean(xDataRow["AllowReturn"]);
                            xPluDataModel.iStock = Convert.ToInt32(xDataRow["Stock"]);
                            xPluDataModel.strStockUnit = Convert.ToString(xDataRow["StockUnit"]) ?? string.Empty;
                            xPluDataModel.StockUnitNo = Convert.ToInt32(xDataRow["StockUnitNo"]);
                            xPluDataModel.iFkManufacturerId = Convert.ToInt32(xDataRow["FkPluManufacturerId"]);
                            xPluDataModel.xPluSubGroupDataModel = xGetPluSubGroupById(xPluDataModel.iFkPluSubGroupId);
                            xPluDataModel.xVat = xGetVatById(xPluDataModel.iFkVatId);
                            xPluDataModel.xListPluBarcodeDataModel = xListGetPluBarcode(xPluDataModel.iId);

                            xListPluDataModel.Add(xPluDataModel);
                        }

                    }
                }

                return xListPluDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<PluDataModel> xListGetPlu(string prm_strPluNo, string prm_strBarcode, int prm_iPluMainGroupNo)
        {
            //PluCode a göre order yapıldığından databasedeki plu codelar 000001 000002 000003 şeklinde tanımlanmıştır.
            try
            {
                List<PluDataModel> xListPluDataModel = null;

                if (xListPluDataModel == null)
                    xListPluDataModel = new List<PluDataModel>();

                return xListPluDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<PluSearchDataModel> xListGetBarcodeData(string prm_strSearchExpression)
        {
            try
            {
                List<PluSearchDataModel> xListPluSearchDataModel = null;
               
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format("SELECT  tpb.Id as BarcodeId, tp.ShortName as Name, tpb.Barcode as Barcode, tpb.SalePrice FROM TablePlu as tp inner join TablePluBarcode as tpb on tp.Id = tpb.FkPluId  where tpb.Barcode Like '%{0}%' or tp.ShortName like '%{0}%'", prm_strSearchExpression));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    xListPluSearchDataModel = new List<PluSearchDataModel>();

                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        
                        if (xDataRow != null)
                        {
                            PluSearchDataModel xPluDataModel = new PluSearchDataModel();
                            xPluDataModel.PluBarcodeId= Convert.ToInt32(xDataRow["BarcodeId"]);
                            xPluDataModel.strShortName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                            xPluDataModel.Barcode= Convert.ToString(xDataRow["Barcode"]) ?? string.Empty;
                            xPluDataModel.SalePrice = Convert.ToInt32(xDataRow["SalePrice"]);
                            xListPluSearchDataModel.Add(xPluDataModel);
                        }
                    }
                }
                return xListPluSearchDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<PluDataModel> xListGetPluPriceLookUp(string prm_strSearchExpression)
        {
            try
            {
                List<PluDataModel> xListPluDataModel = null;

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format("SELECT * FROM TablePlu JOIN TablePluBarcode ON TablePlu.Id=TablePluBarcode.FkPluId WHERE Name Like '%{0}%' OR Barcode Like '%{0}%' OR Code Like '%{0}%' ORDER BY Name", prm_strSearchExpression));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListPluDataModel == null)
                            xListPluDataModel = new List<PluDataModel>();

                        if (xDataRow != null)
                        {
                            PluDataModel xPluDataModel = new PluDataModel();

                            xPluDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xPluDataModel.strCode = Convert.ToString(xDataRow["Code"]);
                            xPluDataModel.strOldCode = Convert.ToString(xDataRow["OldCode"]);
                            xPluDataModel.strShelfCode = Convert.ToString(xDataRow["ShelfCode"]);
                            xPluDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                            xPluDataModel.strShortName = Convert.ToString(xDataRow["ShortName"]) ?? string.Empty;
                            xPluDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnScreen = Convert.ToString(xDataRow["DescriptionOnScreen"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnShelf = Convert.ToString(xDataRow["DescriptionOnShelf"]) ?? string.Empty;
                            xPluDataModel.strDescriptionOnScale = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                            xPluDataModel.iFkPluSubGroupId = Convert.ToInt32(xDataRow["FkPluSubGroupId"]);
                            xPluDataModel.iFkVatId = Convert.ToInt32(xDataRow["FkVatId"]);
                            xPluDataModel.strKeyboardValue = Convert.ToString(xDataRow["KeyboardValue"]) ?? string.Empty;
                            xPluDataModel.bScalable = Convert.ToBoolean(xDataRow["Scalable"]);
                            xPluDataModel.bAllowDiscount = Convert.ToBoolean(xDataRow["AllowDiscount"]);
                            xPluDataModel.iDiscountPercent = Convert.ToInt32(xDataRow["DiscountPercent"]);
                            xPluDataModel.bScalable = Convert.ToBoolean(xDataRow["AllowNegativeStock"]);
                            xPluDataModel.bAllowDiscount = Convert.ToBoolean(xDataRow["AllowReturn"]);
                            xPluDataModel.iStock = Convert.ToInt32(xDataRow["Stock"]);
                            xPluDataModel.strStockUnit = Convert.ToString(xDataRow["StockUnit"]) ?? string.Empty;
                            xPluDataModel.StockUnitNo = Convert.ToInt32(xDataRow["StockUnitNo"]);
                            xPluDataModel.iFkManufacturerId = Convert.ToInt32(xDataRow["FkPluManufacturerId"]);
                            xPluDataModel.xPluSubGroupDataModel = xGetPluSubGroupById(xPluDataModel.iFkPluSubGroupId);
                            xPluDataModel.xVat = xGetVatByNo(Convert.ToInt32(xDataRow["VatNo"]));
                            xPluDataModel.xListPluBarcodeDataModel = xListGetPluBarcode(xPluDataModel.iId);

                            xListPluDataModel.Add(xPluDataModel);
                        }

                    }
                }

                return xListPluDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public void vSaveCommonPlu(ServiceDataModel.PluStockModel prm_xPluStockModel)
        {
            try
            {
                int iFkPluId = 0;
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format("SELECT FkPluId FROM TablePluBarcode WHERE Barcode='{0}'", prm_xPluStockModel.Barcode));
                iFkPluId = int.Parse(xDataTable.Rows[0]["FkPluId"].ToString());
                if (iFkPluId > 0)
                {
                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format
                    ("UPDATE TablePlu SET Code='{0}', ShortName='{1}', FkVatId={2} where PluId = {3}); SELECT Changes();",
                prm_xPluStockModel.Code,
                prm_xPluStockModel.ShortName,
                prm_xPluStockModel.FkVatId,
                iFkPluId));
                }
                else
                {
                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format
                    ("INSERT INTO TablePlu(Code, ShortName, FkVatId) VALUES('{0}','{1}',{2}); SELECT last_inserted_id();",
                prm_xPluStockModel.Code,
                prm_xPluStockModel.ShortName,
                prm_xPluStockModel.FkVatId));
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vSavePlu(ServiceDataModel.PluModel prm_xPluDataModel, ServiceDataModel.PluBarcodeModel prm_xPluBarcodeDataModel)
        {
            try
            {
                var pluId = 0;
                var query = String.Format(
                    "UPDATE TablePlu SET " +
                    "OldCode = '{0}', " +
                    "ShelfCode = '{1}', " +
                    "Name = '{2}', " +
                    "ShortName = '{3}', " +
                    "Description = '{4}', " +
                    "DescriptionOnScreen = '{5}', " +
                    "DescriptionOnShelf = '{6}', " +
                    "DescriptionOnScale = '{7}', " +
                    "FkPluSubGroupId = {8}, " +
                    "FkVatId = {9}, " +
                    "KeyboardValue = '{10}', " +
                    "Scalable = {11}, " +
                    "AllowDiscount = {12}, " +
                    "DiscountPercent = {13}, " +
                    "AllowNegativeStock = {14}, " +
                    "AllowReturn = {15}, " +
                    "Stock = {16}, " +
                    "StockUnit = '{17}', " +
                    "MinStock = {18}, " +
                    "MaxStock = {19}, " +
                    "FkPluManufacturerId = {20}, " +
                    "VatNo = {22}, " +
                    "Code = '{21}', " +
                    "StockUnitNo = {24} " +
                    "WHERE FkServerId = {23}; Select Changes() ",
                    prm_xPluDataModel.OldCode,
                    prm_xPluDataModel.ShelfCode,
                    prm_xPluDataModel.Name,
                    prm_xPluDataModel.ShortName,
                    prm_xPluDataModel.ShortName,
                    prm_xPluDataModel.ShortName,
                    prm_xPluDataModel.ShortName,
                    prm_xPluDataModel.ShortName,
                    prm_xPluDataModel.FkPluSubGroupId,
                    prm_xPluDataModel.FkVatId,
                    prm_xPluDataModel.KeyboardValue,
                    Convert.ToInt16(prm_xPluDataModel.Scalable),
                    Convert.ToInt16(prm_xPluDataModel.AllowDiscount),
                    prm_xPluDataModel.DiscountPercent,
                    Convert.ToInt16(prm_xPluDataModel.AllowNegativeStock),
                    Convert.ToInt16(prm_xPluDataModel.AllowReturn),
                    prm_xPluDataModel.Stock,
                    prm_xPluDataModel.StockUnit,
                    prm_xPluDataModel.MinStock,
                    prm_xPluDataModel.MaxStock,
                    prm_xPluDataModel.FkPluManufacturerId,
                    prm_xPluDataModel.Code,
                    prm_xPluDataModel.VatNo,
                    prm_xPluDataModel.FkServerId,
                    prm_xPluDataModel.StockUnitNo);

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(query);

                if (xDataTable.Rows[0]["Changes()"].ToString() == "0")
                {
                    query = string.Format
                        ("INSERT INTO TablePlu (Code, OldCode, ShelfCode, Name, ShortName, Description, DescriptionOnScreen, " +
                         "DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, " +
                         "DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId, VatNo, FkServerId, StockUnitNo) " +
                         "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}',{12}," +
                         "{13},{14},{15},{16},{17},{18},{19},'{20}',{21}, {22}, {23},{24}); SELECT last_insert_rowid()",
                            prm_xPluDataModel.Code,
                            prm_xPluDataModel.OldCode,
                            prm_xPluDataModel.ShelfCode,
                            prm_xPluDataModel.Name,
                            prm_xPluDataModel.ShortName,
                            prm_xPluDataModel.ShortName,
                            prm_xPluDataModel.ShortName,
                            prm_xPluDataModel.ShortName,
                            prm_xPluDataModel.ShortName,
                            prm_xPluDataModel.FkPluSubGroupId,
                            prm_xPluDataModel.FkVatId,
                            prm_xPluDataModel.KeyboardValue,
                            Convert.ToInt16(prm_xPluDataModel.Scalable),
                            Convert.ToInt16(prm_xPluDataModel.AllowDiscount),
                            prm_xPluDataModel.DiscountPercent,
                            Convert.ToInt16(prm_xPluDataModel.AllowNegativeStock),
                            Convert.ToInt16(prm_xPluDataModel.AllowReturn),
                            prm_xPluDataModel.Stock,
                            prm_xPluDataModel.MinStock,
                            prm_xPluDataModel.MaxStock,
                            prm_xPluDataModel.StockUnit,
                            prm_xPluDataModel.FkPluManufacturerId,
                            prm_xPluDataModel.VatNo,
                            prm_xPluDataModel.FkServerId,
                            prm_xPluDataModel.StockUnitNo);
                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(query);
                    pluId = Convert.ToInt32(xDataTable.Rows[0]["last_insert_rowid()"]);
                }

                query = string.Format("UPDATE TablePluBarcode SET " +
                                      "Barcode = '{0}', " +
                                      "OldBarcode = '{1}', " +
                                      "FkPluBarcodeDefinitionId = {2}, " +
                                      "PurchasePrice = {3}, " +
                                      "SalePrice = {4} where FkServerId = {5}; Select Changes()",
                                    prm_xPluBarcodeDataModel.Barcode,
                                    prm_xPluBarcodeDataModel.OldBarcode,
                                    prm_xPluBarcodeDataModel.FkPluBarcodeDefinitionId,
                                    prm_xPluBarcodeDataModel.PurchasePrice,
                                    prm_xPluBarcodeDataModel.SalePrice,
                                    prm_xPluBarcodeDataModel.FkServerId);
                xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(query);

                if (xDataTable.Rows[0]["Changes()"].ToString() == "0")
                {
                    query = string.Format(
                            "INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, FkPluBarcodeDefinitionId, " +
                            "PurchasePrice, SalePrice, FkServerId) VALUES({0},'{1}','{2}',{3},{4},{5},{6}); ",
                            pluId,
                            prm_xPluBarcodeDataModel.Barcode,
                            prm_xPluBarcodeDataModel.OldBarcode,
                            prm_xPluBarcodeDataModel.FkPluBarcodeDefinitionId,
                            prm_xPluBarcodeDataModel.PurchasePrice,
                            prm_xPluBarcodeDataModel.SalePrice,
                            prm_xPluBarcodeDataModel.FkServerId);
                    Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteVoidDataTable(query);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public PluSubGroupDataModel xGetPluSubGroupById(int prm_strPluSubGroupId)
        {
            try
            {
                PluSubGroupDataModel xPluSubGroupDataModel = null;

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format("SELECT * FROM TablePluSubGroup WHERE Id={0} ORDER BY Id", prm_strPluSubGroupId));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    DataRow xDataRow = xDataTable.Rows[0];

                    if (xDataRow != null)
                    {
                        xPluSubGroupDataModel = new PluSubGroupDataModel();

                        xPluSubGroupDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                        xPluSubGroupDataModel.iFkPluMainGroupId = Convert.ToInt32(xDataRow["FkPluMainGroupId"]);
                        xPluSubGroupDataModel.iNo = Convert.ToInt32(xDataRow["No"]);
                        xPluSubGroupDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                        xPluSubGroupDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                        xPluSubGroupDataModel.iDiscountPercent = Convert.ToInt32(xDataRow["DiscountPercent"]);
                        xPluSubGroupDataModel.xPluMainGroupDataModel = xGetPluMainGroupById(xPluSubGroupDataModel.iFkPluMainGroupId);
                    }
                }

                return xPluSubGroupDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public ServiceDataModel.PluSubGroupModel GetFirstSubGroupModel()
        {
            try
            {
                var query = string.Format("select * from TablePluSubGroup");
                var dataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(query);
                var sub = dataTable.Rows[0].ToModelItem<ServiceDataModel.PluSubGroupModel>();
                return sub;
            }
            catch (Exception)
            {
                return new ServiceDataModel.PluSubGroupModel();
            }
        }

        public List<PluSubGroupDataModel> xListGetPluSubGroup(int prm_iId)
        {
            try
            {
                List<PluSubGroupDataModel> xListPluSubGroupDataModel = null;

                if (xListPluSubGroupDataModel == null)
                    xListPluSubGroupDataModel = new List<PluSubGroupDataModel>();

                return xListPluSubGroupDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public PluMainGroupDataModel xGetPluMainGroupById(int prm_strPluMainGroupId)
        {
            try
            {
                PluMainGroupDataModel xPluMainGroupDataModel = null;

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format("SELECT * FROM TablePluMainGroup WHERE Id={0} ORDER BY Id", prm_strPluMainGroupId));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    DataRow xDataRow = xDataTable.Rows[0];

                    if (xDataRow != null)
                    {
                        xPluMainGroupDataModel = new PluMainGroupDataModel();

                        xPluMainGroupDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                        xPluMainGroupDataModel.iNo = Convert.ToInt32(xDataRow["No"]);
                        xPluMainGroupDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                        xPluMainGroupDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                        xPluMainGroupDataModel.iDiscountPercent = Convert.ToInt32(xDataRow["DiscountPercent"]);
                    }
                }

                return xPluMainGroupDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<PluMainGroupDataModel> xListGetPluMainGroups()
        {
            return xListGetPluMainGroup(-1);
        }

        public List<PluMainGroupDataModel> xListGetPluMainGroup(int prm_iId)
        {
            try
            {
                List<PluMainGroupDataModel> xListPluMainGroupDataModel = null;

                if (xListPluMainGroupDataModel == null)
                    xListPluMainGroupDataModel = new List<PluMainGroupDataModel>();

                return xListPluMainGroupDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public int iGetPluStockByCode(int prm_iPluCode)
        {
            return 0;
        }

        public bool bSetPluStockByCode(string prm_strPluCode, int prm_iStock)
        {
            bool bReturnValue = false;
            try
            {

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format("UPDATE TablePlu SET Stock = {0} WHERE Code='{1}'", prm_iStock, prm_strPluCode));
                bReturnValue = true;
            }
            catch (Exception)
            {

            }

            return bReturnValue;

        }

        public int iGetPluStockByBarcode(string prm_strPluBarcode)
        {
            return 0;
        }

        public bool bSetPluStockByBarcode(string prm_strPluBarcode, int prm_iStock)
        {
            return false;
        }

        public void vSavePluMainGroup(PluMainGroupDataModel prm_xPluMainGroupDataModel)
        {
            bool returnvalue = false;
            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format("INSERT INTO TablePluMainGroup VALUES({0},{1},{2},{3},{4}); SELECT last_insert_rowid()",
                    prm_xPluMainGroupDataModel.iNo,
                    prm_xPluMainGroupDataModel.iDiscountPercent,
                    prm_xPluMainGroupDataModel.strName,
                    prm_xPluMainGroupDataModel.strDescription,
                    prm_xPluMainGroupDataModel.decMaxPrice));

                if (int.Parse(xDataTable.Rows[0]["last_insert_rowid()"].ToString()) > 0)
                {
                    returnvalue = true;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

        }

        public void vSavePluGroup(ServiceDataModel.PluMainGroupModel prm_xPluMainGroupDataModel, List<ServiceDataModel.PluSubGroupModel> prm_xPluSubGroupDataModel)
        {
            try
            {
                //var query = string.Format("UPDATE TablePluMainGroup SET " +
                //    "DiscountPercent = {0}, " +
                //    "Name = '{1}', " +
                //    "Description = '{2}', " +
                //    "MaxPrice = {3} " +
                //    "where No = {4}; Select Changes() ",
                //    prm_xPluMainGroupDataModel.DiscountPercent,
                //    prm_xPluMainGroupDataModel.Name,
                //    prm_xPluMainGroupDataModel.Description,
                //    prm_xPluMainGroupDataModel.MaxPrice,
                //    prm_xPluMainGroupDataModel.No);
                //DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(query);

                //if (xDataTable.Rows[0]["Changes()"].ToString() == "0")
                //{
                var query = string.Format("INSERT INTO TablePluMainGroup (No, DiscountPercent, Name, Description, MaxPrice) " +
                    "VALUES({0},{1},'{2}','{3}',{4}); SELECT last_insert_rowid()",
                    prm_xPluMainGroupDataModel.No,
                    prm_xPluMainGroupDataModel.DiscountPercent,
                    prm_xPluMainGroupDataModel.Name,
                    prm_xPluMainGroupDataModel.Description,
                    prm_xPluMainGroupDataModel.MaxPrice);
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(query);

                var mainGrupId = Convert.ToInt16(xDataTable.Rows[0]["last_insert_rowid()"]);
                foreach (ServiceDataModel.PluSubGroupModel subGroup in prm_xPluSubGroupDataModel)
                {
                    query = string.Format("INSERT INTO TablePluSubGroup (FkPluMainGroupId, No, DiscountPercent, Name, Description) " +
                        "VALUES({0},{1},{2},'{3}','{4}');",
                        mainGrupId,
                        subGroup.No,
                        subGroup.DiscountPercent,
                        subGroup.Name,
                        subGroup.Description);
                    Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteVoidDataTable(query);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

        }

        public void vSavePluSubGroup(PluSubGroupDataModel prm_xPluSubGroupDataModel)
        {
            bool returnvalue = false;
            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format("INSERT INTO TablePluSubGroup VALUES({0},{1},{2},{3},{4}); SELECT last_insert_rowid()",
                    prm_xPluSubGroupDataModel.iFkPluMainGroupId,
                    prm_xPluSubGroupDataModel.iNo,
                    prm_xPluSubGroupDataModel.iDiscountPercent,
                    prm_xPluSubGroupDataModel.strName,
                    prm_xPluSubGroupDataModel.strDescription));

                if (int.Parse(xDataTable.Rows[0]["last_insert_rowid()"].ToString()) > 0)
                {
                    returnvalue = true;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        //public void vSavePluSubGroup(ServiceDataModel.PluSubGroupModel prm_xPluSubGroupDataModel)
        //{
        //    try
        //    {
        //        //var query = string.Format("UPDATE TablePluSubGroup SET " +
        //        //    "FkPluMainGroupId = {0}, " +
        //        //    "DiscountPercent = {1}, " +
        //        //    "Name = {2}, " +
        //        //    "Description = {3} where No = {4}; Select Changes() ",
        //        //    prm_xPluSubGroupDataModel.FkPluMainGroupId,
        //        //    prm_xPluSubGroupDataModel.DiscountPercent,
        //        //    prm_xPluSubGroupDataModel.Name,
        //        //    prm_xPluSubGroupDataModel.Description,
        //        //    prm_xPluSubGroupDataModel.No);
        //        //DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(query);

        //        //if (xDataTable.Rows[0]["Changes()"].ToString() == "0")
        //        //{
        //        var query = string.Format("INSERT INTO TablePluSubGroup (FkPluMainGroupId, No, DiscountPercent, Name, Description) " +
        //            "VALUES({0},{1},{2},'{3}','{4}');",
        //            prm_xPluSubGroupDataModel.FkPluMainGroupId,
        //            prm_xPluSubGroupDataModel.No,
        //            prm_xPluSubGroupDataModel.DiscountPercent,
        //            prm_xPluSubGroupDataModel.Name,
        //            prm_xPluSubGroupDataModel.Description);
        //        Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteVoidDataTable(query);
        //        //}
        //    }
        //    catch (Exception xException)
        //    {
        //        xException.strTraceError();
        //    }
        //}

        public void vSavePluManufacturer(ServiceDataModel.PluManufacturerModel prm_xPluManufacturerModel)
        {
            try
            {

                var query = string.Format("INSERT INTO TablePluManufacturer (Id, Name) VALUES({0},'{1}');",
                       prm_xPluManufacturerModel.Id,
                       prm_xPluManufacturerModel.Name);
                Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteVoidDataTable(query);
                //}
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

        }
        public void vSavePluManufacturerList(PluManufacturerDataModel prm_xPluManufacturerDataModel)
        {
            bool returnvalue = false;
            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(string.Format("INSERT INTO TablePluManufacturer (Id, Name) VALUES({0},'{1}')" +
                                                                                                                                      "; SELECT last_insert_rowid()",
                    prm_xPluManufacturerDataModel.strName));

                if (int.Parse(xDataTable.Rows[0]["last_insert_rowid()"].ToString()) > 0)
                {
                    returnvalue = true;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

        }

     

        public List<StockDataModel> xGetPluStock()
        {
            List<StockDataModel> xPluDataModelList = new List<StockDataModel>();
            DataGridViewComboBoxColumn dcombo = new DataGridViewComboBoxColumn();
            try
            {
                var query = string.Format("SELECT tp.Id as PluId, tpb.Id as BarcodeId, tp.ShortName, tpb.Barcode, tp.Stock, tp.StockUnit, tp.StockUnitNo, tpb.PurchasePrice, tp.MinStock, tp.MaxStock, tpb.SalePrice, tp.Code, tv.Rate, tv.No FROM TablePlu as tp inner join TablePluBarcode as tpb on tp.Id = tpb.FkPluId inner join TableVat as tv on tv.No = tp.VatNo");
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(query);
                StockDataModel xPluDataModel = null;

                if (xDataTable != null)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        xPluDataModel = new StockDataModel();
                        xPluDataModel.PluId = Convert.ToInt32(xDataRow["PluId"]);
                        xPluDataModel.BarcodeId = Convert.ToInt32(xDataRow["BarcodeId"]);
                        xPluDataModel.ShortName = Convert.ToString(xDataRow["ShortName"]) ?? string.Empty;
                        xPluDataModel.Barcode = Convert.ToString(xDataRow["Barcode"]) ?? string.Empty;
                        xPluDataModel.Stock = Convert.ToInt32(xDataRow["Stock"]);
                        xPluDataModel.StockUnitNo = Convert.ToInt32(xDataRow["StockUnitNo"]);
                        xPluDataModel.PurchasePrice = Convert.ToDecimal(xDataRow["PurchasePrice"]) / 100;
                        xPluDataModel.MinStock = Convert.ToInt32(xDataRow["MinStock"]);
                        xPluDataModel.MaxStock = Convert.ToInt32(xDataRow["MaxStock"]);
                        xPluDataModel.SalePrice = Convert.ToDecimal(xDataRow["SalePrice"]) / 100;
                        xPluDataModel.Code = Convert.ToString(xDataRow["Code"]) ?? string.Empty;
                        xPluDataModel.No = Convert.ToInt32(xDataRow["No"]);
                        xPluDataModel.IncomewithStock = Convert.ToInt64((xPluDataModel.SalePrice - (xPluDataModel.SalePrice * Convert.ToInt32(xDataRow["Rate"]) / 100) - xPluDataModel.PurchasePrice) * xPluDataModel.Stock);
                        xPluDataModelList.Add(xPluDataModel);
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xPluDataModelList;
        }

        public List<StockDataModel> xGetSearchPluStock(string prm_xBarcode)
        {
            List<StockDataModel> xSearchPluDataModelList = new List<StockDataModel>();

            try
            {
                var query = string.Format("SELECT tp.Id as PluId, tpb.Id as BarcodeId, tp.ShortName, tpb.Barcode, tp.Stock, tp.StockUnitNo, tpb.PurchasePrice, tp.MinStock, tp.MaxStock, tpb.SalePrice, tp.Code, tv.No, tv.Rate FROM TablePlu as tp inner join TablePluBarcode as tpb on tp.Id = tpb.FkPluId inner join TableVat as tv on tv.No = tp.VatNo where tpb.Barcode like '%{0}%' ", prm_xBarcode);
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(query);
                StockDataModel xPluDataModel;

                if (xDataTable != null)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        xPluDataModel = new StockDataModel();
                        xPluDataModel.PluId = Convert.ToInt32(xDataRow["PluId"]);
                        xPluDataModel.BarcodeId = Convert.ToInt32(xDataRow["BarcodeId"]);
                        xPluDataModel.ShortName = Convert.ToString(xDataRow["ShortName"]) ?? string.Empty;
                        xPluDataModel.Barcode = Convert.ToString(xDataRow["Barcode"]) ?? string.Empty;
                        xPluDataModel.Stock = Convert.ToInt32(xDataRow["Stock"]);
                        xPluDataModel.StockUnitNo = Convert.ToInt32(xDataRow["StockUnitNo"]);
                        xPluDataModel.PurchasePrice = Convert.ToInt32(xDataRow["PurchasePrice"]) / 100;
                        xPluDataModel.MinStock = Convert.ToInt32(xDataRow["MinStock"]);
                        xPluDataModel.MaxStock = Convert.ToInt32(xDataRow["MaxStock"]);
                        xPluDataModel.SalePrice = Convert.ToInt32(xDataRow["SalePrice"]) / 100;
                        xPluDataModel.Code = Convert.ToString(xDataRow["Code"]) ?? string.Empty;
                        xPluDataModel.No = Convert.ToInt32(xDataRow["No"]);
                        xPluDataModel.IncomewithStock = Convert.ToInt32((xPluDataModel.SalePrice - (xPluDataModel.SalePrice * Convert.ToInt32(xDataRow["Rate"]) / 100) - xPluDataModel.PurchasePrice) * xPluDataModel.Stock);

                        xSearchPluDataModelList.Add(xPluDataModel);
                    }
                }

            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return xSearchPluDataModelList;
        }

        public List<StockDataModel> SavePluStock(List<StockDataModel> updatedStockList)
        {
            try
            {
                if (updatedStockList == null)
                {
                    throw new ArgumentException("StockListCanNotBeNull!");
                }

                var barcodeIsNull = updatedStockList.Exists(p => string.IsNullOrEmpty(p.Barcode));
                if (barcodeIsNull)
                {
                    throw new ArgumentException("BarcodeCannotBeNull!");
                }
                foreach (var updatedStock in updatedStockList)
                {
                    if (updatedStock.PluId == 0) // insert 
                    {
                        var subGroupId = Dao.xGetInstance().GetFirstSubGroupModel().No;
                        var queryTablePlu =
                            string.Format(
                                "INSERT INTO TablePlu (Name, ShortName, Description, DescriptionOnScreen, DescriptionOnShelf, DescriptionOnScale, Stock, StockUnitNo,  MinStock,   MaxStock, Code, VatNo, FkPluSubGroupId) " +
                            "VALUES('{0}','{0}','{0}','{0}','{0}','{0}','{1}','{2}','{3}','{4}','{5}',{6},{7}); SELECT last_insert_rowid() as FkPluId ", 
                            updatedStock.ShortName, updatedStock.Stock, updatedStock.StockUnitNo, updatedStock.MinStock, updatedStock.MaxStock, updatedStock.Code, updatedStock.No, subGroupId);
                        DataTable dataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(queryTablePlu);
                        var pluId = dataTable.Rows[0]["FkPluId"];
                        if (pluId == null)
                        {
                            throw new ArgumentException("PluId cannot be null!");
                        }

                        updatedStock.PluId = Convert.ToInt32(pluId);

                        var queryTableBarcode = string.Format("INSERT INTO TablePluBarcode (FkPluId,  Barcode, PurchasePrice, SalePrice ) " +
                                                              "VALUES({0}, '{1}', {2}, {3}); SELECT last_insert_rowid() as FkPluBarcodeId ", 
                                                              pluId, updatedStock.Barcode, updatedStock.PurchasePrice, updatedStock.SalePrice);
                        dataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteDataTable(queryTableBarcode);
                        updatedStock.BarcodeId = Convert.ToInt32(dataTable.Rows[0]["FkPluBarcodeId"]);
                    }
                    else //update
                    {
                        var queryForPlu = string.Format("UPDATE TablePlu SET " +
                                                        "Name = '{0}', " +
                                                        "ShortName = '{0}', " +
                                                        "Description = '{0}', " +
                                                        "DescriptionOnScreen = '{0}', " +
                                                        "DescriptionOnShelf = '{0}', " +
                                                        "DescriptionOnScale = '{0}', " +
                                                        "Stock = {1}, " +
                                                        "StockUnitNo = '{2}', " +
                                                        "MinStock = {3}, " +
                                                        "MaxStock = {4}, " +
                                                        "Code = '{5}', " +
                                                        "VatNo = {7} " +
                                                        "where Id = {6};",
                                                        updatedStock.ShortName,
                                                        updatedStock.Stock,
                                                        updatedStock.StockUnitNo,
                                                        updatedStock.MinStock,
                                                        updatedStock.MaxStock,
                                                        updatedStock.Code,
                                                        updatedStock.PluId,
                                                        updatedStock.No);

                        var queryForPluBarcode = string.Format("Update TablePluBarcode set " +
                            "Barcode = '{0}'," +
                            "PurchasePrice = {1}, " +
                            "SalePrice = {2} " +
                            "where Id = {3}",
                            updatedStock.Barcode,
                            Convert.ToInt32(updatedStock.PurchasePrice),
                            Convert.ToInt32(updatedStock.SalePrice),
                            updatedStock.BarcodeId);

                        Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteVoidDataTable(queryForPlu);
                        Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteVoidDataTable(queryForPluBarcode);
                    }
                }
                return updatedStockList;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return new List<StockDataModel>();
            }
        }

        public void UpdatePluForSendServer(ServiceDataModel.PluListSaveResponseModel pluListSaveResponse)
        {
            try
            {
                foreach (var plu in pluListSaveResponse.PluList)
                {
                    var query = string.Format("UPDATE TablePlu Set FkServerId = '{0}' where Id = {1}", plu.FkServerId, plu.PluId);
                    Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteVoidDataTable(query);

                    query = string.Format("UPDATE TablePluBarcode Set FkServerId = '{0}' where FkPluId = {1}", plu.FkServerBarcodeId, plu.PluId);
                    Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileNameAndPath).xExecuteVoidDataTable(query);               }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }


        //public void vUpdatePluStock(ServiceDataModel.PluStockModel prm_xPluStockModel)
        //{
        //    try
        //    {
        //        var query = String.Format(
        //            "UPDATE TablePlu SET " +
        //            "MinStock = '{0}', " +
        //            "PurchasePrice = '{1}', " +
        //            "SalePrice = '{2}', " +
        //            "ShortName = '{3}', " +
        //            "Stock = '{4}', " +
        //            "StockUnit = {5} " +
        //            "WHERE Code = '{6}'; Select Changes() ",
        //            prm_xPluStockModel.MinStock,
        //            prm_xPluStockModel.PurchasePrice,
        //            prm_xPluStockModel.SalePrice,
        //            prm_xPluStockModel.ShortName,
        //            prm_xPluStockModel.Stock,
        //            prm_xPluStockModel.StockUnit,
        //            prm_xPluStockModel.Code);

        //        DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(query);

        //        if (xDataTable.Rows[0]["Changes()"].ToString() != "0")
        //        {
        //            query = string.Format("UPDATE TablePluBarcode SET " +
        //            "Barcode = '{0}', " +
        //            "OldBarcode = '{1}', " +
        //            "FkPluBarcodeDefinitionId = {2}, " +
        //            "PurchasePrice = {3}, " +
        //            "SalePrice = {4} where FkPluId in (select Id from TablePlu where Code = {5})",
        //            prm_xPluStockModel.Barcode,
        //            prm_xPluStockModel.OldBarcode,
        //            prm_xPluStockModel.FkPluBarcodeDefinitionId,
        //            prm_xPluStockModel.PurchasePrice,
        //            prm_xPluBarcodeDataModel.SalePrice,
        //            prm_xPluDataModel.Code);
        //            Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteVoidDataTable(query);
        //        }
        //        else
        //        {
        //            query = string.Format
        //                ("INSERT INTO TablePlu (Code, OldCode, ShelfCode, Name, ShortName, Description, DescriptionOnScreen, " +
        //                "DescriptionOnShelf, DescriptionOnScale, FkPluSubGroupId, FkVatId, KeyboardValue, Scalable, AllowDiscount, " +
        //                "DiscountPercent, AllowNegativeStock, AllowReturn, Stock, MinStock, MaxStock, StockUnit, FkPluManufacturerId) " +
        //                "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}',{12}," +
        //                "{13},{14},{15},{16},{17},{18},{19},'{20}',{21}); SELECT last_insert_rowid()",
        //            prm_xPluDataModel.Code,
        //            prm_xPluDataModel.OldCode,
        //            prm_xPluDataModel.ShelfCode,
        //            prm_xPluDataModel.Name,
        //            prm_xPluDataModel.ShortName,
        //            prm_xPluDataModel.ShortName,
        //            prm_xPluDataModel.ShortName,
        //            prm_xPluDataModel.ShortName,
        //            prm_xPluDataModel.ShortName,
        //            prm_xPluDataModel.FkPluSubGroupId,
        //            prm_xPluDataModel.FkVatId,
        //            prm_xPluDataModel.KeyboardValue,
        //            Convert.ToInt16(prm_xPluDataModel.Scalable),
        //            Convert.ToInt16(prm_xPluDataModel.AllowDiscount),
        //            prm_xPluDataModel.DiscountPercent,
        //            Convert.ToInt16(prm_xPluDataModel.AllowNegativeStock),
        //            Convert.ToInt16(prm_xPluDataModel.AllowReturn),
        //            prm_xPluDataModel.Stock,
        //            prm_xPluDataModel.MinStock,
        //            prm_xPluDataModel.MaxStock,
        //            prm_xPluDataModel.StockUnit,
        //            prm_xPluDataModel.FkPluManufacturerId);
        //            xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(query);

        //            query = string.Format("INSERT INTO TablePluBarcode (FkPluId, Barcode, OldBarcode, FkPluBarcodeDefinitionId, " +
        //                "PurchasePrice, SalePrice) VALUES({0},'{1}','{2}',{3},{4},{5}); ",
        //            Convert.ToInt32(xDataTable.Rows[0]["last_insert_rowid()"]),
        //            prm_xPluBarcodeDataModel.Barcode,
        //            prm_xPluBarcodeDataModel.OldBarcode,
        //            prm_xPluBarcodeDataModel.FkPluBarcodeDefinitionId,
        //            prm_xPluBarcodeDataModel.PurchasePrice,
        //            prm_xPluBarcodeDataModel.SalePrice);
        //            Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteVoidDataTable(query);
        //        }
        //    }
        //    catch (Exception xException)
        //    {
        //        xException.strTraceError();
        //    }
        //}

    }
}
