using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;
using SaleFlex.UserInterface.Constanst;

namespace SaleFlex.UserInterface.Controls
{
    public class CustomMaskedTextBox : MaskedTextBox, ICustomControl
    {
        public string m_strInputType = string.Empty;
        private ICustomKeyboard m_xCustomKeyboard = null;
        private string m_strBackupText = string.Empty;
        private ToolTip m_xToolTip = new ToolTip();
        private FormControlDataModel xFormControlsDataModel;

        public Boolean bTriggerEvents = true;

        private const int EM_SHOWBALLOONTIP = 0x1503;

        protected override void WndProc(ref Message prm_xMessage)
        {
            if (prm_xMessage.Msg == EM_SHOWBALLOONTIP)
            {
                prm_xMessage.Result = (IntPtr)0;
                return;
            }
            base.WndProc(ref prm_xMessage);
        }

        public CustomMaskedTextBox(FormControlDataModel prm_xFormControlDataModel)
        {
            xFormControlsDataModel = prm_xFormControlDataModel;
            vInitializeCustomTextBoxComponents(prm_xFormControlDataModel);
        }

        public void vInitializeCustomTextBoxComponents(FormControlDataModel prm_xFormControlsDataModel)
        {
            ((Control)this).bSetControlCommonProperties(prm_xFormControlsDataModel);

            Multiline = false;


            if (Text != string.Empty && prm_xFormControlsDataModel.strTextAlignment != string.Empty)
            {
                switch (prm_xFormControlsDataModel.strTextAlignment)
                {
                    case "CENTER":
                        TextAlign = HorizontalAlignment.Center;
                        break;
                    case "LEFT":
                        TextAlign = HorizontalAlignment.Left;
                        break;
                    case "RIGHT":
                        TextAlign = HorizontalAlignment.Right;
                        break;
                    default:
                        TextAlign = HorizontalAlignment.Left;
                        break;
                }
            }

            bSetTextFromPropertyValue();

            m_strInputType = prm_xFormControlsDataModel.strInputType;
        }

        private bool bSetTextFromPropertyValue()
        {
            try
            {
                if (strName == CustomControlName.strLogin)
                {
                    Text = CommonProperty.prop_strLastLoginUserName;
                }
                else if (strName == CustomControlName.strPassword || strName == CustomControlName.strAdminPassword)
                {
                    UseSystemPasswordChar = true;
                    //Text = CommonProperty.strLastLoginPassword;
                }
                else if (strName == CustomControlName.strBarcodeLength)
                {
                    Text = string.Format("{0}", CommonProperty.prop_iBarcodeLength);
                }
                else if (strName == CustomControlName.strImageFolder)
                {
                    Text = CommonProperty.prop_strImagesFolder;
                }
                else if (strName == CustomControlName.strDebugModeState)
                {
                    Text = string.Format("{0}", CommonProperty.prop_bIsDebugModeActive);
                }
                else if (strName == CustomControlName.strIsoCultureName)
                {
                    Text = CommonProperty.prop_strIsoCultureName;
                }
                else if (strName == CustomControlName.strLicenseOwner)
                {
                    Text = CommonProperty.prop_strLicenseOwner;
                }
                else if (strName == CustomControlName.strWaitAfterReceipt)
                {
                    Text = string.Format("{0}", CommonProperty.prop_iWaitAfterReceiptClosed);
                }
                else if (strName == CustomControlName.strDatabasePosFileName)
                {
                    Text = CommonProperty.prop_strDatabasePosFileName;
                }
                else if (strName == CustomControlName.strDatabaseSaleFileName)
                {
                    Text = CommonProperty.prop_strDatabaseSalesFileName;
                }
                else if (strName == CustomControlName.strBackColorDepartment)
                {
                    Text = CommonProperty.prop_strDepartmentBackColor;
                }
                else if (strName == CustomControlName.strBackColorFunction)
                {
                    Text = CommonProperty.prop_strFunctionBackColor;
                }
                else if (strName == CustomControlName.strBackColorMessageBox)
                {
                    Text = CommonProperty.prop_strMessageBoxBackColor;
                }
                else if (strName == CustomControlName.strBackColorPayment)
                {
                    Text = CommonProperty.prop_strPaymentBackColor;
                }
                else if (strName == CustomControlName.strBackColorPlu)
                {
                    Text = CommonProperty.prop_strPluBackColor;
                }
                else if (strName == CustomControlName.strBackColorTotal)
                {
                    Text = CommonProperty.prop_strTotalBackColor;
                }

                SelectionStart = Text.Length;
                ScrollToCaret();
                Refresh();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                 return false;
            }

            return true;
        }

