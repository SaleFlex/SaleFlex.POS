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

namespace SaleFlex.UserInterface.Controls
{
    public partial class CustomCustomerForm : Form
    {
        List<CustomPaymentListData> m_xListCustomPaymentListData = new List<CustomPaymentListData>();
        List<CustomSalesData> m_xListCustomSalesData = new List<CustomSalesData>();
        int m_iSelectedIndex = 0;

        public CustomCustomerForm()
        {
            InitializeComponent();

            if (Screen.AllScreens.Count() > 1)
            {
                foreach (Screen xScreen in Screen.AllScreens)
                {
                    if (xScreen.Primary == false)
                    {
                        this.Location = xScreen.WorkingArea.Location;
                        this.StartPosition = FormStartPosition.Manual;
                        break;
                    }
                }
            }
        }
        public bool bAddSale(TransactionDataModel prm_xTransactionDataModel)
        {
            Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale in bAddSale Called");
            if (prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xDepartmentDataModel == null && prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel == null)
                return false;

            CustomSalesData xCustomSalesData = new CustomSalesData();

            if (m_xListCustomSalesData.Count == 0)
                xCustomSalesData.ROW_NUMBER = 1;

            else
                xCustomSalesData.ROW_NUMBER = (int)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["ROW_NUMBER"].Value + 1;

            xCustomSalesData.REFERENCE_ID = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().iId;
            xCustomSalesData.TRANSACTION = prm_xTransactionDataModel.xTransactionHeadDataModel.iTransactionDocumentTypeNo != (int)EnumDocumentType.Return ? "Satış" : "İade";
            xCustomSalesData.UNIT = 1;
            if (prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xDepartmentDataModel != null)
            {
                xCustomSalesData.TRANSACTION_TYPE = "DEPARTMENT";
                xCustomSalesData.ID = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xDepartmentDataModel.iId;
                xCustomSalesData.DEPARTMENT_NO = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xDepartmentDataModel.iNo;
                xCustomSalesData.NAME_OF_PRODUCT = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xDepartmentDataModel.strName;
            }
            else if (prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel != null)
            {
                xCustomSalesData.TRANSACTION_TYPE = "PLU";
                xCustomSalesData.ID = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.iId;
                xCustomSalesData.PLU_NO = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.strCode;
                xCustomSalesData.BARCODE = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.xListPluBarcodeDataModel[0].strBarcode;
                if (prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.xListPluBarcodeDataModel[0].strBarcode != null && prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.xListPluBarcodeDataModel[0].strBarcode.Length > 0)
                    xCustomSalesData.NAME_OF_PRODUCT = string.Format("{0} [{1}]", prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.strDescriptionOnScreen, prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.xListPluBarcodeDataModel[0].strBarcode);
                else
                    xCustomSalesData.NAME_OF_PRODUCT = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.strName;
            }
            xCustomSalesData.QUANTITY = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.StockUnitNo == 1 ? Convert.ToDecimal(prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().decQuantity)/1000 : prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().decQuantity;
            xCustomSalesData.PRICE = Convert.ToDecimal(prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().decPrice)/100;
            xCustomSalesData.TOTAL_AMOUNT = Convert.ToDecimal(prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().decTotalPrice)/ 100;
            xCustomSalesData.DISCOUNT_SURCHARGE_DATAMODEL_LIST = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xDiscountSurchargeDataModel;
            xCustomSalesData.UNIT_QUANTITY = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.StockUnitNo != 1 ? xCustomSalesData.QUANTITY.ToString() : string.Format("{0:#,0.000}", xCustomSalesData.QUANTITY);

            m_xListCustomSalesData.Add(xCustomSalesData);

            int iRowIndex = dataGridViewSales.Rows.Add(xCustomSalesData.ROW_NUMBER, xCustomSalesData.REFERENCE_ID, xCustomSalesData.TRANSACTION_TYPE, xCustomSalesData.TRANSACTION, xCustomSalesData.NAME_OF_PRODUCT, xCustomSalesData.UNIT_QUANTITY, xCustomSalesData.UNIT, xCustomSalesData.PRICE, xCustomSalesData.TOTAL_AMOUNT);

            if (dataGridViewSales.Rows.Count > 1)
                dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value = (int)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 2].Cells["ROW_NUMBER"].Value + 1;
            else
                dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value = dataGridViewSales.Rows.Count;

