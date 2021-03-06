﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooleanAlgebraSolver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major == 6)
                SetProcessDPIAware();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<int> mt = new List<int> { 2,3,4,5,7,12,13,15};
            List<int> dc = new List<int> { 4,6,7,9,11,12,14,15};
            MultipleOutputMinimizationSolver q = new MultipleOutputMinimizationSolver(4, mt, dc);
            q.solve();
            q.PRNMINOUTPUT();
            Application.Run(new Main());
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
