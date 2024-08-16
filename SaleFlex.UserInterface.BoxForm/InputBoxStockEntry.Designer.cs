namespace SaleFlex.UserInterface.BoxForm
{
    partial class InputBoxStockEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBoxStockEntry));
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.dataGridViewStockList = new System.Windows.Forms.DataGridView();
            this.PluId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BARCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCKUNIT = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MINSTOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAXSTOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALEPRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PURCHASEPRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RATE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IncomewithStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.lblStockCount = new System.Windows.Forms.Label();
            this.lblProfitResult = new System.Windows.Forms.Label();
            this.lblProfit = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Pink;
            this.buttonExit.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonExit.Location = new System.Drawing.Point(862, 697);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(150, 59);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "Vazgeç";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.LightBlue;
            this.buttonSave.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSave.Location = new System.Drawing.Point(12, 697);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 59);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Kaydet";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // dataGridViewStockList
            // 
            this.dataGridViewStockList.AllowUserToDeleteRows = false;
            this.dataGridViewStockList.AllowUserToOrderColumns = true;
            this.dataGridViewStockList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridViewStockList.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridViewStockList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStockList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PluId,
            this.BarcodeId,
            this.ShortName,
            this.BARCODE,
            this.STOCK,
            this.STOCKUNIT,
            this.MINSTOCK,
            this.MAXSTOCK,
            this.SALEPRICE,
            this.PURCHASEPRICE,
            this.CODE,
            this.RATE,
            this.IncomewithStock});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStockList.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewStockList.GridColor = System.Drawing.Color.LightBlue;
            this.dataGridViewStockList.Location = new System.Drawing.Point(12, 87);
            this.dataGridViewStockList.MultiSelect = false;
            this.dataGridViewStockList.Name = "dataGridViewStockList";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStockList.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewStockList.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataGridViewStockList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewStockList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewStockList.ShowCellToolTips = false;
            this.dataGridViewStockList.ShowEditingIcon = false;
            this.dataGridViewStockList.ShowRowErrors = false;
            this.dataGridViewStockList.Size = new System.Drawing.Size(1000, 563);
            this.dataGridViewStockList.TabIndex = 2;
            this.dataGridViewStockList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStockList_CellValueChanged);
            this.dataGridViewStockList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewStockList_ColumnHeaderMouseDoubleClick);
            this.dataGridViewStockList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewStockList_DataBindingComplete);
            // 
            // PluId
            // 
            this.PluId.DataPropertyName = "PluId";
            this.PluId.HeaderText = "PluId";
            this.PluId.Name = "PluId";
            this.PluId.Visible = false;
            // 
            // BarcodeId
            // 
            this.BarcodeId.DataPropertyName = "BarcodeId";
            this.BarcodeId.HeaderText = "BarcodeId";
            this.BarcodeId.Name = "BarcodeId";
            this.BarcodeId.Visible = false;
            // 
            // ShortName
            // 
            this.ShortName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ShortName.DataPropertyName = "ShortName";
            this.ShortName.FillWeight = 370.1299F;
            this.ShortName.HeaderText = "ÜRÜN";
            this.ShortName.MinimumWidth = 100;
            this.ShortName.Name = "ShortName";
            // 
            // BARCODE
            // 
            this.BARCODE.DataPropertyName = "BARCODE";
            this.BARCODE.HeaderText = "BARKOD";
            this.BARCODE.Name = "BARCODE";
            this.BARCODE.Width = 130;
            // 
            // STOCK
            // 
            this.STOCK.DataPropertyName = "STOCK";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.STOCK.DefaultCellStyle = dataGridViewCellStyle2;
            this.STOCK.HeaderText = "ADET/KG";
            this.STOCK.Name = "STOCK";
            this.STOCK.Width = 60;
            // 
            // STOCKUNIT
            // 
            this.STOCKUNIT.DataPropertyName = "StockUnitNo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.STOCKUNIT.DefaultCellStyle = dataGridViewCellStyle3;
            this.STOCKUNIT.FillWeight = 32.46753F;
            this.STOCKUNIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.STOCKUNIT.HeaderText = "STOK BİRİMİ";
            this.STOCKUNIT.Name = "STOCKUNIT";
            this.STOCKUNIT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STOCKUNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.STOCKUNIT.Width = 60;
            // 
            // MINSTOCK
            // 
            this.MINSTOCK.DataPropertyName = "MINSTOCK";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MINSTOCK.DefaultCellStyle = dataGridViewCellStyle4;
            this.MINSTOCK.HeaderText = "MİN STOK";
            this.MINSTOCK.Name = "MINSTOCK";
            this.MINSTOCK.Width = 60;
            // 
            // MAXSTOCK
            // 
            this.MAXSTOCK.DataPropertyName = "MAXSTOCK";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MAXSTOCK.DefaultCellStyle = dataGridViewCellStyle5;
            this.MAXSTOCK.HeaderText = "MAX STOK";
            this.MAXSTOCK.Name = "MAXSTOCK";
            this.MAXSTOCK.Width = 60;
            // 
            // SALEPRICE
            // 
            this.SALEPRICE.DataPropertyName = "SALEPRICE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.SALEPRICE.DefaultCellStyle = dataGridViewCellStyle6;
            this.SALEPRICE.FillWeight = 32.46753F;
            this.SALEPRICE.HeaderText = "SATIŞ FİYATI";
            this.SALEPRICE.Name = "SALEPRICE";
            this.SALEPRICE.Width = 60;
            // 
            // PURCHASEPRICE
            // 
            this.PURCHASEPRICE.DataPropertyName = "PURCHASEPRICE";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.PURCHASEPRICE.DefaultCellStyle = dataGridViewCellStyle7;
            this.PURCHASEPRICE.FillWeight = 32.46753F;
            this.PURCHASEPRICE.HeaderText = "ALIŞ FİYATI";
            this.PURCHASEPRICE.Name = "PURCHASEPRICE";
            this.PURCHASEPRICE.Width = 60;
            // 
            // CODE
            // 
            this.CODE.DataPropertyName = "CODE";
            this.CODE.HeaderText = "KOD";
            this.CODE.Name = "CODE";
            // 
            // RATE
            // 
            this.RATE.DataPropertyName = "No";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RATE.DefaultCellStyle = dataGridViewCellStyle8;
            this.RATE.FillWeight = 32.46753F;
            this.RATE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RATE.HeaderText = "KDV ORANI";
            this.RATE.Name = "RATE";
            this.RATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RATE.Width = 60;
            // 
            // IncomewithStock
            // 
            this.IncomewithStock.DataPropertyName = "IncomewithStock";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.IncomewithStock.DefaultCellStyle = dataGridViewCellStyle9;
            this.IncomewithStock.HeaderText = "STOKTAN ELDE EDİLEN GELİR";
            this.IncomewithStock.Name = "IncomewithStock";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSearch.Location = new System.Drawing.Point(425, 40);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(152, 41);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "ARA";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.textBoxBarcode.Location = new System.Drawing.Point(12, 41);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(407, 40);
            this.textBoxBarcode.TabIndex = 3;
            this.textBoxBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxBarcode_KeyDown);
            // 
            // lblStockCount
            // 
            this.lblStockCount.AutoSize = true;
            this.lblStockCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStockCount.Location = new System.Drawing.Point(83, 665);
            this.lblStockCount.Name = "lblStockCount";
            this.lblStockCount.Size = new System.Drawing.Size(0, 20);
            this.lblStockCount.TabIndex = 5;
            // 
            // lblProfitResult
            // 
            this.lblProfitResult.AutoSize = true;
            this.lblProfitResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProfitResult.Location = new System.Drawing.Point(594, 665);
            this.lblProfitResult.Name = "lblProfitResult";
            this.lblProfitResult.Size = new System.Drawing.Size(0, 20);
            this.lblProfitResult.TabIndex = 6;
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProfit.Location = new System.Drawing.Point(281, 665);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(289, 20);
            this.lblProfit.TabIndex = 8;
            this.lblProfit.Text = "Stoktan Elde Edilen Toplam Gelir : ";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStock.Location = new System.Drawing.Point(8, 665);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(56, 20);
            this.lblStock.TabIndex = 9;
            this.lblStock.Text = "Stok :";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonAdd.Location = new System.Drawing.Point(598, 41);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(150, 40);
            this.buttonAdd.TabIndex = 10;
            this.buttonAdd.Text = "EKLE";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputBoxStockEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblProfit);
            this.Controls.Add(this.lblProfitResult);
            this.Controls.Add(this.lblStockCount);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxBarcode);
            this.Controls.Add(this.dataGridViewStockList);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputBoxStockEntry";
            this.RightToLeftLayout = true;
            this.Text = "InputBoxStockEntry";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridView dataGridViewStockList;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.Label lblStockCount;
        private System.Windows.Forms.Label lblProfitResult;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn PluId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BARCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK;
        private System.Windows.Forms.DataGridViewComboBoxColumn STOCKUNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MINSTOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAXSTOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALEPRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PURCHASEPRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewComboBoxColumn RATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncomewithStock;
    }
}