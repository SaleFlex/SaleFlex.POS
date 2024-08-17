namespace SaleFlex.UserInterface.BoxForm
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelDownloading = new System.Windows.Forms.Label();
            this.labelProductDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.BackColor = System.Drawing.Color.Transparent;
            this.labelProductName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProductName.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelProductName.Location = new System.Drawing.Point(15, 217);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(116, 17);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "SaleFlex.POS";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDownloading
            // 
            this.labelDownloading.AutoSize = true;
            this.labelDownloading.BackColor = System.Drawing.Color.Transparent;
            this.labelDownloading.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelDownloading.ForeColor = System.Drawing.Color.LightCyan;
            this.labelDownloading.Location = new System.Drawing.Point(15, 335);
            this.labelDownloading.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelDownloading.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelDownloading.Name = "labelDownloading";
            this.labelDownloading.Size = new System.Drawing.Size(130, 17);
            this.labelDownloading.TabIndex = 23;
            this.labelDownloading.Text = "Downloading...";
            this.labelDownloading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProductDescription
            // 
            this.labelProductDescription.AutoSize = true;
            this.labelProductDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelProductDescription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProductDescription.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelProductDescription.Location = new System.Drawing.Point(15, 243);
            this.labelProductDescription.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductDescription.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelProductDescription.Name = "labelProductDescription";
            this.labelProductDescription.Size = new System.Drawing.Size(101, 17);
            this.labelProductDescription.TabIndex = 24;
            this.labelProductDescription.Text = "SaleFlex.POS";
            this.labelProductDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(425, 425);
            this.Controls.Add(this.labelProductDescription);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.labelDownloading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaleFlex.POS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelDownloading;
        private System.Windows.Forms.Label labelProductDescription;
    }
}
