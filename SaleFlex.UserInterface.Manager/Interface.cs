using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Constanst;
using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.Windows;
using SaleFlex.POS.Device.Manager;
using SaleFlex.POS.Manager;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.Manager
{
    public class Interface : CustomEventHandler
    {
        private static Interface m_xGlobalsInstance = null;
        private int m_iTabIndex = 0;
        private CustomForm m_xCustomForm = null;
        private CustomCustomerForm m_xCustomCustomerForm = null;
        private string m_strFormName = string.Empty;

        public static Interface xGetInstance()
        {
            if (m_xGlobalsInstance == null)
                m_xGlobalsInstance = new Interface();
            return m_xGlobalsInstance;
        }

        public Interface()
        {
            m_xCustomForm = new CustomForm();

            if (m_xCustomForm != null)
            {
                DeviceManager.xGetInstance().bInitialize();

                // Prevent to monitor power down
                Api.PreventMonitorPowerdown();

                if (Api.GetNumLock() != true)
                {
                    Api.SetNumLock(true);
                }

                if (CommonProperty.prop_bIsDebugModeActive == false)
                {
                    Cursor.Hide();
                }

                if (bDrawFormControls() == false)
                {
                }

                m_xCustomForm.bSetStatusBarDocumentTypeLabel(PosManager.xGetInstance().prop_enumDocumentType);

                //if (prop_xPosManagerData.xPosDataModel.strCustomerDisplayType.ToUpper() == "N-KOLAY")
                //{
                //    m_xCustomCustomerForm = new CustomCustomerForm();

                //    if (m_xCustomCustomerForm != null)
                //    {
                //        m_xCustomForm.xCustomCustomerForm = m_xCustomCustomerForm;
                //        m_xCustomCustomerForm.Show();
                //    }
                //}
                if (prop_xPosManagerData.xTransactionDataModel == null)
                {
                    prop_xPosManagerData.xTransactionDataModel = new TransactionDataModel();
                }

                m_xCustomForm.bFocusNumPad();
            }
            else
            {
                Application.Exit();
            }
        }

        public CustomForm prop_xCustomForm
        {
            get
            {
                return m_xCustomForm;
            }
        }

        public Form prop_xForm
        {
            get
            {
                return m_xCustomForm;
            }
        }

        private bool bDrawFormControls()
        {
            try
            {
                try
                {
                    m_strFormName = PosManager.xGetInstance().strCurrentFormName;
                }
                catch (Exception xException)
                {
                    xException.strTraceError();
                }

                m_xCustomForm.xFormClosingEventHandler = xEventDistributor(CustomEventFunctionName.strExitApplication);

                m_xCustomForm.bReDrawForm(m_strFormName);

                m_iTabIndex = 0;

                foreach (FormControlDataModel xFormControlDataModel in m_xCustomForm.m_xFormDataModel.xListFormControlDataModel)
                {
                    m_xCustomForm.SuspendLayout();
                    switch (xFormControlDataModel.strType)
                    {
                        case CustomControlTypeName.strButton:
                            try
                            {
                                CustomButton xCustomButton = new CustomButton(xFormControlDataModel);
                                xCustomButton.TabIndex = m_iTabIndex++;

                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction1.strName) == false)
                                    xCustomButton.xEventHandler1 = xEventDistributor(xFormControlDataModel.xFormControlFunction1.strName);
                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction2.strName) == false)
                                    xCustomButton.xEventHandler2 = xEventDistributor(xFormControlDataModel.xFormControlFunction2.strName);

                                m_xCustomForm.bAddControl(xCustomButton, xFormControlDataModel);
                            }
                            catch (Exception xException)
                            {
                                xException.strTraceError();
                            }
                            break;
                        case CustomControlTypeName.strComboBox:
                            try
                            {
                                CustomComboBox xCustomComboBox = new CustomComboBox(xFormControlDataModel);
                                xCustomComboBox.TabIndex = m_iTabIndex++;

                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction1.strName) == false)
                                    xCustomComboBox.xEventHandler1 = xEventDistributor(xFormControlDataModel.xFormControlFunction1.strName);
                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction2.strName) == false)
                                    xCustomComboBox.xEventHandler2 = xEventDistributor(xFormControlDataModel.xFormControlFunction2.strName);

                                m_xCustomForm.bAddControl(xCustomComboBox, xFormControlDataModel);
                            }
                            catch (Exception xException)
                            {
                                xException.strTraceError();
                            }

                            break;
                        case CustomControlTypeName.strTextBox:
                            try
                            {
                                CustomTextBox xCustomTextBox = new CustomTextBox(xFormControlDataModel);
                                xCustomTextBox.TabIndex = m_iTabIndex++;

                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction1.strName) == false)
                                    xCustomTextBox.xEventHandler1 = xEventDistributor(xFormControlDataModel.xFormControlFunction1.strName);
                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction2.strName) == false)
                                    xCustomTextBox.xEventHandler2 = xEventDistributor(xFormControlDataModel.xFormControlFunction2.strName);
                                m_xCustomForm.bAddControl(xCustomTextBox, xFormControlDataModel);
                            }
                            catch (Exception xException)
                            {
                                xException.strTraceError();
                            }
                            break;
                        case CustomControlTypeName.strLabel:
                            try
                            {
                                if (xFormControlDataModel.xFormControlFunction1.strName == "GET_SERVICE_CODE")
                                {
                                    string strPasswordCode = string.Empty;

                                    PosManager.xGetInstance().bServiceRequestCode(out strPasswordCode);

                                    xFormControlDataModel.strCaption1 = string.Format("{0}: {1}", LabelTranslations.strGet("PasswordCode"), strPasswordCode);
                                }
                                else if (xFormControlDataModel.xFormControlFunction1.strName == "PERIODIC_Z_REPORT")
                                {
                                    xFormControlDataModel.strCaption1 = string.Format("{0}", LabelTranslations.strGet("PeriodicZReportWarning"));
                                }

                                CustomLabel xCustomLabel = new CustomLabel(xFormControlDataModel);
                                xCustomLabel.TabIndex = m_iTabIndex++;

                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction1.strName) == false)
                                    xCustomLabel.xEventHandler1 = xEventDistributor(xFormControlDataModel.xFormControlFunction1.strName);
                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction2.strName) == false)
                                    xCustomLabel.xEventHandler2 = xEventDistributor(xFormControlDataModel.xFormControlFunction2.strName);

                                m_xCustomForm.bAddControl(xCustomLabel, xFormControlDataModel);
                            }
                            catch (Exception xException)
                            {
                                xException.strTraceError();
                            }
                            break;
                        case CustomControlTypeName.strPicture:
                            try
                            {
                                CustomPictureBox xCustomPictureBox = new CustomPictureBox(xFormControlDataModel);
                                xCustomPictureBox.TabIndex = m_iTabIndex++;

                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction1.strName) == false)
                                    xCustomPictureBox.xEventHandler1 = xEventDistributor(xFormControlDataModel.xFormControlFunction1.strName);
                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction2.strName) == false)
                                    xCustomPictureBox.xEventHandler2 = xEventDistributor(xFormControlDataModel.xFormControlFunction2.strName);

                                m_xCustomForm.bAddControl(xCustomPictureBox, xFormControlDataModel);
                            }
                            catch (Exception xException)
                            {
                                xException.strTraceError();
                            }
                            break;
                        case CustomControlTypeName.strNumpad:
                            try
                            {
                                CustomNumpad xCustomNumpad = new CustomNumpad(xFormControlDataModel);
                                xCustomNumpad.TabIndex = m_iTabIndex++;

                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction1.strName) == false)
                                    xCustomNumpad.xEventHandler1 = xEventDistributor(xFormControlDataModel.xFormControlFunction1.strName);
                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction2.strName) == false)
                                    xCustomNumpad.xEventHandler2 = xEventDistributor(xFormControlDataModel.xFormControlFunction2.strName);
                                xCustomNumpad.xEventHandlerGetPrice = xEventDistributor(CustomEventFunctionName.strPriceLookUp);
                                xCustomNumpad.xEventHandlerClearBuffer = xEventDistributor(CustomEventFunctionName.strClearBuffer);
                                xCustomNumpad.xExternalKeyPressEventHandler = new KeyPressEventHandler(vExternalKeyboardEvent);
                                xCustomNumpad.xExternalKeyEventHandler = new KeyEventHandler(vExternalKeyEventHandler);
                                xCustomNumpad.Focus();
                                m_xCustomForm.bAddControl(xCustomNumpad, xFormControlDataModel);

                                m_xCustomForm.prop_xAlwaysFocusedControl = (Control)xCustomNumpad;
                            }
                            catch (Exception xException)
                            {
                                xException.strTraceError();
                            }
                            break;
                        case CustomControlTypeName.strSalesList:
                            try
                            {
                                CustomSalesList xCustomSalesList = new CustomSalesList(xFormControlDataModel);
                                xCustomSalesList.TabIndex = m_iTabIndex++;

                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction1.strName) == false)
                                    xCustomSalesList.xEventHandler1 = xEventDistributor(xFormControlDataModel.xFormControlFunction1.strName);
                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction2.strName) == false)
                                    xCustomSalesList.xEventHandler2 = xEventDistributor(xFormControlDataModel.xFormControlFunction2.strName);

                                m_xCustomForm.bAddControl(xCustomSalesList, xFormControlDataModel);
                            }
                            catch (Exception xException)
                            {
                                xException.strTraceError();
                            }
                            break;
                        case CustomControlTypeName.strPaymentList:
                            try
                            {
                                CustomPaymentList xCustomPaymentList = new CustomPaymentList(xFormControlDataModel);
                                xCustomPaymentList.TabIndex = m_iTabIndex++;

                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction1.strName) == false)
                                    xCustomPaymentList.xEventHandler1 = xEventDistributor(xFormControlDataModel.xFormControlFunction1.strName);
                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction2.strName) == false)
                                    xCustomPaymentList.xEventHandler2 = xEventDistributor(xFormControlDataModel.xFormControlFunction2.strName);

                                m_xCustomForm.bAddControl(xCustomPaymentList, xFormControlDataModel);
                            }
                            catch (Exception xException)
                            {
                                xException.strTraceError();
                            }
                            break;
                        case CustomControlTypeName.strAmountsTable:
                            try
                            {
                                CustomAmountsTable xCustomAmountsTable = new CustomAmountsTable(xFormControlDataModel);
                                xCustomAmountsTable.TabIndex = m_iTabIndex++;

                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction1.strName) == false)
                                    xCustomAmountsTable.xEventHandler1 = xEventDistributor(xFormControlDataModel.xFormControlFunction1.strName);
                                if (string.IsNullOrEmpty(xFormControlDataModel.xFormControlFunction2.strName) == false)
                                    xCustomAmountsTable.xEventHandler2 = xEventDistributor(xFormControlDataModel.xFormControlFunction2.strName);

                                m_xCustomForm.bAddControl(xCustomAmountsTable, xFormControlDataModel);
                            }
                            catch (Exception xException)
                            { 
                                xException.strTraceError();
                            }
                            break;
                        default:
                            break;
                    }
                    m_xCustomForm.ResumeLayout(false);
                }

                m_xCustomForm.bFocusNumPad();

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public override bool bReDrawFormControls()
        {
            try
            {
                while (m_xCustomForm.Controls.Count > 0)
                {
                    m_xCustomForm.Controls.RemoveAt(0);
                }

                m_xCustomForm.Controls.Clear();

                return bDrawFormControls() && base.bReDrawFormControls();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }
    }
}
