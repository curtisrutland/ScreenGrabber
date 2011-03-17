using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenGrabber {
    public partial class CaptureAreaForm : Form {

        public Point SelectAreaOrigin { get; set; }
        public Size SelectAreaSize { get; set; }

        public CaptureAreaForm(Image img) {
            InitializeComponent();
            this.DoubleBuffered = true;
            Cursor.Hide();
            BackgroundImage = img;
            this.Height = img.Height;
            this.Width = img.Width;
            this.Location = Point.Empty;
            var chc = new CrosshairsControl() { Width = img.Width, Height = img.Height, Location = Point.Empty };
            chc.AreaSelected += new EventHandler<AreaSelectedEventArgs>(chc_AreaSelected);
            this.Controls.Add(chc);
        }

        void chc_AreaSelected(object sender, AreaSelectedEventArgs e) {
            (sender as CrosshairsControl).AreaSelected -= new EventHandler<AreaSelectedEventArgs>(chc_AreaSelected);
            SelectAreaOrigin = e.Origin;
            SelectAreaSize = e.Size;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CaptureAreaForm_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void CaptureAreaForm_FormClosing(object sender, FormClosingEventArgs e) {
            Cursor.Show();
        }        
    }
}
