namespace SaleFlex.UserInterface.BoxForm
{
    partial class InputBoxCashReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBoxCashReport));
            this.buttonExit = new System.Windows.Forms.Button();
            this.dataGridViewStockList = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashWithoutVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnProductCash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockList)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.LightBlue;
            this.buttonExit.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonExit.Location = new System.Drawing.Point(912, 656);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 100);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "Çıkış";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // dataGridViewStockList
            // 
            this.dataGridViewStockList.AllowUserToAddRows = false;
            this.dataGridViewStockList.AllowUserToDeleteRows = false;
            this.dataGridViewStockList.AllowUserToResizeRows = false;
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
            this.Day,
            this.ReceiptTotal,
            this.CashWithoutVat,
            this.ReturnProductCash,
            this.PurchasePrice,
            this.Profit,
            this.CashPayment,
            this.CardPayment,
            this.OtherPayment});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStockList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewStockList.Location = new System.Drawing.Point(12, 145);
            this.dataGridViewStockList.MultiSelect = false;
            this.dataGridViewStockList.Name = "dataGridViewStockList";
            this.dataGridViewStockList.ReadOnly = true;
            this.dataGridViewStockList.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataGridViewStockList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewStockList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockList.ShowCellToolTips = false;
            this.dataGridViewStockList.ShowEditingIcon = false;
            this.dataGridViewStockList.ShowRowErrors = false;
            this.dataGridViewStockList.Size = new System.Drawing.Size(1000, 485);
            this.dataGridViewStockList.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.ItemHeight = 29;
            this.comboBox1.Location = new System.Drawing.Point(17, 86);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 37);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.LightBlue;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rapor Tipi";
            // 
            // Day
            // 
            this.Day.DataPropertyName = "Day";
            this.Day.HeaderText = "TARİH";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            // 
            // ReceiptTotal
            // 
            this.ReceiptTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReceiptTotal.DataPropertyName = "ReceiptTotal";
            this.ReceiptTotal.HeaderText = "CİRO SATIŞ TOPLAM";
            this.ReceiptTotal.Name = "ReceiptTotal";
            this.ReceiptTotal.ReadOnly = true;
            this.ReceiptTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CashWithoutVat
            // 
            this.CashWithoutVat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CashWithoutVat.DataPropertyName = "CashWithoutVat";
            this.CashWithoutVat.HeaderText = "NET SATIŞ";
            this.CashWithoutVat.Name = "CashWithoutVat";
            this.CashWithoutVat.ReadOnly = true;
            this.CashWithoutVat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ReturnProductCash
            // 
            this.ReturnProductCash.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReturnProductCash.DataPropertyName = "ReturnProductCash";
            this.ReturnProductCash.HeaderText = "SATIŞ İADE TOPLAM";
            this.ReturnProductCash.Name = "ReturnProductCash";
            this.ReturnProductCash.ReadOnly = true;
            this.ReturnProductCash.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PurchasePrice
            // 
            this.PurchasePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PurchasePrice.DataPropertyName = "PurchasePrice";
            this.PurchasePrice.HeaderText = "ALIŞ MALİYET TOPLAM";
            this.PurchasePrice.Name = "PurchasePrice";
            this.PurchasePrice.ReadOnly = true;
            this.PurchasePrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Profit
            // 
            this.Profit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Profit.DataPropertyName = "Profit";
            this.Profit.HeaderText = "NET KAZANÇ";
            this.Profit.Name = "Profit";
            this.Profit.ReadOnly = true;
            this.Profit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CashPayment
            // 
            this.CashPayment.DataPropertyName = "CashPayment";
            this.CashPayment.HeaderText = "NAKİT ÖDENEN";
            this.CashPayment.Name = "CashPayment";
            this.CashPayment.ReadOnly = true;
            // 
            // CardPayment
            // 
            this.CardPayment.DataPropertyName = "CardPayment";
            this.CardPayment.HeaderText = "KREDİ KARTI";
            this.CardPayment.Name = "CardPayment";
            this.CardPayment.ReadOnly = true;
            // 
            // OtherPayment
            // 
            this.OtherPayment.DataPropertyName = "OtherPayment";
            this.OtherPayment.HeaderText = "DİĞER ÖDEME";
            this.OtherPayment.Name = "OtherPayment";
            this.OtherPayment.ReadOnly = true;
            // 
            // InputBoxCashReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridViewStockList);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InputBoxCashReport";
            this.Text = "InputBoxCashReport";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.DataGridView dataGridViewStockList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashWithoutVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnProductCash;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherPayment;
    }
}