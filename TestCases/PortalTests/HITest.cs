using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Portal.Pages;
using Portal.UIElement;
using Common.Driver;
using System;
using Common;
using XiaoIcePortal.Pages;

namespace TestCases.PortalTests
{
    
    [TestClass]
    public class HITest : PortalTestInit
    {
        [TestCategory("Portal")]
        [TestMethod]
        [TestProperty("description", "1.是否能够成功切换到人工客服功能的“设置” 界面")]
        public void Can_ClickSetting()
        {
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            //Click settings
            HIPage.ClickSettings();
            Assert.IsTrue(HIPage.IsSetting(),"设置页面未成功显示");
            PortalChromeDriver.TakeScreenShot("1.是否能够成功切换到人工客服功能的“设置” 界面");
        }

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "2.是否可以正常开启“人工客服”功能")]
        public void Can_TurnOnHI()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();

            if (HIPage.IsOn())
            { HIPage.TurnOff(); }
            HIPage.TurnOn();
            HIPage.DisTurnOnDialogByClickOK();
            Assert.IsTrue(HIPage.IsOn(),"点击OK按钮，HI打开失败");

            if (HIPage.IsOn())
            { HIPage.TurnOff(); }
            HIPage.TurnOn();
            PortalChromeDriver.Instance.Navigate().Refresh();
            Assert.IsTrue(HIPage.IsOn(), "刷新页面，HI打开失败");

            if (HIPage.IsOn())
            { HIPage.TurnOff(); }
            HIPage.TurnOn();
            HIPage.DisTurnOnDialogByCancle();
            Assert.IsTrue(HIPage.IsOn(), "点击叉号取消按钮，HI打开失败");
            PortalChromeDriver.TakeScreenShot("2.是否可以正常开启“人工客服”功能");
        }    

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "3-10是否可以添加触发关键词")]
        public void Can_AddTrigger()
        { 
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();

            #region 3.[接入条件设置]是否可以添加一条触发关键词
            HIPage.ClearTriggers();
            HIPage.InputTrigger("hi");
            PortalChromeDriver.TakeScreenShot("3.[接入条件设置]是否可以添加一条触发关键词");
            Assert.IsTrue(HIPage.iskeywordAdded("hi"),"添加一条触发关键词失败");           
            #endregion

            #region 4.[接入条件设置]是否可以添加一条为空的触发关键词
            HIPage.ClearTriggers();
            HIPage.InputTrigger("");
            PortalChromeDriver.Refresh();
            PortalChromeDriver.TakeScreenShot("4.[接入条件设置]是否可以添加一条为空的触发关键词");      
            Assert.IsFalse(HIPage.iskeywordAdded(""),"添加为空的触发关键词");
            #endregion

            #region 5.[接入条件设置]是否可以添加一条触发关键词，当输入空格时
            HIPage.ClearTriggers();
            HIPage.InputTrigger(" ");
            PortalChromeDriver.TakeScreenShot("5.[接入条件设置]是否可以添加一条触发关键词，当输入空格时");
            Assert.IsFalse(HIPage.iskeywordAdded(" "), "添加空格为触发关键词");
            #endregion

            #region 6.	[接入条件设置]是否可以添加一条触发关键词，当输入html标签时
            HIPage.ClearTriggers();
            HIPage.InputTrigger("<div class='body'>");
            PortalChromeDriver.TakeScreenShot("6.[接入条件设置]是否可以添加一条触发关键词，当输入html标签时");
            Assert.IsTrue(HIPage.iskeywordAdded("<div class='body'>"),"添加HTML标签失败");
            #endregion

            #region 7.	[接入条件设置]是否可以添加一条超过20个字的触发关键词
            HIPage.ClearTriggers();
            HIPage.InputTrigger("012345678901234567890");
            Assert.IsFalse(HIPage.iskeywordAdded("012345678901234567890"), "添加一条超过20个字的触发关键词");
            PortalChromeDriver.TakeScreenShot("7.[接入条件设置]是否可以添加一条超过20个字的触发关键词");
            #endregion

            #region 8.	[接入条件设置]是否可以添加一条重复的触发关键词
            Thread.Sleep(2 * 1000);
            HIPage.ClearTriggers();
            HIPage.InputTrigger("hi");
            Assert.IsTrue(HIPage.iskeywordAdded("hi"), "keyword added");
            HIPage.InputTrigger("hi");
            Assert.IsFalse(HIPage.isTheSameKeywordAdded("hi"), "添加一条重复的触法关键词");
            PortalChromeDriver.TakeScreenShot("8.[接入条件设置]是否可以添加一条重复的触发关键词");
            #endregion

            #region 9.	[接入条件设置]是否可以添加一条包含非法词语的触发关键词
            HIPage.ClearTriggers();
            HIPage.InputTrigger("赌博");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot("9.[接入条件设置]是否可以添加一条包含非法词语的触发关键词");
            Assert.IsTrue(HIPage.HasAlert_Failure(),"添加非法触发关键词");
            HIPage.ClickModifyButton();
            #endregion

        }

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "11-17是否可以编辑已有的触发关键词")]
        public void Can_EditTrigger()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();

            #region 11.	[接入条件设置]是否可以编辑已有的触发关键词
            HIPage.ClearTriggers();
            HIPage.InputTrigger("Hi");
            HIPage.EditTrigger("append");
            HIPage.ClickSomewhereToSave();
            PortalChromeDriver.TakeScreenShot("11.[接入条件设置]是否可以编辑已有的触发关键词");
            Assert.IsTrue(HIPage.iskeywordAdded("append"),"编辑已有触发关键词失败");      
            #endregion

            # region 12. [接入条件设置]是否可以正常保存，当编辑已有的触发关键词删除所有内容
            HIPage.ClearTriggers();
            HIPage.InputTrigger("Hi");
            HIPage.DeleteTriggerByEditButton();
            HIPage.ClickSomewhereToSave();
            PortalChromeDriver.TakeScreenShot("12.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词删除所有内容");
            Assert.IsTrue(HIPage.iskeywordAdded("Hi"), "编辑已有的触发关键词删除所有内容");          
            #endregion

            #region 13.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词输入空格
            HIPage.InputTrigger("Hi");
            HIPage.EditTrigger(" ");
            PortalChromeDriver.Refresh();
            PortalChromeDriver.TakeScreenShot("13.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词输入空格");
            Assert.IsTrue(HIPage.iskeywordAdded("Hi"), "编辑已有的触发关键词输入空格");          
            HIPage.DeleteTrigger();
            PortalChromeDriver.Refresh();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            #endregion

            #region 14.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词输入html标签时
            HIPage.ClearTriggers();
            HIPage.InputTrigger("Hi");
            PortalChromeDriver.Refresh();
            HIPage.EditTrigger("<div class='body'>");
            HIPage.ClickSomewhereToSave();
            PortalChromeDriver.TakeScreenShot("14.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词输入html标签时");
            Assert.IsTrue(HIPage.iskeywordAdded("<div class='body'>"), "编辑已有的触发关键词输入html标签时");
            #endregion

            #region 15.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词超过20个字
            HIPage.ClearTriggers();
            HIPage.InputTrigger("Hi");
            HIPage.EditTrigger("012345678901234567890");
            HIPage.ClickSomewhereToSave();
            PortalChromeDriver.TakeScreenShot("15.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词超过20个字");
            Assert.IsTrue(HIPage.iskeywordAdded("01234567890123456789"), "编辑已有的触发关键词超过20个字");          
            #endregion

            #region 16.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词跟其他的触发关键词重复时
            HIPage.ClearTriggers();
            HIPage.InputTrigger("Hi");
            HIPage.InputTrigger("Hello");
            HIPage.EditTrigger("Hi");
            HIPage.ClickSomewhereToSave();
            PortalChromeDriver.TakeScreenShot("16.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词跟其他的触发关键词重复时");
            Assert.IsTrue(HIPage.iskeywordAdded("Hello"), "编辑已有的触发关键词跟其他的触发关键词重复时");          
            #endregion

            #region 17.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词包含非法词语
            HIPage.ClearTriggers();
            HIPage.InputTrigger("Hi");
            HIPage.EditTrigger("赌博");
            HIPage.ByPassAlert();
            PortalChromeDriver.Refresh();
            PortalChromeDriver.TakeScreenShot("17.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词包含非法词语");
            Assert.IsTrue(HIPage.iskeywordAdded("Hi"), "编辑已有的触发关键词包含非法词语");
            #endregion  

        }

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "19-23是否可以删除已有的触发关键词")]
        public void Can_DeleteTrigger()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            #region 20.	[接入条件设置]是否可以成功删除一条触发关键词
            HIPage.ClearTriggers();
            HIPage.InputTrigger("Hi");
            HIPage.DeleteTrigger();
            PortalChromeDriver.TakeScreenShot("20.[接入条件设置]是否可以成功删除一条触发关键词");
            Assert.IsFalse(HIPage.iskeywordAdded("Hi"), "删除一条触发关键词失败");            
            #endregion

            #region 19, 21.  [接入条件设置]是否可以成功删除5条触发关键词   
            HIPage.ClearTriggers();
            HIPage.InputTrigger("Hi1");
            HIPage.InputTrigger("Hi2");
            HIPage.InputTrigger("Hi3");
            HIPage.InputTrigger("Hi4");
            HIPage.InputTrigger("Hi5");
            PortalChromeDriver.TakeScreenShot("19.[接入条件设置]是否可以添加5条触发关键词");
            Assert.IsTrue(HIPage.AddedFiveTrigger("最多添加5条"), "未显示'最多添加5条'提示");           
            HIPage.DeleteTrigger();
            Assert.IsTrue(HIPage.AddedFiveTrigger("输入关键词，最多20个字"),"删除一条之后，不能再添加新触发关键词");
            HIPage.DeleteTrigger();
            HIPage.DeleteTrigger();
            HIPage.DeleteTrigger();
            HIPage.DeleteTrigger();
            Assert.IsFalse(HIPage.iskeywordAdded("Hi1"), "删除触发关键词失败");
            PortalChromeDriver.TakeScreenShot("21.[接入条件设置]是否可以成功删除5条触发关键词");
            #endregion

            #region 22.	[接入条件设置]是否可以成功删除再添加触发关键词
            HIPage.ClearTriggers();
            PortalChromeDriver.Refresh();
            HIPage.InputTrigger("Hi1");
            HIPage.InputTrigger("Hi2");
            HIPage.InputTrigger("Hi3");
            HIPage.InputTrigger("Hi4");
            HIPage.InputTrigger("Hi5");
            HIPage.DeleteTrigger();
            Assert.IsFalse(HIPage.iskeywordAdded("Hi5"), "删除一条关键词失败");
            HIPage.DeleteTrigger();
            Assert.IsFalse(HIPage.iskeywordAdded("Hi4"), "删除一条关键词失败");
            HIPage.InputTrigger("Hi6");
            Assert.IsTrue(HIPage.iskeywordAdded("Hi6"), "删除之后再添加关键词失败");
            HIPage.InputTrigger("Hi7");
            PortalChromeDriver.TakeScreenShot("22.[接入条件设置]是否可以成功删除再添加触发关键词");
            Assert.IsTrue(HIPage.iskeywordAdded("Hi7"), "删除之后再添加关键词失败");           
            HIPage.ClearTriggers();
            Assert.IsFalse(HIPage.iskeywordAdded("Hi"), "清除触发关键词失败");
            #endregion

            #region 23.	[接入条件设置]是否保存状态，当输入触发关键词后不点添加，切换到“客服人员设
            HIPage.ClearTriggers();
            HIPage.InputTriggerWithoutSave("Hi");
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHITrigger);
            PortalChromeDriver.TakeScreenShot("23.[接入条件设置]是否保存状态，当输入触发关键词后不点添加，切换到“客服人员设");
            Assert.IsFalse(HIPage.iskeywordAdded("Hi"), "切换到'客服人员设置'，应保存失败");
            #endregion
        }

        /// <summary>
        /// 24.	[客服人员设定]是否提示非认证的公众号无法使用该功能
        /// </summary>
        //[TestMethod]
        //[TestCategory("Portal")]
        //public void Can_Non_certified_GoToHiChat()
        //{
        //    //确保HI是Turn on的状态
        //    HIPage.TurnOnSetup();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
        //    HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
        //    Assert.IsFalse(HIPage.IsVerified());
        //    PortalChromeDriver.TakeScreenShot("24.[客服人员设定]是否提示非认证的公众号无法使用该功能");
        //}

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "25.[客服人员设定]是否认证的公众号可以使用该功能(尚未获取密码）")]
        public void Can_Certified_GoToHiStaff()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            PortalChromeDriver.TakeScreenShot("25.[客服人员设定]是否认证的公众号可以使用该功能");
            Assert.IsTrue(HIPage.IsVerified(),"认证公众号去到绑定客服页失败");
        }

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "26.[客服人员设定]是否可以获取登陆密码")]
        public void Can_Staf_GetBindCode()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            HIPage.GetLoginCode();
            Assert.IsTrue(HIPage.IsSendLoginCode());
            PortalChromeDriver.TakeScreenShot("26.[客服人员设定]是否可以获取登陆密码");
            Assert.IsTrue(HIPage.IsLoginCodeTextDisable(),"客服人员获取登陆密码失败");
        }

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "34.[客服人员设定]是否可以移除绑定的客服人员")]
        public void Can_Delete_BindedStaff()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            HIPage.DeleteStaff();
            PortalChromeDriver.TakeScreenShot("32.[客服人员设定]是否可以移除绑定的客服人员");
            Assert.IsTrue(HIPage.IsVerified(),"移除客服人员失败");
        }


        //[TestMethod]
        //[TestCategory("Portal")]
        //[TestProperty("description", "41.[对话窗口]用户消息列表是否可以正常显示，当超过8条消息时")]
        //public void Can_GetMoreMessageShow_UsersMoreThanEight()
        //{

        //    //确保HI是Turn on的状态
        //    HIPage.TurnOnSetup();
        //    HIPage.HiChatPoartal();
        //    HIPage.FakeUserSendMessage();
        //}


        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "50.[对话窗口]是否可以置顶，当切换用户的时候")]
        public void Is_User_TopShow_ReplyMsg()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.OpenHiChatWindow();
            HIPage.GetOtherUserFromUserList();
            Thread.Sleep(5 * 1000);
            Assert.IsFalse(HIPage.CheckTheTopUser());
            HIPage.GetTestUserFromUserList();
            HIPage.SendMessage("我应该置顶");
            Thread.Sleep(2*1000);
            PortalChromeDriver.TakeScreenShot("50.[对话窗口]是否可以置顶，当切换用户的时候");
            Assert.IsTrue(HIPage.CheckTheTopUser(),"切换用户后该用户未置顶");
        }

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "46.[对话窗口]聊天对话窗是否可以发送不同格式的图片")]
        public void Can_Send_DiffPhotos()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.OpenHiChatWindow();
            HIPage.GetTestUserFromUserList();
            HIPage.SendImage();
            PortalChromeDriver.TakeScreenShot("46.[对话窗口]聊天对话窗是否可以发送不同格式的图片");
            Assert.IsTrue(HIPage.CanSendVarousPhotos(),"Portal发送图片失败");
        }

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "47.[对话窗口]聊天对话窗是否可以输入超过300个字")]
        public void Check_MaxLenth_Of_MsgInputBox()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.OpenHiChatWindow();
            HIPage.GetTestUserFromUserList();
            HIPage.SendMessage("0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123");
            Thread.Sleep(2*1000);
            PortalChromeDriver.TakeScreenShot("47.[对话窗口]聊天对话窗是否可以输入超过300个字");
            Assert.IsTrue(HIPage.IsLengthWithin300(),"超过300字应只显示前300字");           
        }

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "49.[对话窗口]聊天对话窗是否保存聊天历史记录（1）")]
        public void Check_Msg_History1()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.OpenHiChatWindow();
            HIPage.GetTestUserFromUserList();
            HIPage.SendMessage("1");
            HIPage.SendMessage("2");
            HIPage.SendMessage("3");
            PortalChromeDriver.TakeScreenShot("49.[对话窗口]聊天对话窗是否保存聊天历史记录（1）");
            Assert.IsTrue(HIPage.GetTheLastMsg().Text.Equals("3"),"聊天记录不正确");
        }

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "50.[对话窗口]聊天对话窗是否保存聊天历史记录（2）")]
        public void Check_Msg_History2()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.OpenHiChatWindow();
            HIPage.SendMessage("1");
            HIPage.SendMessage("2");
            HIPage.SendMessage("3");
     
            //click settings
            HIPage.ClickSettings();
            //Turn on HI
            if (HIPage.IsOn()) { HIPage.TurnOff(); }
            HIPage.TurnOn();
            HIPage.DisTurnOnDialogByClickOK();
            HIPage.OpenHiChatWindow();
            HIPage.GetTestUserFromUserList();
            PortalChromeDriver.TakeScreenShot("50.[对话窗口]聊天对话窗是否保存聊天历史记录（2）");
            Assert.IsTrue(HIPage.GetTheLastMsg().Text.Equals("3"),"关闭HI之后，聊天记录保存失败");
        }

        /// <summary>
        /// 51.	[对话窗口]聊天对话窗不支持超链接和URL，都应该以文本形式显示，且不可点击
        /// </summary>
        //[TestMethod]
        //public void IsHyperLink()
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
        //    HIPage.OpenHiChatWindow();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));

        //    HIPage.GetTestUserFromUserList();
        //    var inputBox = PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgInputBox);
        //    var sendButton = PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgSendBtn);
        //    //inputBox.SendKeys("a");
        //    //PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));            
        //    //sendButton.Click();
        //    //PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));


        //    inputBox.SendKeys("http://www.baidu.com");
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
        //    sendButton.Click();
        //    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
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

        [TestMethod]
        [TestCategory("Portal")]
        [TestProperty("description", "56.是否可以停用‘人工客服’功能")]
        public void Can_TurnOff_HI()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.TurnOff();
            PortalChromeDriver.TakeScreenShot("56.是否可以停用'人工客服'功能");
            Assert.IsTrue(HIPage.isOff(),"停用'人工客服'失败");
        }       
    }
}
