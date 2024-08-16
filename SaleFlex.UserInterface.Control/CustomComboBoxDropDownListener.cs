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
using SaleFlex.CommonLibrary;
using SaleFlex.Windows;

namespace SaleFlex.UserInterface.Controls
{
    public delegate void DropDownMouseMove(int x, int y);

    class CustomComboBoxDropDownListener : NativeWindow
    {
        public event DropDownMouseMove OnDropDownMouseMove;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case Api.WM_MOUSEMOVE:
                    if (OnDropDownMouseMove != null)
                    {
                        OnDropDownMouseMove(Api.LOWORD(m.LParam.ToInt32()), Api.HIWORD(m.LParam.ToInt32()));
                    }
                    break;
                case Api.WM_MOUSEWHEEL:
                    if (OnDropDownMouseMove != null)
                    {
                        POINT pt = new POINT();
                        Api.GetCursorPos(ref pt);
                        Api.ScreenToClient(m.HWnd, ref pt);

                        OnDropDownMouseMove(pt.iX, pt.iY);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
