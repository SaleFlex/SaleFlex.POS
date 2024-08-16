using System;
using Microsoft.Win32;

namespace SaleFlex.CommonLibrary
{
    public class RegistryReadWrite
    {
        static RegistryReadWrite m_xRegistryRWInstance = null;

        public RegistryReadWrite()
        {
        }

        public static RegistryReadWrite xGetInstance()
        {
            if (m_xRegistryRWInstance == null)
                m_xRegistryRWInstance = new RegistryReadWrite();
            return m_xRegistryRWInstance;
        }

        public RegistryKey xGetRegistryKey(string strRegistryKey)
        {
            try
            {
                RegistryKey xRegistryKey;
                xRegistryKey = Registry.CurrentUser.OpenSubKey(strRegistryKey, true);

                if (xRegistryKey == null)
                    xRegistryKey = Registry.CurrentUser.CreateSubKey(strRegistryKey);


                return xRegistryKey;
            }
            catch (Exception xException)
            {
                throw (xException);
            }
        }

        public string strGetRegistryValue(string strRegistryKey, string strRegistryName, string strDefaultValue)
        {
            try
            {
                RegistryKey xRegistryKey = xGetRegistryKey(strRegistryKey);
                string strRegistryValue = (string)xRegistryKey.GetValue(strRegistryName);
                if (strRegistryValue == null)
                {
                    strRegistryValue = strDefaultValue;
                    xRegistryKey.SetValue(strRegistryName, strDefaultValue);
                }

                return strRegistryValue;
            }
            catch (Exception xException)
            {
                throw (xException);
            }
        }

        public void vSetRegistryValue(string strRegistryKey, string strRegistryName, string strRegistryValue)
        {
            try
            {
                RegistryKey xRegistryKey = xGetRegistryKey(strRegistryKey);
                xRegistryKey.SetValue(strRegistryName, strRegistryValue);
            }
            catch (Exception xException)
            {
                throw (xException);
            }
        }
    }
}
