using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;
using SaleFlex.Data;
using SaleFlex.Data.AccessLayer;

namespace SaleFlex.UserInterface.Controls
{
    public class CustomForm : Form
    {
        private System.ComponentModel.IContainer m_xComponents = null;
        private System.Windows.Forms.ToolTip m_xCustomFormToolTip;

        private string m_strFormName = string.Empty;
        public FormDataModel m_xFormDataModel = null;
        private System.ComponentModel.IContainer components;
        private Control m_xAlwaysFocusedControl = null;
        private CustomCustomerForm m_xCustomCustomerForm = null;

        public Control prop_xAlwaysFocusedControl
        {
            get
            {
                return m_xAlwaysFocusedControl;
            }
            set
            {
                m_xAlwaysFocusedControl = value;
            }
        }

        public CustomForm()
        {
            vInitialize();
        }

        public CustomForm(string prm_strFormName)
        {
            m_strFormName = prm_strFormName;
            vInitialize();
        }

        ~CustomForm()
        {
        }

        void vInitialize()
        {
            InitializeComponent();
            //vInitializeDynamicComponent(m_strFormName);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool prm_bDisposing)
        {
            if (prm_bDisposing && (m_xComponents != null))
            {
                m_xComponents.Dispose();
            }
            base.Dispose(prm_bDisposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomForm));
            this.m_xCustomFormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // CustomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CustomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Need Configuration Data...!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.vCustomFormClosing);
            this.Load += new System.EventHandler(this.vCustomFormLoading);
            this.Shown += new System.EventHandler(this.vCustomFormShown);
            this.ResumeLayout(false);

        }

        private void vInitializeDynamicComponent(string prm_strFormName)
        {
            try
            {
                m_xFormDataModel = Dao.xGetInstance().xGetFormByName(m_strFormName);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            this.SuspendLayout();
            try
            {
                if (m_xFormDataModel != null)
                {
                    try
                    {
                        switch (m_xFormDataModel.strFormBorderStyle)
                        {
                            case "NONE":
                                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                                break;
                            case "SINGLE":
                                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                                break;
                            case "TOOL":
                                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                                break;
                            case "NORMAL":
                            default:
                                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                                break;
                        }

                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                    }

                    try
                    {
                        if (m_xFormDataModel.strName != null && m_xFormDataModel.strName != string.Empty)
                            Name = string.Format("form_{0}", m_xFormDataModel.strName);
                        else
                            Name = "form_TMP";
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                        Name = "form_TMP";
                    }

                    try
                    {
                        if (m_xFormDataModel.iWidth != 0 || m_xFormDataModel.iHeight != 0)
                        {
                            if (m_xFormDataModel.iWidth != 0)
                                Width = m_xFormDataModel.iWidth;
                            if (m_xFormDataModel.iHeight != 0)
                                Height = m_xFormDataModel.iHeight;
                        }
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                    }

                    try
                    {
                        switch (m_xFormDataModel.strStartPosition)
                        {
                            case "CENTERSCREEN":
                                StartPosition = FormStartPosition.CenterScreen;
                                break;
                            case "CENTERPARENT":
                                StartPosition = FormStartPosition.CenterParent;
                                break;
                            case "TOPLEFT":
                            default:
                                StartPosition = FormStartPosition.Manual;
                                Location = new Point(0, 0);
                                break;
                        }
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                        StartPosition = FormStartPosition.Manual;
                        Location = new Point(0, 0);
                    }

                    try
                    {
                        if (m_xFormDataModel.strIcon != null && m_xFormDataModel.strIcon != string.Empty)
                        {
                            Icon = new Icon(string.Format("{0}\\{1}", CommonProperty.prop_strImagesFolder, m_xFormDataModel.strIcon));
                        }
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                    }

                    try
                    {
                        if (m_xFormDataModel.strImage != null && m_xFormDataModel.strImage != string.Empty)
                        {
                            Bitmap xBitmap = new Bitmap(string.Format("{0}\\{1}", CommonProperty.prop_strImagesFolder, m_xFormDataModel.strImage));
                            BackgroundImage = xBitmap;
                        }
                        else
                        {
                            BackgroundImage = null;
                        }
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                    }

                    try
                    {
                        if (string.IsNullOrEmpty(m_xFormDataModel.strBackColor) == false)
                        {
                            BackColor = System.Drawing.Color.FromName(m_xFormDataModel.strBackColor);
                        }
                        else
                        {
                            BackColor = System.Drawing.SystemColors.Control;
                        }
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                        BackColor = System.Drawing.SystemColors.Control;
                    }

                    try
                    {
                        if (m_xFormDataModel.strCaption != null && m_xFormDataModel.strCaption != string.Empty)
                            Text = string.Format("SaleFlex® - {0}", m_xFormDataModel.strCaption);
                        else
                            Text = string.Format("SaleFlex®");
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                        Text = string.Format("SaleFlex® - ERR");
                    }

                    try
                    {
                        if (m_xFormDataModel.bShowStatusBar == true)
                        {
                            CustomStatusBar xCustomStatusBar = new CustomStatusBar("statusbar_MainStatusBar", CommonProperty.prop_strApplicationVersion);

                            Controls.Add(xCustomStatusBar);
                        }
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                    }

                    SelectNextControl(ActiveControl, true, true, true, true);
                    this.bFocusNumPad();

                    this.bSetStatusBarZNoLabel(string.Empty);
                    this.bSetStatusBarReceiptNoLabel(string.Empty);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            this.ResumeLayout(false);
            Application.DoEvents();
        }

        public CustomCustomerForm xCustomCustomerForm
        {
            get
            {
                return m_xCustomCustomerForm;
            }
            set
            {
                m_xCustomCustomerForm = value;
            }
        }

        public System.Windows.Forms.ToolTip xCustomFormToolTip
        {
            get
            {
                return m_xCustomFormToolTip;
            }
        }

        private void vCustomFormClosing(object prm_objSender, FormClosingEventArgs prm_xFormClosingEventArgs)
        {
            if (xFormClosingEventHandler != null)
            {
                xFormClosingEventHandler(prm_objSender, prm_xFormClosingEventArgs);

            }
        }

        public EventHandler xFormClosingEventHandler { get; set; }

        private void vCustomFormLoading(object sender, EventArgs e)
        {
        }

        private void vCustomFormShown(object sender, EventArgs e)
        {
        }

        delegate bool bAddControlDelegate(Control prm_xControl, FormControlDataModel prm_xFormControlDataModel);
        public bool bAddControl(Control prm_xControl, FormControlDataModel prm_xFormControlDataModel)
        {
            bool bReturnValue = false;

            if (this.InvokeRequired == true)
            {
                return (bool)this.Invoke(new bAddControlDelegate(bAddControl), new object[] { prm_xControl, prm_xFormControlDataModel });
            }

            if (prm_xFormControlDataModel.strToolTip != string.Empty)
            {
                xCustomFormToolTip.SetToolTip(prm_xControl, prm_xFormControlDataModel.strToolTip);
            }

            Controls.Add(prm_xControl);
            prm_xControl.BringToFront();
            bReturnValue = true;

            return bReturnValue;
        }

        public bool bReDrawForm(string prm_strFormName)
        {
            vInitializeDynamicComponent(prm_strFormName);
            return true;
        }

        public string strFormName
        {
            get
            {
                return m_strFormName;
            }
        }
    }
}
