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
using XiaoIceH5;
using XiaoIceH5.UIElement;
using XiaoIcePortal.Pages;
using XiaoIcePortal.Pages.Weibo;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests.Weibo
{
    [TestClass]
    public class MenuTest_Weibo:PortalTestInit_Weibo
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
            WeChatManagermentPage.GoTo_Menu_Page();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("1.1");
            MenuPage.AddMenu_Link_Wait("https://www.google.com");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo.FollowStateChanged();

            MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Menu);
            MobileAndroidDriver.ClickElemnetPerName("1.1");
            MobileAndroidDriver.GetScreenshot(filePath, "是否能成功添加一个一级菜单;在一级菜单里是否能成功设置一个跳转网页;是否能够成功删除所有菜单，点击界面下方的”删除”按钮");
            Assert.IsTrue(MobileH5.IsAtPerName("Google"));
            MobileAndroidDriver.androidDriver.Dispose();

            //一级菜单文字
            MenuPage.AddMenu("1.2");
            MenuPage.AddMenu_Text("文字");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo.FollowStateChanged();

            MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Menu);
            MobileAndroidDriver.ClickElemnetPerName("1.2");
            MobileAndroidDriver.GetScreenshot(filePath, "是否能成功添加一个一级菜单;在一级菜单里是否能成功设置一个跳转网页;是否能够成功删除所有菜单，点击界面下方的”删除”按钮");
            Assert.IsTrue(MobileH5.IsAtPerName("文字"));
            MobileAndroidDriver.androidDriver.Dispose();

            //一级菜单图片
            MenuPage.AddMenu("1.2");
            MebuPage_Weibo.AddMenu_Image();

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo.FollowStateChanged();

            MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Menu);
            MobileAndroidDriver.ClickElemnetPerName("1.2");
            MobileAndroidDriver.GetScreenshot(filePath, "");
            Assert.IsTrue(MobileAndroidDriver.IsAt("//android.widget.ImageView[contains(@resource-id,'com.sina.weibo:id/message_pic_shadow')]"));
            MobileAndroidDriver.androidDriver.Dispose();

            //一级菜单图文
            MenuPage.AddMenu("1.3");
            MenuPage.AddMenu_News();

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo.FollowStateChanged();

            MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Menu);
            MobileAndroidDriver.ClickElemnetPerName("1.3");
            MobileAndroidDriver.GetScreenshot(filePath, "");
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("关于“东方万里行” 相关问题")));
            MobileAndroidDriver.androidDriver.Dispose();

            filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\是否能够成功删除所有菜单，点击界面下方的”删除”按钮");
            MenuPage.DeleteMenuItem();
            Thread.Sleep(2*1000);
            Assert.IsFalse(Utility.IsAt(MenuElement.addedMenu, "一级菜单"));
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
