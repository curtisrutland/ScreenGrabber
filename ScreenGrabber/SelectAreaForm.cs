using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenGrabber {
    public partial class SelectAreaForm : Form {
        public Point Origin { get; set; }
        public Size SelectedSize { get; set; }

        public SelectAreaForm() {
            InitializeComponent();
        }

        private void RectangleForm_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                Rectangle rect = this.ClientRectangle;
                Origin = this.PointToScreen(rect.Location);
                SelectedSize = rect.Size;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape) {
                Origin = Point.Empty;
                SelectedSize = Size.Empty;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void SelectAreaForm_Load(object sender, EventArgs e) {
            this.BringToFront();
        }

    }
}
