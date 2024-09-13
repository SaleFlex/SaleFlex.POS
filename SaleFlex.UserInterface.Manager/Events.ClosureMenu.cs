using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.POS.Manager;
using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Data;
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
                {
                    vTotalValuesChanges();
                }
                else
                {
                    CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }
    }
}
