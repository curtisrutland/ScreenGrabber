namespace ScreenGrabber
{
    partial class ImgurResponseControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.exceptionButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.exceptionTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.deleteLinkTextBox = new System.Windows.Forms.TextBox();
            this.exceptionLabel = new System.Windows.Forms.Label();
            this.copyDirectLinkButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.largeThumbTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.smallThumbTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imgurPageTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.directLinkTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(334, 114);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(35, 23);
            this.button10.TabIndex = 23;
            this.button10.Tag = "DeleteLink";
            this.button10.Text = "Go";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Go_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(334, 86);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(35, 23);
            this.button9.TabIndex = 22;
            this.button9.Tag = "LargeThumb";
            this.button9.Text = "Go";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Go_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(334, 60);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(35, 23);
            this.button8.TabIndex = 24;
            this.button8.Tag = "SmallThumb";
            this.button8.Text = "Go";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Go_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(334, 34);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(35, 23);
            this.button7.TabIndex = 26;
            this.button7.Tag = "ImgurPage";
            this.button7.Text = "Go";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Go_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(334, 8);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(35, 23);
            this.button6.TabIndex = 25;
            this.button6.Tag = "DirectLink";
            this.button6.Text = "Go";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Go_Click);
            // 
            // exceptionButton
            // 
            this.exceptionButton.Location = new System.Drawing.Point(278, 143);
            this.exceptionButton.Name = "exceptionButton";
            this.exceptionButton.Size = new System.Drawing.Size(50, 23);
            this.exceptionButton.TabIndex = 18;
            this.exceptionButton.Tag = "Exception";
            this.exceptionButton.Text = "Copy";
            this.exceptionButton.UseVisualStyleBackColor = true;
            this.exceptionButton.Click += new System.EventHandler(this.Copy_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(278, 114);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 23);
            this.button5.TabIndex = 17;
            this.button5.Tag = "DeleteLink";
            this.button5.Text = "Copy";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Copy_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(278, 86);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 23);
            this.button4.TabIndex = 16;
            this.button4.Tag = "LargeThumb";
            this.button4.Text = "Copy";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Copy_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(278, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 23);
            this.button3.TabIndex = 21;
            this.button3.Tag = "SmallThumb";
            this.button3.Text = "Copy";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Copy_Click);
            // 
            // exceptionTextBox
            // 
            this.exceptionTextBox.Location = new System.Drawing.Point(100, 145);
            this.exceptionTextBox.Name = "exceptionTextBox";
            this.exceptionTextBox.ReadOnly = true;
            this.exceptionTextBox.Size = new System.Drawing.Size(172, 20);
            this.exceptionTextBox.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(278, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 23);
            this.button2.TabIndex = 19;
            this.button2.Tag = "ImgurPage";
            this.button2.Text = "Copy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Copy_Click);
            // 
            // deleteLinkTextBox
            // 
            this.deleteLinkTextBox.Location = new System.Drawing.Point(100, 116);
            this.deleteLinkTextBox.Name = "deleteLinkTextBox";
            this.deleteLinkTextBox.ReadOnly = true;
            this.deleteLinkTextBox.Size = new System.Drawing.Size(172, 20);
            this.deleteLinkTextBox.TabIndex = 10;
            // 
            // exceptionLabel
            // 
            this.exceptionLabel.AutoSize = true;
            this.exceptionLabel.Location = new System.Drawing.Point(3, 148);
            this.exceptionLabel.Name = "exceptionLabel";
            this.exceptionLabel.Size = new System.Drawing.Size(54, 13);
            this.exceptionLabel.TabIndex = 7;
            this.exceptionLabel.Text = "Exception";
            // 
            // copyDirectLinkButton
            // 
            this.copyDirectLinkButton.Location = new System.Drawing.Point(278, 8);
            this.copyDirectLinkButton.Name = "copyDirectLinkButton";
            this.copyDirectLinkButton.Size = new System.Drawing.Size(50, 23);
            this.copyDirectLinkButton.TabIndex = 20;
            this.copyDirectLinkButton.Tag = "DirectLink";
            this.copyDirectLinkButton.Text = "Copy";
            this.copyDirectLinkButton.UseVisualStyleBackColor = true;
            this.copyDirectLinkButton.Click += new System.EventHandler(this.Copy_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Delete Link";
            // 
            // largeThumbTextBox
            // 
            this.largeThumbTextBox.Location = new System.Drawing.Point(100, 88);
            this.largeThumbTextBox.Name = "largeThumbTextBox";
            this.largeThumbTextBox.ReadOnly = true;
            this.largeThumbTextBox.Size = new System.Drawing.Size(172, 20);
            this.largeThumbTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Large Thumbnail";
            // 
            // smallThumbTextBox
            // 
            this.smallThumbTextBox.Location = new System.Drawing.Point(100, 62);
            this.smallThumbTextBox.Name = "smallThumbTextBox";
            this.smallThumbTextBox.ReadOnly = true;
            this.smallThumbTextBox.Size = new System.Drawing.Size(172, 20);
            this.smallThumbTextBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Small Thumbnail";
            // 
            // imgurPageTextBox
            // 
            this.imgurPageTextBox.Location = new System.Drawing.Point(100, 36);
            this.imgurPageTextBox.Name = "imgurPageTextBox";
            this.imgurPageTextBox.ReadOnly = true;
            this.imgurPageTextBox.Size = new System.Drawing.Size(172, 20);
            this.imgurPageTextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Imgur Page";
            // 
            // directLinkTextBox
            // 
            this.directLinkTextBox.Location = new System.Drawing.Point(100, 10);
            this.directLinkTextBox.Name = "directLinkTextBox";
            this.directLinkTextBox.ReadOnly = true;
            this.directLinkTextBox.Size = new System.Drawing.Size(172, 20);
            this.directLinkTextBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Direct Link";
            // 
            // ImgurResponseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.exceptionButton);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.exceptionTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.deleteLinkTextBox);
            this.Controls.Add(this.exceptionLabel);
            this.Controls.Add(this.copyDirectLinkButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.largeThumbTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.smallThumbTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imgurPageTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.directLinkTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ImgurResponseControl";
            this.Size = new System.Drawing.Size(378, 175);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button exceptionButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox exceptionTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox deleteLinkTextBox;
        private System.Windows.Forms.Label exceptionLabel;
        private System.Windows.Forms.Button copyDirectLinkButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox largeThumbTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox smallThumbTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox imgurPageTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox directLinkTextBox;
        private System.Windows.Forms.Label label1;
    }
}
