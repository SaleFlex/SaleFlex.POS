using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Newtonsoft.Json;

namespace SaleFlex.CommonLibrary
{
    // A generic class for reading and writing JSON data to a file, using a singleton pattern.
    public class JsonReadWrite<T>
    {
        // Singleton instance of JsonReadWrite.
        private static JsonReadWrite<T> m_xGlobalsInstance = null;

        // The name of the JSON file to be used for reading and writing operations.
        public string prop_strJsonFileName { get; set; }

        // Constructor: Initializes the JSON file name to a default value.
        public JsonReadWrite()
        {
            prop_strJsonFileName = "Settings.Json";  // Default JSON file name
        }

        // Singleton pattern: Retrieves the global instance of JsonReadWrite. 
        // If the instance is not already created, it initializes a new one.
        public static JsonReadWrite<T> xGetInstance()
        {
            if (m_xGlobalsInstance == null)
            {
                m_xGlobalsInstance = new JsonReadWrite<T>();
            }
            return m_xGlobalsInstance;
        }

        // Writes the given object to the JSON file.
        // prm_objTemplate: The object of type T to be serialized into JSON and written to the file.
        public bool bWrite(T prm_objTemplate)
        {
            bool bReturnValue = false;

            try
            {
                // Serialize the object into a JSON formatted string with indentation.
                string strJsonData = JsonConvert.SerializeObject(prm_objTemplate, Formatting.Indented);

                // Check if the JSON string is not empty.
                if (!string.IsNullOrEmpty(strJsonData))
                {
                    try
                    {
                        // Write the JSON string to the file.
                        using (StreamWriter xStreamWriter = new StreamWriter("Settings.Json", false))  // File will be overwritten.
                        {
                            xStreamWriter.WriteLine(strJsonData);  // Write JSON data to the file.
                            xStreamWriter.Flush();  // Ensure that all data is written to the file.
                            bReturnValue = true;  // Indicate success.
                        }
                    }
                    catch (Exception xException)
                    {
                        // Log the exception if an error occurs during file writing.
                        xException.strTraceError();
                    }
                }
            }
            catch (Exception xException)
            {
                // Log the exception if an error occurs during serialization.
                xException.strTraceError();
            }

            return bReturnValue;  // Return the result of the write operation (true if successful, false otherwise).
        }

        // Reads JSON data from the file and deserializes it into an object.
        // prm_ref_objTemplate: The reference to an object of type T where the deserialized data will be stored.
        public bool bRead(ref T prm_ref_objTemplate)
        {
            bool bReturnValue = false;

            try
            {
                // String to hold the JSON data read from the file.
                string strJsonData = string.Empty;

                try
                {
                    // Read the JSON data from the file.
                    using (StreamReader xStreamReader = new StreamReader("Settings.Json", true))  // Open file for reading.
                    {
                        strJsonData = xStreamReader.ReadToEnd();  // Read the entire file content.
                        bReturnValue = true;  // Indicate success.
                    }
                }
                catch (Exception xException)
                {
                    // Log the exception if an error occurs during file reading.
                    xException.strTraceError();
                }

                // If the JSON data is not empty, deserialize it into the provided object.
                if (!string.IsNullOrEmpty(strJsonData))
                {
                    prm_ref_objTemplate = JsonConvert.DeserializeObject<T>(strJsonData);  // Deserialize JSON to object.
                }
            }
            catch (Exception xException)
            {
                // Log the exception if an error occurs during deserialization.
                xException.strTraceError();
            }

            return bReturnValue;  // Return the result of the read operation (true if successful, false otherwise).
        }
    }
}
