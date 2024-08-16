using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.UserInterface.Controls
{
    interface ICustomControl
    {
        string strName { get; set; }
        string strType { get; set; }
        string strFunction1 { get; set; }
        string strFunction2 { get; set; }
        EventHandler xEventHandler1 { get; set; }
        EventHandler xEventHandler2 { get; set; }
    }
}
