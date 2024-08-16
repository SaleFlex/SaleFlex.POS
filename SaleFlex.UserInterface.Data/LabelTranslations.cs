using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaleFlex.Data;
using SaleFlex.Data.AccessLayer;


namespace SaleFlex.UserInterface.Data
{
    public class LabelTranslations
    {

        public static string strGet(string prm_strLabelName)
        {
            string strLabelName = Dao.xGetInstance().strGetLabelValues(prm_strLabelName);

            if (string.IsNullOrEmpty(strLabelName))
                return prm_strLabelName;
            else
                return strLabelName;
        }

        public static string strGetError(enumErrorCode prm_enumErrorCode)
        {
            string strErrorLabelName = string.Empty;

            switch (prm_enumErrorCode)
            {
                case enumErrorCode.DEPARTMENT_NOT_FOUND:
                    strErrorLabelName = strGet("DepartmentNotFound");
                    break;
                case enumErrorCode.CAN_NOT_INSERT_TRANSACTION:
                    strErrorLabelName = strGet("CanNotInsertTransactıon");
                    break;
                case enumErrorCode.CAN_NOT_START_RECEIPT:
                    strErrorLabelName = strGet("CanNotStartReceipt");
                    break;
                case enumErrorCode.NEED_CASHIER_LOGIN:
                    strErrorLabelName = strGet("NeedCashierLogin");
                    break;
                case enumErrorCode.PLU_NOT_FOUND:
                    strErrorLabelName = strGet("PluNotFound");
                    break;
                case enumErrorCode.INSUFFICIENT_STOCK:
                    strErrorLabelName = strGet("InsufficientStock");
                    break;
                case enumErrorCode.CAN_NOT_CLOSE_RECEIPT:
                    strErrorLabelName = strGet("CanNotCloseReceipt");
                    break;
                case enumErrorCode.PAYMENT_TYPE_ERROR:
                    strErrorLabelName = strGet("PaymentTypeError");
                    break;
                case enumErrorCode.PAYMENT_NOT_POSSIBLE:
                    strErrorLabelName = strGet("PaymentNotPossible");
                    break;
                case enumErrorCode.CAN_NOT_CANCEL_TRANSACTION:
                    strErrorLabelName = strGet("CanNotCancelTransaction");
                    break;
                case enumErrorCode.CAN_NOT_CANCEL_DOCUMENT:
                    strErrorLabelName = strGet("CanNotCancelDocument");
                    break;
                case enumErrorCode.SUBTOTAL_NOT_POSSIBLE:
                    strErrorLabelName = strGet("SubtotalNotPossible");
                    break;
            }

            return strErrorLabelName;
        }

        public static string strGetDocumentType(enumDocumentType prm_enumDocumentType)
        {
            string strDocumentType = string.Empty;

            strDocumentType = strGet(prm_enumDocumentType.ToString());

            return strDocumentType;
        }
    }
}
