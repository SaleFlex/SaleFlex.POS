using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.POS.Device.Manager;
using SaleFlex.POS.Manager;
using SaleFlex.UserInterface.BoxForm;
using SaleFlex.UserInterface.Constanst;
using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleFlex.UserInterface.Manager
{
    public partial class Events
    {

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

                DeviceManager.xGetInstance().bCustomerDisplayMessage("", "", "TOPLAM: ", string.Format("{0:#,0.00}", prop_xPosManagerData.lReceiptTotalPrice));
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
                    long lCashAmount = strCashAmount.decConvertToDecimal();

                    //if ((strCashAmount != "" && decCashAmount <= 0) || ((decCashAmount - Math.Truncate(decCashAmount)).ToString().Count() > 4))
                    //{
                    //    CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                    //    return;
                    //}

                    if ((strCashAmount != "" && lCashAmount <= 0))
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("NotPossible"));
                        return;
                    }

                    if (lCashAmount <= 0)
                        lCashAmount = 0;

                    if (((CustomButton)xControl).strName.Length > 4 && xCustomButton.strName.Substring(0, 4).ToUpper() == "CASH")
                    {
                        lCashAmount = Convert.ToInt64(xCustomButton.strName.Substring(4, xCustomButton.strName.Length - 4));
                    }
                    else if (lCashAmount == 0m)
                    {
                        lCashAmount = prop_xPosManagerData.lReceiptTotalPrice - prop_xPosManagerData.lReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        lCashAmount = prop_xPosManagerData.lReceiptTotalPrice;

                    if (PosManager.xGetInstance().bPayment(EnumPaymentType.CASH, lCashAmount) == false)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        return;
                    }

                    vNewPaymentAdded();
                    vTotalValuesChanges();
                    PosManager.xGetInstance().bClearTransaction(true);
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

                DeviceManager.xGetInstance().bCustomerDisplayMessage("", "", "TOPLAM: ", string.Format("{0:#,0.00}", prop_xPosManagerData.lReceiptTotalPrice));
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
                        decCreditAmount = prop_xPosManagerData.lReceiptTotalPrice - prop_xPosManagerData.lReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        decCreditAmount = prop_xPosManagerData.lReceiptTotalPrice;

                    if (PosManager.xGetInstance().bPayment(EnumPaymentType.CREDIT_CARD, decCreditAmount) == false)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        return;
                    }

                    vNewPaymentAdded();
                    vTotalValuesChanges();
                    PosManager.xGetInstance().bClearTransaction(true);
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
                DeviceManager.xGetInstance().bCustomerDisplayMessage("", "", "TOPLAM: ", string.Format("{0:#,0.00}", prop_xPosManagerData.lReceiptTotalPrice));
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
                        decCheckAmount = prop_xPosManagerData.lReceiptTotalPrice - prop_xPosManagerData.lReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        decCheckAmount = prop_xPosManagerData.lReceiptTotalPrice;

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
                        decPrepaidAmount = prop_xPosManagerData.lReceiptTotalPrice - prop_xPosManagerData.lReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        decPrepaidAmount = prop_xPosManagerData.lReceiptTotalPrice;

                    if (PosManager.xGetInstance().bPayment(EnumPaymentType.PREPAID_CARD, decPrepaidAmount) == false)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        return;
                    }

                    vNewPaymentAdded();
                    vTotalValuesChanges();
                    PosManager.xGetInstance().bClearTransaction(true);
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
                        decChargeSaleAmount = prop_xPosManagerData.lReceiptTotalPrice - prop_xPosManagerData.lReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        decChargeSaleAmount = prop_xPosManagerData.lReceiptTotalPrice;

                    if (PosManager.xGetInstance().bPayment(EnumPaymentType.ON_CREDIT, decChargeSaleAmount) == false)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        return;
                    }

                    vNewPaymentAdded();
                    vTotalValuesChanges();
                    PosManager.xGetInstance().bClearTransaction(true);
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
                        decOtherAmount = prop_xPosManagerData.lReceiptTotalPrice - prop_xPosManagerData.lReceiptTotalPayment;
                    }

                    if (bCheckWaybill == true)
                        decOtherAmount = prop_xPosManagerData.lReceiptTotalPrice;

                    if (PosManager.xGetInstance().bPayment(EnumPaymentType.OTHER, decOtherAmount) == false)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                        return;
                    }

                    vNewPaymentAdded();
                    vTotalValuesChanges();
                    PosManager.xGetInstance().bClearTransaction(true);
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
            DeviceManager.xGetInstance().bCustomerDisplayMessage("", "", "TOPLAM: ", string.Format("{0:#,0.00}", prop_xPosManagerData.lReceiptTotalPrice));
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
                    decExchangeAmount = prop_xPosManagerData.lReceiptTotalPrice - prop_xPosManagerData.lReceiptTotalPayment;
                }
                if (bCheckWaybill == true)
                    decExchangeAmount = prop_xPosManagerData.lReceiptTotalPrice;

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
                        m_lPriceOfProduct = 0;
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
