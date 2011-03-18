using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.Collections.Specialized;
using System.Xml.Linq;
using System.IO;

namespace ScreenGrabber {
    public static class ImgurUploader {
        public static ImgurResponse UploadImage(string path) {
            if (File.Exists(path)) {
                Image image = Image.FromFile(path);
                return UploadImage(image);
            }
            else {
                throw new FileNotFoundException("Could not find image file.", path);
            }
        }

        public static ImgurResponse UploadImage(Image image) {
            ImgurResponse res = new ImgurResponse();
            using (WebClient wc = new WebClient()) {
                var fields = GetFields(image);
                try {
                    var response = wc.UploadValues(Properties.Settings.Default.ImgurApiUrl, fields);
                    res = GetImgurResponse(response);
                }
                catch (Exception exc) {
                    res.Exception = exc;
                }
            }
            return res;
        }

        private static NameValueCollection GetFields(Image image) {
            NameValueCollection res = new NameValueCollection();
            res.Add("key", Properties.Settings.Default.ImgurApiKey);
            res.Add("image", image.ToBase64());
            res.Add("type", "base64");
            return res;
        }

        private static ImgurResponse GetImgurResponse(byte[] data) {
            ImgurResponse res = new ImgurResponse() { Exception = null };
            XElement xml;
            try {
                xml = XElement.Parse(Encoding.UTF8.GetString(data));
                res.ResponseTime = DateTime.Now;
                res.DeleteLink = xml.Element("links").Element("delete_page").Value;
                res.DirectLink = xml.Element("links").Element("original").Value;
                res.ImgurPage = xml.Element("links").Element("imgur_page").Value;
                res.SmallThumb = xml.Element("links").Element("small_square").Value;
                res.LargeThumb = xml.Element("links").Element("large_thumbnail").Value;
            }
            catch (Exception exc) {
                res.Exception = exc;
            }
            ResponseLog.AddResponse(res);
            return res;
        }
    }

    public class ImgurResponse {
        public string DeleteLink { get; set; }
        public string DirectLink { get; set; }
        public string ImgurPage { get; set; }
        public string SmallThumb { get; set; }
        public string LargeThumb { get; set; }

        public Exception Exception { get; set; }

        public DateTime ResponseTime { get; set; }
    }
}
