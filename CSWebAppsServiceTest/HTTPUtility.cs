using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSWebAppsServiceTest
{
    public class HTTPUtility
    {
        public static string GetResponse(string url, string data = null)
        {
            WebClient webClient = new WebClient();

            string response = null;
            try
            {
                lock (webClient)
                {
                    webClient.Headers.Clear();
                    webClient.Headers.Add("Accept", "*");
                    webClient.Headers.Add("Content-Type", "application/json");
                    webClient.Headers["KeepAlive"] = "true";
                    webClient.Headers["Method"] = "Post";
                    webClient.Headers[HttpRequestHeader.AcceptLanguage] = "en-us";
                    webClient.Headers["User-Agent"] = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; .NET CLR 3.5.30729;)";
                    webClient.Headers["AutomaticDecompression"] = (DecompressionMethods.Deflate | DecompressionMethods.GZip).ToString();

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
