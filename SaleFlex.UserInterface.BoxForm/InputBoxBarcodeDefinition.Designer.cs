using SaleFlex.UserInterface.Controls;

namespace SaleFlex.UserInterface.BoxForm
{
    partial class InputBoxBarcodeDefinition
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
            this.textBoxLengthOfProductCode = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBarcodeStartingNumber = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxLengthOfQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLengthOfPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLengthOfProductCode
            // 
            this.textBoxLengthOfProductCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxLengthOfProductCode.Location = new System.Drawing.Point(267, 75);
            this.textBoxLengthOfProductCode.MaxLength = 11;
            this.textBoxLengthOfProductCode.Name = "textBoxLengthOfProductCode";
            this.textBoxLengthOfProductCode.Size = new System.Drawing.Size(156, 27);
            this.textBoxLengthOfProductCode.TabIndex = 50;
            this.textBoxLengthOfProductCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBarcodeType_KeyPress);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonCancel.Location = new System.Drawing.Point(286, 288);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 50);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "VAZGEÇ";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxLengthOfPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxLengthOfQuantity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxLengthOfProductCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxBarcodeStartingNumber);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonOk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 369);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(45, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 23);
            this.label2.TabIndex = 49;
            this.label2.Text = "BARKOD BAŞLANGIÇ NO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(64, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 23);
            this.label1.TabIndex = 48;
            this.label1.Text = "ÜRÜN KODU UZUNLUĞU";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxBarcodeStartingNumber
            // 
            this.comboBoxBarcodeStartingNumber.DisplayMember = "strName";
            this.comboBoxBarcodeStartingNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxBarcodeStartingNumber.FormattingEnabled = true;
            this.comboBoxBarcodeStartingNumber.Items.AddRange(new object[] {
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29"});
            this.comboBoxBarcodeStartingNumber.Location = new System.Drawing.Point(267, 30);
            this.comboBoxBarcodeStartingNumber.Name = "comboBoxBarcodeStartingNumber";
            this.comboBoxBarcodeStartingNumber.Size = new System.Drawing.Size(156, 27);
            this.comboBoxBarcodeStartingNumber.TabIndex = 5;
            this.comboBoxBarcodeStartingNumber.ValueMember = "strName";
            this.comboBoxBarcodeStartingNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxBarcodeStartingNumber_SelectedIndexChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOk.Location = new System.Drawing.Point(68, 288);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(120, 50);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "TAMAM";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxLengthOfQuantity
            // 
            this.textBoxLengthOfQuantity.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxLengthOfQuantity.Location = new System.Drawing.Point(267, 122);
            this.textBoxLengthOfQuantity.MaxLength = 11;
            this.textBoxLengthOfQuantity.Name = "textBoxLengthOfQuantity";
            this.textBoxLengthOfQuantity.Size = new System.Drawing.Size(156, 27);
            this.textBoxLengthOfQuantity.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(27, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 23);
            this.label3.TabIndex = 51;
            this.label3.Text = "ÜRÜN MİKTARI UZUNLUĞU";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxLengthOfPrice
            // 
            this.textBoxLengthOfPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxLengthOfPrice.Location = new System.Drawing.Point(267, 167);
            this.textBoxLengthOfPrice.MaxLength = 11;
            this.textBoxLengthOfPrice.Name = "textBoxLengthOfPrice";
            this.textBoxLengthOfPrice.Size = new System.Drawing.Size(156, 27);
            this.textBoxLengthOfPrice.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(27, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 23);
            this.label4.TabIndex = 53;
            this.label4.Text = "ÜRÜN FİYAT UZUNLUĞU";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxDescription.Location = new System.Drawing.Point(267, 215);
            this.textBoxDescription.MaxLength = 11;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(156, 27);
            this.textBoxDescription.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(27, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 23);
            this.label5.TabIndex = 55;
            this.label5.Text = "AÇIKLAMA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InputBoxBarcodeDefinition
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(505, 394);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputBoxBarcodeDefinition";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InputBoxBarcodeDefinition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputBoxBarcodeDefinition_FormClosing);
            this.Load += new System.EventHandler(this.InputBoxBarcodeDefinition_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ComboBox comboBoxBarcodeStartingNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLengthOfProductCode;
        private System.Windows.Forms.TextBox textBoxLengthOfQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLengthOfPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label5;
    }
}