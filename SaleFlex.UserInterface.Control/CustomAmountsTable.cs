using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;

namespace SaleFlex.UserInterface.Controls
{
    public partial class CustomAmountsTable : UserControl, ICustomControl
    {
        private string m_strFunction1Name = string.Empty;

        public CustomAmountsTable(FormControlDataModel prm_xFormControlDataModel)
        {
            InitializeComponent();
            vInitializeCustomComponents(prm_xFormControlDataModel);
        }

        public void vInitializeCustomComponents(FormControlDataModel prm_xFormControlDataModel)
        {
            ((Control)this).bSetControlCommonProperties(prm_xFormControlDataModel);

            if (prm_xFormControlDataModel.strBackColor != string.Empty)
                BackColor = System.Drawing.Color.DarkBlue;

            m_strFunction1Name = prm_xFormControlDataModel.xFormControlFunction1.strName;
            //Click += CyberPOSEventHandler.xGetInstance().xEventDistributor(m_strFunction1Name);

            int iWidth = Size.Width > 250 ? Size.Width : 250;
            int iHeight = Size.Height > 200 ? Size.Height : 200;

            if (iWidth > 250 || iHeight > 200)
            {
                int iWidthChange = (iWidth - 250);
                int iLocationYChange = (iHeight - 200) / 6;

                labelSalesAmount.Location = new System.Drawing.Point(7, 14);
                labelSalesAmount.Size = new System.Drawing.Size(83, 18);
                labelDiscountAmount.Location = new System.Drawing.Point(7, 45 + iLocationYChange);
                labelDiscountAmount.Size = new System.Drawing.Size(83, 18);
                //labelSurchargeAmount.Location = new System.Drawing.Point(7, 76 + iLocationYChange * 2);
                //labelSurchargeAmount.Size = new System.Drawing.Size(83, 18);
                labelNetAmount.Location = new System.Drawing.Point(7, 106 + iLocationYChange * 3);
                labelNetAmount.Size = new System.Drawing.Size(83, 20);
                labelPaymentAmount.Location = new System.Drawing.Point(7, 138 + iLocationYChange * 4);
                labelPaymentAmount.Size = new System.Drawing.Size(83, 18);
                labelBalanceAmount.Location = new System.Drawing.Point(7, 165 + iLocationYChange * 5);
                labelBalanceAmount.Size = new System.Drawing.Size(83, 24);

                labelTextSalesAmount.Location = new System.Drawing.Point(91, 9);
                labelTextSalesAmount.Size = new System.Drawing.Size(156 + iWidthChange, 23);
                labelTextDiscountAmount.Location = new System.Drawing.Point(91, 40 + iLocationYChange);
                labelTextDiscountAmount.Size = new System.Drawing.Size(156 + iWidthChange, 23);
                labelTextTotalAmount.Location = new System.Drawing.Point(91, 67 + iLocationYChange * 2);
                labelTextTotalAmount.Size = new System.Drawing.Size(156 + iWidthChange, 67);
                labelTextPaymentAmount.Location = new System.Drawing.Point(95, 133 + iLocationYChange * 3);
                labelTextPaymentAmount.Size = new System.Drawing.Size(156 + iWidthChange, 23);
                labelTextBalanceAmount.Location = new System.Drawing.Point(95, 162 + iLocationYChange * 4);
                labelTextBalanceAmount.Size = new System.Drawing.Size(156 + iWidthChange, 23);
            }
        }

        public string strName { get; set; }
        public string strType { get; set; }
        public string strFunction1 { get; set; }
        public string strFunction2 { get; set; }
        public EventHandler xEventHandler1 { get; set; }
        public EventHandler xEventHandler2 { get; set; }

        public void vOnEvent1(object prm_objObject, EventArgs prm_xEventArgs)
        {
            if (xEventHandler1 != null)
                xEventHandler1(prm_objObject, prm_xEventArgs);
        }

        public void vOnEvent2(object prm_objObject, EventArgs prm_xEventArgs)
        {
            if (xEventHandler2 != null)
                xEventHandler2(prm_objObject, prm_xEventArgs);
        }

        CustomCustomerForm xGetCustomCustomerForm()
        {
            try
            {
                CustomForm xCustomForm = (CustomForm)this.Parent;

                return xCustomForm.xCustomCustomerForm;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return null;
        }

        public decimal decReceiptTotalPrice
        {
            get
            {
                try
                {
                    return Convert.ToDecimal(labelTextSalesAmount.Text);
                }
                catch (Exception xException)
                {
                    xException.strTraceError();
                    return 0;
                }
            }
            set
            {
                labelTextTotalAmount.Text = labelTextSalesAmount.Text = string.Format("{0:#,0.00}", value);
                try
                {
                    labelTextBalanceAmount.Text = string.Format("{0:#,0.00}", value - Convert.ToDecimal(labelTextPaymentAmount.Text));
                }
                catch (Exception xException)
                {
                    xException.strTraceError();
                    labelTextTotalAmount.Text = "0,00";
                }

                if (xGetCustomCustomerForm() != null)
                    xGetCustomCustomerForm().decReceiptTotalPrice = value;
            }
        }

        public decimal decReceiptTotalPayment
        {
            get
            {
                try
                {
                    return Convert.ToDecimal(labelTextPaymentAmount.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                labelTextPaymentAmount.Text = string.Format("{0:#,0.00}", value);
                try
                {
                    labelTextBalanceAmount.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(labelTextTotalAmount.Text) - value);
                }
                catch (Exception xException)
                {
                    xException.strTraceError();
                    labelTextBalanceAmount.Text = "0,00";
                }

                if (xGetCustomCustomerForm() != null)
                    xGetCustomCustomerForm().decReceiptTotalPayment = value;
            }
        }

        public decimal decDiscountTotalAmount
        {
            get
            {
                try
                {
                    return Convert.ToDecimal(labelTextDiscountAmount.Text);
                }
                catch (Exception xException)
                {
                    xException.strTraceError();
                    return 0;
                }
            }
            set
            {
                labelTextDiscountAmount.Text = string.Format("{0:#,0.00}", value);

                if (xGetCustomCustomerForm() != null)
                    xGetCustomCustomerForm().decDiscountTotalAmount = value;
            }
        }

        public decimal decSurchargeTotalAmount
        {
            get
            {
                //try
                //{
                //    return Convert.ToDecimal(textBoxSurchargeAmount.Text);
                //}
                //catch (Exception xException)
                //{
                //    xException.strTraceError();
                return 0;
                //}
            }
            set
            {
                //textBoxSurchargeAmount.Text = string.Format("{0:#,0.00}", value);

                if (xGetCustomCustomerForm() != null)
                    xGetCustomCustomerForm().decSurchargeTotalAmount = value;
            }
        }

        public bool bClear()
        {
            decReceiptTotalPrice = 0m;
            decReceiptTotalPayment = 0m;
            decDiscountTotalAmount = 0m;
            decSurchargeTotalAmount = 0m;

            if (xGetCustomCustomerForm() != null)
                xGetCustomCustomerForm().bClear();

            return true;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            //WindowsAPI.HideCaret((IntPtr)sender);
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            //WindowsAPI.ShowCaret((IntPtr)sender);
        }

        public void vUpdateAndRefreshFormControls()
        {
            foreach (Control xControl in this.Controls)
            {
                xControl.Update();
                xControl.Refresh();
            }
        }



    }
}
