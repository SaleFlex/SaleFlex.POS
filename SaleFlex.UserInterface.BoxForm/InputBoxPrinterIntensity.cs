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
    public partial class InputBoxPrinterIntensity : Form
    {
        private bool m_bCancelFormClosing = false;

        public InputBoxPrinterIntensity()
        {
            InitializeComponent();
        }

        public int iPrinterIntensity
        {
            get
            {
                return int.Parse(textBoxPrinterIntensity.Text);
            }
            set
            {
                textBoxPrinterIntensity.Text = value.ToString();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                m_bCancelFormClosing = true;
            }
        }

        private void InputBoxPrinterIntensity_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
          
        }

        private void InputBoxPrinterIntensity_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }
    }
}

