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

namespace SaleFlex.UserInterface.Manager
{
    public partial class Events
    {
        public void vSettingMenu(object prm_objSender, EventArgs prm_xEventArgs)
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
                    PosManager.xGetInstance().vChangeForm(enumFormType.SETTING);
                    bReDrawFormControls();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vSetDisplayBrightness(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetPrinterIntensity(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetCashier(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetSupervisor(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetReceiptHeader(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetReceiptFooter(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetIdleMessage(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetBarcodeDefinition(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetVatDefinition(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetDepartmentDefinition(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetCurrencyDefinition(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetPluDefinition(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetPluMainGroupDefinition(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetDiscountRate(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vSetSurchargeRate(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnValue = false;

            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }
    }
}
