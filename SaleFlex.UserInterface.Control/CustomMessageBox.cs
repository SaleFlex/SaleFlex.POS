using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.AccessLayer;
using SaleFlex.Data.Models;
using SaleFlex.Data;

namespace SaleFlex.UserInterface.Controls
{
    static public class CustomMessageBox
    {
        static public DialogResult Show(string prm_strMessageBoxLine1, string prm_strMessageBoxLine2)
        {
            return Show(string.Format("{0,-45}{1}{2,-45}", prm_strMessageBoxLine1, Environment.NewLine, prm_strMessageBoxLine2));
        }

        static public DialogResult Show(string prm_strMessage, bool prm_bIsWarningMessageBox)
        {
            return Show(prm_strMessage, MessageBoxButtons.OK, prm_bIsWarningMessageBox);
        }

        static public DialogResult Show(string prm_strMessage, MessageBoxButtons prm_xMessageBoxButtons = MessageBoxButtons.OK, bool prm_bIsWarningMessageBox = false)
        {
            Form xForm = new Form();            
            xForm.FormClosing += xForm_FormClosing;

            if (prm_xMessageBoxButtons == MessageBoxButtons.OK)
            {
                Button xButtonOk = new Button();
                xButtonOk.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonOk.Location = new System.Drawing.Point(180, 183);
                xButtonOk.Name = "buttonOk";
                xButtonOk.Size = new System.Drawing.Size(120, 50);
                xButtonOk.TabIndex = 0;
                xButtonOk.Text = "TAMAM";
                xButtonOk.UseVisualStyleBackColor = true;
                xButtonOk.DialogResult = DialogResult.OK;

                Label xLabelMessage = new Label();
                xLabelMessage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xLabelMessage.Location = new System.Drawing.Point(12, 9);
                xLabelMessage.Name = "labelMessage";
                xLabelMessage.Size = new System.Drawing.Size(456, 171);
                xLabelMessage.TabIndex = 1;
                xLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                xLabelMessage.Text = prm_strMessage;

                GroupBox xGoupBox = new GroupBox();
                xGoupBox.Controls.Add(xLabelMessage);
                xGoupBox.Controls.Add(xButtonOk);
                xGoupBox.Location = new System.Drawing.Point(2, 2);
                xGoupBox.Name = "xGoupBox";
                xGoupBox.Size = new System.Drawing.Size(476, 236);
                xGoupBox.TabIndex = 113;
                xGoupBox.TabStop = false;


                xForm.AcceptButton = xButtonOk;
                xForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                xForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                if (prm_bIsWarningMessageBox == true)
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxForeColor);
                }
                else
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxForeColor);
                }
                xForm.ClientSize = new System.Drawing.Size(480, 240);
                xForm.ControlBox = false;
                xForm.Controls.Add(xGoupBox);
                xForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                xForm.Name = "CustomMessageBox";
                xForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                xForm.Text = "CustomMessageBox";
                xForm.TopMost = true;
            }
            else if (prm_xMessageBoxButtons == MessageBoxButtons.YesNo)
            {
                Button xButtonYes = new Button();
                xButtonYes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonYes.Location = new System.Drawing.Point(100, 183);
                xButtonYes.Name = "buttonYes";
                xButtonYes.Size = new System.Drawing.Size(120, 50);
                xButtonYes.TabIndex = 0;
                xButtonYes.Text = "EVET";
                xButtonYes.UseVisualStyleBackColor = true;
                xButtonYes.DialogResult = DialogResult.Yes;

                Button xButtonNo = new Button();
                xButtonNo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonNo.Location = new System.Drawing.Point(280, 183);
                xButtonNo.Name = "buttonNo";
                xButtonNo.Size = new System.Drawing.Size(120, 50);
                xButtonNo.TabIndex = 2;
                xButtonNo.Text = "HAYIR";
                xButtonNo.UseVisualStyleBackColor = true;
                xButtonNo.DialogResult = DialogResult.No;

                Label xLabelMessage = new Label();
                xLabelMessage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xLabelMessage.Location = new System.Drawing.Point(12, 9);
                xLabelMessage.Name = "labelMessage";
                xLabelMessage.Size = new System.Drawing.Size(456, 171);
                xLabelMessage.TabIndex = 1;
                xLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                xLabelMessage.Text = prm_strMessage;

                GroupBox xGoupBox = new GroupBox();
                xGoupBox.Controls.Add(xLabelMessage);
                xGoupBox.Controls.Add(xButtonYes);
                xGoupBox.Controls.Add(xButtonNo);
                xGoupBox.Location = new System.Drawing.Point(2, 2);
                xGoupBox.Name = "xGoupBox";
                xGoupBox.Size = new System.Drawing.Size(476, 236);
                xGoupBox.TabIndex = 113;
                xGoupBox.TabStop = false;

                xForm.AcceptButton = xButtonYes;
                xForm.CancelButton = xButtonNo;
                xForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                xForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                if (prm_bIsWarningMessageBox == true)
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxForeColor);
                }
                else
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxForeColor);
                } 
                xForm.ClientSize = new System.Drawing.Size(480, 240);
                xForm.ControlBox = false;
                xForm.Controls.Add(xGoupBox);
                xForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                xForm.Name = "CustomMessageBox";
                xForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                xForm.Text = "CustomMessageBox";
                xForm.TopMost = true;
            }
            else if (prm_xMessageBoxButtons == MessageBoxButtons.YesNoCancel)
            {
                Button xButtonYes = new Button();
                xButtonYes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonYes.Location = new System.Drawing.Point(180, 183);
                xButtonYes.Name = "buttonYes";
                xButtonYes.Size = new System.Drawing.Size(120, 50);
                xButtonYes.TabIndex = 2;
                xButtonYes.Text = "EVET";
                xButtonYes.UseVisualStyleBackColor = true;
                xButtonYes.DialogResult = DialogResult.Yes;

                Button xButtonNo = new Button();
                xButtonNo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonNo.Location = new System.Drawing.Point(30, 183);
                xButtonNo.Name = "buttonNo";
                xButtonNo.Size = new System.Drawing.Size(120, 50);
                xButtonNo.TabIndex = 0;
                xButtonNo.Text = "HAYIR";
                xButtonNo.UseVisualStyleBackColor = true;
                xButtonNo.DialogResult = DialogResult.No;

                Button xButtonCancel = new Button();
                xButtonCancel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonCancel.Location = new System.Drawing.Point(330, 183);
                xButtonCancel.Name = "buttonNo";
                xButtonCancel.Size = new System.Drawing.Size(120, 50);
                xButtonCancel.TabIndex = 0;
                xButtonCancel.Text = "VAZGEÇ";
                xButtonCancel.UseVisualStyleBackColor = true;
                xButtonCancel.DialogResult = DialogResult.No;

                Label xLabelMessage = new Label();
                xLabelMessage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xLabelMessage.Location = new System.Drawing.Point(12, 9);
                xLabelMessage.Name = "labelMessage";
                xLabelMessage.Size = new System.Drawing.Size(456, 171);
                xLabelMessage.TabIndex = 1;
                xLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                xLabelMessage.Text = prm_strMessage;

                GroupBox xGoupBox = new GroupBox();
                xGoupBox.Controls.Add(xLabelMessage);
                xGoupBox.Controls.Add(xButtonYes);
                xGoupBox.Controls.Add(xButtonNo);
                xGoupBox.Controls.Add(xButtonCancel);
                xGoupBox.Location = new System.Drawing.Point(2, 2);
                xGoupBox.Name = "xGoupBox";
                xGoupBox.Size = new System.Drawing.Size(476, 236);
                xGoupBox.TabIndex = 113;
                xGoupBox.TabStop = false;

                xForm.AcceptButton = xButtonYes;
                xForm.CancelButton = xButtonCancel;
                xForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                xForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                if (prm_bIsWarningMessageBox == true)
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxForeColor);
                }
                else
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxForeColor);
                } 
                xForm.ClientSize = new System.Drawing.Size(480, 240);
                xForm.ControlBox = false;
                xForm.Controls.Add(xGoupBox);
                xForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                xForm.Name = "CustomMessageBox";
                xForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                xForm.Text = "CustomMessageBox";
                xForm.TopMost = true;
            }
            else if (prm_xMessageBoxButtons == MessageBoxButtons.RetryCancel)
            {
                Button xButtonRetry = new Button();
                xButtonRetry.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonRetry.Location = new System.Drawing.Point(280, 183);
                xButtonRetry.Name = "buttonYes";
                xButtonRetry.Size = new System.Drawing.Size(120, 50);
                xButtonRetry.TabIndex = 2;
                xButtonRetry.Text = "TEKRAR DENE";
                xButtonRetry.UseVisualStyleBackColor = true;
                xButtonRetry.DialogResult = DialogResult.Yes;

                Button xButtonCancel = new Button();
                xButtonCancel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonCancel.Location = new System.Drawing.Point(100, 183);
                xButtonCancel.Name = "buttonNo";
                xButtonCancel.Size = new System.Drawing.Size(120, 50);
                xButtonCancel.TabIndex = 0;
                xButtonCancel.Text = "VAZGEÇ";
                xButtonCancel.UseVisualStyleBackColor = true;
                xButtonCancel.DialogResult = DialogResult.No;

                Label xLabelMessage = new Label();
                xLabelMessage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xLabelMessage.Location = new System.Drawing.Point(12, 9);
                xLabelMessage.Name = "labelMessage";
                xLabelMessage.Size = new System.Drawing.Size(456, 171);
                xLabelMessage.TabIndex = 1;
                xLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                xLabelMessage.Text = prm_strMessage;

                GroupBox xGoupBox = new GroupBox();
                xGoupBox.Controls.Add(xLabelMessage);
                xGoupBox.Controls.Add(xButtonRetry);
                xGoupBox.Controls.Add(xButtonCancel);
                xGoupBox.Location = new System.Drawing.Point(2, 2);
                xGoupBox.Name = "xGoupBox";
                xGoupBox.Size = new System.Drawing.Size(476, 236);
                xGoupBox.TabIndex = 113;
                xGoupBox.TabStop = false;

                xForm.AcceptButton = xButtonRetry;
                xForm.CancelButton = xButtonCancel;
                xForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                xForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                if (prm_bIsWarningMessageBox == true)
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxForeColor);
                }
                else
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxForeColor);
                } 
                xForm.ClientSize = new System.Drawing.Size(480, 240);
                xForm.ControlBox = false;
                xForm.Controls.Add(xGoupBox);
                xForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                xForm.Name = "CustomMessageBox";
                xForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                xForm.Text = "CustomMessageBox";
                xForm.TopMost = true;
            }
            else if (prm_xMessageBoxButtons == MessageBoxButtons.OKCancel)
            {
                Button xButtonOk = new Button();
                xButtonOk.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonOk.Location = new System.Drawing.Point(280, 183);
                xButtonOk.Name = "buttonYes";
                xButtonOk.Size = new System.Drawing.Size(120, 50);
                xButtonOk.TabIndex = 2;
                xButtonOk.Text = "TAMAM";
                xButtonOk.UseVisualStyleBackColor = true;
                xButtonOk.DialogResult = DialogResult.Yes;

                Button xButtonCancel = new Button();
                xButtonCancel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonCancel.Location = new System.Drawing.Point(100, 183);
                xButtonCancel.Name = "buttonNo";
                xButtonCancel.Size = new System.Drawing.Size(120, 50);
                xButtonCancel.TabIndex = 0;
                xButtonCancel.Text = "VAZGEÇ";
                xButtonCancel.UseVisualStyleBackColor = true;
                xButtonCancel.DialogResult = DialogResult.No;

                Label xLabelMessage = new Label();
                xLabelMessage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xLabelMessage.Location = new System.Drawing.Point(12, 9);
                xLabelMessage.Name = "labelMessage";
                xLabelMessage.Size = new System.Drawing.Size(456, 171);
                xLabelMessage.TabIndex = 1;
                xLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                xLabelMessage.Text = prm_strMessage;

                GroupBox xGoupBox = new GroupBox();
                xGoupBox.Controls.Add(xLabelMessage);
                xGoupBox.Controls.Add(xButtonOk);
                xGoupBox.Controls.Add(xButtonCancel);
                xGoupBox.Location = new System.Drawing.Point(2, 2);
                xGoupBox.Name = "xGoupBox";
                xGoupBox.Size = new System.Drawing.Size(476, 236);
                xGoupBox.TabIndex = 113;
                xGoupBox.TabStop = false;

                xForm.AcceptButton = xButtonOk;
                xForm.CancelButton = xButtonCancel;
                xForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                xForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                if (prm_bIsWarningMessageBox == true)
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxForeColor);
                }
                else
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxForeColor);
                } 
                xForm.ClientSize = new System.Drawing.Size(480, 240);
                xForm.ControlBox = false;
                xForm.Controls.Add(xGoupBox);
                xForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                xForm.Name = "CustomMessageBox";
                xForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                xForm.Text = "CustomMessageBox";
                xForm.TopMost = true;
            }
            else if (prm_xMessageBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                Button xButtonRetry = new Button();
                xButtonRetry.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonRetry.Location = new System.Drawing.Point(180, 183);
                xButtonRetry.Name = "buttonYes";
                xButtonRetry.Size = new System.Drawing.Size(120, 50);
                xButtonRetry.TabIndex = 2;
                xButtonRetry.Text = "TEKRAR DENE";
                xButtonRetry.UseVisualStyleBackColor = true;
                xButtonRetry.DialogResult = DialogResult.Yes;

                Button xButtonAbort = new Button();
                xButtonAbort.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonAbort.Location = new System.Drawing.Point(30, 183);
                xButtonAbort.Name = "buttonNo";
                xButtonAbort.Size = new System.Drawing.Size(120, 50);
                xButtonAbort.TabIndex = 0;
                xButtonAbort.Text = "DURDUR";
                xButtonAbort.UseVisualStyleBackColor = true;
                xButtonAbort.DialogResult = DialogResult.No;

                Button xButtonIgnore = new Button();
                xButtonIgnore.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xButtonIgnore.Location = new System.Drawing.Point(330, 183);
                xButtonIgnore.Name = "buttonNo";
                xButtonIgnore.Size = new System.Drawing.Size(120, 50);
                xButtonIgnore.TabIndex = 0;
                xButtonIgnore.Text = "YOKSAY";
                xButtonIgnore.UseVisualStyleBackColor = true;
                xButtonIgnore.DialogResult = DialogResult.No;

                Label xLabelMessage = new Label();
                xLabelMessage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                xLabelMessage.Location = new System.Drawing.Point(12, 9);
                xLabelMessage.Name = "labelMessage";
                xLabelMessage.Size = new System.Drawing.Size(456, 171);
                xLabelMessage.TabIndex = 1;
                xLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                xLabelMessage.Text = prm_strMessage;

                GroupBox xGoupBox = new GroupBox();
                xGoupBox.Controls.Add(xLabelMessage);
                xGoupBox.Controls.Add(xButtonRetry);
                xGoupBox.Controls.Add(xButtonAbort);
                xGoupBox.Controls.Add(xButtonIgnore);
                xGoupBox.Location = new System.Drawing.Point(2, 2);
                xGoupBox.Name = "xGoupBox";
                xGoupBox.Size = new System.Drawing.Size(476, 236);
                xGoupBox.TabIndex = 113;
                xGoupBox.TabStop = false;

                xForm.AcceptButton = xButtonRetry;
                xForm.CancelButton = xButtonAbort;
                xForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                xForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                if (prm_bIsWarningMessageBox == true)
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strWarningBoxForeColor);
                }
                else
                {
                    xForm.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxBackColor);
                    xForm.ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strMessageBoxForeColor);
                } 
                xForm.ClientSize = new System.Drawing.Size(480, 240);
                xForm.ControlBox = false;
                xForm.Controls.Add(xGoupBox);
                xForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                xForm.Name = "CustomMessageBox";
                xForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                xForm.Text = "CustomMessageBox";
                xForm.TopMost = true;
            }

            return xForm.ShowDialog();
        }

        static void xForm_FormClosing(object sender, FormClosingEventArgs e)
        {
          CustomNumpad.m_bCustomMessageBoxIsActive = true;
        }
    }
}
