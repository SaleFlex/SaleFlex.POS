using System.Windows.Forms;
using System.Reflection;
using SaleFlex.UserInterface.Manager;
using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using System.Threading;

namespace SaleFlex.POS
{
    class Main : ApplicationContext
    {
        public Main()
        {
            string strVersion = CommonProperty.prop_strApplicationVersion = strAssemblyVersion;
            string strDescription = CommonProperty.prop_strApplicationDescription = strAssemblyDescription;

            Trace.vInsert(enumTraceLevel.Normal, "SaleFlex.POS ({0},{1})", strVersion, strDescription);

            MainForm = Interface.xGetInstance().prop_xForm;
        }

        public string strAssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string strAssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
    }
}