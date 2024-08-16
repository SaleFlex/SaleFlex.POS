using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using SaleFlex.CommonLibrary;

namespace SaleFlex.POS.Manager
{
    class License
    {
        private static License m_xGlobalsInstance = null;
        private bool m_bIsAuthorized = false;

        public License()
        {
            m_bIsAuthorized = false;
        }

        ~License()
        {
        }

        public static License xGetInstance()
        {
            if (m_xGlobalsInstance == null)
                m_xGlobalsInstance = new License();
            return m_xGlobalsInstance;
        }

        public bool bAuthorizedLicense()
        {
            bool bReturnValue = false;

            string strFileName = "SaleFlex.license.bin";

            try
            {
                using (StreamReader xStreamReader = new StreamReader(strFileName, true))
                {
                    bReturnValue = bAuthorizedLicense(xStreamReader.ReadToEnd());
                }
            }
            catch
            {
            }

            return bReturnValue;
        }

        public bool bAuthorizedLicense(string prm_strLicense)
        {
            if (DateTime.Now < (new DateTime(2018, 1, 1)) && prm_strLicense.ToLower() == "85d839f2930082f5ade84c7a2b09ac6d3799ac37986391598a9a533f7ac4a03d") // Data "SaleFlex.pos.license" and sha256 "85d839f2930082f5ade84c7a2b09ac6d3799ac37986391598a9a533f7ac4a03d"
            {
                // Development license
                m_bIsAuthorized = true;
                return true;
            }
            
            return m_bIsAuthorized = false;
        }

        public bool bIsAuthorized
        {
            get
            {
                return m_bIsAuthorized;
            }
        }

        public bool bReset()
        {
            m_bIsAuthorized = false;
            return m_bIsAuthorized == false;
        }
    }
}
