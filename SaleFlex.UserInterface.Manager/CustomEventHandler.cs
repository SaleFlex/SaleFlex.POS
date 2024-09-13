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
                EventHandler xEventHandler;

                // Event handler assignment is based on the function name passed as a parameter.
                // The function name is matched to predefined function names, and the appropriate event
                // handler is assigned.

                //if( prm_strFunctionName==PredefinedFunctionNames.strFunctionNames[FunctionNames.Login])
                //{
                //     xEventHandler = new System.EventHandler(vLoginSystem);
                //}

                // Switch statement to handle different function names and assign appropriate event handlers.
                switch (prm_strFunctionName)
                {
                    case CustomEventFunctionName.strNone:
                        xEventHandler = new System.EventHandler(vNoneFunction);
                        break;
                    case CustomEventFunctionName.strExitApplication:
                        xEventHandler = new System.EventHandler(vExitApplication);
                        break;
                    case CustomEventFunctionName.strLogin:
                    case CustomEventFunctionName.strLoginExtended:
                        xEventHandler = new System.EventHandler(vLoginSystem);
                        break;
                    case CustomEventFunctionName.strLogout:
                        xEventHandler = new System.EventHandler(vLogoutSystem);
                        break;
                    case CustomEventFunctionName.strServiceCodeRequest:
                        xEventHandler = new System.EventHandler(vServiceCodeRequest);
                        break;
                    case CustomEventFunctionName.strLoginService:
                        xEventHandler = new System.EventHandler(vNotDefinedFunction);
                        break;
                    case CustomEventFunctionName.strCloseForm:
                        xEventHandler = new System.EventHandler(vCloseForm);
                        break;
                    case CustomEventFunctionName.strSaveChanges:
                        xEventHandler = new System.EventHandler(vSaveChanges);
                        break;
                    case CustomEventFunctionName.strSaleDepartment:
                        xEventHandler = new System.EventHandler(vSaleDepartment);
                        break;
                    case CustomEventFunctionName.strSaleDepartmentByNo:
                        xEventHandler = new System.EventHandler(vSaleDepartmentByNo);
                        break;
                    case CustomEventFunctionName.strSalePluCode:
                        xEventHandler = new System.EventHandler(vSalePluCode);
                        break;
                    case CustomEventFunctionName.strSalePluBarcode:
                        xEventHandler = new System.EventHandler(vSalePluBarcode);
                        break;
                    case CustomEventFunctionName.strGetPluFromMainGroup:
                        xEventHandler = new System.EventHandler(vGetPluFromMainGroup);
                        break;
                    case CustomEventFunctionName.strRepeatLastSale:
                        xEventHandler = new System.EventHandler(vRepeatLastSale);
                        break;
                    case CustomEventFunctionName.strRepeatSale:
                        xEventHandler = new System.EventHandler(vRepeatSale);
                        break;
                    case CustomEventFunctionName.strCancelDepartment:
                        xEventHandler = new System.EventHandler(vCancelDepartment);
                        break;
                    case CustomEventFunctionName.strCancelPlu:
                        xEventHandler = new System.EventHandler(vCancelPlu);
                        break;
                    case CustomEventFunctionName.strCancelLastSale:
                        xEventHandler = new System.EventHandler(vCancelLastSale);
                        break;
                    case CustomEventFunctionName.strCancelSale:
                        xEventHandler = new System.EventHandler(vCancelSale);
                        break;
                    case CustomEventFunctionName.strOpenCashDrawer:
                        xEventHandler = new System.EventHandler(vOpenCashDrawer);
                        break;
                    case CustomEventFunctionName.strFunctionMenu:
                        xEventHandler = new System.EventHandler(vFunctionMenu);
                        break;
                    case CustomEventFunctionName.strSaleMenu:
                        xEventHandler = new System.EventHandler(vSaleMenu);
                        break;
                    case CustomEventFunctionName.strServiceMenu:
                        xEventHandler = new System.EventHandler(vServiceMenu);
                        break;
                    case CustomEventFunctionName.strSettingMenu:
                        xEventHandler = new System.EventHandler(vSettingMenu);
                        break;
                    case CustomEventFunctionName.strReportMenu:
                        xEventHandler = new System.EventHandler(vReportMenu);
                        break;
                    case CustomEventFunctionName.strCashier:
                        xEventHandler = new System.EventHandler(vCashier);
                        break;
                    case CustomEventFunctionName.strChangeDocumentType:
                        xEventHandler = new System.EventHandler(vChangeDocumentType);
                        break;
                    case CustomEventFunctionName.strCustomer:
                        xEventHandler = new System.EventHandler(vCustomer);
                        break;
                    case CustomEventFunctionName.strRefund:
                        xEventHandler = new System.EventHandler(vRefund);
                        break;
                    case CustomEventFunctionName.strDiscountByAmount:
                        xEventHandler = new System.EventHandler(vDiscountByAmount);
                        break;
                    case CustomEventFunctionName.strSurchargeByAmount:
                        xEventHandler = new System.EventHandler(vSurchargeByAmount);
                        break;
                    case CustomEventFunctionName.strDiscountByPercent:
                        xEventHandler = new System.EventHandler(vDiscountByPercent);
                        break;
                    case CustomEventFunctionName.strSurchargeByPercent:
                        xEventHandler = new System.EventHandler(vSurchargeByPercent);
                        break;
                    case CustomEventFunctionName.strInputPrice:
                        xEventHandler = new System.EventHandler(vInputPrice);
                        break;
                    case CustomEventFunctionName.strInputQuantity:
                        xEventHandler = new System.EventHandler(vInputQuantity);
                        break;
                    case CustomEventFunctionName.strInputAmount:
                        xEventHandler = new System.EventHandler(vInputAmount);
                        break;
                    case CustomEventFunctionName.strPriceLookUp:
                        xEventHandler = new System.EventHandler(vPriceLookUp);
                        break;
                    case CustomEventFunctionName.strSubTotal:
                        xEventHandler = new System.EventHandler(vSubTotal);
                        break;
                    case CustomEventFunctionName.strTotal:
                        xEventHandler = new System.EventHandler(vTotal);
                        break;
                    case CustomEventFunctionName.strSaleOption:
                        xEventHandler = new System.EventHandler(vSaleOption);
                        break;
                    case CustomEventFunctionName.strPayment:
                        xEventHandler = new System.EventHandler(vPayment);
                        break;
                    case CustomEventFunctionName.strCashPayment:
                        xEventHandler = new System.EventHandler(vCashPayment);
                        break;
                    case CustomEventFunctionName.strCreditPayment:
                        xEventHandler = new System.EventHandler(vCreditPayment);
                        break;
                    case CustomEventFunctionName.strCheckPayment:
                        xEventHandler = new System.EventHandler(vCheckPayment);
                        break;
                    case CustomEventFunctionName.strExchangePayment:
                        xEventHandler = new System.EventHandler(vExchangePayment);
                        break;
                    case CustomEventFunctionName.strPrepaidPayment:
                        xEventHandler = new System.EventHandler(vPrepaidPayment);
                        break;
                    case CustomEventFunctionName.strChargeSalePayment:
                        xEventHandler = new System.EventHandler(vChargeSalePayment);
                        break;
                    case CustomEventFunctionName.strOtherPayment:
                        xEventHandler = new System.EventHandler(vOtherPayment);
                        break;
                    case CustomEventFunctionName.strPaymentDetail:
                        xEventHandler = new System.EventHandler(vPaymentDetail);
                        break;
                    case CustomEventFunctionName.strClosure:
                        xEventHandler = new System.EventHandler(vClosure);
                        break;
                    case CustomEventFunctionName.strCancelDocument:
                        xEventHandler = new System.EventHandler(vCancelDocument);
                        break;
                    case CustomEventFunctionName.strStockEntryForm:
                        xEventHandler = new System.EventHandler(vStockEntryForm);
                        break;
                    case CustomEventFunctionName.strSaleDetailReport:
                        xEventHandler = new System.EventHandler(vSaleDetailReport);
                        break;
                    case CustomEventFunctionName.strPluSaleReport:
                        xEventHandler = new System.EventHandler(vPluSaleReport);
                        break;
                    case CustomEventFunctionName.strPosSummaryReport:
                        xEventHandler = new System.EventHandler(vPosSummaryReport);
                        break;
                    case CustomEventFunctionName.strSetDisplayBrightness:
                        xEventHandler = new System.EventHandler(vSetDisplayBrightness);
                        break;
                    case CustomEventFunctionName.strSetPrinterIntensity:
                        xEventHandler = new System.EventHandler(vSetPrinterIntensity);
                        break;
                    case CustomEventFunctionName.strSetCashier:
                        xEventHandler = new System.EventHandler(vSetCashier);
                        break;
                    case CustomEventFunctionName.strSetSupervisor:
                        xEventHandler = new System.EventHandler(vSetSupervisor);
                        break;
                    case CustomEventFunctionName.strSetReceiptHeader:
                        xEventHandler = new System.EventHandler(vSetReceiptHeader);
                        break;
                    case CustomEventFunctionName.strSetReceiptFooter:
                        xEventHandler = new System.EventHandler(vSetReceiptFooter);
                        break;
                    case CustomEventFunctionName.strSetIdleMessage:
                        xEventHandler = new System.EventHandler(vSetIdleMessage);
                        break;
                    case CustomEventFunctionName.strSetBarcodeDefinition:
                        xEventHandler = new System.EventHandler(vSetBarcodeDefinition);
                        break;
                    case CustomEventFunctionName.strSetVatDefinition:
                        xEventHandler = new System.EventHandler(vSetVatDefinition);
                        break;
                    case CustomEventFunctionName.strSetDepartmentDefinition:
                        xEventHandler = new System.EventHandler(vSetDepartmentDefinition);
                        break;
                    case CustomEventFunctionName.strSetCurrencyDefinition:
                        xEventHandler = new System.EventHandler(vSetCurrencyDefinition);
                        break;
                    case CustomEventFunctionName.strSetPluDefinition:
                        xEventHandler = new System.EventHandler(vSetPluDefinition);
                        break;
                    case CustomEventFunctionName.strSetPluMainGroupDefinition:
                        xEventHandler = new System.EventHandler(vSetPluMainGroupDefinition);
                        break;
                    case CustomEventFunctionName.strSetDiscountRate:
                        xEventHandler = new System.EventHandler(vSetDiscountRate);
                        break;
                    case CustomEventFunctionName.strSetSurchargeRate:
                        xEventHandler = new System.EventHandler(vSetSurchargeRate);
                        break;
                    case CustomEventFunctionName.strServiceCompanyInfo:
                        xEventHandler = new System.EventHandler(vServiceCompanyInfo);
                        break;
                    case CustomEventFunctionName.strServiceChangeDateTime:
                        xEventHandler = new System.EventHandler(vServiceChangeDateTime);
                        break;
                    case CustomEventFunctionName.strServiceParameterDownload:
                        xEventHandler = new System.EventHandler(vServiceParameterDownload);
                        break;
                    case CustomEventFunctionName.strServiceSetReceiptLimit:
                        xEventHandler = new System.EventHandler(vServiceSetReceiptLimit);
                        break;
                    case CustomEventFunctionName.strServiceResetToFactoryMode:
                        xEventHandler = new System.EventHandler(vServiceResetToFactoryMode);
                        break;
                    case CustomEventFunctionName.strServiceResetPassword:
                        xEventHandler = new System.EventHandler(vServiceResetPassword);
                        break;
                    case CustomEventFunctionName.strServiceChangePassword:
                        xEventHandler = new System.EventHandler(vServiceChangePassword);
                        break;
                    case CustomEventFunctionName.strServicePosActive:
                        xEventHandler = new System.EventHandler(vServicePosActive);
                        break;
                    case CustomEventFunctionName.strServiceSoftwareDownload:
                        xEventHandler = new System.EventHandler(vServiceSoftwareDownload);
                        break;
                    case CustomEventFunctionName.strInvoiceList:
                        xEventHandler = new System.EventHandler(vInvoiceList);
                        break;
                    case CustomEventFunctionName.strWaybillList:
                        xEventHandler = new System.EventHandler(vWaybillList);
                        break;
                    case CustomEventFunctionName.strReturnList:
                        xEventHandler = new System.EventHandler(vReturnList);
                        break;
                    case CustomEventFunctionName.strStockLookUp:
                        xEventHandler = new System.EventHandler(vStockLookUp);
                        break;
                    case CustomEventFunctionName.strSuspendPayment:
                        xEventHandler = new System.EventHandler(vSuspendPayment);
                        break;
                    case CustomEventFunctionName.strBackPayment:
                        xEventHandler = new System.EventHandler(vBackPayment);
                        break;
                    case CustomEventFunctionName.strSaleShortcut:
                        xEventHandler = new System.EventHandler(vShortcutMenu);
                        break;
                    //case CustomEventFunctionName.strReDrawForm:
                    //    xEventHandler = new System.EventHandler(vReDrawButtons);
                    //    break;
                    default:
                        // If no matching function name is found, use a default handler for undefined functions
                        xEventHandler = new System.EventHandler(vNotDefinedFunction);
                        break;
                }

                // Return the assigned event handler
                return xEventHandler;
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
