using System.Windows.Forms;
using System.Reflection;
using SaleFlex.UserInterface.Manager;
using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using System.Threading;

namespace SaleFlex.POS
{
    /// <summary>
    /// Main class that initializes the SaleFlex.POS application context.
    /// It inherits from ApplicationContext, which is responsible for managing the application's lifecycle.
    /// </summary>
    class SaleFlexPosMain : ApplicationContext
    {
        /// <summary>
        /// Constructor that initializes the Main class.
        /// This sets the application version and description, and logs the version and description information
        /// using the Trace class. It also sets the main form for the application.
        /// </summary>
        public SaleFlexPosMain()
        {
            // Retrieve and set the application version and description from the assembly attributes.
            string strVersion = CommonProperty.prop_strApplicationVersion = strAssemblyVersion;
            string strDescription = CommonProperty.prop_strApplicationDescription = strAssemblyDescription;

            // Log the application version and description with normal trace level.
            Trace.vInsert(enumTraceLevel.Normal, "SaleFlex.POS ({0},{1})", strVersion, strDescription);

            // Set the main form of the application using the user interface manager.
            MainForm = Interface.xGetInstance().prop_xForm;
        }

        /// <summary>
        /// Property to retrieve the current assembly's version.
        /// This extracts the version information from the assembly that is executing.
        /// </summary>
        public string strAssemblyVersion
        {
            get
            {
                // Retrieve the version of the currently executing assembly.
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Property to retrieve the current assembly's description.
        /// This extracts the description information from the assembly's custom attributes.
        /// </summary>
        public string strAssemblyDescription
        {
            get
            {
                // Retrieve all custom attributes of the executing assembly that match the AssemblyDescriptionAttribute type.
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

                // If no description attribute is found, return an empty string.
                if (attributes.Length == 0)
                {
                    return "";
                }

                // Return the description from the AssemblyDescriptionAttribute.
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
    }
}