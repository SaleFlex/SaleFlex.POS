using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.Controls
{
    class CustomStatusBar : StatusStrip
    {
        private ToolStripStatusLabel m_xToolStripVersionLabel;
        private ToolStripStatusLabel m_xToolStripDateTimeLabel;
        private ToolStripStatusLabel m_xToolStripStatusLabel;
        private ToolStripStatusLabel m_xToolStripLicenseLabel;
        private ToolStripProgressBar m_xToolStripProgressBar;
        private ToolStripStatusLabel m_xToolStripDocumentTypeLabel;
        private ToolStripStatusLabel m_xToolStripZNoLabel;
        private ToolStripStatusLabel m_xToolStripReceiptNoLabel;
        private ToolStripStatusLabel m_xToolStripPriceLabel;
        private ToolStripStatusLabel m_xToolStripQuantityLabel;
        private ToolStripStatusLabel m_xToolStripCashierLabel;

        private string m_strLicense = string.Empty;
        private string m_strVersion = string.Empty;

        private Timer m_xDateTimeTimer;
        private Timer m_xTimer;

        public CustomStatusBar()
        {
            vInitializeComponent();
        }

        public CustomStatusBar(string prm_strName, string prm_strVersion)
        {
            Name = prm_strName;
            m_strVersion = prm_strVersion;
            vInitializeComponent();
        }

        private void vInitializeComponent()
        {
            m_xToolStripDocumentTypeLabel = new ToolStripStatusLabel();
            m_xToolStripDocumentTypeLabel.Name = "m_xToolStripStatusLabel";
            m_xToolStripDocumentTypeLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;
            m_xToolStripDocumentTypeLabel.BackColor = Color.Red;
            m_xToolStripDocumentTypeLabel.ForeColor = Color.Wheat;
            m_xToolStripDocumentTypeLabel.Font = new Font("Arial", this.Font.Size, FontStyle.Bold, this.Font.Unit, (byte)162);

            m_xToolStripZNoLabel = new ToolStripStatusLabel();
            m_xToolStripZNoLabel.Name = "m_xToolStripStatusLabel";
            m_xToolStripZNoLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;

            m_xToolStripReceiptNoLabel = new ToolStripStatusLabel();
            m_xToolStripReceiptNoLabel.Name = "m_xToolStripStatusLabel";
            m_xToolStripReceiptNoLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;

            m_xToolStripDateTimeLabel = new ToolStripStatusLabel();
            m_xToolStripDateTimeLabel.Name = "m_xToolStripDateTimeLabel";
            m_xToolStripDateTimeLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;
            m_xToolStripDateTimeLabel.Size = new System.Drawing.Size(200, 16);
            m_xToolStripDateTimeLabel.AutoSize = false;

            m_xToolStripStatusLabel = new ToolStripStatusLabel();
            m_xToolStripStatusLabel.Name = "m_xToolStripStatusLabel";
            m_xToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;

            m_xToolStripLicenseLabel = new ToolStripStatusLabel();
            m_xToolStripLicenseLabel.Name = "m_xToolStripLicenseLabel";
            m_xToolStripLicenseLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;
            m_xToolStripLicenseLabel.Size = new System.Drawing.Size(200, 16);
            m_xToolStripLicenseLabel.AutoSize = false;

            m_xToolStripProgressBar = new ToolStripProgressBar();
            m_xToolStripProgressBar.Name = "m_xToolStripProgressBar";
            m_xToolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            m_xToolStripProgressBar.Step = 1;
            m_xToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            m_xToolStripProgressBar.Visible = false;
            m_xToolStripProgressBar.AutoSize = false;
            m_xToolStripProgressBar.Minimum = 0;
            m_xToolStripProgressBar.Maximum = 200;

            m_xToolStripPriceLabel = new ToolStripStatusLabel();
            m_xToolStripPriceLabel.Name = "m_xToolStripStatusLabel";
            m_xToolStripPriceLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;

            m_xToolStripQuantityLabel = new ToolStripStatusLabel();
            m_xToolStripQuantityLabel.Name = "m_xToolStripStatusLabel";
            m_xToolStripQuantityLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;

            m_xToolStripCashierLabel = new ToolStripStatusLabel();
            m_xToolStripCashierLabel.Name = "m_xToolStripStatusLabel";
            m_xToolStripCashierLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;

            //this.Font = new Font("Consolas", 20, FontStyle.Regular, GraphicsUnit.Pixel, (byte)162);
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ForeColor = System.Drawing.Color.Black;

            m_xTimer = new Timer();
            m_xTimer.Tick += new EventHandler(xTimer_Tick);

            m_xDateTimeTimer = new Timer();
            m_xDateTimeTimer.Interval = 1000;
            m_xDateTimeTimer.Tick += new EventHandler(xDateTimeTimer_Tick);
            m_xDateTimeTimer.Enabled = true;

            if (m_strVersion != string.Empty)
            {
                m_xToolStripVersionLabel = new ToolStripStatusLabel();
                m_xToolStripVersionLabel.Name = "m_xToolStripVersionLabel";
                m_xToolStripVersionLabel.BorderSides = ToolStripStatusLabelBorderSides.Right;
                m_xToolStripVersionLabel.Text = string.Format("SaleFlex.POS v{0}", m_strVersion);

                Items.AddRange(new System.Windows.Forms.ToolStripItem[] { m_xToolStripVersionLabel, m_xToolStripDateTimeLabel, m_xToolStripLicenseLabel, m_xToolStripProgressBar, m_xToolStripStatusLabel, m_xToolStripDocumentTypeLabel, m_xToolStripZNoLabel, m_xToolStripReceiptNoLabel, m_xToolStripCashierLabel, m_xToolStripPriceLabel, m_xToolStripQuantityLabel });
            }
            else
            {
                Items.AddRange(new System.Windows.Forms.ToolStripItem[] { m_xToolStripDateTimeLabel, m_xToolStripLicenseLabel, m_xToolStripProgressBar, m_xToolStripStatusLabel, m_xToolStripDocumentTypeLabel, m_xToolStripZNoLabel, m_xToolStripReceiptNoLabel, m_xToolStripCashierLabel, m_xToolStripPriceLabel, m_xToolStripQuantityLabel });
            }

            m_xToolStripLicenseLabel.Text = string.Format("{0}: {1}", LabelTranslations.strGet("LicenseOwner"), CommonProperty.prop_strLicenseOwner); ;
        }

        delegate void xDateTimeTimer_TickDelegate(object sender, EventArgs e);
        void xDateTimeTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    this.Invoke(new xDateTimeTimer_TickDelegate(xDateTimeTimer_Tick), new object[] { sender, e });
                }

                m_xToolStripDateTimeLabel.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        delegate void xTimer_TickDelegate(object sender, EventArgs e);
        void xTimer_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new xTimer_TickDelegate(xTimer_Tick), new object[] { sender, e });
            }

            if (m_xToolStripProgressBar.Value < m_xToolStripProgressBar.Maximum)
                m_xToolStripProgressBar.Value += 2;
            else
                m_xToolStripProgressBar.Value = m_xToolStripProgressBar.Minimum;
        }

        delegate bool bStartInProgressDelegate();
        public bool bStartInProgress()
        {
            bool bReturnValue = false;

            if (this.InvokeRequired == true)
            {
                this.Invoke(new bStartInProgressDelegate(bStartInProgress));
            }

            m_xToolStripProgressBar.Value = 0;
            m_xToolStripProgressBar.Visible = true;
            m_xTimer.Start();

            return bReturnValue;
        }

        delegate bool bStopInProgressDelegate();
        public bool bStopInProgress()
        {
            bool bReturnValue = false;

            if (this.InvokeRequired == true)
            {
                this.Invoke(new bStopInProgressDelegate(bStopInProgress));
            }

            m_xToolStripProgressBar.Visible = false;
            m_xTimer.Stop();

            return bReturnValue;
        }

        public string strStatus
        {
            get
            {
                return m_xToolStripStatusLabel.Text;
            }
            set
            {
                m_xToolStripStatusLabel.Text = value;
            }
        }

        string m_strDocumentType = string.Empty;
        public string strDocumentType
        {
            get
            {
                return m_strDocumentType;
            }
            set
            {
                m_strDocumentType = value;
                if (string.IsNullOrEmpty(m_strDocumentType) == true)
                {
                    m_xToolStripDocumentTypeLabel.Text = "";
                }
                else
                {
                    m_xToolStripDocumentTypeLabel.Text = string.Format("[  {0}  ]", m_strDocumentType);
                }
            }
        }

        decimal m_decPrice = 0m;
        public decimal decPrice
        {
            get
            {
                return m_decPrice;
            }
            set
            {
                m_decPrice = value;
                m_xToolStripPriceLabel.Text = string.Format("{0} : {1:#,0.00} {2}", LabelTranslations.strGet("Price"), m_decPrice, LabelTranslations.strGet("CurrencySymbol"));

            }
        }

        decimal m_decQuantity = 0m;
        public decimal decQuantity
        {
            get
            {
                return m_decQuantity;
            }
            set
            {
                m_decQuantity = value;
                m_xToolStripQuantityLabel.Text = string.Format("{0} : {1}", LabelTranslations.strGet("Quantity"), m_decQuantity);

            }
        }

        string m_strCashier = string.Empty;
        public string strCashier
        {
            get
            {
                return m_strCashier;
            }
            set
            {
                m_strCashier = value;
                if (string.IsNullOrEmpty(m_strCashier) == true)
                {
                    m_xToolStripCashierLabel.Text = "";
                }
                else
                {
                    m_xToolStripCashierLabel.Text = string.Format("{0}", m_strCashier);
                }
            }
        }


        public string strZNo
        {
            get
            {
                return m_xToolStripZNoLabel.Text;
            }
            set
            {
                m_xToolStripZNoLabel.Text = value;
            }
        }

        public string strReceiptNo
        {
            get
            {
                return m_xToolStripReceiptNoLabel.Text;
            }
            set
            {
                m_xToolStripReceiptNoLabel.Text = value;
            }
        }
    }
}
