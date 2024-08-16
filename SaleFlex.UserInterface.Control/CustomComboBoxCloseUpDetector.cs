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
    class CustomComboBoxCloseUpDetector : NativeWindow
    {
        private IntPtr m_pHwndComboBox;

        public event EventHandler OnDropDownWindowDisappered;

        /// <summary>
        /// Occurs when the drop-down window is dismissed and disappears.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCloseUp(EventArgs e)
        {
            if (OnDropDownWindowDisappered != null)
            {
                OnDropDownWindowDisappered(this, e);
            }
        }

        public CustomComboBoxCloseUpDetector(IntPtr prm_pHwndComboBox)
        {
            m_pHwndComboBox = prm_pHwndComboBox;
        }

        protected override void WndProc(ref Message prm_xMessage)
        {
            base.WndProc(ref prm_xMessage);

            switch (prm_xMessage.Msg)
            {
                case Api.WM_COMMAND:
                    if (prm_xMessage.LParam == m_pHwndComboBox)
                    {
                        int notifyMessage = (int)((((uint)prm_xMessage.WParam) & 0xffff0000) >> 16);

                        if (notifyMessage == Api.CBN_CLOSEUP)
                        {
                            this.OnCloseUp(new EventArgs());
                        }
                    }
                    break;
            }
        }
    }
}
