using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenGrabber {
    public partial class StandaloneUploaderControl : UserControl {

        public event EventHandler<EventArgs> UploadCompleted;
        protected virtual void OnUploadCompleted() {
            if (UploadCompleted != null)
                UploadCompleted(this, new EventArgs());
        }

        private ImgurResponse imgurResponse;
        public ImgurResponse ImgurResponse {
            get { return imgurResponse; }
            set {
                imgurResponse = value;
                SetResponse();
            }
        }

        private string fileName;
        public string FileName {
            get { return fileName; }
            set {
                fileName = value;
                if (value != null)
                    SetValues();
            }
        }

        public StandaloneUploaderControl() {
            InitializeComponent();
        }

        private void SetResponse() {
            imgurResponseControl.ImgurResponse = imgurResponse;
        }

        private void StandaloneUploaderControl_Load(object sender, EventArgs e) {
            progressBar.ToggleMarqueeAnimationSpeed(0);
            progressBar.Value = 0;
        }

        private void SetValues() {
            fileNameLabel.Text = FileName;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.ImageLocation = FileName;
        }

        public void BeginUpload() {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => BeginUpload()));
            else {
                progressBar.ToggleMarqueeAnimationSpeed(50);
                actionLabel.Text = "Uploading image to Imgur. Please wait.";
                BeginUploadImage();
            }
        }

        private void EndUpload() {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => EndUpload()));
            else {
                progressBar.ToggleMarqueeAnimationSpeed(0);
                actionLabel.Text = "Image uploaded.";
                OnUploadCompleted();
            }
        }

        private void BeginUploadImage() {
            BackgroundWorker worker = new BackgroundWorker();

            DoWorkEventHandler dw = null;
            dw = (s, ea) => {
                worker.DoWork -= dw;
                ImgurResponse = ImgurUploader.UploadImage(FileName);
            };
            worker.DoWork += dw;

            RunWorkerCompletedEventHandler rw = null;
            rw = (s, ea) => {
                worker.RunWorkerCompleted -= rw;
                EndUpload();
            };
            worker.RunWorkerCompleted += rw;

            worker.RunWorkerAsync();
        }
    }
}
