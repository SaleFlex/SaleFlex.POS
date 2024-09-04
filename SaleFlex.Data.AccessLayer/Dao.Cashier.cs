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
        public List<CashierDataModel> xListGetCashiers()
        {
            try
            {
                List<CashierDataModel> xListCashierDataModel = null;

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable("SELECT * FROM TableCashier ORDER BY Id");

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListCashierDataModel == null)
                            xListCashierDataModel = new List<CashierDataModel>();

                        if (xDataRow != null)
                        {
                            CashierDataModel xCashierDataModel = new CashierDataModel();

                            xCashierDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xCashierDataModel.iNo = Convert.ToInt32(xDataRow["No"]);
                            xCashierDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                            xCashierDataModel.strLastName = Convert.ToString(xDataRow["LastName"]) ?? string.Empty;
                            xCashierDataModel.strPassword = Convert.ToString(xDataRow["Password"]) ?? string.Empty;
                            xCashierDataModel.strIdentityNumber = Convert.ToString(xDataRow["IdentityNumber"]) ?? string.Empty;
                            xCashierDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                            xCashierDataModel.bIsAdministrator = Convert.ToBoolean(xDataRow["IsAdministrator"]);

                            xListCashierDataModel.Add(xCashierDataModel);
                        }

                    }
                }

                return xListCashierDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<CashierDataModel> xListGetCashier(int prm_iCashierNo, string prm_strCashierName, string prm_strCashierLastName)
        {
            try
            {
                List<CashierDataModel> xListCashierDataModel = null;

                if (xListCashierDataModel == null)
                    xListCashierDataModel = new List<CashierDataModel>();

                return xListCashierDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveCashier(CashierDataModel prm_xCashierDataModel)
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

        public void vSaveCashier(ServiceDataModel.CashierModel prm_xCashierModel)
        {
            try
            {

                var query = string.Format("INSERT INTO TableCashier (No, Name, LastName, Password, IdentityNumber, Description, IsAdministrator) VALUES({0},'{1}','{2}','{3}','{4}','{5}',{6});",
                       prm_xCashierModel.No,
                       prm_xCashierModel.Name,
                       prm_xCashierModel.LastName,
                       prm_xCashierModel.Password,
                       prm_xCashierModel.IdentityNumber,
                       prm_xCashierModel.Description,
                       Convert.ToInt16(prm_xCashierModel.IsAdministrator));
                Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteVoidDataTable(query);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

        }
        public CashierDataModel xGetCashierByNo(int prm_iCashierNo)
        {
            try
            {
                List<CashierDataModel> xListCashierDataModel = xListGetCashier(prm_iCashierNo, string.Empty, string.Empty);

                if (xListCashierDataModel == null)
                    return null;

                return xListCashierDataModel.First();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public CashierDataModel xGetCashierByNameLastName(string prm_strCashierName, string prm_strCashierLastName)
        {
            try
            {
                List<CashierDataModel> xListCashierDataModel = xListGetCashier(0, prm_strCashierName, prm_strCashierLastName);

                return xListCashierDataModel.First();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public CashierDataModel xGetCashierByFullname(string prm_strCashierFullname)
        {
            try
            {
                List<CashierDataModel> xListCashierDataModel = null;

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable($"SELECT * FROM TableCashier WHERE (Name || ' ' || LastName) = '{prm_strCashierFullname}' ORDER BY Id");

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListCashierDataModel == null)
                            xListCashierDataModel = new List<CashierDataModel>();

                        if (xDataRow != null)
                        {
                            CashierDataModel xCashierDataModel = new CashierDataModel();

                            xCashierDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xCashierDataModel.iNo = Convert.ToInt32(xDataRow["No"]);
                            xCashierDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                            xCashierDataModel.strLastName = Convert.ToString(xDataRow["LastName"]) ?? string.Empty;
                            xCashierDataModel.strPassword = Convert.ToString(xDataRow["Password"]) ?? string.Empty;
                            xCashierDataModel.strIdentityNumber = Convert.ToString(xDataRow["IdentityNumber"]) ?? string.Empty;
                            xCashierDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                            xCashierDataModel.bIsAdministrator = Convert.ToBoolean(xDataRow["IsAdministrator"]);

                            xListCashierDataModel.Add(xCashierDataModel);
                        }

                    }
                }

                return xListCashierDataModel.First();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<CashierDataModel> xListGetCashierForAllCashRegister()
        {
            try
            {
                List<CashierDataModel> xListCashierDataModel = null;

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable("SELECT * FROM TableCashier ORDER BY Id");

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    foreach (DataRow xDataRow in xDataTable.Rows)
                    {
                        if (xListCashierDataModel == null)
                            xListCashierDataModel = new List<CashierDataModel>();

                        if (xDataRow != null)
                        {
                            CashierDataModel xCashierDataModel = new CashierDataModel();

                            xCashierDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                            xCashierDataModel.iNo = Convert.ToInt32(xDataRow["No"]);
                            xCashierDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                            xCashierDataModel.strLastName = Convert.ToString(xDataRow["LastName"]) ?? string.Empty;
                            xCashierDataModel.strPassword = Convert.ToString(xDataRow["Password"]) ?? string.Empty;
                            xCashierDataModel.strIdentityNumber = Convert.ToString(xDataRow["IdentityNumber"]) ?? string.Empty;
                            xCashierDataModel.strDescription = Convert.ToString(xDataRow["Description"]) ?? string.Empty;
                            xCashierDataModel.bIsAdministrator = Convert.ToBoolean(xDataRow["FontAutoHeight"]);

                            xListCashierDataModel.Add(xCashierDataModel);
                        }

                    }
                }

                return xListCashierDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public List<CashierDataModel> xListGetCashierForAllCashRegister(int prm_iCashierNo, string prm_strCashierUserName, int prm_iCashRegisterNumber)
        {
            try
            {
                List<CashierDataModel> xListCashierDataModel = null;

                if (xListCashierDataModel == null)
                    xListCashierDataModel = new List<CashierDataModel>();

                return xListCashierDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveCashierForAllCashRegister(CashierDataModel prm_xCashierDataModel)
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
