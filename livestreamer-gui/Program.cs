//
// livestreamer-gui
// (c) 2014 - 2016 Andrzej Budzanowski <psychob.pl@gmail.com>
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace livestreamer_gui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new gui.MainWindow());
        }
    }
}
