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
    public partial class CustomPaymentList : UserControl, ICustomControl
    {
        List<CustomPaymentListData> m_xListCustomPaymentListData = new List<CustomPaymentListData>();
        int m_iSelectedIndex = 0;

        public CustomPaymentList(FormControlDataModel prm_xFormControlDataModel)
        {
            InitializeComponent();
            vInitializeCustomComponents(prm_xFormControlDataModel);
        }

        public void vInitializeCustomComponents(FormControlDataModel prm_xFormControlDataModel)
        {
            ((Control)this).bSetControlCommonProperties(prm_xFormControlDataModel);

            dataGridViewPayments.BackgroundColor = BackColor;
            dataGridViewPayments.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewPayments.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridViewPayments.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewPayments.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewPayments.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewPayments.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridViewPayments.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewPayments.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            dataGridViewPayments.Click +=  new EventHandler(vOnEvent1);
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

        public bool bAddPayment(TransactionDataModel prm_xTransactionDataModel)
        {
            if (prm_xTransactionDataModel.xListPaymentDataModel.Last() == null)
                return false;

            CustomPaymentListData xCustomPaymentListData = new CustomPaymentListData();

            xCustomPaymentListData.ROW_NUMBER = dataGridViewPayments.Rows.Count + 1;
            xCustomPaymentListData.TYPE = prm_xTransactionDataModel.xListPaymentDataModel.Last().xPaymentTypeDataModel.strTypeName;
            xCustomPaymentListData.AMOUNT = prm_xTransactionDataModel.xListPaymentDataModel.Last().decAmount/100;
            xCustomPaymentListData.ID = prm_xTransactionDataModel.xListPaymentDataModel.Last().lId;

            m_xListCustomPaymentListData.Add(xCustomPaymentListData);

            int iRowIndex = dataGridViewPayments.Rows.Add(xCustomPaymentListData.TYPE, xCustomPaymentListData.AMOUNT);
            dataGridViewPayments.Rows[iRowIndex].Selected = true;
            dataGridViewPayments.FirstDisplayedScrollingRowIndex = iRowIndex;

            m_iSelectedIndex = iRowIndex;

            if (xGetCustomCustomerForm() != null)
                xGetCustomCustomerForm().bAddPayment(prm_xTransactionDataModel);

            return true;
        }

        public bool bClear()
        {
            while (m_xListCustomPaymentListData.Count > 0)
                m_xListCustomPaymentListData.RemoveAt(0);

            while (dataGridViewPayments.Rows.Count > 0)
                dataGridViewPayments.Rows.RemoveAt(0);

            return true;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (dataGridViewPayments.Rows.Count > 0 && m_iSelectedIndex > 0)
            {
                m_iSelectedIndex--;
                dataGridViewPayments.Rows[m_iSelectedIndex].Selected = true;
                dataGridViewPayments.FirstDisplayedScrollingRowIndex = m_iSelectedIndex;
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (dataGridViewPayments.Rows.Count > 0 && m_iSelectedIndex < dataGridViewPayments.Rows.Count - 1)
            {
                m_iSelectedIndex++;
                dataGridViewPayments.Rows[m_iSelectedIndex].Selected = true;
                dataGridViewPayments.FirstDisplayedScrollingRowIndex = m_iSelectedIndex;
            }
        }

        private void CustomPaymentList_Enter(object sender, EventArgs e)
        {
            try
            {
                Control xControl = (Control)sender;

                ((CustomForm)xControl.Parent).bFocusNumPad();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }
    }

    class CustomPaymentListData
    {
        public int ROW_NUMBER { get; set; }
        public string TYPE { get; set; }
        public decimal AMOUNT { get; set; }
        public long ID { get; set; }
    }
}
