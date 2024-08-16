using SaleFlex.UserInterface.Controls;

namespace SaleFlex.UserInterface.BoxForm
{
    partial class InputBoxSetupParameter
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
            this.textBoxMerchantId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.textBoxIpPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPosId = new System.Windows.Forms.TextBox();
            this.textBoxStoreNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMerchantId
            // 
            this.textBoxMerchantId.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxMerchantId.Location = new System.Drawing.Point(221, 76);
            this.textBoxMerchantId.MaxLength = 11;
            this.textBoxMerchantId.Name = "textBoxMerchantId";
            this.textBoxMerchantId.Size = new System.Drawing.Size(156, 27);
            this.textBoxMerchantId.TabIndex = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonExit);
            this.groupBox1.Controls.Add(this.textBoxIpPort);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxPosId);
            this.groupBox1.Controls.Add(this.textBoxStoreNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxMerchantId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonOk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 298);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ButtonExit
            // 
            this.ButtonExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonExit.Location = new System.Drawing.Point(257, 218);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(120, 50);
            this.ButtonExit.TabIndex = 56;
            this.ButtonExit.Text = "ÇIKIŞ";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxIpPort
            // 
            this.textBoxIpPort.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxIpPort.Location = new System.Drawing.Point(221, 168);
            this.textBoxIpPort.MaxLength = 11;
            this.textBoxIpPort.Name = "textBoxIpPort";
            this.textBoxIpPort.Size = new System.Drawing.Size(156, 27);
            this.textBoxIpPort.TabIndex = 55;
            this.textBoxIpPort.Text = "213.144.115.150";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(76, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 23);
            this.label4.TabIndex = 54;
            this.label4.Text = "Sunucu IP:Port:";
            // 
            // textBoxPosId
            // 
            this.textBoxPosId.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxPosId.Location = new System.Drawing.Point(221, 34);
            this.textBoxPosId.MaxLength = 11;
            this.textBoxPosId.Name = "textBoxPosId";
            this.textBoxPosId.Size = new System.Drawing.Size(156, 27);
            this.textBoxPosId.TabIndex = 53;
            this.textBoxPosId.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBoxStoreNo
            // 
            this.textBoxStoreNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxStoreNo.Location = new System.Drawing.Point(221, 122);
            this.textBoxStoreNo.MaxLength = 11;
            this.textBoxStoreNo.Name = "textBoxStoreNo";
            this.textBoxStoreNo.Size = new System.Drawing.Size(156, 27);
            this.textBoxStoreNo.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(76, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 23);
            this.label3.TabIndex = 51;
            this.label3.Text = "Şube No";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(78, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 23);
            this.label2.TabIndex = 49;
            this.label2.Text = "Pos No";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(76, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 23);
            this.label1.TabIndex = 48;
            this.label1.Text = "Bayi Kodu";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOk.Location = new System.Drawing.Point(80, 218);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(120, 50);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "TAMAM";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // InputBoxSetupParameter
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(490, 322);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputBoxSetupParameter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InputBoxSetupParameter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputBoxSetupParameter_FormClosing);
            this.Load += new System.EventHandler(this.InputBoxSetupParameter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMerchantId;
        private System.Windows.Forms.TextBox textBoxStoreNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPosId;
        private System.Windows.Forms.TextBox textBoxIpPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ButtonExit;
    }
}