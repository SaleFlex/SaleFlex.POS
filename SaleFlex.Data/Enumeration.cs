﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data
{
    public enum enumFormType
    {
        NONE = 0,
        SALE = 1,
        LOGIN,
        LOGIN_EXT,
        LOGIN_SERVICE,
        SERVICE,
        SETTING,
        PARAMETER,
        REPORT,        
        FUNCTION,
        CUSTOMER,
        VOID,
        REFUND,
        STOCK,
        END_OF_DAY
        
    }

    public enum enumPaymentType
    {
        NONE = 0,
        CASH = 1,
        CREDIT_CARD = 2,
        CHECK = 3,
        CREDIT_NOCARD = 4,
        PREPAID_CARD = 5,
        MOBILE = 6,
        BONUS = 7,
        EXCHANGE = 8,
        CHARGE_SALE = 9,    // VERESİYE
        OTHER = 10
    }

    public enum enumDocumentState
    {
        CLOSED,         // Kapalı Belge
        SUSPENDED,      // Askıda Belge
        OPENED          // Açık Belge
    }

    public enum enumDocumentResult
    {
        NONE = 0,
        SUCCESSED,
        CANCELED_BY_CASHIER,                            // Kasiyer tarafindan iptal edildi
        CANCELED_BY_APPLICATION,                        // Uygulama tarafindan iptal edildi. Belge geçişi sırasında.
        CANCELED_BY_APPLICATION_AFTER_POWER_ON,         // Program acilirken yarim kalan belgeden dolayi iptal edildi 
        CANCELED_BY_APPLICATION_BECAUSE_OF_HANGING,     // Askiya alindigindan dolayi iptal edildi
        SUSPENDED                                       // Askıda
    }

    public enum enumDocumentType
    {
        None = 0,
        FiscalReceipt,                  // Mali Fiş
        NoneFiscalReceipt,              // Mali Olmayan Fiş
        Invoice,                        // Matbu Fatura
        EInvoice,                       // E-Fatura
        EArchiveInvoice,                // E-Arşıv Faturası
        DiplomaticInvoice,              // Diplomatik Satış
        Waybill,                        // İrsaliye
        PaidOut,                        // Kasa Çıkış
        ReceivedOnAccount,              // Kasa Giriş
        Return,                         // İade
        Expense                         // Gider Pusulası
    };

    public enum enumErrorCode
    {
        NONE = 0,
        DEPARTMENT_NOT_FOUND = 1,
        CAN_NOT_INSERT_TRANSACTION,
        CAN_NOT_START_RECEIPT,
        NEED_CASHIER_LOGIN,
        PLU_NOT_FOUND,
        INSUFFICIENT_STOCK,
        CAN_NOT_CLOSE_RECEIPT,
        PAYMENT_TYPE_ERROR,
        PAYMENT_NOT_POSSIBLE,
        CAN_NOT_CANCEL_TRANSACTION,
        CAN_NOT_CANCEL_DOCUMENT,
        SUBTOTAL_NOT_POSSIBLE,
        SUSPEND_QUEUE_FULL,
        SUSPEND_NOT_FOUND,
        NEED_SUSPEND

    }
}
