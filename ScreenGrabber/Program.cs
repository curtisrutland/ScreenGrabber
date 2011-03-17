using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScreenGrabber {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.SavePath == "unset")
                Properties.Settings.Default.SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Application.Run(new MainForm() { Visible = false });
        }
    }
}
