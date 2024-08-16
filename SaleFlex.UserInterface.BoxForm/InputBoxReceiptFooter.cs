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
    public partial class InputBoxReceiptFooter : Form
    {
        private bool m_bCancelFormClosing = false;

        public InputBoxReceiptFooter()
        {
            InitializeComponent();

        }

        public string strFooterLine1
        {
            get
            {
                return textBoxFooterLine1.Text;
            }

            set
            {
                textBoxFooterLine1.Text = value;

            }
        }

        public string strFooterLine2
        {
            get
            {
                return textBoxFooterLine2.Text;
            }
            set
            {
                textBoxFooterLine2.Text = value;
            }
        }

        public string strFooterLine3
        {
            get
            {
                return textBoxFooterLine3.Text;
            }
            set
            {
                textBoxFooterLine3.Text = value;
            }
        }

        public string strFooterLine4
        {
            get
            {
                return textBoxFooterLine4.Text;
            }
            set
            {
                textBoxFooterLine4.Text = value;
            }
        }

        public string strFooterLine5
        {
            get
            {
                return textBoxFooterLine5.Text;
            }
            set
            {
                textBoxFooterLine5.Text = value;
            }
        }

        private List<string> strListFooterLines = new List<string>();

        public List<string> xListFooterLines
        {
            get
            {
                return strListFooterLines;

            }
            set
            {
                strListFooterLines = value;
            }
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                m_bCancelFormClosing = true;
            }

        }

        private void InputBoxReceiptFooter_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void InputBoxReceiptFooter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }
    }
}
