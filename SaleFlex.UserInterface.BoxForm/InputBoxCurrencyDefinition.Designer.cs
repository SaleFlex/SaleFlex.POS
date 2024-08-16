using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Controls;

namespace SaleFlex.UserInterface.BoxForm
{
    partial class InputBoxCurrencyDefiniton
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
            this.textBoxCurrencySign = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "ALPHANUMERIC"));
            this.textBoxCurrencyCode = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "NUMERIC"));
            this.textBoxCurrencySymbol = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "ALPHANUMERIC"));
            this.textBoxRateOfCurrency = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "NUMERIC"));
            this.textBoxCurrencyName = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "ALPHANUMERIC"));


            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCurrencySignDirection = new System.Windows.Forms.ComboBox();
            this.comboBoxCurrencyId = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonCancel.Location = new System.Drawing.Point(223, 327);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 50);
            this.buttonCancel.TabIndex = 54;
            this.buttonCancel.Text = "VAZGEÇ";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxCurrencySign);
            this.groupBox1.Controls.Add(this.textBoxCurrencyCode);
            this.groupBox1.Controls.Add(this.textBoxCurrencySymbol);
            this.groupBox1.Controls.Add(this.textBoxRateOfCurrency);
            this.groupBox1.Controls.Add(this.textBoxCurrencyName);
            this.groupBox1.Controls.Add(this.comboBoxCurrencySignDirection);
            this.groupBox1.Controls.Add(this.comboBoxCurrencyId);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonOk);
            this.groupBox1.Location = new System.Drawing.Point(7, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 385);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "-";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(14, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 23);
            this.label5.TabIndex = 54;
            this.label5.Text = "DÖVİZ SEMBOLÜ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(10, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 23);
            this.label7.TabIndex = 53;
            this.label7.Text = "DÖVİZ İŞARET YÖNÜ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(50, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 23);
            this.label6.TabIndex = 52;
            this.label6.Text = "DÖVİZ İŞARETİ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(30, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 23);
            this.label4.TabIndex = 50;
            this.label4.Text = "DÖVİZ KODU";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(61, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 23);
            this.label3.TabIndex = 49;
            this.label3.Text = "DÖVİZ KURU";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(69, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 23);
            this.label2.TabIndex = 48;
            this.label2.Text = "DÖVİZ ADI";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(63, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 23);
            this.label1.TabIndex = 47;
            this.label1.Text = "DÖVİZ NO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCurrencySign
            // 
            this.textBoxCurrencySign.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCurrencySign.Location = new System.Drawing.Point(194, 233);
            this.textBoxCurrencySign.Name = "textBoxCurrencySign";
            this.textBoxCurrencySign.Size = new System.Drawing.Size(181, 27);
            this.textBoxCurrencySign.TabIndex = 46;
            // 
            // textBoxCurrencyCode
            // 
            this.textBoxCurrencyCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCurrencyCode.Location = new System.Drawing.Point(195, 147);
            this.textBoxCurrencyCode.Name = "textBoxCurrencyCode";
            this.textBoxCurrencyCode.Size = new System.Drawing.Size(181, 27);
            this.textBoxCurrencyCode.TabIndex = 44;
            // 
            // textBoxCurrencySymbol
            // 
            this.textBoxCurrencySymbol.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCurrencySymbol.Location = new System.Drawing.Point(195, 189);
            this.textBoxCurrencySymbol.Name = "textBoxCurrencySymbol";
            this.textBoxCurrencySymbol.Size = new System.Drawing.Size(181, 27);
            this.textBoxCurrencySymbol.TabIndex = 45;
            // 
            // textBoxRateOfCurrency
            // 
            this.textBoxRateOfCurrency.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxRateOfCurrency.Location = new System.Drawing.Point(195, 101);
            this.textBoxRateOfCurrency.Name = "textBoxRateOfCurrency";
            this.textBoxRateOfCurrency.Size = new System.Drawing.Size(181, 27);
            this.textBoxRateOfCurrency.TabIndex = 43;
            // 
            // textBoxCurrencyName
            // 
            this.textBoxCurrencyName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCurrencyName.Location = new System.Drawing.Point(195, 61);
            this.textBoxCurrencyName.Name = "textBoxCurrencyName";
            this.textBoxCurrencyName.Size = new System.Drawing.Size(181, 27);
            this.textBoxCurrencyName.TabIndex = 42;
            // 
            // comboBoxCurrencySignDirection
            // 
            this.comboBoxCurrencySignDirection.DisplayMember = "strName";
            this.comboBoxCurrencySignDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrencySignDirection.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxCurrencySignDirection.FormattingEnabled = true;
            this.comboBoxCurrencySignDirection.Items.AddRange(new object[] {
            "LEFT",
            "RIGHT"});
            this.comboBoxCurrencySignDirection.Location = new System.Drawing.Point(194, 275);
            this.comboBoxCurrencySignDirection.Name = "comboBoxCurrencySignDirection";
            this.comboBoxCurrencySignDirection.Size = new System.Drawing.Size(181, 27);
            this.comboBoxCurrencySignDirection.TabIndex = 48;
            // 
            // comboBoxCurrencyId
            // 
            this.comboBoxCurrencyId.DisplayMember = "strName";
            this.comboBoxCurrencyId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrencyId.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxCurrencyId.FormattingEnabled = true;
            this.comboBoxCurrencyId.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxCurrencyId.Location = new System.Drawing.Point(195, 18);
            this.comboBoxCurrencyId.Name = "comboBoxCurrencyId";
            this.comboBoxCurrencyId.Size = new System.Drawing.Size(181, 27);
            this.comboBoxCurrencyId.TabIndex = 40;
            this.comboBoxCurrencyId.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrencyId_SelectedIndexChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOk.Location = new System.Drawing.Point(82, 327);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(120, 50);
            this.buttonOk.TabIndex = 52;
            this.buttonOk.Text = "TAMAM";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // InputBoxCurrencyDefiniton
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(413, 395);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputBoxCurrencyDefiniton";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InputBoxCurrencyDefinition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputBoxCurrencyDefiniton_FormClosing);
            this.Load += new System.EventHandler(this.InputBoxCurrencyDefiniton_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTextBox textBoxCurrencySign;
        private CustomTextBox textBoxCurrencyCode;
        private CustomTextBox textBoxCurrencySymbol;
        private CustomTextBox textBoxRateOfCurrency;
        private CustomTextBox textBoxCurrencyName;

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ComboBox comboBoxCurrencySignDirection;
        private System.Windows.Forms.ComboBox comboBoxCurrencyId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}