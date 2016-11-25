using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTests
{
    public class MessageModel
    {
        public string UserId { get; set; }
        public string UserNickname { get; set; }
        public string StaffId { get; set; }
        public string Content { get; set; }
        public MessageImage Image { get; set; }
        public int ContentType { get; set; }
        public int DirectionType { get; set; }
        public int CreateTimeStamp { get; set; }
        public string CreateTime { get; set; }
        public int PromisedTag { get; set; }
    }

    public class MessageImage
    {
        public MessageImage()
        {
            Url = "";
            Height = "";
            Width = "";
        }

        public string Url { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }

    }


    class Program
    {
        static void Main(string[] args)
        {
            String domainUrl = "http://e.msxiaobing.com/";
            string HiSendMessageUrl = "WebApps/HiSendMessage?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&sign=osulywmy";
            string HiReadLatestMessageUrl = "WebApps/HiReadLatestMessage?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&sign=osulywmy";
            string HiReadNewMessageByUserUrl = "WebApps/HiReadNewMessageByUser?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&messageId=9058799639&sign=osulywmy";
            string GetUserProfileUrl = "WebApps/GetUserProfile?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&sign=osulywmy";
            string HiReadNewMessageByStaffUrl = "WebApps/HiReadNewMessageByStaff?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&messageId=9058799639&sign=osulywmy&staffId=root";
            string HiReadHistoryMessageUrl = "WebApps/HiReadHistoryMessage?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&messageId=8897451991&sign=osulywmy&staffId=root";
            string HiFindRecentRepliedStaffIdUrl = "WebApps/HiFindRecentRepliedStaffId?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&messageId=8909689666&sign=osulywmy";
            //var url = "http://e.msxiaobing.com/WebApps/HiSendMessage?appId=wx6fa1ce38190e98f3&partnerId=25&userId=of5NLwzb4DdNH1WpKgyoG0XTc8KU&sign=mllaywhy";
            //var url = "http://stcvm-ls202:48794/WebApps/HiSendMessage?appId=wx6fa1ce38190e98f3&partnerId=25&userId=of5NLwzb4DdNH1WpKgyoG0XTc8KU&sign=mllaywhy";
            var url = "http://csint.trafficmanager.cn/WebApps/HiSendMessage?appId=wx6fa1ce38190e98f3&partnerId=25&userId=of5NLwzb4DdNH1WpKgyoG0XTc8KU&sign=mllaywhy";
            //string data = "{\"Content\": \"12\",\"ContentType\":\"4\",\"CreateTimeStamp\":\"1479726078353\",\"DirectionType\":\"1\",\"StaffId\":\"\",\"UserId\":\"of5NLwzb4DdNH1WpKgyoG0XTc8KU\",\"UserNickname\":\"xun\"}";
            var unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var msg = NewMethod(unixTimestamp, "", "of5NLwzb4DdNH1WpKgyoG0XTc8KU");
            var data = JsonConvert.SerializeObject(msg);

            //string data1 = @"{
            //        UserId: 'of5NLwzb4DdNH1WpKgyoG0XTc8KU',
            //        UserNickname: 'xun',
            //        StaffId: '',
            //        Content: '212125',
            //        Image: {
            //            Url: '',
            //            Height: '',
            //            Width: ''
            //        },
            //        ContentType: 4,
            //        DirectionType: 1,
            //        CreateTimeStamp: " + unixTimestamp.ToString() + ",                    CreateTime: '',                    PromisedTag: '" + unixTimestamp.ToString() + "'            } ";

            string data11 = @"{'UserId':'of5NLwzb4DdNH1WpKgyoG0XTc8KU','UserNickname':'xun','StaffId':'root','Content':'THE LATEST MESSAGE','Image':{},'ContentType':4,'DirectionType':2,'CreateTimeStamp':'','CreateTime':''}";
            string HiSendMessageResponse= GetResponse(domainUrl+HiSendMessageUrl, data);
            string HiReadLatestMessage = GetResponse(domainUrl + HiReadLatestMessageUrl);
            

        }

        private static MessageModel NewMethod(int tp, string content, string userId)
        {
            var msg = new MessageModel()
            {
                UserId = userId,
                Content = content,
                CreateTimeStamp = tp,
                PromisedTag = tp,

                UserNickname = "xun",
                StaffId = "",
                ContentType = 4,
                DirectionType = 1,
                Image = new MessageImage(),
                CreateTime = "",

            };
            return msg;
        }

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
                    //webClient.Headers.Add("Host", "e.msxiaobing.com");
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
