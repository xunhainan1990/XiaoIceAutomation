using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSWebAppsServiceTest
{
    public class HTTPUtility
    {
        public static TimeSpan timeSpan ;
        public static string GetResponse(string url, string data = null)
        {

            WebClient webClient = new WebClient();

            string response = null;
            try
            {
                lock (webClient)
                {
                    webClient.Headers.Clear();
                    //webClient.Headers.Add("Accept", "*");
                    webClient.Headers.Add("Content-Type", "application/json");
                    //webClient.Headers["KeepAlive"] = "true";
                    //webClient.Headers["Method"] = "Post";
                    //webClient.Headers[HttpRequestHeader.AcceptLanguage] = "en-us";
                    //webClient.Headers["User-Agent"] = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; .NET CLR 3.5.30729;)";
                    //webClient.Headers["AutomaticDecompression"] = (DecompressionMethods.Deflate | DecompressionMethods.GZip).ToString();

                    webClient.Encoding = Encoding.UTF8;

                    if (!string.IsNullOrEmpty(data))
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        response = webClient.UploadString(url, data);
                        sw.Stop();
                        timeSpan = sw.Elapsed;

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

        public static bool GetSourceUrl(string response)
        {
            int indexSourceUrl= response.IndexOf("SourceUrl");
            
            if(response.Substring(indexSourceUrl + 18, 4) =="http")
                return true;
            return false;
        }
    }
}
