using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ScreenGrabber {
    public static class ExtensionMethods {
        public static string ToBase64(this Image image) {
            string result;
            using (MemoryStream stream = new MemoryStream()) {
                image.Save(stream, ImageFormat.Png);
                stream.Position = 0;
                using (BinaryReader reader = new BinaryReader(stream))
                    result = Convert.ToBase64String(reader.ReadBytes((int)stream.Length));
            }
            return result;
        }

        public static void ToggleMarqueeAnimationSpeed(this ToolStripProgressBar progressBar, int value) {
            if (value == 0) {
                progressBar.MarqueeAnimationSpeed = value;
                progressBar.Value = 0;
                progressBar.Style = ProgressBarStyle.Blocks;
            }
            else {
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = value;
            }
        }

        public static Queue<T> ToQueue<T>(this IList<T> list) {
            var queue = new Queue<T>();
            foreach (var t in list)
                queue.Enqueue(t);
            return queue;
        }
    }
}
