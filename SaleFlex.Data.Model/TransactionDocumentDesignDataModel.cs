using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    public class TransactionDocumentDesignDataModel
    {
        public long lId { get; set; }
        public long lNo { get; set; }
        public string strName { get; set; }
        public long lDocumentTypeId { get; set; }
        public TransactionDocumentTypeDataModel xTransactionDocumentTypeDataModel { get; set; }
        public int iRowLength { get; set; }
        public int iMaxDynamicLinesNumber { get; set; }
        public int iDateColumn { get; set; }
        public int iDateRow { get; set; }
        public int iTimeColumn { get; set; }
        public int iTimeRow { get; set; }
        public int iCustomerNameColumn { get; set; }
        public int iCustomerNameRow { get; set; }
        public int iCustomerAddress1Column { get; set; }
        public int iCustomerAddress1Row { get; set; }
        public int iCustomerAddress2Column { get; set; }
        public int iCustomerAddress2Row { get; set; }
        public int iCustomerAddress3Column { get; set; }
        public int iCustomerAddress3Row { get; set; }
        public int iCustomerTaxOfficeColumn { get; set; }
        public int iCustomerTaxOfficeRow { get; set; }
        public int iCustomerTaxNoColumn { get; set; }
        public int iCustomerTaxNoRow { get; set; }
        public int iProductMaxDynamicLinesNumber { get; set; }
        public int iProductStartRow { get; set; }
        public int iProductNameColumn { get; set; }
        public int iProductVatColumn { get; set; }
        public int iProductVatRow { get; set; }
        public int iProductPriceOfOneColumn { get; set; }
        public int iProductQuantityColumn { get; set; }
        public int iProductTotalPriceColumn { get; set; }
        public int iTotalVatColumn { get; set; }
        public int iTotalVatRow { get; set; }
        public int iTotalPriceInDigitsColumn { get; set; }
        public int iTotalPriceInDigitsRow { get; set; }
        public int iTotalPriceInWordsColumn { get; set; }
        public int iTotalPriceInWordsRow { get; set; }
        public int iPaymentStartRow { get; set; }
        public int iPaymentNameColumn { get; set; }
        public int iPaymentAmountColumn { get; set; }
        public int iCashierColumn { get; set; }
        public int iCashierRow { get; set; }
        public int iDocumentInfoColumn { get; set; }
        public int iDocumentInfoRow { get; set; }
        public int iDocumentMessage1Column { get; set; }
        public int iDocumentMessage1Row { get; set; }
        public int iDocumentMessage2Column { get; set; }
        public int iDocumentMessage2Row { get; set; }
        public int iPageNumberColumn { get; set; }
        public int iPageNumberRow { get; set; }
        public int iCashRegisterNumberColumn { get; set; }
        public int iCashRegisterNumberRow { get; set; }
    }
}
