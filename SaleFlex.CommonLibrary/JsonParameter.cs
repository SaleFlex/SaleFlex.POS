using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SaleFlex.CommonLibrary
{
    public class JsonParameter
    {
        private static JsonParameter m_xGlobalsInstance = null;

        public static JsonParameter xGetInstance()
        {
            if (m_xGlobalsInstance == null)
            {
                m_xGlobalsInstance = new JsonParameter();

                JsonReadWrite<JsonParameter>.xGetInstance().bRead(ref m_xGlobalsInstance);
            }

            return m_xGlobalsInstance;
        }

        public bool bUpdateJsonParameter()
        {
            return JsonReadWrite<JsonParameter>.xGetInstance().bWrite(m_xGlobalsInstance);
        }

        public short prop_sTraceLevel { get; set; }
        public string prop_strTracesFolder { get; set; }
        public bool prop_bEventLog { get; set; }
        public long prop_lTraceFileSize { get; set; }
        public string prop_strApplicationVersion { get; set; }
        public string prop_strApplicationDescription { get; set; }
        public string prop_strImagesFolder { get; set; }
        public string prop_strLicenseOwner { get; set; }
        public string prop_strIsoCultureName { get; set; }
        public int prop_iBarcodeLength { get; set; }
        public string prop_strLastLoginName { get; set; }
        public string prop_strLastLoginLastName { get; set; }
        public string prop_strSupervisorName { get; set; }
        public bool prop_bIsDebugModeActive { get; set; }
        public int prop_iWaitAfterReceiptClosed { get; set; }
        public string prop_strDbsFolder { get; set; }
        public string prop_strDatabasePosFileName { get; set; }
        public string prop_strDatabaseSalesFileName { get; set; }
        public string prop_strDatabaseProductsFileName { get; set; }
        public string prop_strDepartmentBackColor { get; set; }
        public string prop_strFunctionBackColor { get; set; }
        public string prop_strMessageBoxBackColor { get; set; }
        public string prop_strMessageBoxForeColor { get; set; }
        public string prop_strPaymentBackColor { get; set; }
        public string prop_strPluBackColor { get; set; }
        public string prop_strTotalBackColor { get; set; }
        public string prop_strWarningBoxBackColor { get; set; }
        public string prop_strWarningBoxForeColor { get; set; }
        public string prop_strPrinterName { get; set; }
        public string prop_strInputBoxBackColor { get; set; }
        public string prop_strInputBoxForeColor { get; set; }
        public int prop_iStartFormType { get; set; }
        public int prop_iLastLoginUserNo { get; set; }
        public string prop_strLastLoginPassword { get; set; }
        public string prop_strLastLoginAdminPassword { get; set; }
        public string prop_strSupervisorPassword { get; set; }
        public int prop_iDefaultCashierNo { get; set; }
        public long prop_lPosId{ get; set; }
        public long prop_lMerchantId { get; set; }
        public int prop_iStoreNo { get; set; }
        public string prop_strIpPort { get; set; }
        public string prop_strAppToken { get; set; }
        public bool prop_bIsOfflinePos { get; set; }

        public JsonParameter()
        {
            FileInfo xFileInfo = new FileInfo(JsonReadWrite<JsonParameter>.xGetInstance().prop_strJsonFileName);

            if (xFileInfo.Exists == false)
            {
                prop_sTraceLevel = 0;
                prop_strTracesFolder = @"C:\SaleFlex\Traces";
                prop_bEventLog = true;
                prop_lTraceFileSize = 5242880;
                prop_strApplicationVersion = string.Empty;
                prop_strApplicationDescription = string.Empty;
                prop_strImagesFolder = @"C:\SaleFlex\Images";
                prop_strLicenseOwner = string.Empty;
                prop_strIsoCultureName = "tr - TR";
                prop_iBarcodeLength = 13;
                prop_strLastLoginName = string.Empty;
                prop_strLastLoginLastName = string.Empty;
                prop_strSupervisorName = "MANAGER";
                prop_bIsDebugModeActive = false;
                prop_iWaitAfterReceiptClosed = 5;
                prop_strDbsFolder = @"C:\SaleFlex\DBs";
                prop_strDatabasePosFileName = "SaleFlex.POS.DB3";
                prop_strDatabaseSalesFileName = "SaleFlex.POS.SALES.DB3";
                prop_strDatabaseProductsFileName = "SaleFlex.POS.PRODUCTS.DB3";
                prop_strDepartmentBackColor = string.Empty;
                prop_strFunctionBackColor = string.Empty;
                prop_strMessageBoxBackColor = "DARKSEAGREEN";
                prop_strMessageBoxForeColor = "BLACK";
                prop_strPaymentBackColor = string.Empty;
                prop_strPluBackColor = string.Empty;
                prop_strTotalBackColor = string.Empty;
                prop_strWarningBoxBackColor = "DARKSEAGREEN";
                prop_strWarningBoxForeColor = "BLACK";
                prop_strPrinterName = string.Empty;
                prop_strInputBoxBackColor = "DARKSEAGREEN";
                prop_strInputBoxForeColor = "BLACK";
                prop_iStartFormType = 0;
                prop_iLastLoginUserNo = 0;
                prop_strLastLoginPassword = string.Empty;
                prop_strLastLoginAdminPassword = string.Empty;
                prop_strSupervisorPassword = "202220232024";
                prop_iDefaultCashierNo = 1;
                prop_lPosId = 0;
                prop_lMerchantId = 0;
                prop_iStoreNo = 0;
                prop_strIpPort = string.Empty;
                prop_strAppToken = string.Empty;
                prop_bIsOfflinePos = true;
                JsonReadWrite<JsonParameter>.xGetInstance().bWrite(this);
            }
        }
    }
}
