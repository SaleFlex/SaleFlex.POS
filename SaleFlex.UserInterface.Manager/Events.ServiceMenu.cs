using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Constanst;
using SaleFlex.UserInterface.BoxForm;
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
        public void vServiceMenu(object prm_objSender, EventArgs prm_xEventArgs)
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
                    PosManager.xGetInstance().vChangeForm(enumFormType.SERVICE);
                    bReDrawFormControls();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vServiceCompanyInfo(object prm_objSender, EventArgs prm_xEventArgs)
        {
            if (vCheckServiceMode())
                return;
            try
            {
                string strNationalIdNumber = string.Empty;
                string strTaxIdNumber = string.Empty;
                string strMersisIdNumber = string.Empty;
                string strWebAdress = string.Empty;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strServiceCompanyInfo)
                {
                    InputBoxCompanyInformation xInputBoxCompanyInformation = new InputBoxCompanyInformation();
                    PosDataModel xPosDataModel = new PosDataModel();

                    xPosDataModel = Dao.xGetInstance().xGetPos();

                    if (xPosDataModel != null)
                    {
                        xInputBoxCompanyInformation.strNationalIdNumber = xPosDataModel.strOwnerNationalIdNumber;
                        xInputBoxCompanyInformation.strTaxIdNumber = xPosDataModel.strOwnerTaxIdNumber;
                        xInputBoxCompanyInformation.strMersisIdNumber = xPosDataModel.strOwnerMersisIdNumber;
                        xInputBoxCompanyInformation.strCompanyWebAddress = xPosDataModel.strOwnerWebAdress;
                    }

                    if (xInputBoxCompanyInformation.ShowDialog() == DialogResult.OK)
                    {
                        xPosDataModel.strOwnerNationalIdNumber = xInputBoxCompanyInformation.strNationalIdNumber;
                        xPosDataModel.strOwnerTaxIdNumber = xInputBoxCompanyInformation.strTaxIdNumber;
                        xPosDataModel.strOwnerMersisIdNumber = xInputBoxCompanyInformation.strMersisIdNumber;
                        xPosDataModel.strOwnerWebAdress = xInputBoxCompanyInformation.strCompanyWebAddress;


                        if (Dao.xGetInstance().bSavePos(xPosDataModel) == false)
                        {
                            xInputBoxCompanyInformation.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// SERVICE_DATE_TIME
        /// </summary>
        /// <param name="prm_objSender"></param>
        /// <param name="prm_xEventArgs"></param>
        public void vServiceChangeDateTime(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bResultValue = false;
            if (vCheckServiceMode())
                return;
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strServiceChangeDateTime)
                {
                    DateTime xDateTime = new DateTime();

                    if (PosManager.xGetInstance().bServiceChangeDateTime(ref xDateTime) == true)
                    {
                        CustomMessageBox.Show(string.Format("{0}: {1}", LabelTranslations.strGet("DateAndTime"), xDateTime));
                        bResultValue = true;
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bResultValue == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        /// <summary>
        /// SERVICE_PARAMETER_DOWNLOAD
        /// </summary>
        /// <param name="prm_objSender"></param>
        /// <param name="prm_xEventArgs"></param>
        public void vServiceParameterDownload(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool boolResult = false;
            if (vCheckServiceMode())
                return;
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strServiceParameterDownload)
                {
                    if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (PosManager.xGetInstance().bServiceParameterDownload() == true)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendFormat("Parametre Yüklendi");
                            CustomMessageBox.Show(string.Format("{0}", sb));
                            boolResult = true;
                        }
                    }
                    else
                    {
                        boolResult = true;
                    }
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

        public void vServiceSetReceiptLimit(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool boolResult = false;
            if (vCheckServiceMode())
                return;
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strServiceSetReceiptLimit)
                {
                    decimal decReceiptLimit = 0.0M;

                    if (PosManager.xGetInstance().bServiceGetReceiptLimit(out decReceiptLimit) == true)
                    {
                        InputBoxReceiptLimit xInputBoxReceiptLimit = new InputBoxReceiptLimit();
                        xInputBoxReceiptLimit.decReceiptLimit = decReceiptLimit;

                        if (xInputBoxReceiptLimit.ShowDialog() == DialogResult.OK)
                        {
                            ReceiptLimitDataModel xReceiptLimitDataModel = new ReceiptLimitDataModel();
                            xReceiptLimitDataModel.iId = 1;
                            xReceiptLimitDataModel.decReceiptLimit = xInputBoxReceiptLimit.decReceiptLimit;

                            if (PosManager.xGetInstance().bServiceSetReceiptLimit(xInputBoxReceiptLimit.decReceiptLimit) == true && Dao.xGetInstance().bSaveReceiptLimit(xReceiptLimitDataModel) == true)
                            {
                                boolResult = true;
                            }
                        }
                        else
                        {
                            boolResult = true;
                        }
                    }
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

        public void vServiceResetToFactoryMode(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool boolResult = false;
            if (vCheckServiceMode())
                return;
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strServiceResetToFactoryMode)
                {
                    if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (PosManager.xGetInstance().bServiceResetToFactoryMode() == true)
                        {
                            boolResult = true;
                        }
                    }
                    else
                    {
                        boolResult = true;
                    }
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

        public void vServiceResetPassword(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnResult = false;
            if (vCheckServiceMode())
                return;
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strServiceResetPassword)
                {
                    if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (PosManager.xGetInstance().bServiceResetPassword() == true)
                        {

                            bReturnResult = true;

                        }
                    }
                    else
                    {
                        bReturnResult = true;
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnResult == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vServiceChangePassword(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool bReturnResult = false;
            if (vCheckServiceMode())
                return;
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strServiceChangePassword)
                {
                    if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (PosManager.xGetInstance().bServiceResetPassword() == true)
                        {

                            bReturnResult = true;

                        }
                    }
                    else
                    {
                        bReturnResult = true;
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            if (bReturnResult == false)
            {
                CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
            }
        }

        public void vServicePosActive(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool boolResult = false;
            if (vCheckServiceMode())
                return;
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strServicePosActive)
                {
                    if (PosManager.xGetInstance().bServicePosActivated() == true)
                    {
                        boolResult = true;
                        CustomMessageBox.Show(LabelTranslations.strGet("CashRegisterActivated"));
                    }
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

        public void vServiceCodeRequest(object prm_objSender, EventArgs prm_xEventArgs)
        {
            string strPasswordCode = string.Empty;

            bool boolResult = false;
            if (vCheckServiceMode())
                return;
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strServiceCodeRequest)
                {
                    if (PosManager.xGetInstance().bServiceRequestCode(out strPasswordCode) == true)
                    {

                    }
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

        public void vServiceSoftwareDownload(object prm_objSender, EventArgs prm_xEventArgs)
        {
            bool boolResult = false;
            if (vCheckServiceMode())
                return;
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strServiceSoftwareDownload)
                {
                    if (PosManager.xGetInstance().bServiceSoftwareDownload() == true)
                    {
                        boolResult = true;
                    }
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

            vCheckServiceMode();
        }

        public bool vCheckServiceMode()
        {
            enumFormType enumFormType;
            if (PosManager.xGetInstance().bGetForm(out enumFormType) == true)
            {
                if (enumFormType != enumFormType.SERVICE)
                {
                    object xSender = null;
                    foreach (Control xControl in m_xLastCustomForm.Controls)
                    {
                        if (xControl is CustomButton)
                        { xSender = xControl; break; }
                    }
                    CustomMessageBox.Show(LabelTranslations.strGet("OutOfService"));
                    vLogoutSystem(xSender, null);
                    return true;
                }
            }
            return false;
        }
    }
}
