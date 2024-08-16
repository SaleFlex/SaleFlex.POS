using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SaleFlex.UserInterface.Controls
{
    public delegate void delegate_vNewKey(NewKeyEventArgs prm_xNewKeyEventArgs);

    interface ICustomKeyboard
    {
        event delegate_vNewKey eventNewKey;
        Point Location { get; set; }
        DialogResult ShowDialog();
    }
}
