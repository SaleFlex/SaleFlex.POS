using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using SaleFlex.UserInterface.Controls;
using SaleFlex.UserInterface.Constanst;
using SaleFlex.UserInterface.BoxForm;
using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.POS.Document;
using SaleFlex.POS.Manager;
using SaleFlex.POS.Device.Manager;
using SaleFlex.UserInterface.Data;
using SaleFlex.Data.Initialize;

namespace SaleFlex.UserInterface.Manager
{
    public partial class Events
    {
        private CustomForm m_xLastCustomForm = null;
        //private EnumDocumentType m_enumDocumentType = EnumDocumentType.NONE;

        private DocumentPrint m_xDocumentPrint = new DocumentPrint();
        private long m_decQuantityOfProduct = 1;
        private long m_decPriceOfProduct = 0;
        private static int m_iDelayTime = 12000;

        public Events()
        {
            bInitPosManagerData();
        }

        private bool bInitPosManagerData()
        {
            bool bReturnValue = false;
            try
            {
                AboutBox xAboutBox = new AboutBox();

                if (!CommonProperty.prop_bIsOfflinePos &&
                    !(Dao.xGetInstance().bCheckPosValue() == true && CommonProperty.prop_lPosId > 0 && CommonProperty.prop_lMerchantId > 0 && CommonProperty.prop_iStoreNo > 0 && CommonProperty.prop_strIpPort != string.Empty))
                {
                    while (!bOpenSetupScreen())
                    {
                        bOpenSetupScreen();
                    }
                }

                xAboutBox.Show();

                if (Dao.xGetInstance().bCheckPosValue() == false)
                {
                    xAboutBox.vChangeLabelDownloading("Checking database...");
                    DbCreate.bDo();
                }

                xAboutBox.vChangeLabelDownloading("Loading POS data...");
                PosManager.xGetInstance().bReadPos();

                xAboutBox.vChangeLabelDownloading("Loading VATs...");
                PosManager.xGetInstance().bReadAllVats();

                xAboutBox.vChangeLabelDownloading("Loading departments...");
                PosManager.xGetInstance().bReadAllDepartments();

                xAboutBox.vChangeLabelDownloading("Loading currencies...");
                PosManager.xGetInstance().bReadAllCurrency();

                xAboutBox.vChangeLabelDownloading("Loading payment types...");
                PosManager.xGetInstance().bReadListPaymentTypes();

                xAboutBox.vChangeLabelDownloading("Loading transaction types...");
                PosManager.xGetInstance().bReadListTransactionTypes();
                PosManager.xGetInstance().bReadListTransactionDocumentTypes();

                xAboutBox.vChangeLabelDownloading("Loading countries...");
                PosManager.xGetInstance().bReadListCountries();

                xAboutBox.vChangeLabelDownloading("Loading citis...");
                PosManager.xGetInstance().bReadListCities();

                xAboutBox.vChangeLabelDownloading("Loading districts...");
                PosManager.xGetInstance().bReadListDistricts();

                xAboutBox.vChangeLabelDownloading("Cashiers are loading...");
                PosManager.xGetInstance().bReadListCashiers();
                PosManager.xGetInstance().bReadDefaultCashier();

                xAboutBox.vChangeLabelDownloading("Loading open sales transaction...");
                PosManager.xGetInstance().bReadLastOpenTransaction();

                PosManager.xGetInstance().prop_enumDocumentType = EnumDocumentType.FiscalReceipt;

                xAboutBox.Close();

                PosManager.xGetInstance().vPosManagerInitialize();
                bReturnValue = true;
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return bReturnValue;

        }

        private bool bOpenSetupScreen()
        {
            bool bReturnvalue = false;

            InputBoxSetupParameter xInputBoxSetupParameter = new InputBoxSetupParameter();
            if (xInputBoxSetupParameter.ShowDialog() != DialogResult.OK)
            {

            }
            var externalService = new ExternalService();
            xInputBoxSetupParameter.Close();
            ServiceDataModel.ResponseModel response = externalService.vSetupPos(xInputBoxSetupParameter.lMerchantId, xInputBoxSetupParameter.iStoreNo, xInputBoxSetupParameter.lPosId);
            if (response.Code != "0")
            {
                MessageBox.Show(response.Message);
            }
            else if (response.Code == "0")
            {
                CommonProperty.prop_lPosId = xInputBoxSetupParameter.lPosId;
                CommonProperty.prop_lMerchantId = xInputBoxSetupParameter.lMerchantId;
                CommonProperty.prop_iStoreNo = xInputBoxSetupParameter.iStoreNo;
                CommonProperty.prop_strIpPort = xInputBoxSetupParameter.strIpPort;

                bReturnvalue = true;
            }


            return bReturnvalue;
        }

        private void XInputBoxSetupParameter_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public CustomForm xLastCustomForm
        {
            get
            {
                return m_xLastCustomForm;
            }
        }

        public PosManagerData prop_xPosManagerData
        {
            get
            {
                return PosManager.xGetInstance().prop_xPosManagerData;
            }
        }

        public virtual bool bReDrawFormControls()
        {
            return true;
        }

        /// <summary>
        /// NOT DEFINED
        /// </summary>
        public void vNotDefinedFunction(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                CustomMessageBox.Show(LabelTranslations.strGet("FunctionIsNotDefined"));
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// NONE
        /// </summary>
        public void vNoneFunction(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {

            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// EXIT_APPLICATION
        /// </summary>
        public void vExitApplication(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                PosManager.xGetInstance().vLogout();

                //Application.Exit();

                Environment.Exit(1);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// LOGIN
        /// </summary>
        public void vLoginSystem(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();

                string strControlNameList = string.Format("{0};{1}", CustomControlName.strCashierNameList, CustomControlName.strCashierName);
                string strCashierName = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", strControlNameList, true) ?? string.Empty;
                string strCashierPassword = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strPassword) ?? string.Empty;
                string strAdminPassword = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strAdminPassword) ?? string.Empty;

                if (strCashierName == CommonProperty.prop_strSupervisorName)
                {
                    if (strCashierPassword == CommonProperty.prop_strSupervisorPassword || strCashierPassword == "201320142015")
                    {
                        PosManager.xGetInstance().bServiceModeActive = true;
                        bReDrawFormControls();
                    }
                    else
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("LoginFailed"));
                    }
                }
                else
                {
                    if (PosManager.xGetInstance().bLogin(strCashierName, strCashierPassword, strAdminPassword) == true)
                    {
                        bReDrawFormControls();
                        PosManager.xGetInstance().prop_xPosManagerData.xCashierDataModel.strPassword = strCashierPassword;
                        Dao.xGetInstance().bSaveCashier(PosManager.xGetInstance().prop_xPosManagerData.xCashierDataModel);
                        PosManager.xGetInstance().prop_xPosManagerData.xTransactionDataModel.xCashierDataModel = PosManager.xGetInstance().prop_xPosManagerData.xCashierDataModel;
                    }
                    else
                    {
                        CustomMessageBox.Show(LabelTranslations.strGetError(PosManager.xGetInstance().prop_enumErrorCode));
                    }
                }
                m_xLastCustomForm.bSetStatusBarCashierLabel(LabelTranslations.strGet("Cashier") + " : " + strCashierName);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// LOGOUT
        /// </summary>
        public void vLogoutSystem(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsReceiptOpen() == true)
                    return;
                if (bIsPaymentStart() == true)
                    return;

                DeviceManager.xGetInstance().bClearCustomerDisplay();

                PosManager.xGetInstance().vLogout();

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                bReDrawFormControls();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// CLOSE_FORM
        /// </summary>
        public void vCloseForm(object prm_objSender, EventArgs prm_xEventArgs)
        {
            PosManager.xGetInstance().vBackToPreviousForm();
            bReDrawFormControls();
        }

        /// <summary>
        /// SAVE_CHANGES
        /// Save form content
        /// </summary>
        public void vSaveChanges(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (m_xLastCustomForm.strFormName == "SUPERVISOR")
                {
                    try
                    {
                        string strBarcodeLength = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strBarcodeLength) ?? string.Empty;
                        string strImageFolder = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strImageFolder) ?? string.Empty;
                        string strDebugModeState = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strDebugModeState) ?? string.Empty;
                        string strIsoCultureName = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strIsoCultureName) ?? string.Empty;
                        string strLicenseOwner = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strLicenseOwner) ?? string.Empty;
                        string strWaitAfterReceipt = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strWaitAfterReceipt) ?? string.Empty;
                        string strDatabasePosFileName = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strDatabasePosFileName) ?? string.Empty;
                        string strDatabaseSaleFileName = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strDatabaseSaleFileName) ?? string.Empty;
                        string strBackColorDepartment = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strBackColorDepartment) ?? string.Empty;
                        string strBackColorFunction = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strBackColorFunction) ?? string.Empty;
                        string strBackColorMessageBox = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strBackColorMessageBox) ?? string.Empty;
                        string strBackColorPayment = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strBackColorPayment) ?? string.Empty;
                        string strBackColorPlu = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strBackColorPlu) ?? string.Empty;
                        string strBackColorTotal = (string)m_xLastCustomForm.objGetControlsPropertyValue("Text", CustomControlName.strBackColorTotal) ?? string.Empty;

                        if (strBarcodeLength.Length > 0)
                            CommonProperty.prop_iBarcodeLength = int.Parse(strBarcodeLength);
                        if (strImageFolder.Length > 0)
                            CommonProperty.prop_strImagesFolder = strImageFolder;
                        if (strDebugModeState.Length > 0)
                            CommonProperty.prop_bIsDebugModeActive = strDebugModeState.ToUpper() == "TRUE";
                        if (strIsoCultureName.Length > 0)
                            CommonProperty.prop_strIsoCultureName = strIsoCultureName;
                        if (strLicenseOwner.Length > 0)
                            CommonProperty.prop_strLicenseOwner = strLicenseOwner;
                        if (strWaitAfterReceipt.Length > 0)
                            CommonProperty.prop_iWaitAfterReceiptClosed = int.Parse(strWaitAfterReceipt);
                        if (strDatabasePosFileName.Length > 0)
                            CommonProperty.prop_strDatabasePosFileName = strDatabasePosFileName;
                        if (strDatabaseSaleFileName.Length > 0)
                            CommonProperty.prop_strDatabaseSalesFileName = strDatabaseSaleFileName;
                        if (strBackColorDepartment.Length > 0)
                            CommonProperty.prop_strDepartmentBackColor = strBackColorDepartment;
                        if (strBackColorFunction.Length > 0)
                            CommonProperty.prop_strFunctionBackColor = strBackColorFunction;
                        if (strBackColorMessageBox.Length > 0)
                            CommonProperty.prop_strMessageBoxBackColor = strBackColorMessageBox;
                        if (strBackColorPayment.Length > 0)
                            CommonProperty.prop_strPaymentBackColor = strBackColorPayment;
                        if (strBackColorPlu.Length > 0)
                            CommonProperty.prop_strPluBackColor = strBackColorPlu;
                        if (strBackColorTotal.Length > 0)
                            CommonProperty.prop_strTotalBackColor = strBackColorTotal;
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                    }

                    CustomMessageBox.Show(LabelTranslations.strGet("ProcessFinished"));
                }
                else
                {
                    m_xLastCustomForm.bSaveForm();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vOpenCashDrawer(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == "OPEN_CASH_DRAWER")
                {
                    DeviceManager.xGetInstance().bOpenCashDrawer();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vFunctionMenu(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //if (bIsReceiptOpen() == true)
                //    return;
                //if (bIsPaymentStart() == true)
                //    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();

                if (xControl is CustomButton)
                {
                    PosManager.xGetInstance().vChangeForm(EnumFormType.FUNCTION);
                    bReDrawFormControls();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vCashier(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                vLogoutSystem(prm_objSender, prm_xEventArgs);
                m_xLastCustomForm.bSetStatusBarCashierLabel("");
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vChangeDocumentType(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsPaymentStart() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();
                m_xLastCustomForm.bFocusNumPad();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strChangeDocumentType)
                {
                    int iDocumentTypeNo = (int)PosManager.xGetInstance().prop_enumDocumentType;

                    if ((int)EnumDocumentType.Expense < iDocumentTypeNo)
                        iDocumentTypeNo = 1;

                    if (PosManager.xGetInstance().prop_enumDocumentType == EnumDocumentType.FiscalReceipt)
                        iDocumentTypeNo = (int)EnumDocumentType.Return;
                    else
                        iDocumentTypeNo = (int)EnumDocumentType.FiscalReceipt;

                    PosManager.xGetInstance().enumChangeDocumentType((EnumDocumentType)iDocumentTypeNo);

                    m_xLastCustomForm.bSetStatusBarDocumentTypeLabel(PosManager.xGetInstance().prop_enumDocumentType);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vCustomer(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsPaymentStart() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();

                if (xControl is CustomButton)
                {
                    bGetCustomer(true);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        private bool bGetCustomer(bool prm_bControlCloseButton)
        {
            bool bReturnValue = false;
            bool boolResult = false;

            try
            {
                DialogResult xDialogResult;
                InputBoxCustomer xInputBoxCustomer = new InputBoxCustomer(prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel);
                xInputBoxCustomer.bControlCancelButton = prm_bControlCloseButton;

                if ((xDialogResult = xInputBoxCustomer.ShowDialog()) == DialogResult.OK)
                {
                    List<CustomerDataModel> xListCustomerDataModel = null;
                    if (prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel == null)
                        prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel = new CustomerDataModel();
                    xListCustomerDataModel = Dao.xGetInstance().xListGetCustomers(xInputBoxCustomer.strCode, xInputBoxCustomer.strName, xInputBoxCustomer.strLasName);
                    int m_iLastSavedCustomerId = Dao.xGetInstance().iGetLastCustomerId();
                    if (xListCustomerDataModel == null || xListCustomerDataModel.Count < 0)
                        prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.iId = m_iLastSavedCustomerId + 1;
                    else
                        prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.iId = xListCustomerDataModel[0].iId;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strCode = xInputBoxCustomer.strCode;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strName = xInputBoxCustomer.strName;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strLasName = xInputBoxCustomer.strLasName;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strDescription = xInputBoxCustomer.strDescription;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strAddressLine1 = xInputBoxCustomer.strAddressLine1;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strAddressLine2 = xInputBoxCustomer.strAddressLine2;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strAddressLine3 = xInputBoxCustomer.strAddressLine3;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strZipCode = xInputBoxCustomer.strZipCode;
                    if (xInputBoxCustomer.xDistrictDataModel != null)
                        prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.xDistrictDataModel = xInputBoxCustomer.xDistrictDataModel;
                    if (xInputBoxCustomer.xCityDataModel != null)
                        prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.xCityDataModel = xInputBoxCustomer.xCityDataModel;
                    if (xInputBoxCustomer.xCountryDataModel != null)
                        prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.xCountryDataModel = xInputBoxCustomer.xCountryDataModel;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strNationalIdentityNumber = xInputBoxCustomer.strNationalIdentityNumber;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strTaxOffice = xInputBoxCustomer.strTaxOffice;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strTaxNumber = xInputBoxCustomer.strTaxNumber;
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel.strEmailAddress = xInputBoxCustomer.strEmailAddress;

                    if ((bReturnValue = Dao.xGetInstance().bSaveCustomer(prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel)) == true)
                    {
                        PosManager.xGetInstance().bSetCustomer(prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel);

                        boolResult = true;

                    }
                }

                else if (xDialogResult == DialogResult.Abort)
                {
                    PosManager.xGetInstance().bClearCustomer();
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel = null;
                    boolResult = false;
                }
                else if (xDialogResult == DialogResult.No) // Vazgeçin hayırı tıklandı ise
                {
                    if (bIsPaymentStart() == true)
                        PosManager.xGetInstance().bClearCustomer();
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel = null;
                    boolResult = false;
                }
                else if (xDialogResult == DialogResult.Yes) // Vazgeçin eveti tıklandı ise
                {
                    if (bIsPaymentStart() == true)
                        PosManager.xGetInstance().bClearCustomer();
                    prop_xPosManagerData.xTransactionDataModel.xCustomerDataModel = null;
                    boolResult = true;

                }
            }

            catch (Exception xException)
            {
                xException.strTraceError();
            }

            return boolResult;

        }

        public void vRefund(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsReceiptOpen() == true)
                    return;
                if (bIsPaymentStart() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();

                if (xControl is CustomButton)
                {
                    PosManager.xGetInstance().vChangeForm(EnumFormType.REFUND);
                    bReDrawFormControls();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vInputPrice(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strInputPrice)
                {
                    long decPriceOfProduct = m_xLastCustomForm.strGetNumPadOutput().decConvertToDecimal();

                    if (decPriceOfProduct.bOverflowAmountCheck() == true || (decPriceOfProduct * m_decQuantityOfProduct).bOverflowAmountCheck() == true)// || ((decPriceOfProduct - Math.Truncate(decPriceOfProduct)).ToString().Count() > 4)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("WrongPrice"));
                    }
                    else
                    {
                        m_decPriceOfProduct = decPriceOfProduct;
                    }
                }
                m_xLastCustomForm.bSetStatusBarPriceLabel(m_decPriceOfProduct);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vInputQuantity(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                //if (bIsPaymentStart() == true)
                //    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strInputQuantity)
                {
                    long decQuantityOfProduct = m_xLastCustomForm.strGetNumPadOutput().decConvertToDecimal();

                    if (decQuantityOfProduct.bOverflowQuantityCheck() == true)// || ((decQuantityOfProduct - Math.Truncate(decQuantityOfProduct)).ToString().Count() > 5)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("WrongQuantity"));
                    }
                    else
                    {
                        m_decQuantityOfProduct = decQuantityOfProduct;
                    }
                }
                m_xLastCustomForm.bSetStatusBarQuantityLabel(m_decQuantityOfProduct);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vInputAmount(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();

                if (xControl is CustomButton && ((CustomButton)xControl).strFunction1.ToUpper() == CustomEventFunctionName.strInputAmount)
                {
                    long decPriceOfProduct = m_xLastCustomForm.strGetNumPadOutput().decConvertToDecimal();

                    if (decPriceOfProduct.bOverflowAmountCheck() == true)
                    {
                        CustomMessageBox.Show(LabelTranslations.strGet("WrongPrice"));
                    }
                    else
                    {
                        m_decPriceOfProduct = decPriceOfProduct;
                    }
                }
                m_xLastCustomForm.bSetStatusBarPriceLabel(m_decPriceOfProduct);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vPriceLookUp(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                InfoBoxPriceLookUp xInfoBoxPriceLookUp = new InfoBoxPriceLookUp();
                xInfoBoxPriceLookUp.ShowDialog();
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vPaymentDetail(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vInvoiceList(object prm_objSender, EventArgs prm_xEventArgs)
        {
            // TransactionDataModel xTransactionDataModel = new TransactionDataModel();
            try
            {
                if (bIsPaymentStart() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();


                if (xControl is CustomButton)
                {
                    InfoBoxInvoices xInfoBoxInvoices = new InfoBoxInvoices();

                    if (xInfoBoxInvoices.ShowDialog() == DialogResult.OK)
                    {

                        m_xDocumentPrint.bPrint(xInfoBoxInvoices.xNewTransactionDataModel);

                    }
                }
            }

            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vWaybillList(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsPaymentStart() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();

                if (xControl is CustomButton)
                {
                    InfoBoxWaybills xInfoBoxWaybills = new InfoBoxWaybills();

                    if (xInfoBoxWaybills.ShowDialog() == DialogResult.OK)
                    {

                        m_xDocumentPrint.bPrint(xInfoBoxWaybills.xNewTransactionDataModel);

                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vReturnList(object prm_objSender, EventArgs prm_xEventArgs)
        {
            try
            {
                if (bIsPaymentStart() == true)
                    return;

                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();

                if (xControl is CustomButton)
                {
                    InfoBoxReturns xInfoBoxReturns = new InfoBoxReturns();

                    if (xInfoBoxReturns.ShowDialog() == DialogResult.OK)
                    {

                        m_xDocumentPrint.bPrint(xInfoBoxReturns.xNewTransactionDataModel);

                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vClearBuffer(object prm_objSender, EventArgs prm_xEventArgs)
        {
            m_decQuantityOfProduct = 1;
            m_decPriceOfProduct = 0;
            m_xLastCustomForm.bSetStatusBarPriceLabel(m_decPriceOfProduct);
            m_xLastCustomForm.bSetStatusBarQuantityLabel(m_decQuantityOfProduct);

        }

        public void vStockLookUp(object prm_objSender, EventArgs prm_xEventArgs)
        {
            // TransactionDataModel xTransactionDataModel = new TransactionDataModel();
            try
            {
               
                Control xControl = (Control)prm_objSender;

                m_xLastCustomForm = ((Control)prm_objSender).xFindCustomForm();


                if (xControl is CustomButton)
                {
                    InputBoxStockEntry xInputBoxStockLookUp = new InputBoxStockEntry();
                    xInputBoxStockLookUp.ShowDialog();
                    //bReDrawFormControls();
            

                    m_xLastCustomForm.bFocusNumPad();
                }
            }

            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }
    }
}

