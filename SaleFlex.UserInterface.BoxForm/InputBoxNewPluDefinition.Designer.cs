using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Controls;

namespace SaleFlex.UserInterface.BoxForm
{
    partial class InputBoxNewPluDefinition
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
            this.textBoxBarcode = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "NUMERIC"));
            this.textBoxPLUProductQuantity = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "NUMERIC"));
            this.textBoxPLUPriceLimitation = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "NUMERIC"));
            this.textBoxPLUPrice = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "NUMERIC"));
            this.textBoxPLUName = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "ALPHANUMERIC"));
            this.maskedTextBoxPluCode = new CustomMaskedTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "NUMERIC"));


            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxMainGroupNo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDepartmentId = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxBarcode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxBarcode.Location = new System.Drawing.Point(180, 350);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(174, 27);
            this.textBoxBarcode.TabIndex = 76;
            // 
            // textBoxPLUProductQuantity
            // 
            this.textBoxPLUProductQuantity.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPLUProductQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPLUProductQuantity.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxPLUProductQuantity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxPLUProductQuantity.Location = new System.Drawing.Point(180, 307);
            this.textBoxPLUProductQuantity.Name = "textBoxPLUProductQuantity";
            this.textBoxPLUProductQuantity.Size = new System.Drawing.Size(174, 27);
            this.textBoxPLUProductQuantity.TabIndex = 75;
            // 
            // textBoxPLUPriceLimitation
            // 
            this.textBoxPLUPriceLimitation.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPLUPriceLimitation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPLUPriceLimitation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxPLUPriceLimitation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxPLUPriceLimitation.Location = new System.Drawing.Point(180, 263);
            this.textBoxPLUPriceLimitation.Name = "textBoxPLUPriceLimitation";
            this.textBoxPLUPriceLimitation.ReadOnly = true;
            this.textBoxPLUPriceLimitation.Size = new System.Drawing.Size(174, 27);
            this.textBoxPLUPriceLimitation.TabIndex = 74;
            // 
            // textBoxPLUPrice
            // 
            this.textBoxPLUPrice.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPLUPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPLUPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxPLUPrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxPLUPrice.Location = new System.Drawing.Point(180, 216);
            this.textBoxPLUPrice.Name = "textBoxPLUPrice";
            this.textBoxPLUPrice.Size = new System.Drawing.Size(174, 27);
            this.textBoxPLUPrice.TabIndex = 73;
            // 
            // textBoxPLUName
            // 
            this.textBoxPLUName.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPLUName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPLUName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxPLUName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxPLUName.Location = new System.Drawing.Point(180, 172);
            this.textBoxPLUName.Name = "textBoxPLUName";
            this.textBoxPLUName.Size = new System.Drawing.Size(174, 27);
            this.textBoxPLUName.TabIndex = 72;
            // 
            // maskedTextBoxPluCode
            // 
            this.maskedTextBoxPluCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedTextBoxPluCode.Location = new System.Drawing.Point(180, 44);
            this.maskedTextBoxPluCode.Mask = "000000";
            this.maskedTextBoxPluCode.Name = "maskedTextBoxPluCode";
            this.maskedTextBoxPluCode.PromptChar = ' ';
            this.maskedTextBoxPluCode.Size = new System.Drawing.Size(174, 27);
            this.maskedTextBoxPluCode.TabIndex = 68;
            this.maskedTextBoxPluCode.Click += new System.EventHandler(this.maskedTextBoxPluCode_Click);
            this.maskedTextBoxPluCode.Leave += new System.EventHandler(this.maskedTextBoxPluCode_Leave);
            // 
            // buttonCancel
            // 
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonCancel.Location = new System.Drawing.Point(200, 406);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 50);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "VAZGEÇ";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBoxMainGroupNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxBarcode);
            this.groupBox1.Controls.Add(this.textBoxPLUProductQuantity);
            this.groupBox1.Controls.Add(this.textBoxPLUPriceLimitation);
            this.groupBox1.Controls.Add(this.textBoxPLUPrice);
            this.groupBox1.Controls.Add(this.textBoxPLUName);
            this.groupBox1.Controls.Add(this.comboBoxDepartmentId);
            this.groupBox1.Controls.Add(this.maskedTextBoxPluCode);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonOk);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 480);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(35, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 23);
            this.label8.TabIndex = 84;
            this.label8.Text = "PLU GRUP";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxMainGroupNo
            // 
            this.comboBoxMainGroupNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMainGroupNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMainGroupNo.DisplayMember = "strName";
            this.comboBoxMainGroupNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMainGroupNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxMainGroupNo.FormattingEnabled = true;
            this.comboBoxMainGroupNo.IntegralHeight = false;
            this.comboBoxMainGroupNo.Location = new System.Drawing.Point(180, 129);
            this.comboBoxMainGroupNo.MaxDropDownItems = 10;
            this.comboBoxMainGroupNo.Name = "comboBoxMainGroupNo";
            this.comboBoxMainGroupNo.Size = new System.Drawing.Size(174, 27);
            this.comboBoxMainGroupNo.TabIndex = 83;
            this.comboBoxMainGroupNo.ValueMember = "strName";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(93, 349);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 23);
            this.label7.TabIndex = 82;
            this.label7.Text = "BARKOD";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(17, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 23);
            this.label6.TabIndex = 81;
            this.label6.Text = "PLU ÜRÜN MİKTARI";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(15, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 23);
            this.label5.TabIndex = 80;
            this.label5.Text = "PLU FİYAT LİMİTİ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(71, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 79;
            this.label4.Text = "PLU FİYATI";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(93, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 23);
            this.label3.TabIndex = 78;
            this.label3.Text = "PLU ADI";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(35, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 77;
            this.label2.Text = "DEPARTMAN ADI";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxDepartmentId
            // 
            this.comboBoxDepartmentId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxDepartmentId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxDepartmentId.DisplayMember = "strName";
            this.comboBoxDepartmentId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDepartmentId.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxDepartmentId.FormattingEnabled = true;
            this.comboBoxDepartmentId.IntegralHeight = false;
            this.comboBoxDepartmentId.Location = new System.Drawing.Point(180, 88);
            this.comboBoxDepartmentId.MaxDropDownItems = 10;
            this.comboBoxDepartmentId.Name = "comboBoxDepartmentId";
            this.comboBoxDepartmentId.Size = new System.Drawing.Size(174, 27);
            this.comboBoxDepartmentId.TabIndex = 71;
            this.comboBoxDepartmentId.ValueMember = "strName";
            this.comboBoxDepartmentId.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepartmentId_SelectedIndexChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOk.Location = new System.Drawing.Point(56, 406);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(120, 50);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "KAYDET";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(93, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 67;
            this.label1.Text = "PLU NO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InputBoxNewPluDefinition
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(410, 508);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputBoxNewPluDefinition";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InputBoxPluDefinition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputBoxNewPluDefinition_FormClosing);
            this.Load += new System.EventHandler(this.InputBoxNewPluDefinition_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        //private void InputBoxPluDefinition_Load(object sender, System.EventArgs e)
        //{
        //  throw new System.NotImplementedException();
        //}

        #endregion

        private CustomTextBox textBoxBarcode;
        private CustomTextBox textBoxPLUProductQuantity;
        private CustomTextBox textBoxPLUPriceLimitation;
        private CustomTextBox textBoxPLUPrice;
        private CustomTextBox textBoxPLUName;
        private CustomMaskedTextBox maskedTextBoxPluCode;

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxMainGroupNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDepartmentId;
    }
}