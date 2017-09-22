using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Net;
using System.Management;
using Microsoft.Win32;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Net.Mail;

namespace Infrastructure.Library.Utility
{
    //************************Machine*********************************************
    public class Machine
    {
        public void SendMail()
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress("" + "Admin@aaa.com" + "", "Admin");

            message.To.Add(new MailAddress("" + ""+ ""));

            //message.CC.Add(new MailAddress("carboncopy@foo.bar.com"));

            message.Subject = "" + "subject" + "";

            message.Body = "";
            message.BodyEncoding = System.Text.Encoding.GetEncoding("gb2312");
            SmtpClient client = new SmtpClient();
            //client.Credentials = new NetworkCredential("200759599@qq.com", "xuyuebai@");
            client.Send(message);
        }

        IPAddress hostIPAddress =
                   Dns.GetHostAddresses(Dns.GetHostName())[0];

        public string IPAddress
        {
            get
            {
                return hostIPAddress.ToString();
            }
        }

        public BindingList<string> COM
        {
            get
            {
                BindingList<string> result = new BindingList<string>();
                try
                {
                    RegistryKey softwarekey = Registry.LocalMachine.OpenSubKey("HARDWARE", true);
                    RegistryKey dev = softwarekey.OpenSubKey("DEVICEMAP");
                    RegistryKey ser = dev.OpenSubKey("SERIALCOMM");
                    foreach (string sValName in ser.GetValueNames())
                    //开始遍历由指定子键拥有的键值名称组成的字符串数组 
                    {
                        result.Add(/*"" + sValName + ": " + */ser.GetValue(sValName).ToString());
                        //在列表中加入键名称和对应的键值 
                    }
                }
                catch { }
                return result;
            }
        }//END COM

