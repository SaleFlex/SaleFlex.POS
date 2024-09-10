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
    public partial class InputBoxCurrencyDefiniton : Form
    {
        private bool m_bCancelFormClosing = false;
        private List<CurrencyDataModel> m_xListCurrencyDataModel = new List<CurrencyDataModel>();

        public InputBoxCurrencyDefiniton()
        {
            InitializeComponent();
        }

        public List<CurrencyDataModel> xListCurrencyDataModel
        {
            get
            {
                return m_xListCurrencyDataModel;
            }
            set
            {
                m_xListCurrencyDataModel = value;
            }
        }

        public int iCurrencyId
        {
            get
            {
                return int.Parse(comboBoxCurrencyId.Text);
            }
            set
            {
                comboBoxCurrencyId.Text = value.ToString();
            }
        }

        public string strCurrencyName
        {
            get
            {
                return textBoxCurrencyName.Text;
            }
            set
            {
                textBoxCurrencyName.Text = value;
            }
        }

        public decimal decRateOfCurrency
        {
            get
            {
                try
                {
                    return decimal.Parse(textBoxRateOfCurrency.Text.Replace(".", ","), System.Globalization.NumberStyles.AllowDecimalPoint);
                }
                catch
                {
                    return 0.00M;
                }
            }
            set
            {
                textBoxRateOfCurrency.Text = value.ToString();
            }
        }

        public string strCurrencySymbol
        {
            get
            {
                return textBoxCurrencySymbol.Text;
            }
            set
            {
                textBoxCurrencySymbol.Text = value.ToString();
            }
        }

        public int iCurrencyCode
        {
            get
            {
                return Convert.ToInt32(textBoxCurrencyCode.Text);
            }
            set
            {
                textBoxCurrencyCode.Text = value.ToString();
            }
        }

        public string strCurrencySign
        {
            get
            {
                return textBoxCurrencySign.Text;
            }
            set
            {
                textBoxCurrencySign.Text = value;
            }
        }

        public string strCurrencySignDirection
        {
            get
            {
                return comboBoxCurrencySignDirection.Text;
            }
            set
            {
                comboBoxCurrencySignDirection.Text = value;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                m_bCancelFormClosing = true;
            }
        }

        private void comboBoxCurrencyId_SelectedIndexChanged(object sender, EventArgs e)
        {
            vGetCurrencyDataModelDetails();
        }

        private void vGetCurrencyDataModelDetails()
        {
            CurrencyDataModel xCurrencyDataModel = new CurrencyDataModel();
            xCurrencyDataModel = xListCurrencyDataModel.Where(x => x.iNo.ToString() == comboBoxCurrencyId.SelectedItem.ToString()).FirstOrDefault();

            textBoxCurrencyName.Text = string.Empty;
            textBoxRateOfCurrency.Text = string.Empty;
            textBoxCurrencyCode.Text = string.Empty;
            textBoxCurrencySymbol.Text = string.Empty;
            textBoxCurrencySign.Text = string.Empty;
            comboBoxCurrencySignDirection.SelectedIndex = -1;
            if (xCurrencyDataModel != null)
            {
                textBoxCurrencyName.Text = xCurrencyDataModel.strName;
                textBoxRateOfCurrency.Text = xCurrencyDataModel.lRateOfCurrency.ToString();
                textBoxCurrencyCode.Text = xCurrencyDataModel.iCurrencyCode.ToString();
                textBoxCurrencySymbol.Text = xCurrencyDataModel.strCurrencySymbol;
                textBoxCurrencySign.Text = xCurrencyDataModel.strSign;
                comboBoxCurrencySignDirection.SelectedItem = xCurrencyDataModel.strSignDirection.Trim();
            }
        }

        private void InputBoxCurrencyDefiniton_Load(object sender, EventArgs e)
        {

            comboBoxCurrencyId.SelectedIndex = 0;
            vGetCurrencyDataModelDetails();

            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
          
        }

        private void InputBoxCurrencyDefiniton_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }
      
    }
}
