﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Starfield.Utils
{
    static class ConsoleHelper
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        readonly static IntPtr handle = GetConsoleWindow();
        [DllImport("kernel32.dll")] static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")] static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void Hide()
        {
            ShowWindow(handle, SW_HIDE); //hide the console
        }
        public static void Show()
        {
            ShowWindow(handle, SW_SHOW); //show the console
        }
    }
}
