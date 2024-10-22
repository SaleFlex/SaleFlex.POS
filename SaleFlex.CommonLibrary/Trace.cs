using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace SaleFlex.CommonLibrary
{
    /// <summary>
    /// Trace class to handle logging messages with different levels of importance.
    /// This class allows capturing detailed trace information, including the method and class names
    /// from which the trace is being logged, and supports various trace levels.
    /// </summary>
    public class Trace
    {
        /// <summary>
        /// Inserts a trace message with a specific trace level.
        /// </summary>
        /// <param name="prm_enumTraceLevel">Trace importance level.</param>
        /// <param name="prm_strTrace">The trace message to be logged.</param>
        public static void vInsert(enumTraceLevel prm_enumTraceLevel, string prm_strTrace)
        {
            try
            {
                // Retrieve the method that called this method and the one before it.
                MethodBase xLocationMethodBase = new StackTrace().GetFrame(1).GetMethod();
                MethodBase xCalledByMethodBase = new StackTrace().GetFrame(2).GetMethod();

                // Get class and method names for logging purposes.
                string strLocationClassName = xLocationMethodBase.ReflectedType.Name;
                string strLocationMethodName = xLocationMethodBase.Name;
                string strCalledByClassName = xCalledByMethodBase.ReflectedType.Name;
                string strCalledByMethodName = xCalledByMethodBase.Name;

                // Prepare and log the trace message.
                vPrepareTrace(prm_enumTraceLevel, strLocationClassName, strLocationMethodName, strCalledByClassName, strCalledByMethodName, prm_strTrace);
            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }
        }

        /// <summary>
        /// Inserts a formatted trace message with specific arguments and trace level.
        /// </summary>
        /// <param name="prm_enumTraceLevel">Trace importance level.</param>
        /// <param name="prm_strTraceFormat">The trace message format string.</param>
        /// <param name="prm_objaTraceArgumenst">Arguments for the format string.</param>
        public static void vInsert(enumTraceLevel prm_enumTraceLevel, string prm_strTraceFormat, params object[] prm_objaTraceArgumenst)
        {
            try
            {
                // Retrieve the method that called this method and the one before it.
                MethodBase xLocationMethodBase = new StackTrace().GetFrame(1).GetMethod();
                MethodBase xCalledByMethodBase = new StackTrace().GetFrame(2).GetMethod();

                // Get class and method names for logging purposes.
                string strLocationClassName = xLocationMethodBase.ReflectedType.Name;
                string strLocationMethodName = xLocationMethodBase.Name;
                string strCalledByClassName = xCalledByMethodBase.ReflectedType.Name;
                string strCalledByMethodName = xCalledByMethodBase.Name;

                // Prepare and log the trace message with arguments.
                vPrepareTrace(prm_enumTraceLevel, strLocationClassName, strLocationMethodName, strCalledByClassName, strCalledByMethodName, prm_strTraceFormat, prm_objaTraceArgumenst);
            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }
        }

        /// <summary>
        /// Inserts a formatted trace message with a specific ID, trace level, and arguments.
        /// </summary>
        /// <param name="prm_enumTraceLevel">Trace importance level.</param>
        /// <param name="prm_lID">Unique ID associated with the trace.</param>
        /// <param name="prm_strTraceFormat">The trace message format string.</param>
        /// <param name="prm_objaTraceArgumenst">Arguments for the format string.</param>
        public static void vInsert(enumTraceLevel prm_enumTraceLevel, long prm_lID, string prm_strTraceFormat, params object[] prm_objaTraceArgumenst)
        {
            try
            {
                // Retrieve the method that called this method and the one before it.
                MethodBase xLocationMethodBase = new StackTrace().GetFrame(1).GetMethod();
                MethodBase xCalledByMethodBase = new StackTrace().GetFrame(2).GetMethod();

                // Get class and method names for logging purposes.
                string strLocationClassName = xLocationMethodBase.ReflectedType.Name;
                string strLocationMethodName = xLocationMethodBase.Name;
                string strCalledByClassName = xCalledByMethodBase.ReflectedType.Name;
                string strCalledByMethodName = xCalledByMethodBase.Name;

                // Format trace message with ID.
                prm_strTraceFormat = string.Format("[ID:{0}] {1}", prm_lID, prm_strTraceFormat);
                vPrepareTrace(prm_enumTraceLevel, strLocationClassName, strLocationMethodName, strCalledByClassName, strCalledByMethodName, prm_strTraceFormat, prm_objaTraceArgumenst);
            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }
        }

        /// <summary>
        /// Inserts a trace message with a specific ID and trace level.
        /// </summary>
        /// <param name="prm_enumTraceLevel">Trace importance level.</param>
        /// <param name="prm_lID">Unique ID associated with the trace.</param>
        /// <param name="prm_strTrace">The trace message to be logged.</param>
        public static void vInsert(enumTraceLevel prm_enumTraceLevel, long prm_lID, string prm_strTrace)
        {
            try
            {
                // Retrieve the method that called this method and the one before it.
                MethodBase xLocationMethodBase = new StackTrace().GetFrame(1).GetMethod();
                MethodBase xCalledByMethodBase = new StackTrace().GetFrame(2).GetMethod();

                // Get class and method names for logging purposes.
                string strLocationClassName = xLocationMethodBase.ReflectedType.Name;
                string strLocationMethodName = xLocationMethodBase.Name;
                string strCalledByClassName = xCalledByMethodBase.ReflectedType.Name;
                string strCalledByMethodName = xCalledByMethodBase.Name;

                // Format trace message with ID.
                prm_strTrace = string.Format("[ID:{0}] {1}", prm_lID, prm_strTrace);
                vPrepareTrace(prm_enumTraceLevel, strLocationClassName, strLocationMethodName, strCalledByClassName, strCalledByMethodName, prm_strTrace);
            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }
        }

        /// <summary>
        /// Inserts a data log trace message with a specific trace level.
        /// </summary>
        /// <param name="prm_enumTraceLevel">Trace importance level.</param>
        /// <param name="prm_strTrace">The trace message to be logged.</param>
        public static void vInsertDataLog(enumTraceLevel prm_enumTraceLevel, string prm_strTrace)
        {
            try
            {
                // Retrieve the method that called this method and the one before it.
                MethodBase xLocationMethodBase = new StackTrace().GetFrame(1).GetMethod();
                MethodBase xCalledByMethodBase = new StackTrace().GetFrame(2).GetMethod();

                // Get class and method names for logging purposes.
                string strLocationClassName = xLocationMethodBase.ReflectedType.Name;
                string strLocationMethodName = xLocationMethodBase.Name;
                string strCalledByClassName = xCalledByMethodBase.ReflectedType.Name;
                string strCalledByMethodName = xCalledByMethodBase.Name;

                // Prepare and log the trace message for data logging.
                vPrepareTraceDataLog(prm_enumTraceLevel, strLocationClassName, strLocationMethodName, strCalledByClassName, strCalledByMethodName, prm_strTrace);
            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }
        }

        /// <summary>
        /// Prepares and logs the trace message to the trace file, with formatted arguments.
        /// </summary>
        /// <param name="prm_enumTraceLevel">Trace importance level.</param>
        /// <param name="prm_strLocationClassName">Class name where the trace was inserted.</param>
        /// <param name="prm_strLocationMethodName">Method name where the trace was inserted.</param>
        /// <param name="prm_strCalledByClassName">Class name of the caller method.</param>
        /// <param name="prm_strCalledByMethodName">Method name of the caller.</param>
        /// <param name="prm_strTraceFormat">Message format to be logged.</param>
        /// <param name="prm_objaTraceArgumenst">Arguments for the format string.</param>
        public static void vPrepareTrace(enumTraceLevel prm_enumTraceLevel, string prm_strLocationClassName, string prm_strLocationMethodName, string prm_strCalledByClassName, string prm_strCalledByMethodName, string prm_strTraceFormat, params object[] prm_objaTraceArgumenst)
        {
            try
            {
                // Ensure that arguments are not null.
                for (int iIndex = 0; iIndex < prm_objaTraceArgumenst.Length; iIndex++)
                {
                    if (prm_objaTraceArgumenst[iIndex] == null)
                        prm_objaTraceArgumenst[iIndex] = (object)string.Format("<ERROR:Null object assigned>");
                }
                // Format the trace message and log it.
                vPrepareTrace(prm_enumTraceLevel, prm_strLocationClassName, prm_strLocationMethodName, prm_strCalledByClassName, prm_strCalledByMethodName, string.Format(prm_strTraceFormat, prm_objaTraceArgumenst));
            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }
        }

        /// <summary>
        /// Prepares and logs the trace message to the trace file.
        /// </summary>
        /// <param name="prm_enumTraceLevel">Trace importance level.</param>
        /// <param name="prm_strLocationClassName">Class name where the trace was inserted.</param>
        /// <param name="prm_strLocationMethodName">Method name where the trace was inserted.</param>
        /// <param name="prm_strCalledByClassName">Class name of the caller method.</param>
        /// <param name="prm_strCalledByMethodName">Method name of the caller.</param>
        /// <param name="prm_strTrace">Message to be logged.</param>
        public static void vPrepareTrace(enumTraceLevel prm_enumTraceLevel, string prm_strLocationClassName, string prm_strLocationMethodName, string prm_strCalledByClassName, string prm_strCalledByMethodName, string prm_strTrace)
        {
            prm_strTrace = string.Format("{0}.{1}^{2}.{3}^{4}", prm_strLocationClassName, prm_strLocationMethodName, prm_strCalledByClassName, prm_strCalledByMethodName, prm_strTrace);
            vInsertTrace((int)prm_enumTraceLevel, prm_strTrace);
        }

        public static void vPrepareTraceDataLog(enumTraceLevel prm_enumTraceLevel, string prm_strLocationClassName, string prm_strLocationMethodName, string prm_strCalledByClassName, string prm_strCalledByMethodName, string prm_strTrace)
        {
            prm_strTrace = string.Format("{0}.{1}^{2}.{3}^{4}", prm_strLocationClassName, prm_strLocationMethodName, prm_strCalledByClassName, prm_strCalledByMethodName, prm_strTrace);
            vInsertTraceDataLog((int)prm_enumTraceLevel, prm_strTrace);
        }


        /// <summary>
        /// Insert trace message line into the trace file
        /// </summary>
        /// <remarks>
        /// vInsertTrace(enumTraceLevel.Important, "MainForm" , "MainForm_Load", "Main form loaded at {0}.", DateTime.Now)
        /// </remarks>
        /// <param name="prm_strClassName">Class name associated with Message</param>
        /// <param name="prm_strMethodName">Method name associated with Message</param>
        /// <param name="prm_strTrace">Message to write in trace</param>
        /// <param name="prm_sTraceLevel">Trace importance level (0 more important-5 less important-6 turn off tracing)</param>
        private static void vInsertTrace(enumTraceLevel prm_enumTraceLevel, string prm_strClassName, string prm_strMethodName, string prm_strTraceFormat, params object[] prm_objaTraceArgumenst)
        {
            try
            {
                for (int iIndex = 0; iIndex < prm_objaTraceArgumenst.Length; iIndex++)
                {
                    if (prm_objaTraceArgumenst[iIndex] == null)
                        prm_objaTraceArgumenst[iIndex] = (object)string.Format("<ERROR:Null object assigned>");
                }
                vInsertTrace(prm_enumTraceLevel, prm_strClassName, prm_strMethodName, string.Format(prm_strTraceFormat, prm_objaTraceArgumenst));
            }
            catch
            {
                vInsertTrace((int)prm_enumTraceLevel, string.Format(prm_strTraceFormat, prm_objaTraceArgumenst));
            }
        }


        /// <summary>
        /// Insert trace message line into the trace file
        /// </summary>
        /// <remarks>
        /// vInsertTrace(enumTraceLevel.Important, "MainForm" , "MainForm_Load", "Main form loading.")
        /// </remarks>
        /// <param name="prm_strClassName">Class name associated with Message</param>
        /// <param name="prm_strMethodName">Method name associated with Message</param>
        /// <param name="prm_strTrace">Message to write in trace</param>
        /// <param name="prm_sTraceLevel">Trace importance level (0 more important-5 less important-6 turn off tracing)</param>
        private static void vInsertTrace(enumTraceLevel prm_enumTraceLevel, string prm_strClassName, string prm_strMethodName, string prm_strTrace)
        {
            try
            {
                string strTemporary = string.Format("{0}.{1}", prm_strClassName, prm_strMethodName);
                vInsertTrace((int)prm_enumTraceLevel, string.Format("{0}^{1}", strTemporary, prm_strTrace));
            }
            catch
            {
                vInsertTrace((int)prm_enumTraceLevel, prm_strTrace);
            }
        }


        /// <summary>
        /// Insert trace message line into the trace file
        /// </summary>
        /// <remarks>
        /// vInsertTrace(5, "c26e7500-45d9-48cb-a0ac-9a966959636a" , "Everything is OK")
        /// </remarks>
        /// <param name="prm_dGuid">GUID associated with Message</param>
        /// <param name="prm_strTrace">Message to write in trace</param>
        /// <param name="prm_sTraceLevel">Trace importance level (0 more important-5 less important-6 turn off tracing)</param>
        private static void vInsertTrace(enumTraceLevel prm_enumTraceLevel, Guid prm_dGuid, string prm_strTrace)
        {
            try
            {
                vInsertTrace((int)prm_enumTraceLevel, string.Format("{0}^{1}", prm_dGuid, prm_strTrace));
            }
            catch
            {
                // Probably guid is not suitable so catch an exception
                vInsertTrace((int)prm_enumTraceLevel, prm_strTrace);
            }
        }


        /// <summary>
        /// Inserts the trace message line into the trace file.
        /// The method ensures to create the necessary log file and handle message formatting.
        /// </summary>
        /// <param name="prm_iTraceLevel">Trace level as an integer.</param>
        /// <param name="prm_strTrace">Trace message to write to the file.</param>
        private static void vInsertTrace(int prm_iTraceLevel, string prm_strTrace)
        {
            try
            {
                if (prm_strTrace == "") return;

                if (prm_iTraceLevel < 0 || prm_iTraceLevel > 5) return;

                if (JsonParameter.xGetInstance().prop_sTraceLevel > prm_iTraceLevel)
                {
                    return;
                }

                DateTime xDateTime = new DateTime();
                xDateTime = DateTime.Now;
                string strFileName;
                string strFolderName;

                strFolderName = strTraceFolderName(xDateTime);

                DirectoryInfo xDirectoryInfo = new DirectoryInfo(strFolderName);

                if (xDirectoryInfo.Exists == false)
                    Directory.CreateDirectory(strFolderName);

                StringTokenizer xStringTokenizer = new StringTokenizer(Process.GetCurrentProcess().MainModule.ModuleName, ".");
                string strModulName = xStringTokenizer.strNextToken();

                strFileName = string.Format("{0}\\Trace_{1:0000}{2:00}{3:00}_{4:00}_{5}_{6:00000}.LOG", strFolderName, xDateTime.Year, xDateTime.Month, xDateTime.Day, xDateTime.Hour, strModulName, Process.GetCurrentProcess().Id);
                vCheckFileSize(strFileName);

                // Just put some useful info mesaages to Windows Event Log
                if (prm_iTraceLevel == 5)
                    bWriteTraceEventLog(prm_strTrace);

                prm_strTrace = prm_strTrace.strCheckAndCleanStringWithInvalidCharacterList("\n\r");

                string strTemporary = string.Format("{0}.{1}^Level({2})^{3}", xDateTime.ToString("T"), xDateTime.Millisecond, prm_iTraceLevel, prm_strTrace);
                try
                {
                    using (StreamWriter xStreamWriter = new StreamWriter(strFileName, true))
                    {
                        xStreamWriter.WriteLine(strTemporary);
                    }
                }
                catch
                {
                    // Swallow exceptions to ensure tracing does not break the program.
                }

            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }
        }

        private static void vInsertTraceDataLog(int prm_iTraceLevel, string prm_strTrace)
        {
            try
            {
                if (prm_strTrace == "") return;

                if (prm_iTraceLevel < 0 || prm_iTraceLevel > 5) return;

                if (JsonParameter.xGetInstance().prop_sTraceLevel > prm_iTraceLevel)
                {
                    return;
                }

                DateTime xDateTime = new DateTime();
                xDateTime = DateTime.Now;
                string strFileName;
                string strFolderName;

                strFolderName = strTraceFolderName(xDateTime);

                DirectoryInfo xDirectoryInfo = new DirectoryInfo(strFolderName);

                if (xDirectoryInfo.Exists == false)
                    Directory.CreateDirectory(strFolderName);

                StringTokenizer xStringTokenizer = new StringTokenizer(Process.GetCurrentProcess().MainModule.ModuleName, ".");
                string strModulName = xStringTokenizer.strNextToken();

                strFileName = string.Format("{0}\\DataLog_{1:0000}{2:00}{3:00}_{4:00}_{5}_{6:00000}.LOG", strFolderName, xDateTime.Year, xDateTime.Month, xDateTime.Day, xDateTime.Hour, strModulName, Process.GetCurrentProcess().Id);
                vCheckFileSize(strFileName);

                // Just put some useful info mesaages to Windows Event Log
                if (prm_iTraceLevel == 5)
                    bWriteTraceEventLog(prm_strTrace);

                prm_strTrace = prm_strTrace.strCheckAndCleanStringWithInvalidCharacterList("\n\r");

                string strTemporary = string.Format("{0}.{1}^Level({2})^{3}", xDateTime.ToString("T"), xDateTime.Millisecond, prm_iTraceLevel, prm_strTrace);
                try
                {
                    using (StreamWriter xStreamWriter = new StreamWriter(strFileName, true))
                    {
                        xStreamWriter.WriteLine(strTemporary);
                    }
                }
                catch
                {
                    // Swallow exceptions to ensure tracing does not break the program.
                }

            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }
        }


        /// <summary>
        /// Insert trace message line into the trace file
        /// </summary>
        /// <remarks>
        /// vInsertError(xException, 234)
        /// </remarks>
        /// <param name="prm_xException">Message to write in error log file.</param>
        /// <param name="prm_uiErrorNumber">Windows event log error number. (default is 0)</param>
        /// 
        public static void vInsertError(Exception prm_xException, string prm_strCustomMessage = "", uint prm_uiErrorNumber = 0)
        {

            try
            {
                bool bWriteToFile = true;
                if (prm_xException == null) return;
                if (JsonParameter.xGetInstance().prop_sTraceLevel >= 6)
                    bWriteToFile = false;

                DateTime xDateTime = new DateTime();
                xDateTime = DateTime.Now;
                string strFileName;
                string strFolderName;

                strFolderName = strTraceFolderName(xDateTime);

                DirectoryInfo xDirectoryInfo = new DirectoryInfo(strFolderName);

                if (xDirectoryInfo.Exists == false)
                    Directory.CreateDirectory(strFolderName);

                StringTokenizer xStringTokenizer = new StringTokenizer(Process.GetCurrentProcess().MainModule.ModuleName, ".");
                string strModulName = xStringTokenizer.strNextToken();


                strFileName = string.Format("{0}\\Error_{1:0000}{2:00}{3:00}_{4:00}_{5}_{6:00000}.LOG", strFolderName, xDateTime.Year, xDateTime.Month, xDateTime.Day, xDateTime.Hour, strModulName, Process.GetCurrentProcess().Id);

                lock (strFileName)
                {

                    bWriteErrorEventLog(string.Format("{0} {1}", prm_xException.Source, prm_xException.Message), prm_uiErrorNumber);

                    string strTemporary;

                    strTemporary = string.Format("{0} - ERROR DESCRIPTION START --------[[ERROR CODE: {1}]]--------------------------------------------", DateTime.Now.ToString("T"), prm_uiErrorNumber);

                    if (prm_strCustomMessage != string.Empty)//custom message BOŞ DEĞİLSE
                        strTemporary += string.Format("\r\nCUSTOM MESSAGE: {0}\r\n", prm_strCustomMessage);

                    strTemporary += string.Format("\r\n{0}\r\n", prm_xException);
                    strTemporary += "---------- ERROR DESCRIPTION END -------------------------------------------------------------------------";
                    try
                    {
                        if (bWriteToFile == true)
                            using (StreamWriter xStreamWriter = new StreamWriter(strFileName, true))
                            {
                                xStreamWriter.WriteLine(strTemporary);
                                xStreamWriter.Close();
                            }
                    }
                    catch (Exception xException)
                    {
                        vInsertErrorWithoutReadingParameters(xException);
                        bWriteErrorEventLog(string.Format("{0} {1}", xException.Source, xException.Message), 666); // Satan error code :D
                    }
                }

            }
            catch (Exception xException)
            {
                vInsertErrorWithoutReadingParameters(xException);
                bWriteErrorEventLog(string.Format("{0} {1}", xException.Source, xException.Message), 666); // Satan error code :D
            }

        }


        private static void vInsertErrorWithoutReadingParameters(Exception prm_xException)
        {
            try
            {
                if (prm_xException == null) return;

                DateTime dtDateTime = new DateTime();
                dtDateTime = DateTime.Now;
                string strFileName;
                string strFolderName;

                StringTokenizer xStringTokenizer = new StringTokenizer(Process.GetCurrentProcess().MainModule.ModuleName, ".");
                string strModulName = xStringTokenizer.strNextToken();

                strFolderName = string.Format("C:\\Error_On_{0}\\Error_{1:0000}{2:00}{3:00}", strModulName, dtDateTime.Year, dtDateTime.Month, dtDateTime.Day);

                DirectoryInfo xDirectoryInfo = new DirectoryInfo(strFolderName);

                if (xDirectoryInfo.Exists == false)
                    Directory.CreateDirectory(strFolderName);
                strFileName = string.Format("{0}\\Error_{1:0000}{2:00}{3:00}_{4:00}_{5}_{6:00000}.LOG", strFolderName, dtDateTime.Year, dtDateTime.Month, dtDateTime.Day, dtDateTime.Hour, Process.GetCurrentProcess().ProcessName, Process.GetCurrentProcess().Id);

                string strTemporary;

                strTemporary = string.Format("{0} - ERROR DESCRIPTION START -----------------------------------------------------------------------", DateTime.Now.ToString("T"));
                strTemporary += string.Format("\r\n{0}\r\n", prm_xException);
                strTemporary += "---------- ERROR DESCRIPTION END -------------------------------------------------------------------------";
                try
                {
                    using (StreamWriter xStreamWriter = new StreamWriter(strFileName, true))
                    {
                        xStreamWriter.WriteLine(strTemporary);
                    }
                }
                catch (Exception xException)
                {
                    strTemporary = xException.Message;
                }

            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }
        }

        /// <summary>
        /// Determines the folder path where trace logs should be saved.
        /// </summary>
        /// <param name="prm_xDateTime">DateTime object for the trace.</param>
        /// <returns>Path to the trace log folder.</returns>
        public static string strTraceFolderName(DateTime prm_xDateTime)
        {
            try
            {
                return string.Format("{0}\\Log_{1:0000}{2:00}{3:00}", JsonParameter.xGetInstance().prop_strTracesFolder, prm_xDateTime.Year, prm_xDateTime.Month, prm_xDateTime.Day);
            }
            catch
            {
                StringTokenizer xStringTokenizer = new StringTokenizer(Process.GetCurrentProcess().MainModule.ModuleName, ".");
                string strModulName = xStringTokenizer.strNextToken();

                return string.Format("C:\\Error_On_{0}\\Error_{1:0000}{2:00}{3:00}", strModulName, prm_xDateTime.Year, prm_xDateTime.Month, prm_xDateTime.Day);
            }
        }

        private static bool bWriteErrorEventLog(string prm_strErrorMessage, uint prm_uiErrorNumber)
        {
            return bWriteEventLog(prm_strErrorMessage, prm_uiErrorNumber, true);
        }

        private static bool bWriteTraceEventLog(string prm_strTraceMessage)
        {
            return bWriteEventLog(prm_strTraceMessage, 100, false);
        }

        private static bool bWriteEventLog(string prm_strMessage, uint prm_uiErrorNumber, bool bIsErrorEvent)
        {
            try
            {
                if (JsonParameter.xGetInstance().prop_bEventLog == false)
                    return false;

                string strProcessFileName = Process.GetCurrentProcess().MainModule.ModuleName;

                StringTokenizer xStringTokenizer = new StringTokenizer(strProcessFileName, ".");
                string strSource = xStringTokenizer.strNextToken();

                string strLog = "Application";

                if (!EventLog.SourceExists(strSource))
                    EventLog.CreateEventSource(strSource, strLog);

                prm_strMessage = prm_strMessage.strCheckAndCleanStringWithInvalidCharacterList("\n\r");
                EventLog.WriteEntry(strSource, prm_strMessage, bIsErrorEvent ? EventLogEntryType.Error : EventLogEntryType.Information, (int)prm_uiErrorNumber);
            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }
            return true;
        }


        private static void vCheckFileSize(string prm_strFileName)
        {
            try
            {
                FileInfo xFileInfo = new FileInfo(prm_strFileName);

                if (xFileInfo.Exists == false)
                    return;

                if (xFileInfo.Length >= JsonParameter.xGetInstance().prop_lTraceFileSize)
                {
                    for (int iIndex = 1; true; iIndex++)
                    {
                        xFileInfo = new FileInfo(string.Format("{0}_{1}.LOG", prm_strFileName.Substring(0, prm_strFileName.Length - 4), iIndex));
                        if (xFileInfo.Exists == false)
                            File.Move(prm_strFileName, string.Format("{0}_{1}.LOG", prm_strFileName.Substring(0, prm_strFileName.Length - 4), iIndex));
                    }
                }
            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }
        }

        /****************************************************************************************
         * Function		: xTraceFileList()
         * Input		: Trace or Log Files Date
         * Outout		: Trace or Log files array sorted by last writing time
         * Purpose		: 
         * Create Date  : 08/08/2011 By Ferhat Mousavi
         * Modify Date  : 12/08/2011 By Ferhat Mousavi
         *****************************************************************************************/
        public static FileInfo[] xTraceFileList(DateTime prm_xTraceDate)
        {
            FileInfo[] xReturnFileInfoList = null;

            try
            {
                string strFolderName = strTraceFolderName(prm_xTraceDate);

                DirectoryInfo xDirectoryInfo = new DirectoryInfo(strFolderName);

                if (xDirectoryInfo.Exists == true)
                {
                    xReturnFileInfoList = xDirectoryInfo.GetFiles("*.LOG");
                    // Sort by Last Write Time
                    Array.Sort(xReturnFileInfoList, new FileComparer(enumFileCompareBy.CreationTime));
                }
            }
            catch
            {
                // Swallow exceptions to ensure tracing does not break the program.
            }

            return xReturnFileInfoList;
        }
    }

    /// <summary>
    /// Enumeration representing different trace levels.
    /// </summary>
    public enum enumTraceLevel
    {
        /// <summary>
        /// Write low level trace. These traces are useful for developers. Numeric value is 0
        /// </summary>
        LowLevel = (short)0,
        /// <summary>
        /// Write unnecessary level trace. Numeric value is 1
        /// </summary>
        Unnecessary,
        /// <summary>
        /// Write normal level trace. Numeric value is 2
        /// </summary>
        Normal,
        /// <summary>
        /// Write necessary level trace. Numeric value is 3
        /// </summary>
        Necessary,
        /// <summary>
        /// Write imprtant level trace. Numeric value is 4
        /// </summary>
        Important,
        /// <summary>
        /// Write trace and put it to Windows Event Log. Numeric value is 5.
        /// </summary>
        UsefulInformation
    }
}
