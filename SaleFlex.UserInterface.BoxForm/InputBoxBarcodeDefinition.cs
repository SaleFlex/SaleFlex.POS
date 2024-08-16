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
    public partial class InputBoxBarcodeDefinition : Form
    {
     
        private bool m_bCancelFormClosing = false;

        private List<PluBarcodeDefinitionDataModel> m_xListPluBarcodeDefinitionDataModel = new List<PluBarcodeDefinitionDataModel>();

        public InputBoxBarcodeDefinition()
        {
            InitializeComponent();
            foreach (string strBarcodeStartingNumber in comboBoxBarcodeStartingNumber.Items)
            {
                PluBarcodeDefinitionDataModel xPluBarcodeDefinitionDataModel = new PluBarcodeDefinitionDataModel { strStartingDigits = strBarcodeStartingNumber };
                xListBarcodeDataModel.Add(xPluBarcodeDefinitionDataModel);
            }
        }

        public List<PluBarcodeDefinitionDataModel> xListBarcodeDataModel
        {
            get
            {
                return m_xListPluBarcodeDefinitionDataModel;
            }
            set
            {
                m_xListPluBarcodeDefinitionDataModel = value;
                comboBoxBarcodeStartingNumber.Items.Clear();

                foreach (PluBarcodeDefinitionDataModel xPluBarcodeDefinitionDataModel in m_xListPluBarcodeDefinitionDataModel)
                {
                    comboBoxBarcodeStartingNumber.Items.Add(xPluBarcodeDefinitionDataModel.strStartingDigits);
                }

                comboBoxBarcodeStartingNumber.SelectedIndex = 0;
            }
        }

        public string strBarcodeStartingNumber
        {
            get
            {
                return comboBoxBarcodeStartingNumber.Text;
            }
        }

        public string strBarcodeDefinition
        {
            get
            {
                return textBoxLengthOfProductCode.Text;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                m_bCancelFormClosing = true;
            }
        }

        

        private void InputBoxBarcodeDefinition_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
        }

        private void comboBoxBarcodeStartingNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PluBarcodeDefinitionDataModel xPluBarcodeDefinitionDataModel = new PluBarcodeDefinitionDataModel();
                xPluBarcodeDefinitionDataModel = xListBarcodeDataModel.Where(x => x.strStartingDigits == (string)comboBoxBarcodeStartingNumber.SelectedItem).FirstOrDefault();
                textBoxLengthOfProductCode.Text = string.Empty;

                if (xPluBarcodeDefinitionDataModel != null)
                {
                    textBoxLengthOfProductCode.Text = xPluBarcodeDefinitionDataModel.strStartingDigits;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }


        private void textBoxBarcodeType_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxLengthOfProductCode.Select(textBoxLengthOfProductCode.Text.Length, 0);
            if (strBarcodeDefinition.Length == 0)
            {
                if (e.KeyChar != (char)67)  e.Handled = true;
                else e.Handled = false;  
            }
    
            else
            {
                string strLastChar = (strBarcodeDefinition).Substring(strBarcodeDefinition.Length - 1, 1);

                if (e.KeyChar != (char)67 && e.KeyChar != (char)81 && e.KeyChar != ',' && e.KeyChar != (char)127 && e.KeyChar != (char)8){e.Handled = true;}
        
                else
                {
                    if (strBarcodeDefinition.Length == 10 && strBarcodeDefinition.Contains(',') == false && e.KeyChar != (char)127 && e.KeyChar != (char)8 || strLastChar == "Q" && e.KeyChar == (char)67 || e.KeyChar == ',' && strBarcodeDefinition.Contains(',') || strLastChar == "C" && e.KeyChar != (char)81 && e.KeyChar != (char)8 && e.KeyChar != (char)67 || strLastChar == "," && e.KeyChar != (char)81 && e.KeyChar != (char)127 && e.KeyChar != (char)8) e.Handled = true;
                    else e.Handled = false;
                }
            }
        }

        private void InputBoxBarcodeDefinition_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
         
        }

      
        
    }
}