            dataGridViewSales.Rows[iRowIndex].Selected = true;
            dataGridViewSales.FirstDisplayedScrollingRowIndex = iRowIndex;
            dataGridViewSales.Update();
            dataGridViewSales.Refresh();

            m_iSelectedIndex = iRowIndex;

            labelMessage.Text = string.Empty;

            return true;
        }

        public bool bAddSubTotal(decimal prm_decReceiptTotalPrice, TransactionDataModel prm_xTransactionDataModel)
        {
            if ((string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["TRANSACTION"].Value != "Ara Toplam")
            {
                int iRowIndex = dataGridViewSales.Rows.Add(dataGridViewSales.Rows.Count + 1, 0, "SUB_TOTAL", "Ara Toplam", "ARATOPLAM", "", "", "", string.Format("{0:#,0.00}", prm_decReceiptTotalPrice));
                dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value = (int)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 2].Cells["ROW_NUMBER"].Value + 1;
                dataGridViewSales.Rows[iRowIndex].Selected = true;
                dataGridViewSales.FirstDisplayedScrollingRowIndex = iRowIndex;

                CustomSalesData xCustomSalesData = new CustomSalesData();

                xCustomSalesData.ROW_NUMBER = (int)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 2].Cells["ROW_NUMBER"].Value + 1;
                xCustomSalesData.TRANSACTION_TYPE = "SUBTOTAL";
                xCustomSalesData.TOTAL_AMOUNT = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xSubTotalDataModel.decSubTotalAmount;
                xCustomSalesData.DISCOUNT_SURCHARGE_DATAMODEL_LIST = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xDiscountSurchargeDataModel;
                xCustomSalesData.PRICE = prm_decReceiptTotalPrice;

                m_xListCustomSalesData.Add(xCustomSalesData);
            }

            labelMessage.Text = string.Empty;

