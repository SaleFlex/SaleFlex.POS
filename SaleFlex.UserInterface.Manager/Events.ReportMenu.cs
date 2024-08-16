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
using SaleFlex.UserInterface.Data;
using SaleFlex.UserInterface.BoxForm;

namespace SaleFlex.UserInterface.Manager
{
    public partial class Events
    {
        public void vReportMenu(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //if (bIsReceiptOpen() == true)
                //    return;
                //if (bIsPaymentStart() == true)
                //    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();

                if (xControl is CustomButton)
                {
                    PosManager.xGetInstance().vChangeForm(enumFormType.REPORT);
                    bReDrawFormControls();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vSaleDetailReport(object prm_objSender, EventArgs prm_xEventArgs)
        {
            //bool boolResult = false;

            try
            {


                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();


                if (xControl is CustomButton)
                {
                    InputBoxCashReport xInputBoxCashReport = new InputBoxCashReport();
                    //xInputBoxStockLookUp.m_xPluID = 6;
                    xInputBoxCashReport.ShowDialog();

                }
            }

            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vPluSaleReport(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == "TAKE_X_PLU_REPORT")
                {
                    if (PosManager.xGetInstance().bPluReport() == true)
                        CustomMessageBox.Show(LabelTranslations.strGet("ProcessFinished"));
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vPosSummaryReport(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool boolResult = false;

            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strPosSummaryReport)
                {
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (boolResult == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }
    }
}
