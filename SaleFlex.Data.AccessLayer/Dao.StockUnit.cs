using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;


namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public StockUnitDataModel xGetStockUnitById(int prm_iStockUnitId)
        {
            try
            {
                StockUnitDataModel xStockUnitDataModel = null;

                string strCommandText = string.Format("SELECT * FROM TableStockUnit WHERE StockUnitId={0} ORDER BY No", prm_iStockUnitId);

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(strCommandText);


                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    DataRow xDataRow = xDataTable.Rows[0];

                    if (xDataRow != null)
                    {
                        xStockUnitDataModel = new StockUnitDataModel();

                        xStockUnitDataModel.StockUnitId = Convert.ToInt32(xDataRow["StockUnitId"]);
                        xStockUnitDataModel.No = Convert.ToInt32(xDataRow["No"]);
                        xStockUnitDataModel.Name = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                        xStockUnitDataModel.Description = Convert.ToString(xDataRow["Description"]);
                        xStockUnitDataModel.Coefficient = Convert.ToInt32(xDataRow["Coefficient"]);
                    }
                }

                return xStockUnitDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public StockUnitDataModel xGetStockUnitByNo(int prm_iStockUnitNo)
        {
            try
            {
                StockUnitDataModel xStockUnitDataModel = null;

                string strCommandText = string.Format("SELECT * FROM TableStockUnit WHERE [No]={0} ORDER BY No", prm_iStockUnitNo);

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(strCommandText);


                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    DataRow xDataRow = xDataTable.Rows[0];

                    if (xDataRow != null)
                    {
                        xStockUnitDataModel = new StockUnitDataModel();

                        xStockUnitDataModel.StockUnitId = Convert.ToInt32(xDataRow["StockUnitId"]);
                        xStockUnitDataModel.No = Convert.ToInt32(xDataRow["No"]);
                        xStockUnitDataModel.Name = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                        xStockUnitDataModel.Description = Convert.ToString(xDataRow["Description"]);
                        xStockUnitDataModel.Coefficient = Convert.ToInt32(xDataRow["Coefficient"]);
                    }
                }

                return xStockUnitDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<StockUnitDataModel> xListGetStockUnit()
        {
            try
            {
                List<StockUnitDataModel> xStockUnitList = new List<StockUnitDataModel>();
                StockUnitDataModel xStockUnitDataModel = null;

                string strCommandText = string.Format("SELECT * FROM TableStockUnit ORDER BY No");

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(strCommandText);

                if (xDataTable != null)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        xStockUnitDataModel = new StockUnitDataModel();

                        xStockUnitDataModel.StockUnitId = Convert.ToInt32(xDataRow["StockUnitId"]);
                        xStockUnitDataModel.No = Convert.ToInt32(xDataRow["No"]);
                        xStockUnitDataModel.Name = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                        xStockUnitDataModel.Description = Convert.ToString(xDataRow["Description"]);
                        xStockUnitDataModel.Coefficient = Convert.ToInt32(xDataRow["Coefficient"]);

                        xStockUnitList.Add(xStockUnitDataModel);
                    }
                }
                return xStockUnitList;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public void vSaveStockUnit(ServiceDataModel.StockUnitModel prm_xStockUnitModel)
        {
            try
            {

                var query = string.Format("INSERT INTO TableStockUnit (No, Name, Description, Coefficient) VALUES({0},'{1}','{2}',{3});",
                       prm_xStockUnitModel.No,
                       prm_xStockUnitModel.Name,
                       prm_xStockUnitModel.Description,
                       prm_xStockUnitModel.Coefficient);
                Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteVoidDataTable(query);
                //}
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

        }
        public List<StockUnitDataModel> xListGetStockUnits(int prm_iStockUnitNo)
        {
            try
            {
                List<StockUnitDataModel> xListStockUnitDataModel = null;

                if (xListStockUnitDataModel == null)
                    xListStockUnitDataModel = new List<StockUnitDataModel>();

                return xListStockUnitDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<ServiceDataModel.StockUnitModel> GetStockUnitListForCombo()
        {
            try
            {
                List<ServiceDataModel.StockUnitModel> stockUnitList = new List<ServiceDataModel.StockUnitModel>();
                ServiceDataModel.StockUnitModel stockUnit;

                var query = string.Format("SELECT No, Name FROM TableStockUnit ORDER BY No");

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(query);

                if (xDataTable != null)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        stockUnit = new ServiceDataModel.StockUnitModel();

                        stockUnit.No = Convert.ToInt32(xDataRow["No"]);
                        stockUnit.Name = xDataRow["Name"].ToString();

                        stockUnitList.Add(stockUnit);
                    }
                }
                return stockUnitList;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return new List<ServiceDataModel.StockUnitModel>();
            }
        }

    }
}
