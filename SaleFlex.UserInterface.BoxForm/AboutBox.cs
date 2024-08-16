using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using SaleFlex.Data;
using SaleFlex.Data.AccessLayer;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            labelProductName.Text = String.Format("SaleFlex.POS v{0}", CommonProperty.prop_strApplicationVersion);
            labelProductDescription.Text = string.Format("{0}", CommonProperty.prop_strApplicationDescription);
        }

        public string strDownloading
        {
            get
            {
                return labelDownloading.Text;
            }
        }

        delegate void vChangeLabelDownloadingDelegate(string prm_strLableValue);
        public void vChangeLabelDownloading(string prm_strLableValue)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new vChangeLabelDownloadingDelegate(vChangeLabelDownloading), new object[] { prm_strLableValue });
            }
            else
            {
                
                labelDownloading.Text = prm_strLableValue;
                Application.DoEvents();
            }
        }

    }
}
