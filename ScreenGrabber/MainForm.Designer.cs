namespace ScreenGrabber
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.niContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clipboardItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadFromClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFromClipboardItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentUploadsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.niContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.niContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ScreenGrabber!";
            this.notifyIcon.Visible = true;
            // 
            // niContextMenu
            // 
            this.niContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clipboardItem,
            this.uploadItem,
            this.recentUploadsItem,
            this.autoItem,
            this.exitItem});
            this.niContextMenu.Name = "niContextMenu";
            this.niContextMenu.Size = new System.Drawing.Size(161, 114);
            this.niContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.niContextMenu_Opening);
            // 
            // clipboardItem
            // 
            this.clipboardItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadFromClipboard,
            this.saveFromClipboardItem});
            this.clipboardItem.Name = "clipboardItem";
            this.clipboardItem.Size = new System.Drawing.Size(160, 22);
            this.clipboardItem.Text = "Clipboard";
            // 
            // uploadFromClipboard
            // 
            this.uploadFromClipboard.Image = global::ScreenGrabber.Properties.Resources.uploadsmall;
            this.uploadFromClipboard.Name = "uploadFromClipboard";
            this.uploadFromClipboard.Size = new System.Drawing.Size(193, 22);
            this.uploadFromClipboard.Text = "Upload From Clipboard";
            this.uploadFromClipboard.Click += new System.EventHandler(this.UploadFromClipboard_Click);
            // 
            // saveFromClipboardItem
            // 
            this.saveFromClipboardItem.Image = global::ScreenGrabber.Properties.Resources.downloadsmall;
            this.saveFromClipboardItem.Name = "saveFromClipboardItem";
            this.saveFromClipboardItem.Size = new System.Drawing.Size(193, 22);
            this.saveFromClipboardItem.Text = "Save From Clipboard";
            this.saveFromClipboardItem.Click += new System.EventHandler(this.SaveFromClipboardItem_Click);
            // 
            // uploadItem
            // 
            this.uploadItem.Image = global::ScreenGrabber.Properties.Resources.uploadsmall;
            this.uploadItem.Name = "uploadItem";
            this.uploadItem.Size = new System.Drawing.Size(160, 22);
            this.uploadItem.Text = "Upload Images";
            this.uploadItem.Click += new System.EventHandler(this.Upload_Click);
            // 
            // autoItem
            // 
            this.autoItem.Name = "autoItem";
            this.autoItem.Size = new System.Drawing.Size(160, 22);
            this.autoItem.Text = "Auto Upload";
            this.autoItem.Click += new System.EventHandler(this.AutoUpload_Click);
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(160, 22);
            this.exitItem.Text = "Exit";
            this.exitItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // recentUploadsItem
            // 
            this.recentUploadsItem.Name = "recentUploadsItem";
            this.recentUploadsItem.Size = new System.Drawing.Size(160, 22);
            this.recentUploadsItem.Text = "Recent Uploads";
            this.recentUploadsItem.Click += new System.EventHandler(this.recentUploadsItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(104, 0);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "ScreenGrabber";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.niContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip niContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.ToolStripMenuItem uploadItem;
        private System.Windows.Forms.ToolStripMenuItem autoItem;
        private System.Windows.Forms.ToolStripMenuItem clipboardItem;
        private System.Windows.Forms.ToolStripMenuItem uploadFromClipboard;
        private System.Windows.Forms.ToolStripMenuItem saveFromClipboardItem;
        private System.Windows.Forms.ToolStripMenuItem recentUploadsItem;
    }
}

