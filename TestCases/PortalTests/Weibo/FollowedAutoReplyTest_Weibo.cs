using Common;
using Mobile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal;
using Portal.Pages;
using System.Threading;
using Mobile;
using XiaoIcePortal.Pages;
using XiaoIcePortal.Pages.Weibo;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests.Weibo
{

    public class FollowedAutoReplyTest_Weibo: PortalTestInit_Weibo
    {
        [TestInitialize]
        public void IntiMomentsSnapshot()
        {
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
        }

        [TestCategory("FollowedAutoReply_Weibo")]
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
            Mobile_Weibo_Utility.UnFollow();
            Mobile_Weibo_Utility.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            Assert.IsTrue((Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("hello，谢谢关注")));

            FollowedAutoReplyPage.AddAutoReplyText("我是更改的文字回复");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal修改文字回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "我是更改的文字回复"));

            FollowedAutoReplyPage.Delete();
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal删除一条回复");
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "我是更改的文字回复"));

        }

        [TestCategory("FollowedAutoReply_Weibo")]
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
            Mobile_Weibo_Utility.UnFollow();
            Mobile_Weibo_Utility.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            Assert.IsTrue((Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("新浪")));
        }

        [TestCategory("FollowedAutoReply_Weibo")]
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
            Mobile_Weibo_Utility.UnFollow();
            Mobile_Weibo_Utility.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            Assert.IsTrue((Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("<script type='text/javascript'>document.write('< h1 > Hello World!</ h1 >')</script>")));
        }

        [TestCategory("FollowedAutoReply_Weibo")]
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
            Mobile_Weibo_Utility.UnFollow();
            Mobile_Weibo_Utility.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            Assert.IsTrue((Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("图片")));
        }

        [TestCategory("FollowedAutoReply_Weibo")]
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
            Mobile_Weibo_Utility.UnFollow();
            Mobile_Weibo_Utility.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            MobileAndroidDriver.ClickElemnetPerName("g");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerName("头条文章"));

            FollowedAutoReplyPage.Delete();
            PortalChromeDriver.TakeScreenShot(filePath, "删除图文");
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "关于“东方万里行” 相关问题"));

            FollowedAutoReplyPage.AddAutoReplyNews(FollowedAutoReplyElement.EditNews);
            PortalChromeDriver.TakeScreenShot(filePath, "修改图文回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "e"));
        }

        [TestCategory("FollowedAutoReply_Weibo")]
        [TestCategory("FollowedAutoReply_Add_News_NextPage")]
        [TestMethod]
        [TestCategory("Staging")]
        [TestCategory("BVT")]
        [TestProperty("description", "图文翻页")]
        public void FollowedAutoReply_News_NextPage_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图文回复_翻页");

            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabnews);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            //翻到第二页
            Utility.NextPage();
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.NewsChoose), "i");

            Utility.PreviousPage();
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.NewsChoose, "g"));

            Utility.NextPageInput("2");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.NewsChoose, "i"));

            Utility.NextPageInput("1");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.NewsChoose, "g"));
        }

        [TestCategory("FollowedAutoReply_Weibo")]
        [TestCategory("FollowedAutoReply_Add_Delete_Edit_Image")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "添加删除修改图片回复")]
        public void FollowedAutoReply_Add_Delete_Edit_Image_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图片回复");
            FollowedAutoReplyPage_Weibo.AddAutoReplyImage("Capture.PNG");
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImage, "Capture.PNG"));

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.UnFollow();
            Mobile_Weibo_Utility.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "Mobile端check");
            Assert.IsTrue(MobileAndroidDriver.IsAt("//android.widget.ImageView[contains(@resource-id,'com.sina.weibo:id/message_pic_shadow')]"));

            filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\删除图片回复");
            FollowedAutoReplyPage.Delete_Image();
            PortalChromeDriver.TakeScreenShot(filePath, "删除图片回复");
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedImage, "Capture.PNG"), "删除图片");

            filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\修改图片回复");
            FollowedAutoReplyPage_Weibo.AddAutoReplyImage("efwe.jpg");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "修改图片回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImage, "efwe.jpg"), "修改图片");
        }

        [TestCategory("FollowedAutoReply_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("FollowedAutoReply_Add_Delete_Edit_Video")]
        [TestMethod]
        [TestProperty("description", "添加删除修改视频回复")]
        public void FollowedAutoReply_Add_Delete_Edit_Voice_WeiBo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加删除修改视频回复");

            FollowedAutoReplyPage_Weibo.AddAutoReplyVoice("秋天不回来.amr");
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAudio, "秋天不回来.amr"), "添加视频回复");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.UnFollow();
            Mobile_Weibo_Utility.Follow();
            MobileAndroidDriver.GetScreenshot(filePath, "验证添加回复");
            Assert.IsTrue((Mobile_WeChat_Utility.IsAtPerXpath("//android.widget.TextView[contains(@resource-id,'com.sina.weibo:id/audio_time')]")), "验证添加回复");

            FollowedAutoReplyPage.Delete_Image();
            PortalChromeDriver.TakeScreenShot(filePath, "删除视频回复");
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedVideo, "秋天不回来.amr"), "删除视频回复");

            FollowedAutoReplyPage_Weibo.AddAutoReplyVoice("童话.amr");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "修改音频回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAudio, "童话.amr"), "修改音频回复");
        }

        [TestCategory("FollowedAutoReply_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("FollowedAutoReply_EditImage_NextPage")]
        [TestMethod]
        [TestProperty("description", "同时添加文本，图文，图片和语音自动回复信息，当前选中的素材被保存并发布到微信公众号上")]
        public void FollowedAutoReply_AddedAll_VideoFirst_WeiBo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\同时添加文本图文图片和语音自动回复信息，当前选中的素材被保存并发布到微信公众号上");

            FollowedAutoReplyPage.AddAutoReplyText("hello，谢谢关注");
            FollowedAutoReplyPage.AddAutoReplyNews(FollowedAutoReplyElement.NewsChoose);
            FollowedAutoReplyPage_Weibo.AddAutoReplyImage("Capture.PNG");      
            FollowedAutoReplyPage_Weibo.AddAutoReplyVoice("秋天不回来.amr");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.UnFollow();
            Mobile_Weibo_Utility.Follow();

            MobileAndroidDriver.GetScreenshot(filePath, "同时添加所有回复素材，video会上传至微信平台");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAudio, "秋天不回来.amr"), "添加视频回复");
        }

        [TestCategory("FollowedAutoReply_Weibo")]
        [TestCategory("FollowedAuto_Reply_NoMaterial_Tips")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "当没有有图文素材的时候，检查图片消息界面是否显示正确")]
        public void FollowedAuto_Reply_NoMaterial_Tips_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\当没有有图文素材的时候，检查图片消息界面是否显示正确");
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Account_Arrow_Down);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.Logout);
            LoginPage.LoginWithPhoneNumber("13269120258");
            Thread.Sleep(10 * 1000);
            MobileAndroidDriver.AndroidMmsInitialize();
            Mobile_WeChat_Utility.GetLoginCode();

            HomePage.ClickWeChatApp("XiaoIceTest");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabnews);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.NoMaterial_Tip, "没有同步到素材，请去往微信后台添加。新添加素材最多需15分钟同步到本地。"));
        }

        [TestCategory("FollowedAutoReply_Weibo")]
        [TestCategory("FollowedAuto_Reply_Delete_null")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "当回复素材（文本/图文/图片/语音 ）为空的时候，点击“删除回复”")]
        public void FollowedAuto_Reply_Delete_null_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\当回复素材（文本图文图片语音 ）为空的时候，点击“删除回复”");

            Thread.Sleep(10 * 1000);
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
