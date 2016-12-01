using Common;
using Common.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using CSH5;
using CSH5.UIElement;
using Portal.Pages;
using Portal.UIElement;
using XiaoIcePortal.Pages;
using System.IO;

namespace TestCases.PortalAndH5Tests
{
    [TestClass]
    public class ChatWithCustomerService : PortalTests.PortalTestInit
    {
        
        [TestInitialize]
        public void LunchWeChat()
        {
            //if(MobileAndroidDriver.androidDriver==null)
            MobileAndroidDriver.AndroidInitialize();
        }

        [TestCategory("H5")]
        [TestMethod]
        [TestProperty("description", "10.[接入条件设置]是否可以添加一条与自定义回复的关键词相同的触发关键词")]
        public void Can_AddTrigger_InHI_ComeFirst()
        {
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI AutoReply Page
            WeChatManagermentPage.GoTo_AutoReply_Page();
            //AutoReplyPage.TurnOnAutoReply();\
            AutoReplyPage.AddReply("Hi");
            string foler=PortalChromeDriver.CreateFolder("10.[接入条件设置]是否可以添加一条与自定义回复的关键词相同的触发关键词");
            PortalChromeDriver.TakeScreenShot(foler, "Portal添加自动回复关键词");
            WeChatManagermentPage.GoToHIPage();
            HIPage.ClickSettings();
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHITrigger);
            HIPage.ClearTriggers();
            HIPage.InputTrigger("Hi");
            PortalChromeDriver.TakeScreenShot(foler, "Portal添加HITrigger");
            //Trigger Card In H5
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();          
            //H5呼叫客服      
            HIMobileH5.SendMessage("Hi");
            MobileAndroidDriver.GetScreenshot(foler,"H5验证HICard");
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.HiCardXpath),"HI触发关键词应该优先");

        }


        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "18.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词内容与自定义关键词回复相同的内容时")]
        public void Can_EditTriger_InHI_ComeFirst()
        {
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI AutoReply Page
            WeChatManagermentPage.GoTo_AutoReply_Page();
            //AutoReplyPage.TurnOnAutoReply();\
            AutoReplyPage.AddReply("Hi");
            string foler = PortalChromeDriver.CreateFolder("18.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词内容与自定义关键词回复相同的内容时");
            PortalChromeDriver.TakeScreenShot(foler,"添加自动回复关键词");
            WeChatManagermentPage.GoToHIPage();
            HIPage.ClickSettings();
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHITrigger);
            HIPage.ClearTriggers();
            HIPage.InputTrigger("Hello");
            HIPage.EditTrigger("Hi");
            PortalChromeDriver.TakeScreenShot(foler, "编辑HITrigger");
            //Trigger Card In H5
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //H5呼叫客服      
            HIMobileH5.SendMessage("Hi");
            MobileAndroidDriver.GetScreenshot(foler, "18.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词内容与自定义关键词回复相同的内容时");
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.HiCardXpath),"编辑已有触发关键词后，HI触发关键词应优先");

        }

        [TestCategory("H5")]
        [TestMethod]
        [TestProperty("description", "29.[客服人员设定]是否可以正常使用，当登陆密码有效期超过60s时")]
        public void Can_StaffBind_IfTimeOut()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //切换到Hi的设置Tab页
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            //判断是否已经绑定客服，如果绑定，则删除客服
            HIPage.DeleteStaff();
            //获取绑定客服验证码
            var value=HIPage.GetLoginCode();
            string foler = PortalChromeDriver.CreateFolder("29.[客服人员设定]是否可以正常使用，当登陆密码有效期超过60s时");
            
            //等待60秒,超过有效期
            Thread.Sleep(60 * 1000);
            //H5页面进入平台测试账号对话窗口     
            HIMobileH5.GetToTestAccount();

            //发送验证码
            HIMobileH5.SendMessage(value);
            MobileAndroidDriver.GetScreenshot(foler, "验证H5是否正确输入验证码");
            PortalChromeDriver.TakeScreenShot(foler,"验证Portal端客服是否绑定成功");
            Assert.IsFalse(HIMobileH5.IsStaffBind());
            
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "30.[客服人员设定]是否可以正常使用，当登陆密码过期后重新获取")]
        public void Staff_RetainCode_IfTimeOut()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //切换到Hi的设置Tab页
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            //判断是否已经绑定客服，如果绑定，则删除客服
            HIPage.DeleteStaff();
            //获取绑定客服验证码
            var value = HIPage.GetLoginCode();
            Thread.Sleep(60*1000);
            //H5页面进入平台测试账号对话窗口     
            HIMobileH5.GetToTestAccount();
            //删除聊天记录
            HIMobileH5.ClearAllRecord();
            value=HIPage.GetLoginCode();
            //发送验证码
            HIMobileH5.SendMessage(value);
            Thread.Sleep(5*1000);
            string foler = PortalChromeDriver.CreateFolder("30.[客服人员设定]是否可以正常使用，当登陆密码过期后重新获取");
            PortalChromeDriver.TakeScreenShot(foler,"验证登陆密码过期后重新获取是否正常绑定");
            Assert.IsTrue(HIMobileH5.IsStaffBind());            
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestCategory("CheckCodeAvailableIfTimeOut")]
        [TestProperty("description", "31.[客服人员设定]是否可以正常使用，当登陆密码有效期内(首次绑定)")]
        public void CheckCodeAvailableIfTimeOut()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //切换到Hi的设置Tab页
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            //判断是否已经绑定客服，如果绑定，则删除客服
            HIPage.DeleteStaff();
            //获取绑定客服验证码
            var value = HIPage.GetLoginCode();
            Thread.Sleep(60*1000);
            //H5页面进入平台测试账号对话窗口     
            HIMobileH5.GetToTestAccount();
            //删除聊天记录
            HIMobileH5.ClearAllRecord();
            //发送验证码
            HIMobileH5.SendMessage(value);
            //验证网页版是否成功绑定
            Assert.IsFalse(HIPage.IsStaffBindOnPortal());
            string foler = PortalChromeDriver.CreateFolder("31.[客服人员设定]是否可以正常使用，当登陆密码有效期内(首次绑定)");
           //验证Mobile是否有绑定成功提示
           PortalChromeDriver.TakeScreenShot(foler,"验证过期验证码是否能正常使用");
            Assert.IsFalse(HIMobileH5.IsStaffBind());
            
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "42.[对话窗口]用户消息列表中点击一条未读消息，小红点是否取消显示")]
        public void Is_Small_New_Msg_Tip()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.OpenHiChatWindow();
            Thread.Sleep(20*1000);
            HIPage.GetOtherUserFromUserList();
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //召唤客服
            HIMobileH5.GetHiCard("客服");
            //PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            //客服窗口发送消息
            HIMobileH5.XB_SendMessage("这里是测试账号");
            HIMobileH5.BackButtonClick();
            Thread.Sleep(5 * 1000);
            //小红点的判断
            string foler = PortalChromeDriver.CreateFolder("42.[对话窗口]用户消息列表中点击一条未读消息，小红点是否取消显示");
            PortalChromeDriver.TakeScreenShot(foler,"42.[对话窗口]用户消息列表中点击一条未读消息，小红点是否取消显示");
            Assert.IsTrue(HIPage.Is_Small_New_Msg_Tip());
           
        }

        /// <summary>
        /// 39.	[对话窗口]用户消息列表的时间是否可以正常使用回
        /// </summary>
        //[TestMethod]
        //public void CheckTimestamp()
        //{
        //    LoginPage.GoTo();
        //    HomePage.ClickWeChatApp();
        //    //Go to AI Page
        //    WeChatManagermentPage.GoToHIPage();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
        //    //click settings
        //    HIPage.ClickSettings();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
        //    //Turn on HI
        //    if (HIPage.isOff()) { HIPage.TurnOn(); }
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

        //    //H5 Action
        //    var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
        //    contactlist.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

        //    var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
        //    officialaccount.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

        //    var bibilog = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
        //    bibilog.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

        //    var input = AndroidDriver.GetElmentByXpath(HIMobileH5Element.KeyBoardSwichXpath);
        //    input.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

        //    var sendMessage = AndroidDriver.GetElmentByXpath(HIMobileH5Element.EditTextXpath);
        //    sendMessage.SendKeys("客服");
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

        //    var sendButton = AndroidDriver.GetElmentByXpath(HIMobileH5Element.SendButtonXpath);
        //    sendButton.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));

        //    var HICard = AndroidDriver.GetElmentByXpath(HIMobileH5Element.HiCardXpath);
        //    HICard.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));

        //    //var xb_inputbox = AndroidDriver.GetElmentByXpath(HIMobileH5Element.xb_inputboxXpath);
        //    var xb_inputbox = AndroidDriver.GetElementByClassName("android.widget.EditText");
        //    xb_inputbox.SendKeys("这里是测试账号");
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
        //    var xb_add_btn = AndroidDriver.GetElementByClassName("android.widget.Button");
        //    xb_add_btn.Click();
        //    xb_add_btn.Click();
        //    HIPage.OpenHiChatWindow();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

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
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
        //    //绑定一个人工客服
        //    HI.BindStaff();
        //    //H5页面进入平台测试账号对话窗口   
        //    HI.GetToTestAccount();
        //    //发送验证码
        //    HI.SendMessage("客服");
        //    //点击HICard
        //    var HICard = AndroidDriver.GetElmentByXpath(HIMobileH5Element.HiCardXpath);
        //    HICard.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));

        //    var xb_inputbox = AndroidDriver.GetElmentByXpath(HIMobileH5Element.xb_inputboxXpath);
        //    var xb_add_btn = AndroidDriver.GetElmentByXpath(HIMobileH5Element.xb_add_btnXpath);
        //    for (int i = 1; i <= 8; i++)
        //    {
        //        xb_inputbox.SendKeys("这里是测试账号" + i);
        //        PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
        //        xb_add_btn.Click();
        //        PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
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
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
        //    //click settings
        //    HIPage.ClickSettings();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
        //    //Turn on HI
        //    if (HIPage.isOff()) { HIPage.TurnOn(); }
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

        //    //H5 Action
        //    var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
        //    contactlist.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

        //    var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
        //    officialaccount.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

        //    var bibilog = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
        //    bibilog.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

        //    var input = AndroidDriver.GetElmentByXpath(HIMobileH5Element.KeyBoardSwichXpath);
        //    input.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

        //    var sendMessage = AndroidDriver.GetElmentByXpath(HIMobileH5Element.EditTextXpath);
        //    sendMessage.SendKeys("客服");
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

        //    var sendButton = AndroidDriver.GetElmentByXpath(HIMobileH5Element.SendButtonXpath);
        //    sendButton.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));

        //    var HICard = AndroidDriver.GetElmentByXpath(HIMobileH5Element.HiCardXpath);
        //    HICard.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));

        //    var xb_inputbox = AndroidDriver.GetElmentByXpath(HIMobileH5Element.xb_inputboxXpath);
        //    var xb_add_btn = AndroidDriver.GetElmentByXpath(HIMobileH5Element.xb_add_btnXpath);
        //    xb_inputbox.SendKeys("这里是超长字符测试这里是超长字符测试这里是超长字符测试");
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
        //    xb_add_btn.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

        //    HIPage.OpenHiChatWindow();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

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


        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "59.[对话窗口]是否有新消息提示标识显示，当开启人工客服后有消息接入;61.	是否可以显示大红点，当不在人工对话栏并有新消息接入时")]
        public void Is_Big_MsgTip_ShowUp()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //H5呼叫客服
            HIMobileH5.GetHiCard("客服");
            //H5用户发送消息 
            HIMobileH5.XB_SendMessage("这里是测试账号");
            HIMobileH5.XB_SendMessage("这里是测试账号");
            string foler = PortalChromeDriver.CreateFolder("59.[对话窗口]是否有新消息提示标识显示，当开启人工客服后有消息接入_客户H5发送消息");
            MobileAndroidDriver.GetScreenshot(foler,"客户H5发送消息");
            HIMobileH5.BackButtonClick();
            Thread.Sleep(5 * 1000);
            PortalChromeDriver.TakeScreenShot(foler,"59.[对话窗口]是否有新消息提示标识显示，当开启人工客服后有消息接入;61.是否可以显示大红点，当不在人工对话栏并有新消息接入时");
            Assert.IsTrue(HIPage.Is_Big_New_Msg_Tip());
            //点击人工客服之后 大红点消失
            HIPage.HiChatPoartal();
            Assert.IsFalse(HIPage.Is_Big_New_Msg_Tip());           
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "62.是否可以显示大红点，当停留在'对话窗口'页面")]
        public void Is_Big_MsgTip_Show_InHiWin()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.HiChatPoartal();

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //H5呼叫客服
            HIMobileH5.GetHiCard("客服");
            //H5用户发送消息
            HIMobileH5.XB_SendMessage("这里是测试账号");
            string foler = PortalChromeDriver.CreateFolder("62.是否可以显示大红点，当停留在'对话窗口'页面");
          MobileAndroidDriver.GetScreenshot(foler,"客户H5发消息");
            HIMobileH5.BackButtonClick();
            PortalChromeDriver.TakeScreenShot(foler,"62.是否可以显示大红点，当停留在'对话窗口'页面");
            Assert.IsFalse(HIPage.Is_Big_New_Msg_Tip());
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "43.客服是否可以正常回复收到的用户消息")]
        public void Can_Staff_CheckReply_FromCustomer()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //H5呼叫客服
            HIMobileH5.GetHiCard("客服");
            //H5用户发送消息
            HIMobileH5.XB_SendMessage("这里是测试账号");

            //Portal客服打开Hi对话窗口     
            HIPage.OpenHiChatWindow();
            //点击测试账号
            HIPage.GetTestUserFromUserList();
            //客服发送消息
            HIPage.SendMessage("这里是客服");
            //验证Portal最后一条消息是不是客服回复的消息
            string foler = PortalChromeDriver.CreateFolder("43.客服是否可以正常回复收到的用户消息");
            PortalChromeDriver.TakeScreenShot(foler,"Portal");
            MobileAndroidDriver.GetScreenshot(foler,"H5");
            Assert.IsTrue(HIMobileH5.IsAtPerXpath(string.Format(HIMobileH5Element.ReplyFromHi, "这里是客服")));
            HIMobileH5.ClickReplyCard();         
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "44.[对话窗口]是否可以在用户消息列表上次置顶显示，无论消息的状态是已读或未读，只要收到新的消息")]
        public void Is_NewMsg_TopShow_InHIWin()
        {  
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //Portal客服打开Hi对话窗口
            HIPage.OpenHiChatWindow();
            HIPage.GetOtherUserFromUserList();
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //H5呼叫客服
            HIMobileH5.GetHiCard("客服");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            //H5用户发送消息
            HIMobileH5.XB_SendMessage("这里是测试账号");
            HIMobileH5.BackButtonClick();
            Thread.Sleep(5*1000);
            string foler = PortalChromeDriver.CreateFolder("44.[对话窗口]是否可以在用户消息列表上次置顶显示，无论消息的状态是已读或未读，只要收到新的消息");
            PortalChromeDriver.TakeScreenShot(foler,"Portal");
            Assert.IsTrue(HIPage.CheckTheTopUser());        
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "H5.1.功能开启后，在公众号里是否能触发人工客服card;H5.2.删除设置的关键词，是否还能触发人工客服card;H5.3.是否可以触发人工客服card，当输入含有找客服意向的语句")]
        public void TriggerHICardPerCustomize()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            #region 添加一条触发关键词
            HIPage.ClearTriggers();
            HIPage.InputTrigger("hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            #endregion

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            
            HIMobileH5.SendMessage("hi");
            Thread.Sleep(5 * 1000);
            string foler = PortalChromeDriver.CreateFolder("H5.1.功能开启后，在公众号里是否能触发人工客服card");
           MobileAndroidDriver.GetScreenshot(foler,"H5");
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.HiCardXpath));

            HIPage.ClearTriggers();
            HIMobileH5.ClearAllRecord();

            Thread.Sleep(5*1000);
            //H5呼叫客服
            HIMobileH5.SendMessage("hi");
            Thread.Sleep(5*1000);
            MobileAndroidDriver.GetScreenshot(foler,"H5.2.删除设置的关键词，是否还能触发人工客服card");
            Assert.IsFalse(HIMobileH5.IsAt(HIMobileH5Element.HiCardXpath));
           
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("客服");
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(foler,"H5.3.是否可以触发人工客服card，当输入含有找客服意向的语句");
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.HiCardXpath));           
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "4.修改设置好的关键词后，能否正常触发人工客服card")]
        public void TriggerHiCardAfterEditTriger()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();

            #region 修改设置好的关键词
            HIPage.InputTrigger("Hi");
            HIPage.EditTrigger("append");
            HIPage.ClickSomewhereToSave();
            #endregion

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("Hiappend");
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.HiCardXpath));

            HIMobileH5.ClearAllRecord();
            Thread.Sleep(5*1000);
            HIMobileH5.SendMessage("Hi");
            Thread.Sleep(5 * 1000);
            string foler = PortalChromeDriver.CreateFolder("H5.4.修改设置好的关键词后，能否正常触发人工客服card");
            MobileAndroidDriver.GetScreenshot(foler,"H5");
            Assert.IsFalse(HIMobileH5.IsAt(HIMobileH5Element.HiCardXpath));          
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "5.功能关闭后，在公众号里能否触发人工客服card")]
        public void TriggerHiCardPerHITurnOFF()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();

            #region 
            HIPage.InputTrigger("Hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));       
            #endregion

            if (HIPage.IsOn())
            {
                HIPage.TurnOff();
            }           

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("Hi");
            string foler = PortalChromeDriver.CreateFolder("H5.5.功能关闭后，在公众号里能否触发人工客服card");
            MobileAndroidDriver.GetScreenshot(foler,"H5");
            Assert.IsFalse(HIMobileH5.IsAt(HIMobileH5Element.xb_chatwith_texttest));
            
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "6.点击人工客服card，是否可以进入H5对话窗")]
        public void ClickHICard()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //清空聊天记录
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            string foler = PortalChromeDriver.CreateFolder("H5.6.点击人工客服card，是否可以进入H5对话窗");
            MobileAndroidDriver.GetScreenshot(foler,"H5");
            HIMobileH5.GetHiCard("客服");
            Assert.IsTrue(HIMobileH5.IsAtPerXpath(HIMobileH5Element.xb_chatwith_texttest));
            HIMobileH5.BackButtonClick();
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "7.在H5对话窗口,是否可以发送消息")]
        public void SendMessageInH5()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //H5 Action
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //清空聊天记录
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.GetHiCard("客服");  
            HIMobileH5.XB_SendMessage("这里是测试账号");
            //目前的问题是取不到最新的消息
            HIPage.OpenHiChatWindow();
            string foler = PortalChromeDriver.CreateFolder("H5.7.在H5对话窗口, 是否可以发送消息");
            MobileAndroidDriver.GetScreenshot(foler,"H5发送消息");
            Assert.IsTrue(HIPage.Can_ReceiveMesageFromMobile());
           
            HIMobileH5.XB_SendPhotoPerXiangJi();
            MobileAndroidDriver.GetScreenshot(foler,"H5发送图片图片");
            Assert.IsTrue(HIPage.Can_ReceiveImageFromMobile());
            HIMobileH5.BackButtonClick();

            
            //element not Clickable
            //HI.XB_SendPhotoPerXiangCe();
            //PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            //Assert.IsTrue(HIPage.Can_ReceiveImageFromMobile());
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "10.是否可以收到一条新的客服回复的card，当用户没有退出当前H5对话窗口时;9.用户在H5对话窗口时，是否可以收到客服回复的消息;21.发送和接受的图片是否可以可以点击放大")]
        public void SendMessageInPortal()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.OpenHiChatWindow();
            HIPage.GetTestUserFromUserList();

            HIMobileH5.GetToTestAccount();
            HIMobileH5.GetHiCard("客服");
            HIMobileH5.XB_SendMessage("我是客户");
            Thread.Sleep(2 * 1000);
            HIPage.SendMessage("我是客服");
            //发送消息
            string foler = PortalChromeDriver.CreateFolder("H5.9.用户在H5对话窗口时，是否可以收到客服回复的消息");
            MobileAndroidDriver.GetScreenshot(foler,"H5");
            Assert.IsTrue(HIMobileH5.GetMessage("我是客服"));

            //验证在未退出当前窗口时，是否会收到客服回复的card
            string foler10 = PortalChromeDriver.CreateFolder("H5.10.是否可以收到一条新的客服回复的card,当用户没有退出当前H5对话窗口时");
            MobileAndroidDriver.GetScreenshot(foler,"H5");
            Assert.IsFalse(HIMobileH5.IsAt(HIMobileH5Element.ReplyCardFromHI));
            //发送图片
            HIPage.SendImage();
            HIMobileH5.ClickReplyCard();
            HIMobileH5.GetImageMessage(false);
            string foler21 = PortalChromeDriver.CreateFolder("H5.21.发送和接受的图片是否可以可以点击放大");
            MobileAndroidDriver.GetScreenshot(foler21,"H5");
            Assert.IsTrue(HIMobileH5.GetMagnifyImage());
            HIMobileH5.BackButtonClick();
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "11.当用户不在H5对话窗口时，是否可以收到客服的回复")]
        public void CheckReplyBackFromHI()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //Thread.Sleep(5*1000);
            //H5呼叫客服
            HIMobileH5.GetHiCard("客服");
            HIMobileH5.XB_SendMessage("这里是测试账号");

            //退出当前对话窗口
            HIMobileH5.BackButtonClick();
           
            //Portal端客服回复
            HIPage.OpenHiChatWindow(); 
            HIPage.GetTestUserFromUserList();
            Thread.Sleep(90* 1000);
            HIMobileH5.SendMessage("a");
            Thread.Sleep(10 * 1000); ;
            HIPage.SendMessage("这里是客服");
            Thread.Sleep(2 * 1000);
            //验证最后一条消息是不是客服回复的消息
            string foler = PortalChromeDriver.CreateFolder("H5.11.当用户不在H5对话窗口时, 是否可以收到客服的回复");
            MobileAndroidDriver.GetScreenshot(foler,"H5");
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.ReplyCardFromHI));           
            HIMobileH5.ClickReplyCard();
            Assert.IsTrue(HIMobileH5.IsAtPerXpath(string.Format(HIMobileH5Element.ReplyFromHi, "这里是客服")));
            HIMobileH5.BackButtonClick();
        }

       
        [TestCategory("H5")]
        [TestProperty("description", "12.对话窗口是否可以分享 和发送给朋友")]
        [TestMethod]
        public void Can_ShareWin_ToFriend()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //H5呼叫客服
            HIMobileH5.GetHiCard("客服");
            string foler = PortalChromeDriver.CreateFolder("H5.12.对话窗口是否可以分享 和发送给朋友");
            MobileAndroidDriver.GetScreenshot(foler,"H5");
            Assert.IsTrue(HIMobileH5.GetMoreItmes());
            HIMobileH5.BackButtonClick();
        }
        /// <summary>
        /// 17.	客服是否可以回复用户的客服请求（需要另一个账号，暂时自己和自己聊）
        /// </summary>
        //[TestMethod]
        //public void RelyTo()
        //{
        //    //Portal确保HI是Turn on的状态
        //    HIPage.TurnOnSetup();
        //    //绑定客服
        //    HI.BindStaff();
        //    //H5页面进入平台测试账号对话窗口   
        //    HI.GetToTestAccount();
        //    //H5呼叫客服
        //    HI.SendMessage("客服");
        //    //点击HICard
        //    var HICard = AndroidDriver.GetElmentByXpath(HIMobileH5Element.HiCardXpath);
        //    HICard.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(15));
        //    HI.XB_SendMessage("这里是测试账号");


        //    AndroidDriver.GetElementByName(HIMobileH5Element.HIMessageFromCustom).Click();


        //    HI.XB_SendPhotoPerXiangJi();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
        //    Assert.IsTrue(HIPage.Can_ReceiveImageFromMobile());
        //}

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "23.人工客服功能关闭，是否可以打开H5对话窗口")]
        public void IsHICardAvailableAfterHITurnOff()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //清空聊天记录
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("客服");
            //关闭HI
            HIPage.TurnOff();
            HIMobileH5.ClickHICard();
            string foler = PortalChromeDriver.CreateFolder("H5.23.人工客服功能关闭，是否可以打开H5对话窗口");
            MobileAndroidDriver.GetScreenshot(foler,"H5");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(HIMobileH5Element.HIOffError));
            Assert.IsFalse(HIMobileH5.IsAt(HIMobileH5Element.HiCardXpath));
            HIMobileH5.BackButtonClick();
        }

        [TestMethod]
        [TestCategory("H5")]
        [TestProperty("description", "30.按home键后，是否还能进入继续聊天(不停用微信进程)")]
        public void Can_Continue_Chat_PressHome()
        {           
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            ////H5呼叫客服
            HIMobileH5.GetHiCard("客服");
            HIMobileH5.XB_SendMessage("我是客户测试账号");
            Thread.Sleep(2*1000);
            HIMobileH5.BackButtonClick();
            Thread.Sleep(2 * 1000);
            HIMobileH5.BackToHome();
            HIPage.OpenHiChatWindow();
            HIPage.SendMessage("这里是客服");
            Thread.Sleep(10*1000);
            HIMobileH5.OpenWeChatFromHome();
            HIMobileH5.ClickReplyCard();
            Thread.Sleep(2*1000);
            string foler = PortalChromeDriver.CreateFolder("H5.30.按home键后，是否还能进入继续聊天(不停用微信进程)");
            MobileAndroidDriver.GetScreenshot(foler,"H5)");
            Assert.IsTrue(HIMobileH5.GetMessage("这里是客服"));
            HIMobileH5.BackButtonClick();
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            MobileAndroidDriver.androidDriver.Dispose();
        }

    }
}