            return true;
        }


        public bool bAddDiscountByAmountLine(DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel)
        {
            if ((string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["TRANSACTION"].Value != "Ara Toplam" && (string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["NAME_OF_PRODUCT"].Value != "ARATOPLAM")
            {
                int iRowIndex = dataGridViewSales.Rows.Add(dataGridViewSales.Rows.Count + 1, 0, "SUB_TOTAL", "IND. TU.", m_xListCustomSalesData[m_xListCustomSalesData.Count - 1].NAME_OF_PRODUCT, "", "", "", string.Format("-{0:#,0.00}", prm_xDiscountSurchargeDataModel.decDiscountAmount));
                dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value = m_xListCustomSalesData[m_xListCustomSalesData.Count - 1].ROW_NUMBER;
                dataGridViewSales.Rows[iRowIndex].Selected = true;
                dataGridViewSales.FirstDisplayedScrollingRowIndex = iRowIndex;
            }

            else if ((string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["TRANSACTION"].Value == "Ara Toplam" || (string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["NAME_OF_PRODUCT"].Value == "ARATOPLAM")
            {
                int iRowIndex = dataGridViewSales.Rows.Add(dataGridViewSales.Rows.Count + 1, 0, "SUB_TOTAL", "IND. TU.", "ARATOPLAM", "", "", "", string.Format("-{0:#,0.00}", prm_xDiscountSurchargeDataModel.decDiscountAmount));
                dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value = (int)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 2].Cells["ROW_NUMBER"].Value;
                dataGridViewSales.Rows[iRowIndex].Selected = true;
                dataGridViewSales.FirstDisplayedScrollingRowIndex = iRowIndex;
            }
            else
            {
                return false;
            }

            labelMessage.Text = string.Empty;

            return true;
        }

        public bool bAddDiscountByPercentLine(DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel)
        {
            if ((string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["TRANSACTION"].Value != "Ara Toplam" && (string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["NAME_OF_PRODUCT"].Value != "ARATOPLAM")
            {
                int iRowIndex = dataGridViewSales.Rows.Add(dataGridViewSales.Rows.Count + 1, 0, "SUB_TOTAL", "IND. Y.", m_xListCustomSalesData[m_xListCustomSalesData.Count - 1].NAME_OF_PRODUCT, string.Format("%{0}", prm_xDiscountSurchargeDataModel.iDiscountPercentage), "", "", string.Format("-{0:#,0.00}", prm_xDiscountSurchargeDataModel.decDiscountSurchargeResult));
                dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value = m_xListCustomSalesData[m_xListCustomSalesData.Count - 1].ROW_NUMBER;
                dataGridViewSales.Rows[iRowIndex].Selected = true;
                dataGridViewSales.FirstDisplayedScrollingRowIndex = iRowIndex;
            }

            else if ((string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["TRANSACTION"].Value == "Ara Toplam" || (string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["NAME_OF_PRODUCT"].Value == "ARATOPLAM")
            {
                int iRowIndex = dataGridViewSales.Rows.Add(dataGridViewSales.Rows.Count + 1, 0, "SUB_TOTAL", "IND. Y.", "ARATOPLAM", string.Format("%{0}", +prm_xDiscountSurchargeDataModel.iDiscountPercentage), "", "", prm_xDiscountSurchargeDataModel.decDiscountSurchargeResult);
                dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value = (int)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 2].Cells["ROW_NUMBER"].Value;
                dataGridViewSales.Rows[iRowIndex].Selected = true;
                dataGridViewSales.FirstDisplayedScrollingRowIndex = iRowIndex;
            }
            else
            {
                return false;
            }

            labelMessage.Text = string.Empty;

            return true;
        }

        public bool bAddSurchargeByPercentLine(DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel)
        {
            if ((string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["TRANSACTION"].Value != "Ara Toplam" && (string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["NAME_OF_PRODUCT"].Value != "ARATOPLAM")
            {
                int iRowIndex = dataGridViewSales.Rows.Add(dataGridViewSales.Rows.Count + 1, 0, "SUB_TOTAL", "ART. Y.", m_xListCustomSalesData[m_xListCustomSalesData.Count - 1].NAME_OF_PRODUCT, string.Format("%{0}", prm_xDiscountSurchargeDataModel.iSurchargePercentage), "", "", prm_xDiscountSurchargeDataModel.decDiscountSurchargeResult);
                dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value = m_xListCustomSalesData[m_xListCustomSalesData.Count - 1].ROW_NUMBER;
                dataGridViewSales.Rows[iRowIndex].Selected = true;
                dataGridViewSales.FirstDisplayedScrollingRowIndex = iRowIndex;
            }

            else if ((string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["TRANSACTION"].Value == "Ara Toplam" || (string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["NAME_OF_PRODUCT"].Value == "ARATOPLAM")
            {
                int iRowIndex = dataGridViewSales.Rows.Add(dataGridViewSales.Rows.Count + 1, 0, "SUB_TOTAL", "ART. Y.", "ARATOPLAM", string.Format("%{0}", prm_xDiscountSurchargeDataModel.iSurchargePercentage), "", "", prm_xDiscountSurchargeDataModel.decDiscountSurchargeResult);
                dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value = (int)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 2].Cells["ROW_NUMBER"].Value;
                dataGridViewSales.Rows[iRowIndex].Selected = true;
                dataGridViewSales.FirstDisplayedScrollingRowIndex = iRowIndex;
            }
            else
            {
                return false;
            }

            labelMessage.Text = string.Empty;

            return true;
        }

        //public bool bCheckLastSaleCanceledOrNot()
        //{
        //    if (!(dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].DefaultCellStyle.BackColor == Color.LightGray || dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].DefaultCellStyle.ForeColor == Color.WhiteSmoke))
        //        return false;

        //    return true;
        //}

        public bool bAddTotal(decimal prm_decReceiptTotalPrice)
        {
            if ((string)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["TRANSACTION"].Value == "Satış")
            {
                int iRowIndex = dataGridViewSales.Rows.Add(dataGridViewSales.Rows.Count + 1, 0, "TOTAL", "Toplam", " ", 0m, 0, 0m, prm_decReceiptTotalPrice);
                dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value = (int)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 2].Cells["ROW_NUMBER"].Value;
                dataGridViewSales.Rows[iRowIndex].Selected = true;
                dataGridViewSales.FirstDisplayedScrollingRowIndex = iRowIndex;
            }

            labelMessage.Text = string.Empty;

            return true;
        }

        public bool bAddPayment(TransactionDataModel prm_xTransactionDataModel)
        {
            if (prm_xTransactionDataModel.xListPaymentDataModel.Last() == null)
                return false;

            CustomPaymentListData xCustomPaymentListData = new CustomPaymentListData();

            xCustomPaymentListData.ROW_NUMBER = dataGridViewPayments.Rows.Count + 1;
            xCustomPaymentListData.TYPE = prm_xTransactionDataModel.xListPaymentDataModel.Last().xPaymentTypeDataModel.strTypeName;
            xCustomPaymentListData.AMOUNT = prm_xTransactionDataModel.xListPaymentDataModel.Last().decAmount / 100;
            xCustomPaymentListData.ID = prm_xTransactionDataModel.xListPaymentDataModel.Last().lId;

            m_xListCustomPaymentListData.Add(xCustomPaymentListData);

            int iRowIndex = dataGridViewPayments.Rows.Add(xCustomPaymentListData.TYPE, xCustomPaymentListData.AMOUNT);
            dataGridViewPayments.Rows[iRowIndex].Selected = true;
            dataGridViewPayments.FirstDisplayedScrollingRowIndex = iRowIndex;

            m_iSelectedIndex = iRowIndex;

            return true;
        }

        public bool bClear()
        {
            while (m_xListCustomSalesData.Count > 0)
                m_xListCustomSalesData.RemoveAt(0);

            while (dataGridViewSales.Rows.Count > 0)
                dataGridViewSales.Rows.RemoveAt(0);

            decReceiptTotalPrice = 0m;
            decReceiptTotalPayment = 0m;
            decDiscountTotalAmount = 0m;
            decSurchargeTotalAmount = 0m;

            labelMessage.Text = string.Empty;

            while (m_xListCustomPaymentListData.Count > 0)
                m_xListCustomPaymentListData.RemoveAt(0);

            while (dataGridViewPayments.Rows.Count > 0)
                dataGridViewPayments.Rows.RemoveAt(0);

            return true;
        }

        public bool bShowMessage(string prm_strMessage)
        {
            labelMessage.Text = prm_strMessage;

            return true;
        }

        public bool bErrorCorrection(int prm_iIndex)
        {
            try
            {

                dataGridViewSales.Rows[prm_iIndex].DefaultCellStyle.BackColor = Color.LightGray;
                dataGridViewSales.Rows[prm_iIndex].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                dataGridViewSales.Rows[prm_iIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                //dataGridViewSales.Rows.RemoveAt(prm_iIndex);

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public bool bCancelTransaction(int prm_iIndex)
        {
            try
            {
                for (int iRowIndex = 0; iRowIndex < dataGridViewSales.Rows.Count; ++iRowIndex)
                {
                    if ((int)dataGridViewSales.Rows[prm_iIndex].Cells["ROW_NUMBER"].Value == (int)dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value)
                    {
                        dataGridViewSales.Rows[iRowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                        dataGridViewSales.Rows[iRowIndex].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                        dataGridViewSales.Rows[iRowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    }
                }
                //dataGridViewSales.Rows.RemoveAt(prm_iIndex);

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
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
            }
        }
    }

    class CustomCustomerSaleData
    {
        public int ROW_NUMBER { get; set; }
        public int REFERENCE_ID { get; set; }
        public string TRANSACTION_TYPE { get; set; }
        public string TRANSACTION { get; set; }
        public string NAME_OF_PRODUCT { get; set; }
        public decimal QUANTITY { get; set; }
        public int UNIT { get; set; }
        public decimal PRICE { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }
        public string BARCODE { get; set; }
        public int DEPARTMENT_NO { get; set; }
        public string PLU_NO { get; set; }
        public int ID { get; set; }
        public List<DiscountSurchargeDataModel> DISCOUNT_SURCHARGE_DATAMODEL_LIST { get; set; }
    }

    class CustomCustomerPaymentData
    {
        public int ROW_NUMBER { get; set; }
        public string TYPE { get; set; }
        public decimal AMOUNT { get; set; }
        public long ID { get; set; }
    }
}
