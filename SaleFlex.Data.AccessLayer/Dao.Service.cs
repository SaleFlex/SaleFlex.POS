using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.SQLite;
using SaleFlex.Data.AccessLayer;

namespace SaleFlex.Data.AccessLayer
{
    public partial class Dao
    {
        public PosDataModel xGetPosDataModel()
        {
             try
            {
                PosDataModel xPosDataModel = null;

                DataTable xDataTable = Dbo.xGetInstance(CommonProperty.prop_strDatabasePosFileName).xExecuteDataTable(string.Format("SELECT * FROM TablePos LIMIT 1"));

                if (xDataTable != null && xDataTable.Rows.Count > 0)
                {
                    DataRow xDataRow = xDataTable.Rows[0];

                    if (xDataRow != null)
                    {
                        xPosDataModel = new PosDataModel();

                        xPosDataModel.iId = Convert.ToInt32(xDataRow["Id"]);
                        xPosDataModel.strName = Convert.ToString(xDataRow["Name"]) ?? string.Empty;
                        xPosDataModel.strSerialNumber = Convert.ToString(xDataRow["SerialNumber"]) ?? string.Empty;
                        xPosDataModel.strBrand = Convert.ToString(xDataRow["Brand"]) ?? string.Empty;
                        xPosDataModel.strModel = Convert.ToString(xDataRow["Model"]) ?? string.Empty;
                        xPosDataModel.strOperatingSystemVersion = Convert.ToString(xDataRow["OperatingSystemVersion"]) ?? string.Empty;
                        xPosDataModel.strOwnerNationalIdNumber = Convert.ToString(xDataRow["OwnerNationalIdNumber"]) ?? string.Empty;
                        xPosDataModel.strOwnerTaxIdNumber = Convert.ToString(xDataRow["OwnerTaxIdNumber"]) ?? string.Empty;
                        xPosDataModel.strOwnerMersisIdNumber = Convert.ToString(xDataRow["OwnerMersisIdNumber"]) ?? string.Empty;
                        xPosDataModel.strOwnerCommercialRecordNo = Convert.ToString(xDataRow["OwnerCommercialRecordNo"]) ?? string.Empty;
                        xPosDataModel.strOwnerWebAdress = Convert.ToString(xDataRow["OwnerWebAdress"]) ?? string.Empty;
                        xPosDataModel.strOwnerRegistrationNumber = Convert.ToString(xDataRow["OwnerRegistrationNumber"]) ?? string.Empty;
                        xPosDataModel.strMacAddress = Convert.ToString(xDataRow["MacAddress"]) ?? string.Empty;
                        xPosDataModel.strCashierScreenType = Convert.ToString(xDataRow["CashierScreenType"]) ?? string.Empty;
                        xPosDataModel.strCustomerScreenType = Convert.ToString(xDataRow["CustomerScreenType"]) ?? string.Empty;
                        xPosDataModel.strCustomerDisplayType = Convert.ToString(xDataRow["CustomerDisplayType"]) ?? string.Empty;
                        xPosDataModel.strCustomerDisplayPort = Convert.ToString(xDataRow["CustomerDisplayPort"]) ?? string.Empty;
                        xPosDataModel.strReceiptPrinterType = Convert.ToString(xDataRow["ReceiptPrinterType"]) ?? string.Empty;
                        xPosDataModel.strReceiptPrinterPortName = Convert.ToString(xDataRow["ReceiptPrinterPortName"]) ?? string.Empty;
                        xPosDataModel.strInvoicePrinterType = Convert.ToString(xDataRow["InvoicePrinterType"]) ?? string.Empty;
                        xPosDataModel.strInvoicePrinterPortName = Convert.ToString(xDataRow["InvoicePrinterPortName"]) ?? string.Empty;
                        xPosDataModel.strScaleType = Convert.ToString(xDataRow["ScaleType"]) ?? string.Empty;
                        xPosDataModel.strScalePortName = Convert.ToString(xDataRow["ScalePortName"]) ?? string.Empty;
                        xPosDataModel.strBarcodeReaderPort = Convert.ToString(xDataRow["BarcodeReaderPort"]) ?? string.Empty;
                        xPosDataModel.strServerIp1 = Convert.ToString(xDataRow["ServerIp1"]) ?? string.Empty;
                        xPosDataModel.strServerPort1 = Convert.ToString(xDataRow["ServerPort1"]) ?? string.Empty;
                        xPosDataModel.strServerIp2 = Convert.ToString(xDataRow["ServerIp2"]) ?? string.Empty;
                        xPosDataModel.strServerPort2 = Convert.ToString(xDataRow["ServerPort2"]) ?? string.Empty;
                        xPosDataModel.bForceToWorkOnline = Convert.ToBoolean(xDataRow["ForceToWorkOnline"]);
                        xPosDataModel.iFkDefaultCountryId = Convert.ToInt32(xDataRow["FkDefaultCountryId"]);
                    }
                }

                return xPosDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public PosDataModel xGetPos()
        {
            return xGetPos(0);
        }

        public PosDataModel xGetPos(long prm_lId)
        {
            try
            {
                PosDataModel xPosDataModel = null;

                if (xPosDataModel == null)
                    xPosDataModel = new PosDataModel();

                return xPosDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSavePos(PosDataModel prm_xPosDataModel)
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

        public ReceiptLimitDataModel xGetReceiptLimit()
        {
            return xGetReceiptLimit(0);
        }

        public ReceiptLimitDataModel xGetReceiptLimit(int prm_iId)
        {
            try
            {
                ReceiptLimitDataModel xReceiptLimitDataModel = null;


                if (xReceiptLimitDataModel == null)
                    xReceiptLimitDataModel = new ReceiptLimitDataModel();


                return xReceiptLimitDataModel;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return null;
            }
        }

        public bool bSaveReceiptLimit(ReceiptLimitDataModel prm_xReceiptLimitDataModel)
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
