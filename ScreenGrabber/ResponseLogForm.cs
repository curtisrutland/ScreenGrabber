using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenGrabber.Properties;

namespace ScreenGrabber {
    public partial class ResponseLogForm : Form {
        private List<ImgurResponse> responses;
        private int lastIndex = -1;

        public ResponseLogForm() {
            InitializeComponent();
            responses = ResponseLog.GetAllResponses();
            if (!responses.Any())
                NoResponses();
            else
                Initialize();
        }

        private void Initialize() {
            responses = responses.OrderByDescending(r => r.ResponseTime).ToList();
            responses.ForEach(r => listBox.Items.Add(r.ResponseTime.ToString(Settings.Default.ShortDateFormat)));
            listBox.SelectedIndex = 0;
        }

        private void NoResponses() {
            listBox.Items.Add("No uploads this session.");
            listBox.Enabled = false;
            webBrowser.Visible = false;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e) {
            int si = listBox.SelectedIndex;
            if (si >= responses.Count || si < 0 || si == lastIndex)
                return;
            var res = responses[si];
            imgurResponseControl.ImgurResponse = res;
            webBrowser.Navigate(res.DirectLink);
            lastIndex = si;
        }
    }
}
