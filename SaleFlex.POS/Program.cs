// ----------------------------------------------------------------------------------
// Project: SaleFlex.POS
// Developed by: Ferhat Mousavi
// Description: SaleFlex.POS is a sales Point of Sale (POS) application designed to 
//              work seamlessly with both touch-screen and keyboard-operated systems. 
//              It is part of the SaleFlex solution, offering flexibility, scalability,
//              and centralized control for modern retail businesses. 
//              This code ensures that only one instance of SaleFlex.POS runs at a 
//              time and handles unexpected application errors gracefully.
// ----------------------------------------------------------------------------------
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
        /// The main entry point for the SaleFlex.POS application.
        /// The [STAThread] attribute indicates that the COM threading model for the application
        /// is single-threaded apartment, which is required for Windows Forms applications.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Iterate over all the running processes.
            foreach (Process xProcess  in Process.GetProcesses())
            {
                // Check if there is another running process with the same name as the current process.
                // If another instance of SaleFlex.POS is found (same process name but different process ID), show a warning.
                // This ensures that only one instance of the SaleFlex.POS application runs at any time,
                // preventing potential conflicts with data or system resources.
                if (Process.GetCurrentProcess().ProcessName == xProcess.ProcessName && Process.GetCurrentProcess().Id != xProcess.Id)
                {
                    MessageBox.Show("The SaleFlex.POS is already running.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Enable modern Windows visual styles for the application.
            Application.EnableVisualStyles();

            // Set compatible text rendering for older Windows versions.
            Application.SetCompatibleTextRenderingDefault(false);

            // Add a global event handler for unhandled exceptions to capture unexpected errors.
            // This ensures that even if an unexpected error occurs, the application will show
            // a user-friendly message before closing.
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(vCurrentDomainUnhandledException);

            // Start the main form of the application.
            Application.Run(new Main());
        }

        /// <summary>
        /// This method handles unhandled exceptions.
        /// Any unhandled exception that occurs during runtime will be caught here,
        /// allowing the application to display a meaningful error message before exiting.
        /// </summary>
        /// <param name="prm_Sender">The source of the event.</param>
        /// <param name="prm_xUnhandledExceptionEventArgs">Event arguments containing exception information.</param>
        static void vCurrentDomainUnhandledException(object prm_Sender, UnhandledExceptionEventArgs prm_xUnhandledExceptionEventArgs)
        {
            // Show a message box for unpredicted errors and close the application.
            MessageBox.Show(string.Format("Unpredicted error.  The application was closed. {0}", prm_xUnhandledExceptionEventArgs.ExceptionObject.ToString()));
            
            // Exit the application after showing the error message.
            Environment.Exit(1);
        }
    }
}
