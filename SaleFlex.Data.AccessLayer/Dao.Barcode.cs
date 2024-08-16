using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;
using System.Data;
using SaleFlex.Data.SQLite;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public PluBarcodeDataModel xBarcodeDataModel { get; set; }

        public List<PluBarcodeDataModel> xListGetBarcode()
        {
            return xListGetBarcode(string.Empty);
        }

        public List<PluBarcodeDataModel> xListGetBarcode(string prm_strBarcodeStartingNumber)
        {
            try
            {
                List<PluBarcodeDataModel> xListBarcodeDataModel = null;

                if (xListBarcodeDataModel == null)
                    xListBarcodeDataModel = new List<PluBarcodeDataModel>();

                return xListBarcodeDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public void vSavePluBarcode(PluBarcodeDataModel prm_xPluBarcodeDataModel)
        {
            bool returnvalue = false;
            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseStockFileName).xExecuteDataTable(string.Format("INSERT INTO TablePluBarcode VALUES({0},{1},{2},{3},{4},{5}); SELECT last_insert_rowid()",
                    prm_xPluBarcodeDataModel.iFkPluId,
                    prm_xPluBarcodeDataModel.strBarcode,
                    prm_xPluBarcodeDataModel.strOldBarcode,
                    prm_xPluBarcodeDataModel.iFkPluBarcodeDefinitionId,
                    prm_xPluBarcodeDataModel.decPurchasePrice,
                    prm_xPluBarcodeDataModel.decSalePrice));

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

        public void vSavePluBarcode(ServiceDataModel.PluBarcodeModel prm_xPluBarcodeDataModel)
        {
            try
            {
                var query = string.Format("UPDATE TablePluBarcode " +
                    "Barcode = {0}, OldBarcode = {1}, FkPluBarcodeDefinitionId = {2}, PurchasePrice = {3}, SalePrice = {4}; Select Changes()",
                    prm_xPluBarcodeDataModel.FkPluId,
                    prm_xPluBarcodeDataModel.Barcode,
                    prm_xPluBarcodeDataModel.OldBarcode,
                    prm_xPluBarcodeDataModel.FkPluBarcodeDefinitionId,
                    prm_xPluBarcodeDataModel.PurchasePrice,
                    prm_xPluBarcodeDataModel.SalePrice);
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseStockFileName).xExecuteDataTable(query);

                if (xDataTable.Rows[0]["Changes()"].ToString() == "0")
                {
                    query = string.Format("INSERT INTO TablePluBarcode VALUES({0},{1},{2},{3},{4},{5}); ",
                    prm_xPluBarcodeDataModel.FkPluId,
                    prm_xPluBarcodeDataModel.Barcode,
                    prm_xPluBarcodeDataModel.OldBarcode,
                    prm_xPluBarcodeDataModel.FkPluBarcodeDefinitionId,
                    prm_xPluBarcodeDataModel.PurchasePrice,
                    prm_xPluBarcodeDataModel.SalePrice);
                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseStockFileName).xExecuteDataTable(query);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public bool bSaveBarcodeDefinition(PluBarcodeDataModel prm_xBarcodeDataModel)
        {
            try
            {
                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }

        }
    }
}
