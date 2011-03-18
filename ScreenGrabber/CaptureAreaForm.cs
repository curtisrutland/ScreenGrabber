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

        private bool isDragging = false;
        private Point clickPos;

        private Image img;

        public CaptureAreaForm(Image img) {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.img = img;
            BackgroundImage = this.img;
            this.Height = img.Height;
            this.Width = img.Width;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Point.Empty;
            this.Cursor = Cursors.Cross;
        }

        protected override void OnShown(EventArgs e) {
            this.Location = Point.Empty;
            base.OnShown(e);
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (isDragging)
                DrawRect(e.Graphics);
            DrawMagBox(e.Graphics);
            base.OnPaint(e);
        }

        private Point cursorPos {
            get { return this.PointToClient(Cursor.Position); }
        }

        private void CaptureAreaForm_KeyUp(object sender, KeyEventArgs e) {
            CheckKey(e);
        }

        private void CheckKey(KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                if (isDragging)
                    CancelDragging();
                else
                    CancelCapture();
            }
        }

        private void CancelDragging() {
            isDragging = false;
            Invalidate();
        }

        private void CancelCapture() {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CaptureAreaForm_FormClosing(object sender, FormClosingEventArgs e) {
            this.Cursor = Cursors.Default;
            Cursor.Show();
        }

        private void DrawRect(Graphics g) {
            Point start;
            Size size;
            GetStartAndSizeFromPoint(cursorPos, out start, out size);
            Rectangle rect = new Rectangle(start, size);
            using (Pen p = new Pen(Color.Black)) {
                g.DrawRectangle(p, rect);
            }
        }

        private void DrawMagBox(Graphics g) {
            var magBoxSize = new Size(100, 100);
            var toMagSize = new Size(40, 40);
            var pos = cursorPos;
            var rectStart = new Point(pos.X - toMagSize.Width / 2, pos.Y - toMagSize.Height / 2);
            var rect = new Rectangle(rectStart, toMagSize);
            Bitmap pointBmp = new Bitmap(toMagSize.Width, toMagSize.Height);
            using (var pg = Graphics.FromImage(pointBmp)) {
                pg.DrawImage(img, 0, 0, rect, GraphicsUnit.Pixel);
            }
            Bitmap magBmp = new Bitmap(magBoxSize.Width, magBoxSize.Height);
            using (var mg = Graphics.FromImage(magBmp)) {
                mg.DrawImage(pointBmp, 0, 0, magBoxSize.Width, magBoxSize.Height);
            }
            var pD = new Point(pos.X + 15, pos.Y + 15);
            g.DrawImage(magBmp, pD);
            using (var p = new Pen(Color.Black)) {
                g.DrawRectangle(p, new Rectangle(pD, magBoxSize));
                Point pv1 = new Point(pD.X + magBoxSize.Width / 2, pD.Y), pv2 = new Point(pD.X + magBoxSize.Width / 2, pD.Y + magBoxSize.Height);
                Point ph1 = new Point(pD.X, pD.Y + magBoxSize.Height / 2), ph2 = new Point(pD.X + magBoxSize.Width, pD.Y + magBoxSize.Height / 2);
                g.DrawLine(p, pv1, pv2);
                g.DrawLine(p, ph1, ph2);
            }
        }

        private void GetStartAndSizeFromPoint(Point pos, out Point start, out Size size) {
            size = new Size() {
                Width = Math.Abs(clickPos.X - pos.X),
                Height = Math.Abs(clickPos.Y - pos.Y)
            };
            start = new Point() { X = Math.Min(pos.X, clickPos.X), Y = Math.Min(pos.Y, clickPos.Y) };
        }

        private void CaptureAreaForm_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                clickPos = PointToClient(Cursor.Position);
                isDragging = true;
            }
        }

        private void CaptureAreaForm_MouseMove(object sender, MouseEventArgs e) {
            Invalidate();
        }

        private void CaptureAreaForm_MouseUp(object sender, MouseEventArgs e) {
            if (isDragging) {
                if (e.Button == MouseButtons.Left)
                    isDragging = false;
                Point start;
                Size size;
                GetStartAndSizeFromPoint(cursorPos, out start, out size);
                AreaSelected(start, size);
            }
        }

        private void AreaSelected(Point start, Size size) {
            SelectAreaOrigin = start;
            SelectAreaSize = size;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
