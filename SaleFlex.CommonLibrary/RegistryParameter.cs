using System;
using System.Diagnostics;

namespace SaleFlex.CommonLibrary
{
    public class RegistryParameter
    {
        private static RegistryParameter m_xGlobalsInstance = null;

        public RegistryParameter()
        {
        }

        public static RegistryParameter xGetInstance()
        {
            if (m_xGlobalsInstance == null)
                m_xGlobalsInstance = new RegistryParameter();
            return m_xGlobalsInstance;
        }

        public string strGetParameter(string prm_strModulName, string prm_strParameterName, string prm_strParameterDefaultValue)
        {
            try
            {
                return RegistryReadWrite.xGetInstance().strGetRegistryValue(string.Format("SOFTWARE\\SALEFLEX\\{0}", prm_strModulName), prm_strParameterName, prm_strParameterDefaultValue);
            }
            catch
            {
                return prm_strParameterDefaultValue;
            }
        }

        public string strGetParameter(string prm_strParameterName, string prm_strParameterDefaultValue)
        {
            try
            {
                return RegistryReadWrite.xGetInstance().strGetRegistryValue(string.Format("SOFTWARE\\SALEFLEX\\{0}", strGetModulName()), prm_strParameterName, prm_strParameterDefaultValue);
            }
            catch
            {
                return prm_strParameterDefaultValue;
            }
        }

        public short sGetParameter(string prm_strParameterName, string prm_strParameterDefaultValue)
        {
            try
            {
                return Convert.ToInt16(RegistryReadWrite.xGetInstance().strGetRegistryValue(string.Format("SOFTWARE\\SALEFLEX\\{0}", strGetModulName()), prm_strParameterName, prm_strParameterDefaultValue));
            }
            catch
            {
                return Convert.ToInt16(prm_strParameterDefaultValue);
            }
        }

        public int iGetParameter(string prm_strParameterName, int prm_iParameterDefaultValue)
        {
            try
            {
                return Convert.ToInt32(RegistryReadWrite.xGetInstance().strGetRegistryValue(string.Format("SOFTWARE\\SALEFLEX\\{0}", strGetModulName()), prm_strParameterName, string.Format("{0}", prm_iParameterDefaultValue)));
            }
            catch
            {
                return prm_iParameterDefaultValue;
            }
        }

        public long lGetParameter(string prm_strParameterName, string prm_strParameterDefaultValue)
        {
            try
            {
                return Convert.ToInt64(RegistryReadWrite.xGetInstance().strGetRegistryValue(string.Format("SOFTWARE\\SALEFLEX\\{0}", strGetModulName()), prm_strParameterName, prm_strParameterDefaultValue));
            }
            catch
            {
                return Convert.ToInt64(prm_strParameterDefaultValue);
            }
        }

        public bool bGetParameter(string prm_strParameterName, bool prm_bParameterDefaultValue)
        {
            try
            {
                if (RegistryReadWrite.xGetInstance().strGetRegistryValue(string.Format("SOFTWARE\\SALEFLEX\\{0}", strGetModulName()), prm_strParameterName, prm_bParameterDefaultValue == true ? "TRUE" : "FALSE").ToUpper() == "TRUE")
                    return true;
            }
            catch
            {
                return prm_bParameterDefaultValue;
            }
            return false;
        }

        public bool bSetParameter(string prm_strParameterName, string prm_strParameterValue)
        {
            try
            {
                RegistryReadWrite.xGetInstance().vSetRegistryValue(string.Format("SOFTWARE\\SALEFLEX\\{0}", strGetModulName()), prm_strParameterName, prm_strParameterValue);
                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bSetParameter(string prm_strParameterName, int prm_iParameterValue)
        {
            try
            {
                RegistryReadWrite.xGetInstance().vSetRegistryValue(string.Format("SOFTWARE\\SALEFLEX\\{0}", strGetModulName()), prm_strParameterName, string.Format("{0}", prm_iParameterValue));
                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bSetParameterToKeyName(string prm_strModuleName, string prm_strParameterName, string prm_strParameterDefaultValue)
        {
            try
            {
                RegistryReadWrite.xGetInstance().vSetRegistryValue(string.Format("SOFTWARE\\SALEFLEX\\{0}", prm_strModuleName), prm_strParameterName, prm_strParameterDefaultValue);
                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public string strGetModulName(bool prm_bRemoveForm = false)
        {
            string strProcessFileName = Process.GetCurrentProcess().MainModule.ModuleName;

            StringTokenizer xStringTokenizer = new StringTokenizer(strProcessFileName, ".");
            string strApplicationName = xStringTokenizer.strNextToken();

            return (prm_bRemoveForm == true && strApplicationName.Substring(strApplicationName.Length - 4, 4) == "Form") ? strApplicationName.Substring(0, strApplicationName.Length - 4) : strApplicationName;
        }

        public string strGetAllModulName(bool prm_bRemoveForm = false)
        {
            string strProcessFileName = Process.GetCurrentProcess().MainModule.ModuleName;

            StringTokenizer xStringTokenizer = new StringTokenizer(strProcessFileName, ".");
            string strApplicationName = "";
            for (int iIndex = 0; iIndex < xStringTokenizer.iCountTokens() - 1; iIndex++)
            {
                strApplicationName += xStringTokenizer.strNextToken();
                if (iIndex < xStringTokenizer.iCountTokens() - 2)
                    strApplicationName += ".";
            }

            return strApplicationName;
        }

    }
}
