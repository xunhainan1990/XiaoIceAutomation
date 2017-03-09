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
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests.Weibo
{
    //[TestClass]
    public class FollowedAutoReplyTest_Weibo: PortalTestInit_Weibo
    {
        [TestInitialize]
        public void IntiMomentsSnapshot()
        {
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("AddText_FollowedAutoReply")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "添加文字关键词回复BVT")]
        public void FollowedAutoReply_AddText_BVT_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加文字关键词回复");

            FollowedAutoReplyPage.AddAutoReplyText("hello，谢谢关注");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal添加一条回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "hello，谢谢关注"));

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo.UnFollow();
            Mobile_Weibo.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            Assert.IsTrue((Mobile_Weibo.GetLatestMessage().Text.Contains("hello，谢谢关注")));

            FollowedAutoReplyPage.AddAutoReplyText("我是更改的文字回复");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal修改文字回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "我是更改的文字回复"));

            FollowedAutoReplyPage.Delete();
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal删除一条回复");
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "我是更改的文字回复"));

        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_AddText_href_Weibo")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "添加超链接")]
        public void FollowedAutoReply_AddText_href_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加超链接");

            FollowedAutoReplyPage.AddAutoReplyText("<a href='http://www.sina.com.cn'>新浪</a>");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "超链接");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "新浪"));

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo.UnFollow();
            Mobile_Weibo.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            Assert.IsTrue((Mobile_Weibo.GetLatestMessage().Text.Contains("新浪")));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_AddText_script_Weibo")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "添加脚本")]
        public void FollowedAutoReply_AddText_script_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加脚本");

            FollowedAutoReplyPage.AddAutoReplyText("<script type='text/javascript'>document.write('< h1 > Hello World!</ h1 >')</script>");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "添加脚本");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "<script type='text/javascript'>document.write('< h1 > Hello World!</ h1 >')</script>"));

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo.UnFollow();
            Mobile_Weibo.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            Assert.IsTrue((Mobile_Weibo.GetLatestMessage().Text.Contains("<script type='text/javascript'>document.write('< h1 > Hello World!</ h1 >')</script>")));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("FollowedAutoReply_AddText_href_Image_Weibo")]
        [TestMethod]
        [TestProperty("description", "图片")]
        public void FollowedAutoReply_AddText_href_Image_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\是否能打开一张图片");

            FollowedAutoReplyPage.AddAutoReplyText("<a href='http://www.sinaimg.cn/dy/deco/2013/0604/loader.gif'>图片</a>");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "图片");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "图片"));

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo.UnFollow();
            Mobile_Weibo.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            Assert.IsTrue((Mobile_Weibo.GetLatestMessage().Text.Contains("图片")));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_Add_Delete_Edit_News")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "添加删除修改图文回复并在Mobile端验证")]
        public void FollowedAutoReply_Add_Delete_Edit_News_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加删除修改图文回复并在Mobile端验证");

            FollowedAutoReplyPage.AddAutoReplyNews(FollowedAutoReplyElement.NewsChoose);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal添加图文回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "g"));

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo.UnFollow();
            Mobile_Weibo.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            MobileAndroidDriver.ClickElemnetPerName("g");
            Assert.IsTrue(MobileH5.IsAtPerName("头条文章"));

            FollowedAutoReplyPage.Delete();
            PortalChromeDriver.TakeScreenShot(filePath, "删除图文");
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "关于“东方万里行” 相关问题"));

            FollowedAutoReplyPage.AddAutoReplyNews(FollowedAutoReplyElement.EditNews);
            PortalChromeDriver.TakeScreenShot(filePath, "修改图文回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "e"));
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }

}
