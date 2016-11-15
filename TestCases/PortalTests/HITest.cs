using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Portal.Pages;
using Portal.UIElement;
using Common.Driver;
using System;

namespace TestCases.PortalTests
{
    
    [TestClass]
    public class HITest : PortalTestInit
    {
        /// <summary>
        /// 1.	是否能够成功切换到人工客服功能的“设置” 界面
        /// </summary>
        [TestCategory("Portal")]
        [TestMethod]
        public void Can_ClickSetting()
        {
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            //Click settings
            HIPage.ClickSettings();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.IsSetting());
            PortalChromeDriver.TakeScreenShot("1.是否能够成功切换到人工客服功能的“设置” 界面");
        }

        /// <summary>
        /// 2.	是否可以正常开启“人工客服”功能
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Can_TurnOnHI()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();

            if (HIPage.IsOn())
            { HIPage.TurnOff(); }
            HIPage.TurnOn();
            HIPage.DisTurnOnDialogByClickOK();
            Assert.IsTrue(HIPage.IsOn());

            if (HIPage.IsOn())
            { HIPage.TurnOff(); }
            HIPage.TurnOn();
            PortalChromeDriver.Instance.Navigate().Refresh();
            Assert.IsTrue(HIPage.IsOn());

            if (HIPage.IsOn())
            { HIPage.TurnOff(); }
            HIPage.TurnOn();
            HIPage.DisTurnOnDialogByCancle();
            Assert.IsTrue(HIPage.IsOn());
            PortalChromeDriver.TakeScreenShot("2.是否可以正常开启“人工客服”功能");
        }    

        /// <summary>
        /// 3-10	[接入条件设置]是否可以添加触发关键词
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Can_AddTrigger()
        { 
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

            #region 3.	[接入条件设置]是否可以添加一条触发关键词
            HIPage.InputTrigger("hi");
            Thread.Sleep(2* 1000);
            Assert.IsTrue(HIPage.iskeywordAdded("hi"));
            PortalChromeDriver.TakeScreenShot("3.[接入条件设置]是否可以添加一条触发关键词");
            //check if has edit button
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            Assert.IsTrue(HIPage.HasEditButton());
            //check if has delete button
            Assert.IsTrue(HIPage.HasDeleteButton());
            HIPage.DeleteTrigger();
            #endregion

            #region 4.	[接入条件设置]是否可以添加一条为空的触发关键词
            HIPage.InputTrigger("");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
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
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
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
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsFalse(HIPage.iskeywordAdded("012345678901234567890"), "keyword added");
            PortalChromeDriver.TakeScreenShot("7.[接入条件设置]是否可以添加一条超过20个字的触发关键词");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            if (HIPage.HasDeleteButton())
                HIPage.DeleteTrigger();
            #endregion

            #region 8.	[接入条件设置]是否可以添加一条重复的触发关键词
            HIPage.InputTrigger("hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));           
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
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            PortalChromeDriver.TakeScreenShot("9.[接入条件设置]是否可以添加一条包含非法词语的触发关键词");
            Thread.Sleep(2* 1000);
            Assert.IsTrue(HIPage.HasAlert_Failure());
            HIPage.ClickModifyButton();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            PortalChromeDriver.Refresh();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
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
        [TestCategory("Portal")]
        public void Can_EditTrigger()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

            #region 11.	[接入条件设置]是否可以编辑已有的触发关键词
            HIPage.InputTrigger("Hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.EditTrigger("append");
            HIPage.ClickSomewhereToSave();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            Assert.IsTrue(HIPage.iskeywordAdded("Hiappend"));
            PortalChromeDriver.TakeScreenShot("11.[接入条件设置]是否可以编辑已有的触发关键词");
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            #endregion

            # region 12. [接入条件设置]是否可以正常保存，当编辑已有的触发关键词删除所有内容
            HIPage.InputTrigger("Hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.DeleteTriggerByEditButton();
            HIPage.ClickSomewhereToSave();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.iskeywordAdded("Hi"));
            PortalChromeDriver.TakeScreenShot("12.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词删除所有内容");
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            #endregion

            #region 13.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词输入空格
            HIPage.InputTrigger("Hi");
            Thread.Sleep(5* 1000);
            HIPage.ReplaceTrigger(" ");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            PortalChromeDriver.Refresh();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.iskeywordAdded("Hi"), "Keyword Added");
            PortalChromeDriver.TakeScreenShot("13.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词输入空格");
            HIPage.DeleteTrigger();
            PortalChromeDriver.Refresh();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            #endregion

            #region 14.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词输入html标签时
            HIPage.InputTrigger("Hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            PortalChromeDriver.Refresh();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            HIPage.ReplaceTrigger("<div class='body'>");
            HIPage.ClickSomewhereToSave();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.iskeywordAdded("<div class='body'>"), "Keyword Added");
            PortalChromeDriver.TakeScreenShot("14.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词输入html标签时");
            HIPage.DeleteTrigger();
            #endregion

            #region 15.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词超过20个字
            HIPage.InputTrigger("Hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.ReplaceTrigger("012345678901234567890");
            HIPage.ClickSomewhereToSave();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.iskeywordAdded("01234567890123456789"), "Keyword Added");
            PortalChromeDriver.TakeScreenShot("15.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词超过20个字");
            HIPage.DeleteTrigger();
            #endregion

            #region 16.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词跟其他的触发关键词重复时
            HIPage.InputTrigger("Hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.InputTrigger("Hello");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.ReplaceTrigger("Hi");
            HIPage.ClickSomewhereToSave();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.iskeywordAdded("Hello"), "Keyword Added");
            PortalChromeDriver.TakeScreenShot("16.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词跟其他的触发关键词重复时");
            HIPage.DeleteTrigger();
            #endregion

            #region 17.	[接入条件设置]是否可以正常保存，当编辑已有的触发关键词包含非法词语
            HIPage.InputTrigger("Hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.ReplaceTrigger("赌博");
            HIPage.ClickSomewhereToSave();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.iskeywordAdded("Hi"), "Keyword Added");
            PortalChromeDriver.TakeScreenShot("17.[接入条件设置]是否可以正常保存，当编辑已有的触发关键词包含非法词语");
            HIPage.DeleteTrigger();
            #endregion  
        }

        /// <summary>
        /// 19-23
        /// 19.	[接入条件设置]是否可以添加5条触发关键词
        /// 20.	[接入条件设置]是否可以成功删除一条触发关键词
        /// 21.	[接入条件设置]是否可以成功删除5条触发关键词
        /// 22.	[接入条件设置]是否可以成功删除再添加触发关键词
        /// 23.	[接入条件设置]是否保存状态，当输入触发关键词后不点添加，切换到“客服人员设定”tab
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Can_DeleteTrigger()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

            #region 20.	[接入条件设置]是否可以成功删除一条触发关键词
            HIPage.InputTrigger("Hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsFalse(HIPage.iskeywordAdded("Hi"), "Keyword Delete");
            PortalChromeDriver.TakeScreenShot("20.[接入条件设置]是否可以成功删除一条触发关键词");
            #endregion

            #region 19, 21.  [接入条件设置]是否可以成功删除5条触发关键词          
            HIPage.InputTrigger("Hi1");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.InputTrigger("Hi2");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.InputTrigger("Hi3");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.InputTrigger("Hi4");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.InputTrigger("Hi5");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.AddedFiveTrigger("最多添加5条"));
            PortalChromeDriver.TakeScreenShot("19.[接入条件设置]是否可以添加5条触发关键词");
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.AddedFiveTrigger("输入关键词，最多20个字"));
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            HIPage.DeleteTrigger();
            Thread.Sleep(5*1000);
            Assert.IsFalse(HIPage.iskeywordAdded("Hi1"), "Delete trigger");
            PortalChromeDriver.TakeScreenShot("21.[接入条件设置]是否可以成功删除5条触发关键词"); 
            #endregion

            #region 22.	[接入条件设置]是否可以成功删除再添加触发关键词
            PortalChromeDriver.Refresh();
            HIPage.InputTrigger("Hi1");
            Thread.Sleep(5* 1000);
            HIPage.InputTrigger("Hi2");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.InputTrigger("Hi3");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.InputTrigger("Hi4");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.InputTrigger("Hi5");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsFalse(HIPage.iskeywordAdded("Hi5"), "Keyword Delete");
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsFalse(HIPage.iskeywordAdded("Hi4"), "Keyword Delete");
            HIPage.InputTrigger("Hi6");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.iskeywordAdded("Hi6"), "Keyword add");
            HIPage.InputTrigger("Hi7");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.iskeywordAdded("Hi7"), "Keyword add");
            Assert.IsTrue(HIPage.AddedFiveTrigger("最多添加5条"), "Added 5 Keyword");
            PortalChromeDriver.TakeScreenShot("22.[接入条件设置]是否可以成功删除再添加触发关键词");
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.DeleteTrigger();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsFalse(HIPage.iskeywordAdded("Hi"), "Keyword Delete");
            #endregion

            #region 23.	[接入条件设置]是否保存状态，当输入触发关键词后不点添加，切换到“客服人员设
            HIPage.InputTriggerWithoutSave("Hi");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            Thread.Sleep(5* 1000);
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHITrigger);
            Assert.IsFalse(HIPage.iskeywordAdded("Hi"), "Keyword Delete");
            PortalChromeDriver.TakeScreenShot("23.[接入条件设置]是否保存状态，当输入触发关键词后不点添加，切换到“客服人员设");
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

        /// <summary>
        /// 25.	[客服人员设定]是否认证的公众号可以使用该功能(尚未获取密码）
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Can_Certified_GoToHiStaff()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            Assert.IsTrue(HIPage.IsVerified());
            PortalChromeDriver.TakeScreenShot("25.[客服人员设定]是否认证的公众号可以使用该功能");
        }

        /// <summary>
        /// 26.	[客服人员设定]是否可以获取登陆密码
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Can_Staf_GetBindCode()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            HIPage.GetLoginCode();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            Assert.IsTrue(HIPage.IsSendLoginCode());
            PortalChromeDriver.TakeScreenShot("26.[客服人员设定]是否可以获取登陆密码");
            var value = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.LoginCodeText).GetAttribute("value");
            Assert.IsTrue(HIPage.IsLoginCodeTextDisable());
        }

        /// <summary>
        /// 32.	[客服人员设定]是否可以移除绑定的客服人员
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Can_Delete_BindedStaff()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

            HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
            HIPage.DeleteStaff();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            Assert.IsTrue(HIPage.IsVerified());
            PortalChromeDriver.TakeScreenShot("32.[客服人员设定]是否可以移除绑定的客服人员");
        }

        /// <summary>
        /// 50.	[对话窗口]是否可以置顶，当切换用户的时候
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Is_User_TopShow_ReplyMsg()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.OpenHiChatWindow();
            HIPage.GetOtherUserFromUserList();
            Thread.Sleep(2*1000);
            HIPage.GetTestUserFromUserList();
            Thread.Sleep(2 * 1000);
            Assert.IsFalse(HIPage.CheckTheTopUser());
            HIPage.GetTestUserFromUserList();
            HIPage.SendMessage("我应该置顶");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(HIPage.CheckTheTopUser());
        }

        /// <summary>
        /// 46.	[对话窗口]聊天对话窗是否可以发送不同格式的图片（JPG，PNG，BMP和GIF）
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Can_Send_DiffPhotos()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.OpenHiChatWindow();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));

            HIPage.GetTestUserFromUserList();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.SendImage();
            Assert.IsTrue(HIPage.CanSendVarousPhotos());
            PortalChromeDriver.TakeScreenShot("46.[对话窗口]聊天对话窗是否可以发送不同格式的图片");
        }

        /// <summary>
        /// 47.	[对话窗口]聊天对话窗是否可以输入超过300个字
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Check_MaxLenth_Of_MsgInputBox()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.OpenHiChatWindow();
            Thread.Sleep(10* 1000);
            HIPage.GetTestUserFromUserList();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            HIPage.SendMessage("0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123");
            Assert.IsTrue(HIPage.IsLengthWithin300());
            PortalChromeDriver.TakeScreenShot("47.[对话窗口]聊天对话窗是否可以输入超过300个字");
        }

        /// <summary>
        /// 49.	[对话窗口]聊天对话窗是否保存聊天历史记录（1）
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Check_Msg_History1()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.OpenHiChatWindow();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(15));
            HIPage.GetTestUserFromUserList();
            HIPage.SendMessage("1");
            HIPage.SendMessage("2");
            HIPage.SendMessage("3");
            PortalChromeDriver.Refresh();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(15));
            Assert.IsTrue(HIPage.GetTheLastMsg().Text.Equals("3"));
            PortalChromeDriver.TakeScreenShot("49.[对话窗口]聊天对话窗是否保存聊天历史记录");
        }

        /// <summary>
        /// 50.	[对话窗口]聊天对话窗是否保存聊天历史记录（2）
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Check_Msg_History2()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            HIPage.OpenHiChatWindow();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

            HIPage.SendMessage("1");
            HIPage.SendMessage("2");
            HIPage.SendMessage("3");
     
            //click settings
            HIPage.ClickSettings();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            //Turn on HI
            if (HIPage.IsOn()) { HIPage.TurnOff(); }
            HIPage.TurnOn();
            HIPage.DisTurnOnDialogByClickOK();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            HIPage.OpenHiChatWindow();
            Thread.Sleep(10* 1000);
            HIPage.GetTestUserFromUserList();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            Assert.IsTrue(HIPage.GetTheLastMsg().Text.Equals("3"));
            PortalChromeDriver.TakeScreenShot("50.[对话窗口]聊天对话窗是否保存聊天历史记录（2）");
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

        /// <summary>
        /// 56.	是否可以停用"人工客服"功能
        /// </summary>
        [TestMethod]
        [TestCategory("Portal")]
        public void Can_TurnOff_HI()
        {
            //确保HI是Turn on的状态
            HIPage.TurnOnSetup();
            HIPage.TurnOff();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            Assert.IsTrue(HIPage.isOff());
            PortalChromeDriver.TakeScreenShot("56.是否可以停用'人工客服'功能");
        }       
    }
}
