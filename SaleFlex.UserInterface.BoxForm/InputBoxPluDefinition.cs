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
    public partial class InputBoxPluDefinition : Form
    {
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        private bool m_bCancelFormClosing = false;
        private List<PluDataModel> m_xListPluDataModel = new List<PluDataModel>();
        private List<DepartmentDataModel> m_xListDepartmentDataModel = new List<DepartmentDataModel>();
        private List<PluMainGroupDataModel> m_xListPluMainGroupDataModel = new List<PluMainGroupDataModel>();
        private PluDataModel m_xPluDataModel = null;

        public InputBoxPluDefinition()
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
                comboBoxPluCode.Items.Clear();
                foreach (PluDataModel xPluDataModel in m_xListPluDataModel)
                {
                    comboBoxPluCode.Items.Add(string.Format("{0}", Convert.ToInt64(xPluDataModel.strCode)));
                }
                comboBoxPluCode.SelectedIndex = 0;
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
                comboBoxSubGroupNo.Items.Clear();
                comboBoxSubGroupNo.DataSource = m_xListDepartmentDataModel;
                comboBoxSubGroupNo.DisplayMember = "strName";
                comboBoxSubGroupNo.ValueMember = "iNo";
                comboBoxSubGroupNo.SelectedIndex = 0;
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
                return int.Parse(comboBoxSubGroupNo.SelectedValue.ToString());
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
                return comboBoxPluCode.Text.PadLeft(6, '0');
            }
        }

        public string strPLUName
        {
            get
            {
                return textBoxPLUName.Text;
            }
        }

        public decimal decPLUPrice
        {
            get
            {
                return decimal.Parse(textBoxPLUPrice.Text.Replace(".", ","), System.Globalization.NumberStyles.AllowDecimalPoint);
            }
        }

        public decimal decPriceLimitation
        {
            get
            {
                return decimal.Parse(textBoxPLUPriceLimitation.Text.Replace(".", ","), System.Globalization.NumberStyles.AllowDecimalPoint);
            }
        }

        public decimal iQuantity
        {
            get
            {
                return decimal.Parse(textBoxPLUProductQuantity.Text.Replace(".", ","), System.Globalization.NumberStyles.AllowDecimalPoint);
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

        private void comboBoxPluId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PluDataModel xPluDataModel = new PluDataModel();
                xPluDataModel = xListPluDataModel.Where(x => x.strCode == comboBoxPluCode.SelectedItem.ToString().PadLeft(6, '0')).FirstOrDefault();

                if (xPluDataModel != null)
                {
                    comboBoxSubGroupNo.SelectedValue = xPluDataModel.xPluSubGroupDataModel.iNo;
                    comboBoxMainGroupNo.SelectedValue = xPluDataModel.xPluSubGroupDataModel.xPluMainGroupDataModel.iNo;
                    textBoxPLUName.Text = xPluDataModel.strName;
                    textBoxPLUPrice.Text = xPluDataModel.xListPluBarcodeDataModel[0].decSalePrice.ToString();
                    textBoxPLUPriceLimitation.Text = xPluDataModel.xPluSubGroupDataModel.xPluMainGroupDataModel.decMaxPrice.ToString();
                    textBoxBarcode.Text = xPluDataModel.xListPluBarcodeDataModel[0].strBarcode;
                    textBoxPLUProductQuantity.Text = ((decimal)(xPluDataModel.iStock) / 100).ToString();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        private void InputBoxPluDefinition_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void InputBoxPluDefinition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            InputBoxNewPluDefinition xInputBoxNewPluDefinition = new InputBoxNewPluDefinition();
            xInputBoxNewPluDefinition.xListPluDataModel = xListPluDataModel;
            xInputBoxNewPluDefinition.xListDepartmentDataModel = xListDepartmentDataModel;
            xInputBoxNewPluDefinition.xListPluMainGroupDataModel = xListPluMainGroupDataModel;

            m_bCancelFormClosing = false;
            this.DialogResult = DialogResult.None;

            if (xInputBoxNewPluDefinition.ShowDialog() == DialogResult.OK)
            {
                PluDataModel xPluDataModel = new PluDataModel();
                xPluDataModel.xPluSubGroupDataModel.iNo = xInputBoxNewPluDefinition.iDepartmentId;
                xPluDataModel.strCode = xInputBoxNewPluDefinition.strPluCode;
                xPluDataModel.strName = xInputBoxNewPluDefinition.strPLUName;
                xPluDataModel.xListPluBarcodeDataModel[0].decSalePrice = xInputBoxNewPluDefinition.decPLUPrice;
                xPluDataModel.xPluSubGroupDataModel.xPluMainGroupDataModel.decMaxPrice = xInputBoxNewPluDefinition.decPriceLimitation;
                xPluDataModel.iStock = xInputBoxNewPluDefinition.iQuantity * 100;
                xPluDataModel.xListPluBarcodeDataModel[0].strBarcode = xInputBoxNewPluDefinition.strBarcode;
                xPluDataModel.xPluSubGroupDataModel.xPluMainGroupDataModel.iId = xInputBoxNewPluDefinition.iPluMainGroupNo;
                xPluDataModel.xPluSubGroupDataModel.iId = 1;
                xPluDataModel.iId = 1;
                PluBarcodeDataModel xPluBarcodeDataModel = new PluBarcodeDataModel();
                xPluBarcodeDataModel.iId = 1;
                xPluBarcodeDataModel.iFkPluId = 1;
                xPluBarcodeDataModel.strBarcode = xInputBoxNewPluDefinition.strBarcode;
                xPluDataModel.xListPluBarcodeDataModel.Add(xPluBarcodeDataModel);
                xNewPluDataModel = xPluDataModel;
                this.DialogResult = DialogResult.Cancel;
            }


        }

        private void comboBoxDepartmentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPLUPriceLimitation.Text = ((DepartmentDataModel)comboBoxSubGroupNo.SelectedItem).lMaxPrice.ToString();
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

