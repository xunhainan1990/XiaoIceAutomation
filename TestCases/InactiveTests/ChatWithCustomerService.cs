using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using XiaoIceH5;
using Common;
using XiaoIceH5.UIElement;
using XiaoIcePortal.Driver;
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;
using OpenQA.Selenium.Appium.Android;

namespace TestCases.InactiveTests
{
    [TestClass]
    public class ChatWithHI : PortalTests.PortalTestInit
    {
        [TestInitialize]
        public void LunchWeChat()
        {
            AndroidDriver.AndroidInitialize();
            //PortalChromeDriver.ChromeInitialize();
        }

        /// <summary>
        /// 27.	[客服人员设定]是否可以正常使用，当登陆密码有效期超过60s时
        /// </summary>
        [TestMethod]
        public void CanStaffBindIfTimeOut()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            //切换到Hi的设置Tab页
            HIPage.SwichHISettingTab(HIPageUIElement.SubTabHIStaff);
            Thread.Sleep(10 * 1000);
            //判断是否已经绑定客服，如果绑定，则删除客服
            HIPage.DeleteStaff();
            //获取绑定客服验证码
            var value=HIPage.GetLoginCode();
            Thread.Sleep(5 * 1000);
            //H5页面进入平台测试账号对话窗口     
            HI.GetToTestAccount();
            //等待60秒,超过有效期
            Thread.Sleep(60*1000);
            //发送验证码
            HI.SendMessage(value);
            Assert.IsFalse(HI.IsStaffBind());
        }

