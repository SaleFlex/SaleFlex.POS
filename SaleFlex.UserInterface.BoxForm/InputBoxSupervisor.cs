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
    public partial class InputBoxSupervisor : Form
    {
        private bool m_bCancelFormClosing = false;



        public InputBoxSupervisor(string prm_iSupervisorPassword)
        {
            InitializeComponent();

            textBoxSupervisorPassword.Text = prm_iSupervisorPassword;

        }



        public string strSupervisorPassword
        {
            get
            {
                return textBoxSupervisorPassword.Text;
            }
            set
            {

                textBoxSupervisorPassword.Text = value;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                m_bCancelFormClosing = true;
            }
        }

        private void InputBoxDepartmentDefinition_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void InputBoxSupervisor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }

        private void textBoxSupervisorPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.bIsDigit() == true) return;
            else e.Handled = true;
        }
    }
}
