using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SaleFlex.CommonLibrary;
using SaleFlex.Data.AccessLayer;
using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Data;
using SaleFlex.Data;
using SaleFlex.POS.Device.Manager;
using SaleFlex.Windows;
using SaleFlex.POS.Manager;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class InfoBoxShortCutMenu : CustomForm
    {
        private CustomForm m_xCustomForm = null;
        private string m_strFormName = string.Empty;
        public InfoBoxShortCutMenu()
        {
            drawButton();
            InitializeComponent();
        }

        private void InfoBoxShortCutMenu_Load(object sender, EventArgs e)
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

        private void vPopulateComboBox(string prm_strText)
        {
            Dictionary<string, string> dictionaryProduct = null;
            comboBoxProduct.DataSource = null;
            comboBoxProduct.Items.Clear();
            List<PluSearchDataModel> xListPluSearchDataModel = null;
           
            try
            {
                if (prm_strText == string.Empty)
                {
                    comboBoxProduct.Items.Clear();
                    return;
                }
                xListPluSearchDataModel = Dao.xGetInstance().xListGetBarcodeData(prm_strText);
                if (xListPluSearchDataModel != null)
                {
                    comboBoxProduct.Items.Clear();
                     dictionaryProduct = new Dictionary<string, string>();

                    foreach (PluSearchDataModel xPluDataModel in xListPluSearchDataModel)
                    {
                        var a = string.Format("{0} {1} {2} {3} {4} ", xPluDataModel.PluBarcodeId, xPluDataModel.strShortName, xPluDataModel.Barcode, xPluDataModel.SalePrice, LabelTranslations.strGet("CurrencySymbol"));
                        dictionaryProduct.Add(xPluDataModel.PluBarcodeId.ToString(), a);
                        
                    }
                    comboBoxProduct.DataSource = new BindingSource(dictionaryProduct, null);
                    comboBoxProduct.DisplayMember = "Value";
                    comboBoxProduct.ValueMember = "Key";
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

        private void drawButton()
        {
            List<FormControlDataModel> lFormControlDataModel = new List<FormControlDataModel>();
            lFormControlDataModel = Dao.xGetInstance().xGetShortCutButtons();
            var i = 14;
            foreach (var form in lFormControlDataModel)
            {
                CustomButton xCustomButton = new CustomButton(form);
                xCustomButton.FormID = form.iId;
                xCustomButton.Location = new System.Drawing.Point(i, 105);
                xCustomButton.Click += new EventHandler(SetBarcode);
                this.bAddControl(xCustomButton, form);
                i += 100;
            }
        }

        private void SetBarcode(object sender, EventArgs e)
        {
            var barcode = PosManager.xGetInstance().GetBarcodeByBarcodeId(Convert.ToInt64(((KeyValuePair<string, string>)comboBoxProduct.SelectedItem).Key));
            PosManager.xGetInstance().bUpdateFormControlName(((CustomButton)sender).FormID, "BARCODE" + barcode);
            drawButton();
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxBarcode.Text = "";
            comboBoxProduct.Items.Clear();
            vFocus();
        }

        private void buttonSpace_Click_1(object sender, EventArgs e)
        {
            textBoxBarcode.Text += " ";
            vFocus();
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (textBoxBarcode.Text.Length >= 1)
                textBoxBarcode.Text = textBoxBarcode.Text.Remove(textBoxBarcode.Text.Length - 1);

            vFocus();
        }

        private void buttonH_Click(object sender, EventArgs e)
        {
            textBoxBarcode.Text += ((Control)sender).Text;
            vFocus();
        }

        private void textBoxBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearch.PerformClick();
            }
        }
    }
}

