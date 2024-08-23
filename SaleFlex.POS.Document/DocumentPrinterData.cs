using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.POS.Document
{
    public class DocumentPrinterData
    {
        const int iDateLength = 10;
        const int iTimeLength = 5;
        const int iCustomerNameSurnameLength = 40;
        const int iCustomerAddress1Length = 40;
        const int iCustomerAddress2Length = 40;
        const int iCustomerAddress3Length = 40;
        const int iCustomerTaxOfficeLength = 20;
        const int iCustomerTaxNoLength = 15;
        const int iProductNameLength = 32;
        const int iProductVatLength = 3;
        const int iProductPriceOfOneLength = 10;
        const int iProductQuantityLength = 7;
        const int iProductTotalPriceLength = 13;
        const int iTotalVatLength = 13;
        const int iTotalPriceInDigitsLength = 20;
        const int iTotalPriceInWordsLength = 30;
        const int iPaymentNameLength = 15;
        const int iPaymentAmountLength = 13;
        const int iCashierLength = 60;
        const int iDocumentInfoLength = 40;
        const int iDocumentMessage1Length = 60;
        const int iDocumentMessage2Length = 60;
        const int iCashRegisterNumberLength = 5;

        string[] strDocumentDataLines = new string[60];
        string[] strTempDataLines = new string[60];

        private int _iMaxLinesNumber;

        public int iMaxLinesNumber
        {
            get { return _iMaxLinesNumber; }
            set { _iMaxLinesNumber = value; }
        }

        public void vCheckAndGetString(string prm_strValue, int prm_iLength, int prm_iColumn, int prm_iRowLength, int prm_iRow, string prm_strFormat, bool prm_bPadRightSelection = true)
        {
            string strReturnValue = string.Empty;

            if (prm_strValue != null)
            {
                if (prm_strFormat != null)
                {
                    prm_strValue = string.Format(prm_strFormat, prm_strValue);
                }

                if (prm_strValue.Length > prm_iLength)
                {
                    strReturnValue = prm_strValue.Substring(0, prm_iLength);
                }

                if (prm_bPadRightSelection)
                {
                    strReturnValue = prm_strValue.PadRight(prm_iLength, ' ');
                }
                else
                {
                    strReturnValue = prm_strValue.PadLeft(prm_iLength, ' ');

                }
                if (prm_iColumn + prm_iLength > prm_iRowLength)
                {
                    prm_iLength = prm_iRowLength - prm_iColumn;

                    strReturnValue = strReturnValue.Substring(0, prm_iLength);
                }
            }

            else
            {
                for (int iIndex = 0; iIndex < prm_iLength; iIndex++)
                {
                    strReturnValue += " ";
                }
            }

            strDocumentDataLines[prm_iRow] = strDocumentDataLines[prm_iRow].Substring(0, prm_iColumn) + strReturnValue + strDocumentDataLines[prm_iRow].Substring(prm_iColumn + prm_iLength, prm_iRowLength - (prm_iColumn + prm_iLength));

        }


        public string[] strPrepareDocumentData(TransactionDataModel prm_xTransactionDataModel)
        {

            TransactionDocumentDesignDataModel xTransactionDocumentDesignDataModel = Dao.xGetInstance().xGetTransactionDocumentDesign(prm_xTransactionDataModel.xTransactionHeadDataModel.xTransactionDocumentTypeDataModel.iId);


            string strDocumentHeaderLines = string.Empty;
            int iMaxDynamicLinesNumber = xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber;
            iMaxLinesNumber = iMaxDynamicLinesNumber;
            int iRowLength = xTransactionDocumentDesignDataModel.iRowLength;
            strDocumentDataLines = new string[iMaxDynamicLinesNumber];
            strTempDataLines = new string[iMaxDynamicLinesNumber];

            for (int iIndex = 0; iIndex < iMaxDynamicLinesNumber; iIndex++)
            {
                for (int iIndex2 = 0; iIndex2 < iRowLength; iIndex2++)
                {
                    strDocumentDataLines[iIndex] += " ";
                    strTempDataLines[iIndex] += " ";
                }
            }

            int iPageCount = 0;
            int iPageNumber = 0;
            int iProductDataLineCount = 0;
            decimal decTransmittedTotal = 0m;

            if (xTransactionDocumentDesignDataModel != null)
            {

                bool bDateWillPrint = xTransactionDocumentDesignDataModel.iDateColumn >= 0 && xTransactionDocumentDesignDataModel.iDateRow >= 0;
                bool bTimeWillPrint = xTransactionDocumentDesignDataModel.iTimeColumn >= 0 && xTransactionDocumentDesignDataModel.iTimeRow >= 0;

                if (prm_xTransactionDataModel.xTransactionHeadDataModel.xTransactionDocumentTypeDataModel.iNo == (int)EnumDocumentType.Waybill) // BELGE BAŞLIĞI (İRSALİYE)
                {
                    string strDocumentHeader = LabelTranslations.strGet("WayBill");
                    strDocumentHeaderLines += strDocumentHeader.strCenterAlignment(iRowLength);
                }

                else if (prm_xTransactionDataModel.xTransactionHeadDataModel.xTransactionDocumentTypeDataModel.iNo == (int)EnumDocumentType.Invoice) //BELGE BAŞLIĞI(FATURA)
                {
                    string strDocumentHeader = LabelTranslations.strGet("Invoice");
                    strDocumentHeaderLines += strDocumentHeader.strCenterAlignment(iRowLength);
                }

                else if (prm_xTransactionDataModel.xTransactionHeadDataModel.xTransactionDocumentTypeDataModel.iNo == (int)EnumDocumentType.Return) // BELGE BAŞLIĞI (GİDER PUSULASI)
                {
                    string strDocumentHeader = LabelTranslations.strGet("Return");
                    strDocumentHeaderLines += strDocumentHeader.strCenterAlignment(iRowLength);
                }
                strDocumentDataLines[0] = strDocumentHeaderLines;

                if (bDateWillPrint == true)
                {
                    string strDate = DateTime.Now.ToString("dd.MM.yyyy");

                    vCheckAndGetString(strDate, iDateLength, xTransactionDocumentDesignDataModel.iDateColumn, iRowLength, xTransactionDocumentDesignDataModel.iDateRow, null, false);

                    strTempDataLines[xTransactionDocumentDesignDataModel.iDateRow] = strDocumentDataLines[xTransactionDocumentDesignDataModel.iDateRow];
                }

                else
                {
                    strDocumentDataLines[xTransactionDocumentDesignDataModel.iDateRow] = strDocumentDataLines[xTransactionDocumentDesignDataModel.iDateRow];
                }

                if (bTimeWillPrint == true)
                {
                    string strTime = DateTime.Now.ToString("HH:mm:ss");

                    vCheckAndGetString(strTime, iTimeLength, xTransactionDocumentDesignDataModel.iTimeColumn, iRowLength, xTransactionDocumentDesignDataModel.iTimeRow, null, false);

                    strTempDataLines[xTransactionDocumentDesignDataModel.iTimeRow] = strDocumentDataLines[xTransactionDocumentDesignDataModel.iTimeRow];
                }
                else
                {
                    strDocumentDataLines[xTransactionDocumentDesignDataModel.iTimeRow] = strDocumentDataLines[xTransactionDocumentDesignDataModel.iTimeRow];
                }

                string strName = string.Empty;
                string strLasName = string.Empty;
                string strAddressLine1 = string.Empty;
                string strAddressLine2 = string.Empty;
                string strAddressLine3 = string.Empty;
                string strCustomerTaxOffice = string.Empty;
                string strCustomerTaxNumber = string.Empty;

                if (prm_xTransactionDataModel.xCustomerDataModel != null)
                {
                    strName = prm_xTransactionDataModel.xCustomerDataModel.strName;
                    strLasName = prm_xTransactionDataModel.xCustomerDataModel.strLasName;
                    strAddressLine1 = prm_xTransactionDataModel.xCustomerDataModel.strAddressLine1;
                    strAddressLine2 = prm_xTransactionDataModel.xCustomerDataModel.strAddressLine2;
                    strAddressLine3 = prm_xTransactionDataModel.xCustomerDataModel.strAddressLine3;
                    strCustomerTaxOffice = prm_xTransactionDataModel.xCustomerDataModel.strTaxOffice;
                    strCustomerTaxNumber = prm_xTransactionDataModel.xCustomerDataModel.strTaxNumber;


                    vCheckAndGetString((strName + " " + strLasName), iCustomerNameSurnameLength, xTransactionDocumentDesignDataModel.iCustomerNameColumn, iRowLength, xTransactionDocumentDesignDataModel.iCustomerNameRow, null, true);

                    vCheckAndGetString(strAddressLine1, iCustomerAddress1Length, xTransactionDocumentDesignDataModel.iCustomerAddress1Column, iRowLength, xTransactionDocumentDesignDataModel.iCustomerAddress1Row, null, true);

                    vCheckAndGetString(strAddressLine2, iCustomerAddress2Length, xTransactionDocumentDesignDataModel.iCustomerAddress2Column, iRowLength, xTransactionDocumentDesignDataModel.iCustomerAddress2Row, null, true);

                    vCheckAndGetString(strAddressLine3, iCustomerAddress3Length, xTransactionDocumentDesignDataModel.iCustomerAddress3Column, iRowLength, xTransactionDocumentDesignDataModel.iCustomerAddress3Row, null, true);

                    vCheckAndGetString(strCustomerTaxOffice, iCustomerTaxOfficeLength, xTransactionDocumentDesignDataModel.iCustomerTaxOfficeColumn, iRowLength, xTransactionDocumentDesignDataModel.iCustomerTaxOfficeRow, null, true);

                    vCheckAndGetString(strCustomerTaxNumber, iCustomerTaxNoLength, xTransactionDocumentDesignDataModel.iCustomerTaxNoColumn, iRowLength, xTransactionDocumentDesignDataModel.iCustomerTaxNoRow, null, true);

                }
                int iIndex = 0;

                foreach (var xTransactionDetail in prm_xTransactionDataModel.xListTransactionDetailDataModel)
                {
                    iIndex = ((iPageNumber * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iProductStartRow + iProductDataLineCount);

                    if (xTransactionDetail.bCanceled == true)
                        continue;

                    string strProductName = string.Empty;
                    decimal decQuantityOfProduct = 0m;
                    decimal decTotalPrice = 0m;
                    decimal decPriceOfOneProduct = 0m;

                    int iVatRate = 0;

                    if (xTransactionDetail.xDepartmentDataModel != null)
                    {
                        strProductName = xTransactionDetail.xDepartmentDataModel.strName;
                        iVatRate = xTransactionDetail.xDepartmentDataModel.xVat.iRate;
                    }
                    else if (xTransactionDetail.xPluDataModel != null)
                    {
                        if (xTransactionDetail.xPluDataModel.xListPluBarcodeDataModel[0].strBarcode != string.Empty && xTransactionDetail.xPluDataModel.xListPluBarcodeDataModel[0].strBarcode.Length > 0)
                            strProductName = string.Format("{0} [{1}]", xTransactionDetail.xPluDataModel.strName, xTransactionDetail.xPluDataModel.xListPluBarcodeDataModel[0].strBarcode);
                        else
                            strProductName = xTransactionDetail.xPluDataModel.strName;
                        iVatRate = xTransactionDetail.xPluDataModel.xVat.iRate;
                    }
                    else
                    {
                        return null;
                    }

                    decQuantityOfProduct = xTransactionDetail.decQuantity;
                    decPriceOfOneProduct = xTransactionDetail.decPrice;
                    decTotalPrice = xTransactionDetail.decTotalPrice;

                    vCheckAndGetString(strProductName, iProductNameLength, xTransactionDocumentDesignDataModel.iProductNameColumn, iRowLength, iIndex, null, true);

                    vCheckAndGetString((iVatRate.ToString()), iProductVatLength, xTransactionDocumentDesignDataModel.iProductVatColumn, iRowLength, iIndex, "%{0}", false);

                    vCheckAndGetString(string.Format("{0:#,0.000}", decQuantityOfProduct), iProductQuantityLength, xTransactionDocumentDesignDataModel.iProductQuantityColumn, iRowLength, iIndex, null, false);

                    vCheckAndGetString(string.Format("{0:#,0.00} TL", decPriceOfOneProduct), iProductPriceOfOneLength, xTransactionDocumentDesignDataModel.iProductPriceOfOneColumn, iRowLength, iIndex, null, false);

                    vCheckAndGetString(string.Format("{0:#,0.00} TL", decTotalPrice), iProductTotalPriceLength, xTransactionDocumentDesignDataModel.iProductTotalPriceColumn, iRowLength, iIndex, null, false);

                    iIndex++;

                    decTransmittedTotal += xTransactionDetail.decTotalPrice;

                    iProductDataLineCount++;


                    if (iProductDataLineCount >= xTransactionDocumentDesignDataModel.iProductMaxDynamicLinesNumber && iProductDataLineCount + (iPageNumber * xTransactionDocumentDesignDataModel.iProductMaxDynamicLinesNumber) != prm_xTransactionDataModel.xListTransactionDetailDataModel.Count)
                    {

                        vCheckAndGetString("AKTARILAN TOPLAM : " + decTransmittedTotal.ToString(), 12, 20, iRowLength, iIndex + 1, null, true);

                        iPageNumber++;

                        vCheckAndGetString("SAYFA NO: " + iPageNumber.ToString(), 5, xTransactionDocumentDesignDataModel.iPageNumberColumn, iRowLength, (iPageCount * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iPageNumberRow, null, true);

                        iPageCount++;

                        Array.Resize(ref strDocumentDataLines, ((iPageNumber + 1) * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber));
                        //strDocumentDataLines PageNumber a göre yeniden boyutlandırılıyor.
                        //strDocumentDataLines is resized according to page number
                        for (int iAssignmentIndex = 0; iAssignmentIndex < strTempDataLines.Length; iAssignmentIndex++)
                        {

                            //strTempDataLine are kept data liner that required on every page
                            //The data in strTempDataLineda is assigned to other pages on DocumentDataLine
                            strDocumentDataLines[(iPageNumber * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + iAssignmentIndex] = strTempDataLines[iAssignmentIndex];
                        }

                        vCheckAndGetString("AKTARILAN TOPLAM : " + decTransmittedTotal, 12, 20, iRowLength, (iPageNumber * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iProductStartRow - 1, null, true);

                        iProductDataLineCount = 0;

                    }
                }

                decimal decReceiptVatRate = 0m;
                decimal decReceiptTotalPrice = 0m;

                if (prm_xTransactionDataModel.xTransactionHeadDataModel != null)
                {
                    decReceiptTotalPrice = prm_xTransactionDataModel.xTransactionHeadDataModel.decReceiptTotalPrice;
                    decReceiptVatRate = prm_xTransactionDataModel.xTransactionHeadDataModel.decReceiptTotalVat;

                    if (xTransactionDocumentDesignDataModel.iTotalPriceInDigitsRow != -1)
                        vCheckAndGetString(string.Format("TOPLAM TUTAR: {0:#,0.00} TL", decReceiptTotalPrice), iTotalPriceInDigitsLength, xTransactionDocumentDesignDataModel.iTotalPriceInDigitsColumn, iRowLength, (iPageNumber * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iTotalPriceInDigitsRow, null, false);
                    if (xTransactionDocumentDesignDataModel.iTotalPriceInWordsRow != -1)
                        vCheckAndGetString(strConvertAmountToWords(decReceiptTotalPrice), iTotalPriceInWordsLength, xTransactionDocumentDesignDataModel.iTotalPriceInWordsColumn, iRowLength, (iPageNumber * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iTotalPriceInWordsRow, null, true);

                    if (xTransactionDocumentDesignDataModel.iTotalVatRow != -1)
                        vCheckAndGetString(string.Format("TOPLAM KDV: {0:#,0.00} TL", decReceiptVatRate), iTotalVatLength, xTransactionDocumentDesignDataModel.iTotalVatColumn, iRowLength, (iPageNumber * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iTotalVatRow, null, false);

                }

                int iPaymentStartingRowIndex = xTransactionDocumentDesignDataModel.iPaymentStartRow;

                foreach (var xTransactionPayment in prm_xTransactionDataModel.xListPaymentDataModel)
                {
                    string strTypeName = string.Empty;
                    decimal decAmount = 0m;

                    if (xTransactionPayment.xPaymentTypeDataModel != null)
                    {

                        strTypeName = xTransactionPayment.xPaymentTypeDataModel.strTypeName;
                        decAmount = xTransactionPayment.decAmount;

                        if (iPaymentStartingRowIndex != -1)
                        {
                            vCheckAndGetString(strTypeName, iPaymentNameLength, xTransactionDocumentDesignDataModel.iPaymentNameColumn, iRowLength, (iPageNumber * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + iPaymentStartingRowIndex, null);

                            vCheckAndGetString(string.Format("{0:#,0.00} TL", decAmount), iPaymentAmountLength, xTransactionDocumentDesignDataModel.iPaymentAmountColumn, iRowLength, (iPageNumber * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + iPaymentStartingRowIndex, null, false);

                            iPaymentStartingRowIndex++;
                        }
                    }
                }
            }

            string strCashierName = string.Empty;
            string strCashierLastName = string.Empty;
            string strCashierIdentityNumber = string.Empty;

            if (prm_xTransactionDataModel.xCashierDataModel != null)
            {

                string strCashierNo = Convert.ToString(prm_xTransactionDataModel.xCashierDataModel.iNo) != null ? string.Format("{0}{1}", prm_xTransactionDataModel.xCashierDataModel.iNo, "/") : string.Empty;

                strCashierName = prm_xTransactionDataModel.xCashierDataModel.strName != null ? string.Format("{0}{1}", prm_xTransactionDataModel.xCashierDataModel.strName, " ") : string.Empty;

                strCashierLastName = prm_xTransactionDataModel.xCashierDataModel.strLastName != null ? string.Format("{0}{1}", prm_xTransactionDataModel.xCashierDataModel.strLastName, "/") : string.Empty;

                strCashierIdentityNumber = prm_xTransactionDataModel.xCashierDataModel.strIdentityNumber != null ? string.Format("{0}{1}", prm_xTransactionDataModel.xCashierDataModel.strIdentityNumber, "") : string.Empty;
                string CashierDetails = string.Format("{0}{1}{2}{3}", strCashierNo, strCashierName, strCashierLastName, strCashierIdentityNumber);

                for (int iPageNum = 0; iPageNum <= iPageNumber; iPageNum++)
                {
                    vCheckAndGetString(CashierDetails, iCashierLength, xTransactionDocumentDesignDataModel.iCashierColumn, iRowLength, (iPageNum * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iCashierRow, null, true);

                }


                strTempDataLines[xTransactionDocumentDesignDataModel.iCashierRow] = strDocumentDataLines[xTransactionDocumentDesignDataModel.iCashierRow];
            }


            string strTransactionNo = string.Empty;

            if (prm_xTransactionDataModel.xTransactionHeadDataModel != null)
            {

                strTransactionNo = prm_xTransactionDataModel.xTransactionHeadDataModel.strTransactionNo;

                for (int iPageNum = 0; iPageNum <= iPageNumber; iPageNum++)
                {
                    vCheckAndGetString(string.Format("ISLEM NO : {0}", strTransactionNo), iDocumentInfoLength, xTransactionDocumentDesignDataModel.iDocumentInfoColumn, iRowLength, (iPageNum * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iDocumentInfoRow, null, true);
                }

                strTempDataLines[xTransactionDocumentDesignDataModel.iDocumentInfoRow] = strDocumentDataLines[xTransactionDocumentDesignDataModel.iDocumentInfoRow];
            }

            int iCashRegisterId = Dao.xGetInstance().iGetPosId();

            for (int iPageNum = 0; iPageNum <= iPageNumber; iPageNum++)
            {
                vCheckAndGetString("KASA NO:" + iCashRegisterId, iCashRegisterNumberLength, xTransactionDocumentDesignDataModel.iCashRegisterNumberColumn, iRowLength, (iPageNum * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iCashRegisterNumberRow, null, true);
            }

            vCheckAndGetString("TESEKKUR EDERIZ", iDocumentMessage1Length, xTransactionDocumentDesignDataModel.iDocumentMessage1Column, iRowLength, (iPageNumber * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iDocumentMessage1Row, null, true);

            vCheckAndGetString("YINE BEKLERIZ", iDocumentMessage2Length, xTransactionDocumentDesignDataModel.iDocumentMessage2Column, iRowLength, (iPageNumber * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iDocumentMessage2Row, null, true);

            vCheckAndGetString("SAYFA NO: " + (iPageNumber + 1).ToString(), 5, xTransactionDocumentDesignDataModel.iPageNumberColumn, iRowLength, (iPageNumber * xTransactionDocumentDesignDataModel.iMaxDynamicLinesNumber) + xTransactionDocumentDesignDataModel.iPageNumberRow, null, true);

            for (int iLineIndex1 = 0; iLineIndex1 < strDocumentDataLines.Length; iLineIndex1++)
            {
                strDocumentDataLines[iLineIndex1] += Environment.NewLine;
            }

            return strDocumentDataLines;
        }

        private string strConvertAmountToWords(decimal prm_decAmount)
        {
            string strAmount = prm_decAmount.ToString("F2").Replace('.', ',');  // Replace('.',',') ondalık ayracının . olma durumu için            
            string strInteger = strAmount.Substring(0, strAmount.IndexOf(',')); //tutarın tam kısmı
            string strFloating = strAmount.Substring(strAmount.IndexOf(',') + 1, 2);
            string strWords = "";

            string[] Ones = { "", "BİR", "İKİ", "ÜÇ", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] Tens = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] Thousands = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

            int iGroupNumber = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
            //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

            strInteger = strInteger.PadLeft(iGroupNumber * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

            string strGroupValue;
            int iLength = 0;
            for (int i = 0; i < iGroupNumber * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
            {
                strGroupValue = "";

                if (strInteger.Substring(i, 1) != "0")
                    strGroupValue += Ones[Convert.ToInt32(strInteger.Substring(i, 1))] + "YÜZ"; //yüzler                

                if (strGroupValue == "BİRYÜZ") //biryüz düzeltiliyor.
                    strGroupValue = "YÜZ";

                strGroupValue += Tens[Convert.ToInt32(strInteger.Substring(i + 1, 1))]; //onlar

                strGroupValue += Ones[Convert.ToInt32(strInteger.Substring(i + 2, 1))]; //birler                

                if (strGroupValue != "") //binler
                    strGroupValue += Thousands[i / 3];

                if (strGroupValue == "BİRBİN") //birbin düzeltiliyor.
                    strGroupValue = "BİN";

                strWords += strGroupValue + " ";
                iLength = strGroupValue.Length;
            }


            if (strWords != "")
                strWords += "TL ";

            int yaziUzunlugu = strWords.Length;

            //strWords = strWords.Substring(0, yaziUzunlugu - iLength);

            if (strFloating.Substring(0, 1) != "0") //kuruş onlar
                strWords += Tens[Convert.ToInt32(strFloating.Substring(0, 1))];

            if (strFloating.Substring(1, 1) != "0") //kuruş birler
                strWords += Ones[Convert.ToInt32(strFloating.Substring(1, 1))];

            if (strWords.Length > yaziUzunlugu)
                strWords += " KURUŞ";
            else
                strWords += "SIFIR KURUŞ";

            return strWords;
        }
    }
}
