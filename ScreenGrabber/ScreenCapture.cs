using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenGrabber {
    public enum CaptureType { Fullscreen, Range, Window }

    public static class ScreenCapture {
        public static Image Capture(CaptureType type, Point origin = default(Point), Size size = default(Size), IntPtr handle = default(IntPtr)) {
            Image result;
            switch (type) {
                case CaptureType.Range:
                    result = CaptureRange(origin, size);
                    break;
                case CaptureType.Window:
                    result = CaptureWindow(handle);
                    break;
                default:
                    result = CaptureFullScreen();
                    break;
            }
            Clipboard.SetImage(result);
            return result;
        }

        public static Image CaptureFullScreen() {
            int width = Screen.AllScreens.Sum(x => x.Bounds.Width);
            int height = Screen.AllScreens.Select(x => x.Bounds.Height).Max();
            var size = new System.Drawing.Size(width, height);
            return CaptureRange(Point.Empty, size);
        }

        public static Image CaptureRange(Point origin, Size size) {
            Bitmap b = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(b))
                g.CopyFromScreen(origin, Point.Empty, size);
            return b;
        }

        public static Image CaptureWindow(IntPtr handle) {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            // bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            // restore selection
            GDI32.SelectObject(hdcDest, hOld);
            // clean up 
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            // get a .NET image object for it
            Image img = Image.FromHbitmap(hBitmap);
            // free up the Bitmap object
            GDI32.DeleteObject(hBitmap);
            return img;
        }
    }
}
