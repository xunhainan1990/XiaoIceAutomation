using System;
using System.Collections.Generic;
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
                lock (webClient)
                {
                    webClient.Headers.Add("Content-Type", "application/json");
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
