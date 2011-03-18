using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenGrabber.Properties;
using System.Security.Principal;
using System.IO;
using System.Windows.Forms;

namespace ScreenGrabber {
    public static class ResponseLog {
        private static List<ImgurResponse> sessionResponses;
        private static ResponseLogForm rlf;

        static ResponseLog() { sessionResponses = new List<ImgurResponse>(); }

        public static List<ImgurResponse> GetAllResponses() {
            return sessionResponses;
        }

        public static void AddResponse(ImgurResponse response) {
            sessionResponses.Add(response);
            WriteToLog(response);
            if (sessionResponses.Count > Settings.Default.ResponsesToKeep)
                sessionResponses.RemoveAt(0);
        }

        public static void WriteToLog(ImgurResponse response) {
            string filename = Environment.UserName.RemoveAll(Settings.Default.InvalidPathCharacters) + Settings.Default.LogFileNameSuffix;
            string path = Path.Combine(Application.UserAppDataPath, filename);
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write)) {
                using (StreamWriter sw = new StreamWriter(fs)) {
                    sw.WriteLine("Upload Log: {0}", response.ResponseTime.ToString(Settings.Default.LongDateFormat));
                    if (response.Exception == null) {
                        sw.WriteLine("Direct Link\t{0}", response.DirectLink);
                        sw.WriteLine("Imgur  Page\t{0}", response.ImgurPage);
                        sw.WriteLine("Small Thumb\t{0}", response.SmallThumb);
                        sw.WriteLine("Large Thumb\t{0}", response.LargeThumb);
                        sw.WriteLine("Delete Link\t{0}", response.DeleteLink);
                    }
                    else{
                        sw.WriteLine("Exception{0}{1}", Environment.NewLine, response.Exception.Message);
                        sw.WriteLine("Stack Trace{0}{1}", Environment.NewLine, response.Exception.StackTrace);
                    }
                    sw.WriteLine();
                }
            }
        }

        public static void ShowLogs() {
            if (rlf == null || rlf.IsDisposed) {
                rlf = new ResponseLogForm();
                rlf.Show();
            }
            else {
                rlf.Focus();
            }
        }
    }
}
