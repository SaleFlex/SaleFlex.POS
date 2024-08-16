using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class InfoBoxPriceLookUp : Form
    {
        public InfoBoxPriceLookUp()
        {
            InitializeComponent();
        }

        private void InfoBoxPriceLookUp_Load(object sender, EventArgs e)
        {
            vFocus();
        }

        private void button_Click(object sender, EventArgs e)
        {
            textBoxBarcode.Text += ((Control)sender).Text;

            vFocus();
        }

        private void buttonSpace_Click(object sender, EventArgs e)
        {
            textBoxBarcode.Text += " ";

            vFocus();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxBarcode.Text.Length >= 1)
                textBoxBarcode.Text = textBoxBarcode.Text.Remove(textBoxBarcode.Text.Length - 1);

            vFocus();
        }

        private void vPopulateComboBox(string prm_strText)
        {
            try
            {
                List<PluDataModel> xListPluDataModel = Dao.xGetInstance().xListGetPluPriceLookUp(prm_strText);
                if (xListPluDataModel != null)
                {
                    comboBoxProduct.Items.Clear();
                    foreach (PluDataModel xPluDataModel in xListPluDataModel)
                    {
                        foreach (PluBarcodeDataModel xPluBarcodeDataModel in xPluDataModel.xListPluBarcodeDataModel)
                        {
                            comboBoxProduct.Items.Add(string.Format("{0} [{1}] - {2} {3}", xPluDataModel.strName, xPluBarcodeDataModel.strBarcode, Convert.ToDecimal(xPluBarcodeDataModel.decSalePrice)/100, LabelTranslations.strGet("CurrencySymbol")));
                        }
                    }
                    comboBoxProduct.SelectedIndex = 0;
                }
                else
                {
                    comboBoxProduct.Items.Clear();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        private void vFocus()
        {
            textBoxBarcode.Focus();
            textBoxBarcode.Select(textBoxBarcode.Text.Length, 1);
        }

        private void textBoxBarcode_TextChanged(object sender, EventArgs e)
        {
            vFocus();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            vPopulateComboBox(textBoxBarcode.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxBarcode.Text = "";

            comboBoxProduct.Items.Clear();

            vFocus();
        }
    }
}
