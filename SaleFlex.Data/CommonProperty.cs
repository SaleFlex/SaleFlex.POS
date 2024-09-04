using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SaleFlex.CommonLibrary;
using SaleFlex.Data;

namespace SaleFlex.Data
{
    public class CommonProperty
    {
        public static string prop_strApplicationVersion
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strApplicationVersion;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strApplicationVersion = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strApplicationDescription
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strApplicationDescription;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strApplicationDescription = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strImagesFolder
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strImagesFolder;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strImagesFolder = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strLicenseOwner
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strLicenseOwner;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strLicenseOwner = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strIsoCultureName
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strIsoCultureName;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strIsoCultureName = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static int prop_iBarcodeLength
        {
            get
            {
                return JsonParameter.xGetInstance().prop_iBarcodeLength;
            }
            set
            {
                JsonParameter.xGetInstance().prop_iBarcodeLength = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strLastLoginUserName
        {
            get
            {
                string strLastLoginName = JsonParameter.xGetInstance().prop_strLastLoginName;
                string strLastLoginLastName = JsonParameter.xGetInstance().prop_strLastLoginLastName;
                return string.Format("{0} {1}", strLastLoginName, strLastLoginLastName);
            }
            set
            {
                string[] strUserNameParts = value.Trim(' ').SplitToTwoPart(' ');
                if (strUserNameParts.Count() == 2)
                {
                    JsonParameter.xGetInstance().prop_strLastLoginName = strUserNameParts[0];
                    JsonParameter.xGetInstance().prop_strLastLoginLastName = strUserNameParts[1];
                    JsonParameter.xGetInstance().bUpdateJsonParameter();
                }
                else
                {
                    // Error
                    throw new ApplicationException("LoginUserName could not be split to two part.");
                }
            }
        }

        public static string prop_strSupervisorName
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strSupervisorName;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strSupervisorName = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static bool prop_bIsDebugModeActive
        {
            get
            {
                return JsonParameter.xGetInstance().prop_bIsDebugModeActive;
            }
            set
            {
                JsonParameter.xGetInstance().prop_bIsDebugModeActive = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static int prop_iWaitAfterReceiptClosed
        {
            get
            {
                return JsonParameter.xGetInstance().prop_iWaitAfterReceiptClosed;
            }
            set
            {
                JsonParameter.xGetInstance().prop_iWaitAfterReceiptClosed = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strDbsFolder
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strDbsFolder;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strDbsFolder = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strDatabasePosFileName
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strDatabasePosFileName;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strDatabasePosFileName = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strDatabaseSalesFileName
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strDatabaseSalesFileName;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strDatabaseSalesFileName = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strDatabaseProductsFileName
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strDatabaseProductsFileName;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strDatabaseProductsFileName = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strDepartmentBackColor
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strDepartmentBackColor;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strDepartmentBackColor = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strFunctionBackColor
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strFunctionBackColor;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strFunctionBackColor = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strMessageBoxBackColor
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strMessageBoxBackColor;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strMessageBoxBackColor = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strMessageBoxForeColor
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strMessageBoxForeColor;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strMessageBoxForeColor = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strPaymentBackColor
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strPaymentBackColor;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strPaymentBackColor = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strPluBackColor
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strPluBackColor;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strPluBackColor = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strTotalBackColor
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strTotalBackColor;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strTotalBackColor = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strWarningBoxBackColor
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strWarningBoxBackColor;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strWarningBoxBackColor = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strWarningBoxForeColor
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strWarningBoxForeColor;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strWarningBoxForeColor = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strPrinterName
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strPrinterName;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strPrinterName = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strInputBoxBackColor
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strInputBoxBackColor;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strInputBoxBackColor = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strInputBoxForeColor
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strInputBoxForeColor;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strInputBoxForeColor = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static EnumFormType prop_enumStartFormType
        {
            get
            {
                return (EnumFormType)JsonParameter.xGetInstance().prop_iStartFormType;
            }
            set
            {
                JsonParameter.xGetInstance().prop_iStartFormType = (int)value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static int prop_iLastLoginUserNo
        {
            get
            {
                return JsonParameter.xGetInstance().prop_iLastLoginUserNo;
            }
            set
            {
                JsonParameter.xGetInstance().prop_iLastLoginUserNo = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strLastLoginPassword
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strLastLoginPassword;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strLastLoginPassword = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strLastLoginAdminPassword
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strLastLoginAdminPassword;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strLastLoginAdminPassword = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strSupervisorPassword
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strSupervisorPassword;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strSupervisorPassword = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static long prop_lPosId
        {
            get
            {
                return JsonParameter.xGetInstance().prop_lPosId;
            }
            set
            {
                JsonParameter.xGetInstance().prop_lPosId = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static long prop_lMerchantId
        {
            get
            {
                return JsonParameter.xGetInstance().prop_lMerchantId;
            }
            set
            {
                JsonParameter.xGetInstance().prop_lMerchantId = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static int prop_iStoreNo
        {
            get
            {
                return JsonParameter.xGetInstance().prop_iStoreNo;
            }
            set
            {
                JsonParameter.xGetInstance().prop_iStoreNo = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strIpPort
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strIpPort;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strIpPort = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strAppToken
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strAppToken;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strAppToken = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static bool prop_bIsOfflinePos 
        {
            get
            {
                return JsonParameter.xGetInstance().prop_bIsOfflinePos;
            }
            set
            {
                JsonParameter.xGetInstance().prop_bIsOfflinePos = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }


    }
}
