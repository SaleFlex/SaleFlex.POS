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
using SaleFlex.Data.AccessLayer;
using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class InputBoxVatDefinition : Form
    {
        private List<VatDataModel> m_xListVatDataModel = new List<VatDataModel>();
        private bool m_bCancelFormClosing = false;
        private bool m_bCheckVatRate = false;
        private bool m_bCheckVatRate1 = false;
        private bool m_bCheckVatRate2 = false;

        public bool bCheckVatRate
        {
            get { return m_bCheckVatRate; }
            set { m_bCheckVatRate = value; }
        }
        public bool bCheckVatRate1
        {
            get { return m_bCheckVatRate1; }
            set { m_bCheckVatRate1 = value; }
        }

        public bool bCheckVatRate2
        {
            get { return m_bCheckVatRate2; }
            set { m_bCheckVatRate2 = value; }
        }



        public InputBoxVatDefinition()
        {
            InitializeComponent();
        }
        public List<VatDataModel> xListVatDataModel
        {
            get
            {
                return m_xListVatDataModel;
            }
            set
            {
                m_xListVatDataModel = value;
            }
        }
        public int iVATId
        {
            get
            {
                return int.Parse(comboBoxVATId.Text);
            }
        }

        public string strVATRate
        {
            get
            {
                return textBoxVATRate.Text;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            bCheckVatRate = false;
            bCheckVatRate1 = false;
            bCheckVatRate2 = false;

            if (xListVatDataModel.Where(x => x.iNo.ToString() == comboBoxVATId.SelectedItem.ToString()).FirstOrDefault().iRate.ToString() == textBoxVATRate.Text)
            {
                bCheckVatRate = true;
            }

            if (strVATRate.iConvertToInt() > 99 || strVATRate.iConvertToInt() < 1)
            {
                bCheckVatRate1 = true;
                CustomMessageBox.Show(LabelTranslations.strGet("VatSetError1"));
            }

            foreach (var xVat in Dao.xGetInstance().xListGetVats())
            {
                if (strVATRate.iConvertToInt() == xVat.iRate && bCheckVatRate == false)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("VatSetError"));
                    bCheckVatRate2 = true;
                }
            }
            if (bCheckVatRate1 == false && bCheckVatRate2 == false && bCheckVatRate == false)
            {
                if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    m_bCancelFormClosing = true;
                }
            }
        }

        private void InputBoxVatDefinition_Load(object sender, EventArgs e)
        {
            comboBoxVATId.SelectedIndex = 0;
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void comboBoxVATId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xListVatDataModel.Where(x => x.iNo.ToString() == comboBoxVATId.SelectedItem.ToString()).FirstOrDefault() != null)
            {
                textBoxVATRate.Text = xListVatDataModel.Where(x => x.iNo.ToString() == comboBoxVATId.SelectedItem.ToString()).FirstOrDefault().iRate.ToString();
            }
            else
            {
                textBoxVATRate.Text = string.Empty;
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
        }

        private void InputBoxVatDefinition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }
    }
}
