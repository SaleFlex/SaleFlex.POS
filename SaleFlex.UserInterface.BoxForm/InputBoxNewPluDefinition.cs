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
    public partial class InputBoxNewPluDefinition : Form
    {
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        private bool m_bCancelFormClosing = false;
        private List<PluDataModel> m_xListPluDataModel = new List<PluDataModel>();
        private List<DepartmentDataModel> m_xListDepartmentDataModel = new List<DepartmentDataModel>();
        private List<PluMainGroupDataModel> m_xListPluMainGroupDataModel = new List<PluMainGroupDataModel>();
        private PluDataModel m_xPluDataModel = null;

        public InputBoxNewPluDefinition()
        {
            InitializeComponent();
        }

        public PluDataModel xNewPluDataModel
        {
            get
            {
                return m_xPluDataModel;
            }
            set
            {
                m_xPluDataModel = value;
            }
        }

        public List<PluDataModel> xListPluDataModel
        {
            get
            {
                return m_xListPluDataModel;
            }
            set
            {
                m_xListPluDataModel = value;
            }


        }

        public List<DepartmentDataModel> xListDepartmentDataModel
        {
            get
            {
                return m_xListDepartmentDataModel;
            }
            set
            {
                m_xListDepartmentDataModel = value;
                comboBoxDepartmentId.Items.Clear();
                comboBoxDepartmentId.DataSource = m_xListDepartmentDataModel;
                comboBoxDepartmentId.DisplayMember = "strName";
                comboBoxDepartmentId.ValueMember = "iNo";
                comboBoxDepartmentId.SelectedIndex = 0;
            }
        }

        public List<PluMainGroupDataModel> xListPluMainGroupDataModel
        {
            get
            {
                return m_xListPluMainGroupDataModel;
            }
            set
            {
                m_xListPluMainGroupDataModel = value;
                comboBoxMainGroupNo.Items.Clear();
                comboBoxMainGroupNo.DataSource = m_xListPluMainGroupDataModel;
                comboBoxMainGroupNo.DisplayMember = "strName";
                comboBoxMainGroupNo.ValueMember = "lNo";
                comboBoxMainGroupNo.SelectedIndex = 0;
            }
        }

        public int iDepartmentId
        {
            get
            {
                return int.Parse(comboBoxDepartmentId.SelectedValue.ToString());
            }
        }

        public int iPluMainGroupNo
        {
            get
            {
                return int.Parse(comboBoxMainGroupNo.SelectedValue.ToString());
            }
        }

        public string strPluCode
        {
            get
            {
                return maskedTextBoxPluCode.Text.PadLeft(6, '0');
            }
        }

        public string strPLUName
        {
            get
            {
                return textBoxPLUName.Text;
            }
        }

        public long decPLUPrice
        {
            get
            {
                return long.Parse(textBoxPLUPrice.Text.Replace(".", ","), System.Globalization.NumberStyles.AllowDecimalPoint);
            }
        }

        public decimal decPriceLimitation
        {
            get
            {
                return decimal.Parse(textBoxPLUPriceLimitation.Text.Replace(".", ","), System.Globalization.NumberStyles.AllowDecimalPoint);
            }
        }

        public int iQuantity
        {
            get
            {
                return int.Parse(textBoxPLUProductQuantity.Text.Replace(".", ","), System.Globalization.NumberStyles.AllowDecimalPoint);
            }
        }

        public string strBarcode
        {
            get
            {
                return textBoxBarcode.Text;
            }
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


        private void InputBoxNewPluDefinition_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void InputBoxNewPluDefinition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }

        private void maskedTextBoxPluCode_Leave(object sender, EventArgs e)
        {
            if (maskedTextBoxPluCode.Text.iConvertToInt() > 200000)
            {
                CustomMessageBox.Show(LabelTranslations.strGet("PluMaxWarning"), MessageBoxButtons.OK);
                maskedTextBoxPluCode.Focus();
                return;
            }

            foreach (PluDataModel xPluDataModel in xListPluDataModel)
            {
                if (xPluDataModel.strCode == strPluCode)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("PluExistWarning"), MessageBoxButtons.OK);
                    maskedTextBoxPluCode.Focus();
                    return;
                }
            }

        }

        private void maskedTextBoxPluCode_Click(object sender, EventArgs e)
        {
            maskedTextBoxPluCode.Select(maskedTextBoxPluCode.Text.Length, 0);
        }

        private void comboBoxDepartmentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPLUPriceLimitation.Text = ((DepartmentDataModel)comboBoxDepartmentId.SelectedItem).decMaxPrice.ToString();
        }

        private void textBoxBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && textBoxBarcode.Text.Length >= CommonProperty.prop_iBarcodeLength)
                e.Handled = true;
            else if (e.KeyChar.bIsDigit() != true && e.KeyChar != '\b')
                e.Handled = true;
        }

    }
}

