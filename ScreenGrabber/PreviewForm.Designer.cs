namespace ScreenGrabber
{
    partial class PreviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.imageModeButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.uploadButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.actionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.uploadDetailsPage = new System.Windows.Forms.TabPage();
            this.imgurResponseControl = new ScreenGrabber.ImgurResponseControl();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.uploadDetailsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageModeButton,
            this.saveButton,
            this.uploadButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(634, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // imageModeButton
            // 
            this.imageModeButton.Image = global::ScreenGrabber.Properties.Resources.zoomin;
            this.imageModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imageModeButton.Name = "imageModeButton";
            this.imageModeButton.Size = new System.Drawing.Size(86, 22);
            this.imageModeButton.Text = "Image Mode";
            this.imageModeButton.ToolTipText = "Toggles image mode between Proportional and FullSize";
            this.imageModeButton.Click += new System.EventHandler(this.imageModeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Image = global::ScreenGrabber.Properties.Resources.downloadsmall;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 22);
            this.saveButton.Text = "Save to Disk";
            this.saveButton.ToolTipText = "Save this image to disk.";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Image = global::ScreenGrabber.Properties.Resources.uploadsmall;
            this.uploadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(104, 22);
            this.uploadButton.Text = "Upload to Imgur";
            this.uploadButton.ToolTipText = "Upload to Imgur";
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.actionLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(634, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // actionLabel
            // 
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(38, 17);
            this.actionLabel.Text = "Ready";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 365);
            this.panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.uploadDetailsPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(634, 365);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.previewPictureBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(626, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Preview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.previewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPictureBox.Location = new System.Drawing.Point(3, 3);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(620, 333);
            this.previewPictureBox.TabIndex = 1;
            this.previewPictureBox.TabStop = false;
            // 
            // uploadDetailsPage
            // 
            this.uploadDetailsPage.Controls.Add(this.imgurResponseControl);
            this.uploadDetailsPage.Location = new System.Drawing.Point(4, 22);
            this.uploadDetailsPage.Name = "uploadDetailsPage";
            this.uploadDetailsPage.Padding = new System.Windows.Forms.Padding(3);
            this.uploadDetailsPage.Size = new System.Drawing.Size(626, 339);
            this.uploadDetailsPage.TabIndex = 1;
            this.uploadDetailsPage.Text = "Upload Details";
            this.uploadDetailsPage.UseVisualStyleBackColor = true;
            // 
            // imgurResponseControl
            // 
            this.imgurResponseControl.ImgurResponse = null;
            this.imgurResponseControl.Location = new System.Drawing.Point(8, 6);
            this.imgurResponseControl.Name = "imgurResponseControl";
            this.imgurResponseControl.Size = new System.Drawing.Size(378, 175);
            this.imgurResponseControl.TabIndex = 0;
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreviewForm";
            this.Text = "Preview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreviewForm_FormClosing);
            this.Load += new System.EventHandler(this.PreviewForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.uploadDetailsPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripButton imageModeButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton uploadButton;
        private System.Windows.Forms.ToolStripStatusLabel actionLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.TabPage uploadDetailsPage;
        private ImgurResponseControl imgurResponseControl;
    }
}