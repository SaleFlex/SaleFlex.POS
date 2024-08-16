using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;

namespace SaleFlex.UserInterface.Controls
{
    public partial class CustomNumpad : UserControl, ICustomControl
    {
        private string m_strFunction1Name = string.Empty;
        private bool m_bIsGetPriceModeActive = false;
        private double m_dResizedWidth = 0;
        private double m_dResizedHeight = 0;
        private int m_iNumpadHeight = 0;
        private int m_iNumpadWidth = 0;
        public static bool m_bCustomMessageBoxIsActive = false;
        FormControlDataModel xFormControlsDataModel = null;

        public CustomNumpad(FormControlDataModel prm_xFormControlDataModel)
        {
            InitializeComponent();
            vInitializeCustomComponents(prm_xFormControlDataModel);
            xFormControlsDataModel = prm_xFormControlDataModel;
        }

        public void vInitializeCustomComponents(FormControlDataModel prm_xFormControlDataModel)
        {
            ((Control)this).bSetControlCommonProperties(prm_xFormControlDataModel);

            buttonZero.BackColor = BackColor;
            buttonOne.BackColor = BackColor;
            buttonTwo.BackColor = BackColor;
            buttonThree.BackColor = BackColor;
            buttonFour.BackColor = BackColor;
            buttonFive.BackColor = BackColor;
            buttonSix.BackColor = BackColor;
            buttonSeven.BackColor = BackColor;
            buttonEight.BackColor = BackColor;
            buttonNine.BackColor = BackColor;
            buttonComma.BackColor = BackColor;

            buttonZero.ForeColor = ForeColor;
            buttonOne.ForeColor = ForeColor;
            buttonTwo.ForeColor = ForeColor;
            buttonThree.ForeColor = ForeColor;
            buttonFour.ForeColor = ForeColor;
            buttonFive.ForeColor = ForeColor;
            buttonSix.ForeColor = ForeColor;
            buttonSeven.ForeColor = ForeColor;
            buttonEight.ForeColor = ForeColor;
            buttonNine.ForeColor = ForeColor;
            buttonComma.ForeColor = ForeColor;

            textBoxOuput.SelectionLength = 0;
            m_strFunction1Name = prm_xFormControlDataModel.xFormControlFunction1.strName;
            if (prm_xFormControlDataModel.strCaption1.Length > 0)
                buttonOk.Text = prm_xFormControlDataModel.strCaption1;
        }

        public string strNumPadOutput
        {
            get
            {
                return textBoxOuput.Text;
            }
            set
            {
                textBoxOuput.Text = value;
            }
        }

        public bool bIsGetPriceModeActive
        {
            set
            {
                m_bIsGetPriceModeActive = value;
            }
            get
            {
                return m_bIsGetPriceModeActive;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            vFocusOnOutputTextBox();
            vInvokeExternalEvent(e, false);
        }

        delegate void vNewKeyDelegate(string prm_strValue, string prm_strFunction);
        void vNewKey(string prm_strValue, string prm_strFunction)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new vNewKeyDelegate(vNewKey), prm_strValue, prm_strFunction);
                return;
            }

            if (prm_strValue != string.Empty)
            {
                textBoxOuput.Text += prm_strValue;
            }
            else if (prm_strFunction != string.Empty)
            {
                switch (prm_strFunction)
                {
                    case "DELETE":
                        if (textBoxOuput.Text.Length > 0)
                        {
                            textBoxOuput.Text = textBoxOuput.Text.Substring(0, textBoxOuput.Text.Length - 1);
                        }
                        break;
                    case "OK":
                        break;
                    case "CLEAR":
                        textBoxOuput.Text = "";
                        if (xEventHandlerClearBuffer != null)
                            xEventHandlerClearBuffer.Invoke(this, new EventArgs());
                        break;
                }
            }

