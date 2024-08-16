namespace SaleFlex.UserInterface.Controls
{
    partial class CustomCustomerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomCustomerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.labelTextBalanceAmount = new System.Windows.Forms.Label();
            this.labelTextPaymentAmount = new System.Windows.Forms.Label();
            this.labelTextTotalAmount = new System.Windows.Forms.Label();
            this.labelTextDiscountAmount = new System.Windows.Forms.Label();
            this.labelTextSalesAmount = new System.Windows.Forms.Label();
            this.labelBalanceAmount = new System.Windows.Forms.Label();
            this.labelPaymentAmount = new System.Windows.Forms.Label();
            this.labelNetAmount = new System.Windows.Forms.Label();
            this.labelDiscountAmount = new System.Windows.Forms.Label();
            this.labelSalesAmount = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.dataGridViewPayments = new System.Windows.Forms.DataGridView();
            this.TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROW_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REFERENCE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANSACTION_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANSACTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME_OF_PRODUCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).BeginInit();
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
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSales.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewSales.Location = new System.Drawing.Point(252, 22);
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
            this.dataGridViewSales.Size = new System.Drawing.Size(748, 509);
            this.dataGridViewSales.TabIndex = 5;
            // 
            // labelTextBalanceAmount
            // 
            this.labelTextBalanceAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelTextBalanceAmount.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTextBalanceAmount.ForeColor = System.Drawing.Color.White;
            this.labelTextBalanceAmount.Location = new System.Drawing.Point(828, 720);
            this.labelTextBalanceAmount.Name = "labelTextBalanceAmount";
            this.labelTextBalanceAmount.Size = new System.Drawing.Size(156, 23);
            this.labelTextBalanceAmount.TabIndex = 26;
            this.labelTextBalanceAmount.Text = "0,00";
            this.labelTextBalanceAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTextPaymentAmount
            // 
            this.labelTextPaymentAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelTextPaymentAmount.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTextPaymentAmount.ForeColor = System.Drawing.Color.White;
            this.labelTextPaymentAmount.Location = new System.Drawing.Point(828, 689);
            this.labelTextPaymentAmount.Name = "labelTextPaymentAmount";
            this.labelTextPaymentAmount.Size = new System.Drawing.Size(156, 23);
            this.labelTextPaymentAmount.TabIndex = 25;
            this.labelTextPaymentAmount.Text = "0,00";
            this.labelTextPaymentAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTextTotalAmount
            // 
            this.labelTextTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelTextTotalAmount.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTextTotalAmount.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelTextTotalAmount.Location = new System.Drawing.Point(793, 628);
            this.labelTextTotalAmount.Name = "labelTextTotalAmount";
            this.labelTextTotalAmount.Size = new System.Drawing.Size(191, 52);
            this.labelTextTotalAmount.TabIndex = 24;
            this.labelTextTotalAmount.Text = "0,00";
            this.labelTextTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTextDiscountAmount
            // 
            this.labelTextDiscountAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelTextDiscountAmount.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTextDiscountAmount.ForeColor = System.Drawing.Color.White;
            this.labelTextDiscountAmount.Location = new System.Drawing.Point(828, 596);
            this.labelTextDiscountAmount.Name = "labelTextDiscountAmount";
            this.labelTextDiscountAmount.Size = new System.Drawing.Size(156, 27);
            this.labelTextDiscountAmount.TabIndex = 23;
            this.labelTextDiscountAmount.Text = "0,00";
            this.labelTextDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTextSalesAmount
            // 
            this.labelTextSalesAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelTextSalesAmount.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTextSalesAmount.ForeColor = System.Drawing.Color.White;
            this.labelTextSalesAmount.Location = new System.Drawing.Point(828, 565);
            this.labelTextSalesAmount.Name = "labelTextSalesAmount";
            this.labelTextSalesAmount.Size = new System.Drawing.Size(156, 23);
            this.labelTextSalesAmount.TabIndex = 22;
            this.labelTextSalesAmount.Text = "0,00";
            this.labelTextSalesAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBalanceAmount
            // 
            this.labelBalanceAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelBalanceAmount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBalanceAmount.ForeColor = System.Drawing.Color.White;
            this.labelBalanceAmount.Location = new System.Drawing.Point(712, 719);
            this.labelBalanceAmount.Name = "labelBalanceAmount";
            this.labelBalanceAmount.Size = new System.Drawing.Size(92, 24);
            this.labelBalanceAmount.TabIndex = 21;
            this.labelBalanceAmount.Text = "BALANCE:";
            this.labelBalanceAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPaymentAmount
            // 
            this.labelPaymentAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelPaymentAmount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPaymentAmount.ForeColor = System.Drawing.Color.White;
            this.labelPaymentAmount.Location = new System.Drawing.Point(710, 689);
            this.labelPaymentAmount.Name = "labelPaymentAmount";
            this.labelPaymentAmount.Size = new System.Drawing.Size(92, 23);
            this.labelPaymentAmount.TabIndex = 20;
            this.labelPaymentAmount.Text = "PAYMENT:";
            this.labelPaymentAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNetAmount
            // 
            this.labelNetAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelNetAmount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelNetAmount.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelNetAmount.Location = new System.Drawing.Point(710, 628);
            this.labelNetAmount.Name = "labelNetAmount";
            this.labelNetAmount.Size = new System.Drawing.Size(92, 52);
            this.labelNetAmount.TabIndex = 19;
            this.labelNetAmount.Text = "TOTAL:";
            this.labelNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDiscountAmount
            // 
            this.labelDiscountAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelDiscountAmount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelDiscountAmount.ForeColor = System.Drawing.Color.White;
            this.labelDiscountAmount.Location = new System.Drawing.Point(712, 596);
            this.labelDiscountAmount.Name = "labelDiscountAmount";
            this.labelDiscountAmount.Size = new System.Drawing.Size(110, 27);
            this.labelDiscountAmount.TabIndex = 18;
            this.labelDiscountAmount.Text = "DISCOUNT:";
            this.labelDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSalesAmount
            // 
            this.labelSalesAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelSalesAmount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSalesAmount.ForeColor = System.Drawing.Color.White;
            this.labelSalesAmount.Location = new System.Drawing.Point(712, 565);
            this.labelSalesAmount.Name = "labelSalesAmount";
            this.labelSalesAmount.Size = new System.Drawing.Size(92, 23);
            this.labelSalesAmount.TabIndex = 17;
            this.labelSalesAmount.Text = "SALE:";
            this.labelSalesAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 204);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.Color.Transparent;
            this.labelMessage.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(54, 566);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(509, 177);
            this.labelMessage.TabIndex = 28;
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewPayments
            // 
            this.dataGridViewPayments.AllowUserToAddRows = false;
            this.dataGridViewPayments.AllowUserToDeleteRows = false;
            this.dataGridViewPayments.AllowUserToResizeColumns = false;
            this.dataGridViewPayments.AllowUserToResizeRows = false;
            this.dataGridViewPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPayments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridViewPayments.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.dataGridViewPayments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPayments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPayments.ColumnHeadersVisible = false;
            this.dataGridViewPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TYPE,
            this.AMOUNT});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPayments.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewPayments.Location = new System.Drawing.Point(12, 331);
            this.dataGridViewPayments.MultiSelect = false;
            this.dataGridViewPayments.Name = "dataGridViewPayments";
            this.dataGridViewPayments.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPayments.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewPayments.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataGridViewPayments.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewPayments.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPayments.ShowCellToolTips = false;
            this.dataGridViewPayments.ShowEditingIcon = false;
            this.dataGridViewPayments.ShowRowErrors = false;
            this.dataGridViewPayments.Size = new System.Drawing.Size(234, 200);
            this.dataGridViewPayments.TabIndex = 29;
            // 
            // TYPE
            // 
            this.TYPE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TYPE.DataPropertyName = "TYPE";
            this.TYPE.HeaderText = "TİP";
            this.TYPE.Name = "TYPE";
            this.TYPE.ReadOnly = true;
            // 
            // AMOUNT
            // 
            this.AMOUNT.DataPropertyName = "AMOUNT";
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.AMOUNT.DefaultCellStyle = dataGridViewCellStyle9;
            this.AMOUNT.HeaderText = "TUTAR";
            this.AMOUNT.Name = "AMOUNT";
            this.AMOUNT.ReadOnly = true;
            this.AMOUNT.Width = 50;
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
            this.REFERENCE_ID.HeaderText = "REFERENCE_ID";
            this.REFERENCE_ID.Name = "REFERENCE_ID";
            this.REFERENCE_ID.ReadOnly = true;
            this.REFERENCE_ID.Visible = false;
            // 
            // TRANSACTION_TYPE
            // 
            this.TRANSACTION_TYPE.DataPropertyName = "TRANSACTION_TYPE";
            this.TRANSACTION_TYPE.FillWeight = 85F;
            this.TRANSACTION_TYPE.HeaderText = "TRANSACTION_TYPE";
            this.TRANSACTION_TYPE.Name = "TRANSACTION_TYPE";
            this.TRANSACTION_TYPE.ReadOnly = true;
            this.TRANSACTION_TYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TRANSACTION_TYPE.Visible = false;
            this.TRANSACTION_TYPE.Width = 85;
            // 
            // TRANSACTION
            // 
            this.TRANSACTION.DataPropertyName = "TRANSACTION";
            this.TRANSACTION.HeaderText = "TRANSACTION";
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
            this.NAME_OF_PRODUCT.HeaderText = "NAME_OF_PRODUCT";
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
            this.QUANTITY.HeaderText = "QUANTITY/KG";
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
            this.UNIT.HeaderText = "UNIT";
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
            this.PRICE.HeaderText = "PRICE";
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            this.PRICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRICE.Width = 54;
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
            this.TOTAL_AMOUNT.HeaderText = "TOTAL";
            this.TOTAL_AMOUNT.Name = "TOTAL_AMOUNT";
            this.TOTAL_AMOUNT.ReadOnly = true;
            this.TOTAL_AMOUNT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TOTAL_AMOUNT.Width = 55;
            // 
            // CustomCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.dataGridViewPayments);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelTextBalanceAmount);
            this.Controls.Add(this.labelTextPaymentAmount);
            this.Controls.Add(this.labelTextTotalAmount);
            this.Controls.Add(this.labelTextDiscountAmount);
            this.Controls.Add(this.labelTextSalesAmount);
            this.Controls.Add(this.labelBalanceAmount);
            this.Controls.Add(this.labelPaymentAmount);
            this.Controls.Add(this.labelNetAmount);
            this.Controls.Add(this.labelDiscountAmount);
            this.Controls.Add(this.labelSalesAmount);
            this.Controls.Add(this.dataGridViewSales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomCustomerForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.Label labelTextBalanceAmount;
        private System.Windows.Forms.Label labelTextPaymentAmount;
        private System.Windows.Forms.Label labelTextTotalAmount;
        private System.Windows.Forms.Label labelTextDiscountAmount;
        private System.Windows.Forms.Label labelTextSalesAmount;
        private System.Windows.Forms.Label labelBalanceAmount;
        private System.Windows.Forms.Label labelPaymentAmount;
        private System.Windows.Forms.Label labelNetAmount;
        private System.Windows.Forms.Label labelDiscountAmount;
        private System.Windows.Forms.Label labelSalesAmount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.DataGridView dataGridViewPayments;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
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