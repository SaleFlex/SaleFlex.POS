using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using SaleFlex.CommonLibrary;

namespace SaleFlex.POS.Manager
{
    public static class ResponseMessage
    {
        public enum RESPONSE_CODE
        {
            [StringValue("0000")]
            [DescriptionValue("SUCCEEDED")]
            SUCCEEDED=0,
            [StringValue("0001")]
            [DescriptionValue("INVALID_TRANSACTION")]
            INVALID_TRANSACTION,
            [StringValue("0002")]
            [DescriptionValue("Allready in fiscal mode")]
            ALLREADY_FISCAL_MODE,
            [StringValue("0003")]
            [DescriptionValue("RECEIPT_LIMIT_EXCEEDED")]
            RECEIPT_LIMIT_EXCEEDED,
            [StringValue("0004")]
            [DescriptionValue("DEPARTMENT_LIMIT_EXCEEDED")]
            DEPARTMENT_LIMIT_EXCEEDED,
            [StringValue("0005")]
            [DescriptionValue("UNAUTHORIZED_TRANSACTION")]
            UNAUTHORIZED_TRANSACTION,
            [StringValue("0006")]
            [DescriptionValue("Department is not active.")]
            DEPARTMENT_IS_NOT_ACTIVE,
            [StringValue("0007")]
            [DescriptionValue("Payment amount is zero.")]
            PAYMENT_AMOUNT_IS_ZERO,
            [StringValue("0008")]
            [DescriptionValue("Payment limit exceeded.")]
            PAYMENT_LIMIT_EXCEEDED,
            [StringValue("0009")]
            [DescriptionValue("Amount is too large.")]
            AMOUNT_TOO_LARGE,
            [StringValue("0010")]
            [DescriptionValue("Amount is too little.")]
            AMOUNT_TOO_LITTLE,
            [StringValue("0011")]
            [DescriptionValue("Plu is not found.")]
            PLU_NOT_FOUND,
            [StringValue("0012")]
            [DescriptionValue("Plu is not defined.")]
            PLU_NOT_DEFINED,
            [StringValue("0013")]
            [DescriptionValue("Quantity is already in barcode.")]
            QTY_ALREADY_IN_BARCODE,
            [StringValue("0014")]
            [DescriptionValue("Service mode entrance limit is exceeded.")]
            SERVICE_MODE_PASSWORD_LIMIT_OVERLOADED,
            [StringValue("0015")]
            [DescriptionValue("Database integrity error")]
            DATABASE_INTEGRITY_ERROR,
            [StringValue("0016")]
            [DescriptionValue("Receipt started")]
            RECEIPT_STARTED,
            [StringValue("0017")]
            [DescriptionValue("Process number error")]
            PROCESS_NUMBER_ERROR,
            [StringValue("0018")]
            [DescriptionValue("INCORRECT_CASHIER_INFO")]
            INCORRECT_CASHIER_INFO,
            [StringValue("0019")]
            [DescriptionValue("Service password is not correct.")]
            SERVICE_PASSWORD_ERROR,
            [StringValue("0020")]
            [DescriptionValue("SYSTEM_TEMPORARILY_DOWN")]
            SYSTEM_TEMPORARILY_DOWN,
            [StringValue("0021")]
            [DescriptionValue("SYSTEM_IDLE")]
            SYSTEM_IDLE,
            [StringValue("0022")]
            [DescriptionValue("SYSTEM_ERROR")]
            SYSTEM_ERROR,
            [StringValue("0023")]
            [DescriptionValue("License is not accepted. Have to use proper license.")]
            LICENSE_IS_NOT_ACCEPTED,
            [StringValue("0024")]
            [DescriptionValue("Need to authorize the DLL.")]
            NEED_TO_AUTHORIZED,
            [StringValue("0025")]
            [DescriptionValue("Unexpected error occured. Please report this situation.")]
            UNEXPECTED_ERROR,
            [StringValue("0026")]
            [DescriptionValue("Cashier id is not correct")]
            INCORRECT_CASHIER_ID,
            [StringValue("0027")]
            [DescriptionValue("Need to login and activate sales screen mode")]
            NEED_TO_ACTIVATE_SALES_SCREEN_MODE,
            [StringValue("0028")]
            [DescriptionValue("Need to login and activate end of day screen mode")]
            NEED_TO_ACTIVATE_END_OF_DAY_SCREEN_MODE,
            [StringValue("0029")]
            [DescriptionValue("Need to login and activate service screen mode")]
            NEED_TO_ACTIVATE_SERVICE_SCREEN_MODE,
            [StringValue("0030")]
            [DescriptionValue("Index is out of range")]
            INVALID_INDEX,
            [StringValue("0031")]
            [DescriptionValue("Invalid document type. First you should open a suitable document.")]
            INVALID_DOCUMENT_TYPE,
            [StringValue("0032")]
            [DescriptionValue("There are an active document.")]
            ALREADY_ACTIVE_DOCUMENT,
            [StringValue("0033")]
            [DescriptionValue("There is not any active or open receipt.")]
            NO_ACTIVE_RECEIPT,
            [StringValue("0034")]
            [DescriptionValue("There is not any active or open document.")]
            NO_ACTIVE_DOCUMENT,
            [StringValue("0035")]
            [DescriptionValue("Closing fiscal receipt or invoice is not directly possible. Try to cancel or payment.")]
            COULD_NOT_END_RECEIPT_INVOICE,
            [StringValue("0036")]
            [DescriptionValue("Communication error.")]
            COMMUNICATION_ERROR,
            [StringValue("0037")]
            [DescriptionValue("Parameter(s) is not valid.")]
            INVALID_PARAMETERS,
            [StringValue("0038")]
            [DescriptionValue("Not possible")]
            NOT_POSSIBLE,
            [StringValue("0039")]
            [DescriptionValue("Receipt limit")]
            RECEIPT_LIMIT,
            [StringValue("0040")]
            [DescriptionValue("Department not used")]
            DEPARTMENT_NOT_USED,
            [StringValue("0041")]
            [DescriptionValue("Price zero")]
            PRICE_ZERO,
            [StringValue("0042")]
            [DescriptionValue("Price limit")]
            PRICE_LIMIT,
            [StringValue("0043")]
            [DescriptionValue("Value too large")]
            VALUE_TOO_LARGE,
            [StringValue("0044")]
            [DescriptionValue("Item not found")]
            ITEM_NOT_FOUND,
            [StringValue("0045")]
            [DescriptionValue("Wrong quantity")]
            WRONG_QUANTITY,
            [StringValue("0046")]
            [DescriptionValue("No item entered")]
            NO_ITEM_ENTERED,
            [StringValue("0047")]
            [DescriptionValue("Percent key error")]
            PERCENT_KEY_ERROR,
            [StringValue("0048")]
            [DescriptionValue("Value too little")]
            VALUE_TOO_LITTLE,
            [StringValue("0049")]
            [DescriptionValue("Value too large take reports")]
            VALUE_TOO_LARGE_TAKE_REPORTS,
            [StringValue("0050")]
            [DescriptionValue("Discount key error")]
            DISCOUNT_KEY_ERROR,
            [StringValue("0051")]
            [DescriptionValue("Discount zero")]
            DISCOUNT_ZERO,
            [StringValue("0052")]
            [DescriptionValue("Discount too large")]
            DISCOUNT_TOO_LARGE,
            [StringValue("0053")]
            [DescriptionValue("Void all key error")]
            VOIDALL_KEY_ERROR,
            [StringValue("0054")]
            [DescriptionValue("Payment started")]
            PAYMENT_STARTED,
            [StringValue("0055")]
            [DescriptionValue("Value not entered")]
            VALUE_NOT_ENTERED,
            [StringValue("0056")]
            [DescriptionValue("Void key error")]
            VOID_KEY_ERROR,
            [StringValue("0057")]
            [DescriptionValue("Error correction key error")]
            EC_KEY_ERROR,
            [StringValue("0058")]
            [DescriptionValue("Not enough money")]
            NOT_ENOUGH_MONEY,
            [StringValue("0059")]
            [DescriptionValue("Invoice zero")]
            INVOICE_ZERO,
            [StringValue("0060")]
            [DescriptionValue("Cash payment error")]
            CASH_PAYMENT_ERROR,
            [StringValue("0061")]
            [DescriptionValue("Not enough currency")]
            NOT_ENOUGH_CURRENCY,
            [StringValue("0062")]
            [DescriptionValue("Credit payment error")]
            CREDIT_PAYMENT_ERROR,
            [StringValue("0063")]
            [DescriptionValue("Currency payment error")]
            CURRENCY_PAYMENT_ERROR,
            [StringValue("0064")]
            [DescriptionValue("No currency")]
            NO_CURRENCY,
            [StringValue("0065")]
            [DescriptionValue("Too many items")]
            TOO_MANY_ITEMS,
            [StringValue("0066")]
            [DescriptionValue("Disk almost full")]
            DISK_ALMOST_FULL,
            [StringValue("0067")]
            [DescriptionValue("No record")]
            NO_RECORD,
            [StringValue("0068")]
            [DescriptionValue("No receipts")]
            NO_RECEIPTS,
            [StringValue("0069")]
            [DescriptionValue("Not found")]
            NOT_FOUND,
            [StringValue("0070")]
            [DescriptionValue("Password invalid")]
            PASSWORD_INVALID,
            [StringValue("0071")]
            [DescriptionValue("Already used")]
            ERROR_ALREADY_USED,
            [StringValue("0072")]
            [DescriptionValue("Tax not set")]
            ERROR_TAX_NOT_SET,
            [StringValue("0073")]
            [DescriptionValue("Limit too large")]
            ERROR_LIMIT_TOO_LARGE,
            [StringValue("0074")]
            [DescriptionValue("Price too large")]
            ERROR_PRICE_TOO_LARGE,
            [StringValue("0075")]
            [DescriptionValue("Price equal zero")]
            ERROR_PRICE_EQUAL_ZERO,
            [StringValue("0076")]
            [DescriptionValue("Rate zero")]
            ERROR_RATE_ZERO,
            [StringValue("0077")]
            [DescriptionValue("Barcode already used")]
            ERROR_BARCODE_ALREADY_USED,
            [StringValue("0078")]
            [DescriptionValue("Invalid department")]
            ERROR_INVALID_DEPARTMENT,
            [StringValue("0079")]
            [DescriptionValue("No item found")]
            ERROR_NO_ITEM_FOUND,
            [StringValue("0080")]
            [DescriptionValue("Too many items")]
            ERROR_TOO_MANY_ITEMS,
            [StringValue("0081")]
            [DescriptionValue("PLU item unused")]
            ERROR_PLU_ITEM_UNUSED,
            [StringValue("0082")]
            [DescriptionValue("Quantity too large")]
            ERROR_QTY_TOO_LARGE,
            [StringValue("0083")]
            [DescriptionValue("Invalid percent rate")]
            ERROR_INVALID_PERCENT_RATE,
            [StringValue("0084")]
            [DescriptionValue("Argument invalid")]
            ERROR_ARGUMENT_INVALID,
            [StringValue("0085")]
            [DescriptionValue("Total tax error")]
            ERROR_TOTAL_TAX_ERROR,
            [StringValue("0109")]
            [DescriptionValue("End of day report is not taken in last 24 hours")]
            ERROR_NEED_TO_TAKE_END_OF_DAY_REPORT
        }