            vFocusOnOutputTextBox();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            vNewKey(string.Empty, "DELETE");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            vNewKey(string.Empty, "CLEAR");
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            if (textBoxOuput.Text.Length > 0 && textBoxOuput.Text.IndexOf("X") < 0)
            {
                vNewKey("X", string.Empty);
            }
            vFocusOnOutputTextBox();
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            if (textBoxOuput.Text.IndexOf(",") < 0)
            {
                vNewKey(",", string.Empty);
            }
            vFocusOnOutputTextBox();
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            vNewKey("1", string.Empty);
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            vNewKey("2", string.Empty);
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            vNewKey("3", string.Empty);
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            vNewKey("4", string.Empty);
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            vNewKey("5", string.Empty);
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            vNewKey("6", string.Empty);
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            vNewKey("7", string.Empty);
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            vNewKey("8", string.Empty);
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            vNewKey("9", string.Empty);
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            vNewKey("0", string.Empty);
        }

        private void textBoxOuput_TextChanged(object sender, EventArgs e)
        {
            vFocusOnOutputTextBox();
            vInvokeExternalEvent(e);
        }

        private void vInvokeExternalEvent(EventArgs e, bool prm_bForce = true)
        {
            if (prm_bForce == false && m_bCustomMessageBoxIsActive == false)
            {
                if (m_bIsGetPriceModeActive == true)
                {
                    if (xEventHandlerGetPrice != null)
                        xEventHandlerGetPrice.Invoke(this, e);
                }
                else
                {
                    if (xEventHandler1 != null)
                        xEventHandler1.Invoke(this, e);
                }

                m_bIsGetPriceModeActive = false;
                vFocusOnOutputTextBox();
                return;
            }

            CustomNumpad.m_bCustomMessageBoxIsActive = false;
            vFocusOnOutputTextBox();
        }

        private void vFocusOnOutputTextBox()
        {
            textBoxOuput.Focus();
            textBoxOuput.Select(textBoxOuput.Text.Length, 0);
        }

        public EventHandler xEventHandlerGetPrice { get; set; }
        public EventHandler xEventHandlerClearBuffer { get; set; }

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

            vFocusOnOutputTextBox();
        }

        public void vOnEvent2(object prm_objObject, EventArgs prm_xEventArgs)
        {
            if (xEventHandler2 != null)
                xEventHandler2(prm_objObject, prm_xEventArgs);

            vFocusOnOutputTextBox();
        }

        private void CustomNumpad_Enter(object prm_objObject, EventArgs e)
        {
            vFocusOnOutputTextBox();
        }

        private void textBoxOuput_KeyDown(object prm_objObject, KeyEventArgs prm_xKeyEventArgs)
        {
            vFocusOnOutputTextBox();
        }

        public KeyPressEventHandler xExternalKeyPressEventHandler { get; set; }
        public KeyEventHandler xExternalKeyEventHandler { get; set; }

        private void textBoxOuput_KeyPress(object prm_objObject, KeyPressEventArgs prm_xKeyPressEventArgs)
        {
            if (prm_xKeyPressEventArgs.KeyChar.bIsDigit() == true || prm_xKeyPressEventArgs.KeyChar == ',' || prm_xKeyPressEventArgs.KeyChar == 13)
            {
                return;
            }

            if (xExternalKeyPressEventHandler != null)
                xExternalKeyPressEventHandler(prm_objObject, prm_xKeyPressEventArgs);

            prm_xKeyPressEventArgs.Handled = true;

            vFocusOnOutputTextBox();
        }

        private void textBoxOuput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                vInvokeExternalEvent(e, false);

            vFocusOnOutputTextBox();
        }

        private void CustomNumpad_Load(object sender, EventArgs e)
        {
            // Put values in the variables

            m_dResizedWidth = this.Width;
            m_dResizedHeight = this.Height;
            m_iNumpadWidth = this.Width;
            m_iNumpadHeight = this.Height;

            // Loop through the controls inside the  form i.e. Tabcontrol Container

            foreach (Control xControl in this.Controls)
            {
                xControl.Tag = xControl.Name + "/" + xControl.Left + "/" + xControl.Top + "/" + xControl.Width + "/" + xControl.Height + "/" + (int)xControl.Font.Size;

            }

            if (xFormControlsDataModel.iWidth >= this.Width)
                this.Width = xFormControlsDataModel.iWidth;
            if (xFormControlsDataModel.iHeight >= this.Height)
                this.Height = xFormControlsDataModel.iHeight;

            vResizeNumpad(this, true);
            vFocusOnOutputTextBox();
        }

        private void vResizeNumpad(Control xForm, bool hasTabs) // Routine to Auto resize the control
        {

            string[] saControlPropertiesArray = null;

            if (this.Width > m_iNumpadWidth || this.Height > m_iNumpadHeight)
            {
                m_iNumpadWidth = this.Width;
                m_iNumpadHeight = this.Height;

                return;
            }

            foreach (Control xControl in xForm.Controls)
            {

                double dWidthRatio = (xForm.Width > m_dResizedWidth ? xForm.Width / (m_dResizedWidth) : m_dResizedWidth / xForm.Width);
                double dHeightRatio = (xForm.Height > m_dResizedHeight ? xForm.Height / (m_dResizedHeight) : m_dResizedHeight / xForm.Height);

                saControlPropertiesArray = xControl.Tag.ToString().Split('/');
                if (xControl.Name == saControlPropertiesArray[0].ToString())
                {
                    //Use integer casting

                    xControl.Width = (int)(Convert.ToInt32(saControlPropertiesArray[3]) * dWidthRatio);
                    xControl.Height = (int)(Convert.ToInt32(saControlPropertiesArray[4]) * dHeightRatio);
                    xControl.Left = (int)(Convert.ToInt32(saControlPropertiesArray[1]) * dWidthRatio);
                    xControl.Top = (int)(Convert.ToInt32(saControlPropertiesArray[2]) * dHeightRatio);
                    xControl.Font = new Font(this.Font.FontFamily, (float)(Convert.ToInt32(saControlPropertiesArray[5]) * dHeightRatio));
                }
            }

            vFocusOnOutputTextBox();
        }
    }
}
