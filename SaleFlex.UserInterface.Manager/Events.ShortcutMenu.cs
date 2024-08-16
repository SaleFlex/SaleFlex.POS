using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Constanst;
using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.POS.Manager;
using SaleFlex.POS.Device.Manager;
using SaleFlex.UserInterface.Data;
using SaleFlex.UserInterface.BoxForm;

namespace SaleFlex.UserInterface.Manager
{
    public partial class Events
    {
      
        public void vShortcutMenu(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();


                if (xControl is CustomButton)
                {
                    InfoBoxShortCutMenu xInfoBoxShortCutMenu = new InfoBoxShortCutMenu();
                    //xInputBoxStockLookUp.m_xPluID = 6;
                    xInfoBoxShortCutMenu.ShowDialog();
                    bReDrawFormControls();
                }
            }

            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

    }
}
