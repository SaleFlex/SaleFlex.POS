using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using SaleFlex.Windows;
using SaleFlex.CommonLibrary;

namespace SaleFlex.UserInterface.Controls
{
    class CustomComboBoxSelectionChangeDetector : NativeWindow
    {
        private IntPtr m_pHwndComboBox;
        public event EventHandler OnSelectionItemChange;

        public CustomComboBoxSelectionChangeDetector(IntPtr prm_pHwndComboBox)
        {
            m_pHwndComboBox = prm_pHwndComboBox;
        }

        protected virtual void OnSelectionChange(EventArgs e)
        {
            if (OnSelectionItemChange != null)
            {
                OnSelectionItemChange(this, e);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case Api.WM_COMMAND:
                    if (m.LParam == m_pHwndComboBox)
                    {
                        int notifyMessage = (int)((((uint)m.WParam) & 0xffff0000) >> 16);

                        if (notifyMessage == Api.CBN_EDITCHANGE || notifyMessage == Api.CBN_SELCHANGE)
                        {
                            this.OnSelectionChange(new EventArgs());
                        }
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
