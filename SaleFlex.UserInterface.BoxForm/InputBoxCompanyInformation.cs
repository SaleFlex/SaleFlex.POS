using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class InputBoxCompanyInformation : Form
    {
        private bool m_bCancelFormClosing = false;

        public InputBoxCompanyInformation()
        {
            InitializeComponent();
        }

        public string strNationalIdNumber
        {
            get
            {
                return textBoxNationalIdNumber.Text;
            }
            set
            {
                 textBoxNationalIdNumber.Text = value;
            }
        }

        public string strTaxIdNumber
        {
            get
            {
                return textBoxTaxIdNumber.Text;
            }
            set
            {
                textBoxTaxIdNumber.Text = value;
            }
        }

        public string strMersisIdNumber
        {
            get
            {
                return textBoxMersisIdNumber.Text;
            }
            set
            {
                textBoxMersisIdNumber.Text= value;
            }
        }

        public string strCompanyWebAddress
        {
            get
            {
                return textBoxCompanyWebAdress.Text;
            }
            set
            {
                textBoxCompanyWebAdress.Text = value;
            }
        }


        private void InputBoxCompanyInformation_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                m_bCancelFormClosing = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void InputBoxCompanyInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }

        private void textBoxNationalIdNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.bIsDigit() == false && e.KeyChar != '\b') e.Handled = true;

            if (string.Format("{0}{1}",textBoxNationalIdNumber.Text,e.KeyChar).Length > 11 && e.KeyChar != '\b') e.Handled = true; 
        }

        private void textBoxTaxIdNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.bIsDigit() == false && e.KeyChar != '\b') e.Handled = true;

            if (string.Format("{0}{1}", textBoxTaxIdNumber.Text, e.KeyChar).Length > 10 && e.KeyChar != '\b') e.Handled = true; 
        }

        private void textBoxMersisIdNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.bIsDigit() == false && e.KeyChar != '\b') e.Handled = true;

            if (string.Format("{0}{1}", textBoxMersisIdNumber.Text, e.KeyChar).Length > 16 && e.KeyChar != '\b') e.Handled = true; 
        }
    }
}
