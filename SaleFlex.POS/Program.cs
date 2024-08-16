using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SaleFlex.POS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            foreach (Process xProcess  in Process.GetProcesses())
            {
                if (Process.GetCurrentProcess().ProcessName == xProcess.ProcessName && Process.GetCurrentProcess().Id != xProcess.Id)
                {
                    MessageBox.Show("The SaleFlex.POS is already running.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(vCurrentDomainUnhandledException);
            Application.Run(new Main());
        }

        static void vCurrentDomainUnhandledException(object prm_Sender, UnhandledExceptionEventArgs prm_xUnhandledExceptionEventArgs)
        {
            MessageBox.Show(string.Format("Unpredicted error.  The application was closed. {0}", prm_xUnhandledExceptionEventArgs.ExceptionObject.ToString()));
            Environment.Exit(1);
        }
    }
}
