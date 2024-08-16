using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.AccessLayer;
using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class InputBoxCashReport : Form
    {
        private PluDataModel m_xPluID = null;
        public PluDataModel xNewPluDataModel
        {
            get { return m_xPluID; }
            set { m_xPluID = value; }
        }
        public InputBoxCashReport()
        {
            InitializeComponent();
            try
            {
                dataGridViewStockList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                List<DropList> xDropdownListItems = new List<DropList>();
                xDropdownListItems.Add(new DropList { strOptionName = LabelTranslations.strGet("Daily") });
                xDropdownListItems.Add(new DropList { strOptionName = LabelTranslations.strGet("Monthly") });
                xDropdownListItems.Add(new DropList { strOptionName = LabelTranslations.strGet("Monthly(Detailed)") });

                foreach (var item in xDropdownListItems)
                {
                    comboBox1.Items.Add(item.strOptionName);
                }
                
                comboBox1.Items.Insert(0, LabelTranslations.strGet("PleaseSelect"));
                comboBox1.SelectedIndex = 0;

                dataGridViewStockList.Columns[0].Visible = false;
                dataGridViewStockList.Hide();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }


        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelectedText = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (strSelectedText != LabelTranslations.strGet("PleaseSelect"))
            {
                if (comboBox1.Items.Contains(LabelTranslations.strGet("PleaseSelect")))
                {
                    comboBox1.Items.RemoveAt(0);
                }
                if (strSelectedText == LabelTranslations.strGet("Daily"))
                {
                    dataGridViewStockList.DataSource = Dao.xGetInstance().xGetCashReportDaily();
                    dataGridViewStockList.Columns[0].Visible = false;
                }
                if (strSelectedText == LabelTranslations.strGet("Monthly"))
                {
                    dataGridViewStockList.DataSource = Dao.xGetInstance().xGetCashReportMonthly();
                    dataGridViewStockList.Columns[0].Visible = false;
                }
                if (strSelectedText == LabelTranslations.strGet("Monthly(Detailed)"))
                {
                    dataGridViewStockList.DataSource = Dao.xGetInstance().xGetCashReportMonthlyDetailed();
                    dataGridViewStockList.Columns[0].Visible = true;
                }

                dataGridViewStockList.Show();
            }

            dataGridViewStockList.Update();
            dataGridViewStockList.Refresh();

        }
    }
    public class DropList
    {
        public string strOptionName { get; set; }
    }
}
