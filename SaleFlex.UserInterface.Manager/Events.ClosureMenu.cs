using SaleFlex.CommonLibrary;
using SaleFlex.POS.Manager;
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
                if (PosManager.xGetInstance().bClosure() == true)
                    return;

                vTotalValuesChanges();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }
    }
}
