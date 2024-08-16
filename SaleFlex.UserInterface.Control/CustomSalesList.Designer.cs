
namespace SaleFlex.UserInterface.Controls
{
    partial class CustomSalesList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomSalesList));
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.ROW_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REFERENCE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANSACTION_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANSACTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME_OF_PRODUCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.AllowUserToAddRows = false;
            this.dataGridViewSales.AllowUserToDeleteRows = false;
            this.dataGridViewSales.AllowUserToResizeColumns = false;
            this.dataGridViewSales.AllowUserToResizeRows = false;
            this.dataGridViewSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridViewSales.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dataGridViewSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROW_NUMBER,
            this.REFERENCE_ID,
            this.TRANSACTION_TYPE,
            this.TRANSACTION,
            this.NAME_OF_PRODUCT,
            this.QUANTITY,
            this.UNIT,
            this.PRICE,
            this.TOTAL_AMOUNT});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSales.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewSales.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSales.MultiSelect = false;
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.ReadOnly = true;
            this.dataGridViewSales.RowHeadersVisible = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataGridViewSales.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewSales.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSales.ShowCellToolTips = false;
            this.dataGridViewSales.ShowEditingIcon = false;
            this.dataGridViewSales.ShowRowErrors = false;
            this.dataGridViewSales.Size = new System.Drawing.Size(498, 198);
            this.dataGridViewSales.TabIndex = 2;
            this.dataGridViewSales.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewSales_Paint);
            // 
            // ROW_NUMBER
            // 
            this.ROW_NUMBER.DataPropertyName = "ROW_NUMBER";
            this.ROW_NUMBER.HeaderText = "NO";
            this.ROW_NUMBER.Name = "ROW_NUMBER";
            this.ROW_NUMBER.ReadOnly = true;
            this.ROW_NUMBER.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ROW_NUMBER.Width = 35;
            // 
            // REFERENCE_ID
            // 
            this.REFERENCE_ID.DataPropertyName = "REFERENCE_ID";
            this.REFERENCE_ID.HeaderText = "REFERANS_ID";
            this.REFERENCE_ID.Name = "REFERENCE_ID";
            this.REFERENCE_ID.ReadOnly = true;
            this.REFERENCE_ID.Visible = false;
            // 
            // TRANSACTION_TYPE
            // 
            this.TRANSACTION_TYPE.DataPropertyName = "TRANSACTION_TYPE";
            this.TRANSACTION_TYPE.HeaderText = "ISLEM_TUR";
            this.TRANSACTION_TYPE.Name = "TRANSACTION_TYPE";
            this.TRANSACTION_TYPE.ReadOnly = true;
            this.TRANSACTION_TYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TRANSACTION_TYPE.Visible = false;
            this.TRANSACTION_TYPE.Width = 85;
            // 
            // TRANSACTION
            // 
            this.TRANSACTION.DataPropertyName = "TRANSACTION";
            this.TRANSACTION.HeaderText = "İŞLEM";
            this.TRANSACTION.Name = "TRANSACTION";
            this.TRANSACTION.ReadOnly = true;
            this.TRANSACTION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TRANSACTION.Width = 120;
            // 
            // NAME_OF_PRODUCT
            // 
            this.NAME_OF_PRODUCT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NAME_OF_PRODUCT.DataPropertyName = "NAME_OF_PRODUCT";
            this.NAME_OF_PRODUCT.FillWeight = 370.1299F;
            this.NAME_OF_PRODUCT.HeaderText = "ÜRÜN";
            this.NAME_OF_PRODUCT.Name = "NAME_OF_PRODUCT";
            this.NAME_OF_PRODUCT.ReadOnly = true;
            this.NAME_OF_PRODUCT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // QUANTITY
            // 
            this.QUANTITY.DataPropertyName = "QUANTITY";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QUANTITY.DefaultCellStyle = dataGridViewCellStyle2;
            this.QUANTITY.FillWeight = 32.46753F;
            this.QUANTITY.HeaderText = "ADET/KG";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.ReadOnly = true;
            this.QUANTITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.QUANTITY.Width = 75;
            // 
            // UNIT
            // 
            this.UNIT.DataPropertyName = "UNIT";
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.UNIT.DefaultCellStyle = dataGridViewCellStyle3;
            this.UNIT.FillWeight = 32.46753F;
            this.UNIT.HeaderText = "BİRİM";
            this.UNIT.Name = "UNIT";
            this.UNIT.ReadOnly = true;
            this.UNIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UNIT.Visible = false;
            this.UNIT.Width = 55;
            // 
            // PRICE
            // 
            this.PRICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PRICE.DataPropertyName = "PRICE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.PRICE.DefaultCellStyle = dataGridViewCellStyle4;
            this.PRICE.FillWeight = 32.46753F;
            this.PRICE.HeaderText = "FİYAT";
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            this.PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRICE.Width = 49;
            // 
            // TOTAL_AMOUNT
            // 
            this.TOTAL_AMOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TOTAL_AMOUNT.DataPropertyName = "TOTAL_AMOUNT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.TOTAL_AMOUNT.DefaultCellStyle = dataGridViewCellStyle5;
            this.TOTAL_AMOUNT.FillWeight = 32.46753F;
            this.TOTAL_AMOUNT.HeaderText = "TUTAR";
            this.TOTAL_AMOUNT.Name = "TOTAL_AMOUNT";
            this.TOTAL_AMOUNT.ReadOnly = true;
            this.TOTAL_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TOTAL_AMOUNT.Width = 57;
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonUp.Image")));
            this.buttonUp.Location = new System.Drawing.Point(499, 0);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(50, 100);
            this.buttonUp.TabIndex = 0;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonDown.Image")));
            this.buttonDown.Location = new System.Drawing.Point(499, 99);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(50, 100);
            this.buttonDown.TabIndex = 1;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // CustomSalesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.dataGridViewSales);
            this.Name = "CustomSalesList";
            this.Size = new System.Drawing.Size(548, 198);
            this.Enter += new System.EventHandler(this.CustomSalesList_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROW_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn REFERENCE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANSACTION_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANSACTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME_OF_PRODUCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_AMOUNT;
    }
}
