using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

using SaleFlex.CommonLibrary;
using SaleFlex.Windows;

namespace SaleFlex.UserInterface.Controls
{
    class CustomComboBoxDropDownWindow : NativeWindow
    {
        private IntPtr m_pHwndDropDown;
        private IntPtr m_pTooltipHandle;
        private CustomComboBoxCloseUpDetector m_xCloseUpDetector;
        private CustomComboBoxDropDownListener m_xCustomComboBoxDropDownListener;
        private CustomComboBoxSelectionChangeDetector m_xSelectionChangeDetector;
        private TOOLINFO m_structToolInfo;
        private Timer m_xTimer;
        private bool m_bIsVisible;


        public CustomComboBoxDropDownWindow()
        {
            m_structToolInfo = new TOOLINFO();

            m_xTimer = new Timer();
            m_xTimer.Enabled = false;
            m_xTimer.Interval = 90;
            m_xTimer.Tick += new EventHandler(_Timer_Tick);
        }

        public new void AssignHandle(IntPtr prm_pHandle)
        {
            base.AssignHandle(prm_pHandle);
            m_xCloseUpDetector = new CustomComboBoxCloseUpDetector(prm_pHandle);
            m_xCloseUpDetector.AssignHandle(Api.GetParent(prm_pHandle));
            m_xCloseUpDetector.OnDropDownWindowDisappered += new EventHandler(vCloseUpDetector_OnDropDownWindowDisappered);
            m_xSelectionChangeDetector = new CustomComboBoxSelectionChangeDetector(prm_pHandle);
            m_xSelectionChangeDetector.AssignHandle(Api.GetParent(prm_pHandle));
            m_xSelectionChangeDetector.OnSelectionItemChange += new EventHandler(m_xSelectionChangeDetector_OnSelectionItemChange);
        }

        void m_xSelectionChangeDetector_OnSelectionItemChange(object sender, EventArgs e)
        {
            POINT structPoint = new POINT();

            Api.GetCursorPos(ref structPoint);
            Api.ScreenToClient(m_pHwndDropDown, ref structPoint);

            this.HandleMouseMove(structPoint.iX, structPoint.iY);
        }

        void vCloseUpDetector_OnDropDownWindowDisappered(object sender, EventArgs e)
        {
            Api.DestroyWindow(m_pTooltipHandle);
            m_bIsVisible = false;
        }

        private void CreateTooltip()
        {
            m_pTooltipHandle = Api.CreateWindowExW(Api.WS_EX_TOPMOST, "tooltips_class32", null, Api.TTS_NOPREFIX,
                                                   (uint)0x80000000, (uint)0x80000000, (uint)0x80000000, (uint)0x80000000,
                                                   m_pHwndDropDown, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            m_structToolInfo.cbSize = (uint)Marshal.SizeOf(typeof(TOOLINFO));
            m_structToolInfo.uFlags = Api.TTF_TRACK | Api.TTF_TRANSPARENT;
            m_structToolInfo.hwnd = m_pHwndDropDown;

            Api.SendMessage(m_pTooltipHandle, Api.TTM_SETMAXTIPWIDTH, new IntPtr(0), new IntPtr(short.MaxValue));
            Api.SendMessage(m_pTooltipHandle, Api.TTM_ADDTOOLW, new IntPtr(0), ref m_structToolInfo);
            Api.SendMessage(m_pTooltipHandle, Api.TTM_SETTIPBKCOLOR, new IntPtr(ColorTranslator.ToWin32(SystemColors.Highlight)), new IntPtr(0));
            Api.SendMessage(m_pTooltipHandle, Api.TTM_SETTIPTEXTCOLOR, new IntPtr(ColorTranslator.ToWin32(SystemColors.HighlightText)), new IntPtr(0));

            RECT margins = new RECT();
            IntPtr p;
            IntPtr hFont;

            margins.Left = 0;
            margins.Top = -1;
            margins.Right = 0;
            margins.Bottom = -1;

            p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(RECT)));

            Marshal.StructureToPtr(margins, p, false);

            Api.SendMessage(m_pTooltipHandle, Api.TTM_SETMARGIN, new IntPtr(0), p);

            Marshal.FreeHGlobal(p);

            hFont = (IntPtr)Api.SendMessage(m_pHwndDropDown, Api.WM_GETFONT, IntPtr.Zero, IntPtr.Zero);

            Api.SendMessage(m_pTooltipHandle, Api.WM_SETFONT, hFont, new IntPtr(0));

            int style = Api.GetWindowLong(m_pTooltipHandle, Api.GWL_STYLE);
            style &= ~Api.WS_BORDER;
            Api.SetWindowLong(m_pTooltipHandle, Api.GWL_STYLE, style);

        }

