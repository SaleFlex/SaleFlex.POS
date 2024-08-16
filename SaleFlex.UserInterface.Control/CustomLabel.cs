using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using SaleFlex.CommonLibrary;
using SaleFlex.Data.Models;

namespace SaleFlex.UserInterface.Controls
{
    public class CustomLabel : Label, ICustomControl
    {
        private Icon m_xIcon;
        private const int m_iIconSize = 16;

        public CustomLabel(FormControlDataModel prm_xFormControlsDataModel)
        {
            vInitializeCustomComponents(prm_xFormControlsDataModel);
        }

        public void vInitializeCustomComponents(FormControlDataModel prm_xFormControlDataModel)
        {
            m_xIcon = null;

            ((Control)this).bSetControlCommonProperties(prm_xFormControlDataModel);

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

            BackColor = System.Drawing.Color.Transparent;
        }

        /// <summary>
        /// Gets/Sets the icons used in drawing this label. 
        /// </summary>
        public Icon xIcon
        {
            get
            {
                return (m_xIcon);
            }
            set
            {
                m_xIcon = value;
            }
        }

        protected override void OnPaint(PaintEventArgs xPaintEventArgs)
        {
            if (m_xIcon == null)
            {
                // There is not any Icon so let the control draw itself ;)
                base.OnPaint(xPaintEventArgs);
                return;
            }

            Rectangle xTextRectangle = new Rectangle(xPaintEventArgs.ClipRectangle.Left + m_iIconSize + 2, xPaintEventArgs.ClipRectangle.Top, xPaintEventArgs.ClipRectangle.Width - m_iIconSize - 2, xPaintEventArgs.ClipRectangle.Height);
            Rectangle xIconRectangle = new Rectangle(xPaintEventArgs.ClipRectangle.Left, xPaintEventArgs.ClipRectangle.Top, m_iIconSize, m_iIconSize);

            Brush xBackgroundBrush = new SolidBrush(ForeColor);
            xPaintEventArgs.Graphics.DrawRectangle(new Pen(xBackgroundBrush), xPaintEventArgs.ClipRectangle);

            Brush xTextBrush = new SolidBrush(ForeColor);

            StringFormat xStringFormat = new StringFormat();
            xStringFormat.Alignment = StringAlignment.Near;
            xStringFormat.LineAlignment = StringAlignment.Center;
            xStringFormat.Trimming = StringTrimming.EllipsisWord;
            xStringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;

            xPaintEventArgs.Graphics.DrawString(Text, Font, xTextBrush, xTextRectangle, xStringFormat);
            xPaintEventArgs.Graphics.DrawIcon(m_xIcon, xIconRectangle);
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
    }
}
