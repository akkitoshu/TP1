﻿using System;
using System.Windows.Forms;

namespace WindowsFormsBoats
{
    public delegate void boatDelegate(IBoat boat);
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPort());
        }
    }
}
