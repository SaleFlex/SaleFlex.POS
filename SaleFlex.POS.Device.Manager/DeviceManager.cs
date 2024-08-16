using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SaleFlex.CommonLibrary;

namespace SaleFlex.POS.Device.Manager
{
    public class DeviceManager
    {
        private static DeviceManager m_xGlobalsInstance = null;
        CashDrawer m_xCashDrawer = null;
        CustomerDisplay m_xCustomerDisplay;

        public DeviceManager()
        {
        }

        public static DeviceManager xGetInstance()
        {
            if (m_xGlobalsInstance == null)
                m_xGlobalsInstance = new DeviceManager();
            return m_xGlobalsInstance;
        }

        public bool bInitialize()
        {
            bool bReturnValue = false;
            try
            {
                
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return bReturnValue;
        }

        public bool bCustomerDisplayIdleMessage(string prm_strMessageTextOfLine1, string prm_strMessageTextOfLine2 = "", string prm_strMessageTextOfLine3 = "", string prm_strMessageTextOfLine4 = "")
        {
            bool bResultValue = false;

            try
            {
                bResultValue = true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bResultValue;
        }

        public bool bCustomerDisplayMessage(string prm_strMessageTextOfLine1, string prm_strMessageTextOfLine2 = "", string prm_strMessageTextOfLine3 = "", string prm_strMessageTextOfLine4 = "")
        {
            bool bResultValue = false;

            try
            {
                bResultValue = true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bResultValue;
        }

        public bool bClearCustomerDisplay()
        {
            bool bResultValue = false;

            try
            {
                bResultValue = true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bResultValue;
        }

        public bool bOpenCashDrawer()
        {
            bool bResultValue = false;

            try
            {
                bResultValue = true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bResultValue;
        }

        public bool bWaitForCashDrawerClose()
        {
            bool bResultValue = false;

            try
            {
                bResultValue = true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bResultValue;
        }

        public bool bOpenCashDrawerAndWaitForDrawerClose()
        {
            bool bResultValue = false;

            try
            {
                bResultValue = true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bResultValue;
        }
    }
}
