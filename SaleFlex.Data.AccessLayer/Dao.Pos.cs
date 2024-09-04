using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;
using System.Data.SqlClient;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public bool bCheckPosDb()
        {
            bool returnvalue = false;

            try
            {
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable("SELECT count(*) FROM sqlite_master WHERE type='table'");

                if (xDataTable.Rows.Count > 0)
                {
                    int iTableCount = Convert.ToInt32(xDataTable.Rows[0][0]) - 1;

                    if (iTableCount == 6)
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

        public void vSavePos(ServiceDataModel.PosModel prm_xPosDataModel)
        {
            try
            {
                var query = string.Format("INSERT INTO TablePos " +
                    "(Name, OwnerNationalIdNumber, OwnerTaxIdNumber, OwnerMersisIdNumber, OwnerCommercialRecordNo, " +
                    "OwnerWebAdress, OwnerRegistrationNumber, MacAddress, CashierScreenType, CustomerScreenType, " +
                    "CustomerDisplayType, CustomerDisplayPort, ReceiptPrinterType, ReceiptPrinterPortName, InvoicePrinterType, " +
                    "InvoicePrinterPortName, ScaleType, ScalePortName, BarcodeReaderPort, ServerIp1, ServerPort1, ServerIp2, ServerPort2, " +
                    "ForceToWorkOnline, FkDefaultCountryId, PluUpdateNo) " +
                    "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'," +
                    "'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}',{23},{24},{25});",
                    prm_xPosDataModel.Name,
                    prm_xPosDataModel.OwnerNationalIdNumber,
                    prm_xPosDataModel.OwnerTaxIdNumber,
                    prm_xPosDataModel.OwnerMersisIdNumber,
                    prm_xPosDataModel.OwnerCommercialRecordNo,
                    prm_xPosDataModel.OwnerWebAdress,
                    prm_xPosDataModel.OwnerRegistrationNumber,
                    prm_xPosDataModel.MacAddress,
                    prm_xPosDataModel.CashierScreenType,
                    prm_xPosDataModel.CustomerScreenType,
                    prm_xPosDataModel.CustomerDisplayType,
                    prm_xPosDataModel.CustomerDisplayPort,
                    prm_xPosDataModel.ReceiptPrinterType,
                    prm_xPosDataModel.ReceiptPrinterPortName,
                    prm_xPosDataModel.InvoicePrinterType,
                    prm_xPosDataModel.InvoicePrinterPortName,
                    prm_xPosDataModel.ScaleType,
                    prm_xPosDataModel.ScalePortName,
                    prm_xPosDataModel.BarcodeReaderPort,
                    prm_xPosDataModel.ServerIp1,
                    prm_xPosDataModel.ServerPort1,
                    prm_xPosDataModel.ServerIp2,
                    prm_xPosDataModel.ServerPort2,
                    Convert.ToInt16(prm_xPosDataModel.ForceToWorkOnline),
                    prm_xPosDataModel.FkDefaultCountryId,prm_xPosDataModel.PluUpdateNo);
                Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteVoidDataTable(query);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vSaveCountry(ServiceDataModel.CountryModel prm_xCountryDataModel)
        {
            try
            {
                Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteVoidDataTable(
                    string.Format("INSERT INTO TableCountry (Name, Code, ShortName) VALUES('{0}','{1}','{2}'); ",
                    prm_xCountryDataModel.Name,
                    prm_xCountryDataModel.Code,
                    prm_xCountryDataModel.ShortName));
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vSaveCommonPlu()
        {
            try
            {
                //for (int i = 0; i < length; i++)
                //{

                //}
                //DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileName).xExecuteDataTable(
                //    string.Format("INSERT INTO TableCountry VALUES({0},{1},{2}); ",
                //    prm_xCountryDataModel.Name,
                //    prm_xCountryDataModel.Code,
                //    prm_xCountryDataModel.ShortName));
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public long iGetPluUpdateNo()
        {
            try
            {
                var query = string.Format("SELECT PluUpdateNo FROM TablePos limit 1");
                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteDataTable(query);

                return Convert.ToInt32(xDataTable.Rows[0]["PluUpdateNo"]);
            }
            catch(SqlException ex)
            {
                Trace.vInsertError(ex);
                return 0;
            }
        }

        public void vUpdatePluUpdateNo(long pluUpdateNo)
        {
            try
            {
                var query = string.Format("UPDATE TablePos SET PluUpdateNo = {0}", pluUpdateNo);
                Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileNameAndPath).xExecuteVoidDataTable(query);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

    }
}
