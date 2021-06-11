using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace DDoSTool
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern Boolean AllocConsole();
    }


    class Program
    {
        static void Main(string[] args)
        {
            NativeMethods.AllocConsole();
            Console.Title = "Auto DDOS TOOL";
            GetSite.begin();
        }
    }
}
