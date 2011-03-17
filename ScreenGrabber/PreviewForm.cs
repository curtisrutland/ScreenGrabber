using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ScreenGrabber {
    public partial class PreviewForm : Form {
        private enum PreviewMode { Fill, Zoom }

        private PreviewMode mode = PreviewMode.Fill;
        private Image image;

        private object locker = new object();

        private bool uploading = false;

        public PreviewForm(Image image) {
            InitializeComponent();
            uploadDetailsPage.Hide();
            this.image = image;
            previewPictureBox.Size = panel1.Size;
            previewPictureBox.SizeMode = GetFillMode();
            previewPictureBox.Image = this.image;
            panel1.AutoScroll = false;
            imageModeButton.Image = Properties.Resources.zoomin;
        }

        public PreviewForm(Image image, ImgurResponse response) : this(image) {
            GotUploadResponse(response);
        }

        private void PreviewForm_Load(object sender, EventArgs e) {
            this.BringToFront();
            progressBar.ToggleMarqueeAnimationSpeed(0);
            //progressBar.Value = 0;
        }

        private PictureBoxSizeMode GetFillMode() {
            if (image.Size.Height < panel1.Size.Height || image.Size.Width < panel1.Size.Width)
                return PictureBoxSizeMode.CenterImage;
            else
                return PictureBoxSizeMode.Zoom;
        }

        private void imageModeButton_Click(object sender, EventArgs e) {
            if (mode == PreviewMode.Zoom) {
                mode = PreviewMode.Fill;
                previewPictureBox.Size = panel1.Size;
                previewPictureBox.SizeMode = GetFillMode(); ;
                panel1.AutoScrollMinSize = Size.Empty;
                panel1.AutoScroll = false;
                imageModeButton.Image = Properties.Resources.zoomin;
            }
            else {
                mode = PreviewMode.Zoom;
                previewPictureBox.Size = image.Size;
                previewPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                panel1.AutoScrollMinSize = image.Size;
                panel1.AutoScroll = true;
                imageModeButton.Image = Properties.Resources.zoomout;
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            SaveImage();
        }

        private void SaveImage() {
            string path;
            if (Utilities.TryGetSavePath(out path)) {
                ImageFormat format = path.ToLower().EndsWith("jpg") ? ImageFormat.Jpeg : ImageFormat.Png;
                try {
                    BackgroundWorker worker = new BackgroundWorker();

                    DoWorkEventHandler dw = null;
                    dw = (snd, ea) => {
                        worker.DoWork -= dw;
                        StartSave();
                        image.Save(path, format);
                    };
                    worker.DoWork += dw;

                    RunWorkerCompletedEventHandler rw = null;
                    rw = (snd, ea) => {
                        worker.RunWorkerCompleted -= rw;
                        EndSave();
                    };
                    worker.RunWorkerCompleted += rw;

                    worker.RunWorkerAsync();
                }
                catch (Exception exc) {
                    MessageBox.Show("Unable to save: " + exc.Message);
                }
            }
        }

        private void uploadButton_Click(object sender, EventArgs e) {
            BackgroundWorker worker = new BackgroundWorker();
            uploading = true;
            DoWorkEventHandler dw = null;
            dw = (snd, ea) => {
                worker.DoWork -= dw;
                StartUpload();
                GotUploadResponse(ImgurUploader.UploadImage(image));
            };
            worker.DoWork += dw;

            RunWorkerCompletedEventHandler rw = null;
            rw = (snd, ea) => {
                worker.RunWorkerCompleted -= rw;
                EndUpload();
            };
            worker.RunWorkerCompleted += rw;

            worker.RunWorkerAsync();
        }

        private void StartUpload() {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => StartUpload()));
            else {
                ToggleButtonsEnabled(false);
                progressBar.ToggleMarqueeAnimationSpeed(50);
                actionLabel.Text = "Uploading image to Imgur. Please wait.";
            }
        }

        private void GotUploadResponse(ImgurResponse imgurResponse) {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => GotUploadResponse(imgurResponse)));
            else {
                imgurResponseControl.ImgurResponse = imgurResponse;
                uploadDetailsPage.Show();
                tabControl1.SelectedIndex = 1;
            }
        }

        private void EndUpload() {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => EndUpload()));
            else {
                ToggleButtonsEnabled(true);
                progressBar.ToggleMarqueeAnimationSpeed(0);
                //progressBar.Value = 0;
                actionLabel.Text = "Image successfully uploaded.";
                uploading = false;
            }
        }

        private void StartSave() {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => StartSave()));
            else {
                lock (locker) {
                    ToggleButtonsEnabled(false);
                    progressBar.ToggleMarqueeAnimationSpeed(50);
                    actionLabel.Text = "Saving Image...";
                }
            }
        }

        private void EndSave() {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => EndSave()));
            else {
                lock (locker) {
                    ToggleButtonsEnabled(true);
                    progressBar.ToggleMarqueeAnimationSpeed(0);
                    //progressBar.Value = 0;
                    actionLabel.Text = "Image Saved.";
                }
            }
        }

        private void ToggleButtonsEnabled(bool p) {
            imageModeButton.Enabled = p;
            uploadButton.Enabled = p;
            saveButton.Enabled = p;
        }

        private void PreviewForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (uploading) {
                var res = MessageBox.Show("Upload currently in progress. Are you sure you want to exit?", "Upload in progress", MessageBoxButtons.YesNo);
                if (res != System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = true;
            }
        }
    }

}
