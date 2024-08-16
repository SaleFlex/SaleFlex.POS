using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.UserInterface.Controls;
using SaleFlex.Windows;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.POS.Document
{
    public class DocumentPrint
    {
        public string prop_strPrinterName
        {
            get
            {
                return CommonProperty.prop_strPrinterName;
            }
        }

        public bool bPrint(TransactionDataModel prm_xTransactionDataModel)
        {
            try
            {
                DocumentPrinterData xDocumentPrinterData = new DocumentPrinterData();

                string[] strDocumentDataLines = xDocumentPrinterData.strPrepareDocumentData(prm_xTransactionDataModel);

                long iPrinterId = Dao.xGetInstance().lGetPrinterId();

                switch (iPrinterId)
                {
                    case 1://Receipt Printer 

                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x18");//Cancels printer buffer and Initialize printer

                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x40");// Initialize printer

                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x1D\x74\x01");//CODE PAGE 437 IBM CHARACTERS

                        //RawPrinterHelper.SendStringToPrinter(prop_strPrinterName, "\x1B\x1D\x74\x0C");//sets Turkish CodePage

                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x4D");// 7 X 9 FONT, 42 CHAR / LINE
                        //Ğ
                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x26\x00\x7C\x7C\x80\x1C\xA2\x08\xA2\x08\xA2\x0C");
                        //Ş                    
                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x26\x00\x7E\x7E\x80\x40\xA4\x00\xA6\x00\xA4\x18");
                        //İ
                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x26\x00\x7D\x7D\x80\x00\x22\x00\xBE\x00\x22\x00");
                        //ğ 
                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x26\x00\x7B\x7B\x80\x18\xA5\x00\xA5\x00\xA5\x1A");
                        //ş                
                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x26\x00\x60\x60\x80\x12\x00\x2A\x01\x2A\x00\x24");
                        //ı                
                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x26\x00\x5E\x5E\x80\x00\x00\x00\x3E\x00\x00\x00");
                        //ç  
                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x26\x00\x3F\x3F\x80\x18\x00\x24\x02\x24\x00\x24");
                        //Ü
                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x26\x00\x3C\x3C\x80\x00\xBE\x00\x02\x00\xBE\x00");
                        //Ö
                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x26\x00\x60\x60\x80\x1C\xA2\x00\x22\x00\xA2\x1C");
                        //Ç
                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x26\x00\x2D\x2D\x80\x78\x84\x00\x86\x00\x84\x00");

                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x1B\x25\x01");//Enables download character set

                        RawPrinterApi.SendStringToPrinter(prop_strPrinterName, "\x14");//Resets the printing magnified in character width

                        if (strDocumentDataLines == null)

                            return false;

                        for (int iDocumentLineIndex = 0; iDocumentLineIndex < strDocumentDataLines.Length; iDocumentLineIndex = iDocumentLineIndex + xDocumentPrinterData.iMaxLinesNumber)
                        {
                            string[] strDocumentLines = new string[xDocumentPrinterData.iMaxLinesNumber];

                            Array.Copy(strDocumentDataLines, iDocumentLineIndex, strDocumentLines, 0, xDocumentPrinterData.iMaxLinesNumber);

                            CustomMessageBox.Show(LabelTranslations.strGet("InsertPaper"));
                            {

                                for (int i = 0; i < strDocumentLines.Length; i++)
                                {
                                    strDocumentLines[i] = strDocumentLines[i].Replace('Ğ', (char)124).Replace('İ', (char)125).Replace('Ş', (char)126).Replace('ğ', (char)123).Replace('ş', (char)96).Replace('ı', (char)94).Replace('ç', (char)63).Replace('Ç', (char)45).Replace('Ö', (char)96).Replace('Ü', (char)60).Replace('ü', (char)62);

                                    strDocumentLines[i] = new string(Encoding.GetEncoding(857).GetBytes(strDocumentLines[i]).Select(b => (char)b).ToArray());

                                }

                                RawPrinterApi.SendStringToPrinter(prop_strPrinterName, string.Join("", strDocumentLines));

                                if (prm_xTransactionDataModel.xTransactionHeadDataModel.xTransactionDocumentTypeDataModel.iNo == (int)enumDocumentType.Waybill)
                                {
                                    CustomMessageBox.Show(LabelTranslations.strGet("WaybillPrinted"));
                                }
                                else if (prm_xTransactionDataModel.xTransactionHeadDataModel.xTransactionDocumentTypeDataModel.iNo == (int)enumDocumentType.FiscalReceipt)
                                {
                                    CustomMessageBox.Show(LabelTranslations.strGet("InvoicePrinted"));
                                }
                                else if (prm_xTransactionDataModel.xTransactionHeadDataModel.xTransactionDocumentTypeDataModel.iNo == (int)enumDocumentType.Return)
                                {
                                    CustomMessageBox.Show(LabelTranslations.strGet("ReturnPrinted"));
                                }
                            }
                        }

                        break;

                    case 2://Laser Printer

                        for (int iIndex = 0; iIndex < strDocumentDataLines.Length; iIndex++)
                        {
                            strDocumentDataLines[iIndex] = strCharacterConvertor(strDocumentDataLines[iIndex]);
                        }
                        if (strDocumentDataLines == null)

                            return false;

                        for (int iDocumentLineIndex = 0; iDocumentLineIndex < strDocumentDataLines.Length; iDocumentLineIndex = iDocumentLineIndex + xDocumentPrinterData.iMaxLinesNumber)
                        {
                            string[] strDocumentLines = new string[xDocumentPrinterData.iMaxLinesNumber];

                            Array.Copy(strDocumentDataLines, iDocumentLineIndex, strDocumentLines, 0, xDocumentPrinterData.iMaxLinesNumber);

                            if (CustomMessageBox.Show(LabelTranslations.strGet("InsertPaper"), MessageBoxButtons.YesNo, true) == DialogResult.Yes)
                            {
                                RawPrinterApi.SendStringToPrinter(prop_strPrinterName, string.Join("", strDocumentLines));


                                if (prm_xTransactionDataModel.xTransactionHeadDataModel.xTransactionDocumentTypeDataModel.iNo == (int)enumDocumentType.Waybill)
                                {
                                    CustomMessageBox.Show(LabelTranslations.strGet("WaybillPrinted"));
                                }
                                else if (prm_xTransactionDataModel.xTransactionHeadDataModel.xTransactionDocumentTypeDataModel.iNo == (int)enumDocumentType.Invoice)
                                {
                                    CustomMessageBox.Show(LabelTranslations.strGet("InvoicePrinted"));
                                }
                                else if (prm_xTransactionDataModel.xTransactionHeadDataModel.xTransactionDocumentTypeDataModel.iNo == (int)enumDocumentType.Return)
                                {
                                    CustomMessageBox.Show(LabelTranslations.strGet("ReturnPrinted"));
                                }
                            }
                        }

                        break;
                    case 3:

                        break;

                    case 4:

                        break;

                    case 5:

                        break;

                    default:

                        break;
                }

                return false;
            }

            catch (Exception xException)
            {
                xException.strTraceError();
                return false;
            }
        }

        public string strCharacterConvertor(string prm_strConvertedDocumentLines)

        {

            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('ö', 'o');
            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('ü', 'u');
            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('ğ', 'g');
            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('ş', 's');
            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('ı', 'i');
            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('ç', 'c');
            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('Ö', 'O');
            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('Ü', 'U');
            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('Ğ', 'G');
            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('Ş', 'S');
            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('İ', 'i');
            prm_strConvertedDocumentLines = prm_strConvertedDocumentLines.Replace('Ç', 'C');

            return prm_strConvertedDocumentLines;

        }
    }
}
