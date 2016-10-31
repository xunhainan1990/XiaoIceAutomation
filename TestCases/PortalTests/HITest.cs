using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using XiaoIcePortal.Pages;
using System.Linq;
using XiaoIcePortal.UIElement;
using AutoItX3Lib;
using XiaoIcePortal.Driver;

namespace TestCases.PortalTests
{
    [TestClass]
    public class HITest : PortalTestInit
    {
        /// <summary>
        /// 1.	是否能够成功切换到人工客服功能的“设置” 界面
        /// </summary>
        [TestMethod]
        public void CanClickSetting()
        {
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            Thread.Sleep(2 * 1000);
            //Click settings
            HIPage.ClickSettings();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.IsSetting());
            PortalChromeDriver.TakeScreenShot(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 2.	是否可以正常开启“人工客服”功能
        /// </summary>
        [TestMethod]
        public void CanTurnOnHI_Test()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Assert.IsTrue(HIPage.IsOn());
            PortalChromeDriver.TakeScreenShot(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        //51. 是否可以停用"人工客服"功能
        [TestMethod]
        public void CanTurnOffHI_Test()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.TurnOff();
            Thread.Sleep(10 * 1000);
            Assert.IsTrue(HIPage.isOff());
            PortalChromeDriver.TakeScreenShot(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 3-10,19	[接入条件设置]是否可以添加触发关键词
        /// </summary>
        [TestMethod]
        public void CanAddTrigger()
        { 
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);

            #region 3.	[接入条件设置]是否可以添加一条触发关键词
            HIPage.InputTrigger("hi");
            Thread.Sleep(2* 1000);
            Assert.IsTrue(HIPage.iskeywordAdded("hi"));
            PortalChromeDriver.TakeScreenShot("3.[接入条件设置]是否可以添加一条触发关键词");
            //check if has edit button
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(HIPage.HasEditButton());
            //check if has delete button
            Assert.IsTrue(HIPage.HasDeleteButton());
            HIPage.DeleteTrigger();
            #endregion

            #region 4.	[接入条件设置]是否可以添加一条为空的触发关键词
            HIPage.InputTrigger("");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot("4.[接入条件设置]是否可以添加一条为空的触发关键词");      
            PortalChromeDriver.Refresh();
            Assert.IsFalse(HIPage.iskeywordAdded(""));
            //check if has edit button
            Assert.IsFalse(HIPage.HasEditButton());
            //check if has delete button
            Assert.IsFalse(HIPage.HasDeleteButton());
            if (HIPage.HasDeleteButton())
                HIPage.DeleteTrigger();
            #endregion

            #region 5.	[接入条件设置]是否可以添加一条触发关键词，当输入空格时
            HIPage.InputTrigger(" ");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot("5.[接入条件设置]是否可以添加一条触发关键词，当输入空格时");
            Assert.IsFalse(HIPage.iskeywordAdded(" "), "keyword added");
            //check if has edit button
            Assert.IsFalse(HIPage.HasEditButton(), "has edit button");
            //check if has delete button
            Assert.IsFalse(HIPage.HasDeleteButton(), "has delete button");
            if (HIPage.HasDeleteButton())
                HIPage.DeleteTrigger();
            #endregion

            #region 6.	[接入条件设置]是否可以添加一条触发关键词，当输入html标签时
            HIPage.InputTrigger("<div class='body'>");
            Thread.Sleep(2* 1000);
            PortalChromeDriver.TakeScreenShot("6.[接入条件设置]是否可以添加一条触发关键词，当输入html标签时");
            Assert.IsTrue(HIPage.iskeywordAdded("<div class='body'>"));
            //check if has edit button
            Assert.IsTrue(HIPage.HasEditButton());
            //check if has delete button
            Assert.IsTrue(HIPage.HasDeleteButton());
            if (HIPage.HasDeleteButton())
                HIPage.DeleteTrigger();
            #endregion

            #region 7.	[接入条件设置]是否可以添加一条超过20个字的触发关键词
            HIPage.InputTrigger("012345678901234567890");
            Thread.Sleep(2 * 1000);
            Assert.IsFalse(HIPage.iskeywordAdded("012345678901234567890"), "keyword added");
            PortalChromeDriver.TakeScreenShot("7.[接入条件设置]是否可以添加一条超过20个字的触发关键词");
            Thread.Sleep(2 * 1000);
            if (HIPage.HasDeleteButton())
                HIPage.DeleteTrigger();
            #endregion

            #region 8.	[接入条件设置]是否可以添加一条重复的触发关键词
            HIPage.InputTrigger("hi");
            Thread.Sleep(2 * 1000);           
            Thread.Sleep(5*1000);
            Assert.IsTrue(HIPage.iskeywordAdded("hi"), "keyword added");
            HIPage.InputTrigger("hi");
            Assert.IsFalse(HIPage.isTheSameKeywordAdded("hi"), "keyword added");
            PortalChromeDriver.TakeScreenShot("8.[接入条件设置]是否可以添加一条重复的触发关键词");
            if (HIPage.HasDeleteButton())
                HIPage.DeleteTrigger();
            #endregion

            #region 9.	[接入条件设置]是否可以添加一条包含非法词语的触发关键词
            HIPage.InputTrigger("赌博");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot("9.[接入条件设置]是否可以添加一条包含非法词语的触发关键词");
            Thread.Sleep(2* 1000);
            Assert.IsTrue(HIPage.HasAlert_Failure());
            HIPage.ClickModifyButton();
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.Refresh();
            Thread.Sleep(2 * 1000);
            //check if has edit button
            Assert.IsFalse(HIPage.HasEditButton(), "Has Edit Button");
            //check if has delete button
            Assert.IsFalse(HIPage.HasDeleteButton(), "Has Delete Button");
            if (HIPage.HasDeleteButton())
                HIPage.DeleteTrigger();
            #endregion
        }

        /// <summary>
        /// 11-17	[接入条件设置]是否可以编辑已有的触发关键词
        /// </summary>
        [TestMethod]
        public void CanEditTrigger()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);

            #region 11.	[接入条件设置]是否可以编辑已有的触发关键词
            HIPage.InputTrigger("Hi");
            Thread.Sleep(2 * 1000);
            HIPage.EditTrigger("append");
            HIPage.ClickSomewhereToSave();
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(HIPage.iskeywordAdded("Hiappend"), "Keyword Added");
            HIPage.DeleteTrigger();
            Thread.Sleep(5 * 1000);
            #endregion

            # region 12. [接入条件设置]是否可以正常保存，当编辑已有的触发关键词删除所有内容
            HIPage.InputTrigger("Hi");
            Thread.Sleep(2 * 1000);
            HIPage.DeleteTriggerByEditButton();
            HIPage.ClickSomewhereToSave();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.iskeywordAdded("Hi"), "Keyword Added");
            HIPage.DeleteTrigger();
            Thread.Sleep(5 * 1000);
            #endregion

