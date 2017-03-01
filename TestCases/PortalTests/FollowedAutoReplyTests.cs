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
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests
{
    [TestClass]
    public class FollowedAutoReplyTests : PortalTestInit
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
        public void FollowedAutoReply_AddText_BVT()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加文字关键词回复");

            FollowedAutoReplyPage.AddAutoReplyText("hello，谢谢关注");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal添加一条回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "hello，谢谢关注"));

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.UnFollowWeChatOffcialAccount();
            MobileH5.FollowWeChatOffcialAccount();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("hello，谢谢关注")));
            MobileH5.BackButtonClick();

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
        [TestCategory("AddText_FollowedAutoReply")]
        [TestMethod]
        [TestProperty("description", "添加文字关键词回复")]
        public void FollowedAutoReply_AddText()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加文字关键词回复");

            FollowedAutoReplyPage.AddAutoReplyText("");
            PortalChromeDriver.Refresh();
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal添加空回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "您输入的欢迎语"));

            FollowedAutoReplyPage.Delete();
            FollowedAutoReplyPage.AddAutoReplyText("123456");
            PortalChromeDriver.Refresh();
            Thread.Sleep(3 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal添加数字回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "123456"));

            FollowedAutoReplyPage.Delete();
            Thread.Sleep(3*1000);
            FollowedAutoReplyPage.AddAutoReplyText("!@##$%^&*()()");
            PortalChromeDriver.Refresh();
            Thread.Sleep(3 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal添加字符回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "!@##$%^&*()()"));

            FollowedAutoReplyPage.Delete();
            Thread.Sleep(3 * 1000);
            FollowedAutoReplyPage.AddAutoReplyText("0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.Refresh();           
            PortalChromeDriver.TakeScreenShot(filePath, "Portal验证回复字符上限");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789"));

        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_AddText_Illegal")]
        [TestMethod]
        [TestProperty("description", "添加非法字符")]
        public void FollowedAutoReply_AddText_Illegal()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加非法字符");

            FollowedAutoReplyPage.AddAutoReplyText("法轮功");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "添加非法字符");
            Assert.IsTrue(Utility.IsAt(CommonElement.notification), "抱歉，您的回复中包含了不当内容，请修改后重新保存。");
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Alert_Failure_Confirm);
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_AddText_href")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "添加超链接")]
        public void FollowedAutoReply_AddText_href()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加超链接");

            FollowedAutoReplyPage.AddAutoReplyText("<a href='http://www.sina.com.cn'>新浪</a>");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "超链接");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "新浪"));           
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_AddText_script")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "添加脚本")]
        public void FollowedAutoReply_AddText_script()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加脚本");

            FollowedAutoReplyPage.AddAutoReplyText("<script type='text/javascript'>document.write('< h1 > Hello World!</ h1 >')</script>");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "添加脚本");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "<script type='text/javascript'>document.write('< h1 > Hello World!</ h1 >')</script>"));          
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("FollowedAutoReply_AddText_href_Image")]
        [TestMethod]
        [TestProperty("description", "图片")]
        public void FollowedAutoReply_AddText_href_Image()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\是否能打开一张图片");

            FollowedAutoReplyPage.AddAutoReplyText("<a href='http://www.sinaimg.cn/dy/deco/2013/0604/loader.gif'>图片</a>");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "图片");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "图片"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_Add_Delete_Edit_News")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "添加删除修改图文回复并在Mobile端验证")]
        public void FollowedAutoReply_Add_Delete_Edit_News()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加删除修改图文回复并在Mobile端验证");

            FollowedAutoReplyPage.AddAutoReplyNews(FollowedAutoReplyElement.NewsChoose);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal添加图文回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "关于“东方万里行” 相关问题"));

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.UnFollowWeChatOffcialAccount();
            MobileH5.FollowWeChatOffcialAccount();
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile check");
            MobileAndroidDriver.ClickElemnetPerName("关于“东方万里行” 相关问题");
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("关于“东方万里行” 相关问题")));
  
            FollowedAutoReplyPage.Delete();
            PortalChromeDriver.TakeScreenShot(filePath, "删除图文");
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "关于“东方万里行” 相关问题"));

            FollowedAutoReplyPage.AddAutoReplyNews(FollowedAutoReplyElement.EditNews);
            PortalChromeDriver.TakeScreenShot(filePath, "修改图文回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "jdw"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_Add_News_NextPage")]
        [TestMethod]
        [TestCategory("Staging")]
        [TestCategory("BVT")]
        [TestProperty("description", "图文翻页")]
        public void FollowedAutoReply_News_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图文回复_翻页");

            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabnews);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            //翻到第二页
            Utility.NextPage();
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.NewsChoose),"f");

            Utility.PreviousPage();
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.NewsChoose, "关于“东方万里行” 相关问题"));

            Utility.NextPageInput("2");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.NewsChoose, "f"));

            Utility.NextPageInput("1");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.NewsChoose, "关于“东方万里行” 相关问题"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_Add_Delete_Edit_Image")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "添加删除修改图片回复")]
        public void FollowedAutoReply_Add_Delete_Edit_Image()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图片回复");

            FollowedAutoReplyPage.AddAutoReplyImage(FollowedAutoReplyElement.ImageChoose);
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImage, "u=115503548,1566568049&fm=23&gp=0.jpg"));

            //MobileAndroidDriver.AndroidInitialize();
            //MobileH5.UnFollowWeChatOffcialAccount();
            //MobileH5.FollowWeChatOffcialAccount();
            //Thread.Sleep(5 * 1000);
            //Assert.IsTrue(MobileAndroidDriver.IsAt("//android.widget.FrameLayout[contains(@resource-id,'com.tencent.mm:id/a4w')]", "添加第一页图片"));

            filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\删除图片回复");
            FollowedAutoReplyPage.Delete();
            PortalChromeDriver.TakeScreenShot(filePath, "删除图片回复");
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedImage, "u=115503548,1566568049&fm=23&gp=0.jpg"),"删除图片");

            filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\修改图片回复");
            FollowedAutoReplyPage.AddAutoReplyImage(FollowedAutoReplyElement.EditImage);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "修改图片回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImage, "1114.png"),"修改图片");
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddImageAndText_FollowedAutoReply_NextPage")]
        [TestMethod]
        [TestProperty("description", "图片翻页")]
        public void FollowedAutoReply_Image_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图文回复_翻页");

            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabimage);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2*1000);

            Utility.NextPage();
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.ImageChoose, "fwef.jpg"));

            Utility.PreviousPage();
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.ImageChoose, "u=115503548,1566568049&fm=23&gp=0.jpg"));

            Utility.NextPageInput("2");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.ImageChoose, "fwef.jpg"));

            Utility.NextPageInput("1");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.ImageChoose, "u=115503548,1566568049&fm=23&gp=0.jpg"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("FollowedAutoReply_Add_Delete_Edit_Video")]
        [TestMethod]
        [TestProperty("description", "添加删除修改视频回复")]
        public void FollowedAutoReply_Add_Delete_Edit_Video()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加删除修改视频回复");

            FollowedAutoReplyPage.AddAutoReplyVideo(FollowedAutoReplyElement.VideoChoose);
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedVideo, "测试视频11"), "添加视频回复");

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.UnFollowWeChatOffcialAccount();
            MobileH5.FollowWeChatOffcialAccount();
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "验证添加回复");
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("测试视频11")), "验证添加回复");

            FollowedAutoReplyPage.Delete();
            PortalChromeDriver.TakeScreenShot(filePath, "删除视频回复");
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedVideo, "测试视频11"),"删除视频回复");

            FollowedAutoReplyPage.AddAutoReplyVideo(FollowedAutoReplyElement.VideoEdit);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "修改音频回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedVideo, "测试视频10"), "修改音频回复");
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_Video_NextPage")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "视频翻页")]
        public void FollowedAutoReply_Video_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图文回复_翻页");

            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabvideo);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);

            Utility.NextPage();
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.VideoChoose, "测试视频5"));

            Utility.PreviousPage();
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.VideoChoose, "测试视频11"));

            Utility.NextPageInput("2");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.VideoChoose, "测试视频5"));

            Utility.NextPageInput("1");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.VideoChoose, "测试视频11"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("FollowedAutoReply_EditImage_NextPage")]
        [TestMethod]
        [TestProperty("description", "同时添加文本，图文，图片和语音自动回复信息，当前选中的素材被保存并发布到微信公众号上")]
        public void FollowedAutoReply_AddedAll_VideoFirst()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\同时添加文本图文图片和语音自动回复信息，当前选中的素材被保存并发布到微信公众号上");

            FollowedAutoReplyPage.AddAutoReplyText("hello，谢谢关注");
            FollowedAutoReplyPage.AddAutoReplyImage(FollowedAutoReplyElement.ImageChoose);
            FollowedAutoReplyPage.AddAutoReplyNews(FollowedAutoReplyElement.NewsChoose);
            FollowedAutoReplyPage.AddAutoReplyVideo(FollowedAutoReplyElement.VideoEdit);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.UnFollowWeChatOffcialAccount();
            MobileH5.FollowWeChatOffcialAccount();

            MobileAndroidDriver.GetScreenshot(filePath, "同时添加所有回复素材，video会上传至微信平台");
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("测试视频10")));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAuto_Reply_NoMaterial_Tips")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "当没有有图文素材的时候，检查图片消息界面是否显示正确")]
        public void FollowedAuto_Reply_NoMaterial_Tips()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\当没有有图文素材的时候，检查图片消息界面是否显示正确");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Account_Arrow_Down);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Logout);
            LoginPage.LoginWithPhoneNumber("13269120258");
            Thread.Sleep(10 * 1000);
            MobileAndroidDriver.AndroidMmsInitialize();
            MobileH5.GetLoginCode();

            HomePage.ClickWeChatApp("不是衣橱的海南");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabimage);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.NoMaterial_Tip, "没有同步到素材，请去往微信后台添加。新添加素材最多需15分钟同步到本地。"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAuto_Reply_Delete_null")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "当回复素材（文本/图文/图片/语音 ）为空的时候，点击“删除回复”")]
        public void FollowedAuto_Reply_Delete_null()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\当回复素材（文本图文图片语音 ）为空的时候，点击“删除回复”");

            Thread.Sleep(10*1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Delete);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "空内容无法删除"));            
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
