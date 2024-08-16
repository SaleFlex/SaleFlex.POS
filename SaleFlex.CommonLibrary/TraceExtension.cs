using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace SaleFlex.CommonLibrary
{
    public static class TraceExtension
    {
        public static string strTraceError(this Exception prm_xException, string prm_strCustomMessage = "", uint prm_uiErrorNumber = 0)
        {
            Trace.vInsertError(prm_xException, prm_strCustomMessage, prm_uiErrorNumber);
            return prm_xException.Message;
        }

        public static string strTraceDump(this byte[] prm_baInputArray, string prm_strTitle = "HEX DUMP")
        {
            StringBuilder strResult = new StringBuilder(string.Format("{0}-", prm_strTitle));

            try
            {
                if (prm_baInputArray != null)
                {
                    strResult.AppendFormat("LENGTH {0}: ", prm_baInputArray.Length);
                    for (int iIndex = 0; iIndex < prm_baInputArray.Length; iIndex++)
                    {
                        strResult.AppendFormat("{0:X2}", prm_baInputArray[iIndex]);
                    }
                }
                else
                {
                    strResult.Clear().Append("Buffer is empty.");
                }


                MethodBase xLocationMethodBase = new StackTrace().GetFrame(1).GetMethod();
                MethodBase xCalledByMethodBase = new StackTrace().GetFrame(2).GetMethod();

                string strLocationClassName = xLocationMethodBase.ReflectedType.Name;
                string strLocationMethodName = xLocationMethodBase.Name;
                string strCalledByClassName = xCalledByMethodBase.ReflectedType.Name;
                string strCalledByMethodName = xCalledByMethodBase.Name;

                Trace.vPrepareTrace(enumTraceLevel.LowLevel, strLocationClassName, strLocationMethodName, strCalledByClassName, strCalledByMethodName, strResult.ToString());
            }
            catch
            {
            }

            return strResult.ToString();
        }
    }
}