        /// <summary>
        /// 28.	[客服人员设定]是否可以正常使用，当登陆密码过期后重新获取
        /// </summary>
        [TestMethod]
        public void RetainCodeIfTimeOut()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            //切换到Hi的设置Tab页
            HIPage.SwichHISettingTab(HIPageUIElement.SubTabHIStaff);
            Thread.Sleep(10 * 1000);
            //判断是否已经绑定客服，如果绑定，则删除客服
            HIPage.DeleteStaff();
            //获取绑定客服验证码
            var value = HIPage.GetLoginCode();
            Thread.Sleep(26*1000);
            //H5页面进入平台测试账号对话窗口     
            HI.GetToTestAccount();
            //删除聊天记录
            HI.ClearAllRecord();
            value=HIPage.GetLoginCode();     
            //发送验证码
            HI.SendMessage(value);
            Assert.IsTrue(HI.IsStaffBind());
        }

        /// <summary>
        /// 29.	[客服人员设定]是否可以正常使用，当登陆密码有效期超过60s时(首次绑定)
        /// </summary>
        [TestMethod]
        public void CheckCodeAvailableIfTimeOut()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            //切换到Hi的设置Tab页
            HIPage.SwichHISettingTab(HIPageUIElement.SubTabHIStaff);
            //判断是否已经绑定客服，如果绑定，则删除客服
            HIPage.DeleteStaff();
            //获取绑定客服验证码
            var value = HIPage.GetLoginCode();
            //H5页面进入平台测试账号对话窗口     
            HI.GetToTestAccount();
            //删除聊天记录
            HI.ClearAllRecord();
            Thread.Sleep(5 * 1000);
            //发送验证码
            HI.SendMessage(value);
            //验证网页版是否成功绑定
            Assert.IsTrue(HI.IsStaffBind());
            //验证Mobile是否有绑定成功提示
            Assert.IsTrue(HI.CanBindStaff());

        }

        /// <summary>
        /// 33.	是否有新消息提示标识显示，当开启人工客服后有消息接入
        /// </summary>
        [TestMethod]
        public void Is_New_Msg_Tip()
        {

            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            //绑定一个人工客服
            HI.BindStaff();
            //H5页面进入平台测试账号对话窗口   
            HI.GetToTestAccount();
            //发送验证码
            HI.SendMessage("客服");
            //点击HICard
            var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
            HICard.Click();
            Thread.Sleep(10 * 1000);
            //客服窗口发送消息
            HI.XB_SendMessage("这里是测试账号");
            //小红点的判断
        }

        /// <summary>
        /// 38.	[对话窗口]用户消息列表的时间是否可以正常使用回
        /// </summary>
        //[TestMethod]
        //public void CheckTimestamp()
        //{
        //    LoginPage.GoTo();
        //    HomePage.ClickWeChatApp();
        //    //Go to AI Page
        //    WeChatManagermentPage.GoToHIPage();
        //    Thread.Sleep(2 * 1000);
        //    //click settings
        //    HIPage.ClickSettings();
        //    Thread.Sleep(2 * 1000);
        //    //Turn on HI
        //    if (HIPage.isOff()) { HIPage.TurnOn(); }
        //    Thread.Sleep(2 * 1000);

        //    //H5 Action
        //    var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
        //    contactlist.Click();
        //    Thread.Sleep(2 * 1000);

        //    var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
        //    officialaccount.Click();
        //    Thread.Sleep(2 * 1000);

        //    var bibilog = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
        //    bibilog.Click();
        //    Thread.Sleep(5 * 1000);

        //    var input = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
        //    input.Click();
        //    Thread.Sleep(5 * 1000);

        //    var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
        //    sendMessage.SendKeys("客服");
        //    Thread.Sleep(5 * 1000);

        //    var sendButton = AndroidDriver.GetElmentByXpath(HIChatElement.SendButtonXpath);
        //    sendButton.Click();
        //    Thread.Sleep(10 * 1000);

        //    var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
        //    HICard.Click();
        //    Thread.Sleep(10 * 1000);

        //    //var xb_inputbox = AndroidDriver.GetElmentByXpath(HIChatElement.xb_inputboxXpath);
        //    var xb_inputbox = AndroidDriver.GetElementByClassName("android.widget.EditText");
        //    xb_inputbox.SendKeys("这里是测试账号");
        //    Thread.Sleep(2 * 1000);
        //    var xb_add_btn = AndroidDriver.GetElementByClassName("android.widget.Button");
        //    xb_add_btn.Click();
        //    xb_add_btn.Click();
        //    HIPage.OpenHiChatWindow();
        //    Thread.Sleep(2 * 1000);

        //    for (int i = 1; i < 8; i++)
        //    {
        //        var userName = PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[" + i + "]/div[2]/div[1]/div[1]").Text;
        //        if (userName == "xun")
        //        {
        //            var timeStamp = PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[" + i + "]/div[2]/div[1]/div[2]").Text;
        //            Assert.IsTrue(timeStamp.Contains(":"));
        //        }
        //    }
        //}

        /// <summary>
        /// 40.	[对话窗口]用户消息列表是否可以正常显示，当超过8条消息时
        /// </summary>
        //[TestMethod]
        //public void CheckMessageCount()
        //{

        //    //确保HI是Turn on的状态
        //    HIPage.TurnOnSetup();
        //    Thread.Sleep(2 * 1000);
        //    //绑定一个人工客服
        //    HI.BindStaff();
        //    //H5页面进入平台测试账号对话窗口   
        //    HI.GetToTestAccount();
        //    //发送验证码
        //    HI.SendMessage("客服");
        //    //点击HICard
        //    var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
        //    HICard.Click();
        //    Thread.Sleep(10 * 1000);

        //    var xb_inputbox = AndroidDriver.GetElmentByXpath(HIChatElement.xb_inputboxXpath);
        //    var xb_add_btn = AndroidDriver.GetElmentByXpath(HIChatElement.xb_add_btnXpath);
        //    for (int i = 1; i <= 8; i++)
        //    {
        //        xb_inputbox.SendKeys("这里是测试账号" + i);
        //        Thread.Sleep(5 * 1000);
        //        xb_add_btn.Click();
        //        Thread.Sleep(5 * 1000);
        //    }

        //}


        /// <summary>
        /// 41.	[对话窗口]在用户消息列表中用户名和最新的一条消息长度过长时，是否可以正常显示
        /// </summary>
        //[TestMethod]
        //public void CheckMessageLength()
        //{

        //    LoginPage.GoTo();
        //    HomePage.ClickWeChatApp();
        //    //Go to AI Page
        //    WeChatManagermentPage.GoToHIPage();
        //    Thread.Sleep(2 * 1000);
        //    //click settings
        //    HIPage.ClickSettings();
        //    Thread.Sleep(2 * 1000);
        //    //Turn on HI
        //    if (HIPage.isOff()) { HIPage.TurnOn(); }
        //    Thread.Sleep(2 * 1000);

        //    //H5 Action
        //    var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
        //    contactlist.Click();
        //    Thread.Sleep(2 * 1000);

        //    var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
        //    officialaccount.Click();
        //    Thread.Sleep(2 * 1000);

        //    var bibilog = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
        //    bibilog.Click();
        //    Thread.Sleep(5 * 1000);

        //    var input = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
        //    input.Click();
        //    Thread.Sleep(5 * 1000);

        //    var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
        //    sendMessage.SendKeys("客服");
        //    Thread.Sleep(5 * 1000);

        //    var sendButton = AndroidDriver.GetElmentByXpath(HIChatElement.SendButtonXpath);
        //    sendButton.Click();
        //    Thread.Sleep(10 * 1000);

        //    var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
        //    HICard.Click();
        //    Thread.Sleep(10 * 1000);

        //    var xb_inputbox = AndroidDriver.GetElmentByXpath(HIChatElement.xb_inputboxXpath);
        //    var xb_add_btn = AndroidDriver.GetElmentByXpath(HIChatElement.xb_add_btnXpath);
        //    xb_inputbox.SendKeys("这里是超长字符测试这里是超长字符测试这里是超长字符测试");
        //    Thread.Sleep(5 * 1000);
        //    xb_add_btn.Click();
        //    Thread.Sleep(5 * 1000);

        //    HIPage.OpenHiChatWindow();
        //    Thread.Sleep(2 * 1000);

        //    for (int i = 1; i < 8; i++)
        //    {
        //        var userName = PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[" + i + "]/div[2]/div[1]/div[1]").Text;
        //        if (userName == "xun")
        //        {
        //            var timeStamp = PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[" + i + "]/div[2]/div[2]").Text;
        //            Assert.IsTrue(timeStamp.Contains("..."));
        //        }
        //    }

        //}

        /// <summary>
        /// 42.	[对话窗口]用户消息列表中点击一条未读消息，小红点是否取消显示
        /// </summary>
        [TestMethod]
        public void IsMsgTipGone()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            //H5页面进入平台测试账号对话窗口   
            HI.GetToTestAccount();
            //向公众号发送消息
            HI.SendMessage("客服");
            //点击HICard
            var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
            HICard.Click();
            Thread.Sleep(15 * 1000);
            //客服窗口发送消息
            HI.XB_SendMessage("这里是测试账号");
            //打开Hi对话窗口
            HIPage.OpenHiChatWindow();
            Thread.Sleep(10 * 1000);
            //可以封装为取到测试账号的函数，并返回该element
            for (int i = 1; i < 7; i++)
            {
                var userName = PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[" + i + "]/div[1]/span").Text;
                if (userName == "chrysanthemum15")
                {
                    PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[" + i + "]/div[2]/div[1]/div[1]").Click();
                    Thread.Sleep(60 * 10000);
                    //小红点是否为空
                    Assert.IsTrue(PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[1]/div[1]/span") == null);
                }
            }
        }

        /// <summary>
        /// 43.	客服是否可以正常回复收到的用户消息
        /// H5 8.	用户在H5对话窗口时，是否可以收到客服的回复
        /// </summary>
        [TestMethod]
        public void ReplyMessage()
        {

            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);

            //H5页面进入平台测试账号对话窗口   
            HI.GetToTestAccount();
            //H5呼叫客服
            HI.SendMessage("客服");
            //H5点击HICard
            var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
            HICard.Click();
            Thread.Sleep(15 * 1000);
            //H5用户发送消息
            HI.XB_SendMessage("这里是测试账号");

            //Portal客服打开Hi对话窗口     
            HIPage.OpenHiChatWindow();
            Thread.Sleep(2 * 1000);
            //点击测试账号
            HIPage.GetTestUserFromUserList();
            Thread.Sleep(5 * 1000);
            //客服发送消息
            HIPage.SendMessage("这里是客服");
            Thread.Sleep(2 * 1000);
            //验证Portal最后一条消息是不是客服回复的消息
            Assert.IsTrue(AndroidDriver.GetElmentByXpath("//android.view.View[contains(@content-desc,'这里是客服')]") != null);  
        }


        /// <summary>
        /// 44.	[对话窗口]是否可以在用户消息列表上次置顶显示，无论消息的状态是已读或未读，只要收到新的消息
        /// </summary>
        [TestMethod]
        public void NewMsgSecondTop_InHIWin()
        {  
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            //H5页面进入平台测试账号对话窗口   
            HI.GetToTestAccount();
            //H5呼叫客服
            HI.SendMessage("客服");
            //H5点击HICard
            var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
            HICard.Click();
            Thread.Sleep(10 * 1000);
            //H5用户发送消息
            HI.XB_SendMessage("这里是测试账号");

            //Portal客服打开Hi对话窗口
            HIPage.OpenHiChatWindow();
            Thread.Sleep(10 * 1000);
            //判断置顶的客户为发送消息的客户
            var userName = PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[1]/div[2]/div[1]/div[1]").Text;
            Assert.IsTrue(userName == "chrysanthemum");
        }

        /// <summary>
        /// 45.	[对话窗口]是否可以在用户消息列表上置顶-1，无论消息的状态是已读或未读，只要收到新的消息（除了当前聊天的用户外）
        /// </summary>
        [TestMethod]
        public void NewMsgSecondTop_NotInHIWin()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            //Portal客服打开Hi对话窗口
            HIPage.OpenHiChatWindow();
            Thread.Sleep(10 * 1000);
            //Portal点击其他用户，确保测试账号不在第一位
            HIPage.GetOtherUserFromUserList();

            //H5页面进入平台测试账号对话窗口   
            HI.GetToTestAccount();
            //H5呼叫客服
            HI.SendMessage("客服");
            //H5点击HICard
            var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
            HICard.Click();
            Thread.Sleep(10 * 1000);          
            //H5用户发送消息
            HI.XB_SendMessage("这里是测试账号");
            Thread.Sleep(5 * 1000);

            //判断第二置顶的客户为发送消息的客户
            var userName = PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[2]/div[2]/div[1]/div[1]").Text;
            Assert.IsTrue(userName == "chrysanthemum");
        }

        /// <summary>
        /// 54.	[对话窗口]是否有新消息提示标识显示，当开启人工客服后有消息接入
        /// </summary>
        [TestMethod]
        public void IsBigMsgTipGone()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);

            //H5页面进入平台测试账号对话窗口   
            HI.GetToTestAccount();
            //H5呼叫客服
            HI.SendMessage("客服");
            //H5点击HICard
            var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
            HICard.Click();
            Thread.Sleep(10 * 1000);
            //H5用户发送消息
            HI.XB_SendMessage("这里是测试账号");
            //
            Assert.IsTrue(HIPage.Is_Big_New_Msg_Tip());
        }

        /// <summary>
        /// 1.	功能开启后，在公众号里是否能触发人工客服card
        /// 2.	删除设置的关键词，是否还能触发人工客服card
        /// 3.	是否可以触发人工客服card，当输入含有找客服意向的语句
        /// </summary>
        [TestMethod] 
        public void TriggerHICardPerCustomize()
        {

            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            Thread.Sleep(2 * 1000);
            //click settings
            HIPage.ClickSettings();
            Thread.Sleep(2 * 1000);
            //Trun on HI
            if (HIPage.isOff()) { HIPage.TurnOn(); }
            Thread.Sleep(2 * 1000);

            #region 添加一条触发关键词
            HIPage.InputTrigger("hi");
            Thread.Sleep(2 * 1000);
            #endregion

            //H5 Action
            var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
            contactlist.Click();
            Thread.Sleep(2 * 1000);

            var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
            officialaccount.Click();
            Thread.Sleep(2 * 1000);

            var TestAccount = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
            TestAccount.Click();
            Thread.Sleep(5 * 1000);
            HI.ClearAllRecord();
            var input = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
            input.Click();
            Thread.Sleep(5 * 1000);
            var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
            sendMessage.SendKeys("hi");
            Thread.Sleep(5 * 1000);    
            var sendButton = AndroidDriver.GetElmentByXpath(HIChatElement.SendButtonXpath);
            sendButton.Click();
            Thread.Sleep(10 * 1000);
            Assert.IsTrue(HI.IsHiCardShow());
            //添加清楚聊天记录
            HI.ClearAllRecord();
            input.Click();
            HIPage.DeleteTrigger();
            sendMessage.SendKeys("hi");
            Thread.Sleep(5 * 1000);
            sendButton.Click();
            Thread.Sleep(10 * 1000);      
            Assert.IsFalse(XiaoIceH5.HI.IsHiCardShow());
             
            sendMessage.SendKeys("客服");
            Thread.Sleep(5 * 1000);
            sendButton.Click();
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(HI.IsHiCardShow());

        }

        /// <summary>
        /// 4.	修改设置好的关键词后，能否正常触发人工客服card
        /// </summary>
        [TestMethod]
        public void TriggerHiCardAfterEditTriger()
        {
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            Thread.Sleep(2 * 1000);
            //click settings
            HIPage.ClickSettings();
            Thread.Sleep(2 * 1000);
            //Trun on HI
            if (HIPage.isOff()) { HIPage.TurnOn(); }
            Thread.Sleep(2 * 1000);

            #region 
            HIPage.InputTrigger("Hi");
            Thread.Sleep(5 * 1000);
            HIPage.EditTrigger("append");
            HIPage.ClickSomewhereToSave();
            #endregion

            //H5 Action
            var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
            contactlist.Click();
            Thread.Sleep(2 * 1000);

            var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
            officialaccount.Click();
            Thread.Sleep(2 * 1000);

            var bibilog = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
            bibilog.Click();
            Thread.Sleep(5 * 1000);
            HI.ClearAllRecord();
            var input = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
            input.Click();
            Thread.Sleep(5 * 1000);


            var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
            sendMessage.SendKeys("Hiappend");
            Thread.Sleep(5 * 1000);

            var sendButton = AndroidDriver.GetElmentByXpath(HIChatElement.SendButtonXpath);
            sendButton.Click();
            Thread.Sleep(10 * 1000);
            Assert.IsTrue(HI.IsHiCardShow());
            HI.ClearAllRecord();
            input.Click();
            sendMessage.SendKeys("Hi");
            sendButton.Click();
            Thread.Sleep(5 * 1000);
            Assert.IsFalse(HI.IsHiCardShow());
            HIPage.DeleteTrigger();

        }

        /// <summary>
        /// 5.	功能关闭后，在公众号里能否触发人工客服card
        /// </summary>
        [TestMethod]
        public void TriggerHiCardPerHITurnOFF()
        {

            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            Thread.Sleep(2 * 1000);
            //click settings
            HIPage.ClickSettings();
            Thread.Sleep(2 * 1000);

            if (HIPage.isOff()) { HIPage.TurnOn(); }
            Thread.Sleep(2 * 1000);

            #region 
            HIPage.InputTrigger("Hi");
            Thread.Sleep(5 * 1000);       
            #endregion

            if (HIPage.IsOn())
            {
                HIPage.TurnOff();
            }           
            Thread.Sleep(10 * 1000);

            //H5 Action
            var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
            contactlist.Click();
            Thread.Sleep(2 * 1000);

            var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
            officialaccount.Click();
            Thread.Sleep(2 * 1000);

            var bibilog = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
            bibilog.Click();
            Thread.Sleep(5 * 1000);

            HI.ClearAllRecord();
            var keyBoardSwich = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
            keyBoardSwich.Click();
            Thread.Sleep(5 * 1000);

            var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
            sendMessage.SendKeys("Hi");
            Thread.Sleep(5 * 1000);

            var sendButton = AndroidDriver.GetElmentByXpath(HIChatElement.SendButtonXpath);
            sendButton.Click();
            Thread.Sleep(10 * 1000);        
            Assert.IsFalse(XiaoIceH5.HI.IsHiCardShow());
        }

        /// <summary>
        /// 6.	点击人工客服card，是否可以进入H5对话窗
        /// </summary>
        [TestMethod]
        public void ClickHICard()
        {
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            Thread.Sleep(2 * 1000);
            //click settings
            HIPage.ClickSettings();
            Thread.Sleep(2 * 1000);

            if (HIPage.isOff()) { HIPage.TurnOn(); }
            Thread.Sleep(2 * 1000);

            //已经绑定一个人工客服 用一个公众号给客服发消息
            //H5 Action
            Thread.Sleep(5 * 1000);
            var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
            contactlist.Click();
            Thread.Sleep(2 * 1000);

            var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
            officialaccount.Click();
            Thread.Sleep(2 * 1000);

            var testAccount = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
            testAccount.Click();
            Thread.Sleep(5 * 1000);

            HI.ClearAllRecord();
            var keyBoardSwich = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
            keyBoardSwich.Click();
            Thread.Sleep(5 * 1000);

            var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
            sendMessage.SendKeys("客服");
            Thread.Sleep(5 * 1000);

            var sendButton = AndroidDriver.GetElmentByXpath(HIChatElement.SendButtonXpath);
            sendButton.Click();
            Thread.Sleep(10 * 1000);

            var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
            HICard.Click();
            Thread.Sleep(15 * 1000);

            Assert.IsTrue(HI.IsOfficialAccountNameShow());
        }

        /// <summary>
        /// 7.	在H5对话窗口,是否可以发送消息
        /// </summary>
        [TestMethod]
        public void SendMessageInHIWindow()
        {

            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            Thread.Sleep(2 * 1000);
            //click settings
            HIPage.ClickSettings();
            Thread.Sleep(2 * 1000);
            //Turn on HI
            if (HIPage.isOff()) { HIPage.TurnOn(); }
            Thread.Sleep(2 * 1000);

            //已经绑定一个人工客服 用一个公众号给客服发消息
            //H5 Action
            var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
            contactlist.Click();
            Thread.Sleep(2 * 1000);

            var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
            officialaccount.Click();
            Thread.Sleep(2 * 1000);

            var bibilog = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
            bibilog.Click();
            Thread.Sleep(5 * 1000);

            var keyBoardSwich = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
            keyBoardSwich.Click();
            Thread.Sleep(5 * 1000);

            var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
            sendMessage.SendKeys("客服");
            Thread.Sleep(5 * 1000);

            var sendButton = AndroidDriver.GetElmentByXpath(HIChatElement.SendButtonXpath);
            sendButton.Click();
            Thread.Sleep(10 * 1000);

            var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
            HICard.Click();
            Thread.Sleep(10 * 1000);

            var xb_inputbox = AndroidDriver.GetElmentByXpath(HIChatElement.xb_inputboxXpath);
            xb_inputbox.SendKeys("这里是测试账号");
            Thread.Sleep(5 * 1000);

            var xb_add_btn = AndroidDriver.GetElmentByXpath(HIChatElement.xb_add_btnXpath);
            xb_add_btn.Click();
            Thread.Sleep(5 * 1000);
            xb_add_btn.Click();
            Thread.Sleep(5 * 1000);

            var xb_addimg_image = AndroidDriver.GetElmentByXpath(HIChatElement.xb_addimg_image);
            xb_addimg_image.Click();
            Thread.Sleep(5 * 1000);

            var xiangji = AndroidDriver.GetElementByName("相机");
            xiangji.Click();
            Thread.Sleep(2 * 1000);

            var takePhoto = AndroidDriver.GetElmentByXpath(HIChatElement.takePhone);
            takePhoto.Click();
            Thread.Sleep(5* 1000);

            var sendImageConfirm = AndroidDriver.GetElmentByXpath(HIChatElement.SendImageConfirm);
            sendImageConfirm.Click();
            Thread.Sleep(5 * 1000);

            var xiangce= AndroidDriver.GetElementByName("文档");
            xiangce.Click();
            Thread.Sleep(2 * 1000);

            var documentSelect = AndroidDriver.GetElmentByXpath(HIChatElement.DocumentSelect);
            documentSelect.Click();
            Thread.Sleep(2 * 1000);
        }

        /// <summary>
        /// 9.	当用户不在H5对话窗口时，是否可以收到客服的回复
        /// </summary>
        [TestMethod]
        public void CheckReplyBackFromHI()
        {
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            Thread.Sleep(2 * 1000);
            //click settings
            HIPage.ClickSettings();
            Thread.Sleep(2 * 1000);
            //Turn on HI
            if (HIPage.isOff()) { HIPage.TurnOn(); }
            Thread.Sleep(2 * 1000);

            //已经绑定一个人工客服 用一个公众号给客服发消息
            //H5 Action
            var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
            contactlist.Click();
            Thread.Sleep(2 * 1000);

            var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
            officialaccount.Click();
            Thread.Sleep(2 * 1000);

            var bibilog = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
            bibilog.Click();
            Thread.Sleep(5 * 1000);

            var input = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
            input.Click();
            Thread.Sleep(5 * 1000);

            var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
            sendMessage.SendKeys("客服");
            Thread.Sleep(10 * 1000);

            var sendButton = AndroidDriver.GetElmentByXpath(HIChatElement.SendButtonXpath);
            sendButton.Click();
            Thread.Sleep(10 * 1000);

            var HICard = AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath);
            HICard.Click();
            Thread.Sleep(10 * 1000);

            var xb_inputbox = AndroidDriver.GetElmentByXpath(HIChatElement.xb_inputboxXpath);
            xb_inputbox.SendKeys("这里是测试账号");
            Thread.Sleep(5 * 1000);

            //退出当前对话窗口
            AndroidDriver.GetElmentByXpath(HIChatElement.backFromHI).Click();
            Thread.Sleep(10*1000);

            //Portal端客服回复
            HIPage.OpenHiChatWindow();
            Thread.Sleep(5* 1000);
            HIPage.GetTestUserFromUserList();
            Thread.Sleep(5 * 1000);            
            HIPage.SendMessage("这里是客服");

            //验证最后一条消息是不是客服回复的消息
            Assert.IsTrue(HI.IsReplyFromHI());
            Thread.Sleep(5 * 1000);
            AndroidDriver.GetElementByName(HIChatElement.ReplyCardFromHI).Click();
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(AndroidDriver.GetElmentByXpath("//android.view.View[contains(@content-desc,'这里是客服')]") != null);
        }

        /// <summary>
        /// 17.	客服是否可以回复用户的客服请求（需要另一个账号，暂时自己和自己聊）
        /// </summary>
        [TestMethod]
        public void RelyTo()
        {
            //客服已经公众号绑定
            //客服已经受到10条请求
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            Thread.Sleep(2 * 1000);
            //click settings
            HIPage.ClickSettings();
            Thread.Sleep(2 * 1000);
            //Turn on HI
            if (HIPage.isOff()) { HIPage.TurnOn(); }
            Thread.Sleep(2 * 1000);


            //已经绑定一个人工客服 用一个公众号给客服发消息
            //H5 Action
            var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
            contactlist.Click();
            Thread.Sleep(2 * 1000);

            var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
            officialaccount.Click();
            Thread.Sleep(2 * 1000);

            var bibilog = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
            bibilog.Click();
            Thread.Sleep(5 * 1000);

            AndroidDriver.GetElementByName(HIChatElement.HIMessageFromCustom).Click();

            var input = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
            input.Click();
            Thread.Sleep(5 * 1000);

            var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
            sendMessage.SendKeys("我是客服");
            Thread.Sleep(5 * 1000);

            var sendButton = AndroidDriver.GetElmentByXpath(HIChatElement.SendButtonXpath);
            sendButton.Click();
            Thread.Sleep(10 * 1000);

            var xb_addimg_image = AndroidDriver.GetElmentByXpath(HIChatElement.xb_addimg_image);
            xb_addimg_image.Click();
            Thread.Sleep(5 * 1000);

            var xiangji = AndroidDriver.GetElementByName("相机");
            xiangji.Click();
            Thread.Sleep(2 * 1000);

            var takePhoto = AndroidDriver.GetElmentByXpath(HIChatElement.takePhone);
            takePhoto.Click();
            Thread.Sleep(2 * 1000);

        }

        /// <summary>
        /// 18.	发送和接受的图片是否可以可以点击放大
        /// </summary>
        [TestMethod]
        public void MagnifyPictures()
        {
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            Thread.Sleep(2 * 1000);
            //click settings
            HIPage.ClickSettings();
            Thread.Sleep(2 * 1000);
            //Turn on HI
            if (HIPage.isOff()) { HIPage.TurnOn(); }
            Thread.Sleep(2 * 1000);


            //已经绑定一个人工客服 用一个公众号给客服发消息
            //H5 Action
            var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
            contactlist.Click();
            Thread.Sleep(2 * 1000);

            var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
            officialaccount.Click();
            Thread.Sleep(2 * 1000);

            var bibilog = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
            bibilog.Click();
            Thread.Sleep(5 * 1000);

            AndroidDriver.GetElementByName(HIChatElement.HIMessageFromCustom).Click();

            var input = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
            input.Click();
            Thread.Sleep(5 * 1000);

            var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
            sendMessage.SendKeys("我是客服");
            Thread.Sleep(5 * 1000);

            var sendButton = AndroidDriver.GetElmentByXpath(HIChatElement.SendButtonXpath);
            sendButton.Click();
            Thread.Sleep(10 * 1000);

            var xb_addimg_image = AndroidDriver.GetElmentByXpath(HIChatElement.xb_addimg_image);
            xb_addimg_image.Click();
            Thread.Sleep(5 * 1000);

            var xiangji = AndroidDriver.GetElementByName("相册");
            xiangji.Click();
            Thread.Sleep(2 * 1000);

         
        }


        [TestCleanup]
        public void AndroidCleanUp()
        {
            AndroidDriver.androidDriver.Close();
        }

    }
}

