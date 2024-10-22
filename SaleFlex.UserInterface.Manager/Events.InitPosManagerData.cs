using SaleFlex.CommonLibrary;
using SaleFlex.Data.AccessLayer;
using SaleFlex.Data.Initialize;
using SaleFlex.Data;
using SaleFlex.POS.Manager;
using SaleFlex.UserInterface.BoxForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleFlex.Data.Models;
using System.Windows.Forms;
using SaleFlex.GATE.Manager;

namespace SaleFlex.UserInterface.Manager
{
    public partial class Events
    {
        // Method to initialize POS Manager data
        private bool bInitPosManagerData()
        {
            bool bReturnValue = false;
            try
            {
                // Initialize AboutBox form instance
                AboutBox xAboutBox = new AboutBox();

                // Check if the system is not offline and essential POS properties are correctly set
                if (!CommonProperty.prop_bIsOfflinePos &&
                    !(Dao.xGetInstance().bCheckPosDb() == true &&
                    CommonProperty.prop_lPosId > 0 &&
                    CommonProperty.prop_lMerchantId > 0 &&
                    CommonProperty.prop_iStoreNo > 0 &&
                    CommonProperty.prop_strIpPort != string.Empty))
                {
                    // Open setup screen until the necessary conditions are met
                    while (!bOpenSetupScreen()) ;
                }

                // Display AboutBox
                xAboutBox.Show();

                // Check and create necessary databases
                vCheckAndCreateDatabase(xAboutBox);

                // Load POS data into the system
                vLoadPosData(xAboutBox);

                // Close AboutBox
                xAboutBox.Close();

                // Initialize the POS Manager
                PosManager.xGetInstance().vPosManagerInitialize();

                // Set return value to true indicating successful initialization
                bReturnValue = true;
            }
            catch (Exception xException)
            {
                // Handle and log any exceptions that occur during initialization
                xException.strTraceError();
            }
            return bReturnValue;

        }

        // Method to check and create necessary databases for POS
        private void vCheckAndCreateDatabase(AboutBox prm_xAboutBox)
        {
            // Check if POS database exists, if not, create it
            if (Dao.xGetInstance().bCheckPosDb() == false)
            {
                prm_xAboutBox.vChangeLabelDownloading("Checking POS database...");
                DbCreate.bCreatePosDb();
            }

            // Check if Product (PLU) database exists, if not, create it
            if (Dao.xGetInstance().bCheckPluDb() == false)
            {
                prm_xAboutBox.vChangeLabelDownloading("Checking PLU database...");
                DbCreate.bCreateProductDb();
            }

            // Check if Sales database exists, if not, create it
            if (Dao.xGetInstance().bCheckSalesDb() == false)
            {
                prm_xAboutBox.vChangeLabelDownloading("Checking TRANSACTION database...");
                DbCreate.bCreateSalesDb();
            }

            // Check if Customer database exists, if not, create it
            if (Dao.xGetInstance().bCheckCustomersDb() == false)
            {
                prm_xAboutBox.vChangeLabelDownloading("Checking CUSTOMER database...");
                DbCreate.bCreateCustomerDb();
            }

            // Check if Warehouse database exists, if not, create it
            if (Dao.xGetInstance().bCreateWarehouseDb() == false)
            {
                prm_xAboutBox.vChangeLabelDownloading("Checking WAREHOUSE database...");
                DbCreate.bCreateWarehouseDb();
            }
        }

        // Method to load POS data and initialize different entities
        private void vLoadPosData(AboutBox prm_xAboutBox)
        {
            prm_xAboutBox.vChangeLabelDownloading("Loading POS data...");
            PosManager.xGetInstance().bReadPos();

            prm_xAboutBox.vChangeLabelDownloading("Loading VATs...");
            PosManager.xGetInstance().bReadAllVats();

            prm_xAboutBox.vChangeLabelDownloading("Loading departments...");
            PosManager.xGetInstance().bReadAllDepartments();

            prm_xAboutBox.vChangeLabelDownloading("Loading currencies...");
            PosManager.xGetInstance().bReadAllCurrency();

            prm_xAboutBox.vChangeLabelDownloading("Loading payment types...");
            PosManager.xGetInstance().bReadListPaymentTypes();

            prm_xAboutBox.vChangeLabelDownloading("Loading transaction types...");
            PosManager.xGetInstance().bReadListTransactionTypes();
            PosManager.xGetInstance().bReadListTransactionDocumentTypes();

            prm_xAboutBox.vChangeLabelDownloading("Loading countries...");
            PosManager.xGetInstance().bReadListCountries();

            prm_xAboutBox.vChangeLabelDownloading("Loading citis...");
            PosManager.xGetInstance().bReadListCities();

            prm_xAboutBox.vChangeLabelDownloading("Loading districts...");
            PosManager.xGetInstance().bReadListDistricts();

            prm_xAboutBox.vChangeLabelDownloading("Cashiers are loading...");
            PosManager.xGetInstance().bReadListCashiers();
            PosManager.xGetInstance().bReadDefaultCashier();

            prm_xAboutBox.vChangeLabelDownloading("Transactions are loading...");
            PosManager.xGetInstance().bReadLastOpenTransaction();
            PosManager.xGetInstance().bReadTransactionSequences();

            // Set the default document type for the POS Manager
            PosManager.xGetInstance().prop_enumDocumentType = EnumDocumentType.FiscalReceipt;
        }

        // Method to open the setup screen and set up POS data
        private bool bOpenSetupScreen()
        {
            bool bReturnvalue = false;

            // Initialize setup parameter form
            InputBoxSetupParameter xInputBoxSetupParameter = new InputBoxSetupParameter();

            // Display setup parameter input box
            if (xInputBoxSetupParameter.ShowDialog() != DialogResult.OK)
            {
                // Handle invalid input
            }

            // Create an instance of the external service to set up POS
            var xGateManager = new GateManager();
            xInputBoxSetupParameter.Close();

            // Call the setup service and check the response
            ServiceDataModel.ResponseModel response = xGateManager.vSetupPos(xInputBoxSetupParameter.lMerchantId, xInputBoxSetupParameter.iStoreNo, xInputBoxSetupParameter.lPosId);

            // Handle the response from the service call
            if (response.Code != "0")
            {
                MessageBox.Show(response.Message);
            }
            else if (response.Code == "0")
            {
                // Update common properties with the setup data
                CommonProperty.prop_lPosId = xInputBoxSetupParameter.lPosId;
                CommonProperty.prop_lMerchantId = xInputBoxSetupParameter.lMerchantId;
                CommonProperty.prop_iStoreNo = xInputBoxSetupParameter.iStoreNo;
                CommonProperty.prop_strIpPort = xInputBoxSetupParameter.strIpPort;

                bReturnvalue = true;
            }


            return bReturnvalue;
        }
    }
}