        private static RESPONSE_CODE m_enumResponseCode = 0;

        public static RESPONSE_CODE enumResponse
        {
            get
            {
                return m_enumResponseCode;
            }
            set
            {
                m_enumResponseCode = value;
            }
        }

        public static string strResponseDescription
        {
            get
            {
                FieldInfo xFieldInfo = typeof(RESPONSE_CODE).GetFields()[(int)m_enumResponseCode + 1];
                DescriptionValueAttribute[] xaDescriptionAttribute = xFieldInfo.GetCustomAttributes(typeof(DescriptionValueAttribute), false) as DescriptionValueAttribute[];

                if (xaDescriptionAttribute.Length > 0)
                    return xaDescriptionAttribute[0].strDescription;

                return string.Empty;
            }
        }

        public static string strResponseCode
        {
            get
            {
                FieldInfo xFieldInfo = typeof(RESPONSE_CODE).GetFields()[(int)m_enumResponseCode + 1];
                StringValueAttribute[] xaStringAttribute = xFieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

                if (xaStringAttribute.Length > 0)
                    return xaStringAttribute[0].strValue;

                return string.Empty;
            }
        }

        /// <summary>
        /// Parses the supplied enum and string value to find an associated enum value (case sensitive).
        /// </summary>
        /// <param name="stringValue">String value.</param>
        /// <returns>Enum value associated with the string value, or null if not found.</returns>
        public static bool Parse(ref string prm_strResponseCode)
        {
            enumResponse = RESPONSE_CODE.UNEXPECTED_ERROR;

            if (string.IsNullOrEmpty(prm_strResponseCode))
            {
                return false;
            }

            if (prm_strResponseCode.Length > 4)
            {
                return false;
            }

            return bParseResponseCode(ref prm_strResponseCode);
        }

        /// <summary>
        /// Parses the supplied enum and string value to find an associated enum value.
        /// </summary>
        /// <param name="prm_strResponseCode">Response code as string</param>
        private static bool bParseResponseCode(ref string prm_strResponseCode)
        {
            bool bReturnValue = false;
            string strAttributeValue = string.Empty;

            //Look for our string value associated with fields in this enum
            foreach (FieldInfo xFieldInfo in typeof(RESPONSE_CODE).GetFields())
            {
                //Check for our custom attribute
                StringValueAttribute[] xaStringValueAttribute = xFieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

                if (xaStringValueAttribute.Length > 0)
                    strAttributeValue = xaStringValueAttribute[0].strValue;

                //Check for equality then select actual enum value.
                if (string.Compare(strAttributeValue, prm_strResponseCode, false) == 0)
                {
                    enumResponse = (RESPONSE_CODE)Enum.Parse(typeof(RESPONSE_CODE), xFieldInfo.Name);
                    break;
                }
            }

            if (prm_strResponseCode.EndsWith("0000") || prm_strResponseCode.Equals("3030"))
            {
                bReturnValue = true;
            }

            return bReturnValue;
        }
    }
}
