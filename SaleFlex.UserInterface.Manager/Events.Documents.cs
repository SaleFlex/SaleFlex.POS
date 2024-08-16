using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaleFlex.UserInterface.Controls;
using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.POS.Manager;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.Manager
{
    public partial class Events
    {
        private bool bIsReceiptOpen()
        {
            try
            {
                if (PosManager.xGetInstance().prop_enumDocumentState == enumDocumentState.OPENED)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("ReceiptIsOpen"));
                    return true;
                }
            }
            catch
            {
            }

            return false;
        }

        private bool bIsNotReceiptOpen()
        {
            try
            {
                if (PosManager.xGetInstance().prop_enumDocumentState == enumDocumentState.CLOSED && prop_xPosManagerData.xTransactionDataModel.xTransactionHeadDataModel.iId == 0)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("ReceiptIsNotOpen"));
                    return true;
                }
            }
            catch(Exception ex)
            {
            }

            return false;
        }

        private bool bIsPaymentStart()
        {
            try
            {
                if (prop_xPosManagerData.xTransactionDataModel != null && prop_xPosManagerData.decReceiptTotalPayment > 0)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("PaymentIsStarted"));
                    return true;
                }
            }
            catch
            {
            }

            return false;
        }

        private bool bIsPaymentAllow()
        {
            try
            {
                if (prop_xPosManagerData.xTransactionDataModel == null || prop_xPosManagerData.decReceiptTotalPrice <= 0)
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("PaymentIsNotPossible"));
                    return true;
                }
            }
            catch
            {
            }

            return false;
        }

        private bool bIsSuspendedReceipt() {
            try
            {
                if (Dao.xGetInstance().xSuspendedListValues == null || (Dao.xGetInstance().xSuspendedListValues[0] == prop_xPosManagerData.xTransactionDataModel.iId))
                {
                    CustomMessageBox.Show(LabelTranslations.strGet("SuspendDocumentIsNotFound"));
                    return true;
                }
            }
            catch
            {
            }

            return false;
        }
    }
}
