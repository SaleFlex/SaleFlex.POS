using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Controls;

namespace SaleFlex.UserInterface.BoxForm
{
    partial class InputBoxPluMainGroupDefinition
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
            this.textBoxPLUGroupName = new CustomTextBox(new FormControlDataModel("TEXTBOX", "UPPER", "LEFT", "ALPHANUMERIC"));

            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPluMainGroupNo = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPLUGroupName
            // 
            this.textBoxPLUGroupName.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPLUGroupName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPLUGroupName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxPLUGroupName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxPLUGroupName.Location = new System.Drawing.Point(150, 92);
            this.textBoxPLUGroupName.Name = "textBoxPLUGroupName";
            this.textBoxPLUGroupName.Size = new System.Drawing.Size(214, 27);
            this.textBoxPLUGroupName.TabIndex = 55;
            // 
            // buttonCancel
            // 
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonCancel.Location = new System.Drawing.Point(258, 170);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 50);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "VAZGEÇ";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonNew);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxPLUGroupName);
            this.groupBox1.Controls.Add(this.comboBoxPluMainGroupNo);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonOk);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 256);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // buttonNew
            // 
            this.buttonNew.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonNew.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonNew.Location = new System.Drawing.Point(12, 170);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(120, 50);
            this.buttonNew.TabIndex = 68;
            this.buttonNew.Text = "YENİ KAYIT";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 23);
            this.label1.TabIndex = 67;
            this.label1.Text = "PLU GRUP NO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(10, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 23);
            this.label3.TabIndex = 62;
            this.label3.Text = "PLU GRUP ADI";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxPluMainGroupNo
            // 
            this.comboBoxPluMainGroupNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPluMainGroupNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPluMainGroupNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPluMainGroupNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxPluMainGroupNo.FormattingEnabled = true;
            this.comboBoxPluMainGroupNo.IntegralHeight = false;
            this.comboBoxPluMainGroupNo.Location = new System.Drawing.Point(150, 47);
            this.comboBoxPluMainGroupNo.MaxDropDownItems = 20;
            this.comboBoxPluMainGroupNo.Name = "comboBoxPluMainGroupNo";
            this.comboBoxPluMainGroupNo.Size = new System.Drawing.Size(214, 27);
            this.comboBoxPluMainGroupNo.TabIndex = 4;
            this.comboBoxPluMainGroupNo.SelectedIndexChanged += new System.EventHandler(this.comboBoxPluMainGroupId_SelectedIndexChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOk.Location = new System.Drawing.Point(135, 170);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(120, 50);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "TAMAM";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // InputBoxPluMainGroupDefinition
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(410, 281);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputBoxPluMainGroupDefinition";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InputBoxPluDefinition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputBoxPluMainGroupDefinition_FormClosing);
            this.Load += new System.EventHandler(this.InputBoxPluMainGroupDefinition_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        //private void InputBoxPluDefinition_Load(object sender, System.EventArgs e)
        //{
        //  throw new System.NotImplementedException();
        //}

        #endregion

        private CustomTextBox textBoxPLUGroupName;

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPluMainGroupNo;
        private System.Windows.Forms.Button buttonNew;
    }
}