using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.POS.Manager;
using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class InputBoxStockEntry : Form
    {
        private List<StockDataModel> model = new List<StockDataModel>();
        private StockDataModel stockModel;
        private List<StockDataModel> stockList = new List<StockDataModel>();

        public InputBoxStockEntry()
        {
            InitializeComponent();
            try
            {
                dataGridViewStockList.BackgroundColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
                dataGridViewStockList.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);

                var vatList = PosManager.xGetInstance().GetVatListForCombo();
                RATE.DataSource = vatList;
                RATE.DisplayMember = "Rate";
                RATE.ValueMember = "No";

                var stockUnitList = PosManager.xGetInstance().GetStockUnitListForCombo();
                STOCKUNIT.DataSource = stockUnitList;
                STOCKUNIT.DisplayMember = "Name";
                STOCKUNIT.ValueMember = "StockUnitNo";

                stockList = PosManager.xGetInstance().xGetPluStock();
                DataTable stockListDataTable = new DataTable();
                stockListDataTable = ToDataTable<StockDataModel>(stockList);


                //var StockAmount = stockList.Where(a => a.StockUnitNo == 1).Select(p => new { StockAmount = p.Stock / 1000, p.MinStock, });

                DataTable dtCloned = stockListDataTable.Clone();
                dtCloned.Columns["Stock"].DataType = typeof(string);
                foreach (DataRow row in stockListDataTable.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                for (int i = 0; i < dtCloned.Rows.Count; i++)
                {
                    if (int.Parse(dtCloned.Rows[i]["StockUnitNo"].ToString()) == 1)
                    {
                        dtCloned.Rows[i]["Stock"] = string.Format("{0:#,0.00}",Convert.ToDecimal(dtCloned.Rows[i]["Stock"])/1000);
                    }
                }
                dataGridViewStockList.DataSource = dtCloned;

                SetLabels(stockList);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public static DataTable ToDataTable<T>(List<StockDataModel> iList)
        {
            DataTable dataTable = new DataTable();
            PropertyDescriptorCollection propertyDescriptorCollection =
                TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type type = propertyDescriptor.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);


                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach (StockDataModel iListItem in iList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewStockList_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dataGridViewStockList.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dataGridViewStockList.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    dataGridViewStockList.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // Sort the selected column.
            dataGridViewStockList.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;
        }

        private void dataGridViewStockList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridViewStockList.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void dataGridViewStockList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridViewStockList.BackgroundColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
                    dataGridViewStockList.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);

                    stockModel = model.Find(p => p.PluId == Convert.ToInt32(dataGridViewStockList.Rows[e.RowIndex].Cells["PluId"].Value));
                    model.Remove(stockModel);
                    if (stockModel == null) stockModel = new StockDataModel();
                    stockModel.PluId = Convert.ToInt32(dataGridViewStockList.Rows[e.RowIndex].Cells["PluId"].Value);
                    stockModel.BarcodeId = Convert.ToInt32(dataGridViewStockList.Rows[e.RowIndex].Cells["BarcodeId"].Value);
                    stockModel.ShortName = dataGridViewStockList.Rows[e.RowIndex].Cells["ShortName"].Value.ToString();
                    stockModel.Barcode = dataGridViewStockList.Rows[e.RowIndex].Cells["Barcode"].Value.ToString();
                    stockModel.StockUnitNo = Convert.ToInt32(dataGridViewStockList.Rows[e.RowIndex].Cells[6].Value);
                    stockModel.Stock = stockModel.StockUnitNo == 1 ? Convert.ToInt32(Convert.ToDecimal(dataGridViewStockList.Rows[e.RowIndex].Cells["Stock"].Value) * 1000) : Convert.ToInt32(dataGridViewStockList.Rows[e.RowIndex].Cells["Stock"].Value);
                    stockModel.MinStock = Convert.ToInt32(dataGridViewStockList.Rows[e.RowIndex].Cells["MinStock"].Value);
                    stockModel.MaxStock = Convert.ToInt32(dataGridViewStockList.Rows[e.RowIndex].Cells["MaxStock"].Value);
                    stockModel.SalePrice = Convert.ToDecimal(dataGridViewStockList.Rows[e.RowIndex].Cells["SalePrice"].Value) * 100;
                    stockModel.PurchasePrice = Convert.ToDecimal(dataGridViewStockList.Rows[e.RowIndex].Cells["PurchasePrice"].Value) * 100;
                    stockModel.Code = dataGridViewStockList.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                    stockModel.No = Convert.ToInt32(dataGridViewStockList.Rows[e.RowIndex].Cells[11].Value);
                    stockModel.IncomewithStock = Math.Abs(Convert.ToInt32(dataGridViewStockList.Rows[e.RowIndex].Cells["IncomewithStock"].Value));

                    model.Add(stockModel);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                PosManager.xGetInstance().vUpdatePluStock(model);
                CustomMessageBox.Show(LabelTranslations.strGet("Saved"));
                this.Close();
            }
            catch (Exception xException)
            {
                Trace.vInsertError(xException);
                    CustomMessageBox.Show(LabelTranslations.strGet(xException.Message));
                throw xException;
             
                //xException.strTraceError();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewStockList.DataSource = stockList.FindAll(p => p.Barcode.Contains(textBoxBarcode.Text));;
                SetLabels(stockList);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        private void SetLabels(List<StockDataModel> stockList)
        {
            lblStockCount.Text = stockList.Where(p => p.Barcode.Contains(textBoxBarcode.Text)).Sum(p => p.Stock) + " adet ürün";
            lblProfitResult.Text = stockList.Sum(p => p.IncomewithStock).ToString("N2") + "TL";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StockDataModel stockModel = new StockDataModel();
                List<StockDataModel> stockList = PosManager.xGetInstance().xGetPluStock();
                stockModel.PluId = 0;
                stockModel.BarcodeId = 0;
                stockModel.ShortName = "";
                stockModel.Barcode = "Barcode 0 girmeyiniz!";
                stockModel.StockUnitNo = PosManager.xGetInstance().GetVatListForCombo().First().No;
                stockModel.Stock = 0;
                stockModel.MinStock = 0;
                stockModel.MaxStock = 0;
                stockModel.SalePrice = 0;
                stockModel.PurchasePrice = 0;
                stockModel.Code = "";
                stockModel.No = PosManager.xGetInstance().GetVatListForCombo().First().No;
                stockModel.IncomewithStock = 0;
                stockList.Insert(0, stockModel);

                dataGridViewStockList.DataSource = stockList;
                PosManager.xGetInstance().xSaveStock(stockList);

                dataGridViewStockList.DataSource = stockList;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
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

