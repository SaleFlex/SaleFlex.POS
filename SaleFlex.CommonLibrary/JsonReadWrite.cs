using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Newtonsoft.Json;

namespace SaleFlex.CommonLibrary
{
    public class JsonReadWrite<T>
    {
        private static JsonReadWrite<T> m_xGlobalsInstance = null;

        public string prop_strJsonFileName { get; set; }

        public JsonReadWrite()
        {
            prop_strJsonFileName = "Settings.Json";
        }

        public static JsonReadWrite<T> xGetInstance()
        {
            if (m_xGlobalsInstance == null)
            {
                m_xGlobalsInstance = new JsonReadWrite<T>();
            }
            return m_xGlobalsInstance;
        }

        public bool bWrite(T prm_objTemplate)
        {
            bool bReturnValue = false;

            try
            {
                string strJsonData = JsonConvert.SerializeObject(prm_objTemplate, Formatting.Indented);
                if (!string.IsNullOrEmpty(strJsonData))
                {
                    try
                    {
                        using (StreamWriter xStreamWriter = new StreamWriter("Settings.Json", false))
                        {
                            xStreamWriter.WriteLine(strJsonData);
                            xStreamWriter.Flush();
                            bReturnValue = true;
                        }
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }

        public bool bRead(ref T prm_ref_objTemplate)
        {
            bool bReturnValue = false;

            try
            {
                string strJsonData = string.Empty;

                try
                {
                    using (StreamReader xStreamReader = new StreamReader("Settings.Json", true))
                    {
                        strJsonData = xStreamReader.ReadToEnd();
                        bReturnValue = true;
                    }
                }
                catch (Exception xException)
                {
                    xException.strTraceError();
                }

                if (!string.IsNullOrEmpty(strJsonData))
                {
                    prm_ref_objTemplate = JsonConvert.DeserializeObject<T>(strJsonData);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return bReturnValue;
        }
    }
}
