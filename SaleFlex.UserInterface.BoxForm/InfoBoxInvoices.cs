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
using SaleFlex.Data.AccessLayer;
using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.BoxForm
{
    public partial class InfoBoxInvoices : Form
    {
        private bool m_bCancelFormClosing = false;
        int m_iSelectedIndex = 0;
        private TransactionDataModel m_xTransactionDataModel = null;
        decimal iPageCount;
        int iPageNumber=0;
        int iInvoiceListCount;
        int iStartingRow;
        int iRowCount;
        List<TransactionHeadDataModel> xListTransactionHeadDataModel = Dao.xGetInstance().xGetListClosedTransactionHeaders((int)enumDocumentType.Invoice);

        public TransactionDataModel xNewTransactionDataModel
        {
            get { return m_xTransactionDataModel; }
            set { m_xTransactionDataModel = value; }
        }


        public InfoBoxInvoices()
        {
            InitializeComponent();

            iInvoiceListCount = xListTransactionHeadDataModel.Count;

            try
            {
                iPageCount = (decimal)iInvoiceListCount / 8;
                iPageCount = Math.Ceiling(iPageCount);

                for (int iIndex = 1; iIndex <=iPageCount; iIndex++)
                {
                    comboBoxPageCounter.Items.Add(iIndex);
                }
                if (xListTransactionHeadDataModel != null)
                    if (iInvoiceListCount < 8)
                    {
                        iStartingRow = 0;
                        iRowCount = iInvoiceListCount;
                    }
                    else
                    {
                        iStartingRow = iInvoiceListCount - 8;
                        iRowCount = 8;
                    }

                foreach (TransactionHeadDataModel xTransactionHeadDataModel in xListTransactionHeadDataModel.Skip(iStartingRow).Take(iRowCount).ToList())
                    {
                        bAddInvoice(xTransactionHeadDataModel);
                    }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        private bool bAddInvoice(TransactionHeadDataModel prm_xTransactionHeadDataModel)
        {
            if (prm_xTransactionHeadDataModel == null)
                return false;

            string strCustomerName = string.Empty;

            //if (prm_xTransactionHeadDataModel.lFkCustomerId > 0)
            //{
            //    CustomerDataModel xCustomerDataModel = DAO.xGetInstance().xListGetCustomer(string.Empty, string.Empty, string.Empty, prm_xTransactionHeadDataModel.lFkCustomerId).FirstOrDefault();
            //    strCustomerName = string.Format("{0} {1}", xCustomerDataModel.strName, xCustomerDataModel.strLasName); ;
            //}

            int iRowIndex = dataGridViewTransactionHeads.Rows.Add(prm_xTransactionHeadDataModel.iId.ToString(), prm_xTransactionHeadDataModel.xTransactionDateTime, prm_xTransactionHeadDataModel.decReceiptTotalPrice, strCustomerName);
            dataGridViewTransactionHeads.Rows[iRowIndex].Selected = true;
            dataGridViewTransactionHeads.FirstDisplayedScrollingRowIndex = iRowIndex;

            m_iSelectedIndex = iRowIndex;

            return true;
        }

        private void InfoBoxInvoices_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            ForeColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxForeColor);
            dataGridViewTransactionHeads.BackgroundColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
            dataGridViewTransactionHeads.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromName(CommonProperty.prop_strInputBoxBackColor);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
            {
                m_bCancelFormClosing = true;
            }
            else
            {
                
            }

        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {




        }

        private void InfoBoxInvoices_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bCancelFormClosing == true)
                e.Cancel = true;
            m_bCancelFormClosing = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           
  
        }

        private void comboBoxPageCounter_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<TransactionHeadDataModel> xNewListTransactionHeadDataModel = new List<TransactionHeadDataModel>();

            int iRowDataCount = 8;

            iPageNumber = int.Parse(comboBoxPageCounter.SelectedItem.ToString()) - 1;

            if (iInvoiceListCount < iRowDataCount && iInvoiceListCount >0)

                xNewListTransactionHeadDataModel = xListTransactionHeadDataModel.Skip(iPageNumber * iRowDataCount).Take(iInvoiceListCount).ToList();
            else
                xNewListTransactionHeadDataModel = xListTransactionHeadDataModel.Skip(iPageNumber * iRowDataCount).Take(iRowDataCount).ToList();

            iInvoiceListCount = xListTransactionHeadDataModel.Count - iRowDataCount * (int.Parse(comboBoxPageCounter.SelectedItem.ToString()));

            if (xNewListTransactionHeadDataModel != null)

                dataGridViewTransactionHeads.Rows.Clear();

                foreach (TransactionHeadDataModel xTransactionHeadDataModel in xNewListTransactionHeadDataModel)
                {
                    bAddInvoice(xTransactionHeadDataModel);
                }

        }

    }
}
