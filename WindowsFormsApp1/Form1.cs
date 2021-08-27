using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

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

        [DllImport("user32.dll")]
        static extern IntPtr SetActiveWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, IntPtr msg, int wParam, int lParam);


        public const int WM_SETTEXT = 0x1501;


        //using spy++ to get the handler of the repective window and field
        //use of ApiViewer
        public Form1()
        {
            InitializeComponent();
            int ChildHand = 0;
            int ParentHand = FindWindow("CabinetWClass", "File Explorer");
            ChildHand = FindWindowEx(ParentHand, 0, "WorkerW", null);
            ChildHand = FindWindowEx(ChildHand, 0, "ReBarWindow32", null);
            ChildHand = FindWindowEx(ChildHand, 0, "UniversalSearchBand", null);
            ChildHand = FindWindowEx(ChildHand, 0, "ModernSearchBox", "SearchEditBox");
            


            if (ParentHand != 0 & ChildHand != 0)
            {
                SetForegroundWindow(ChildHand);
                //Thread.Sleep(2000);
                SendKeys.SendWait("Search me");
                // this is just printing last letter of the string i.e "e" tried to find out alternative but couldnt found any.
                //Even it some time works and print the full text
            }
            else
            {
                MessageBox.Show("Please open file explorer");
            }
        }

    }
}
