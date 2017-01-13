using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CSWebAppsServiceTest
{
    [TestClass]
    public class CSWebAppsServiceTest
    {
        String domainUrl = "http://cs-webapps-service-prod.chinacloudapp.cn/";
        //string domainUrl = "http://fbbaed324f2b439fa19f922b2c0c08a1.chinacloudapp.cn/";
        //string domainUrl = "http://prod-cswechat-websites-0-staging.chinacloudsites.cn/";
        //String domainUrl = "http://cs-webapps-service-int.chinacloudapp.cn/";
        string HiSendMessageUrl = "webApps/HiSendMessage?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&sign=osulywmy";
        string HiReadLatestMessageUrl = "WebApps/HiReadLatestMessage?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&sign=osulywmy";
        string HiReadNewMessageByUserUrl = "WebApps/HiReadNewMessageByUser?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&messageId=9058799639&sign=osulywmy";
        string GetUserProfileUrl = "WebApps/GetUserProfile?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&sign=osulywmy";
        string HiReadNewMessageByStaffUrl = "WebApps/HiReadNewMessageByStaff?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&messageId=9058799639&sign=osulywmy&staffId=root";
        string HiReadHistoryMessageUrl = "WebApps/HiReadHistoryMessage?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&messageId=8897451991&sign=osulywmy&staffId=root";
        string HiFindRecentRepliedStaffIdUrl = "WebApps/HiFindRecentRepliedStaffId?appId=wx6846d580669f169e&partnerId=25&userId=o6JzkwzXIUWQwe3LrNHpeGeExit4&staffId=root&messageId=8909689666&sign=osulywmy";
        string MesTemp = "{'UkserId':'o6JzkwzXIUWQwe3LrNHpeGeExit4','UserNickname':'方正圆','StaffId':'root','Content':'THE LATEST MESSAGE','Image':{},'ContentType':4,'DirectionType':2,'CreateTimeStamp':'','CreateTime':''}";
        string posttemp = "{'UserId':'o6JzkwzXIUWQwe3LrNHpeGeExit4'}";
        [TestMethod]
        [TestCategory("HiSendMessage")]
        public void HiSendMessageTest()
        { 
           string Response = HTTPUtility.GetResponse(domainUrl + HiSendMessageUrl, MesTemp);
           Assert.IsTrue(Response.Contains("\"success\":true"), Response);
           Console.WriteLine(HTTPUtility.timeSpan.TotalMilliseconds+" ms");
        }

        [TestMethod]
        [TestCategory("HiReadLatestMessage")]
        public void HiReadLatestMessagTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + HiReadLatestMessageUrl, posttemp);
            Assert.IsTrue(Response.Contains("\"success\":true"), Response);
            Console.WriteLine(HTTPUtility.timeSpan.TotalMilliseconds + " ms");
        }

        [TestMethod]
        [TestCategory("Is_SendMessage_equalTo_GetLatestMsg")]
        public void Is_SendMessage_equalTo_GetLatestMsg()
        {
            List<string> ids = new List<string>();
            string HiSendMessageResonse= HTTPUtility.GetResponse(domainUrl + HiSendMessageUrl, MesTemp);
            double HiSendMessageResonseTime = HTTPUtility.timeSpan.TotalMilliseconds;
            int HiSendMessageIndex = HiSendMessageResonse.IndexOf("id", 0);
            string Message = HiSendMessageResonse.Substring(HiSendMessageIndex+4, 10);
            string HiReadLatestMessagResonse= HTTPUtility.GetResponse(domainUrl + HiReadLatestMessageUrl, posttemp);
            int index=HiReadLatestMessagResonse.IndexOf("MessageId", 0);
            while(index< HiReadLatestMessagResonse.Length&&index>0)
            {
                ids.Add(HiReadLatestMessagResonse.Substring(index+11,10));
                index = HiReadLatestMessagResonse.IndexOf("MessageId", index+22);
            }
            Assert.IsTrue(ids[ids.Count - 1].Equals(Message), "HiSendMessageResonse:" + ids[ids.Count - 1]+ "\tHiReadLatestMessagResonse:"+ HiReadLatestMessagResonse);
            Console.WriteLine(HiSendMessageResonseTime+HTTPUtility.timeSpan.TotalMilliseconds + " ms");
        }

        [TestMethod]
        [TestCategory("HiReadNewMessageByUser")]
        public void HiReadNewMessageByUserTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + HiReadNewMessageByUserUrl, posttemp);
            Assert.IsTrue(Response.Contains("\"success\":true"),Response);
            Console.WriteLine(HTTPUtility.timeSpan.TotalMilliseconds + " ms");
        }

        [TestMethod]
        [TestCategory("GetUserProfile")]
        public void GetUserProfileTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + GetUserProfileUrl, posttemp);
            Assert.IsTrue(Response.Contains("\"success\":true"),Response);
            Console.WriteLine(HTTPUtility.timeSpan.TotalMilliseconds + " ms");
        }

        [TestMethod]
        [TestCategory("HiReadNewMessageByStaff")]
        public void HiReadNewMessageByStaffTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + HiReadNewMessageByStaffUrl, posttemp);
            Assert.IsTrue(Response.Contains("\"success\":true"),Response);
            Console.WriteLine(HTTPUtility.timeSpan.TotalMilliseconds + " ms");
        }

        [TestMethod]
        [TestCategory("HiReadHistoryMessage")]
        public void HiReadHistoryMessageTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + HiReadHistoryMessageUrl, posttemp);
            Assert.IsTrue(Response.Contains("\"success\":true"),Response);
            Console.WriteLine(HTTPUtility.timeSpan.TotalMilliseconds + " ms");
        }

        [TestMethod]
        [TestCategory("HiFindRecentRepliedStaffId")]
        public void HiFindRecentRepliedStaffIdTest()
        {
            string Response = HTTPUtility.GetResponse(domainUrl + HiFindRecentRepliedStaffIdUrl, posttemp);
            Assert.IsTrue(Response.Contains("\"success\":true"),Response);
            Console.WriteLine(HTTPUtility.timeSpan.TotalMilliseconds + " ms");
        }

    }
}
