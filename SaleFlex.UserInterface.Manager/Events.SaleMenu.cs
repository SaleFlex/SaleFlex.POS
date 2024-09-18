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
                    CustomMessageBox.Show(LabelTranslations.strGet("PaymentIsStarted"));
                    return;
                }

                Control xControl = (Control)prm_objSender;
                m_xLastCustomForm = xControl.xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                string strNumPadOutput = m_xLastCustomForm.strGetNumPadOutput();

                if (m_lPriceOfProduct == 0 && strNumPadOutput != string.Empty && strNumPadOutput.Length > 0 && xControl is CustomButton && ((CustomButton)xControl).strName.Substring(0, 10).ToUpper() == "DEPARTMENT")
                {
                    try
                    {
                        m_lPriceOfProduct = strNumPadOutput.lConvertQuantityOfProduct(); // If the price entered in the numpad is convertible, assign its converted value to the class variable.
                    }
                    catch
                    {
                        // If the price entered in the numpad is not convertible, leave the value of the class variable as is (zero).
                    }
                }

                if (xControl is CustomButton)
                {
                    CustomButton xCustomButton = (CustomButton)prm_objSender;
                    if (xCustomButton.strName.Length > 10 && xCustomButton.strName.Substring(0, 10).ToUpper() == "DEPARTMENT")
                    {
                        int iDepartmentNo = int.Parse(xCustomButton.strName.Substring(10, xCustomButton.strName.Length - 10));

                        long decPrice = m_lPriceOfProduct;
                        long decQuantity = m_decQuantityOfProduct;
                        m_lPriceOfProduct = 0;
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
                        long decPrice = m_lPriceOfProduct.bOverflowAmountCheck() == true ? xDepartmentDataModel.lDefaultPrice : m_lPriceOfProduct;
                        if (PosManager.xGetInstance().bSaleDepartment(iDepartmentNo, decPrice, m_decQuantityOfProduct) == false)
                        {
                        }

                        m_lPriceOfProduct = 0;
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

                if (m_lPriceOfProduct == 0 && strNumPadOutput != string.Empty && strNumPadOutput.Length > 0 && xControl is CustomButton && ((CustomButton)xControl).strName.Substring(0, 3).ToUpper() == "PLU")
                {
                    try
                    {
                        m_decQuantityOfProduct = strNumPadOutput.lConvertQuantityOfProduct(); // If the price entered in the numpad is convertible, assign its converted value to the class variable.
                    }
                    catch
                    {
                        // If the price entered in the numpad is not convertible, leave the value of the class variable as is (zero).
                    }
                }

                if (xControl is CustomButton)
                {
                    CustomButton xCustomButton = (CustomButton)prm_objSender;
                    if (xCustomButton.strName.Length > 3 && xCustomButton.strName.Substring(0, 3).ToUpper() == "PLU")
                    {
                        string strPluCode = xCustomButton.strName.Substring(3, xCustomButton.strName.Length - 3);

                        long decPrice = m_lPriceOfProduct;
                        long decQuantity = m_decQuantityOfProduct;
                        m_lPriceOfProduct = 0;
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

                if (m_lPriceOfProduct == 0 && strNumPadOutput != string.Empty && strNumPadOutput.Length > 0 && xControl is CustomButton && ((CustomButton)xControl).strName.Substring(0, 3).ToUpper() == "PLU")
                {
                    try
                    {
                        m_decQuantityOfProduct = strNumPadOutput.lConvertQuantityOfProduct(); // If the price entered in the numpad is convertible, assign its converted value to the class variable.
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
                    long decPrice = m_lPriceOfProduct;
                    long decQuantity = m_decQuantityOfProduct;
                    
                    m_lPriceOfProduct = 0;
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
                        PosManager.xGetInstance().bSaleDepartment(xTransactionDetailDataModel.xDepartmentDataModel.iNo, xTransactionDetailDataModel.lPrice, xTransactionDetailDataModel.lQuantity);
                    }
                    else if (xTransactionDetailDataModel.xPluDataModel != null)
                    {
                        long QuantityControl = xTransactionDetailDataModel.xPluDataModel.StockUnitNo == 1 ? xTransactionDetailDataModel.lQuantity : xTransactionDetailDataModel.lQuantity*1000;

                        PosManager.xGetInstance().bSalePluByCode(xTransactionDetailDataModel.xPluDataModel.strCode, xTransactionDetailDataModel.lPrice, QuantityControl);
                    }

                }

                m_lPriceOfProduct = 0;
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
                            PosManager.xGetInstance().bSaleDepartment(xTransactionDetailDataModel.xDepartmentDataModel.iNo, xTransactionDetailDataModel.lPrice, xTransactionDetailDataModel.lQuantity);
                        }
                        else if (xTransactionDetailDataModel.xPluDataModel != null)
                        {
                            PosManager.xGetInstance().bSalePluByCode(xTransactionDetailDataModel.xPluDataModel.strCode, xTransactionDetailDataModel.xPluDataModel.xListPluBarcodeDataModel[0].decSalePrice, xTransactionDetailDataModel.lQuantity);
                        }

                    }

                    m_lPriceOfProduct = 0;
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
                                ((CustomAmountsTable)xController).decReceiptTotalPrice -= xTransactionDetailDataModel.lTotalPrice;
                                ((CustomAmountsTable)xController).decReceiptTotalPayment -= xTransactionDetailDataModel.lTotalPriceWithoutVat;

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
                            m_lPriceOfProduct = 0;
                            m_decQuantityOfProduct = 1;

                            vReceiptClosed(prop_xPosManagerData.lReceiptTotalPrice, prop_xPosManagerData.lReceiptTotalPayment, prop_xPosManagerData.xTransactionDataModel.xListPaymentDataModel, true);
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

                        if (prop_xPosManagerData.lReceiptTotalPrice > decDiscountAmount && decDiscountAmount.bOverflowAmountCheck() == false)
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

                        if (prop_xPosManagerData.lReceiptTotalPrice > decSurchargeAmount)
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
                    xTransactionDetailDataModel.xSubTotalDataModel.decSubTotalAmount = prop_xPosManagerData.lReceiptTotalPrice;
                    prop_xPosManagerData.xTransactionDataModel.xListTransactionDetailDataModel.Add(xTransactionDetailDataModel);
                    m_xLastCustomForm.bAddSubTotal(prop_xPosManagerData.lReceiptTotalPrice, prop_xPosManagerData.xTransactionDataModel);
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

                m_xLastCustomForm.bAddTotal(prop_xPosManagerData.lReceiptTotalPrice);
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

            if (enumDocumentType != EnumDocumentType.FiscalReceipt && prop_xPosManagerData.lReceiptTotalPayment == 0)
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

                    m_lPriceOfProduct = 0;
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
    }
}
