using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenGrabber {
    public partial class StandaloneUploaderForm : Form {
        private string[] fileNames;
        const int MAX_ACTIVE_UPLOADS = 2;

        private List<StandaloneUploaderControl> uploaderControls;
        private Queue<StandaloneUploaderControl> queue;

        private object locker = new object();

        private bool uploading = false;

        public StandaloneUploaderForm(string[] fileNames) {
            InitializeComponent();
            uploaderControls = new List<StandaloneUploaderControl>();
            this.fileNames = fileNames;
        }

        private void StandaloneUploaderForm_Load(object sender, EventArgs e) {
            for (int i = 0; i < fileNames.Length; i++) {
                TabPage page = new TabPage("Image " + (i + 1));
                StandaloneUploaderControl uploaderControl = new StandaloneUploaderControl() {
                    Top = 2,
                    Left = 2,
                    Dock = DockStyle.Fill,
                    FileName = fileNames[i]
                };
                uploaderControls.Add(uploaderControl);
                page.Controls.Add(uploaderControl);
                tabControl.TabPages.Add(page);
            }
        }

        private void BeginUpload_Click(object sender, EventArgs e) {
            beginUploadButton.Enabled = false;
            uploading = true;
            queue = uploaderControls.ToQueue();
            for (int i = 0; i < MAX_ACTIVE_UPLOADS; i++) {
                if (!queue.Any())
                    break;
                lock (locker) {
                    BeginUpload(queue.Dequeue());
                }
            }
        }

        private void BeginUpload(StandaloneUploaderControl uc) {
            uc.UploadCompleted += new EventHandler<EventArgs>(uc_UploadCompleted);
            uc.BeginUpload();
        }

        void uc_UploadCompleted(object sender, EventArgs e) {
            (sender as StandaloneUploaderControl).UploadCompleted -= new EventHandler<EventArgs>(uc_UploadCompleted);
            if (queue.Any()) {
                lock (locker) {
                    BeginUpload(queue.Dequeue());
                }
            }
            else {
                uploading = false;
            }
        }

        private void StandaloneUploaderForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (uploading) {
                var res = MessageBox.Show("Uploads currently in progress. Are you sure you want to exit?", "Uploads Pending", MessageBoxButtons.YesNo);
                if (res != System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = true;
            }
        }
    }
}
