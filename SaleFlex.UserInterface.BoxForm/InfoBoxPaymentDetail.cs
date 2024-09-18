using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class InfoBoxPaymentDetail : Form
    {
        int m_iSelectedIndex = 0;

        public InfoBoxPaymentDetail(long prm_lReceiptTotalPrice, long prm_lReceiptTotalPayment, List<PaymentDataModel> prm_xListPaymentDataModel)
        {
            InitializeComponent();

            try
            {
                labelTotalAmount.Text = string.Format(" {0}: {1:#,0.00} {2}", LabelTranslations.strGet("NetSale"), Convert.ToDecimal(prm_lReceiptTotalPrice) /100, LabelTranslations.strGet("CurrencySymbol"));
                if (prm_lReceiptTotalPrice < prm_lReceiptTotalPayment)
                    labelBalanceAmount.Text = string.Format("{0}: {1:#,0.00} {2}", LabelTranslations.strGet("Change"), (Convert.ToDecimal(prm_lReceiptTotalPayment - prm_lReceiptTotalPrice) /100), LabelTranslations.strGet("CurrencySymbol"));
                else
                    labelBalanceAmount.Text = string.Empty;

                if (prm_xListPaymentDataModel != null)
                    foreach (PaymentDataModel xPaymentDataModel in prm_xListPaymentDataModel)
                    {
                        bAddPayment(xPaymentDataModel);
                    }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
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

        private bool bAddPayment(PaymentDataModel prm_xPaymentDataModel)
        {
            if (prm_xPaymentDataModel == null)
                return false;

            int iRowIndex = dataGridViewPayments.Rows.Add(prm_xPaymentDataModel.xPaymentTypeDataModel.strTypeName, decimal.Parse(prm_xPaymentDataModel.lAmount.ToString())/100);
            dataGridViewPayments.Rows[iRowIndex].Selected = true;
            dataGridViewPayments.FirstDisplayedScrollingRowIndex = iRowIndex;

            m_iSelectedIndex = iRowIndex;

            return true;
        }

        private void InfoBoxPaymentDetail_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewPayments.BackgroundColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
                dataGridViewPayments.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //xEventHandlerGetPrice.Invoke(this, e);
            TransactionHeadDataModel xTransactionHeadDataModel = new TransactionHeadDataModel();
            
           
            //xTransactionHeadDataModel.iFkCashierId = 0;
            //xTransactionHeadDataModel.xTransactionDateTime = DateTime.Now;
            //xTransactionHeadDataModel.iFkTransactionDocumentTypeId = 0;
            //xTransactionHeadDataModel.iFkCustomerId = 0;
            //xTransactionHeadDataModel.xCustomerDataModel = null;
            //xTransactionHeadDataModel.strTransactionNo = "1";
            //xTransactionHeadDataModel.iReceiptNumber = 0;
            //xTransactionHeadDataModel.iZNumber = 0;
            //xTransactionHeadDataModel.lReceiptTotalPrice = 0;
            //xTransactionHeadDataModel.lReceiptTotalVat = 0;
            //xTransactionHeadDataModel.lTotalDiscountAmount = 0;
            //xTransactionHeadDataModel.lTransactionsDiscountAmount = 0;
            //xTransactionHeadDataModel.lCustomerTotalDiscountAmount = 0;
            //xTransactionHeadDataModel.lPromotionTotalDiscountAmount = 0;
            //xTransactionHeadDataModel.lSurchargeAmount = 0;
            //xTransactionHeadDataModel.lPaymentAmount = 0;
            //xTransactionHeadDataModel.lChangeAmount = 0;
            //xTransactionHeadDataModel.lRoundAmount = 0;
            //xTransactionHeadDataModel.bIsVoided = true;
            SaleFlex.Data.AccessLayer.Dao.xGetInstance().bUpdateTransactionHead(xTransactionHeadDataModel);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
