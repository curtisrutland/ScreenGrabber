using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ScreenGrabber {
    public partial class ImgurResponseControl : UserControl {
        private ImgurResponse imgurResponse;
        public ImgurResponse ImgurResponse {
            get { return imgurResponse; }
            set {
                imgurResponse = value;
                if (value != null)
                    SetValues(value);
            }
        }

        private List<Button> buttons;

        public ImgurResponseControl() {
            InitializeComponent();
            buttons = this.Controls.OfType<Button>().ToList();
            SetButtonsEnabled(false);
            this.Load += new EventHandler(ImgurResponseControl_Load); //(s, e) => directLinkTextBox.Focus();
        }

        private void SetButtonsEnabled(bool isEnabled) {
            buttons.ForEach(x => x.Enabled = isEnabled);
        }

        void ImgurResponseControl_Load(object sender, EventArgs e) {
            this.Load -= new EventHandler(ImgurResponseControl_Load);
            directLinkTextBox.SelectAll();

        }

        private void SetValues(ImgurResponse response) {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => SetValues(response)));
            else {
                deleteLinkTextBox.Text = response.DeleteLink ?? string.Empty;
                directLinkTextBox.Text = response.DirectLink ?? string.Empty;
                imgurPageTextBox.Text = response.ImgurPage ?? string.Empty;
                smallThumbTextBox.Text = response.SmallThumb ?? string.Empty;
                largeThumbTextBox.Text = response.LargeThumb ?? string.Empty;
                exceptionTextBox.Text = response.Exception == null ? string.Empty : response.Exception.Message;
                exceptionButton.Enabled = response.Exception != null;
                directLinkTextBox.SelectAll();
                copyDirectLinkButton.Focus();
                SetButtonsEnabled(true);
            }
        }

        private void Copy_Click(object sender, EventArgs e) {
            switch ((sender as Button).Tag as string) {
                case "DeleteLink":
                    SetClipboardText(deleteLinkTextBox.Text);
                    break;
                case "DirectLink":
                    SetClipboardText(directLinkTextBox.Text);
                    break;
                case "ImgurPage":
                    SetClipboardText(imgurPageTextBox.Text);
                    break;
                case "SmallThumb":
                    SetClipboardText(smallThumbTextBox.Text);
                    break;
                case "LargeThumb":
                    SetClipboardText(largeThumbTextBox.Text);
                    break;
                case "Exception":
                    SetClipboardText(exceptionTextBox.Text);
                    break;
                default:
                    MessageBox.Show(String.Format("Case not found. Tag was {0}", (sender as Button).Tag as string));
                    break;
            }
        }

        private void Go_Click(object sender, EventArgs e) {
            switch ((sender as Button).Tag as string) {
                case "DeleteLink":
                    StartProcess(deleteLinkTextBox.Text);
                    break;
                case "DirectLink":
                    StartProcess(directLinkTextBox.Text);
                    break;
                case "ImgurPage":
                    StartProcess(imgurPageTextBox.Text);
                    break;
                case "SmallThumb":
                    StartProcess(smallThumbTextBox.Text);
                    break;
                case "LargeThumb":
                    StartProcess(largeThumbTextBox.Text);
                    break;
                default:
                    MessageBox.Show(String.Format("Case not found. Tag was {0}", (sender as Button).Tag as string));
                    break;
            }
        }

        private void SetClipboardText(string text) {
            if (!string.IsNullOrWhiteSpace(text))
                Clipboard.SetText(text);
        }

        private void StartProcess(string text) {
            if (!string.IsNullOrWhiteSpace(text))
                Process.Start(text);
        }

    }
}
