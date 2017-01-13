using Common;
using Common.Driver;
using CSH5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests
{
    [TestClass]
    public class MenuTest : PortalTestInit
    {
        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单")]
        public void AddOneLevelMenu_Link()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_链接");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("一级菜单");
            MenuPage.AddMenu_Link("https://www.google.com");

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MenuPage.ClickFirstLevelMenu();
            MobileAndroidDriver.GetScreenshot(filePath, "添加一级菜单");
            Assert.IsTrue(MobileH5.IsAtPerXpath(MenuElement.validator_Link, "Google"));

            MenuPage.DeleteMenuItem();
            Assert.IsFalse(Utility.IsAt(MenuElement.addedMenu, "一级菜单"));
        }

        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_文本")]
        public void AddOneLevelMenu_Text()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_文本");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("一");
            MenuPage.AddMenu_Text("这里是一级菜单");

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MenuPage.ClickFirstLevelMenu();
            MobileAndroidDriver.GetScreenshot(filePath, "添加一级菜单");
            Assert.IsTrue(MobileH5.GetLatestMessageWithMenu().Text == "这里是一级菜单");
        }

        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Image")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_图片")]
        public void AddOneLevelMenu_Image()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单——文本");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("一级图片");
            MenuPage.AddMenu_Image();

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MenuPage.ClickFirstLevelMenu();
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "添加一级菜单");
            Assert.IsTrue(MobileAndroidDriver.IsAt("//android.widget.FrameLayout[contains(@resource-id,'com.tencent.mm:id/a48')]", ""));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\删除已添加的图片");
            MenuPage.Delete();
            Thread.Sleep(1*1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "菜单项不能为空"));
            MobileAndroidDriver.GetScreenshot(filePath, "删除已添加的图片");
        }

        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_图文;删除已添加的图文")]
        public void AddOneLevelMenu_News()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_图文");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("一级图文");
            MenuPage.AddMenu_News();

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MenuPage.ClickFirstLevelMenu();
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "添加一级菜单_图文");
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("jdw")));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\删除已添加的图文");
            MenuPage.Delete();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "菜单项不能为空"));
            MobileAndroidDriver.GetScreenshot(filePath, "删除已添加的图文");
        }

        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_语音")]
        public void AddOneLevelMenu_Voice()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_语音");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("一级语音");
            MenuPage.AddMenu_Voice();

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MenuPage.ClickFirstLevelMenu();
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "添加一级菜单_语音");
            Assert.IsTrue(MobileH5.GetVoiceMessage());

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\删除已添加的语音");
            MenuPage.Delete();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "菜单项不能为空"));
            MobileAndroidDriver.GetScreenshot(filePath, "删除已添加的语音");
        }


        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddOneLevelMenu_Video()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("一级视频");
            MenuPage.AddMenu_Video();

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MenuPage.ClickFirstLevelMenu();
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "添加一级菜单_视频");
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("测试视频10")));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\删除已添加的视频");
            MenuPage.Delete();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "菜单项不能为空"));
            MobileAndroidDriver.GetScreenshot(filePath, "删除已添加的视频");
        }

        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddOneLevelMenu_SendMessage_GoBack()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("一级菜单");
            MenuPage.AddMenu_Text("一级菜单");
            MenuPage.AddMenu_GoBack();
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
            Assert.IsFalse(Utility.IsAt(MenuElement.TextInput, "一级菜单"));
        }

        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddOneLevelMenu_JumpPage_GoBack()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("一级菜单");
            MenuPage.AddMenu_Link("https://www.google.com");
            MenuPage.AddMenu_GoBack();
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Jump_Page_Button);
            Assert.IsFalse(Utility.IsAt(MenuElement.JumpLinkInput, "https://www.google.com"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddOneLevelMenu_Limited()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("一级图文菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.Error, "菜单名称名字不多于4个汉字或8个字母"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.Cancle);
            MenuPage.AddMenu("abcdefghi");
            Assert.IsTrue(Utility.IsAt(MenuElement.Error, "菜单名称名字不多于4个汉字或8个字母"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.Cancle);
            MenuPage.AddMenu("&");
            Assert.IsTrue(Utility.IsAt(MenuElement.Error, "字符中不允许出现符号"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.Cancle);
            MenuPage.AddMenu("");
            Assert.IsTrue(Utility.IsAt(MenuElement.Error, "输入不能为空"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddOneLevelMenu_Second()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("一");
            MenuPage.AddMenu_Link("https://www.google.com");
            MenuPage.AddMenu("二");
            MenuPage.AddMenu_Link("https://www.google.com");
            Assert.IsTrue(Utility.IsAt(MenuElement.SecondMenu, "二"));
            MenuPage.AddMenu("三");
            MenuPage.AddMenu_Link("https://www.google.com");
            Assert.IsTrue(Utility.IsAt(MenuElement.ThirdMenu, "三"));
            PortalChromeDriver.ClickElementPerXpath(MenuElement.add_menu_item_btn);
            Assert.IsTrue(Utility.IsAt(MenuElement.Alert_Failure, "最多只能添加三个一级菜单，当前已达设置上限"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.Alert_Failure_Confirm);
            MenuPage.DeleteMenuItem();
            Thread.Sleep(2 * 1000);
            Assert.IsFalse(Utility.IsAt(MenuElement.addedMenu, "三"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddSubMenu()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddSubMenu("2.1");
            MenuPage.AddSubMenu_News();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加4个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu("2.2");
            MenuPage.SubMenu_AddImage();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加3个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu("2.3");
            MenuPage.SubMenu_AddVoice();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加2个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu("2.4");
            MenuPage.SubMenu_AddVideo();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加1个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu("2.5");
            MenuPage.SubMenu_AddLink("https://www.google.com");
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你已添加满5个二级菜单"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.AddSubMenu);
            Assert.IsTrue(Utility.IsAt(MenuElement.Alert_Failure, "最多只能添加五个二级菜单，当前已达设置上限"));
        }


        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddSubMenu_WithFirstLevelMenuContent()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddMenu_Link("https://www.google.com");

            PortalChromeDriver.ClickElementPerXpath(MenuElement.AddSubMenu);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Confirm);
            PortalChromeDriver.GetElementByXpath(MenuElement.MenuInputBox).SendKeys("1.1");
            PortalChromeDriver.GetElementByXpath(MenuElement.MenuAddConfirm).Click();

            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加4个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

        }


        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddMenu_AddImage_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddImage_NextPage();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddMenu_AddImage_NextPage_Input()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddImage_NextPageInput();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddMenu_AddNews_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddNews_NextPage();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddMenu_AddNews_NextPage_Input()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddNews_NextPageInput();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }


        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_语音")]
        public void AddMenu_Voice_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddVoice_NextPage();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddMenu_Voice_NextPage_Input()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddVoice_NextPageInput();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }


        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_语音")]
        public void AddMenu_Video_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddVideo_NextPage();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }


        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddMenu_Video_NextPage_Input()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddVideo_NextPageInput();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddAllMenu()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddSubMenu("1.1");
            MenuPage.AddSubMenu_News();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加4个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu("1.2");
            MenuPage.SubMenu_AddImage();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加3个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu("1.3");
            MenuPage.SubMenu_AddVoice();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加2个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu("1.4");
            MenuPage.SubMenu_AddVideo();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加1个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu("1.5");
            MenuPage.SubMenu_AddLink("https://www.google.com");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            MenuPage.AddMenu("2");

            MenuPage.AddSubMenu_LevelTwo("2.1");
            MenuPage.AddSubMenu_News();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.AddedLevelTwo);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加4个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu_LevelTwo("2.2");
            MenuPage.SubMenu_AddImage();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.AddedLevelTwo);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加3个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu_LevelTwo("2.3");
            MenuPage.SubMenu_AddVoice();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.AddedLevelTwo);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加2个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu_LevelTwo("2.4");
            MenuPage.SubMenu_AddVideo();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.AddedLevelTwo);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加1个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            MenuPage.AddSubMenu_LevelTwo("2.5");
            MenuPage.SubMenu_AddLink("https://www.google.com");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.AddSubMenu_LevelTwo);
            Assert.IsTrue(Utility.IsAt(MenuElement.Alert_Failure, "最多只能添加五个二级菜单，当前已达设置上限"));
        }

        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_文本")]
        public void EditOneLevelMenu_Text()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_文本");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddMenu_Text("这里是一级菜单");

            MenuPage.ResetMenuContent();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_文本")]
        public void EditSubMenu_Text()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_文本");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddSubMenu("1.1");
            MenuPage.AddSubMenu_Text("文本");


            MenuPage.ResetSubMenuContent();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_文本")]
        public void TipsForNoContentMenu()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_文本");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            MenuPage.AddMenu("2");
            PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();

            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "菜单项不能为空"));
            //Assert.IsTrue(PortalChromeDriver.GetElementByClassName("menu_button menu_highlight").Text=="1");
        }

        [TestCategory("Menu")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_文本")]
        public void Menu_NoMaterial_Tips()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_文本");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Account_Arrow_Down);
            Thread.Sleep(2*1000);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Logout);
            LoginPage.LoginWithPhoneNumber("13269120258");
            Thread.Sleep(10 * 1000);
            MobileAndroidDriver.AndroidMmsInitialize();
            MobileH5.GetLoginCode();

            HomePage.ClickWeChatApp("不是衣橱的海南");
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.tabNews);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
            Thread.Sleep(2 * 1000);

            Assert.IsTrue(Utility.IsAt(MenuElement.NoMaterial_Tip, "没有同步到素材，请去往微信后台添加。新添加素材最多需15分钟同步到本地。"));
            //Assert.IsTrue(PortalChromeDriver.GetElementByClassName("menu_button menu_highlight").Text=="1");
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
