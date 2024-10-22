using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Constanst;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;

namespace SaleFlex.UserInterface.Manager
{
    public class CustomEventHandler : Events
    {
        public CustomEventHandler()
        {
        }

        // This method is responsible for distributing event handlers based on the function name provided.
        // It is used to dynamically assign event handlers to form controls during runtime, as the forms
        // and controls are created dynamically.
        public EventHandler xEventDistributor(string prm_strFunctionName)
        {
            try
            {
                // Create a Dictionary to store event handlers
                var xdicEventHandler = new Dictionary<string, EventHandler>
                {
                    { CustomEventFunctionName.strNone, new EventHandler(vNoneFunction) },
                    { CustomEventFunctionName.strExitApplication, new EventHandler(vExitApplication) },
                    { CustomEventFunctionName.strLogin, new EventHandler(vLoginSystem) },
                    { CustomEventFunctionName.strLoginExtended, new EventHandler(vLoginSystem) },
                    { CustomEventFunctionName.strLogout, new EventHandler(vLogoutSystem) },
                    { CustomEventFunctionName.strServiceCodeRequest, new EventHandler(vServiceCodeRequest) },
                    { CustomEventFunctionName.strLoginService, new EventHandler(vNotDefinedFunction) },
                    { CustomEventFunctionName.strCloseForm, new EventHandler(vCloseForm) },
                    { CustomEventFunctionName.strSaveChanges, new EventHandler(vSaveChanges) },
                    { CustomEventFunctionName.strSaleDepartment, new EventHandler(vSaleDepartment) },
                    { CustomEventFunctionName.strSaleDepartmentByNo, new EventHandler(vSaleDepartmentByNo) },
                    { CustomEventFunctionName.strSalePluCode, new EventHandler(vSalePluCode) },
                    { CustomEventFunctionName.strSalePluBarcode, new EventHandler(vSalePluBarcode) },
                    { CustomEventFunctionName.strGetPluFromMainGroup, new EventHandler(vGetPluFromMainGroup) },
                    { CustomEventFunctionName.strRepeatLastSale, new EventHandler(vRepeatLastSale) },
                    { CustomEventFunctionName.strRepeatSale, new EventHandler(vRepeatSale) },
                    { CustomEventFunctionName.strCancelDepartment, new EventHandler(vCancelDepartment) },
                    { CustomEventFunctionName.strCancelPlu, new EventHandler(vCancelPlu) },
                    { CustomEventFunctionName.strCancelLastSale, new EventHandler(vCancelLastSale) },
                    { CustomEventFunctionName.strCancelSale, new EventHandler(vCancelSale) },
                    { CustomEventFunctionName.strOpenCashDrawer, new EventHandler(vOpenCashDrawer) },
                    { CustomEventFunctionName.strFunctionMenu, new EventHandler(vFunctionMenu) },
                    { CustomEventFunctionName.strSaleMenu, new EventHandler(vSaleMenu) },
                    { CustomEventFunctionName.strServiceMenu, new EventHandler(vServiceMenu) },
                    { CustomEventFunctionName.strSettingMenu, new EventHandler(vSettingMenu) },
                    { CustomEventFunctionName.strReportMenu, new EventHandler(vReportMenu) },
                    { CustomEventFunctionName.strCashier, new EventHandler(vCashier) },
                    { CustomEventFunctionName.strChangeDocumentType, new EventHandler(vChangeDocumentType) },
                    { CustomEventFunctionName.strCustomer, new EventHandler(vCustomer) },
                    { CustomEventFunctionName.strRefund, new EventHandler(vRefund) },
                    { CustomEventFunctionName.strDiscountByAmount, new EventHandler(vDiscountByAmount) },
                    { CustomEventFunctionName.strSurchargeByAmount, new EventHandler(vSurchargeByAmount) },
                    { CustomEventFunctionName.strDiscountByPercent, new EventHandler(vDiscountByPercent) },
                    { CustomEventFunctionName.strSurchargeByPercent, new EventHandler(vSurchargeByPercent) },
                    { CustomEventFunctionName.strInputPrice, new EventHandler(vInputPrice) },
                    { CustomEventFunctionName.strInputQuantity, new EventHandler(vInputQuantity) },
                    { CustomEventFunctionName.strInputAmount, new EventHandler(vInputAmount) },
                    { CustomEventFunctionName.strPriceLookUp, new EventHandler(vPriceLookUp) },
                    { CustomEventFunctionName.strSubTotal, new EventHandler(vSubTotal) },
                    { CustomEventFunctionName.strTotal, new EventHandler(vTotal) },
                    { CustomEventFunctionName.strSaleOption, new EventHandler(vSaleOption) },
                    { CustomEventFunctionName.strPayment, new EventHandler(vPayment) },
                    { CustomEventFunctionName.strCashPayment, new EventHandler(vCashPayment) },
                    { CustomEventFunctionName.strCreditPayment, new EventHandler(vCreditPayment) },
                    { CustomEventFunctionName.strCheckPayment, new EventHandler(vCheckPayment) },
                    { CustomEventFunctionName.strExchangePayment, new EventHandler(vExchangePayment) },
                    { CustomEventFunctionName.strPrepaidPayment, new EventHandler(vPrepaidPayment) },
                    { CustomEventFunctionName.strChargeSalePayment, new EventHandler(vChargeSalePayment) },
                    { CustomEventFunctionName.strOtherPayment, new EventHandler(vOtherPayment) },
                    { CustomEventFunctionName.strPaymentDetail, new EventHandler(vPaymentDetail) },
                    { CustomEventFunctionName.strClosure, new EventHandler(vClosure) },
                    { CustomEventFunctionName.strCancelDocument, new EventHandler(vCancelDocument) },
                    { CustomEventFunctionName.strStockEntryForm, new EventHandler(vStockEntryForm) },
                    { CustomEventFunctionName.strSaleDetailReport, new EventHandler(vSaleDetailReport) },
                    { CustomEventFunctionName.strPluSaleReport, new EventHandler(vPluSaleReport) },
                    { CustomEventFunctionName.strPosSummaryReport, new EventHandler(vPosSummaryReport) },
                    { CustomEventFunctionName.strSetDisplayBrightness, new EventHandler(vSetDisplayBrightness) },
                    { CustomEventFunctionName.strSetPrinterIntensity, new EventHandler(vSetPrinterIntensity) },
                    { CustomEventFunctionName.strSetCashier, new EventHandler(vSetCashier) },
                    { CustomEventFunctionName.strSetSupervisor, new EventHandler(vSetSupervisor) },
                    { CustomEventFunctionName.strSetReceiptHeader, new EventHandler(vSetReceiptHeader) },
                    { CustomEventFunctionName.strSetReceiptFooter, new EventHandler(vSetReceiptFooter) },
                    { CustomEventFunctionName.strSetIdleMessage, new EventHandler(vSetIdleMessage) },
                    { CustomEventFunctionName.strSetBarcodeDefinition, new EventHandler(vSetBarcodeDefinition) },
                    { CustomEventFunctionName.strSetVatDefinition, new EventHandler(vSetVatDefinition) },
                    { CustomEventFunctionName.strSetDepartmentDefinition, new EventHandler(vSetDepartmentDefinition) },
                    { CustomEventFunctionName.strSetCurrencyDefinition, new EventHandler(vSetCurrencyDefinition) },
                    { CustomEventFunctionName.strSetPluDefinition, new EventHandler(vSetPluDefinition) },
                    { CustomEventFunctionName.strSetPluMainGroupDefinition, new EventHandler(vSetPluMainGroupDefinition) },
                    { CustomEventFunctionName.strSetDiscountRate, new EventHandler(vSetDiscountRate) },
                    { CustomEventFunctionName.strSetSurchargeRate, new EventHandler(vSetSurchargeRate) },
                    { CustomEventFunctionName.strServiceCompanyInfo, new EventHandler(vServiceCompanyInfo) },
                    { CustomEventFunctionName.strServiceChangeDateTime, new EventHandler(vServiceChangeDateTime) },
                    { CustomEventFunctionName.strServiceParameterDownload, new EventHandler(vServiceParameterDownload) },
                    { CustomEventFunctionName.strServiceSetReceiptLimit, new EventHandler(vServiceSetReceiptLimit) },
                    { CustomEventFunctionName.strServiceResetToFactoryMode, new EventHandler(vServiceResetToFactoryMode) },
                    { CustomEventFunctionName.strServiceResetPassword, new EventHandler(vServiceResetPassword) },
                    { CustomEventFunctionName.strServiceChangePassword, new EventHandler(vServiceChangePassword) },
                    { CustomEventFunctionName.strServicePosActive, new EventHandler(vServicePosActive) },
                    { CustomEventFunctionName.strServiceSoftwareDownload, new EventHandler(vServiceSoftwareDownload) },
                    { CustomEventFunctionName.strInvoiceList, new EventHandler(vInvoiceList) },
                    { CustomEventFunctionName.strWaybillList, new EventHandler(vWaybillList) },
                    { CustomEventFunctionName.strReturnList, new EventHandler(vReturnList) },
                    { CustomEventFunctionName.strStockLookUp, new EventHandler(vStockLookUp) },
                    { CustomEventFunctionName.strSuspendPayment, new EventHandler(vSuspendPayment) },
                    { CustomEventFunctionName.strBackPayment, new EventHandler(vBackPayment) },
                    { CustomEventFunctionName.strSaleShortcut, new EventHandler(vShortcutMenu) }
                };

                //if( prm_strFunctionName==PredefinedFunctionNames.strFunctionNames[FunctionNames.Login])
                //{
                //     return new System.EventHandler(vLoginSystem);
                //}

                // Try to find the event handler and return it
                if (xdicEventHandler.TryGetValue(prm_strFunctionName, out EventHandler xEventHandler))
                {
                    return xEventHandler;
                }

                // Return the default handler if no matching event handler is found
                return new EventHandler(vNotDefinedFunction);
            }
            catch
            {
                // Return null in case of any error during event handler assignment
                return null;
            }
        }

