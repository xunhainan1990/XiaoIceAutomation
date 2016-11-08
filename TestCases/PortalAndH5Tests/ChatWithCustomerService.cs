using Common;
using Common.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using CSH5;
using CSH5.UIElement;
using Portal.Pages;
using Portal.UIElement;


namespace TestCases.InactiveTests
{
    [TestClass]
    public class ChatWithHI : PortalTests.PortalTestInit
    {
        [TestInitialize]
        public void LunchWeChat()
        {
            MobileAndroidDriver.AndroidInitialize();
        }

        /// <summary>
        /// 27.	[客服人员设定]是否可以正常使用，当登陆密码有效期超过60s时
        /// </summary>
        [TestCategory("H5")]
        [TestMethod]
        public void CanStaffBindIfTimeOut()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            //切换到Hi的设置Tab页
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            //判断是否已经绑定客服，如果绑定，则删除客服
            HIPage.DeleteStaff();
            //获取绑定客服验证码
            var value=HIPage.GetLoginCode();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            //H5页面进入平台测试账号对话窗口     
            HIMobileH5.GetToTestAccount();
            //等待60秒,超过有效期
            Thread.Sleep(60*1000);
            //发送验证码
            HIMobileH5.SendMessage(value);
            Assert.IsFalse(HIMobileH5.IsStaffBind());
        }

