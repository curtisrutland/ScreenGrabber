using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using ScreenGrabber.Properties;

namespace ScreenGrabber {
    public partial class MainForm : Form {
        private GlobalHotkey printscreenHotkey, altPrintscreenHotkey, ctrlPrintscreenHotkey;

        public MainForm() {
            InitializeComponent();
            autoItem.Checked = Settings.Default.AutoUpload;
            printscreenHotkey = new GlobalHotkey(Constants.NoMod, Keys.PrintScreen, this);
            altPrintscreenHotkey = new GlobalHotkey(Constants.Alt, Keys.PrintScreen, this);
            ctrlPrintscreenHotkey = new GlobalHotkey(Constants.Ctrl, Keys.PrintScreen, this);
        }

        private void Form1_Load(object sender, EventArgs e) {
            printscreenHotkey.Register();
            altPrintscreenHotkey.Register();
            ctrlPrintscreenHotkey.Register();
            BeginInvoke(new MethodInvoker(() => Hide()));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            printscreenHotkey.Unregiser();
            altPrintscreenHotkey.Unregiser();
            ctrlPrintscreenHotkey.Unregiser();
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == Constants.HotkeyWMId) {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int modifier = (int)m.LParam & 0xFFFF;
                if (modifier == Constants.NoMod)
                    CaptureAll();
                else if (modifier == Constants.Alt)
                    CaptureActiveWindow();
                else if (modifier == Constants.Ctrl)
                    //CaptureRange();
                    CaptureRange();
            }
            base.WndProc(ref m);
        }

        private void Preview(Image image) {
            PreviewForm form;
            if (Settings.Default.AutoUpload) {
                var res = ImgurUploader.UploadImage(image);
                form = new PreviewForm(image, res);
            }
            else {
                 form = new PreviewForm(image);
            }
            form.Show();
        }

        private void CaptureRange() {
            var img = ScreenCapture.CaptureFullScreen();
            CaptureAreaForm caf = new CaptureAreaForm(img);
            if (caf.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Preview(caf.ImageResult);
            }
        }

        private void CaptureActiveWindow() {
            var ss = ScreenCapture.Capture(CaptureType.Window, handle: User32.GetForegroundWindow());
            Preview(ss);
        }

        private void CaptureAll() {
            var ss = ScreenCapture.Capture(CaptureType.Fullscreen);
            Preview(ss);
        }

        private bool TryGetImageFromClipboard(out Image i) {
            if (!Clipboard.ContainsImage()) {
                i = null;
                return false;
            }
            else {
                i = Clipboard.GetImage();
                return true;
            }
        }

        private void Exit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Upload_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.DefaultExt = "png";
            ofd.Filter = "Image Files|*.BMP;*.JPG;*.JPEG;*.PNG;*.GIF";
            ofd.InitialDirectory = Properties.Settings.Default.SavePath;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                StandaloneUploaderForm suf = new StandaloneUploaderForm(ofd.FileNames);
                suf.ShowDialog();
                GC.Collect();
            }
        }

        private void AutoUpload_Click(object sender, EventArgs e) {
            var check = !Settings.Default.AutoUpload;
            Settings.Default.AutoUpload = check;
            autoItem.Checked = check;
            Settings.Default.Save();
        }

        private void UploadFromClipboard_Click(object sender, EventArgs e) {
            Image img;
            if (TryGetImageFromClipboard(out img))
                Preview(img);
        }

        private void SaveFromClipboardItem_Click(object sender, EventArgs e) {
            Image img;
            string path;
            if (TryGetImageFromClipboard(out img) && Utilities.TryGetSavePath(out path)) {
                ImageFormat format = path.ToLower().EndsWith("jpg") ? ImageFormat.Jpeg : ImageFormat.Png;
                img.Save(path, format);
            }
        }

        private void niContextMenu_Opening(object sender, CancelEventArgs e) {
            clipboardItem.Enabled = Clipboard.ContainsImage();
        }

        private void recentUploadsItem_Click(object sender, EventArgs e) {
            ResponseLog.ShowLogs();
        }
    }
}
