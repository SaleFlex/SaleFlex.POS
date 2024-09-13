using SaleFlex.CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFlex.UserInterface.Manager
{
    public partial class Events
    {
        public void vClosure(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }
    }
}
