using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;
using SaleFlex.Data.SQLite;
using System.Data;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public DepartmentDataModel xGetDepartmentByNo(int prm_iDepartmentNo)
        {
            List<DepartmentDataModel> xListDepartmentDataModel = xListGetDepartments(prm_iDepartmentNo);

            if (xListDepartmentDataModel == null)
                return null;

            return xListDepartmentDataModel.First();
        }

        public List<DepartmentDataModel> xListGetDepartments()
        {
            return xListGetDepartments(0);
        }

        public List<DepartmentDataModel> xListGetDepartments(int prm_iDepartmentNo)
        {
            try
            {
                List<DepartmentDataModel> xListDepartmentDataModel = null;

                DataTable xDataTable = null;

                if (prm_iDepartmentNo > 0)
                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable("SELECT * FROM TableDepartment ORDER BY Id");
                else
                    xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable($"SELECT * FROM TableDepartment WHERE No = {prm_iDepartmentNo} ORDER BY Id");

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListDepartmentDataModel == null)
                            xListDepartmentDataModel = new List<DepartmentDataModel>();

                        DepartmentDataModel xDepartmentDataModel = new DepartmentDataModel();
                        xDepartmentDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                        xDepartmentDataModel.iNo = Convert.ToInt32(xDataRow["No"]);
                        xDepartmentDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                        xDepartmentDataModel.lDefaultQuantity = Convert.ToInt32(xDataRow["DefaultQuantity"]);
                        xDepartmentDataModel.lDefaultPrice = Convert.ToInt32(xDataRow["DefaultPrice"]);
                        xDepartmentDataModel.lMaxPrice = Convert.ToInt32(xDataRow["MaxPrice"]);
                        xDepartmentDataModel.xVat = Dao.xGetInstance().xGetVatByNo(Convert.ToInt32(xDataRow["FkVatId"]));
                        xListDepartmentDataModel.Add(xDepartmentDataModel);
                    }
                }

                return xListDepartmentDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveDepartment(DepartmentDataModel prm_xDepartmentDataModel)
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
