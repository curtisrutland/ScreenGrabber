using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenGrabber {
    public class AreaSelectedEventArgs : EventArgs {
        public Point Origin { get; set; }
        public Size Size { get; set; }
    }

    public partial class CrosshairsControl : UserControl {

        public event EventHandler<AreaSelectedEventArgs> AreaSelected;
        protected virtual void OnAreaSelected(Point origin, Size size) {
            if (AreaSelected != null)
                AreaSelected(this, new AreaSelectedEventArgs() { Origin = origin, Size = size });
        }

        private bool isDragging = false;
        private Point clickPos;

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;
                return cp;
            }
        }

        public CrosshairsControl() {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) {
            InvalidateEx();
            DrawCrosshair(e.Graphics);
            if (isDragging)
                DrawRect(e.Graphics);
            base.OnPaint(e);
        }

        private void CaptureAreaForm_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                clickPos = PointToClient(Cursor.Position);
                isDragging = true;
            }
        }

        private void CaptureAreaForm_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left)
                isDragging = false;
            var upPos = PointToClient(Cursor.Position);
            Point start;
            Size size;
            GetStartAndSizeFromPoint(upPos, out start, out size);
            OnAreaSelected(start, size);
            Invalidate();
        }

        private void CaptureAreaForm_MouseMove(object sender, MouseEventArgs e) {
            Invalidate();
        }

        private void DrawCrosshair(Graphics g) {
            Point pos = this.PointToClient(Cursor.Position);
            Point vStart = new Point(pos.X, 0);
            Point vEnd = new Point(pos.X, this.Size.Height);
            Point hStart = new Point(0, pos.Y);
            Point hEnd = new Point(this.Size.Width, pos.Y);
            Rectangle forEllipse = new Rectangle(pos.X - 20, pos.Y - 20, 40, 40);
            using (Pen p = new Pen(Color.Black)) {
                g.DrawLine(p, vStart, vEnd);
                g.DrawLine(p, hStart, hEnd);
                g.DrawEllipse(p, forEllipse);
            }
        }

        private void DrawRect(Graphics g) {
            Point cursorPos = this.PointToClient(Cursor.Position);
            Point start;
            Size size;
            GetStartAndSizeFromPoint(cursorPos, out start, out size);
            Rectangle rect = new Rectangle(start, size);
            using (Pen p = new Pen(Color.Black)) {
                g.DrawRectangle(p, rect);
            }
        }

        private void GetStartAndSizeFromPoint(Point pos, out Point start, out Size size){
            size = new Size() {
                Width = Math.Abs(clickPos.X - pos.X),
                Height = Math.Abs(clickPos.Y - pos.Y)
            };
            start = new Point() { X = Math.Min(pos.X, clickPos.X), Y = Math.Min(pos.Y, clickPos.Y) };
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            //stubbed and left empty on purpose, so as to not repaint the background.
        }

        protected void InvalidateEx() {
            if (Parent == null)
                return;

            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }
    }
}
