using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Controls;

namespace SaleFlex.UserInterface.BoxForm
{
    partial class InputBoxReceiptFooter
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
            this.textBoxFooterLine5 = new CustomTextBox(new FormControlDataModel("TEXTBOX","UPPER","LEFT","ALPHANUMERIC"));
            this.textBoxFooterLine4 = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "ALPHANUMERIC"));
            this.textBoxFooterLine3 = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "ALPHANUMERIC"));
            this.textBoxFooterLine2 = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "ALPHANUMERIC"));
            this.textBoxFooterLine1 = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "ALPHANUMERIC"));
           
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxFooterLine5
            // 
            this.textBoxFooterLine5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxFooterLine5.Location = new System.Drawing.Point(105, 187);
            this.textBoxFooterLine5.MaxLength = 32;
            this.textBoxFooterLine5.Name = "textBoxFooterLine5";
            this.textBoxFooterLine5.Size = new System.Drawing.Size(165, 27);
            this.textBoxFooterLine5.TabIndex = 54;
            this.textBoxFooterLine5.Visible = false;
            // 
            // textBoxFooterLine4
            // 
            this.textBoxFooterLine4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxFooterLine4.Location = new System.Drawing.Point(105, 154);
            this.textBoxFooterLine4.MaxLength = 32;
            this.textBoxFooterLine4.Name = "textBoxFooterLine4";
            this.textBoxFooterLine4.Size = new System.Drawing.Size(165, 27);
            this.textBoxFooterLine4.TabIndex = 52;
            this.textBoxFooterLine4.Visible = false;
            // 
            // textBoxFooterLine3
            // 
            this.textBoxFooterLine3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxFooterLine3.Location = new System.Drawing.Point(105, 121);
            this.textBoxFooterLine3.MaxLength = 32;
            this.textBoxFooterLine3.Name = "textBoxFooterLine3";
            this.textBoxFooterLine3.Size = new System.Drawing.Size(165, 27);
            this.textBoxFooterLine3.TabIndex = 50;
            this.textBoxFooterLine3.Visible = false;
            // 
            // textBoxFooterLine2
            // 
            this.textBoxFooterLine2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxFooterLine2.Location = new System.Drawing.Point(105, 88);
            this.textBoxFooterLine2.MaxLength = 32;
            this.textBoxFooterLine2.Name = "textBoxFooterLine2";
            this.textBoxFooterLine2.Size = new System.Drawing.Size(165, 27);
            this.textBoxFooterLine2.TabIndex = 48;
            // 
            // textBoxFooterLine1
            // 
            this.textBoxFooterLine1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxFooterLine1.Location = new System.Drawing.Point(105, 55);
            this.textBoxFooterLine1.MaxLength = 32;
            this.textBoxFooterLine1.Name = "textBoxFooterLine1";
            this.textBoxFooterLine1.Size = new System.Drawing.Size(165, 27);
            this.textBoxFooterLine1.TabIndex = 46;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonCancel.Location = new System.Drawing.Point(150, 220);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 50);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "VAZGEÇ";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxFooterLine5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxFooterLine4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxFooterLine3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxFooterLine2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxFooterLine1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonOk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 276);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(11, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 23);
            this.label5.TabIndex = 55;
            this.label5.Text = "SATIR 5:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(11, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 23);
            this.label4.TabIndex = 53;
            this.label4.Text = "SATIR 4:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(11, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 23);
            this.label3.TabIndex = 51;
            this.label3.Text = "SATIR 3:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(11, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 49;
            this.label2.Text = "SATIR 2:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(11, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 47;
            this.label1.Text = "SATIR 1:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(6, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(244, 23);
            this.label13.TabIndex = 34;
            this.label13.Text = "FİŞ KAPANIŞ MESAJI";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOk.Location = new System.Drawing.Point(6, 220);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(120, 50);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "TAMAM";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // InputBoxReceiptFooter
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputBoxReceiptFooter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InputBoxReceiptFooter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputBoxReceiptFooter_FormClosing);
            this.Load += new System.EventHandler(this.InputBoxReceiptFooter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTextBox textBoxFooterLine5;
        private CustomTextBox textBoxFooterLine4;
        private CustomTextBox textBoxFooterLine3;
        private CustomTextBox textBoxFooterLine2;
        private CustomTextBox textBoxFooterLine1;

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}