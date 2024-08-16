using System;
using System.Collections.Generic;
using System.Windows.Forms;

using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class InputBoxSetupParameter : Form
    {

        private bool m_bCancelFormClosing = false;

        private List<PluBarcodeDefinitionDataModel> m_xListPluBarcodeDefinitionDataModel = new List<PluBarcodeDefinitionDataModel>();

        public InputBoxSetupParameter()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }



        private void InputBoxSetupParameter_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void InputBoxSetupParameter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
            if (this.DialogResult == DialogResult.Cancel)
                Application.Exit();

        }
        public long lPosId
        {
            get
            {
                return int.Parse(textBoxPosId.Text);
            }
        }
        public long lMerchantId
        {
            get
            {
                return int.Parse(textBoxMerchantId.Text);
            }
        }
        public int iStoreNo
        {
            get
            {
                return int.Parse(textBoxStoreNo.Text);
            }
        }

        public string strIpPort
        {
            get
            {
                return textBoxIpPort.Text;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

    }
}

