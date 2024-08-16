using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.Windows;

namespace SaleFlex.POS.Manager
{
    public partial class PosManager
    {
        public bool bServiceRequestCode(out string prm_out_strPasswordCode)
        {
            prm_out_strPasswordCode = "123456789012";
            return false;
        }

        public bool bServiceGetCompanyInformation(out string prm_out_strNationalIdNumber, out string prm_out_strTaxIdNumber, out string prm_out_strMersisIdNumber, out string prm_out_strCompanyWebAddress)
        {
            prm_out_strNationalIdNumber = string.Empty;
            prm_out_strTaxIdNumber = string.Empty;
            prm_out_strMersisIdNumber = string.Empty;
            prm_out_strCompanyWebAddress = string.Empty;
            return false;
        }

        public bool bServiceParameterDownload()
        {
            return false;
        }

        public bool bServiceGetReceiptLimit(out decimal prm_out_decReceiptLimit)
        {
            prm_out_decReceiptLimit = 0;
            return false;
        }

        public bool bServiceSetReceiptLimit(decimal prm_decReceiptLimit)
        {
            return false;
        }

        public bool bServiceResetToFactoryMode()
        {
            return false;
        }

        public bool bServiceResetPassword()
        {
            return false;
        }

        public bool bServiceSoftwareDownload()
        {
            return false;
        }

        public bool bServicePosActivated()
        {
            return true;
        }

        public bool bServiceChangeDateTime(ref DateTime prm_ref_xDateTime)
        {
            if (Api.SetSystemDateTime(prm_ref_xDateTime) == true)
                prm_ref_xDateTime = DateTime.Now; ;
            return true;
        }
    }
}
