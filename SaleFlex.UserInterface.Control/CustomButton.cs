using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.AccessLayer;
using SaleFlex.Data.Models;
using SaleFlex.Data;
using SaleFlex.UserInterface.Data;

namespace SaleFlex.UserInterface.Controls
{
    public class CustomButton : Button, ICustomControl
    {
        private Image m_xImageSelected;
        private int m_iClickWaitTimeout;

        private string m_strFunction1Name = string.Empty;
        private string m_strFunction2Name = string.Empty;
        private string m_strCaption1 = string.Empty;
        private string m_strCaption2 = string.Empty;
        private string m_strFirstToolTip = string.Empty;
        private string m_strLastToopTip = string.Empty;
        private string m_strFirstLabel = string.Empty;
        private string m_strLastLabel = string.Empty;
        private string m_strFirstToolTipLabel = string.Empty;
        private string m_strLastToolTipLabel = string.Empty;

        private bool m_bIsThisButtonDual = false;
        private int m_iStateOfDualButtonMode = 1; // First state is 1, Last state is 2

        private bool m_bBorder;
        public bool Border
        {
            get { return m_bBorder; }
            set { m_bBorder = value; }
        }

        private string m_strFormControlName;
        public string FormControlName
        {
            get { return m_strFormControlName; }
            set { m_strFormControlName = value; }
        }

        private int m_iFormID;

        public int FormID
        {
            get { return m_iFormID; }
            set { m_iFormID = value; }
        }

        private int m_iFormTypeNo;
        public int FormTypeNo
        {
            get { return m_iFormTypeNo; }
            set { m_iFormTypeNo = value; }
        }


