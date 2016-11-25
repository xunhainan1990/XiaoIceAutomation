using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CSWebAppsServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        String domainUrl = "http://cs-webapps-service-prod.chinacloudapp.cn/";
        //string HiSendMessageUrl = "WebApps/HiSendMessage?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&sign=osulywmy";
        string HiReadLatestMessageUrl = "WebApps/HiReadLatestMessage?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&sign=osulywmy";
        string HiReadNewMessageByUserUrl = "WebApps/HiReadNewMessageByUser?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&messageId=9058799639&sign=osulywmy";
        string GetUserProfileUrl = "WebApps/GetUserProfile?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&sign=osulywmy";
        string HiReadNewMessageByStaffUrl = "WebApps/HiReadNewMessageByStaff?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&messageId=9058799639&sign=osulywmy&staffId=root";
        string HiReadHistoryMessageUrl = "WebApps/HiReadHistoryMessage?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&messageId=8897451991&sign=osulywmy&staffId=root";
        string HiFindRecentRepliedStaffIdUrl = "WebApps/HiFindRecentRepliedStaffId?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&messageId=8909689666&sign=osulywmy";
        //string MesTemp = "{'UserId':'o6JzkwzXIUWQwe3LrNHpeGeExit4','UserNickname':'方正圆','StaffId':'root','Content':'THE LATEST MESSAGE','Image':{},'ContentType':4,'DirectionType':2,'CreateTimeStamp':'','CreateTime':''}";


        string HiSendMessageUrl = "WebApps/HiSendMessage?appId=wx6fa1ce38190e98f3&partnerId=25&userId=of5NLwzb4DdNH1WpKgyoG0XTc8KU&staffId=root&sign=mllaywhy";
        //string HiReadLatestMessageUrl = "WebApps/HiReadLatestMessage?appId=wx6fa1ce38190e98f3&partnerId=25&userId=of5NLwzb4DdNH1WpKgyoG0XTc8KU&staffId=root&sign=mllaywhy";
        //string HiReadNewMessageByUserUrl = "WebApps/HiReadNewMessageByUser?appId=wx6fa1ce38190e98f3&partnerId=25&userId=of5NLwzb4DdNH1WpKgyoG0XTc8KU&staffId=root&messageId=9058799639&sign=mllaywhy";
        //string GetUserProfileUrl = "WebApps/GetUserProfile?appId=wx6fa1ce38190e98f3&partnerId=25&userId=of5NLwzb4DdNH1WpKgyoG0XTc8KU&staffId=root&sign=mllaywhy";
        //string HiReadNewMessageByStaffUrl = "WebApps/HiReadNewMessageByStaff?appId=wx6fa1ce38190e98f3&partnerId=25&userId=of5NLwzb4DdNH1WpKgyoG0XTc8KU&messageId=9058799639&sign=mllaywhy&staffId=root";
        //string HiReadHistoryMessageUrl = "WebApps/HiReadHistoryMessage?appId=wx6fa1ce38190e98f3&partnerId=25&userId=of5NLwzb4DdNH1WpKgyoG0XTc8KU&messageId=8897451991&sign=mllaywhy&staffId=root";
        //string HiFindRecentRepliedStaffIdUrl = "WebApps/HiFindRecentRepliedStaffId?appId=wx6fa1ce38190e98f3&partnerId=25&userId=of5NLwzb4DdNH1WpKgyoG0XTc8KU&staffId=root&messageId=8909689666&sign=mllaywhy";
        string MesTemp = "{'UserId':'of5NLwzb4DdNH1WpKgyoG0XTc8KU','UserNickname':'xun','StaffId':'root','Content':'THE LATEST MESSAGE','Image':{},'ContentType':4,'DirectionType':2,'CreateTimeStamp':'','CreateTime':''}";
        [TestMethod]
        [TestCategory("HiSendMessage")]
        public void HiSendMessageTest()
        {
           
            //string data = string.Format(MesTemp, "o6JzkwzXIUWQwe3LrNHpeGeExit4", "方正圆");
            //var unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            //var msg = NewMethod(unixTimestamp, "", "of5NLwzb4DdNH1WpKgyoG0XTc8KU");
            //var data = JsonConvert.SerializeObject(msg);
            string Response = HTTPUtility.GetResponse(domainUrl + HiSendMessageUrl, MesTemp);          
            Assert.IsTrue(Response.Contains("\"success\":true"));

        }

        [TestMethod]
        [TestCategory("HiReadLatestMessage")]
        public void HiReadLatestMessagTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + HiReadLatestMessageUrl);
            Assert.IsTrue(Response.Contains("\"success\":true"));
        }

        [TestMethod]
        [TestCategory("HiReadLatestMessage")]
        public void Is_SendMessage_equalTo_GetLatestMsg()
        {
            List<string> ids = new List<string>();
            string HiSendMessageResonse= HTTPUtility.GetResponse(domainUrl + HiSendMessageUrl, MesTemp);
            int HiSendMessageIndex = HiSendMessageResonse.IndexOf("id", 0);
            string Message = HiSendMessageResonse.Substring(HiSendMessageIndex+4, 10);
            string HiReadLatestMessagResonse= HTTPUtility.GetResponse(domainUrl + HiReadLatestMessageUrl);
            int index=HiReadLatestMessagResonse.IndexOf("MessageId", 0);
            while(index< HiReadLatestMessagResonse.Length&&index>0)
            {
                ids.Add(HiReadLatestMessagResonse.Substring(index+11,10));
                index = HiReadLatestMessagResonse.IndexOf("MessageId", index+22);
            }
            Assert.IsTrue(ids[ids.Count - 1].Equals(Message));
        }

        [TestMethod]
        [TestCategory("HiReadNewMessageByUser")]
        public void HiReadNewMessageByUserTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + HiReadNewMessageByUserUrl);
            Assert.IsTrue(Response.Contains("\"success\":true"));
        }

        [TestMethod]
        [TestCategory("GetUserProfile")]
        public void GetUserProfileTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + GetUserProfileUrl);
            Assert.IsTrue(Response.Contains("\"success\":true"));
        }

        [TestMethod]
        [TestCategory("HiReadNewMessageByStaff")]
        public void HiReadNewMessageByStaffTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + HiReadNewMessageByStaffUrl);
            Assert.IsTrue(Response.Contains("\"success\":true"));
        }

        [TestMethod]
        [TestCategory("HiReadHistoryMessage")]
        public void HiReadHistoryMessageTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + HiReadHistoryMessageUrl);
            Assert.IsTrue(Response.Contains("\"success\":true"));
        }

        [TestMethod]
        [TestCategory("HiFindRecentRepliedStaffId")]
        public void HiFindRecentRepliedStaffIdTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + HiFindRecentRepliedStaffIdUrl);
            Assert.IsTrue(Response.Contains("\"success\":true"));
        }

    }
}
