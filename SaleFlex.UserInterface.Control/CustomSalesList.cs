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
using SaleFlex.Data.AccessLayer;
using SaleFlex.Data;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.Controls
{
    public partial class CustomSalesList : UserControl, ICustomControl
    {
        List<CustomSalesData> m_xListCustomSalesData = new List<CustomSalesData>();
        int m_iSelectedIndex = 0;

        public CustomSalesList(FormControlDataModel prm_xFormControlsDataModel)
        {
            InitializeComponent();
            vInitializeCustomComponents(prm_xFormControlsDataModel);
        }

        public void vInitializeCustomComponents(FormControlDataModel prm_xFormControlDataModel)
        {
            ((Control)this).bSetControlCommonProperties(prm_xFormControlDataModel);

            dataGridViewSales.BackgroundColor = BackColor;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewSales.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewSales.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewSales.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridViewSales.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewSales.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            dataGridViewSales.Click += new EventHandler(vOnEvent1);
        }

        private void dataGridViewSales_Paint(object sender, PaintEventArgs e)
        {
            // Grid'de exception oluşursa bunu es geçmek için kullanılan kod.
            try
            {
                base.OnPaint(e);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                base.Invalidate();
            }
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
            xCustomSalesData.TRANSACTION = prm_xTransactionDataModel.xTransactionHeadDataModel.iTransactionDocumentTypeNo != (int)EnumDocumentType.Return ? LabelTranslations.strGet("ProductSale") : LabelTranslations.strGet("ProductReturn");
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
                List<PluBarcodeDataModel> xListPluBarcodeDataModels = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.xListPluBarcodeDataModel;
                xCustomSalesData.BARCODE = xListPluBarcodeDataModels != null ? xListPluBarcodeDataModels[0].strBarcode : "";
                if (xListPluBarcodeDataModels != null && xListPluBarcodeDataModels[0].strBarcode != null && xListPluBarcodeDataModels[0].strBarcode.Length > 0)
                    xCustomSalesData.NAME_OF_PRODUCT = string.Format("{0} [{1}]", prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.strDescriptionOnScreen, prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.xListPluBarcodeDataModel[0].strBarcode);
                else if(xListPluBarcodeDataModels == null)
                    xCustomSalesData.NAME_OF_PRODUCT = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.strDescriptionOnScreen;
                else
                    xCustomSalesData.NAME_OF_PRODUCT = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.strName;
            }
            xCustomSalesData.QUANTITY = prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().xPluDataModel.StockUnitNo == 1 ? Convert.ToDecimal(prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().decQuantity)/1000 : prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().decQuantity;
            xCustomSalesData.PRICE = decimal.Parse(prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().decPrice.ToString()) / 100;
            xCustomSalesData.TOTAL_AMOUNT = decimal.Parse(prm_xTransactionDataModel.xListTransactionDetailDataModel.Last().decTotalPrice.ToString()) / 100;
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
            Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale in bAddSale Ended");

            if (xGetCustomCustomerForm() != null)
                xGetCustomCustomerForm().bAddSale(prm_xTransactionDataModel);

            return true;
        }

        public bool bAddSaleFromSuspended(TransactionDataModel prm_xTransactionDataModel)
        {
            Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSaleFromSuspended in CustomsaleList.cs Called");
            for (int i = 0; i < prm_xTransactionDataModel.xListTransactionDetailDataModel.Count; i++)
            {
                if (prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xDepartmentDataModel == null && prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xPluDataModel == null)
                    return false;

                CustomSalesData xCustomSalesData = new CustomSalesData();

                if (m_xListCustomSalesData.Count == 0)
                    xCustomSalesData.ROW_NUMBER = 1;

                else
                    xCustomSalesData.ROW_NUMBER = (int)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["ROW_NUMBER"].Value + 1;

                xCustomSalesData.REFERENCE_ID = prm_xTransactionDataModel.xListTransactionDetailDataModel[i].iId;
                xCustomSalesData.TRANSACTION = prm_xTransactionDataModel.xTransactionHeadDataModel.iTransactionDocumentTypeNo == 1 ? "Satış" : "İade";
                xCustomSalesData.UNIT = 1;
                if (prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xDepartmentDataModel != null)
                {
                    xCustomSalesData.TRANSACTION_TYPE = "DEPARTMENT";
                    xCustomSalesData.ID = prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xDepartmentDataModel.iId;
                    xCustomSalesData.DEPARTMENT_NO = prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xDepartmentDataModel.iNo;
                    xCustomSalesData.NAME_OF_PRODUCT = prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xDepartmentDataModel.strName;
                }
                else if (prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xPluDataModel != null)
                {
                    xCustomSalesData.TRANSACTION_TYPE = "PLU";
                    xCustomSalesData.ID = prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xPluDataModel.iId;
                    xCustomSalesData.PLU_NO = prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xPluDataModel.strCode;
                    xCustomSalesData.BARCODE = prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xPluDataModel.xListPluBarcodeDataModel[0].strBarcode;
                    if (prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xPluDataModel.xListPluBarcodeDataModel[0].strBarcode != null && prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xPluDataModel.xListPluBarcodeDataModel[0].strBarcode.Length > 0)
                        xCustomSalesData.NAME_OF_PRODUCT = string.Format("{0} [{1}]", prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xPluDataModel.strDescriptionOnScreen, prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xPluDataModel.xListPluBarcodeDataModel[0].strBarcode);
                    else
                        xCustomSalesData.NAME_OF_PRODUCT = prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xPluDataModel.strName;
                }
                xCustomSalesData.QUANTITY = prm_xTransactionDataModel.xListTransactionDetailDataModel[i].decQuantity;
                xCustomSalesData.PRICE = decimal.Parse(prm_xTransactionDataModel.xListTransactionDetailDataModel[i].decPrice.ToString()) / 100;
                xCustomSalesData.TOTAL_AMOUNT = decimal.Parse(prm_xTransactionDataModel.xListTransactionDetailDataModel[i].decTotalPrice.ToString()) / 100;
                xCustomSalesData.DISCOUNT_SURCHARGE_DATAMODEL_LIST = prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xDiscountSurchargeDataModel;
                xCustomSalesData.UNIT_QUANTITY = prm_xTransactionDataModel.xListTransactionDetailDataModel[i].xPluDataModel.StockUnitNo != 1 ? xCustomSalesData.QUANTITY.ToString() : string.Format("{0:#,0.000}", xCustomSalesData.QUANTITY/1000);

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
                Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale in bAddSale Ended");

                if (xGetCustomCustomerForm() != null)
                    xGetCustomCustomerForm().bAddSale(prm_xTransactionDataModel);

                if (prm_xTransactionDataModel.xListTransactionDetailDataModel[i].bCanceled)
                    bCancelTransaction(iRowIndex);

            }
            return true;
        }

        public bool bAddSaleWithDetailValues(List<TransactionDetailDataModel> prm_xTransactionDetailDataModel)
        {
            Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale in bAddSale Called");
            if (prm_xTransactionDetailDataModel.Last().xDepartmentDataModel == null && prm_xTransactionDetailDataModel.Last().xPluDataModel == null)
                return false;

            CustomSalesData xCustomSalesData = new CustomSalesData();

            if (m_xListCustomSalesData.Count == 0)
                xCustomSalesData.ROW_NUMBER = 1;

            else
                xCustomSalesData.ROW_NUMBER = (int)dataGridViewSales.Rows[dataGridViewSales.Rows.Count - 1].Cells["ROW_NUMBER"].Value + 1;

            xCustomSalesData.REFERENCE_ID = prm_xTransactionDetailDataModel.Last().iId;
            xCustomSalesData.TRANSACTION = "Satış";
            xCustomSalesData.UNIT = 1;
            if (prm_xTransactionDetailDataModel.Last().xDepartmentDataModel != null)
            {
                xCustomSalesData.TRANSACTION_TYPE = "DEPARTMENT";
                xCustomSalesData.ID = prm_xTransactionDetailDataModel.Last().xDepartmentDataModel.iId;
                xCustomSalesData.DEPARTMENT_NO = prm_xTransactionDetailDataModel.Last().xDepartmentDataModel.iNo;
                xCustomSalesData.NAME_OF_PRODUCT = prm_xTransactionDetailDataModel.Last().xDepartmentDataModel.strName;
            }
            else if (prm_xTransactionDetailDataModel.Last().xPluDataModel != null)
            {
                xCustomSalesData.TRANSACTION_TYPE = "PLU";
                xCustomSalesData.ID = prm_xTransactionDetailDataModel.Last().xPluDataModel.iId;
                xCustomSalesData.PLU_NO = prm_xTransactionDetailDataModel.Last().xPluDataModel.strCode;
                xCustomSalesData.BARCODE = prm_xTransactionDetailDataModel.Last().xPluDataModel.xListPluBarcodeDataModel[0].strBarcode;
                if (prm_xTransactionDetailDataModel.Last().xPluDataModel.xListPluBarcodeDataModel[0].strBarcode != null && prm_xTransactionDetailDataModel.Last().xPluDataModel.xListPluBarcodeDataModel[0].strBarcode.Length > 0)
                    xCustomSalesData.NAME_OF_PRODUCT = string.Format("{0} [{1}]", prm_xTransactionDetailDataModel.Last().xPluDataModel.strDescriptionOnScreen, prm_xTransactionDetailDataModel.Last().xPluDataModel.xListPluBarcodeDataModel[0].strBarcode);
                else
                    xCustomSalesData.NAME_OF_PRODUCT = prm_xTransactionDetailDataModel.Last().xPluDataModel.strName;
            }
            xCustomSalesData.QUANTITY = prm_xTransactionDetailDataModel.Last().decQuantity;
            xCustomSalesData.PRICE = prm_xTransactionDetailDataModel.Last().decPrice;
            xCustomSalesData.TOTAL_AMOUNT = prm_xTransactionDetailDataModel.Last().decTotalPrice;
            xCustomSalesData.DISCOUNT_SURCHARGE_DATAMODEL_LIST = prm_xTransactionDetailDataModel.Last().xDiscountSurchargeDataModel;
            xCustomSalesData.UNIT_QUANTITY = prm_xTransactionDetailDataModel.Last().xPluDataModel.StockUnitNo == 3 ? xCustomSalesData.QUANTITY.ToString() : string.Format("{0:#,0.000}", xCustomSalesData.QUANTITY);

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
            Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale in bAddSale Ended");

            //if (xGetCustomCustomerForm() != null)
            //    xGetCustomCustomerForm().bAddSale(prm_xTransactionDataModel);

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

            if (xGetCustomCustomerForm() != null)
                xGetCustomCustomerForm().bAddSubTotal(prm_decReceiptTotalPrice, prm_xTransactionDataModel);

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

            if (xGetCustomCustomerForm() != null)
                xGetCustomCustomerForm().bAddDiscountByAmountLine(prm_xDiscountSurchargeDataModel);

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

            if (xGetCustomCustomerForm() != null)
                xGetCustomCustomerForm().bAddDiscountByPercentLine(prm_xDiscountSurchargeDataModel);

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

            if (xGetCustomCustomerForm() != null)
                xGetCustomCustomerForm().bAddSurchargeByPercentLine(prm_xDiscountSurchargeDataModel);

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

            if (xGetCustomCustomerForm() != null)
                xGetCustomCustomerForm().bAddTotal(prm_decReceiptTotalPrice);

            return true;
        }

        public bool bClear()
        {
            while (m_xListCustomSalesData.Count > 0)
                m_xListCustomSalesData.RemoveAt(0);

            while (dataGridViewSales.Rows.Count > 0)
                dataGridViewSales.Rows.RemoveAt(0);

            if (xGetCustomCustomerForm() != null)
                xGetCustomCustomerForm().bClear();

            return true;
        }

        public bool bGetDiscountSurchargeList(int prm_iIndex, List<DiscountSurchargeDataModel> prm_xIncomingDiscountSurchargeDataModelList, out List<DiscountSurchargeDataModel> prm_xOutgoingDiscountSurchargeDataModelList)
        {
            int iDiscountSurchargeCounter = -1;
            prm_xOutgoingDiscountSurchargeDataModelList = null;

            try
            {
                prm_xOutgoingDiscountSurchargeDataModelList = new List<DiscountSurchargeDataModel>();
                int iRowNumber = (int)dataGridViewSales.Rows[prm_iIndex].Cells["ROW_NUMBER"].Value;

                for (int iIndex = 0; iIndex < dataGridViewSales.Rows.Count; iIndex++)
                {
                    if ((string)dataGridViewSales.Rows[iIndex].Cells["TRANSACTION"].Value != "Ara Toplam" && (string)dataGridViewSales.Rows[iIndex].Cells["TRANSACTION"].Value != "Satış")
                    {
                        iDiscountSurchargeCounter += 1;
                        if ((int)dataGridViewSales.Rows[iIndex].Cells["ROW_NUMBER"].Value == iRowNumber)
                        {
                            prm_xIncomingDiscountSurchargeDataModelList[iDiscountSurchargeCounter].bIsDiscount = false;
                        }
                    }
                }
                foreach (DiscountSurchargeDataModel IncomingDiscountSurchargeDataModelList in prm_xIncomingDiscountSurchargeDataModelList)
                {
                    prm_xOutgoingDiscountSurchargeDataModelList.Add(IncomingDiscountSurchargeDataModelList);

                }

            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return true;
        }


        public int iGetSelectedSale(out TransactionDetailDataModel prm_xTransactionDetailDataModel)
        {
            int iRowIndex = -1;
            prm_xTransactionDetailDataModel = null;


            try
            {
                if (dataGridViewSales.SelectedRows.Count > 0)
                {
                    iRowIndex = dataGridViewSales.SelectedRows[0].Index;

                    prm_xTransactionDetailDataModel = new TransactionDetailDataModel();

                    int iRowNumber = (int)dataGridViewSales.SelectedRows[0].Cells["ROW_NUMBER"].Value;

                    CustomSalesData xCustomSalesData = null;

                    foreach (CustomSalesData xCustomSalesListData in m_xListCustomSalesData)
                    {
                        if (xCustomSalesListData.ROW_NUMBER == iRowNumber)
                        {
                            xCustomSalesData = xCustomSalesListData;
                            break;
                        }
                    }

                    prm_xTransactionDetailDataModel = Dao.xGetInstance().xGetTransactionDetail(xCustomSalesData.REFERENCE_ID);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return iRowIndex;
        }

        public int iGetLastSale(out TransactionDetailDataModel prm_xTransactionDetailDataModel)
        {
            int iRowIndex = -1;
            prm_xTransactionDetailDataModel = null;

            try
            {
                if (dataGridViewSales.Rows.Count > 0)
                {
                    iRowIndex = dataGridViewSales.Rows.Count - 1;

                    if ((string)dataGridViewSales.Rows[iRowIndex].Cells["TRANSACTION"].Value != "Ara Toplam" && (string)dataGridViewSales.Rows[iRowIndex].Cells["NAME_OF_PRODUCT"].Value != "ARA TOPLAM")
                    {
                        prm_xTransactionDetailDataModel = new TransactionDetailDataModel();
                        prm_xTransactionDetailDataModel.xDiscountSurchargeDataModel = new List<DiscountSurchargeDataModel>();
                        prm_xTransactionDetailDataModel.xDiscountSurchargeDataModel = m_xListCustomSalesData.Last().DISCOUNT_SURCHARGE_DATAMODEL_LIST;

                        // prm_xTransactionDetailDataModel.xDiscountSurchargeDataModel = m_xListCustomSalesListData.Last().DISCOUNT_SURCHARGE_DATAMODEL_LIST;
                        //prm_xTransactionDetailDataModel.xDiscountSurchargeDataModel.Add(m_xListCustomSalesListData.Last().DISCOUNT_SURCHARGE_DATAMODEL_LIST.Last());
                        //return iRowIndex;
                    }

                    while (iRowIndex >= 0 && ((dataGridViewSales.Rows[iRowIndex].DefaultCellStyle.BackColor == Color.LightGray || dataGridViewSales.Rows[iRowIndex].DefaultCellStyle.ForeColor == Color.WhiteSmoke)))
                    {
                        iRowIndex--;
                    }

                    if (iRowIndex >= 0)
                    {
                        prm_xTransactionDetailDataModel = new TransactionDetailDataModel();

                        int iRowNumber = (int)dataGridViewSales.Rows[iRowIndex].Cells["ROW_NUMBER"].Value;

                        CustomSalesData xCustomSalesData = null;

                        foreach (CustomSalesData xCustomSalesListData in m_xListCustomSalesData)
                        {
                            if (xCustomSalesListData.ROW_NUMBER == iRowNumber)
                            {
                                xCustomSalesData = xCustomSalesListData;
                                break;
                            }
                        }

                        prm_xTransactionDetailDataModel = Dao.xGetInstance().xGetTransactionDetail(xCustomSalesData.REFERENCE_ID);
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return iRowIndex;
        }

        public bool bErrorCorrection(int prm_iIndex)
        {
            try
            {

                dataGridViewSales.Rows[prm_iIndex].DefaultCellStyle.BackColor = Color.LightGray;
                dataGridViewSales.Rows[prm_iIndex].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                dataGridViewSales.Rows[prm_iIndex].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                //dataGridViewSales.Rows.RemoveAt(prm_iIndex);

                if (xGetCustomCustomerForm() != null)
                    xGetCustomCustomerForm().bErrorCorrection(prm_iIndex);

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

                if (xGetCustomCustomerForm() != null)
                    xGetCustomCustomerForm().bCancelTransaction(prm_iIndex);

                return true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }
        public bool bRepeatTransaction(int prm_iIndex)
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

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.Rows.Count > 0 && m_iSelectedIndex > 0)
            {
                m_iSelectedIndex--;
                dataGridViewSales.Rows[m_iSelectedIndex].Selected = true;
                dataGridViewSales.FirstDisplayedScrollingRowIndex = m_iSelectedIndex;
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.Rows.Count > 0 && m_iSelectedIndex < dataGridViewSales.Rows.Count - 1)
            {
                m_iSelectedIndex++;
                dataGridViewSales.Rows[m_iSelectedIndex].Selected = true;
                dataGridViewSales.FirstDisplayedScrollingRowIndex = m_iSelectedIndex;
            }
        }

        private void CustomSalesList_Enter(object sender, EventArgs e)
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

    class CustomSalesData
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
        public string UNIT_QUANTITY { get; set; }
    }
}