        public CustomButton(FormControlDataModel prm_xFormControlDataModel)
        {
            try
            {
                m_iClickWaitTimeout = 200;
                vInitializeCustomComponents(prm_xFormControlDataModel);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public void vInitializeCustomComponents(FormControlDataModel prm_xFormControlDataModel)
        {
            try
            {
                FlatAppearance.BorderSize = 0;
                FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                UseVisualStyleBackColor = true;

                ((Control)this).bSetControlCommonProperties(prm_xFormControlDataModel);

                m_strFunction1Name = prm_xFormControlDataModel.xFormControlFunction1.strName;
                m_strFunction2Name = prm_xFormControlDataModel.xFormControlFunction2.strName;
                m_strCaption1 = prm_xFormControlDataModel.strCaption1;
                m_strCaption2 = prm_xFormControlDataModel.strCaption2;

                Single sFontSize = prm_xFormControlDataModel.fFontSize;
                string strFontName = prm_xFormControlDataModel.strFont;

                if(strFontName != string.Empty && sFontSize != 0 )
                {
                    Font = new System.Drawing.Font(strFontName, sFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }

                if (prm_xFormControlDataModel.strImage != string.Empty)
                {
                    Bitmap xBitmap = new Bitmap(string.Format("{0}\\{1}", CommonProperty.prop_strImagesFolder, prm_xFormControlDataModel.strImage));
                    if (xBitmap.Height <= Height)
                        Image = xBitmap;
                }
                else
                {
                    if (strName != null)
                    {
                        if (strName.Length >= 3 && strName.ToUpper().StartsWith("PLU"))
                        {
                            string strPluCode = strName.Remove(0, 3);

                            if (m_strFunction1Name == "SALE_PLU_CODE")
                            {
                                try
                                {
                                    Text = Dao.xGetInstance().xGetPluByCode(strPluCode).strShortName;
                                }
                                catch
                                {
                                    if (Text == string.Empty)
                                        Text = LabelTranslations.strGet("DefinitionIsNotProper");
                                }
                            }
                            else if (m_strFunction1Name == "SALE_PLU_BARCODE")
                            {
                                try
                                {
                                    strPluCode = Dao.xGetInstance().strGetPluCode(strPluCode);
                                    Text = Dao.xGetInstance().xGetPluByCode(strPluCode).strShortName;
                                }
                                catch
                                {
                                    if (Text == string.Empty)
                                        Text = LabelTranslations.strGet("DefinitionIsNotProper");
                                }
                            }
                        }
                        else if (strName.Length >= 10 && strName.ToUpper().StartsWith("DEPARTMENT"))
                        {
                            int iDepartmentNo = int.Parse(strName.Remove(0, 10));
                            Text = Dao.xGetInstance().xGetDepartmentByNo(iDepartmentNo).strName;
                        }
                        else if (strName.Length >= 9 && strName.ToUpper().StartsWith("MAINGROUP"))
                        {
                            int iPluMainGroupId = int.Parse(strName.Remove(0, 9));
                            Text = Dao.xGetInstance().xGetPluMainGroupById(iPluMainGroupId).strName;
                        }
                    }
                }

                if (prm_xFormControlDataModel.strImageSelected != "")
                {
                    Bitmap xBitmapSelected = new Bitmap(string.Format("{0}\\{1}", CommonProperty.prop_strImagesFolder, prm_xFormControlDataModel.strImageSelected));
                    xImageSelected = xBitmapSelected;
                }

                if (Text != string.Empty && prm_xFormControlDataModel.strTextAlignment != string.Empty)
                {
                    switch (prm_xFormControlDataModel.strTextAlignment)
                    {
                        case "BOTTOMCENTER":
                            TextAlign = ContentAlignment.BottomCenter;
                            break;
                        case "BOTTOMLEFT":
                            TextAlign = ContentAlignment.BottomLeft;
                            break;
                        case "BOTTOMRIGHT":
                            TextAlign = ContentAlignment.BottomRight;
                            break;
                        case "MIDDLECENTER":
                            TextAlign = ContentAlignment.MiddleCenter;
                            break;
                        case "MIDDLELEFT":
                            TextAlign = ContentAlignment.MiddleLeft;
                            break;
                        case "MIDDLERIGHT":
                            TextAlign = ContentAlignment.MiddleRight;
                            break;
                        case "TOPCENTER":
                            TextAlign = ContentAlignment.TopCenter;
                            break;
                        case "TOPLEFT":
                            TextAlign = ContentAlignment.TopLeft;
                            break;
                        case "TOPRIGHT":
                            TextAlign = ContentAlignment.TopRight;
                            break;
                        default:
                            TextAlign = ContentAlignment.MiddleCenter;
                            break;
                    }
                }

                if (Text != string.Empty && Image != null && prm_xFormControlDataModel.strTextImageRelation != string.Empty)
                {
                    switch (prm_xFormControlDataModel.strTextImageRelation)
                    {
                        case "IMAGEABOVETEXT":
                            TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                            break;
                        case "IMAGEBEFORETEXT":
                            TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                            break;
                        case "OVERLAY":
                            TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
                            break;
                        case "TEXTABOVEIMAGE":
                            TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
                            break;
                        case "TEXTBEFOREIMAGE":
                            TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
                            break;
                        default:
                            TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                            break;
                    }
                }

                m_iStateOfDualButtonMode = 1; // First State

                if (m_strCaption1 != string.Empty && m_strCaption2 != string.Empty && m_strFunction1Name != string.Empty && m_strFunction2Name != string.Empty)
                {
                    m_bIsThisButtonDual = true;
                }
                else
                {
                    m_bIsThisButtonDual = false;
                }

                if (m_bIsThisButtonDual == true)
                {
                    Text = m_strCaption1;

                    Click += new EventHandler(vOnEvent1);
                }
                else if (prm_xFormControlDataModel.xFormControlFunction1.strName != string.Empty)
                {
                    Click += new EventHandler(vOnEvent1);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// xImageSelected property definition
        /// </summary>
        public Image xImageSelected
        {
            get
            {
                return m_xImageSelected;
            }
            set
            {
                m_xImageSelected = value;
            }
        }

        // Click Wait Timeout property definition
        public int iClickWaitTimeout
        {
            get
            {
                return m_iClickWaitTimeout;
            }
            set
            {
                m_iClickWaitTimeout = value;
            }
        }

        protected override void OnClick(EventArgs xEventArgs)
        {
            try
            {
                if (m_xImageSelected != null && m_iClickWaitTimeout > 0)
                {
                    Image xTmpImage = Image;
                    Image = m_xImageSelected;
                    Refresh();
                    System.Threading.Thread.Sleep(m_iClickWaitTimeout);
                    Image = xTmpImage;
                    Refresh();
                }
                base.OnClick(xEventArgs);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        public bool bChangeState()
        {
            return bChangeState(-1);
        }

        public bool bChangeState(int prm_iState)
        {
            bool bReturnValue = false;
            try
            {
                if (prm_iState == -1)
                {
                    prm_iState = m_iStateOfDualButtonMode == 1 ? 2 : 1;
                }

                if (m_strFunction1Name != string.Empty && m_strFunction2Name != string.Empty)
                {
                    vRemoveAllEvents();
                    if (prm_iState == 2) // Last State
                    {
                        Click += new EventHandler(vOnEvent2);
                    }
                    else // prm_iState==1 First State
                    {
                        Click += new EventHandler(vOnEvent1);
                    }

                    m_iStateOfDualButtonMode = prm_iState;

                    bReturnValue = true;
                }

                if (bReturnValue == true && m_strCaption1 != string.Empty && m_strCaption2 != string.Empty)
                {
                    if (prm_iState == 1)
                    {
                        Text = m_strCaption1;
                    }
                    else // prm_iState==2
                    {
                        Text = m_strCaption2;
                    }
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
            return bReturnValue;
        }

        private void vRemoveAllEvents()
        {
            FieldInfo xFieldInfo = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
            object objObject = xFieldInfo.GetValue(this);
            PropertyInfo xPropertyInfo = this.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList xEventHandlerList = (EventHandlerList)xPropertyInfo.GetValue(this, null);
            xEventHandlerList.RemoveHandler(objObject, xEventHandlerList[objObject]);
        }

        public string strName { get; set; }
        public string strType { get; set; }
        public string strFunction1 { get; set; }
        public string strFunction2 { get; set; }
        public EventHandler xEventHandler1 { get; set; }
        public EventHandler xEventHandler2 { get; set; }

        public void vOnEvent1(object prm_objObject, EventArgs prm_xEventArgs)
        {
            if (xEventHandler1 != null)
                xEventHandler1(prm_objObject, prm_xEventArgs);
        }

        public void vOnEvent2(object prm_objObject, EventArgs prm_xEventArgs)
        {
            if (xEventHandler2 != null)
                xEventHandler2(prm_objObject, prm_xEventArgs);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Border)
            {
                e.Graphics.DrawRectangle(new Pen(Brushes.MediumVioletRed, 5),
                                 e.ClipRectangle.Left,
                                 e.ClipRectangle.Top,
                                 e.ClipRectangle.Width - 1,
                                 e.ClipRectangle.Height - 1);
            }
            else
            {
                e.Graphics.DrawRectangle(new Pen(Brushes.Transparent, 3),
                                 e.ClipRectangle.Left,
                                 e.ClipRectangle.Top,
                                 e.ClipRectangle.Width - 1,
                                 e.ClipRectangle.Height - 1);
            }
        }
    }
}
