using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;

using SaleFlex.CommonLibrary;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.UserInterface.Constanst;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.Controls
{
    public static class ControlExtention
    {
        public static bool bSetControlCommonProperties(this Control prm_xControl, FormControlDataModel prm_xFormControlsDataModel)
        {
            bool bReturnValue = true;
            string strFontName = string.Empty;
            string strControlNamePrefix = string.Empty;
            byte byteGdiCharSet = (byte)0; // ANSI
            float fEmSize = prm_xControl.Font.Size;

            ICustomControl xCustomControl = (ICustomControl)prm_xControl;
            xCustomControl.strName = prm_xFormControlsDataModel.strName;
            xCustomControl.strType = prm_xFormControlsDataModel.strType;
            xCustomControl.strFunction1 = prm_xFormControlsDataModel.xFormControlFunction1.strName;
            xCustomControl.strFunction2 = prm_xFormControlsDataModel.xFormControlFunction2.strName;

            int iHeight = prm_xFormControlsDataModel.iHeight != 0 ? prm_xFormControlsDataModel.iHeight : prm_xControl.Height;
            int iWidth = prm_xFormControlsDataModel.iWidth != 0 ? prm_xFormControlsDataModel.iWidth : prm_xControl.Width;

            prm_xControl.Width = iWidth;
            prm_xControl.Height = iHeight;
            // Control Name
            strControlNamePrefix = prm_xControl.strGetControlNamePrefix(prm_xFormControlsDataModel.strType);

            prm_xControl.Name = string.Format("{0}{1}", strControlNamePrefix, prm_xFormControlsDataModel.strName);

            if (prm_xFormControlsDataModel.strType == CustomControlTypeName.strSalesList || prm_xFormControlsDataModel.strType == CustomControlTypeName.strPaymentList)
            {
                if (iWidth >= 550)
                    prm_xControl.Width = iWidth;
                if (iHeight >= 200)
                    prm_xControl.Height = iHeight;
            }
            else if (prm_xFormControlsDataModel.strType != CustomControlTypeName.strNumpad && prm_xFormControlsDataModel.strType != CustomControlTypeName.strAmountsTable)
            {
                if (prm_xFormControlsDataModel.iWidth != 0 || prm_xFormControlsDataModel.iHeight != 0)
                {
                    if (iWidth != 0)
                        prm_xControl.Width = iWidth;
                    if (iHeight != 0)
                        prm_xControl.Height = iHeight;
                }
            }
            else if (prm_xFormControlsDataModel.strType == CustomControlTypeName.strAmountsTable)
            {
                if (prm_xFormControlsDataModel.iWidth > 250 || prm_xFormControlsDataModel.iHeight > 200)
                {
                    if (iWidth > 250)
                        prm_xControl.Width = iWidth;
                    if (iHeight > 200)
                        prm_xControl.Height = iHeight;
                }
            }

            // Control Location on container
            prm_xControl.Location = new Point(prm_xFormControlsDataModel.iLocationX, prm_xFormControlsDataModel.iLocationY);

            // Control Font
            if (prm_xFormControlsDataModel.strType != CustomControlTypeName.strNumpad && prm_xFormControlsDataModel.strType != CustomControlTypeName.strSalesList && prm_xFormControlsDataModel.strType != CustomControlTypeName.strPaymentList && prm_xFormControlsDataModel.strType != CustomControlTypeName.strAmountsTable)
            {
                if (prm_xFormControlsDataModel.strFont != string.Empty)
                    strFontName = prm_xFormControlsDataModel.strFont;
                else
                    strFontName = "Tahoma"; // default font name

                if (CommonProperty.prop_strIsoCultureName == "tr - TR")
                    byteGdiCharSet = (byte)162; //TURKISH

                if (prm_xFormControlsDataModel.strImage != string.Empty)
                {
                    Bitmap xBitmap = new Bitmap(string.Format("{0}\\{1}", CommonProperty.prop_strImagesFolder, prm_xFormControlsDataModel.strImage));
                    if (xBitmap.Height < iHeight)
                        fEmSize = (float)((iHeight - xBitmap.Height) / 2);
                }
                else if (prm_xFormControlsDataModel.bFontAutoHeight == true)
                {
                    fEmSize = (float)((iHeight) / 2);
                }
                else if (prm_xFormControlsDataModel.fFontSize != 0)
                {
                    fEmSize = prm_xFormControlsDataModel.fFontSize;
                }
                prm_xControl.Font = new Font(strFontName, fEmSize, FontStyle.Regular, GraphicsUnit.Pixel, byteGdiCharSet);
            }

            if (prm_xControl is CustomComboBox)
            {
                prm_xControl.Width = iWidth;
                prm_xControl.Height = iHeight;
            }
            // Control Caption (Text)
            if (prm_xFormControlsDataModel.strType != CustomControlTypeName.strWebBrowser)
            {
                if (prm_xFormControlsDataModel.strCaption1 != string.Empty)
                {
                    prm_xControl.Text = prm_xFormControlsDataModel.strCaption1;
                }
            }

            if (prm_xFormControlsDataModel.strType != CustomControlTypeName.strAmountsTable)
            {
                try
                {
                    if (string.IsNullOrEmpty(prm_xFormControlsDataModel.strBackColor) == false)
                    {
                        prm_xControl.BackColor = System.Drawing.Color.FromName(prm_xFormControlsDataModel.strBackColor);
                    }
                    else
                    {
                        prm_xControl.BackColor = System.Drawing.SystemColors.Control;
                    }
                }
                catch (Exception xException)
                {
                    xException.strTraceError();
                    prm_xControl.BackColor = System.Drawing.SystemColors.Control;
                }
            }

            try
            {
                if (string.IsNullOrEmpty(prm_xFormControlsDataModel.strForeColor) == false)
                {
                    prm_xControl.ForeColor = System.Drawing.Color.FromName(prm_xFormControlsDataModel.strForeColor);
                }
                else
                {
                    prm_xControl.ForeColor = System.Drawing.SystemColors.ControlText;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                prm_xControl.ForeColor = System.Drawing.SystemColors.ControlText;
            }

            return bReturnValue;
        }

        public static string strGetControlNamePrefix(this Control prm_xControl, string prm_strTypeName)
        {
            string strControlNamePrefix = string.Empty;

            // Control Name
            switch (prm_strTypeName)
            {
                case CustomControlTypeName.strButton:
                    strControlNamePrefix = "button_";
                    break;
                case CustomControlTypeName.strMenu:
                    strControlNamePrefix = "menu_";
                    break;
                case CustomControlTypeName.strComboBox:
                    strControlNamePrefix = "combobox_";
                    break;
                case CustomControlTypeName.strLabel:
                    strControlNamePrefix = "label_";
                    break;
                case CustomControlTypeName.strTextBox:
                    strControlNamePrefix = "textbox_";
                    break;
                case CustomControlTypeName.strPicture:
                    strControlNamePrefix = "picture_";
                    break;
                case CustomControlTypeName.strAmountsTable:
                    strControlNamePrefix = "amountstable_";
                    break;
                case CustomControlTypeName.strWebBrowser:
                    strControlNamePrefix = "webbrowser_";
                    break;
                case CustomControlTypeName.strNumpad:
                    strControlNamePrefix = "numpad_";
                    break;
                case CustomControlTypeName.strSalesList:
                    strControlNamePrefix = "saleslist_";
                    break;
                default:
                    strControlNamePrefix = "undefinedcontrol_";
                    break;
            }

            return strControlNamePrefix;
        }

        public static CustomForm xFindCustomForm(this Control prm_xControl)
        {
            CustomForm xCustomForm = null;
            try
            {
                if (prm_xControl != null)
                {
                    xCustomForm = (CustomForm)prm_xControl.FindForm();
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return xCustomForm;
        }

        delegate string strGetControlPropertyValueDelegate(Control prm_xControl, string prm_strPropertyName);
        public static string strGetControlPropertyValue(this Control prm_xControl, string prm_strPropertyName)
        {
            string strReturnValue = string.Empty;

            if (prm_xControl.InvokeRequired == true)
            {
                strReturnValue = (string)prm_xControl.Invoke(new strGetControlPropertyValueDelegate(strGetControlPropertyValue), new object[] { prm_xControl, prm_strPropertyName });
            }
            else
            {
                switch (prm_strPropertyName)
                {
                    case "Text":
                        if (prm_xControl.GetType().Name == "CustomComboBox")
                        {
                            try
                            {
                                strReturnValue = prm_xControl.Text;
                            }
                            catch
                            {
                                strReturnValue = string.Empty;
                            }
                        }
                        else
                        {
                            strReturnValue = prm_xControl.Text;
                        }

                        break;
                    default:
                        break;
                }
            }

            return strReturnValue;
        }

        delegate bool bGetDiscountSurchargeListDelegate(CustomForm prm_xCustomForm, int prm_iIndex, List<DiscountSurchargeDataModel> prm_xIncomingDiscountSurchargeDataModelList, out List<DiscountSurchargeDataModel> prm_xOutgoingDiscountSurchargeDataModelList);
        public static bool bGetDiscountSurchargeList(this CustomForm prm_xCustomForm, int prm_iIndex, List<DiscountSurchargeDataModel> prm_xIncomingDiscountSurchargeDataModelList, out List<DiscountSurchargeDataModel> prm_xOutgoingDiscountSurchargeDataModelList)
        {
            bool bResult = false;
            prm_xOutgoingDiscountSurchargeDataModelList = null;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bResult = (bool)prm_xCustomForm.Invoke(new bGetDiscountSurchargeListDelegate(bGetDiscountSurchargeList), new object[] { prm_xCustomForm, prm_iIndex, prm_xIncomingDiscountSurchargeDataModelList, prm_xOutgoingDiscountSurchargeDataModelList });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        bResult = ((CustomSalesList)xControl).bGetDiscountSurchargeList(prm_iIndex, prm_xIncomingDiscountSurchargeDataModelList, out prm_xOutgoingDiscountSurchargeDataModelList);

                        break;
                    }
                }
            }

            return bResult;
        }

        delegate int iGetSelectedSaleDelegate(CustomForm prm_xCustomForm, out TransactionDetailDataModel prm_xTransactionDetailDataModel);
        public static int iGetSelectedSale(this CustomForm prm_xCustomForm, out TransactionDetailDataModel prm_xTransactionDetailDataModel)
        {
            int iSaleIndex = -1;
            prm_xTransactionDetailDataModel = null;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                iSaleIndex = (int)prm_xCustomForm.Invoke(new iGetSelectedSaleDelegate(iGetSelectedSale), new object[] { prm_xCustomForm, prm_xTransactionDetailDataModel });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        iSaleIndex = ((CustomSalesList)xControl).iGetSelectedSale(out prm_xTransactionDetailDataModel);

                        break;
                    }
                }
            }

            return iSaleIndex;
        }

        delegate int iGetLastSaleDelegate(CustomForm prm_xCustomForm, out TransactionDetailDataModel prm_xTransactionDetailDataModel);
        public static int iGetLastSale(this CustomForm prm_xCustomForm, out TransactionDetailDataModel prm_xTransactionDetailDataModel)
        {
            int iSaleIndex = -1;
            prm_xTransactionDetailDataModel = null;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                iSaleIndex = (int)prm_xCustomForm.Invoke(new iGetLastSaleDelegate(iGetLastSale), new object[] { prm_xCustomForm, prm_xTransactionDetailDataModel });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        iSaleIndex = ((CustomSalesList)xControl).iGetLastSale(out prm_xTransactionDetailDataModel);

                        break;
                    }
                }
            }

            return iSaleIndex;
        }

        delegate bool bErrorCorrectionDelegate(CustomForm prm_xCustomForm, int prm_iSaleIndex);
        public static bool bErrorCorrection(this CustomForm prm_xCustomForm, int prm_iSaleIndex)
        {
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bErrorCorrectionDelegate(bErrorCorrection), new object[] { prm_xCustomForm, prm_iSaleIndex });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        bReturnValue = ((CustomSalesList)xControl).bErrorCorrection(prm_iSaleIndex);

                        break;
                    }
                }
            }

            return bReturnValue;
        }

        delegate bool bCancelTransactionDelegate(CustomForm prm_xCustomForm, int prm_iSaleIndex);
        public static bool bCancelTransaction(this CustomForm prm_xCustomForm, int prm_iSaleIndex)
        {
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bCancelTransactionDelegate(bCancelTransaction), new object[] { prm_xCustomForm, prm_iSaleIndex });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        bReturnValue = ((CustomSalesList)xControl).bCancelTransaction(prm_iSaleIndex);

                        break;
                    }
                    //if (xControl is CustomAmountsTable)
                    //{
                    //    ((CustomAmountsTable)xControl).lReceiptTotalPrice -= /*((CustomSalesList)prm_xCustomForm.Controls[16])*/1;
                    //    ((CustomAmountsTable)xControl).vUpdateAndRefreshFormControls();
                    //}
                }
            }

            return bReturnValue;
        }
        delegate bool bRepeatTransactionDelegate(CustomForm prm_xCustomForm, int prm_iSaleIndex);
        public static bool bRepeatTransaction(this CustomForm prm_xCustomForm, int prm_iSaleIndex)
        {
            bool bReturnValue = true;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bRepeatTransactionDelegate(bRepeatTransaction), new object[] { prm_xCustomForm, prm_iSaleIndex });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        bReturnValue = ((CustomSalesList)xControl).bRepeatTransaction(prm_iSaleIndex);

                        break;
                    }
                }
            }

            return bReturnValue;
        }
        delegate bool bAddSaleDelegate(CustomForm prm_xCustomForm, TransactionDataModel prm_xTransactionDataModel);
        public static bool bAddSale(this CustomForm prm_xCustomForm, TransactionDataModel prm_xTransactionDataModel)
        {
            Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale Called");
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bErrorCorrectionDelegate(bErrorCorrection), new object[] { prm_xCustomForm, prm_xTransactionDataModel });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale in bAddSale Expected");
                        bReturnValue = ((CustomSalesList)xControl).bAddSale(prm_xTransactionDataModel);
                        Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale in AddSale Ended");
                        break;
                    }
                }
            }

            return bReturnValue;
        }
        public static bool bAddSaleFromSuspended(this CustomForm prm_xCustomForm, TransactionDataModel prm_xTransactionDataModel)
        {
            Trace.vInsert(enumTraceLevel.Unnecessary, "vSuspendedTransactionAdded Called");
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bErrorCorrectionDelegate(bErrorCorrection), new object[] { prm_xCustomForm, prm_xTransactionDataModel });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale in bAddSale Expected");
                        bReturnValue = ((CustomSalesList)xControl).bAddSaleFromSuspended(prm_xTransactionDataModel);
                        Trace.vInsert(enumTraceLevel.Unnecessary, "bAddSale in AddSale Ended");
                        break;
                    }
                }
            }

            return bReturnValue;
        }
        

        delegate bool bAddPaymentDelegate(CustomForm prm_xCustomForm, TransactionDataModel prm_xTransactionDataModel);
        public static bool bAddPayment(this CustomForm prm_xCustomForm, TransactionDataModel prm_xTransactionDataModel)
        {
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bAddPaymentDelegate(bAddPayment), new object[] { prm_xCustomForm, prm_xTransactionDataModel });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomPaymentList)
                    {
                        bReturnValue = ((CustomPaymentList)xControl).bAddPayment(prm_xTransactionDataModel);

                        break;
                    }
                }
            }

            return bReturnValue;
        }

        delegate bool bAddSubTotalDelegate(CustomForm prm_xCustomForm, decimal prm_decReceiptTotalPrice, TransactionDataModel prm_xTransactionDataModel);
        public static bool bAddSubTotal(this CustomForm prm_xCustomForm, decimal prm_decReceiptTotalPrice, TransactionDataModel prm_xTransactionDataModel)
        {
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bAddSubTotalDelegate(bAddSubTotal), new object[] { prm_xCustomForm, prm_decReceiptTotalPrice, prm_xTransactionDataModel });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        bReturnValue = ((CustomSalesList)xControl).bAddSubTotal(prm_decReceiptTotalPrice, prm_xTransactionDataModel);

                        break;
                    }
                }
            }

            return bReturnValue;
        }

        delegate bool bAddDiscountByAmountLineDelegate(CustomForm prm_xCustomForm, DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel);
        public static bool bAddDiscountByAmountLine(this CustomForm prm_xCustomForm, DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel)
        {
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bAddDiscountByAmountLineDelegate(bAddDiscountByAmountLine), new object[] { prm_xCustomForm, prm_xDiscountSurchargeDataModel });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        bReturnValue = ((CustomSalesList)xControl).bAddDiscountByAmountLine(prm_xDiscountSurchargeDataModel);

                        break;
                    }
                }
            }

            return bReturnValue;
        }

        delegate bool bAddDiscountByPercentLineDelegate(CustomForm prm_xCustomForm, DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel);
        public static bool bAddDiscountByPercentLine(this CustomForm prm_xCustomForm, DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel)
        {
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bAddDiscountByPercentLineDelegate(bAddDiscountByPercentLine), new object[] { prm_xCustomForm, prm_xDiscountSurchargeDataModel });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        bReturnValue = ((CustomSalesList)xControl).bAddDiscountByPercentLine(prm_xDiscountSurchargeDataModel);

                        break;
                    }
                }
            }

            return bReturnValue;
        }

        delegate bool bAddSurchargeByPercentLineDelegate(CustomForm prm_xCustomForm, DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel);
        public static bool bAddSurchargeByPercentLine(this CustomForm prm_xCustomForm, DiscountSurchargeDataModel prm_xDiscountSurchargeDataModel)
        {
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bAddSurchargeByPercentLineDelegate(bAddSurchargeByPercentLine), new object[] { prm_xCustomForm, prm_xDiscountSurchargeDataModel });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        bReturnValue = ((CustomSalesList)xControl).bAddSurchargeByPercentLine(prm_xDiscountSurchargeDataModel);

                        break;
                    }
                }
            }

            return bReturnValue;
        }
        //delegate bool bCheckLastSaleCanceledOrNotDelegate(CustomForm prm_xCustomForm);
        //public static bool bCheckLastSaleCanceledOrNot(this CustomForm prm_xCustomForm)
        //{
        //    bool bReturnValue = false;

        //    if (prm_xCustomForm.InvokeRequired == true)
        //    {
        //        bReturnValue = (bool)prm_xCustomForm.Invoke(new bCheckLastSaleCanceledOrNotDelegate(bCheckLastSaleCanceledOrNot), new object[] { prm_xCustomForm });
        //    }
        //    else
        //    {
        //        foreach (Control xControl in prm_xCustomForm.Controls)
        //        {
        //            if (xControl is CustomSalesList)
        //            {
        //                bReturnValue = ((CustomSalesList)xControl).bCheckLastSaleCanceledOrNot();

        //                break;
        //            }

        //        }
        //    }
        //    return bReturnValue;
        //}


        delegate bool bAddTotalDelegate(CustomForm prm_xCustomForm, decimal prm_decReceiptTotalPrice);
        public static bool bAddTotal(this CustomForm prm_xCustomForm, decimal prm_decReceiptTotalPrice)
        {
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bAddTotalDelegate(bAddTotal), new object[] { prm_xCustomForm, prm_decReceiptTotalPrice });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomSalesList)
                    {
                        bReturnValue = ((CustomSalesList)xControl).bAddTotal(prm_decReceiptTotalPrice);

                        break;
                    }
                }
            }

            return bReturnValue;
        }

        delegate bool bClearListsDelegate(CustomForm prm_xCustomForm);
        public static bool bClearLists(this CustomForm prm_xCustomForm)
        {
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bClearListsDelegate(bClearLists), new object[] { prm_xCustomForm });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomPaymentList)
                    {
                        bReturnValue = ((CustomPaymentList)xControl).bClear();
                    }
                    else if (xControl is CustomSalesList)
                    {
                        bReturnValue = ((CustomSalesList)xControl).bClear();
                    }
                    else if (xControl is CustomAmountsTable)
                    {
                        ((CustomAmountsTable)xControl).bClear();
                        bReturnValue = true;
                    }
                }
            }

            return bReturnValue;
        }

        delegate bool bSaveFormDelegate(CustomForm prm_xCustomForm);
        public static bool bSaveForm(this CustomForm prm_xCustomForm)
        {
            bool bReturnValue = false;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                bReturnValue = (bool)prm_xCustomForm.Invoke(new bSaveFormDelegate(bSaveForm), new object[] { prm_xCustomForm });
            }
            else
            {
                try
                {
                    using (XmlWriter xXmlWriter = XmlWriter.Create(string.Format("{0}{1}{2}{3}{4}{5}.XML", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)))
                    {
                        xXmlWriter.WriteStartDocument();
                        xXmlWriter.WriteStartElement("TextBoxes");

                        foreach (Control xControl in prm_xCustomForm.Controls)
                        {
                            if (xControl is CustomTextBox || xControl is CustomComboBox)
                            {
                                xXmlWriter.WriteStartElement(xControl.Name);
                                xXmlWriter.WriteElementString("Text", xControl.Text);
                                xXmlWriter.WriteEndElement();
                            }
                        }

                        xXmlWriter.WriteEndElement();
                        xXmlWriter.WriteEndDocument();
                    }

                    bReturnValue = true;
                }
                catch (Exception xException)
                {
                    xException.strTraceError();
                }
            }

            return bReturnValue;
        }

        delegate string strGetNumPadOutputDelegate(CustomForm prm_xCustomForm);
        public static string strGetNumPadOutput(this CustomForm prm_xCustomForm)
        {
            string strNumPadOutput = string.Empty;

            if (prm_xCustomForm.InvokeRequired == true)
            {
                strNumPadOutput = (string)prm_xCustomForm.Invoke(new strGetNumPadOutputDelegate(strGetNumPadOutput), new object[] { prm_xCustomForm });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomNumpad)
                    {
                        strNumPadOutput = ((CustomNumpad)xControl).strNumPadOutput;
                        ((CustomNumpad)xControl).strNumPadOutput = string.Empty;
                    }
                }
            }

            return strNumPadOutput;
        }

        delegate bool bChangeModeToGetPriceDelegate(CustomForm prm_xCustomForm);
        public static bool bChangeModeToGetPrice(this CustomForm prm_xCustomForm)
        {
            if (prm_xCustomForm.InvokeRequired == true)
            {
                return (bool)prm_xCustomForm.Invoke(new bChangeModeToGetPriceDelegate(bChangeModeToGetPrice), new object[] { prm_xCustomForm });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomNumpad)
                    {
                        ((CustomNumpad)xControl).bIsGetPriceModeActive = true;

                        return true;
                    }
                }
            }

            return false;
        }

        delegate bool bFocusNumPadDelegate(CustomForm prm_xCustomForm);
        public static bool bFocusNumPad(this CustomForm prm_xCustomForm)
        {
            if (prm_xCustomForm.InvokeRequired == true)
            {
                return (bool)prm_xCustomForm.Invoke(new bFocusNumPadDelegate(bFocusNumPad), new object[] { prm_xCustomForm });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomNumpad)
                    {
                        ((CustomNumpad)xControl).Focus();
                    }
                }
            }

            return true;
        }

        delegate bool bSetStatusBarStatusLabelDelegate(CustomForm prm_xCustomForm, string prm_strStatusLabel);
        public static bool bSetStatusBarStatusLabel(this CustomForm prm_xCustomForm, string prm_strStatusLabel)
        {
            if (prm_xCustomForm.InvokeRequired == true)
            {
                return (bool)prm_xCustomForm.Invoke(new bSetStatusBarStatusLabelDelegate(bSetStatusBarStatusLabel), new object[] { prm_xCustomForm, prm_strStatusLabel });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomStatusBar)
                    {
                        ((CustomStatusBar)xControl).strStatus = prm_strStatusLabel;

                        return true;
                    }
                }

            }

            return false;
        }

        delegate bool bSetStatusBarDocumentTypeLabelDelegate(CustomForm prm_xCustomForm, EnumDocumentType prm_enumDocumentType);
        public static bool bSetStatusBarDocumentTypeLabel(this CustomForm prm_xCustomForm, EnumDocumentType prm_enumDocumentType)
        {
            if (prm_xCustomForm.InvokeRequired == true)
            {
                return (bool)prm_xCustomForm.Invoke(new bSetStatusBarDocumentTypeLabelDelegate(bSetStatusBarDocumentTypeLabel), new object[] { prm_xCustomForm, prm_enumDocumentType });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomStatusBar)
                    {
                        ((CustomStatusBar)xControl).strDocumentType = LabelTranslations.strGetDocumentType(prm_enumDocumentType);

                        return true;
                    }
                }

            }

            return false;
        }

        delegate bool bSetStatusBarZNoLabelDelegate(CustomForm prm_xCustomForm, string prm_strZNo);
        public static bool bSetStatusBarZNoLabel(this CustomForm prm_xCustomForm, string prm_strZNo)
        {
            if (prm_xCustomForm.InvokeRequired == true)
            {
                return (bool)prm_xCustomForm.Invoke(new bSetStatusBarZNoLabelDelegate(bSetStatusBarZNoLabel), new object[] { prm_xCustomForm, prm_strZNo });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomStatusBar)
                    {
                        if (prm_strZNo == string.Empty)
                            prm_strZNo = "0";
                        ((CustomStatusBar)xControl).strZNo = string.Format("{0} : {1}", LabelTranslations.strGet("GroupNo"), (Convert.ToInt32(prm_strZNo)).ToString());

                        return true;
                    }
                }
            }

            return false;
        }

        delegate bool bSetStatusBarReceiptNoLabelDelegate(CustomForm prm_xCustomForm, string prm_strReceiptNo);
        public static bool bSetStatusBarReceiptNoLabel(this CustomForm prm_xCustomForm, string prm_strReceiptNo)
        {
            if (prm_xCustomForm.InvokeRequired == true)
            {
                return (bool)prm_xCustomForm.Invoke(new bSetStatusBarReceiptNoLabelDelegate(bSetStatusBarReceiptNoLabel), new object[] { prm_xCustomForm, prm_strReceiptNo });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomStatusBar)
                    {
                        ((CustomStatusBar)xControl).strReceiptNo = string.Format("{0} : {1}", LabelTranslations.strGet("ReceiptNo"), (Convert.ToInt32(prm_strReceiptNo)).ToString());

                        return true;
                    }
                }

            }

            return false;
        }

        delegate object objGetControlsPropertyValue1Delegate(CustomForm prm_xCustomForm, string prm_strPropertyName, string prm_strControlName);
        public static object objGetControlsPropertyValue(this CustomForm prm_xCustomForm, string prm_strPropertyName, string prm_strControlName)
        {
            if (prm_xCustomForm.InvokeRequired == true)
            {
                return (bool)prm_xCustomForm.Invoke(new objGetControlsPropertyValue1Delegate(objGetControlsPropertyValue), new object[] { prm_xCustomForm, prm_strPropertyName, prm_strControlName });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    try
                    {
                        string strControlNameInForm = xControl.Name.Substring(xControl.Name.IndexOf("_") + 1);
                        if (strControlNameInForm == prm_strControlName)
                        {
                            return xControl.strGetControlPropertyValue(prm_strPropertyName);
                        }
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                    }
                }
            }

            return null;
        }

        delegate object objGetControlsPropertyValue2Delegate(CustomForm prm_xCustomForm, string prm_strPropertyName, string prm_strControlNameList, bool prm_bUseControlsInList);
        public static object objGetControlsPropertyValue(this CustomForm prm_xCustomForm, string prm_strPropertyName, string prm_strControlNameList, bool prm_bUseControlsInList)
        {
            if (prm_xCustomForm.InvokeRequired == true)
            {
                return (bool)prm_xCustomForm.Invoke(new objGetControlsPropertyValue2Delegate(objGetControlsPropertyValue), new object[] { prm_xCustomForm, prm_strPropertyName, prm_strControlNameList, prm_bUseControlsInList });
            }
            else
            {
                List<string> xControlNameList = prm_strControlNameList.xGetList(";");

                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    try
                    {
                        string strControlNameInForm = xControl.Name.Substring(xControl.Name.IndexOf("_") + 1);
                        foreach (string strControlName in xControlNameList)
                        {
                            if (prm_bUseControlsInList == true && strControlNameInForm == strControlName)
                            {
                                return xControl.strGetControlPropertyValue(prm_strPropertyName);
                            }
                            else if (prm_bUseControlsInList == false && strControlNameInForm != strControlName)
                            {
                                return xControl.strGetControlPropertyValue(prm_strPropertyName);
                            }
                        }
                    }
                    catch (Exception xException)
                    {
                        xException.strTraceError();
                    }
                }
            }
            return null;
        }

        delegate bool bSetStatusBarPriceDelegate(CustomForm prm_xCustomForm, decimal prm_decPrice);
        public static bool bSetStatusBarPriceLabel(this CustomForm prm_xCustomForm, decimal prm_decPrice)
        {
            if (prm_xCustomForm.InvokeRequired == true)
            {
                return (bool)prm_xCustomForm.Invoke(new bSetStatusBarPriceDelegate(bSetStatusBarPriceLabel), new object[] { prm_xCustomForm, prm_decPrice });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomStatusBar)
                    {
                        ((CustomStatusBar)xControl).decPrice = prm_decPrice;

                        return true;
                    }
                }
            }

            return false;
        }

        delegate bool bSetStatusBarQuantityDelegate(CustomForm prm_xCustomForm, decimal prm_decQuantity);
        public static bool bSetStatusBarQuantityLabel(this CustomForm prm_xCustomForm, decimal prm_decQuantity)
        {
            if (prm_xCustomForm.InvokeRequired == true)
            {
                return (bool)prm_xCustomForm.Invoke(new bSetStatusBarQuantityDelegate(bSetStatusBarQuantityLabel), new object[] { prm_xCustomForm, prm_decQuantity });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomStatusBar)
                    {
                        ((CustomStatusBar)xControl).decQuantity = prm_decQuantity;

                        return true;
                    }
                }


            }

            return false;
        }

        delegate bool bSetStatusBarCashierLabelDelegate(CustomForm prm_xCustomForm, string prm_strCashier);
        public static bool bSetStatusBarCashierLabel(this CustomForm prm_xCustomForm, string prm_strCashier)
        {
            if (prm_xCustomForm.InvokeRequired == true)
            {
                return (bool)prm_xCustomForm.Invoke(new bSetStatusBarCashierLabelDelegate(bSetStatusBarCashierLabel), new object[] { prm_xCustomForm, prm_strCashier });
            }
            else
            {
                foreach (Control xControl in prm_xCustomForm.Controls)
                {
                    if (xControl is CustomStatusBar)
                    {
                        ((CustomStatusBar)xControl).strCashier = prm_strCashier;

                        return true;
                    }
                }

            }

            return false;
        }

    }
}