            #region 13.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词输入空格
            HIPage.InputTrigger("Hi");
            Thread.Sleep(5* 1000);
            HIPage.ReplaceTrigger(" ");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.Refresh();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.iskeywordAdded("Hi"), "Keyword Added");
            HIPage.DeleteTrigger();
            PortalChromeDriver.Refresh();
            Thread.Sleep(5 * 1000);
            #endregion

            #region 14.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词输入html标签时
            HIPage.InputTrigger("Hi");
            Thread.Sleep(5 * 1000);
            PortalChromeDriver.Refresh();
            Thread.Sleep(5 * 1000);
            HIPage.ReplaceTrigger("<div class='body'>");
            HIPage.ClickSomewhereToSave();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.iskeywordAdded("<div class='body'>"), "Keyword Added");
            HIPage.DeleteTrigger();
            #endregion

            #region 15.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词超过20个字
            HIPage.InputTrigger("Hi");
            Thread.Sleep(2 * 1000);
            HIPage.ReplaceTrigger("012345678901234567890");
            HIPage.ClickSomewhereToSave();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.iskeywordAdded("01234567890123456789"), "Keyword Added");
            HIPage.DeleteTrigger();
            #endregion

            #region 16.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词跟其他的触发关键词重复时
            HIPage.InputTrigger("Hi");
            Thread.Sleep(2 * 1000);
            HIPage.InputTrigger("Hello");
            Thread.Sleep(2 * 1000);
            HIPage.ReplaceTrigger("Hi");
            HIPage.ClickSomewhereToSave();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.iskeywordAdded("Hello"), "Keyword Added");
            HIPage.DeleteTrigger();
            #endregion

            #region 17.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词包含非法词语
            HIPage.InputTrigger("Hi");
            Thread.Sleep(2 * 1000);
            HIPage.ReplaceTrigger("赌博");
            HIPage.ClickSomewhereToSave();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.iskeywordAdded("Hi"), "Keyword Added");
            HIPage.DeleteTrigger();
            #endregion  
        }

        /// <summary>
        /// 19.	[接入条件设置]是否可以添加5条触发关键词
        /// 20.	[接入条件设置]是否可以成功删除一条触发关键词
        /// 21.	[接入条件设置]是否可以成功删除5条触发关键词
        /// 22.	[接入条件设置]是否可以成功删除再添加触发关键词
        /// 23.	[接入条件设置]是否保存状态，当输入触发关键词后不点添加，切换到“客服人员设定”tab
        /// </summary>
        [TestMethod]
        public void CanDeleteTrigger()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);

            #region 20.	[接入条件设置]是否可以成功删除一条触发关键词
            HIPage.InputTrigger("Hi");
            Thread.Sleep(5 * 1000);
            HIPage.DeleteTrigger();
            Thread.Sleep(2 * 1000);
            Assert.IsFalse(HIPage.iskeywordAdded("Hi"), "Keyword Delete");
            #endregion

            #region 19, 21.  [接入条件设置]是否可以成功删除5条触发关键词          
            HIPage.InputTrigger("Hi1");
            Thread.Sleep(2 * 1000);
            HIPage.InputTrigger("Hi2");
            Thread.Sleep(2 * 1000);
            HIPage.InputTrigger("Hi3");
            Thread.Sleep(2 * 1000);
            HIPage.InputTrigger("Hi4");
            Thread.Sleep(2 * 1000);
            HIPage.InputTrigger("Hi5");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.AddedFiveTrigger("最多添加5条"), "Added 5 Keyword");
            HIPage.DeleteTrigger();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.AddedFiveTrigger("输入关键词，最多20个字"));
            HIPage.DeleteTrigger();
            Thread.Sleep(2 * 1000);
            HIPage.DeleteTrigger();
            Thread.Sleep(2 * 1000);
            HIPage.DeleteTrigger();
            Thread.Sleep(5 * 1000);
            HIPage.DeleteTrigger();
            Thread.Sleep(5*1000);
            Assert.IsFalse(HIPage.iskeywordAdded("Hi1"), "Delete trigger");

            #endregion

            #region 22.	[接入条件设置]是否可以成功删除再添加触发关键词
            PortalChromeDriver.Refresh();
            HIPage.InputTrigger("Hi1");
            Thread.Sleep(5* 1000);
            HIPage.InputTrigger("Hi2");
            Thread.Sleep(2 * 1000);
            HIPage.InputTrigger("Hi3");
            Thread.Sleep(2 * 1000);
            HIPage.InputTrigger("Hi4");
            Thread.Sleep(2 * 1000);
            HIPage.InputTrigger("Hi5");
            Thread.Sleep(2 * 1000);
            HIPage.DeleteTrigger();
            Thread.Sleep(2 * 1000);
            Assert.IsFalse(HIPage.iskeywordAdded("Hi5"), "Keyword Delete");
            HIPage.DeleteTrigger();
            Thread.Sleep(2 * 1000);
            Assert.IsFalse(HIPage.iskeywordAdded("Hi4"), "Keyword Delete");
            HIPage.InputTrigger("Hi6");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.iskeywordAdded("Hi6"), "Keyword add");
            HIPage.InputTrigger("Hi7");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.iskeywordAdded("Hi7"), "Keyword add");
            Assert.IsTrue(HIPage.AddedFiveTrigger("最多添加5条"), "Added 5 Keyword");
            HIPage.DeleteTrigger();
            Thread.Sleep(2 * 1000);
            HIPage.DeleteTrigger();
            Thread.Sleep(2 * 1000);
            HIPage.DeleteTrigger();
            Thread.Sleep(2 * 1000);
            HIPage.DeleteTrigger();
            Thread.Sleep(2 * 1000);
            HIPage.DeleteTrigger();
            Thread.Sleep(2 * 1000);
            Assert.IsFalse(HIPage.iskeywordAdded("Hi"), "Keyword Delete");
            #endregion

            #region 23.	[接入条件设置]是否保存状态，当输入触发关键词后不点添加，切换到“客服人员设
            HIPage.InputTriggerWithoutSave("Hi");
            Thread.Sleep(2 * 1000);
            HIPage.SwichHISettingTab(HIPageUIElement.SubTabHIStaff);
            Thread.Sleep(5* 1000);
            HIPage.SwichHISettingTab(HIPageUIElement.SubTabHITrigger);
            Assert.IsFalse(HIPage.iskeywordAdded("Hi"), "Keyword Delete");
            #endregion
        }

        /// <summary>
        /// 24.	[客服人员设定]是否提示非认证的公众号无法使用该功能
        /// </summary>
        [TestMethod]
        public void CanNon_certifiedGoToHiChat()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            HIPage.SwichHISettingTab(HIPageUIElement.SubTabHIStaff);

            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.IsNotVerified(), "Failed to open HiChat");
        }

        /// <summary>
        /// 25.	[客服人员设定]是否认证的公众号可以使用该功能(尚未获取密码）
        /// 26.	[客服人员设定]是否可以获取登陆密码
        /// </summary>
        [TestMethod]
        public void CanCertifiedGoToHiStaff()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            HIPage.SwichHISettingTab(HIPageUIElement.SubTabHIStaff);
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(HIPage.IsVerified());
        }

        /// <summary>
        /// 26.	[客服人员设定]是否可以获取登陆密码
        /// </summary>
        [TestMethod]
        public void CanGetLoginCode()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            HIPage.SwichHISettingTab(HIPageUIElement.SubTabHIStaff);
            Thread.Sleep(10 * 1000);
            HIPage.GetLoginCode();
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(HIPage.IsSendLoginCode());
            var value = PortalChromeDriver.GetElementByXpath(HIPageUIElement.LoginCodeText).GetAttribute("value");
            Assert.IsTrue(HIPage.IsLoginCodeTextDisable());
        }

        /// <summary>
        /// 32.	[客服人员设定]是否可以移除绑定的客服人员
        /// </summary>
        [TestMethod]
        public void CanHiChatDeleteStaff()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);

            HIPage.SwichHISettingTab(HIPageUIElement.SubTabHIStaff);
            HIPage.DeleteStaff();
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(HIPage.IsVerified());
        }

        /// <summary>
        /// 45.	[对话窗口]聊天对话窗是否可以发送不同格式的图片（JPG，PNG，BMP和GIF）
        /// </summary>
        [TestMethod]
        public void DiffPhotos()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            HIPage.OpenHiChatWindow();
            Thread.Sleep(10 * 1000);

            HIPage.GetTestUserFromUserList();
            PortalChromeDriver.GetElementByXpath(HIPageUIElement.addimg_hidden_input).Click();        
            AutoItX3 au3 = new AutoItX3();
            au3.ControlFocus("Open","", "Edit1");
            Thread.Sleep(2*1000);
            au3.ControlSetText("Open", "", "Edit1", "Test.png");
            Thread.Sleep(2 * 1000);
            au3.ControlClick("Open", "", "Button1");
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(HIPage.CanSendVarousPhotos());          

        }

        /// <summary>
        /// 46.	[对话窗口]聊天对话窗是否可以输入超过300个字
        /// </summary>
        [TestMethod]
        public void MsgBoxInputLength()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            HIPage.OpenHiChatWindow();
            Thread.Sleep(10* 1000);
            HIPage.GetTestUserFromUserList();
            Thread.Sleep(10 * 1000);
            PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgInputBox).SendKeys("0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123");
            Thread.Sleep(10* 1000);
            var save = PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgSendBtn);
                save.Click();
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(HIPage.IsLengthWithin300());
        }

        /// <summary>
        /// 48.	[对话窗口]聊天对话窗是否保存聊天历史记录（1）
        /// </summary>
        [TestMethod]
        public void IsMsgHistory()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            HIPage.OpenHiChatWindow();
            Thread.Sleep(2 * 1000);
            HIPage.GetTestUserFromUserList();
            var inputBox= PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgInputBox);
            inputBox.SendKeys("1");
            Thread.Sleep(10 * 1000);
            var sendButton= PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgSendBtn);           
            sendButton.Click();
            Thread.Sleep(2 * 1000);

            inputBox.SendKeys("2");
            sendButton.Click();
            Thread.Sleep(2 * 1000);
            inputBox.SendKeys("3");
            sendButton.Click();
            Thread.Sleep(5 * 1000);
            PortalChromeDriver.Refresh();
            Thread.Sleep(10 * 1000);
            Assert.IsTrue(HIPage.GetTheLastMsg().Text.Equals("3"));
        }

        /// <summary>
        /// 49.	[对话窗口]聊天对话窗是否保存聊天历史记录（2）
        /// </summary>
        [TestMethod]
        public void IsMsgHistory2()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            Thread.Sleep(2 * 1000);
            HIPage.OpenHiChatWindow();
            Thread.Sleep(2 * 1000);

            var inputBox = PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgInputBox);
            inputBox.SendKeys("1");
            Thread.Sleep(10 * 1000);
            var sendButton = PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgSendBtn);
            sendButton.Click();
            Thread.Sleep(5* 1000);

            inputBox.SendKeys("2");
            sendButton.Click();
            Thread.Sleep(2 * 1000);
            inputBox.SendKeys("3");
            sendButton.Click();
            //click settings
            HIPage.ClickSettings();
            Thread.Sleep(2 * 1000);
            //Turn on HI
            if (HIPage.IsOn()) { HIPage.TurnOff(); }
            HIPage.TurnOn();
            Thread.Sleep(5 * 1000);
            HIPage.OpenHiChatWindow();
            Thread.Sleep(10* 1000);
            HIPage.GetTestUserFromUserList();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.GetTheLastMsg().Text.Equals("3"));
        }

        /// <summary>
        /// 50.	[对话窗口]聊天对话窗不支持超链接和URL，都应该以文本形式显示，且不可点击
        /// </summary>
        //[TestMethod]
        //public void IsHyperLink()
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
        //    HIPage.OpenHiChatWindow();
        //    Thread.Sleep(10 * 1000);

        //    HIPage.GetTestUserFromUserList();
        //    var inputBox = PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgInputBox);
        //    var sendButton = PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgSendBtn);
        //    //inputBox.SendKeys("a");
        //    //Thread.Sleep(10 * 1000);            
        //    //sendButton.Click();
        //    //Thread.Sleep(2 * 1000);


        //    inputBox.SendKeys("http://www.baidu.com");
        //    Thread.Sleep(10 * 1000);
        //    sendButton.Click();
        //    Thread.Sleep(2 * 1000);
        //    //怎么验证超链接？

        //    var elementChatBody = XiaoIcePortal.Driver.PortalChromeDriver.GetElementsByClassName("conversation_item");

        //    foreach (var item in elementChatBody)
        //    {
        //        if (item.Text == "http://www.baidu.com")
        //        {
        //            item.Click();
                    
        //            PortalChromeDriver.Instance.SwitchTo();
        //        }
        //    }
        //    Assert.IsTrue(PortalChromeDriver.GetElementByXpath("//*[@id='page_bodyo9CrYwdJnyo1ApkG6HFLirid_i0c']/div[10]/div/div/div[2]").Text.Equals("3"));

        //}
    }
}
