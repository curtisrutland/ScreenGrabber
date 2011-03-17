using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenGrabber {
    public static class Utilities {

        internal static bool TryGetSavePath(out string fileName) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = "png";
            sfd.Filter = ".png|*.png|.jpg|*.jpg";
            sfd.InitialDirectory = Properties.Settings.Default.SavePath;
            sfd.RestoreDirectory = true;
            sfd.FileName = GetDefaultFileName();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                fileName = sfd.FileName;
                return true;
            }
            else {
                fileName = null;
                return false;
            }
        }

        internal static string GetDefaultFileName() {
            return string.Format("{0}\\{1}.png",
                Properties.Settings.Default.SavePath,
                DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}
