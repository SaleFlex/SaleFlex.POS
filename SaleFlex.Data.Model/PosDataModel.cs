using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class PosDataModel
    {
        public PosDataModel()
        {
        }

        public int iId { get; set; }
        public string strName { get; set; }
        public string strSerialNumber { get; set; }
        public string strBrand { get; set; }
        public string strModel { get; set; }
        public string strOperatingSystemVersion { get; set; }
        public string strOwnerNationalIdNumber { get; set; }
        public string strOwnerTaxIdNumber { get; set; }
        public string strOwnerMersisIdNumber { get; set; }
        public string strOwnerCommercialRecordNo { get; set; }
        public string strOwnerWebAdress { get; set; }
        public string strOwnerRegistrationNumber { get; set; }
        public string strMacAddress { get; set; }
        public string strCashierScreenType { get; set; }
        public string strCustomerScreenType { get; set; }
        public string strCustomerDisplayType { get; set; }
        public string strCustomerDisplayPort { get; set; }
        public string strReceiptPrinterType { get; set; }
        public string strReceiptPrinterPortName { get; set; }
        public string strInvoicePrinterType { get; set; }
        public string strInvoicePrinterPortName { get; set; }
        public string strScaleType { get; set; }
        public string strScalePortName { get; set; }
        public string strBarcodeReaderPort { get; set; }  
        public string strServerIp1 { get; set; }
        public string strServerPort1 { get; set; }
        public string strServerIp2 { get; set; }
        public string strServerPort2 { get; set; }
        public bool bForceToWorkOnline { get; set; }
        public int iFkDefaultCountryId { get; set; }
    }
}
