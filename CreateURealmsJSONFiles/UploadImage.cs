using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Drawing;

namespace CreateURealmsJSONFiles
{
    class UploadImage
    {
        static public string UploadImageWithEasyImgur(string file)
        {
            Console.WriteLine("Processing " + file.ToString());

            var fileName = file.ToString();

            var logFile = @"C:\Users\sean-\AppData\Roaming\EasyImgur\easyimgur.log";
            File.Delete(logFile);

            Bat.ExecuteCommand(@"C:\Users\sean-\Downloads\EasyImgur_v0-3-6\EasyImgur.exe " + file);
            do
            {
                System.Threading.Thread.Sleep(1000);
            } while (File.Exists(logFile) == false);

            var lastLine = "";
            do
            {
                try
                {
                    lastLine = File.ReadLines(@"C:\Users\sean-\AppData\Roaming\EasyImgur\easyimgur.log").Last();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            } while (lastLine.Contains("Showed tooltip with title \"Success!\" and text \"Upload placed in history:") == false);
            var url = lastLine.Remove(0, 107);
            url = url.Replace("\".", "");
            return url;
        }
        static public void UploadImageToImgur(string file)
        {
            //"3c218a661ce5aeaf4af53e9a3d230473ee10781b"





            WebClient client = new WebClient();
            NameValueCollection values = new NameValueCollection();
            values["image"] = Convert.ToBase64String(File.ReadAllBytes(file));
            values["clientId"] = "c927064c3cd35e5";
            byte[] responseBytes = client.UploadValues("https://api.imgur.com/3/upload.xml", values);
            string response = Encoding.Default.GetString(responseBytes);
            client.Dispose();

        }

        static public void UploadImageVersion2(string file)
        {

            byte[] newfile = File.ReadAllBytes(file);

            //c927064c3cd35e5

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.imgur.com/3/image");
            request.Headers.Add("Authorization", "Client-ID c927064c3cd35e5");
            request.Method = "POST";

            ASCIIEncoding enc = new ASCIIEncoding();
            string postData = Convert.ToBase64String(newfile);
            byte[] bytes = enc.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;

            Stream writer = request.GetRequestStream();
            writer.Write(bytes, 0, bytes.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }
    }
}
