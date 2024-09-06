using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Constanst;
using SaleFlex.UserInterface.BoxForm;
using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.POS.Manager;
using SaleFlex.POS.Device.Manager;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.Manager
{
    public partial class Events
    {
        /// <summary>
        /// DEPARTMENT_SALE
        /// Sale department
        /// </summary>

        public PosManager m_xPosManager = null;
        private bool bCheckWaybill = false;

        public void vSaleMenu(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();

                if (xControl is CustomButton)
                {
                    PosManager.xGetInstance().vChangeForm(EnumFormType.SALE);
                    bReDrawFormControls();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vSaleDepartment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsPaymentStart() == true)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                    return;
                }

                Control xControl = (Control)prm_objSender;
                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                string strNumPadOutput = m_xLastCustomForm.strGetNumPadOutput();

                if (m_decPriceOfProduct == 0 && strNumPadOutput != string.Empty && strNumPadOutput.Length > 0 && xControl is CustomButton && ((CustomButton)xControl).strName.Substring(0, 10).ToUpper() == "DEPARTMENT")
                {
                    try
                    {
                        long decPriceOfProduct = Convert.ToInt64(strNumPadOutput);
                        m_decPriceOfProduct = decPriceOfProduct; // If convertable set the value
                    }
                    catch
                    {
                    }
                }

                if (xControl is CustomButton)
                {
                    CustomButton xCustomButton = (CustomButton)prm_objSender;
                    if (xCustomButton.strName.Length > 10 && xCustomButton.strName.Substring(0, 10).ToUpper() == "DEPARTMENT")
                    {
                        int iDepartmentNo = int.Parse(xCustomButton.strName.Substring(10, xCustomButton.strName.Length - 10));

                        long decPrice = m_decPriceOfProduct;
                        long decQuantity = m_decQuantityOfProduct;
                        m_decPriceOfProduct = 0;
                        m_decQuantityOfProduct = 1;
                        if (PosManager.xGetInstance().bSaleDepartment(iDepartmentNo, decPrice, decQuantity) == false)
                        {
                            CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                            return;
                        }

                        vTotalValuesChanges();
                        vNewTransactionAdded();
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vSaleDepartmentByNo(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsPaymentStart() == true)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                    return;
                }

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                string strNumPadOutput = m_xLastCustomForm.strGetNumPadOutput();

                if (strNumPadOutput != string.Empty && strNumPadOutput.Length > 0 && ((xControl is CustomNumpad && ((CustomNumpad)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strSaleDepartmentByNo) || (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strSaleDepartmentByNo)))
                {
                    if (prop_xPosManagerData == null)
                    {
                        if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }

                    int iDepartmentNo = int.Parse(strNumPadOutput);
                    DepartmentDataModel xDepartmentDataModel = Dao.xGetInstance().xGetDepartmentByNo(iDepartmentNo);

                    if (xDepartmentDataModel != null)
                    {
                        long decPrice = m_decPriceOfProduct.bOverflowAmountCheck() == true ? xDepartmentDataModel.decDefaultPrice : m_decPriceOfProduct;
                        if (PosManager.xGetInstance().bSaleDepartment(iDepartmentNo, decPrice, m_decQuantityOfProduct) == false)
                        {
                        }

                        m_decPriceOfProduct = 0;
                    }
                    else
                        CustomMessageBox.Show(LabelTranslations.strGet("DepartmentNotFound"));

                    m_decQuantityOfProduct = 1;
                    vTotalValuesChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// PLU_INDEX_SALE
        /// </summary>
        /// <param name="prm_objSender"></param>kd
        /// <param name="prm_xEventArgs"></param>
        public void vSalePluCode(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                Trace.vInsert(enumTraceLevel.Unnecessary, "vSalePluCode Called.");

                if (bIsPaymentStart() == true)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                    return;
                }

                Control xControl = (Control)prm_objSender;
                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                string strNumPadOutput = m_xLastCustomForm.strGetNumPadOutput();

                if (m_decPriceOfProduct == 0 && strNumPadOutput != string.Empty && strNumPadOutput.Length > 0 && xControl is CustomButton && ((CustomButton)xControl).strName.Substring(0, 3).ToUpper() == "PLU")
                {
                    try
                    {
                        long decQuantityOfProduct = Convert.ToInt64(decimal.Parse(strNumPadOutput) * 1000);// Miktar virgüllü ise diye 1000 ile çarpıyoruz
                        m_decQuantityOfProduct = decQuantityOfProduct; // If convertable set the value
                    }
                    catch
                    {
                    }
                }

                if (xControl is CustomButton)
                {
                    CustomButton xCustomButton = (CustomButton)prm_objSender;
                    if (xCustomButton.strName.Length > 3 && xCustomButton.strName.Substring(0, 3).ToUpper() == "PLU")
                    {
                        string strPluCode = xCustomButton.strName.Substring(3, xCustomButton.strName.Length - 3);

                        long decPrice = m_decPriceOfProduct;
                        long decQuantity = m_decQuantityOfProduct;
                        m_decPriceOfProduct = 0;
                        m_decQuantityOfProduct = 1;

                        if (PosManager.xGetInstance().bSalePluByCode(strPluCode, decPrice, decQuantity) == false)
                        {
                            CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                            return;
                        }

                        vTotalValuesChanges();
                        vNewTransactionAdded();
                        vPrintReceipt();
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// PLU_BARCODE_SALE
        /// </summary>
        /// <param name="prm_objSender"></param>
        /// <param name="prm_xEventArgs"></param>
        public void vSalePluBarcode(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                Trace.vInsert(enumTraceLevel.Unnecessary, "vSalePluBarcode Called.");
                bool isMultiply = false;
                if (bIsPaymentStart() == true)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                    return;
                }

                Control xControl = (Control)prm_objSender;
                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                string strNumPadOutput = m_xLastCustomForm.strGetNumPadOutput();

                if (m_decPriceOfProduct == 0 && strNumPadOutput != string.Empty && strNumPadOutput.Length > 0 && xControl is CustomButton && ((CustomButton)xControl).strName.Substring(0, 3).ToUpper() == "PLU")
                {
                    try
                    {
                        long decQuantityOfProduct = Convert.ToInt64(decimal.Parse(strNumPadOutput)*1000); // Miktar virgüllü ise diye 1000 ile çarpıyoruz
                        m_decQuantityOfProduct = decQuantityOfProduct; // If convertable set the value
                        isMultiply = true;
                    }
                    catch
                    {
                    }
                }

                string strPluBarcode = string.Empty;

                if (xControl is CustomButton)
                {
                    CustomButton xCustomButton = (CustomButton)prm_objSender;
                    if (xCustomButton.strName.Length > 7 && xCustomButton.strName.Substring(0, 3).ToUpper() == "PLU")
                    {
                        strPluBarcode = xCustomButton.strName.Substring(3, xCustomButton.strName.Length - 3);
                    }
                }
                else if (xControl is CustomNumpad)
                {
                    if (strNumPadOutput.IndexOf("X") > 0)
                    {
                        try
                        {
                            long decQuantityOfProduct = Convert.ToInt64(decimal.Parse(strNumPadOutput.Substring(0, strNumPadOutput.IndexOf("X"))) * 1000);// Miktar virgüllü ise diye 1000 ile çarpıyoruz
                            m_decQuantityOfProduct = decQuantityOfProduct; // If convertable set the value
                            isMultiply = true;
                        }
                        catch
                        {
                        }
                        strPluBarcode = strNumPadOutput.Substring(strNumPadOutput.IndexOf("X") + 1);
                    }
                    else
                    {
                        strPluBarcode = strNumPadOutput;
                    }
                }

                if (strPluBarcode != string.Empty)
                {
                    long decPrice = m_decPriceOfProduct;
                    long decQuantity = isMultiply == false ? m_decQuantityOfProduct*1000 : m_decQuantityOfProduct; //1000 den küçükse istenilen bir sayı değildir, o yüzden çarpıyoruz.
                    
                    m_decPriceOfProduct = 0;
                    m_decQuantityOfProduct = 1;

                    if (PosManager.xGetInstance().bSalePlu(strPluBarcode, decPrice, decQuantity) == false)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        return;
                    }

                    vTotalValuesChanges();
                    vNewTransactionAdded();

                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vRepeatSale(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //Trace.vInsert(enumTraceLevel.Unnecessary, "vRepeatTransaction Called.");
                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentStart() == true)
                    return;

                Control xControl = (Control)prm_objSender;
                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                TransactionDetailDataModel xTransactionDetailDataModel = null;

                int iSaleIndex = m_xLastCustomForm.iGetSelectedSale(out xTransactionDetailDataModel);

                if (xTransactionDetailDataModel.bCanceled == false && iSaleIndex >= 0)
                {
                    if (xTransactionDetailDataModel.xDepartmentDataModel != null)
                    {
                        PosManager.xGetInstance().bSaleDepartment(xTransactionDetailDataModel.xDepartmentDataModel.iNo, xTransactionDetailDataModel.decPrice, xTransactionDetailDataModel.decQuantity);
                    }
                    else if (xTransactionDetailDataModel.xPluDataModel != null)
                    {
                        long QuantityControl = xTransactionDetailDataModel.xPluDataModel.StockUnitNo == 1 ? xTransactionDetailDataModel.decQuantity : xTransactionDetailDataModel.decQuantity*1000;

                        PosManager.xGetInstance().bSalePluByCode(xTransactionDetailDataModel.xPluDataModel.strCode, xTransactionDetailDataModel.decPrice, QuantityControl);
                    }

                }

                m_decPriceOfProduct = 0;
                m_decQuantityOfProduct = 1;

                vTotalValuesChanges();
                vNewTransactionAdded();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// REPEAT_LAST_SALE
        /// </summary>
        /// <param name="prm_objSender"></param>
        /// <param name="prm_xEventArgs"></param>
        public void vRepeatLastSale(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //Trace.vInsert(enumTraceLevel.Unnecessary, "vRepeatTransaction Called.");
                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentStart() == true)
                    return;

                Control xControl = (Control)prm_objSender;
                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strRepeatLastSale)
                {
                    TransactionDetailDataModel xTransactionDetailDataModel = null;

                    int iSaleIndex = m_xLastCustomForm.iGetLastSale(out xTransactionDetailDataModel);

                    if (xTransactionDetailDataModel.bCanceled == false && iSaleIndex >= 0)
                    {
                        if (xTransactionDetailDataModel.xDepartmentDataModel != null)
                        {
                            PosManager.xGetInstance().bSaleDepartment(xTransactionDetailDataModel.xDepartmentDataModel.iNo, xTransactionDetailDataModel.decPrice, xTransactionDetailDataModel.decQuantity);
                        }
                        else if (xTransactionDetailDataModel.xPluDataModel != null)
                        {
                            PosManager.xGetInstance().bSalePluByCode(xTransactionDetailDataModel.xPluDataModel.strCode, xTransactionDetailDataModel.xPluDataModel.xListPluBarcodeDataModel[0].decSalePrice, xTransactionDetailDataModel.decQuantity);
                        }

                    }

                    m_decPriceOfProduct = 0;
                    m_decQuantityOfProduct = 1;

                    vTotalValuesChanges();
                    vNewTransactionAdded();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// CANCEL_DEPARTMENT
        /// </summary>
        /// <param name="prm_objSender"></param>
        /// <param name="prm_xEventArgs"></param>
        public void vCancelDepartment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //if (bIsNotReceiptOpen() == true)
                //    return;
                //if (bIsPaymentStart() == true)
                //    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                TransactionDetailDataModel xTransactionDetailDataModel = null;

                int iSaleIndex = m_xLastCustomForm.iGetSelectedSale(out xTransactionDetailDataModel);

                if (xTransactionDetailDataModel.bCanceled == false && xTransactionDetailDataModel.xDepartmentDataModel != null && iSaleIndex >= 0 && CustomMessageBox.Show("ÜRÜNÜN İPTALİNİ ONAYLIYOR MUSUNUZ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PosManager.xGetInstance().bCancelDepartment(xTransactionDetailDataModel.xDepartmentDataModel);

                    m_xLastCustomForm.bErrorCorrection(iSaleIndex);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// CANCEL_PLU
        /// </summary>
        /// <param name="prm_objSender"></param>
        /// <param name="prm_xEventArgs"></param>
        public void vCancelPlu(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //if (bIsNotReceiptOpen() == true)
                //    return;
                //if (bIsPaymentStart() == true)
                //    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                string strNumPadOutput = m_xLastCustomForm.strGetNumPadOutput();

                if (strNumPadOutput == string.Empty)
                {

                    TransactionDetailDataModel xTransactionDetailDataModel = null;

                    int iSaleIndex = m_xLastCustomForm.iGetSelectedSale(out xTransactionDetailDataModel);

                    if (xTransactionDetailDataModel.bCanceled == false && iSaleIndex >= 0 && xTransactionDetailDataModel.xPluDataModel != null && CustomMessageBox.Show("ÜRÜNÜN İPTALİNİ ONAYLIYORMUSNUZ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        PosManager.xGetInstance().bCancelPlu(xTransactionDetailDataModel.xPluDataModel);

                        m_xLastCustomForm.bErrorCorrection(iSaleIndex);
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// CANCEL_LAST_SALE
        /// </summary>
        /// <param name="prm_objSender"></param>
        /// <param name="prm_xEventArgs"></param>
        public void vCancelLastSale(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentStart() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strCancelLastSale)
                {
                    TransactionDetailDataModel xTransactionDetailDataModel = null;

                    int iSaleIndex = m_xLastCustomForm.iGetLastSale(out xTransactionDetailDataModel);

                    if (xTransactionDetailDataModel.bCanceled == false && iSaleIndex >= 0 && CustomMessageBox.Show("ÜRÜNÜN İPTALİNİ ONAYLIYORMUSNUZ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (PosManager.xGetInstance().bErrorCorrection(xTransactionDetailDataModel) == true)
                            m_xLastCustomForm.bErrorCorrection(iSaleIndex);
                    }

                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }
        /**/


        /**/


        public void vCancelSale(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentStart() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                TransactionDetailDataModel xTransactionDetailDataModel = null;

                int iSaleIndex = m_xLastCustomForm.iGetSelectedSale(out xTransactionDetailDataModel);


                if (xTransactionDetailDataModel.bCanceled == false && iSaleIndex >= 0 && CustomMessageBox.Show("ÜRÜNÜN İPTALİNİ ONAYLIYORMUSNUZ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (PosManager.xGetInstance().bCancelTransaction(xTransactionDetailDataModel) == true)
                    {
                        m_xLastCustomForm.bCancelTransaction(iSaleIndex);

                        foreach (Control xController in m_xLastCustomForm.Controls)
                        {
                            if (xController is CustomAmountsTable)
                            {
                                ((CustomAmountsTable)xController).decReceiptTotalPrice -= xTransactionDetailDataModel.decTotalPrice;
                                ((CustomAmountsTable)xController).decReceiptTotalPayment -= xTransactionDetailDataModel.decTotalPriceWithoutVat;

                                break;
                            }
                        }
                        vTotalValuesChanges();
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vCancelDocument(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsNotReceiptOpen() == true)
                    return;
                //if (bIsPaymentStart() == true)
                //    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strName.ToUpper() == CustomEventFunctionName.strCancelDocument)
                {
                    if (CustomMessageBox.Show(LabelTranslations.strGet("AreYouSure"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (PosManager.xGetInstance().bCancelReceipt() == true)
                        {
                            m_decPriceOfProduct = 0;
                            m_decQuantityOfProduct = 1;

                            vReceiptClosed(true);
                            vTotalValuesChanges();

                            DeviceManager.xGetInstance().bCustomerDisplayMessage(LabelTranslations.strGet("DocumentCancelled"), "");
                            m_xLastCustomForm.xCustomCustomerForm.bShowMessage(LabelTranslations.strGet("DocumentCancelled"));
                        }
                        else
                        {
                            CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        }
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vStockEntryForm(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                InputBoxStockEntry xInputBoxStockEntry = new InputBoxStockEntry();
                xInputBoxStockEntry.ShowDialog();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vDiscountByAmount(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //if (bIsNotReceiptOpen() == true)
                //    return;
                //if (bIsPaymentStart() == true)
                //    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strDiscountByAmount)
                {
                    try
                    {
                        if (bIsNotReceiptOpen())
                            return;

                        long decDiscountAmount = m_xLastCustomForm.strGetNumPadOutput().decConvertToDecimal();

                        if (prop_xPosManagerData.decReceiptTotalPrice > decDiscountAmount && decDiscountAmount.bOverflowAmountCheck() == false)
                        {
                            //bool result = m_xLastCustomForm.bCheckLastSaleCanceledOrNot();

                            //if (result == false)
                            //{
                            DiscountSurchargeDataModel xDiscountSurchargeDataModel = new DiscountSurchargeDataModel();
                            PosManager.xGetInstance().bDiscountByAmount(decDiscountAmount, out xDiscountSurchargeDataModel);
                            m_xLastCustomForm.bAddDiscountByAmountLine(xDiscountSurchargeDataModel);
                            //}
                        }
                        else
                            CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vSurchargeByAmount(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //if (bIsNotReceiptOpen() == true)
                //    return;
                //if (bIsPaymentStart() == true)
                //    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strSurchargeByAmount)
                {
                    try
                    {
                        if (bIsNotReceiptOpen())
                            return;

                        decimal decSurchargeAmount = m_xLastCustomForm.strGetNumPadOutput().decConvertToDecimal();

                        if (prop_xPosManagerData.decReceiptTotalPrice > decSurchargeAmount)
                        {
                            PosManager.xGetInstance().bSurchargeByAmount(decSurchargeAmount);
                        }
                        else
                            CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vDiscountByPercent(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //if (bIsNotReceiptOpen() == true)
                //    return;
                //if (bIsPaymentStart() == true)
                //    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strDiscountByPercent)
                {
                    string strDiscountPercentage = m_xLastCustomForm.strGetNumPadOutput();
                    int iDiscountPercentage = strDiscountPercentage.iConvertToInt();

                    if (bIsNotReceiptOpen())
                        return;

                    if (strDiscountPercentage == "")
                    {
                        if (PosManager.xGetInstance().bGetDiscountRate(ref iDiscountPercentage) != false && iDiscountPercentage != 0)
                        {
                            DiscountSurchargeDataModel xDiscountSurchargeDataModel = new DiscountSurchargeDataModel();
                            xDiscountSurchargeDataModel.iDiscountPercentage = iDiscountPercentage;
                            PosManager.xGetInstance().bDiscountByPercent(iDiscountPercentage, out xDiscountSurchargeDataModel);
                            m_xLastCustomForm.bAddDiscountByPercentLine(xDiscountSurchargeDataModel);
                        }
                        else
                        {
                            CustomMessageBox.Show(LabelTranslations.strGet("DefineDiscountSurchargeValue"));
                        }
                    }
                    else if (iDiscountPercentage > 0 && iDiscountPercentage < 100)
                    {
                        DiscountSurchargeDataModel xDiscountSurchargeDataModel = new DiscountSurchargeDataModel();
                        PosManager.xGetInstance().bDiscountByPercent(iDiscountPercentage, out xDiscountSurchargeDataModel);
                        m_xLastCustomForm.bAddDiscountByPercentLine(xDiscountSurchargeDataModel);
                    }
                    else
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vSurchargeByPercent(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //if (bIsNotReceiptOpen() == true)
                //    return;
                //if (bIsPaymentStart() == true)
                //    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strName.ToUpper() == CustomEventFunctionName.strSurchargeByPercent)
                {
                    string strSurchargePercentage = m_xLastCustomForm.strGetNumPadOutput();
                    int iSurchargePercentage = strSurchargePercentage.iConvertToInt();

                    if (bIsNotReceiptOpen())
                        return;

                    if (strSurchargePercentage == "")
                    {
                        if (PosManager.xGetInstance().bGetSurchargeRate(ref iSurchargePercentage) != false && iSurchargePercentage != 0)
                        {
                            DiscountSurchargeDataModel xDiscountSurchargeDataModel = new DiscountSurchargeDataModel();
                            xDiscountSurchargeDataModel.iSurchargePercentage = iSurchargePercentage;
                            PosManager.xGetInstance().bSurchargeByPercent(iSurchargePercentage, out xDiscountSurchargeDataModel);
                            m_xLastCustomForm.bAddSurchargeByPercentLine(xDiscountSurchargeDataModel);
                        }
                        else
                        {
                            CustomMessageBox.Show(LabelTranslations.strGet("DefineDiscountSurchargeValue"));
                        }
                    }
                    else if (iSurchargePercentage > 0 && iSurchargePercentage < 100)
                    {
                        DiscountSurchargeDataModel xDiscountSurchargeDataModel = new DiscountSurchargeDataModel();
                        PosManager.xGetInstance().bSurchargeByPercent(iSurchargePercentage, out xDiscountSurchargeDataModel);
                        m_xLastCustomForm.bAddSurchargeByPercentLine(xDiscountSurchargeDataModel);
                    }
                    else
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vSubTotal(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentStart() == true)
                    return;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (PosManager.xGetInstance().bSubTotal() == true)
                {
                    TransactionDetailDataModel xTransactionDetailDataModel = new TransactionDetailDataModel();
                    xTransactionDetailDataModel.xSubTotalDataModel = new SubTotalDataModel();
                    xTransactionDetailDataModel.xSubTotalDataModel.decSubTotalAmount = prop_xPosManagerData.decReceiptTotalPrice;
                    prop_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel.Add(xTransactionDetailDataModel);
                    m_xLastCustomForm.bAddSubTotal(prop_xPosManagerData.decReceiptTotalPrice, prop_xPosManagerData.xTransactionDataModel);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vTotal(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentStart() == true)
                    return;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                m_xLastCustomForm.bAddTotal(prop_xPosManagerData.decReceiptTotalPrice);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vSaleOption(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentStart() == true)
                    return;

                CustomSaleOption xCustomSaleOption = new CustomSaleOption();
                if (PosManager.xGetInstance().prop_enumDocumentType == EnumDocumentType.Return)
                {
                    return;
                }
                if (xCustomSaleOption.ShowDialog() != DialogResult.Cancel)
                {
                    TransactionDetailDataModel xTransactionDetailDataModel;

                    int iSaleIndex = m_xLastCustomForm.iGetSelectedSale(out xTransactionDetailDataModel);

                    if (xTransactionDetailDataModel.bCanceled)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("NotPossibleForCancelledProduct"));
                        return;
                    }

                    if (xCustomSaleOption.prop_bCancelSale == true)
                    {
                        vCancelSale(prm_objSender, prm_xEventArgs);

                    }
                    else if (xCustomSaleOption.prop_bRepeatSale == true)
                    {
                        vRepeatSale(prm_objSender, prm_xEventArgs);
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public bool bCheckDocumentTypeandGetCustomer()
        {
            bool bControlType = false;
            return bControlType;
            EnumDocumentType enumDocumentType = PosManager.xGetInstance().prop_enumDocumentType;

            if (enumDocumentType != EnumDocumentType.FiscalReceipt && prop_xPosManagerData.decReceiptTotalPayment == 0)
            {
                if (bGetCustomer(false) == false)
                {
                    if (enumDocumentType == EnumDocumentType.Invoice)
                        CustomMessageBox.Show(LabelTranslations.strGet("CancelInvoicePrint"));
                    else if (enumDocumentType == EnumDocumentType.Waybill)
                        CustomMessageBox.Show(LabelTranslations.strGet("CancelWaybillPrint"));
                    else if (enumDocumentType == EnumDocumentType.Return)
                        CustomMessageBox.Show(LabelTranslations.strGet("ReturnNotPrinted"));

                    PosManager.xGetInstance().bCancelReceipt();

                    m_decPriceOfProduct = 0;
                    m_decQuantityOfProduct = 1;
                    vTotalValuesChanges();
                    string strNumPadOutput = m_xLastCustomForm.strGetNumPadOutput();
                    strNumPadOutput = "";
                    bControlType = true;
                }
            }

            if (enumDocumentType == EnumDocumentType.Waybill) bCheckWaybill = true;
            else bCheckWaybill = false;

            return bControlType;
        }

        public void vPayment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bCheckDocumentTypeandGetCustomer() == true)
                    return;

                if (bIsNotReceiptOpen() == true)
                    return;

                if (bIsPaymentAllow() == true)
                    return;

                InputBoxPayment xInputBoxPayment = new InputBoxPayment();
                xInputBoxPayment.ShowDialog();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vCashPayment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bCheckDocumentTypeandGetCustomer() == true)
                    return;

                DeviceManager.xGetInstance().bCustomerDisplayMessage("", "", "TOPLAM: ", string.Format("{0:#,0.00}", prop_xPosManagerData.decReceiptTotalPrice));
                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentAllow() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1 == CustomEventFunctionName.strCashPayment)
                {
                    CustomButton xCustomButton = ((CustomButton)xControl);

                    string strCashAmount = m_xLastCustomForm.strGetNumPadOutput();
                    long decCashAmount = strCashAmount.decConvertToDecimal();

                    //if ((strCashAmount != "" && decCashAmount <= 0) || ((decCashAmount - Math.Truncate(decCashAmount)).ToString().Count() > 4))
                    //{
                    //    CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                    //    return;
                    //}

                    if ((strCashAmount != "" && decCashAmount <= 0))
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                        return;
                    }

                    if (decCashAmount <= 0)
                        decCashAmount = 0;

                    if (((CustomButton)xControl).strName.Length > 4 && xCustomButton.strName.Substring(0, 4).ToUpper() == "CASH")
                    {
                        decCashAmount = Convert.ToInt64(xCustomButton.strName.Substring(4, xCustomButton.strName.Length - 4));
                    }
                    else if (decCashAmount == 0m)
                    {
                        decCashAmount = prop_xPosManagerData.decReceiptTotalPrice - prop_xPosManagerData.decReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        decCashAmount = prop_xPosManagerData.decReceiptTotalPrice;

                    if (PosManager.xGetInstance().bPayment(EnumPaymentType.CASH, decCashAmount) == false)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        return;
                    }

                    vNewPaymentAdded();
                    vTotalValuesChanges();
                    vReceiptClosed();
                    vTotalValuesChanges();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vCreditPayment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bCheckDocumentTypeandGetCustomer() == true)
                    return;

                DeviceManager.xGetInstance().bCustomerDisplayMessage("", "", "TOPLAM: ", string.Format("{0:#,0.00}", prop_xPosManagerData.decReceiptTotalPrice));
                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentAllow() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1 == CustomEventFunctionName.strCreditPayment)
                {
                    CustomButton xCustomButton = ((CustomButton)xControl);

                    string strCreditAmount = m_xLastCustomForm.strGetNumPadOutput();
                    long decCreditAmount = strCreditAmount.decConvertToDecimal();

                    if ((strCreditAmount != "" && decCreditAmount <= 0))// || ((decCreditAmount - Math.Truncate(decCreditAmount)).ToString().Count() > 4)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                        return;
                    }

                    if (decCreditAmount <= 0)
                        decCreditAmount = 0;

                    if (((CustomButton)xControl).strName.Length > 6 && xCustomButton.strName.Substring(0, 6).ToUpper() == "CREDIT")
                    {
                        decCreditAmount = Convert.ToInt64(xCustomButton.strName.Substring(6, xCustomButton.strName.Length - 6));
                    }
                    else if (decCreditAmount == 0m)
                    {
                        decCreditAmount = prop_xPosManagerData.decReceiptTotalPrice - prop_xPosManagerData.decReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        decCreditAmount = prop_xPosManagerData.decReceiptTotalPrice;

                    if (PosManager.xGetInstance().bPayment(EnumPaymentType.CREDIT_CARD, decCreditAmount) == false)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        return;
                    }

                    vNewPaymentAdded();
                    vTotalValuesChanges();
                    vReceiptClosed();
                    vTotalValuesChanges();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vCheckPayment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bCheckDocumentTypeandGetCustomer() == true)
                    return;
                DeviceManager.xGetInstance().bCustomerDisplayMessage("", "", "TOPLAM: ", string.Format("{0:#,0.00}", prop_xPosManagerData.decReceiptTotalPrice));
                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentAllow() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1 == "CHECK")
                {
                    string strCheckAmount = m_xLastCustomForm.strGetNumPadOutput();
                    long decCheckAmount = strCheckAmount.decConvertToDecimal();

                    if ((strCheckAmount != "" && decCheckAmount <= 0))// || ((decCheckAmount - Math.Truncate(decCheckAmount)).ToString().Count() > 4)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                        return;
                    }

                    if (decCheckAmount <= 0)
                        decCheckAmount = 0;

                    if (((CustomButton)xControl).strName.Length > 5 && ((CustomButton)xControl).strName.Substring(0, 5).ToUpper() == "CHECK")
                    {
                        decCheckAmount = long.Parse(((CustomButton)xControl).strName.Substring(5, ((CustomButton)xControl).strName.Length - 5)).decConvertToDecimal();
                    }
                    else if (decCheckAmount == 0m && ((CustomButton)xControl).strFunction1.ToUpper() == "CHECK")
                    {
                        decCheckAmount = prop_xPosManagerData.decReceiptTotalPrice - prop_xPosManagerData.decReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        decCheckAmount = prop_xPosManagerData.decReceiptTotalPrice;

                    PosManager.xGetInstance().bPayment(EnumPaymentType.CHECK, decCheckAmount);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vPrepaidPayment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bCheckDocumentTypeandGetCustomer() == true)
                    return;

                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentAllow() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1 == "PREPAID")
                {
                    string strPrepaidAmount = m_xLastCustomForm.strGetNumPadOutput();
                    long decPrepaidAmount = strPrepaidAmount.decConvertToDecimal();

                    if ((strPrepaidAmount != "" && decPrepaidAmount <= 0))// || ((decPrepaidAmount - Math.Truncate(decPrepaidAmount)).ToString().Count() > 4)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                        return;
                    }

                    if (decPrepaidAmount <= 0)
                        decPrepaidAmount = 0;

                    if (((CustomButton)xControl).strName.Length > 7 && ((CustomButton)xControl).strName.Substring(0, 7).ToUpper() == "PREPAID")
                    {
                        decPrepaidAmount = long.Parse(((CustomButton)xControl).strName.Substring(13, ((CustomButton)xControl).strName.Length - 13)).decConvertToDecimal();
                    }
                    else if (decPrepaidAmount == 0m && ((CustomButton)xControl).strFunction1.ToUpper() == "PREPAID")
                    {
                        decPrepaidAmount = prop_xPosManagerData.decReceiptTotalPrice - prop_xPosManagerData.decReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        decPrepaidAmount = prop_xPosManagerData.decReceiptTotalPrice;

                    if (PosManager.xGetInstance().bPayment(EnumPaymentType.PREPAID_CARD, decPrepaidAmount) == false)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        return;
                    }

                    vNewPaymentAdded();
                    vTotalValuesChanges();
                    vReceiptClosed();
                    vTotalValuesChanges();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vChargeSalePayment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bCheckDocumentTypeandGetCustomer() == true)
                    return;

                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentAllow() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1 == CustomEventFunctionName.strOtherPayment)
                {
                    CustomButton xCustomButton = (CustomButton)xControl;

                    string strChargeSaleAmount = m_xLastCustomForm.strGetNumPadOutput();
                    long decChargeSaleAmount = strChargeSaleAmount.decConvertToDecimal();

                    if ((strChargeSaleAmount != "" && decChargeSaleAmount <= 0))// || ((decChargeSaleAmount - Math.Truncate(decChargeSaleAmount)).ToString().Count() > 4)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                        return;
                    }

                    if (decChargeSaleAmount <= 0)
                        decChargeSaleAmount = 0;

                    if (decChargeSaleAmount == 0)
                    {
                        decChargeSaleAmount = prop_xPosManagerData.decReceiptTotalPrice - prop_xPosManagerData.decReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        decChargeSaleAmount = prop_xPosManagerData.decReceiptTotalPrice;

                    if (PosManager.xGetInstance().bPayment(EnumPaymentType.ON_CREDIT, decChargeSaleAmount) == false)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        return;
                    }

                    vNewPaymentAdded();
                    vTotalValuesChanges();
                    vReceiptClosed();
                    vTotalValuesChanges();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vOtherPayment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bCheckDocumentTypeandGetCustomer() == true)
                    return;

                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentAllow() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1 == CustomEventFunctionName.strOtherPayment)
                {
                    CustomButton xCustomButton = (CustomButton)xControl;

                    string strOtherAmount = m_xLastCustomForm.strGetNumPadOutput();
                    long decOtherAmount = strOtherAmount.decConvertToDecimal();

                    if ((strOtherAmount != "" && decOtherAmount <= 0))// || ((decOtherAmount - Math.Truncate(decOtherAmount)).ToString().Count() > 4)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                        return;
                    }

                    if (decOtherAmount <= 0)
                        decOtherAmount = 0;

                    if (xCustomButton.strName.Length > 5 && xCustomButton.strName.Substring(0, 5).ToUpper() == "OTHER")
                    {
                        decOtherAmount = Convert.ToInt64(xCustomButton.strName.Substring(5, xCustomButton.strName.Length - 5));
                    }
                    else if (decOtherAmount == 0m)
                    {
                        decOtherAmount = prop_xPosManagerData.decReceiptTotalPrice - prop_xPosManagerData.decReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        decOtherAmount = prop_xPosManagerData.decReceiptTotalPrice;

                    if (PosManager.xGetInstance().bPayment(EnumPaymentType.OTHER, decOtherAmount) == false)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        return;
                    }

                    vNewPaymentAdded();
                    vTotalValuesChanges();
                    vReceiptClosed();
                    vTotalValuesChanges();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vExchangePayment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            if (bCheckDocumentTypeandGetCustomer() == true)
                return;
            DeviceManager.xGetInstance().bCustomerDisplayMessage("", "", "TOPLAM: ", string.Format("{0:#,0.00}", prop_xPosManagerData.decReceiptTotalPrice));
            //if (bIsNotReceiptOpen() == true)
            //  return;
            //if (bIsPaymentAllow() == true)
            //  return;

            Control xControl = (Control)prm_objSender;

            m_xLastCustomForm = xControl.xFindCustomForm();
            m_xLastCustomForm.bFocusNumPad();

            if (xControl is CustomButton && ((CustomButton)xControl).strFunction1 == "EXCHANGE")
            {
                string strExchangeAmount = m_xLastCustomForm.strGetNumPadOutput();
                long decExchangeAmount = strExchangeAmount.decConvertToDecimal();

                if ((strExchangeAmount != "" && decExchangeAmount <= 0))// || ((decExchangeAmount - Math.Truncate(decExchangeAmount)).ToString().Count() > 4)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                    return;
                }

                if (decExchangeAmount <= 0)
                    decExchangeAmount = 0;

                if (((CustomButton)xControl).strName.Length > 8 && ((CustomButton)xControl).strName.Substring(0, 8).ToUpper() == "EXCHANGE")
                {
                    decExchangeAmount = long.Parse(((CustomButton)xControl).strName.Substring(5, ((CustomButton)xControl).strName.Length - 8)).decConvertToDecimal();
                }
                else if (decExchangeAmount == 0m && ((CustomButton)xControl).strFunction1.ToUpper() == "EXCHANGE")
                {
                    decExchangeAmount = prop_xPosManagerData.decReceiptTotalPrice - prop_xPosManagerData.decReceiptTotalPayment;
                }
                if (bCheckWaybill == true)
                    decExchangeAmount = prop_xPosManagerData.decReceiptTotalPrice;

                PosManager.xGetInstance().bPayment(EnumPaymentType.EXCHANGE, decExchangeAmount);

            }
        }

        public void vSuspendPayment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsNotReceiptOpen() == true)
                    return;
                if (bIsPaymentStart() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strName.ToUpper() == CustomEventFunctionName.strSuspendPayment)
                {
                    if (PosManager.xGetInstance().bSuspendReceipt() == true)
                    {
                        m_decPriceOfProduct = 0;
                        m_decQuantityOfProduct = 1;

                        vReceiptClosed(true);
                        vTotalValuesChanges();

                        DeviceManager.xGetInstance().bCustomerDisplayMessage(LabelTranslations.strGet("DocumentSuspended"), "");
                        m_xLastCustomForm.xCustomCustomerForm.bShowMessage(LabelTranslations.strGet("DocumentSuspended"));
                    }
                    else
                    {
                        if (PosManager.xGetInstance().prop_enumErrorCode == EnumErrorCode.SUSPEND_QUEUE_FULL)
                        {
                            CustomMessageBox.Show(LabelTranslations.strGet("SuspendQueueFull"));
                        }
                        else
                        {
                            CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        }
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vBackPayment(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //if (bIsNotReceiptOpen() == true)
                //    return;
                if (bIsPaymentStart() == true)
                    return;

                if (bIsSuspendedReceipt() == true)
                    return;

                if (PosManager.xGetInstance().bBacktoReceipt())
                {
                    //son veriyi yukarıda eşitledik sadece alt tarafları değiştirmek için burası var.

                    vTotalValuesChanges();
                    vSuspendedTransactionAdded();
                }
                else
                {
                    if (PosManager.xGetInstance().prop_enumErrorCode == EnumErrorCode.NEED_SUSPEND)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("SuspendNeeded"));
                    }
                    else if (PosManager.xGetInstance().prop_enumErrorCode == EnumErrorCode.SUSPEND_NOT_FOUND)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("SuspendDocumentIsNotFound"));
                    }
                    else
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }
    

    }
}
