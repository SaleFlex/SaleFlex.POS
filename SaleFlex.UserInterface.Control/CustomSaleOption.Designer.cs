namespace SaleFlex.UserInterface.Controls
{
    partial class CustomSaleOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomSaleOption));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonRepeat = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.LightBlue;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonCancel.Location = new System.Drawing.Point(12, 27);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(140, 80);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "REMOVE";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonRepeat
            // 
            this.buttonRepeat.BackColor = System.Drawing.Color.LightBlue;
            this.buttonRepeat.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonRepeat.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonRepeat.Location = new System.Drawing.Point(177, 27);
            this.buttonRepeat.Name = "buttonRepeat";
            this.buttonRepeat.Size = new System.Drawing.Size(140, 80);
            this.buttonRepeat.TabIndex = 1;
            this.buttonRepeat.Text = "REPEAT";
            this.buttonRepeat.UseVisualStyleBackColor = false;
            this.buttonRepeat.Click += new System.EventHandler(this.buttonRepeat_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.LightBlue;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonClose.Location = new System.Drawing.Point(342, 42);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 50);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "BACK";
            this.buttonClose.UseVisualStyleBackColor = false;
            // 
            // CustomSaleOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(474, 134);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonRepeat);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomSaleOption";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomSaleOption";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonRepeat;
        private System.Windows.Forms.Button buttonClose;
    }
}