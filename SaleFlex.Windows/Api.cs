using System;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Management;
using System.Net.NetworkInformation;

namespace SaleFlex.Windows
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct LV_ITEM
    {
        public UInt32 mask;
        public Int32 iItem;
        public Int32 iSubItem;
        public UInt32 state;
        public UInt32 stateMask;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszText;
        public Int32 cchTextMax;
        public Int32 iImage;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
    public struct POINT
    {
        public int iX;
        public int iY;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
    public struct SIZE
    {
        public int cx;
        public int cy;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
    public struct LVHITTESTINFO
    {
        public POINT pt;
        public uint flags;
        public int iItem;
        public int iSubItem;
        public int iGroup;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
    public struct LVFINDINFO
    {
        public uint flags;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string psz;
        public IntPtr lParam;
        public POINT pt;
        public uint vkDirection;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
    public struct TOOLINFO
    {
        public uint cbSize;
        public uint uFlags;
        public IntPtr hwnd;
        public IntPtr uId;
        public RECT rect;
        public IntPtr hInst;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszText;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
    public struct APPBARDATA
    {
        public uint cbSize;
        public IntPtr hwnd;
        public uint uCallbackMessage;
        public uint uEdge;
        public RECT rc;
        public IntPtr lParam;
    }

    /// <summary>
    /// Constant values were found in the "windows.h" header file.
    /// </summary>
    public static class Api
    {
        public const int WM_USER = 0x0400;
        public const int WM_CREATE = 0X0001;
        public const int WM_SETFONT = 0x0030;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_CTLCOLORLISTBOX = 0x0134;
        public const int WM_GETFONT = 0x0031;
        public const int WM_GETTEXT = 0x000D;
        public const int WM_GETTEXTLENGTH = 0x000E;
        public const int WM_MOUSEWHEEL = 0x020A;
        public const int WM_COMMAND = 0x111;

        public const int SB_LINEUP = 0;
        public const int SB_LINEDOWN = 1;

        public const int CBN_CLOSEUP = 8;
        public const int CBN_SELCHANGE = 1;
        public const int CBN_DBLCLK = 2;
        public const int CBN_SETFOCUS = 3;
        public const int CBN_KILLFOCUS = 4;
        public const int CBN_EDITCHANGE = 5;

        public const int WS_EX_TOPMOST = 0x00000008;

        public const int WS_CHILD = 0x40000000;
        public const int WS_VISIBLE = 0x10000000;
        public const int WS_VSCROLL = 0x00200000;
        public const int WS_TABSTOP = 0x00010000;
        public const int WS_BORDER = 0x00800000;

        public const int LVFI_PARAM = 0x0001;
        public const int LVFI_STRING = 0x0002;
        public const int LVFI_PARTIAL = 0x0008;
        public const int LVFI_WRAP = 0x0020;
        public const int LVFI_NEARESTXY = 0x0040;

        public const int LVM_FIRST = 0x1000;
        public const int LVM_HITTEST = (LVM_FIRST + 18);
        public const int LVM_SUBITEMHITTEST = (LVM_FIRST + 57);
        public const int LVM_GETSUBITEMRECT = (LVM_FIRST + 56);
        public const int LVM_GETITEMRECT = (LVM_FIRST + 14);
        public const int LVM_FINDITEMW = (LVM_FIRST + 83);
        public const Int32 LVM_GETITEM = LVM_FIRST + 5;
        public const Int32 LVM_SETITEM = LVM_FIRST + 76;
        public const Int32 LVIF_TEXT = 0x0001;
        public const Int32 LVIF_IMAGE = 0x0002;

        public const int LVM_GETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 54;
        public const int LVM_GETITEMTEXT = LVM_FIRST + 45;

        public const int LVM_SORTITEMSEX = (LVM_FIRST + 81);

        public const int LVS_EX_GRIDLINES = 0x00000001;
        public const int LVS_EX_SUBITEMIMAGES = 0x00000002;
        public const int LVS_EX_CHECKBOXES = 0x00000004;
        public const int LVS_EX_TRACKSELECT = 0x00000008;
        public const int LVS_EX_HEADERDRAGDROP = 0x00000010;
        public const int LVS_EX_FULLROWSELECT = 0x00000020;
        public const int LVS_EX_ONECLICKACTIVATE = 0x00000040;


        public const int LVS_EX_FLATSB = 0x00000100;
        public const int LVS_EX_REGIONAL = 0x00000200;
        public const int LVS_EX_INFOTIP = 0x00000400;
        public const int LVS_EX_UNDERLINEHOT = 0x00000800;
        public const int LVS_EX_UNDERLINECOLD = 0x00001000;
        public const int LVS_EX_MULTIWORKAREAS = 0x00002000;
        public const int LVS_EX_LABELTIP = 0x00004000;
        public const int LVS_EX_BORDERSELECT = 0x00008000;
        public const int LVS_EX_DOUBLEBUFFER = 0x00010000;
        public const int LVS_EX_HIDELABELS = 0x00020000;
        public const int LVS_EX_SINGLEROW = 0x00040000;
        public const int LVS_EX_SNAPTOGRID = 0x00080000;
        public const int LVS_EX_SIMPLESELECT = 0x00100000;

        public const int WM_HSCROLL = 0x114;
        public const int WM_VSCROLL = 0x115;

        public const int LVIR_BOUNDS = 0;
        public const int LVIR_ICON = 1;
        public const int LVIR_LABEL = 2;
        public const int LVIR_SELECTBOUNDS = 3;

        /*Tooltip definitions*/
        public const int TTS_ALWAYSTIP = 0x01;
        public const int TTS_NOPREFIX = 0x02;
        public const int TTS_NOANIMATE = 0x10;
        public const int TTS_NOFADE = 0x20;
        public const int TTS_BALLOON = 0x40;
        public const int TTS_CLOSE = 0x80;


        public const int TTF_IDISHWND = 0x0001;

        public const int TTF_CENTERTIP = 0x0002;
        public const int TTF_RTLREADING = 0x0004;
        public const int TTF_SUBCLASS = 0x0010;
        public const int TTF_TRACK = 0x0020;
        public const int TTF_ABSOLUTE = 0x0080;
        public const int TTF_TRANSPARENT = 0x0100;
        public const int TTF_PARSELINKS = 0x1000;
        public const int TTF_DI_SETITEM = 0x8000;


        public const int TTDT_AUTOMATIC = 0;
        public const int TTDT_RESHOW = 1;
        public const int TTDT_AUTOPOP = 2;
        public const int TTDT_INITIAL = 3;

        public const int TTI_NONE = 0;
        public const int TTI_INFO = 1;
        public const int TTI_WARNING = 2;
        public const int TTI_ERROR = 3;

        public const int TTM_ACTIVATE = (WM_USER + 1);
        public const int TTM_SETDELAYTIME = (WM_USER + 3);
        public const int TTM_ADDTOOLA = (WM_USER + 4);
        public const int TTM_ADDTOOLW = (WM_USER + 50);
        public const int TTM_DELTOOLA = (WM_USER + 5);
        public const int TTM_DELTOOLW = (WM_USER + 51);
        public const int TTM_NEWTOOLRECTA = (WM_USER + 6);
        public const int TTM_NEWTOOLRECTW = (WM_USER + 52);
        public const int TTM_RELAYEVENT = (WM_USER + 7);

        public const int TTM_GETTOOLINFOA = (WM_USER + 8);
        public const int TTM_GETTOOLINFOW = (WM_USER + 53);

        public const int TTM_SETTOOLINFOA = (WM_USER + 9);
        public const int TTM_SETTOOLINFOW = (WM_USER + 54);

        public const int TTM_HITTESTA = (WM_USER + 10);
        public const int TTM_HITTESTW = (WM_USER + 55);
        public const int TTM_GETTEXTA = (WM_USER + 11);
        public const int TTM_GETTEXTW = (WM_USER + 56);
        public const int TTM_UPDATETIPTEXTA = (WM_USER + 12);
        public const int TTM_UPDATETIPTEXTW = (WM_USER + 57);
        public const int TTM_GETTOOLCOUNT = (WM_USER + 13);
        public const int TTM_ENUMTOOLSA = (WM_USER + 14);
        public const int TTM_ENUMTOOLSW = (WM_USER + 58);
        public const int TTM_GETCURRENTTOOLA = (WM_USER + 15);
        public const int TTM_GETCURRENTTOOLW = (WM_USER + 59);
        public const int TTM_WINDOWFROMPOINT = (WM_USER + 16);
        public const int TTM_TRACKACTIVATE = (WM_USER + 17);
        public const int TTM_TRACKPOSITION = (WM_USER + 18);
        public const int TTM_SETTIPBKCOLOR = (WM_USER + 19);
        public const int TTM_SETTIPTEXTCOLOR = (WM_USER + 20);
        public const int TTM_GETDELAYTIME = (WM_USER + 21);
        public const int TTM_GETTIPBKCOLOR = (WM_USER + 22);
        public const int TTM_GETTIPTEXTCOLOR = (WM_USER + 23);
        public const int TTM_SETMAXTIPWIDTH = (WM_USER + 24);
        public const int TTM_GETMAXTIPWIDTH = (WM_USER + 25);
        public const int TTM_SETMARGIN = (WM_USER + 26);
        public const int TTM_GETMARGIN = (WM_USER + 27);
        public const int TTM_POP = (WM_USER + 28);
        public const int TTM_UPDATE = (WM_USER + 29);
        public const int TTM_GETBUBBLESIZE = (WM_USER + 30);
        public const int TTM_ADJUSTRECT = (WM_USER + 31);
        public const int TTM_SETTITLEA = (WM_USER + 32);
        public const int TTM_SETTITLEW = (WM_USER + 33);
        public const int TTM_POPUP = (WM_USER + 34);
        public const int TTM_GETTITLE = (WM_USER + 35);

        public const int STM_SETICON = 0x0170;


        /* Ternary raster operations */
        public const int SRCCOPY = 0x00CC0020;
        public const int SRCPAINT = 0x00EE0086;
        public const int SRCAND = 0x008800C6;
        public const int SRCINVERT = 0x00660046;
        public const int SRCERASE = 0x00440328;
        public const int NOTSRCCOPY = 0x00330008;
        public const int NOTSRCERASE = 0x001100A6;
        public const int MERGECOPY = 0x00C000CA;
        public const int MERGEPAINT = 0x00BB0226;
        public const int PATCOPY = 0x00F00021;
        public const int PATPAINT = 0x00FB0A09;
        public const int PATINVERT = 0x005A0049;
        public const int DSTINVERT = 0x00550009;
        public const int BLACKNESS = 0x00000042;
        public const int WHITENESS = 0x00FF0062;

        public const int CAPTUREBLT = 0x40000000;

        public const int AW_BLEND = 0x00080000;
        public const int AW_HIDE = 0x00010000;

        public const int GWL_WNDPROC = (-4);
        public const int GWL_HINSTANCE = (-6);
        public const int GWL_HWNDPARENT = (-8);
        public const int GWL_STYLE = (-16);
        public const int GWL_EXSTYLE = (-20);
        public const int GWL_USERDATA = (-21);
        public const int GWL_ID = (-12);

        public const int CBS_SIMPLE = 0x0001;
        public const int CBS_DROPDOWN = 0x0002;
        public const int CBS_DROPDOWNLIST = 0x0003;
        public const int CBS_OWNERDRAWFIXED = 0x0010;
        public const int CBS_OWNERDRAWVARIABLE = 0x0020;
        public const int CBS_AUTOHSCROLL = 0x0040;
        public const int CBS_OEMCONVERT = 0x0080;
        public const int CBS_SORT = 0x0100;
        public const int CBS_HASSTRINGS = 0x0200;
        public const int CBS_NOINTEGRALHEIGHT = 0x0400;
        public const int CBS_DISABLENOSCROLL = 0x0800;
        public const int CBS_UPPERCASE = 0x2000;
        public const int CBS_LOWERCASE = 0x4000;

        public const int LB_ITEMFROMPOINT = 0x01A9;
        public const int LB_GETTEXT = 0x0189;
        public const int LB_GETITEMRECT = 0x0198;
        public const int LB_GETTEXTLEN = 0x018A;
        public const int LB_GETCURSEL = 0x0188;

        public const int ABM_NEW = 0;
        public const int ABM_REMOVE = 1;
        public const int ABM_QUERYPOS = 2;
        public const int ABM_SETPOS = 3;
        public const int ABM_GETSTATE = 4;
        public const int ABM_GETTASKBARPOS = 5;
        public const int ABM_ACTIVATE = 6;
        public const int ABM_GETAUTOHIDEBAR = 7;
        public const int ABM_SETAUTOHIDEBAR = 8;
        public const int ABM_WINDOWPOSCHANGED = 9;
        public const int ABM_SETSTATE = 10;

        public const int SS_CENTER = 0x00000001;
        public const int SS_ICON = 0x00000003;
        public const int SS_CENTERIMAGE = 0x00000200;
        public const int SS_WORDELLIPSIS = 0x0000C000;

        public static int MakeLong(int loWord, int hiWord)
        {
            return (hiWord << 16) | (loWord & 0xffff);
        }

        public static IntPtr MakeLParam(int loWord, int hiWord)
        {
            return new IntPtr((hiWord << 16) | (loWord & 0xffff));
        }

        public static int LOWORD(int number)
        {
            return (number & 0xffff);
        }

        public static int HIWORD(int number)
        {
            return (number >> 16) & 0xffff;
        }

        public enum EXECUTION_STATE : uint
        {
            ES_SYSTEM_REQUIRED = 0x00000001,
            ES_DISPLAY_REQUIRED = 0x00000002,
            // Legacy flag, should not be used.
            // ES_USER_PRESENT   = 0x00000004,
            ES_CONTINUOUS = 0x80000000,
        }

        [DllImport("user32.dll")]
        public static extern bool DestroyWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int PtInRect(ref RECT lprc, POINT pt);

        [DllImport("gdi32.dll")]
        public static extern int GetTextExtentPoint32W(IntPtr hdc, [MarshalAs(UnmanagedType.LPWStr)] string lpString, int cbString, out SIZE lpSize);

        [DllImport("user32.dll")]
        public static extern int ScreenToClient(IntPtr hwnd, ref POINT pt);

        [DllImport("user32.dll")]
        public static extern int ClientToScreen(IntPtr hwnd, ref POINT pt);

        [DllImport("user32.dll")]
        public static extern int GetClientRect(IntPtr hwnd, out RECT rcClient);

        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, out RECT rcWindow);

        [DllImport("user32.dll")]
        public static extern int GetCursorPos(ref POINT pt);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int index, int val);

        [DllImport("user32.dll")]
        public static extern int IsWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int DefWindowProc(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);


        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr CreateWindowExW(uint dwExStyle, [MarshalAs(UnmanagedType.LPWStr)] string lpClassName, [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName,
                                                    uint dwStyle, uint x, uint y, uint nWidth, uint nHeight,
                                                    IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hGdiObj);

        [DllImport("gdi32.dll")]
        public static extern int DeleteObject(IntPtr hGdiObj);


        [DllImport("gdi32.dll")]
        public static extern bool GdiFlush();

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight,
                                         IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr hdc, uint dwTime, uint dwFlags);

        [DllImport("user32.dll")]
        public static extern int SendMessage(
            IntPtr hWnd,	// handle to destination window 
            int Msg,		// message 
            IntPtr wParam,	// first message parameter 
            IntPtr lParam	// second message parameter 
            );

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(
            IntPtr hWnd,	// handle to destination window 
            int Msg,		// message 
            IntPtr wParam,	// first message parameter
            [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder lParam	// second message parameter 
            );


        [DllImport("user32.dll")]
        public static extern bool SendMessage(
            IntPtr hWnd,		// handle to destination window 
            UInt32 msg,			// message 
            IntPtr wParam,
            ref LVHITTESTINFO lParam);// pointer to struct of LVHITTESTINFO

        [DllImport("user32.dll")]
        public static extern bool SendMessage(
            IntPtr hWnd,		// handle to destination window 
            UInt32 msg,			// message 
            IntPtr wParam,
            ref RECT lParam);// pointer to struct of RECT

        [DllImport("user32.dll")]
        public static extern bool SendMessage(
            IntPtr hWnd,		// handle to destination window 
            UInt32 msg,			// message 
            IntPtr wParam,
            ref LV_ITEM lParam);// pointer to struct of RECT

        [DllImport("shell32.dll")]
        public static extern IntPtr SHAppBarMessage(uint dwMessage,
           [In] ref APPBARDATA pData);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, UInt32 msg, IntPtr wParam, ref TOOLINFO lParam);

        [DllImport("user32.dll")]
        public static extern int GetSystemMenu(int hwnd, int bRevert);

        [DllImport("user32.dll")]
        public static extern int AppendMenu(int hMenu, int Flagsw, int IDNewItem, string lpNewItem);

        [DllImport("user32.dll", EntryPoint = "BringWindowToTop")]
        public static extern int BringWindowToTop(
            int hWnd         // handle to destination window 
            );

        [DllImport("user32.dll")]
        public static extern bool HideCaret(
            IntPtr hWnd         // handle to destination window 
            );

        [DllImport("user32.dll")]
        public static extern bool ShowCaret(
            IntPtr hWnd         // handle to destination window 
            );

        // System API used to set screensaver state
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uiAction, bool uiParam, uint pvParam, uint init);

        public const uint SPI_SETSCREENSAVEACTIVE = 0x0011;

        // System API used to get screen saver state
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, out bool pvParam, uint init);

        public const uint SPI_GETSCREENSAVEACTIVE = 0x0010;

        // System API used to prevent the display sleeping
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public static void PreventMonitorPowerdown()
        {
            SystemParametersInfo(SPI_SETSCREENSAVEACTIVE, false, 0, 0);
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
        }


        public static void AllowMonitorPowerdown()
        {
            SystemParametersInfo(SPI_SETSCREENSAVEACTIVE, true, 0, 0);
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }

        private const byte VK_NUMLOCK = 0x90;
        private const uint KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 0x2;
        private const int KEYEVENTF_KEYDOWN = 0x0;

        public static bool GetNumLock()
        {
            return (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
        }

        public static void SetNumLock(bool bState)
        {
            if (GetNumLock() != bState)
            {
                keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN, 0);
                keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        // Return Type: BOOL
        [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll", EntryPoint = "SetSystemTime")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool SetSystemTime([InAttribute()] ref SYSTEMTIME lpSystemTime);

        public static bool SetSystemDateTime(DateTime prm_xNewDateTime)
        {
            bool bResult = false;

            try
            {
                prm_xNewDateTime = prm_xNewDateTime.ToUniversalTime();

                SYSTEMTIME sysTime = new SYSTEMTIME()
                {
                    wYear = (short)prm_xNewDateTime.Year /* must be short */,
                    wMonth = (short)prm_xNewDateTime.Month,
                    wDayOfWeek = (short)prm_xNewDateTime.DayOfWeek,
                    wDay = (short)prm_xNewDateTime.Day,
                    wHour = (short)prm_xNewDateTime.Hour,
                    wMinute = (short)prm_xNewDateTime.Minute,
                    wSecond = (short)prm_xNewDateTime.Second,
                    wMilliseconds = (short)prm_xNewDateTime.Millisecond
                };

                bResult = SetSystemTime(ref sysTime);
            }
            catch (Exception)
            {
                bResult = false;
            }
            return bResult;
        }

        public static string GetDriveSerialNumber()
        {
            string strSerialNumber = "N.A.";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia");
                foreach (ManagementObject obj in searcher.Get())
                {
                    strSerialNumber = obj["SerialNumber"]?.ToString() ?? "Seri numarası bulunamadı";
                    break; // İlk fiziksel diskin seri numarasını almak yeterli
                }
            }
            catch (Exception ex)
            {
                
            }
            return strSerialNumber;
        }

        public static string GetMacAddress()
        {
            string strMacAddr =
                (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                ).FirstOrDefault();
            return strMacAddr ?? "N.A.";
        }
    }
}
