
namespace SaleFlex.UserInterface.Controls
{
    public partial class CustomNumpad
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonComma = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonZero = new System.Windows.Forms.Button();
            this.buttonSeven = new System.Windows.Forms.Button();
            this.buttonEight = new System.Windows.Forms.Button();
            this.buttonNine = new System.Windows.Forms.Button();
            this.buttonFour = new System.Windows.Forms.Button();
            this.buttonFive = new System.Windows.Forms.Button();
            this.buttonSix = new System.Windows.Forms.Button();
            this.buttonOne = new System.Windows.Forms.Button();
            this.buttonTwo = new System.Windows.Forms.Button();
            this.buttonThree = new System.Windows.Forms.Button();
            this.textBoxOuput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonDelete.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(115, 34);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(113, 50);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "SİL ←";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonComma
            // 
            this.buttonComma.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonComma.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonComma.ForeColor = System.Drawing.Color.Black;
            this.buttonComma.Location = new System.Drawing.Point(1, 237);
            this.buttonComma.Name = "buttonComma";
            this.buttonComma.Size = new System.Drawing.Size(75, 50);
            this.buttonComma.TabIndex = 12;
            this.buttonComma.Text = ",";
            this.buttonComma.UseVisualStyleBackColor = false;
            this.buttonComma.Click += new System.EventHandler(this.buttonComma_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonOk.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOk.ForeColor = System.Drawing.Color.White;
            this.buttonOk.Location = new System.Drawing.Point(153, 237);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 50);
            this.buttonOk.TabIndex = 14;
            this.buttonOk.Text = "GİRİŞ";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonX
            // 
            this.buttonX.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonX.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonX.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonX.ForeColor = System.Drawing.Color.White;
            this.buttonX.Location = new System.Drawing.Point(0, 34);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(113, 50);
            this.buttonX.TabIndex = 1;
            this.buttonX.Text = "X";
            this.buttonX.UseVisualStyleBackColor = false;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            // 
            // buttonZero
            // 
            this.buttonZero.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonZero.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonZero.ForeColor = System.Drawing.Color.Black;
            this.buttonZero.Location = new System.Drawing.Point(77, 237);
            this.buttonZero.Name = "buttonZero";
            this.buttonZero.Size = new System.Drawing.Size(75, 50);
            this.buttonZero.TabIndex = 13;
            this.buttonZero.Text = "0";
            this.buttonZero.UseVisualStyleBackColor = false;
            this.buttonZero.Click += new System.EventHandler(this.buttonZero_Click);
            // 
            // buttonSeven
            // 
            this.buttonSeven.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonSeven.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSeven.ForeColor = System.Drawing.Color.Black;
            this.buttonSeven.Location = new System.Drawing.Point(1, 84);
            this.buttonSeven.Name = "buttonSeven";
            this.buttonSeven.Size = new System.Drawing.Size(75, 50);
            this.buttonSeven.TabIndex = 3;
            this.buttonSeven.Text = "7";
            this.buttonSeven.UseVisualStyleBackColor = false;
            this.buttonSeven.Click += new System.EventHandler(this.buttonSeven_Click);
            // 
            // buttonEight
            // 
            this.buttonEight.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonEight.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonEight.ForeColor = System.Drawing.Color.Black;
            this.buttonEight.Location = new System.Drawing.Point(77, 84);
            this.buttonEight.Name = "buttonEight";
            this.buttonEight.Size = new System.Drawing.Size(75, 50);
            this.buttonEight.TabIndex = 4;
            this.buttonEight.Text = "8";
            this.buttonEight.UseVisualStyleBackColor = false;
            this.buttonEight.Click += new System.EventHandler(this.buttonEight_Click);
            // 
            // buttonNine
            // 
            this.buttonNine.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonNine.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonNine.ForeColor = System.Drawing.Color.Black;
            this.buttonNine.Location = new System.Drawing.Point(153, 84);
            this.buttonNine.Name = "buttonNine";
            this.buttonNine.Size = new System.Drawing.Size(75, 50);
            this.buttonNine.TabIndex = 5;
            this.buttonNine.Text = "9";
            this.buttonNine.UseVisualStyleBackColor = false;
            this.buttonNine.Click += new System.EventHandler(this.buttonNine_Click);
            // 
            // buttonFour
            // 
            this.buttonFour.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonFour.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonFour.ForeColor = System.Drawing.Color.Black;
            this.buttonFour.Location = new System.Drawing.Point(1, 135);
            this.buttonFour.Name = "buttonFour";
            this.buttonFour.Size = new System.Drawing.Size(75, 50);
            this.buttonFour.TabIndex = 6;
            this.buttonFour.Text = "4";
            this.buttonFour.UseVisualStyleBackColor = false;
            this.buttonFour.Click += new System.EventHandler(this.buttonFour_Click);
            // 
            // buttonFive
            // 
            this.buttonFive.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonFive.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonFive.ForeColor = System.Drawing.Color.Black;
            this.buttonFive.Location = new System.Drawing.Point(77, 135);
            this.buttonFive.Name = "buttonFive";
            this.buttonFive.Size = new System.Drawing.Size(75, 50);
            this.buttonFive.TabIndex = 7;
            this.buttonFive.Text = "5";
            this.buttonFive.UseVisualStyleBackColor = false;
            this.buttonFive.Click += new System.EventHandler(this.buttonFive_Click);
            // 
            // buttonSix
            // 
            this.buttonSix.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonSix.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSix.ForeColor = System.Drawing.Color.Black;
            this.buttonSix.Location = new System.Drawing.Point(153, 135);
            this.buttonSix.Name = "buttonSix";
            this.buttonSix.Size = new System.Drawing.Size(75, 50);
            this.buttonSix.TabIndex = 8;
            this.buttonSix.Text = "6";
            this.buttonSix.UseVisualStyleBackColor = false;
            this.buttonSix.Click += new System.EventHandler(this.buttonSix_Click);
            // 
            // buttonOne
            // 
            this.buttonOne.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonOne.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOne.ForeColor = System.Drawing.Color.Black;
            this.buttonOne.Location = new System.Drawing.Point(1, 186);
            this.buttonOne.Name = "buttonOne";
            this.buttonOne.Size = new System.Drawing.Size(75, 50);
            this.buttonOne.TabIndex = 9;
            this.buttonOne.Text = "1";
            this.buttonOne.UseVisualStyleBackColor = false;
            this.buttonOne.Click += new System.EventHandler(this.buttonOne_Click);
            // 
            // buttonTwo
            // 
            this.buttonTwo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonTwo.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonTwo.ForeColor = System.Drawing.Color.Black;
            this.buttonTwo.Location = new System.Drawing.Point(77, 186);
            this.buttonTwo.Name = "buttonTwo";
            this.buttonTwo.Size = new System.Drawing.Size(75, 50);
            this.buttonTwo.TabIndex = 10;
            this.buttonTwo.Text = "2";
            this.buttonTwo.UseVisualStyleBackColor = false;
            this.buttonTwo.Click += new System.EventHandler(this.buttonTwo_Click);
            // 
            // buttonThree
            // 
            this.buttonThree.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonThree.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonThree.ForeColor = System.Drawing.Color.Black;
            this.buttonThree.Location = new System.Drawing.Point(153, 186);
            this.buttonThree.Name = "buttonThree";
            this.buttonThree.Size = new System.Drawing.Size(75, 50);
            this.buttonThree.TabIndex = 11;
            this.buttonThree.Text = "3";
            this.buttonThree.UseVisualStyleBackColor = false;
            this.buttonThree.Click += new System.EventHandler(this.buttonThree_Click);
            // 
            // textBoxOuput
            // 
            this.textBoxOuput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOuput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxOuput.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxOuput.Location = new System.Drawing.Point(1, 1);
            this.textBoxOuput.Name = "textBoxOuput";
            this.textBoxOuput.Size = new System.Drawing.Size(226, 31);
            this.textBoxOuput.TabIndex = 0;
            this.textBoxOuput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxOuput.TextChanged += new System.EventHandler(this.textBoxOuput_TextChanged);
            this.textBoxOuput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxOuput_KeyDown);
            this.textBoxOuput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOuput_KeyPress);
            this.textBoxOuput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxOuput_KeyUp);
            // 
            // CustomNumpad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textBoxOuput);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonComma);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonX);
            this.Controls.Add(this.buttonZero);
            this.Controls.Add(this.buttonSeven);
            this.Controls.Add(this.buttonEight);
            this.Controls.Add(this.buttonNine);
            this.Controls.Add(this.buttonFour);
            this.Controls.Add(this.buttonFive);
            this.Controls.Add(this.buttonSix);
            this.Controls.Add(this.buttonOne);
            this.Controls.Add(this.buttonTwo);
            this.Controls.Add(this.buttonThree);
            this.Name = "CustomNumpad";
            this.Size = new System.Drawing.Size(228, 298);
            this.Load += new System.EventHandler(this.CustomNumpad_Load);
            this.Enter += new System.EventHandler(this.CustomNumpad_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonComma;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonZero;
        private System.Windows.Forms.Button buttonSeven;
        private System.Windows.Forms.Button buttonEight;
        private System.Windows.Forms.Button buttonNine;
        private System.Windows.Forms.Button buttonFour;
        private System.Windows.Forms.Button buttonFive;
        private System.Windows.Forms.Button buttonSix;
        private System.Windows.Forms.Button buttonOne;
        private System.Windows.Forms.Button buttonTwo;
        private System.Windows.Forms.Button buttonThree;
        private System.Windows.Forms.TextBox textBoxOuput;
    }
}
