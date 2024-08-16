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
    public partial class InputBoxDiscountSurcharge : Form
    {
        public bool m_bCancelFormClosing = false;

        public InputBoxDiscountSurcharge(int prm_iRate, bool prm_bIsDiscountInputBox = true)
        {
            InitializeComponent();

            if (prm_bIsDiscountInputBox == true)
            {
                labelRate.Text = LabelTranslations.strGet("DiscountRate");
            }
            else
            {
                labelRate.Text = LabelTranslations.strGet("SurchargeRate");
            }

            textBoxRate.Text = prm_iRate.ToString();
        }

        public int iRate
        {
            get
            {

            return int.Parse(textBoxRate.Text);

            }

          set
           {

            textBoxRate.Text =value.ToString();

          }

        }

        private void textBoxRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) /*&& (e.KeyChar != '.')*/)
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void InputBoxDiscountSurcharge_Load(object sender, EventArgs e)
        {
          BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
          ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
          
        }

        private void InputBoxDiscountSurcharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                m_bCancelFormClosing = true;
            }
        }
    }
}
