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

        public String domainUrl = "http://cs-webapps-service-prod.chinacloudapp.cn/WebApps/HiSendMessage?appId=wx6fa1ce38190e98f3&partnerId=25&userId={0}&staffId=root&sign={1}";
        public string contentTemp = "{'UserId':'{0}','UserNickname':'{1}','StaffId':'root','Content':'THE LATEST MESSAGE','Image':{},'ContentType':4,'DirectionType':2,'CreateTimeStamp':'','CreateTime':''}";
        public  string url = string.Empty;
        public string content = string.Empty;
        public FakeUser(string userID,string sign,string userNickname)
        {
            url=string.Format(domainUrl,userID,sign);
            content=contentTemp.Replace("{0}", userID).Replace("{1}", userNickname);
        }

        public string GetResponse(string url, string data = null)
        {
            WebClient webClient = new WebClient();

            string response = null;
            try
            { 
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