        private void HandleMouseMove(int x, int y)
        {
            RECT rcClient;
            POINT pt = new POINT();

            pt.iX = x;
            pt.iY = y;

            Api.GetClientRect(m_pHwndDropDown, out rcClient);

            if (Api.PtInRect(ref rcClient, pt) != 0)
            {
                POINT ptScreen = new POINT();
                int nItem;
                int isInside;
                Api.GetCursorPos(ref ptScreen);

                nItem = Api.SendMessage(m_pHwndDropDown, Api.LB_GETCURSEL, IntPtr.Zero, IntPtr.Zero);

                isInside = 0;
                if (nItem >= 0 && isInside == 0)
                {
                    string text;
                    RECT itemRect;
                    RECT rect;
                    SIZE size;
                    IntPtr hdc;
                    POINT ptItem;
                    IntPtr pRect;
                    IntPtr hFont;
                    IntPtr hOldFont;
                    System.Text.StringBuilder sb;
                    int len;

                    len = Api.SendMessage(m_pHwndDropDown, Api.LB_GETTEXTLEN, new IntPtr(nItem), IntPtr.Zero);

                    sb = new StringBuilder(len);
                    Api.SendMessage(m_pHwndDropDown, Api.LB_GETTEXT, new IntPtr(nItem), sb);

                    m_structToolInfo.lpszText = sb.ToString();
                    text = m_structToolInfo.lpszText;

                    pRect = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(RECT)));

                    Api.SendMessage(m_pHwndDropDown, Api.LB_GETITEMRECT, new IntPtr(nItem), pRect);

                    itemRect = (RECT)Marshal.PtrToStructure(pRect, typeof(RECT));

                    Marshal.FreeHGlobal(pRect);

                    ptItem = new POINT();
                    ptItem.iX = itemRect.Left;
                    ptItem.iY = itemRect.Top;

                    /*Convert the item rectangle to screen coordinates*/
                    Api.ClientToScreen(m_pHwndDropDown, ref ptItem);

                    hdc = Api.GetDC(m_pHwndDropDown);

                    hFont = (IntPtr)Api.SendMessage(m_pHwndDropDown, Api.WM_GETFONT, IntPtr.Zero, IntPtr.Zero);

                    hOldFont = Api.SelectObject(hdc, hFont);

                    Api.GetTextExtentPoint32W(hdc, text, text.Length, out size);

                    Api.SelectObject(hdc, hOldFont);

                    Api.ReleaseDC(m_pHwndDropDown, hdc);

                    rect = new RECT();
                    rect.Left = ptItem.iX;
                    rect.Top = ptItem.iY;
                    rect.Right = rect.Left + (itemRect.Right - itemRect.Left);
                    rect.Bottom = rect.Top + (itemRect.Bottom - itemRect.Top);

                    if (size.cx > ((rect.Right - rect.Left) - 3))
                    {
                        Api.SendMessage(m_pTooltipHandle, Api.TTM_UPDATETIPTEXTW, new IntPtr(0), ref m_structToolInfo);
                        Api.SendMessage(m_pTooltipHandle, Api.TTM_TRACKPOSITION, new IntPtr(0), new IntPtr(Api.MakeLong(rect.Left, rect.Top)));
                        Api.SendMessage(m_pTooltipHandle, Api.TTM_TRACKACTIVATE, new IntPtr(1), ref m_structToolInfo);

                        m_xTimer.Start();

                    }
                    else
                    {
                        Api.SendMessage(m_pTooltipHandle, Api.TTM_TRACKACTIVATE, new IntPtr(0), ref m_structToolInfo);

                    }
                }
                else
                {
                    Api.SendMessage(m_pTooltipHandle, Api.TTM_TRACKACTIVATE, new IntPtr(0), ref m_structToolInfo);

                }
            }
            else
            {
                Api.SendMessage(m_pTooltipHandle, Api.TTM_TRACKACTIVATE, new IntPtr(0), ref m_structToolInfo);

            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case Api.WM_CTLCOLORLISTBOX:
                    if (m_pHwndDropDown == IntPtr.Zero || m_bIsVisible == false)
                    {
                        m_xCustomComboBoxDropDownListener = new CustomComboBoxDropDownListener();
                        m_xCustomComboBoxDropDownListener.AssignHandle(m.LParam);
                        m_xCustomComboBoxDropDownListener.OnDropDownMouseMove += new DropDownMouseMove(_DropDownListener_OnDropDownMouseMove);

                        m_pHwndDropDown = m.LParam;

                        /*Create the tooltip here*/
                        CreateTooltip();

                        m_bIsVisible = true;
                    }
                    break;
            }
        }

        void _DropDownListener_OnDropDownMouseMove(int x, int y)
        {
            this.HandleMouseMove(x, y);
        }

        void _Timer_Tick(object sender, EventArgs e)
        {
            POINT pt = new POINT();
            RECT rcClient;
            int style;

            Api.GetCursorPos(ref pt);
            Api.ScreenToClient(m_pHwndDropDown, ref pt);

            Api.GetClientRect(m_pHwndDropDown, out rcClient);

            style = Api.GetWindowLong(m_pHwndDropDown, Api.GWL_STYLE);

            if ((Api.PtInRect(ref rcClient, pt) == 0) || ((style & Api.WS_VISIBLE) == 0))
            {
                // Deactivate the tooltip if the mouse moves outside of the client area
                m_xTimer.Stop();
                Api.SendMessage(m_pTooltipHandle, Api.TTM_TRACKACTIVATE, new IntPtr(0), ref m_structToolInfo);
            }
        }
    }
}
