using SaleFlex.UserInterface.Controls;
using SaleFlex.Data.Models;

namespace SaleFlex.UserInterface.BoxForm
{
    partial class InputBoxCompanyInformation
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
            this.textBoxCompanyWebAdress = new CustomTextBox(new FormControlDataModel("TEXTBOX","UPPER","LEFT","ALPHANUMERIC"));
            this.textBoxMersisIdNumber  = new CustomTextBox(new FormControlDataModel("TEXTBOX","UPPER","LEFT","NUMERIC"));
            this.textBoxNationalIdNumber = new CustomTextBox(new FormControlDataModel("TEXTBOX","UPPER","LEFT","NUMERIC"));
            this.textBoxTaxIdNumber = new CustomTextBox(new FormControlDataModel("TEXTBOX","UPPER","LEFT","NUMERIC"));
            
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCompanyWebAdress
            // 
            this.textBoxCompanyWebAdress.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCompanyWebAdress.Location = new System.Drawing.Point(187, 201);
            this.textBoxCompanyWebAdress.Name = "textBoxCompanyWebAdress";
            this.textBoxCompanyWebAdress.Size = new System.Drawing.Size(251, 27);
            this.textBoxCompanyWebAdress.TabIndex = 44;
            // 
            // textBoxMersisIdNumber
            // 
            this.textBoxMersisIdNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxMersisIdNumber.Location = new System.Drawing.Point(187, 147);
            this.textBoxMersisIdNumber.Name = "textBoxMersisIdNumber";
            this.textBoxMersisIdNumber.Size = new System.Drawing.Size(251, 27);
            this.textBoxMersisIdNumber.TabIndex = 43;
            this.textBoxMersisIdNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMersisIdNumber_KeyPress);
            // 
            // textBoxNationalIdNumber
            // 
            this.textBoxNationalIdNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxNationalIdNumber.Location = new System.Drawing.Point(187, 50);
            this.textBoxNationalIdNumber.Name = "textBoxNationalIdNumber";
            this.textBoxNationalIdNumber.Size = new System.Drawing.Size(251, 27);
            this.textBoxNationalIdNumber.TabIndex = 40;
            this.textBoxNationalIdNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNationalIdNumber_KeyPress);
            // 
            // textBoxTaxIdNumber
            // 
            this.textBoxTaxIdNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxTaxIdNumber.Location = new System.Drawing.Point(187, 101);
            this.textBoxTaxIdNumber.Name = "textBoxTaxIdNumber";
            this.textBoxTaxIdNumber.Size = new System.Drawing.Size(251, 27);
            this.textBoxTaxIdNumber.TabIndex = 41;
            this.textBoxTaxIdNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTaxIdNumber_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxCompanyWebAdress);
            this.groupBox1.Controls.Add(this.textBoxMersisIdNumber);
            this.groupBox1.Controls.Add(this.textBoxNationalIdNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxTaxIdNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonOk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 343);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(10, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 23);
            this.label4.TabIndex = 45;
            this.label4.Text = "WEB ADRES:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(10, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 23);
            this.label3.TabIndex = 42;
            this.label3.Text = "MERSİS NUMARASI:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "VERGİ NUMARASI:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "TC KİMLİK NUMARASI:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(16, -3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(175, 23);
            this.label13.TabIndex = 36;
            this.label13.Text = "ŞİRKET BİLGİLERİ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonCancel.Location = new System.Drawing.Point(262, 270);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 50);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "VAZGEÇ";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOk.Location = new System.Drawing.Point(71, 270);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(120, 50);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "TAMAM";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // InputBoxCompanyInformation
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(488, 369);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputBoxCompanyInformation";
            this.Text = "InputBoxCompanyInformation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputBoxCompanyInformation_FormClosing);
            this.Load += new System.EventHandler(this.InputBoxCompanyInformation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTextBox textBoxCompanyWebAdress;
        private CustomTextBox textBoxMersisIdNumber;
        private CustomTextBox textBoxNationalIdNumber;
        private CustomTextBox textBoxTaxIdNumber;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label4;

    }
}