        /// <summary>
        /// 28.	[客服人员设定]是否可以正常使用，当登陆密码过期后重新获取
        /// </summary>
        [TestMethod]
        public void RetainCodeIfTimeOut()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            //切换到Hi的设置Tab页
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            //判断是否已经绑定客服，如果绑定，则删除客服
            HIPage.DeleteStaff();
            //获取绑定客服验证码
            var value = HIPage.GetLoginCode();
            Thread.Sleep(26*1000);
            //H5页面进入平台测试账号对话窗口     
            HIMobileH5.GetToTestAccount();
            //删除聊天记录
            HIMobileH5.ClearAllRecord();
            value=HIPage.GetLoginCode();
            Thread.Sleep(2*1000);  
            //发送验证码
            HIMobileH5.SendMessage(value);
            Assert.IsTrue(HIMobileH5.IsStaffBind());
        }

        /// <summary>
        /// 29.	[客服人员设定]是否可以正常使用，当登陆密码有效期超过60s时(首次绑定)
        /// </summary>
        [TestMethod]
        public void CheckCodeAvailableIfTimeOut()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            //切换到Hi的设置Tab页
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            //判断是否已经绑定客服，如果绑定，则删除客服
            HIPage.DeleteStaff();
            //获取绑定客服验证码
            var value = HIPage.GetLoginCode();
            //H5页面进入平台测试账号对话窗口     
            HIMobileH5.GetToTestAccount();
            //删除聊天记录
            HIMobileH5.ClearAllRecord();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            //发送验证码
            HIMobileH5.SendMessage(value);
            //验证网页版是否成功绑定
            Assert.IsFalse(HIPage.IsStaffBindOnPortal());
            //验证Mobile是否有绑定成功提示
            Assert.IsFalse(HIMobileH5.IsStaffBind());
        }

        /// <summary>
        /// 42.	[对话窗口]用户消息列表中点击一条未读消息，小红点是否取消显示
        /// </summary>
        [TestMethod]
        public void Is_Small_New_Msg_Tip()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //召唤客服
            HIMobileH5.SendMessage("客服");
            //客服窗口发送消息
            HIMobileH5.XB_SendMessage("这里是测试账号");
            //小红点的判断
            HIPage.OpenHiChatWindow();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(30));
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

        /// <summary>
        /// 42.	[对话窗口]用户消息列表中点击一条未读消息，小红点是否取消显示
        /// </summary>
        [TestMethod]
        public void Is_Big_Msg_Tip_Show()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.OpenHiChatWindow();
            PortalChromeDriver.GetElementByName("xun").Click();
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //向公众号发送消息
            HIMobileH5.SendMessage("客服");
            //客服窗口发送消息
            HIMobileH5.XB_SendMessage("这里是测试账号");
            //打开Hi对话窗口
            
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
           
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
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //H5呼叫客服
            HIMobileH5.SendMessage("客服");
            //H5用户发送消息
            HIMobileH5.XB_SendMessage("这里是测试账号");

            //Portal客服打开Hi对话窗口     
            HIPage.OpenHiChatWindow();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            //点击测试账号
            HIPage.GetTestUserFromUserList();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            //客服发送消息
            HIPage.SendMessage("这里是客服");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            //验证Portal最后一条消息是不是客服回复的消息
            Assert.IsTrue(MobileAndroidDriver.GetElementByXpath("//android.view.View[contains(@content-desc,'这里是客服')]") != null);  
        }


        /// <summary>
        /// 44.	[对话窗口]是否可以在用户消息列表上次置顶显示，无论消息的状态是已读或未读，只要收到新的消息
        /// </summary>
        [TestMethod]
        public void NewMsgSecondTop_InHIWin()
        {  
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //H5呼叫客服
            HIMobileH5.SendMessage("客服");
            //H5用户发送消息
            HIMobileH5.XB_SendMessage("这里是测试账号");

            //Portal客服打开Hi对话窗口
            HIPage.OpenHiChatWindow();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
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
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            //Portal客服打开Hi对话窗口
            HIPage.OpenHiChatWindow();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //H5呼叫客服
            HIMobileH5.SendMessage("客服");  
            //H5用户发送消息
            HIMobileH5.XB_SendMessage("这里是测试账号");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

            //判断第二置顶的客户为发送消息的客户
            var userName = PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[1]/div[2]/div[1]/div[1]").Text;
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
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //H5呼叫客服
            HIMobileH5.SendMessage("客服");
            //H5用户发送消息
            HIMobileH5.XB_SendMessage("这里是测试账号");
            //
            Assert.IsTrue(HIPage.Is_Big_New_Msg_Tip());
        }

        /// <summary>
        /// 1-3
        /// 1.	功能开启后，在公众号里是否能触发人工客服card
        /// 2.	删除设置的关键词，是否还能触发人工客服card
        /// 3.	是否可以触发人工客服card，当输入含有找客服意向的语句
        /// </summary>
        [TestMethod] 
        public void TriggerHICardPerCustomize()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            #region 添加一条触发关键词
            HIPage.InputTrigger("hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            #endregion

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("hi");
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.xb_chatwith_texttest));
            HIPage.DeleteTrigger();
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsFalse(HIMobileH5.IsAt(HIMobileH5Element.xb_chatwith_texttest));
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("客服");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.xb_chatwith_texttest));
        }

        /// <summary>
        /// 4.	修改设置好的关键词后，能否正常触发人工客服card
        /// </summary>
        [TestMethod]
        public void TriggerHiCardAfterEditTriger()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();

            #region 修改设置好的关键词
            HIPage.InputTrigger("Hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            HIPage.EditTrigger("append");
            HIPage.ClickSomewhereToSave();
            #endregion

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("Hiappend");
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.xb_chatwith_texttest));
            HIMobileH5.ClearAllRecord();
            HIMobileH5.SendMessage("Hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            Assert.IsFalse(HIMobileH5.IsAt(HIMobileH5Element.xb_chatwith_texttest));
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.DeleteTrigger();
        }

        /// <summary>
        /// 5.	功能关闭后，在公众号里能否触发人工客服card
        /// </summary>
        [TestMethod]
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
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));

            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("Hi");

            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));        
            Assert.IsFalse(HIMobileH5.IsAt(HIMobileH5Element.xb_chatwith_texttest));
        }

        /// <summary>
        /// 6.	点击人工客服card，是否可以进入H5对话窗
        /// </summary>
        [TestMethod]
        public void ClickHICard()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //H5 Action
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //清空聊天记录
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("客服");
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.xb_chatwith_texttest));
        }

        /// <summary>
        /// 7.	在H5对话窗口,是否可以发送消息
        /// </summary>
        [TestMethod]
        public void SendMessageInHIWindow()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //H5 Action
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //清空聊天记录
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("客服");  
            HIMobileH5.XB_SendMessage("这里是测试账号");
            //目前的问题是取不到最新的消息
            HIPage.OpenHiChatWindow();
            Thread.Sleep(15*1000);
            Assert.IsTrue(HIPage.Can_ReceiveMesageFromMobile());
            HIMobileH5.XB_SendPhotoPerXiangJi();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            Assert.IsTrue(HIPage.Can_ReceiveImageFromMobile());

            //element not Clickable
            //HI.XB_SendPhotoPerXiangCe();
            //PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            //Assert.IsTrue(HIPage.Can_ReceiveImageFromMobile());
        }

        /// <summary>
        /// 9.	当用户不在H5对话窗口时，是否可以收到客服的回复
        /// </summary>
        [TestMethod]
        public void CheckReplyBackFromHI()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();

            //H5呼叫客服
            HIMobileH5.SendMessage("客服");
            HIMobileH5.XB_SendMessage("这里是测试账号");

            //退出当前对话窗口
            MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.backFromHI).Click();
            Thread.Sleep(10*1000);

            //Portal端客服回复
            HIPage.OpenHiChatWindow();
            Thread.Sleep(30* 1000);
            HIPage.GetTestUserFromUserList();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));            
            HIPage.SendMessage("这里是客服");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            //验证最后一条消息是不是客服回复的消息
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.ReplyCardFromHI));
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            MobileAndroidDriver.GetElementByName(HIMobileH5Element.ReplyCardFromHI).Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(15));
            Assert.IsTrue(MobileAndroidDriver.GetElementByXpath("//android.view.View[contains(@content-desc,'这里是客服')]") != null);
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

        /// <summary>
        /// 18.	发送和接受的图片是否可以可以点击放大
        /// </summary>
        [TestMethod]
        public void MagnifyPictures()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            HIPage.OpenHiChatWindow();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(15));
            HIPage.GetTestUserFromUserList();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.SendImage();
            HIPage.SendMessage("上边一条是图片");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            HIMobileH5.GetToTestAccount();
            MobileAndroidDriver.GetElementByName(HIMobileH5Element.ReplyCardFromHI).Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(15));
            HIMobileH5.GetImageMessage();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.ModifiedImage));
        }

        /// <summary>
        /// 20.	人工客服功能关闭，是否可以打开H5对话窗口
        /// </summary>
        [TestMethod]
        public void IsHICardAvailableAfterHITurnOff()
        {
            //Portal确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            //H5页面进入平台测试账号对话窗口   
            HIMobileH5.GetToTestAccount();
            //清空聊天记录
            HIMobileH5.ClearAllRecord();
            //H5呼叫客服
            HIMobileH5.SendMessage("客服");
            //关闭HI
            HIPage.TurnOff();
            //点击HICard
            var HICard = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.HiCardXpath);
            HICard.Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(30));
            Assert.IsTrue(HIMobileH5.IsAt(HIMobileH5Element.HIOffError));
            
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            MobileAndroidDriver.androidDriver.Dispose();
        }

    }
}

