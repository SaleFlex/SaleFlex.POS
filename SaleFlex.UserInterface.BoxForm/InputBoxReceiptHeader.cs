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
    public partial class InputBoxReceiptHeader : Form
    {
        private bool m_bCancelFormClosing = false;

        public InputBoxReceiptHeader()
        {
            InitializeComponent();
        }

        public string strHeaderLine1
        {
            get
            {
                return textBoxHeaderLine1.Text;
            }

            set
            {

                textBoxHeaderLine1.Text = value;
            }
        }

        public string strHeaderLine2
        {
            get
            {
                return textBoxHeaderLine2.Text;
            }

            set
            {

                textBoxHeaderLine2.Text = value;
            }
        }

        public string strHeaderLine3
        {
            get
            {
                return textBoxHeaderLine3.Text;
            }
            set
            {

                textBoxHeaderLine3.Text = value;
            }

        }

        public string strHeaderLine4
        {
            get
            {
                return textBoxHeaderLine4.Text;
            }
            set
            {

                textBoxHeaderLine4.Text = value;
            }
        }

        public string strHeaderLine5
        {
            get
            {
                return textBoxHeaderLine5.Text;
            }
            set
            {

                textBoxHeaderLine5.Text = value;
            }
        }

        public string strHeaderLine6
        {
            get
            {
                return textBoxHeaderLine6.Text;
            }
            set
            {

                textBoxHeaderLine6.Text = value;
            }
        }

        public string strHeaderLine7
        {
            get
            {
                return textBoxHeaderLine7.Text;
            }
            set
            {

                textBoxHeaderLine7.Text = value;
            }
        }

        public string strHeaderLine8
        {
            get
            {
                return textBoxHeaderLine8.Text;
            }
            set
            {

                textBoxHeaderLine8.Text = value;
            }
        }

        public string strHeaderLine9
        {
            get
            {
                return textBoxHeaderLine9.Text;
            }
            set
            {

                textBoxHeaderLine9.Text = value;
            }
        }

        public string strHeaderLine10
        {
            get
            {
                return textBoxHeaderLine10.Text;
            }
            set
            {

                textBoxHeaderLine10.Text = value;
            }
        }


        private List<string> strListHeaderLines = new List<string>();

        public List<string> xListHeaderLines
        {
            get
            {
                return strListHeaderLines;

            }
            set
            {
                strListHeaderLines = value;
            }
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            //strListHeaderLines[0]=  strHeaderLine1;
            //strListHeaderLines[1] = strHeaderLine2;
            //strListHeaderLines[2] = strHeaderLine3;
            //strListHeaderLines[3] = strHeaderLine4;
            //strListHeaderLines[4] = strHeaderLine5;
            //strListHeaderLines[5] = strHeaderLine6;
            //strListHeaderLines[6] = strHeaderLine7;
            //strListHeaderLines[7] = strHeaderLine8;
            //strListHeaderLines[8] = strHeaderLine9;
            //strListHeaderLines[9] = strHeaderLine10;

            if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                m_bCancelFormClosing = true;
            }
        }

        private void InputBoxReceiptHeader_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void InputBoxReceiptHeader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }
    }
}
