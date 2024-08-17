using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public VatDataModel xGetVatById(int prm_strVatId)
        {
            try
            {
                VatDataModel xVatDataModel = null;

                string strCommandText = string.Format("SELECT * FROM TableVat WHERE Id={0} ORDER BY No", prm_strVatId);

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(strCommandText);
                

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    DataRow xDataRow = xDataTable.Rows[0];

                    if (xDataRow != null)
                    {
                        xVatDataModel = new VatDataModel();

                        xVatDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                        xVatDataModel.iNo = Convert.ToInt32(xDataRow["No"]);
                        xVatDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                        xVatDataModel.iRate = Convert.ToInt32(xDataRow["Rate"]);
                        xVatDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                    }
                }

                return xVatDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public VatDataModel xGetVatByNo(int prm_strVatNo)
        {
            try
            {
                VatDataModel xVatDataModel = null;

                string strCommandText = string.Format("SELECT * FROM TableVat WHERE No = {0} ORDER BY No", prm_strVatNo);

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(strCommandText);


                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    DataRow xDataRow = xDataTable.Rows[0];

                    if (xDataRow != null)
                    {
                        xVatDataModel = new VatDataModel();

                        xVatDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                        xVatDataModel.iNo = Convert.ToInt32(xDataRow["No"]);
                        xVatDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                        xVatDataModel.iRate = Convert.ToInt32(xDataRow["Rate"]);
                        xVatDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                    }
                }

                return xVatDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<VatDataModel> xListGetVats()
        {
            try
            {
                List<VatDataModel> vatList = new List<VatDataModel>();
                VatDataModel xVatDataModel = null;

                string strCommandText = string.Format("SELECT * FROM TableVat ORDER BY No");

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(strCommandText);

                if (xDataTable != null)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        xVatDataModel = new VatDataModel();

                        xVatDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                        xVatDataModel.iNo = Convert.ToInt32(xDataRow["No"]);
                        xVatDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                        xVatDataModel.iRate = Convert.ToInt32(xDataRow["Rate"]);
                        xVatDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;

                        vatList.Add(xVatDataModel);
                    }
                }
                return vatList;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<ServiceDataModel.VatModel> GetVatListForCombo()
        {
            try
            {
                List<ServiceDataModel.VatModel> vatList = new List<ServiceDataModel.VatModel>();
                ServiceDataModel.VatModel vat;

                var query = string.Format("SELECT No, Rate FROM TableVat ORDER BY No");

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(query);

                if (xDataTable != null)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        vat = new ServiceDataModel.VatModel();

                        vat.No = Convert.ToInt32(xDataRow["No"]);
                        vat.Rate = Convert.ToInt32(xDataRow["Rate"]);

                        vatList.Add(vat);
                    }
                }
                return vatList;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return new List<ServiceDataModel.VatModel>();
            }
        }

        public List<VatDataModel> xListGetVats(int prm_iVatNo)
        {
            try
            {
                List<VatDataModel> xListVatDataModel = null;

                if (xListVatDataModel == null)
                    xListVatDataModel = new List<VatDataModel>();

                return xListVatDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public void vSaveVat(VatDataModel prm_xVatDataModel)
        {
            bool returnvalue = false;
            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(string.Format("INSERT INTO TableVat VALUES({0},{1},{2},{3},{4}); SELECT last_insert_rowid()",
                    prm_xVatDataModel.iNo,
                    prm_xVatDataModel.strName,
                    prm_xVatDataModel.iRate,
                    prm_xVatDataModel.strDescription));

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

        public void vSaveVat(ServiceDataModel.VatModel prm_xVatModel)
        {
            try
            {
                //var query = string.Format("UPDATE TableVat SET " +
                //    "No = {0}, " +
                //    "Rate = {1}, " +
                //    "Description = '{2}' where Name = '{3}';  Select Changes() ",
                //    prm_xVatModel.No,
                //    prm_xVatModel.Rate,
                //    prm_xVatModel.Description,
                //    prm_xVatModel.Name);
                //DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteDataTable(query);

                //if (xDataTable.Rows[0]["Changes()"].ToString() == "0")
                //{
                var query = string.Format("INSERT INTO TableVat (No, Name, Rate, Description) VALUES({0},'{1}',{2},'{3}');",
                       prm_xVatModel.No,
                       prm_xVatModel.Name,
                       prm_xVatModel.Rate,
                       prm_xVatModel.Description);
                Dbo.xGetInstance(CommonProperty.prop_strDatabaseProductsFileName).xExecuteVoidDataTable(query);
                //}
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

        }
    
    

    }
}
