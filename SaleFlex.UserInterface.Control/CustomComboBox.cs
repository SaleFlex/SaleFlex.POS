using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using SaleFlex.Data;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using SaleFlex.CommonLibrary;
using SaleFlex.UserInterface.Constanst;

namespace SaleFlex.UserInterface.Controls
{
    public class CustomComboBox : ComboBox, ICustomControl
    {
        private Collection<Icon> m_xIconList;
        private CustomComboBoxDropDownWindow m_xCustomComboBoxDropDownWindow;
        private CustomComboBoxDropDownListener m_xCustomComboBoxDropDownListener;

        private const int ICON_SIZE = 16;

        public CustomComboBox(FormControlDataModel prm_xFormControlDataModel)
        {
            try
            {
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
                //FormattingEnabled = true;
                DrawMode = DrawMode.OwnerDrawFixed;
                AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AutoCompleteSource = AutoCompleteSource.ListItems;
                DropDownStyle = ComboBoxStyle.DropDownList;

                ((Control)this).bSetControlCommonProperties(prm_xFormControlDataModel);

                if (prm_xFormControlDataModel.strName == CustomControlName.strCashierNameList)
                {
                    List<CashierDataModel> xListCashierDataModel = Dao.xGetInstance().xListGetCashiers();

                    for (int iIndex = 0; iIndex < xListCashierDataModel.Count; iIndex++)
                    {
                        Items.Add(string.Format("{0} {1}",xListCashierDataModel[iIndex].strName, xListCashierDataModel[iIndex].strLastName));
                    }

                    if (this.strFunction1 == "LOGIN")
                        Items.Add(CommonProperty.prop_strSupervisorName);

                    SelectedIndex = 0;
                }
                else if (prm_xFormControlDataModel.xList.Count > 0)
                {
                    for (int iIndex = 0; iIndex < prm_xFormControlDataModel.xList.Count; iIndex++)
                    {
                        Items.Add(prm_xFormControlDataModel.xList[iIndex]);
                    }
                    SelectedIndex = 0;
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        /// <summary>
        /// Gets/Sets the collection of icons used in drawing this combobox. The icons in this collection
        /// must match the corresponding index of the combobox item.
        /// </summary>
        public Collection<Icon> xIconList
        {
            get
            {
                return (m_xIconList);
            }
            set
            {
                m_xIconList = value;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            m_xCustomComboBoxDropDownWindow = new CustomComboBoxDropDownWindow();
            m_xCustomComboBoxDropDownWindow.AssignHandle(this.Handle);

            m_xCustomComboBoxDropDownListener = new CustomComboBoxDropDownListener();
            m_xCustomComboBoxDropDownListener.AssignHandle(this.Handle);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            try
            {
                Rectangle xTextRectangle;
                Rectangle xIconRectangle;
                if (e.Index >= 0 && m_xIconList != null && m_xIconList[e.Index] != null)
                {
                    xTextRectangle = new Rectangle(e.Bounds.Left + ICON_SIZE + 2, e.Bounds.Top, e.Bounds.Width - ICON_SIZE - 2, e.Bounds.Height);
                    xIconRectangle = new Rectangle(e.Bounds.Left, e.Bounds.Top, ICON_SIZE, ICON_SIZE);
                }
                else
                {
                    xTextRectangle = xIconRectangle = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
                }

                e.DrawBackground();

                if (e.Index >= 0)
                {
                    using (Brush xTextBrush = new SolidBrush(e.ForeColor))
                    {
                        e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, xTextBrush, xTextRectangle);
                    }

                    if (m_xIconList != null && m_xIconList[e.Index] != null)
                    {
                        e.Graphics.DrawIcon(m_xIconList[e.Index], xIconRectangle);
                    }
                }
                base.OnDrawItem(e);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue >= 0x30)
                {
                    bool bStringFounded = false;

                    for (int iIndex = 0; iIndex < Items.Count; iIndex++)
                    {
                        int iComboBoxTextLength = Text.Length;
                        string strComboBoxItemText = Items[iIndex].ToString();
                        if (strComboBoxItemText.Length >= iComboBoxTextLength && strComboBoxItemText.Substring(0, iComboBoxTextLength) == Text.ToUpper())
                        {
                            bStringFounded = true;
                            break;
                        }
                    }

                    if (bStringFounded != true)
                    {
                        char cKeyValue = (char)e.KeyValue;
                        if (Text.ToUpper().IndexOf(cKeyValue, Text.Length - 1) == Text.Length - 1)
                        {
                            Text = string.Empty;
                        }
                    }
                }
                else if (e.KeyValue == 13)
                {
                    int iIndex = 0;
                    for (iIndex = 0; iIndex < Items.Count; iIndex++)
                    {
                        string strItemText = Items[iIndex].ToString();
                        if (strItemText == Text)
                        {
                            SelectedItem = Items[iIndex];
                            EventArgs xEventArgs = new EventArgs();
                            OnSelectionChangeCommitted(xEventArgs);
                            break;
                        }
                    }
                }
                base.OnKeyUp(e);
            }
            catch (Exception xException)
            {
                xException.strTraceError();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            base.OnSelectionChangeCommitted(e);
        }

        delegate bool bResetComboBoxItemsDelegate();
        public bool bResetComboBoxItems()
        {
            bool bReturnValue = false;
            if (this.InvokeRequired == true)
            {
                bReturnValue = (bool)this.Invoke(new bResetComboBoxItemsDelegate(bResetComboBoxItems));
            }
            else
            {
                if (this.Items.Count > 0)
                {
                    this.SelectedIndex = 0;
                    bReturnValue = true;
                }
            }
            return bReturnValue;
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