        private bool m_bOnGotFocus = false;

        delegate void OnGotFocusDelegate(EventArgs xEventArgs);
        protected override void OnGotFocus(EventArgs xEventArgs)
        {
            if (bTriggerEvents == false) return;
            if (this.InvokeRequired == true)
            {
                this.Invoke(new OnGotFocusDelegate(OnGotFocus), xEventArgs);
                return;
            }

            try
            {
                if (m_bOnGotFocus == false)
                {
                    m_bOnGotFocus = true;

                    m_strBackupText = Text;

                    int iX = 0;
                    int iY = 0;

                    if (m_strInputType == "NUMERIC")
                    {
                        iX = (Location.X + Parent.FindForm().Location.X + Width / 2) - (230 / 2);

                        //iX += Parent.FindForm().Location.X;

                        if (1024 - iX < 230)
                            iX -= (iX + 230) - 1024;
                        
                        iY = Parent.FindForm().Location.Y + Location.Y + Height +12;

                        if (768 - iY < 255)
                            iY = Parent.FindForm().Location.Y + Location.Y + 12 - 255;

                        m_xCustomKeyboard = new CustomNumericKeyboard();
                        m_xCustomKeyboard.Location = new Point(iX, iY);

                        m_xCustomKeyboard.eventNewKey += new delegate_vNewKey(vNewKey);

                        m_xCustomKeyboard.ShowDialog();
                    }
                    else if (m_strInputType == "ALPHANUMERIC")
                    {
                        iX = (Location.X + Parent.FindForm().Location.X + Width / 2) - (765 / 2);

                        if (1024 - iX < 765)
                            iX -= (iX + 765) - 1024;

                        iY = Parent.FindForm().Location.Y + Location.Y + Height + 12;

                        if (768 - iY < 255)
                            iY = Parent.FindForm().Location.Y + Location.Y + 12 - 255;

                        m_xCustomKeyboard = new CustomAlphanumericKeyboard();
                        m_xCustomKeyboard.Location = new Point(iX, iY);

                        m_xCustomKeyboard.eventNewKey += new delegate_vNewKey(vNewKey);

                        m_xCustomKeyboard.ShowDialog();
                    }

                    //if (Text.Length > 0)
                    //    m_xToolTip.Show(Text, this, Location.X, Location.Y - 10);

                    base.OnGotFocus(xEventArgs);

                    //Parent.SelectNextControl(this, true, true, true, true);

                    m_bOnGotFocus = false;
                }

            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        delegate void OnClickDelegate(EventArgs xEventArgs);
        protected override void OnClick(EventArgs xEventArgs)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new OnClickDelegate(OnClick), xEventArgs);
                return;
            }

            SelectionStart = Text.Length;
            ScrollToCaret();
            Refresh();

            OnGotFocus(xEventArgs);

            base.OnClick(xEventArgs);
        }

        delegate void vNewKeyDelegate(NewKeyEventArgs prm_xNewKeyEventArgs);
        void vNewKey(NewKeyEventArgs prm_xNewKeyEventArgs)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new vNewKeyDelegate(vNewKey), prm_xNewKeyEventArgs);
                return;
            }

            if (prm_xNewKeyEventArgs.strValue != string.Empty)
            {
                Text += prm_xNewKeyEventArgs.strValue;
            }
            else if (prm_xNewKeyEventArgs.strFunction != string.Empty)
            {
                switch (prm_xNewKeyEventArgs.strFunction)
                {
                    case "DELETE":
                        if (Text.Length > 0)
                            Text = Text.Substring(0, Text.Length - 1);
                        break;
                    case "OK":
                        break;
                    case "CANCEL":
                        Text = m_strBackupText;
                        break;
                }
            }
        }

        public string strName { get; set; }
        public string strType { get; set; }
        public string strFunction1 { get; set; }
        public string strFunction2 { get; set; }
        public EventHandler xEventHandler1 { get; set; }
        public EventHandler xEventHandler2 { get; set; }

        public void vOnEvent1(object prm_objObject, EventArgs prm_xEventArgs)
        {
            if (xEventHandler1 != null)
                xEventHandler1(prm_objObject, prm_xEventArgs);
        }

        public void vOnEvent2(object prm_objObject, EventArgs prm_xEventArgs)
        {
            if (xEventHandler2 != null)
                xEventHandler2(prm_objObject, prm_xEventArgs);
        }
    }
}
