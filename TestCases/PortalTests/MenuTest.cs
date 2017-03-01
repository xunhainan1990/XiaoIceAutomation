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
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单;在一级菜单里是否能成功设置一个跳转网页;是否能够成功删除所有菜单，点击界面下方的”删除”按钮")]
        public void AddOneLevelMenu_Link()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_链接");

            MenuPage.AddMenu("一级菜单");
            MenuPage.AddMenu_Link_Wait("https://www.google.com");

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.ClickFirstLevelMenu("一级菜单");
            MobileAndroidDriver.GetScreenshot(filePath, "是否能成功添加一个一级菜单;在一级菜单里是否能成功设置一个跳转网页;是否能够成功删除所有菜单，点击界面下方的”删除”按钮");
            Assert.IsTrue(MobileH5.IsAtPerName("Google"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功删除所有菜单，点击界面下方的”删除”按钮");
            MenuPage.DeleteMenuItem();
            Assert.IsFalse(Utility.IsAt(MenuElement.addedMenu, "一级菜单"));
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "添加一级菜单中，是否可以删除已输入的菜单名称;是否能成功重命名一级菜单的名称")]
        public void Rename_OneLevelMenu()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单中，是否可以删除已输入的菜单名称");

            //MenuPage.AddMenu("一级菜单");
            PortalChromeDriver.GetElementByXpath(MenuElement.add_menu_item_btn).Click();
            PortalChromeDriver.GetElementByXpath(MenuElement.MenuInputBox).SendKeys("一级菜单");
            PortalChromeDriver.GetElementByXpath(MenuElement.MenuInputBox).Clear();
            PortalChromeDriver.GetElementByXpath(MenuElement.MenuInputBox).SendKeys("菜单");
            PortalChromeDriver.GetElementByXpath(MenuElement.MenuAddConfirm).Click();
            MobileAndroidDriver.GetScreenshot(filePath, "添加一级菜单中，是否可以删除已输入的菜单名称");
            Assert.IsTrue(Utility.IsAt(MenuElement.addedMenu, "菜单"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能成功重命名一级菜单的名称");
            MenuPage.RenameOneLevelMenu("一级");
            MobileAndroidDriver.GetScreenshot(filePath, "是否能成功重命名一级菜单的名称");
            Assert.IsFalse(Utility.IsAt(MenuElement.addedMenu, "一级菜单"));

            //MenuPage.AddMenu_Text("重命名的一级目录");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
            PortalChromeDriver.SendKeysPerXpath(MenuElement.TextInput, "重命名的一级目录");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.bottom_save);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.confirmbox_Cancle);
            Assert.IsFalse(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_文本")]
        public void AddOneLevelMenu_Text()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_文本");

            MenuPage.AddMenu("一");
            MenuPage.AddMenu_Text("这里是一级菜单");
            Thread.Sleep(300 * 1000);
            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.ClickFirstLevelMenu("一");
            MobileAndroidDriver.GetScreenshot(filePath, "是否能成功添加一个一级菜单_文本");
            Assert.IsTrue(MobileH5.GetLatestMessageWithMenu().Text == "这里是一级菜单");
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddOneLevelMenu_Image")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_图片;删除已添加的图片;是否能够成功删除一个一级菜单")]
        public void AddOneLevelMenu_Image()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单——文本");

            MenuPage.AddMenu("一级图片");
            MenuPage.AddMenu_Image();

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.ClearAllRecord();
            MobileH5.ClickFirstLevelMenu("一级图片");
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "添加一级菜单");
            Assert.IsTrue(MobileAndroidDriver.IsAt("//android.widget.FrameLayout[contains(@resource-id,'com.tencent.mm:id/a4w')]", ""));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\删除已添加的图片");
            MenuPage.Delete();
            Thread.Sleep(1*1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "菜单项不能为空"));
            MobileAndroidDriver.GetScreenshot(filePath, "删除已添加的图片");
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_图文;删除已添加的图文")]
        public void AddOneLevelMenu_News()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_图文");

            MenuPage.AddMenu("一级图文");
            MenuPage.AddMenu_News();

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.ClickFirstLevelMenu("一级图文");
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "添加一级菜单_图文");
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("关于“东方万里行” 相关问题")));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\删除已添加的图文");
            MenuPage.Delete();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "菜单项不能为空"));
            MobileAndroidDriver.GetScreenshot(filePath, "删除已添加的图文");
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_语音;删除已添加的语音")]
        public void AddOneLevelMenu_Audio()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_语音");
            MenuPage.AddMenu("一级语音");
            MenuPage.AddMenu_Audio();

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.ClearAllRecord();
            MobileH5.ClickFirstLevelMenu("一级语音");
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "添加一级菜单_语音");
            Assert.IsTrue(MobileH5.GetAudioMessage());

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\删除已添加的语音");
            MenuPage.Delete();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "菜单项不能为空"));
            MobileAndroidDriver.GetScreenshot(filePath, "删除已添加的语音");
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频;删除已添加的视频")]
        public void AddOneLevelMenu_Video()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");

            MenuPage.AddMenu("一级视频");
            MenuPage.AddMenu_Video();
            Thread.Sleep(300*1000);
            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.ClickFirstLevelMenu("一级视频");
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "添加一级菜单_视频");
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("测试视频11")));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\删除已添加的视频");
            MenuPage.Delete();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "菜单项不能为空"));
            MobileAndroidDriver.GetScreenshot(filePath, "删除已添加的视频");
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "发送消息是否能成功返回到上一级界面，当点击“重设菜单内容;发送消息是否能成功返回到上一级界面，并且已添加的素材被清空，当添加了图文,点击“重设菜单内容")]
        public void AddOneLevelMenu_SendMessage_GoBack()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\发送消息是否能成功返回到上一级界面，当点击“重设菜单内容");

            MenuPage.AddMenu("一级菜单");
            MenuPage.AddMenu_Text("一级菜单");
            MenuPage.AddMenu_GoBack();
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
            PortalChromeDriver.TakeScreenShot(filePath, "发送消息是否能成功返回到上一级界面，当点击“重设菜单内容");
            Assert.IsFalse(Utility.IsAt(MenuElement.TextInput, "一级菜单"));
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "跳转到页面是否能成功返回到上一级界面，当点击“重设菜单内容;跳转到页面是否能成功返回到上一级界面，并且已添加的素材被清空，当添加了跳转页面，点击“重设菜单内容" )]
        public void AddOneLevelMenu_JumpPage_GoBack()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\跳转到页面：是否能成功返回到上一级界面，当点击“重设菜单内容");

            MenuPage.AddMenu("一级菜单");
            MenuPage.AddMenu_Link("https://www.google.com");
            MenuPage.AddMenu_GoBack();
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Jump_Page_Button);
            PortalChromeDriver.TakeScreenShot(filePath, "跳转到页面是否能成功返回到上一级界面，当点击“重设菜单内容");
            Assert.IsFalse(Utility.IsAt(MenuElement.JumpLinkInput, "https://www.google.com"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "添加一级菜单中输入大于4个汉字或8个字母，是否会有提示;添加一级菜单中输入符号，是否有提示;添加一级菜单中名字为空时，是否会有提示;")]
        public void AddOneLevelMenu_Limited()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单中输入大于4个汉字或8个字母，是否会有提示");

            MenuPage.AddMenu("一级图文菜单");
            PortalChromeDriver.TakeScreenShot(filePath, "添加一级菜单中输入大于4个汉字，是否会有提示");
            Assert.IsTrue(Utility.IsAt(MenuElement.Error, "菜单名称名字不多于4个汉字或8个字母"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.Cancle);
            MenuPage.AddMenu("abcdefghi");
            PortalChromeDriver.TakeScreenShot(filePath, "添加一级菜单中输入大于8个字母，是否会有提示");
            Assert.IsTrue(Utility.IsAt(MenuElement.Error, "菜单名称名字不多于4个汉字或8个字母"));


            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单中输入符号，是否有提示");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Cancle);
            MenuPage.AddMenu("&");
            PortalChromeDriver.TakeScreenShot(filePath, "添加一级菜单中输入符号，是否有提示");
            Assert.IsTrue(Utility.IsAt(MenuElement.Error, "字符中不允许出现符号"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单中名字为空时，是否会有提示");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Cancle);
            MenuPage.AddMenu("");
            PortalChromeDriver.TakeScreenShot(filePath, "添加一级菜单中名字为空时，是否会有提示");
            Assert.IsTrue(Utility.IsAt(MenuElement.Error, "输入不能为空"));
        }

        [TestCategory("AddOneLevelMenu_More")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "是否能成功添加一个一级菜单;是否能成功添加第二个一级菜单;是否能成功添加第三个一级菜单;是否能成功添加第四个一级菜单；是否能够成功删除所有一级菜单")]
        public void AddOneLevelMenu_More()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能成功添加一个一级菜单");

            MenuPage.AddMenu("一");
            MenuPage.AddMenu_Link("https://www.google.com");

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能成功添加第二个一级菜单");
            MenuPage.AddMenu("二");
            MenuPage.AddMenu_Link("https://www.google.com");
            PortalChromeDriver.TakeScreenShot(filePath, "是否能成功添加第二个一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.SecondMenu, "二"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能成功添加第三个一级菜单");
            MenuPage.AddMenu("三");
            MenuPage.AddMenu_Link("https://www.google.com");
            PortalChromeDriver.TakeScreenShot(filePath, "是否能成功添加第三个一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.ThirdMenu, "三"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能成功添加第四个一级菜单");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.add_menu_item_btn);
            PortalChromeDriver.TakeScreenShot(filePath, "是否能成功添加第四个一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.Alert_Failure, "最多只能添加三个一级菜单，当前已达设置上限"));

            PortalChromeDriver.ClickElementPerXpath(MenuElement.Alert_Failure_Confirm);
            MenuPage.DeleteMenuItem();
            Thread.Sleep(2 * 1000);
            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功删除所有一级菜单");
            PortalChromeDriver.TakeScreenShot(filePath, "是否能够成功删除所有一级菜单");
            Assert.IsFalse(Utility.IsAt(MenuElement.addedMenu, "三"));
        }

        [TestCategory("AddSubMenu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "是否能够成功在第一个一级菜单下添加两个第二级菜单，并且添加一个图片信息；再添加完第一个二级菜单后，点击当前的一级菜单，检查页面是否显示正确；是否能够成功在第一个一级菜单下添加两个第二级菜单，并且添加一个图片信息；再添加完第二个二级菜单后，点击当前的一级菜单，检查页面是否显示正确；是否能够成功在第一个一级菜单下添加第三个二级菜单，并且添加一个语音信息；再添加完第三个二级菜单后，点击当前的一级菜单，检查页面是否显示正确；是否能够成功在第一个一级菜单下添加第四个二级菜单，并且添加一个视频信息；再添加完第四个二级菜单后，点击当前的一级菜单，检查页面是否显示正确；是否能够成功在第一个一级菜单下添加第五个二级菜单，并且添加一个跳转页面信息；再添加完第五个二级菜单后，点击当前的一级菜单，检查页面是否显示正确；是否能够成功在第一个一级菜单添加第六个二级菜单")]
        public void AddSubMenu()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功在第一个一级菜单下添加第一个二级菜单，并且添加一个图文信息");

            MenuPage.AddMenu("1");
            MenuPage.AddSubMenu("1.1");
            MenuPage.AddSubMenu_News();
            PortalChromeDriver.TakeScreenShot(filePath, "是否能成功添加第二个一级菜单");
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\再添加完第一个二级菜单后，点击当前的一级菜单，检查页面是否显示正确");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            PortalChromeDriver.TakeScreenShot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加4个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功在第一个一级菜单下添加两个第二级菜单，并且添加一个图片信息");
            MenuPage.AddSubMenu("1.2");
            MenuPage.SubMenu_AddImage();
            PortalChromeDriver.TakeScreenShot(filePath, "是否能够成功在第一个一级菜单下添加两个第二级菜单，并且添加一个图片信息");
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\再添加完第二个二级菜单后，点击当前的一级菜单，检查页面是否显示正确");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加3个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功在第一个一级菜单下添加第三个二级菜单，并且添加一个语音信息");
            MenuPage.AddSubMenu("1.3");
            MenuPage.SubMenu_AddAudio();
            PortalChromeDriver.TakeScreenShot(filePath, "是否能够成功在第一个一级菜单下添加第三个二级菜单，并且添加一个语音信息");
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\再添加完第三个二级菜单后，点击当前的一级菜单，检查页面是否显示正确");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加2个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功在第一个一级菜单下添加第四个二级菜单，并且添加一个视频信息");
            MenuPage.AddSubMenu("1.4");
            MenuPage.SubMenu_AddVideo();
            PortalChromeDriver.TakeScreenShot(filePath, "是否能够成功在第一个一级菜单下添加第四个二级菜单，并且添加一个视频信息");
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\再添加完第四个二级菜单后，点击当前的一级菜单，检查页面是否显示正确");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加1个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功在第一个一级菜单下添加第五个二级菜单，并且添加一个跳转页面信息");
            MenuPage.AddSubMenu("1.5");
            MenuPage.SubMenu_AddLink("https://www.google.com");
            PortalChromeDriver.TakeScreenShot(filePath, "是否能够成功在第一个一级菜单下添加第五个二级菜单，并且添加一个跳转页面信息");
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\再添加完第五个二级菜单后，点击当前的一级菜单，检查页面是否显示正确");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你已添加满5个二级菜单"));

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功在第一个一级菜单添加第六个二级菜单");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.AddSubMenu);
            MobileAndroidDriver.GetScreenshot(filePath, "是否能够成功在第一个一级菜单添加第六个二级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.Alert_Failure, "最多只能添加五个二级菜单，当前已达设置上限"));
        }

        [TestCategory("AddSubMenu_WithFirstLevelMenuContent")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "是否能够成功添加一个二级菜单，当一级菜单有内容设置的时候")]
        public void AddSubMenu_WithFirstLevelMenuContent()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功添加一个二级菜单，当一级菜单有内容设置的时候");

            MenuPage.AddMenu("1");
            MenuPage.AddMenu_Link("https://www.google.com");

            PortalChromeDriver.ClickElementPerXpath(MenuElement.AddSubMenu);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Confirm);
            PortalChromeDriver.GetElementByXpath(MenuElement.MenuInputBox).SendKeys("1.1");
            PortalChromeDriver.GetElementByXpath(MenuElement.MenuAddConfirm).Click();

            PortalChromeDriver.ClickElementPerXpath(MenuElement.addedMenu);
            PortalChromeDriver.TakeScreenShot(filePath, "二级菜单返回一级菜单");
            Assert.IsTrue(Utility.IsAt(MenuElement.AddedMenu_Description, "你还可以添加4个二级菜单"));
            Assert.IsTrue(Utility.IsAt(MenuElement.SubMenuFromMenu, "添加二级菜单"));
        }

        [TestCategory("AddMenu_AddImage_NextPage")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "检查图片选择素材对话框")]
        public void AddMenu_AddImage_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\检查图片 选择素材 对话框");

            MenuPage.AddMenu("1");
            MenuPage.AddImage_NextPage();
            PortalChromeDriver.TakeScreenShot(filePath, "检查图片选择素材对话框");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "是否能成功添加一个一级菜单_视频")]
        public void AddMenu_AddImage_NextPage_Input()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\添加一级菜单_视频");

            MenuPage.AddMenu("1");
            MenuPage.AddImage_NextPageInput();
            PortalChromeDriver.TakeScreenShot(filePath, "检查图片选择素材对话框");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "检查图文选择素材对话框")]
        public void AddMenu_AddNews_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\检查图文选择素材对话框");

            MenuPage.AddMenu("1");
            MenuPage.AddNews_NextPage();
   
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
            PortalChromeDriver.TakeScreenShot(filePath, "检查图文选择素材对话框");
        }

        [TestCategory("AddMenu_AddNews_NextPage_Input")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "检查图文选择素材对话框")]
        public void AddMenu_AddNews_NextPage_Input()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\检查图文选择素材对话框");

            MenuPage.AddMenu("1");
            MenuPage.AddNews_NextPageInput();

            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
            PortalChromeDriver.TakeScreenShot(filePath, "检查图文选择素材对话框");
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddMenu_Audio_NextPage")]
        [TestMethod]
        [TestProperty("description", "检查语音选择素材对话框")]
        public void AddMenu_Audio_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\检查语音选择素材对话框");

            MenuPage.AddMenu("1");
            MenuPage.AddAudio_NextPage();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
            PortalChromeDriver.TakeScreenShot(filePath, "检查语音选择素材对话框");
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "检查语音选择素材对话框")]
        public void AddMenu_Audio_NextPage_Input()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\检查语音选择素材对话框");

            MenuPage.AddMenu("1");
            MenuPage.AddAudio_NextPageInput();

            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
            PortalChromeDriver.TakeScreenShot(filePath, "检查语音选择素材对话框");
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "检查视频选择素材对话框")]
        public void AddMenu_Video_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\检查视频选择素材对话框");

            MenuPage.AddMenu("1");
            MenuPage.AddVideo_NextPage();
            PortalChromeDriver.TakeScreenShot(filePath, "检查视频选择素材对话框");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "检查视频选择素材对话框")]
        public void AddMenu_Video_NextPage_Input()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\检查视频选择素材对话框");

            MenuPage.AddMenu("1");
            MenuPage.AddVideo_NextPageInput();
            PortalChromeDriver.TakeScreenShot(filePath, "检查视频选择素材对话框");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
        }

        [TestCategory("AddOneLevelMenu_Link")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "是否能够成功添加3个一级菜单，并且每个一级菜单中创建5个二级菜单")]
        public void AddAllMenu()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功添加3个一级菜单，并且每个一级菜单中创建5个二级菜单");

            MenuPage.AddMenu("1");
            MenuPage.AddSubMenu("1.1");
            MenuPage.AddSubMenu_News();
            Thread.Sleep(2 * 1000);

            MenuPage.AddSubMenu("1.2");
            MenuPage.SubMenu_AddImage();
            Thread.Sleep(2 * 1000);

            MenuPage.AddSubMenu("1.3");
            MenuPage.SubMenu_AddAudio();
            Thread.Sleep(2 * 1000);

            MenuPage.AddSubMenu("1.4");
            MenuPage.SubMenu_AddVideo();
            Thread.Sleep(2 * 1000);

            MenuPage.AddSubMenu("1.5");
            MenuPage.SubMenu_AddLink("https://www.google.com");
            Thread.Sleep(2 * 1000);


            MenuPage.AddMenu("2");

            MenuPage.AddSubMenu_LevelTwo("2.1");
            MenuPage.AddSubMenu_News();
            Thread.Sleep(2 * 1000);

            MenuPage.AddSubMenu_LevelTwo("2.2");
            MenuPage.SubMenu_AddImage();
            Thread.Sleep(1 * 1000);

            MenuPage.AddSubMenu_LevelTwo("2.3");
            MenuPage.SubMenu_AddAudio();
            Thread.Sleep(2 * 1000);

            MenuPage.AddSubMenu_LevelTwo("2.4");
            MenuPage.SubMenu_AddVideo();
            Thread.Sleep(2 * 1000);

            MenuPage.AddSubMenu_LevelTwo("2.5");
            MenuPage.SubMenu_AddLink("https://www.google.com");
            Thread.Sleep(2 * 1000);
      
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
            PortalChromeDriver.TakeScreenShot(filePath, "是否能够成功添加3个一级菜单，并且每个一级菜单中创建5个二级菜单");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.AddSubMenu_LevelTwo);
            Assert.IsTrue(Utility.IsAt(MenuElement.Alert_Failure, "最多只能添加五个二级菜单，当前已达设置上限"));
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("EditOneLevelMenu_Text")]
        [TestMethod]
        [TestProperty("description", "是否能够成功修改一级菜单内容")]
        public void EditOneLevelMenu_Text()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功修改一级菜单内容");

            MenuPage.AddMenu("1");
            MenuPage.AddMenu_Text("这里是一级菜单");

            MenuPage.ResetMenuContent();

            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
            PortalChromeDriver.TakeScreenShot(filePath, "是否能够成功修改一级菜单内容");
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("EditSubMenu_Text")]
        [TestMethod]
        [TestProperty("description", "是否能够成功修改二级菜单内容")]
        public void EditSubMenu_Text()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功修改二级菜单内容");

            MenuPage.AddMenu("1");
            MenuPage.AddSubMenu("1.1");
            MenuPage.AddSubMenu_Text("文本");

            MenuPage.ResetSubMenuContent();

            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "保存成功"));
            PortalChromeDriver.TakeScreenShot(filePath, "是否能够成功修改二级菜单内容");
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddOneLevelMenu_Link")]
        [TestMethod]
        [TestProperty("description", "是否会自动跳到第一个没有的菜单下，当有菜单没有被设置内容的时候点 保存发布")]
        public void TipsForNoContentMenu()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否会自动跳到第一个没有的菜单下，当有菜单没有被设置内容的时候点 保存发布");

            MenuPage.AddMenu("1");
            MenuPage.AddMenu("2");
            PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();

            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "菜单项不能为空"));
            PortalChromeDriver.TakeScreenShot(filePath, "是否会自动跳到第一个没有的菜单下，当有菜单没有被设置内容的时候点 保存发布");
            //Assert.IsTrue(PortalChromeDriver.GetElementByClassName("menu_button menu_highlight").Text=="1");
        }

        [TestCategory("Menu")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("Menu_NoMaterial_Tips")]
        [TestMethod]
        [TestProperty("description", "素材库没有素材，是否提示去微信后台添加")]
        public void Menu_NoMaterial_Tips()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\素材库没有素材，是否提示去微信后台添加");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Account_Arrow_Down);
            Thread.Sleep(5*1000);
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
            //PortalChromeDriver.TakeScreenShot(filePath, "素材库没有素材，是否提示去微信后台添加");
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