        int iKeyPressed = 0;
        string strKeyValue = string.Empty;

        protected void vExternalKeyboardEvent(object prm_objObject, KeyPressEventArgs prm_xKeyEventArgs)
        {
            try
            {
                if (iKeyPressed < 3 && iKeyPressed != 2)
                {
                    strKeyValue = string.Format("{0}{1}", strKeyValue, prm_xKeyEventArgs.KeyChar.ToString());
                    iKeyPressed++;
                }
                if (iKeyPressed == 2)
                {
                    strKeyValue = strKeyValue.ToUpper();
                    string strFormControlFunctionName = string.Empty;
                    string strFormControlName = string.Empty;

                    KeyboardTypeFirstDataModel xKeyboardTypeFirstDataModel = new KeyboardTypeFirstDataModel();
                    List<KeyboardTypeFirstDataModel> xListKeyboardTypeFirstDataModel = Dao.xGetInstance().xListGetKeyboardTypeFirst();
                    xKeyboardTypeFirstDataModel = xListKeyboardTypeFirstDataModel.Where(x => x.strKeyboardValue == strKeyValue).FirstOrDefault();


                    if (xKeyboardTypeFirstDataModel.strCategory == "DEPARTMENT")
                    {
                        DepartmentDataModel xDepartmentDataModel = new DepartmentDataModel();
                        List<DepartmentDataModel> xListDepartmentDataModel = Dao.xGetInstance().xListGetDepartments();
                        xDepartmentDataModel = xListDepartmentDataModel.Where(x => x.strName == xKeyboardTypeFirstDataModel.strDefinedButtonText).FirstOrDefault();
                        strFormControlFunctionName = "DEPARTMENT_SALE";
                        strFormControlName = string.Format("{0}{1}", "DEPARTMENT", xDepartmentDataModel.iNo.ToString());

                        EventHandler xRelatedEvent = xEventDistributor(strFormControlFunctionName);

                        FormControlDataModel xFormControlDataModel = new FormControlDataModel(strFormControlName, "UPPER", "LEFT", "ALPHANUMERIC");
                        Control xControl = new Control(strFormControlName);
                        CustomButton xButton = new CustomButton(xFormControlDataModel);
                        xButton.Visible = false;
                        xLastCustomForm.bAddControl(xButton, xFormControlDataModel);

                        xRelatedEvent.Invoke(xButton, new EventArgs());
                    }

                    else if (xKeyboardTypeFirstDataModel.strCategory == "PLU")
                    {
                        PluDataModel xPluDataModel = new PluDataModel();
                        List<PluDataModel> xListPluDataModel = Dao.xGetInstance().xListGetPlu();
                        xPluDataModel = xListPluDataModel.Where(x => x.strName == xKeyboardTypeFirstDataModel.strDefinedButtonText).FirstOrDefault();
                        strFormControlFunctionName = "PLU_INDEX_SALE";
                        strFormControlName = string.Format("{0}{1}", "PLU", xPluDataModel.strCode.TrimStart('0'));

                        EventHandler xRelatedEvent = xEventDistributor(strFormControlFunctionName);

                        FormControlDataModel xFormControlsDataModel = new FormControlDataModel(strFormControlName, "UPPER", "LEFT", "ALPHANUMERIC");
                        Control xControl = new Control(strFormControlName);
                        CustomButton xButton = new CustomButton(xFormControlsDataModel);
                        xButton.Visible = false;
                        xLastCustomForm.bAddControl(xButton, xFormControlsDataModel);

                        xRelatedEvent.Invoke(xButton, new EventArgs());
                    }

                    else if (xKeyboardTypeFirstDataModel.strCategory == "FUNCTION")
                    {
                        List<FormControlDataModel> xListFormControlDataModel = Dao.xGetInstance().xGetKeyFunction(strKeyValue);
                        strFormControlFunctionName = xListFormControlDataModel[0].xFormControlFunction1.strName;

                        EventHandler xRelatedEvent = xEventDistributor(strFormControlFunctionName);

                        foreach (Control xFormControl in xLastCustomForm.Controls)
                        {
                            if (xFormControl.GetType() == typeof(CustomButton))
                            {
                                CustomButton xButton = (CustomButton)xFormControl;
                                if (xButton.strName == xListFormControlDataModel[0].strName)
                                {
                                    xRelatedEvent.Invoke(xFormControl, new EventArgs());
                                }
                            }
                        }

                    }

                    else if (xKeyboardTypeFirstDataModel.strCategory == "OTHER")
                    {
                        string strAsciiCode = strFindKeyboardValueForOtherPage(xKeyboardTypeFirstDataModel.strDefinedButtonText);

                        iKeyPressed = 0;
                        strKeyValue = string.Empty;

                        KeyEventHandler xRelatedKeyEventHandler = new KeyEventHandler(vExternalKeyEventHandler);

                        xRelatedKeyEventHandler.Invoke(strAsciiCode, new KeyEventArgs((Keys)Enum.Parse(typeof(Keys), strAsciiCode)));
                    }

                    strFormControlName = string.Empty;
                    strFormControlFunctionName = string.Empty;
                    iKeyPressed = 0;
                    strKeyValue = string.Empty;

                }
            }

            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }

        public override bool bReDrawFormControls()
        {
            return base.bReDrawFormControls();
        }

        public string strFindKeyboardValueForOtherPage(string prm_strFunction)
        {
            string strKeyboardValue = string.Empty;

            switch (prm_strFunction)
            {
                case "UP":
                    strKeyboardValue = "38";
                    break;
                case "DOWN":
                    strKeyboardValue = "40";
                    break;
                case "LEFT":
                    strKeyboardValue = "37";
                    break;
                case "RIGHT":
                    strKeyboardValue = "39";
                    break;
                case "TAB":
                    strKeyboardValue = "9";
                    break;
                case "SPACE":
                    strKeyboardValue = "32";
                    break;
                case "BACKSPACE":
                    strKeyboardValue = "8";
                    break;
                case "ESC":
                    strKeyboardValue = "27";
                    break;
            }
            return strKeyboardValue;
        }

        protected void vExternalKeyEventHandler(object prm_objObject, KeyEventArgs prm_xKeyEventArgs)
        {
        }
    }
}
