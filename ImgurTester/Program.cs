using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;

namespace ImgurTester
{
    class Program
    {
        private static string apikey = "04d465deabb22c7558164bafd4c1781a";
        private static string imagePath = @"c:\dev\screenshot.png";
        private static string dumpPath = @"c:\dev\imgurresponse.xml";
        private static string url = @"http://api.imgur.com/2/upload.xml";
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            Image i = Image.FromFile(imagePath);
            NameValueCollection data = new NameValueCollection();            
            data.Add("key", apikey);
            data.Add("image", i.ToBase64());
            data.Add("type", "base64");
            Console.WriteLine("Uploading");
            var responseBytes = client.UploadValues(url, "POST", data);
            Console.WriteLine("Done uploading");
            string response = Encoding.UTF8.GetString(responseBytes);
            using (StreamWriter sw = new StreamWriter(dumpPath))
                sw.Write(response);
            System.Diagnostics.Process.Start(dumpPath);
        }
    }

    public static class Extensions
    {
        public static string ToBase64(this Image image)
        {
            string result;
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                stream.Position = 0;
                using (BinaryReader reader = new BinaryReader(stream))
                    result = Convert.ToBase64String(reader.ReadBytes((int)stream.Length));
            }
            return result;
        }
    }
}