        public BindingList<string> CPU
        {
            get
            {
                BindingList<string> result = new BindingList<string>();
                string cpuInfo = "";//cpu序列号
                ManagementClass cimobject = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = cimobject.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    result.Add(cpuInfo.ToString());
                }
                return result;
            }
        }//END CPU

        public BindingList<string> HD
        {

            get
            {
                BindingList<string> result = new BindingList<string>();
                //获取硬盘ID
                String HDid;
                ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc1 = cimobject1.GetInstances();
                foreach (ManagementObject mo in moc1)
                {
                    HDid = (string)mo.Properties["Model"].Value;
                    result.Add(HDid.ToString());
                }
                return result;
            }
        }//END HD

        public BindingList<string> MAC
        {

            get
            {
                BindingList<string> result = new BindingList<string>();
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc2 = mc.GetInstances();
                foreach (ManagementObject mo in moc2)
                {
                    if ((bool)mo["IPEnabled"] == true)
                        result.Add(mo["MacAddress"].ToString());
                    mo.Dispose();
                }

                return result;
            }
        }//END MAC
        public static void Exp2Excel(DataTable dt, bool showHeader)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            //
            int firstColumn = 0;
            if (showHeader)
            {
                for (int m = 0; m < dt.Columns.Count; m++)
                {
                    excel.Cells[1, m + 1] = dt.Columns[m].ColumnName;
                }
                firstColumn = 1;
            }
            //
            excel.Cells.NumberFormatLocal = "@";
            //
            for (int i = 0; i < dt.Rows.Count; i++)
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    excel.Cells[i + 1 + firstColumn, j + 1] = dt.Rows[i].ItemArray.GetValue(j);
                }
            //
            excel.Columns.AutoFit();
            excel.Visible = true;
        }

        public static Bitmap CaptureDesktopWindow()
        {
            //创建屏幕句柄
            Graphics grpWindow = Graphics.FromHwnd(IntPtr.Zero);

            //创建一幅保存图像
            Bitmap bitmap = new Bitmap((int)grpWindow.VisibleClipBounds.Width, (int)grpWindow.VisibleClipBounds.Height, grpWindow);

            //创建bitmap相关的Grp类
            Graphics grpBitmap = Graphics.FromImage(bitmap);

            //窗口上下文
            IntPtr hdcWindow = grpWindow.GetHdc();

            //图片的上下文
            IntPtr hdcBitmap = grpBitmap.GetHdc();

            //拷贝
            Api.BitBlt(hdcBitmap, 0, 0, bitmap.Width, bitmap.Height, hdcWindow, 0, 0, 0x00CC0020);

            //释放关联grpBitmap句柄
            grpBitmap.ReleaseHdc(hdcBitmap);

            //释放关联grpWindow句柄
            grpWindow.ReleaseHdc(hdcWindow);

            //释放grpBitmap对象
            grpBitmap.Dispose();

            //释放grpWindow对象
            grpWindow.Dispose();

            //返回图像
            return bitmap;
            /*
            Image img = null;
            img = ScreenCapturing.CaptureDesktopWindow();
            img.Save("Test.Png", System.Drawing.Imaging.ImageFormat.Png);
            */
        }

        public static string EncryptString(string str)
        {
            char[] Base64Code = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/', '=' };
            byte empty = (byte)0;
            System.Collections.ArrayList byteMessage = new System.Collections.ArrayList(System.Text.Encoding.Default.GetBytes(str));
            System.Text.StringBuilder outmessage;
            int messageLen = byteMessage.Count;
            int page = messageLen / 3;
            int use = 0;
            if ((use = messageLen % 3) > 0)
            {
                for (int i = 0; i < 3 - use; i++)
                    byteMessage.Add(empty);
                page++;
            }
            outmessage = new System.Text.StringBuilder(page * 4);
            for (int i = 0; i < page; i++)
            {
                byte[] instr = new byte[3];
                instr[0] = (byte)byteMessage[i * 3];
                instr[1] = (byte)byteMessage[i * 3 + 1];
                instr[2] = (byte)byteMessage[i * 3 + 2];
                int[] outstr = new int[4];
                outstr[0] = instr[0] >> 2;

                outstr[1] = ((instr[0] & 0x03) << 4) ^ (instr[1] >> 4);
                if (!instr[1].Equals(empty))
                    outstr[2] = ((instr[1] & 0x0f) << 2) ^ (instr[2] >> 6);
                else
                    outstr[2] = 64;
                if (!instr[2].Equals(empty))
                    outstr[3] = (instr[2] & 0x3f);
                else
                    outstr[3] = 64;
                outmessage.Append(Base64Code[outstr[0]]);
                outmessage.Append(Base64Code[outstr[1]]);
                outmessage.Append(Base64Code[outstr[2]]);
                outmessage.Append(Base64Code[outstr[3]]);
            }
            return outmessage.ToString();
        }
        /**************************************************字符串解密算法**************************************************/
        public static string DecryptString(string str)
        {
            if ((str.Length % 4) != 0)
            {
                throw new ArgumentException("不是正确的BASE64编码，请检查。", "str");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(str, "^[A-Z0-9/+=]*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("包含不正确的BASE64编码，请检查。", "str");
            }
            string Base64Code = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+/=";
            int page = str.Length / 4;
            System.Collections.ArrayList outMessage = new System.Collections.ArrayList(page * 3);
            char[] message = str.ToCharArray();
            for (int i = 0; i < page; i++)
            {
                byte[] instr = new byte[4];
                instr[0] = (byte)Base64Code.IndexOf(message[i * 4]);
                instr[1] = (byte)Base64Code.IndexOf(message[i * 4 + 1]);
                instr[2] = (byte)Base64Code.IndexOf(message[i * 4 + 2]);
                instr[3] = (byte)Base64Code.IndexOf(message[i * 4 + 3]);
                byte[] outstr = new byte[3];
                outstr[0] = (byte)((instr[0] << 2) ^ ((instr[1] & 0x30) >> 4));
                if (instr[2] != 64)
                {
                    outstr[1] = (byte)((instr[1] << 4) ^ ((instr[2] & 0x3c) >> 2));
                }
                else
                {
                    outstr[2] = 0;
                }
                if (instr[3] != 64)
                {
                    outstr[2] = (byte)((instr[2] << 6) ^ instr[3]);
                }
                else
                {
                    outstr[2] = 0;
                }
                outMessage.Add(outstr[0]);
                if (outstr[1] != 0)
                    outMessage.Add(outstr[1]);
                if (outstr[2] != 0)
                    outMessage.Add(outstr[2]);
            }
            byte[] outbyte = (byte[])outMessage.ToArray(Type.GetType("System.Byte"));
            return System.Text.Encoding.Default.GetString(outbyte);

        }

        public class Api
        {
            //图像拷贝
            [DllImportAttribute("gdi32.dll")]
            public static extern bool BitBlt(
                IntPtr hdcDest, //目标设备的句柄 
                int nXDest,  // 目标对象的左上角的X坐标
                int nYDest,  // 目标对象的左上角的X坐标
                int nWidth,  // 目标对象的矩形的宽度
                int nHeight, // 目标对象的矩形的长度 
                IntPtr hdcSrc,  // 源设备的句柄
                int nXSrc,   // 源对象的左上角的X坐标 
                int nYSrc,   // 源对象的左上角的X坐标 
                System.Int32 dwRop  // 光栅的操作值 
                );

            public Api()
            {
                //
                // TODO: 在此处添加构造函数逻辑
                //
            }
        }

        static public string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 33 && (int)c <= 126)
                {//字母和符号原样保留
                    tempStr += c.ToString();
                }
                else
                {//累加拼音声母
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }

        static public string GetPYChar(string c)
        {
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));

            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "j";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";

            return "*";
        }

        public enum DMDO
        {
            DEFAULT = 0,
            D90 = 1,
            D180 = 2,
            D270 = 3
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct DEVMODE
        {
            public const int DM_DISPLAYFREQUENCY = 0x400000;
            public const int DM_PELSWIDTH = 0x80000;
            public const int DM_PELSHEIGHT = 0x100000;
            private const int CCHDEVICENAME = 32;
            private const int CCHFORMNAME = 32;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;

            public int dmPositionX;
            public int dmPositionY;
            public DMDO dmDisplayOrientation;
            public int dmDisplayFixedOutput;

            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        //static extern int ChangeDisplaySettings( DEVMODE lpDevMode,  int dwFlags);

        static extern int ChangeDisplaySettings([In] ref DEVMODE lpDevMode, int dwFlags);


        void ChangeRes(int width, int height, int displayFrequency)
        {
            long RetVal = 0;
            DEVMODE dm = new DEVMODE();
            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            dm.dmPelsWidth = width;
            dm.dmPelsHeight = height;
            dm.dmDisplayFrequency = displayFrequency;
            dm.dmFields = DEVMODE.DM_PELSWIDTH | DEVMODE.DM_PELSHEIGHT | DEVMODE.DM_DISPLAYFREQUENCY;
            RetVal = ChangeDisplaySettings(ref dm, 0);
        }

    }
	//************************Hotkey*********************************************
    //        Hotkey hotkey;
    //        hotkey = new Hotkey(this.Handle);
    //        Hotkey1 = hotkey.RegisterHotkey(System.Windows.Forms.Keys.F1, Hotkey.KeyFlags.MOD_EMPTY);//定义快键( F1)   
    //        hotkey.OnHotkey += new HotkeyEventHandler(OnHotkey);
    //

    public delegate void HotkeyEventHandler(int HotKeyID);

    public class Hotkey : System.Windows.Forms.IMessageFilter
    {
        public static Dictionary<int, System.Windows.Forms.Keys> HotKeyDic = new Dictionary<int, System.Windows.Forms.Keys>();

        System.Collections.Hashtable keyIDs = new System.Collections.Hashtable();
        IntPtr hWnd;

        public event HotkeyEventHandler OnHotkey;

        public enum KeyFlags
        {
            MOD_EMPTY = 0x0,
            MOD_ALT = 0x1,
            MOD_CONTROL = 0x2,
            MOD_SHIFT = 0x4,
            MOD_WIN = 0x8
        }
        [DllImport("user32.dll")]
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);

        [DllImport("user32.dll")]
        public static extern UInt32 UnregisterHotKey(IntPtr hWnd, UInt32 id);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalAddAtom(String lpString);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);

        public Hotkey(IntPtr hWnd)
        {
            this.hWnd = hWnd;
            System.Windows.Forms.Application.AddMessageFilter(this);
        }

        public int RegisterHotkey(System.Windows.Forms.Keys Key, KeyFlags keyflags)
        {
            UInt32 hotkeyid = GlobalAddAtom(System.Guid.NewGuid().ToString());
            RegisterHotKey((IntPtr)hWnd, hotkeyid, (UInt32)keyflags, (UInt32)Key);
            keyIDs.Add(hotkeyid, hotkeyid);
            return (int)hotkeyid;
        }

        public void UnregisterHotkeys()
        {
            System.Windows.Forms.Application.RemoveMessageFilter(this);
            foreach (UInt32 key in keyIDs.Values)
            {
                UnregisterHotKey(hWnd, key);
                GlobalDeleteAtom(key);
            }
        }

        public bool PreFilterMessage(ref   System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x312)
            {
                if (OnHotkey != null)
                {
                    foreach (UInt32 key in keyIDs.Values)
                    {
                        if ((UInt32)m.WParam == key)
                        {
                            OnHotkey((int)m.WParam);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
	//************************XXXXXX*********************************************
	//System.Diagnostics.ProcessStartInfo ps=new System.Diagnostics.ProcessStartInfo("my.exe");
	//System.Diagnostics.Process p=new System.Diagnostics.Process();
	//p.StartInfo=ps;
	//p.Start();
    //my.exe是你要调用的程序,放在同一目录下

    //Interaction.Shell(@"c:\WINDOWS\explorer.exe e:\", AppWinStyle.MaximizedFocus, true, -1);

    //		AppDomain Screen = AppDomain.CreateDomain("ResizeScreen");
    //		Screen.ExecuteAssembly(@"c:\Screen.exe");
}
