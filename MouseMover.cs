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
    class MouseMover
    {
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        public static void ChromeInstall()
        {
            Thread.Sleep(500);
            int zidex = 700;
            int yidex = 900;
            SetPosition(zidex, yidex);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(500);
            int firstPos = 880;
            int secondPos = 300;
            SetPosition(firstPos, secondPos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            Thread.Sleep(1500);
            int ThirdPos = 550;
            int FourthPos = 290;
            SetPosition(ThirdPos, FourthPos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void RecaptureComplete()
        {
            Thread.Sleep(500);
            int firstPos = 410;
            int secondPos = 700;
            SetPosition(firstPos, secondPos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void SetPosition(int a, int b)
        {
            SetCursorPos(a, b);
        }

        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        private const int MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
    }
}
