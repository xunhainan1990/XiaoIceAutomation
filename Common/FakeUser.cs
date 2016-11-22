using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FakeUser
    {
        public string GetResponse(string url, string data = null)
        {
            WebClient webClient = new WebClient();

            string response = null;
            try
            {
                //using (var wc = new System.Net.WebClient())
                //{
                //    wc.Headers["Method"] = "Post";
                //    wc.Headers["ContentType"] = "application/json;charset=\"gb2312\"";
                //    wc.Headers["Accept"] = "text/xml, */*";
                //    webClient.Encoding = System.Text.Encoding.UTF8;
                //    wc.Headers["User-Agent"] = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; .NET CLR 3.5.30729;)";
                //    wc.Headers[HttpRequestHeader.AcceptLanguage] = "en-us";
                //    wc.Headers["KeepAlive"] = "true";
                //    wc.Headers["AutomaticDecompression"] = (DecompressionMethods.Deflate | DecompressionMethods.GZip).ToString();
                //    response = wc.UploadString(url, data);
                //}


                lock (webClient)
                {
                    webClient.Headers.Clear();
                    webClient.Headers.Add("Accept", "*");
                    webClient.Headers.Add("Host", "e.msxiaobing.com");
                    webClient.Headers.Add("Content-Type", "application/json");
                    webClient.Headers["KeepAlive"] = "true";
                    webClient.Headers["Method"] = "Post";
                    webClient.Headers[HttpRequestHeader.AcceptLanguage] = "en-us";
                    webClient.Headers["User-Agent"] = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; .NET CLR 3.5.30729;)";
                    webClient.Headers["AutomaticDecompression"] = (DecompressionMethods.Deflate | DecompressionMethods.GZip).ToString();
                    //webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic" + Convert.ToBase64String(
                    //        System.Text.ASCIIEncoding.ASCII.GetBytes(
                    //            string.Format("{0}:{1}", this.AuthUser, this.AuthPassword))));

                    webClient.Encoding = Encoding.UTF8;
                    if (!string.IsNullOrEmpty(data))
                    {
                        response = webClient.UploadString(url, data);
                    }
                    else
                    {
                        response = webClient.DownloadString(url);
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
