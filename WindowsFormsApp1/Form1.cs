using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindowExA")]
        public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);
        [DllImport("user32.dll", EntryPoint = "FindWindowA")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(int hWnd);

    
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, string lParam);
        [DllImport("user32.dll", EntryPoint = "SetWindowText", CharSet = CharSet.Ansi)]
        public static extern bool SetWindowText(IntPtr hWnd, String strNewWindowName);
        private const int EM_SETCUEBANNER = 0x1501;
      
      

        public Form1()
        {
            InitializeComponent();
            int CHand = 0;
            int PHand = FindWindow("CabinetWClass", "File Explorer");
            CHand = FindWindowEx(PHand, 0, "WorkerW", null);
            CHand = FindWindowEx(CHand, 0, "ReBarWindow32", null);
            CHand = FindWindowEx(CHand, 0, "UniversalSearchBand", null);
            CHand = FindWindowEx(CHand, 0, "ModernSearchBox", "SearchEditBox");


            if (PHand != 0 & CHand != 0)
            {
                 SetForegroundWindow(CHand);

                SendMessage(CHand, EM_SETCUEBANNER, 0, "Search Me");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
