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
        [TestCategory("FollowedAutoReply")]
        [TestCategory("AddText_FollowedAutoReply")]
        [TestMethod]
        [TestProperty("description", "添加文字关键词回复")]
        public void FollowedAutoReply_AddText()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加文字关键词回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();

            FollowedAutoReplyPage.AddAutoReplyText("hello，谢谢关注");
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath,"Portal添加一条回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "hello，谢谢关注"));

            //MobileAndroidDriver.AndroidInitializeWithoutChangingKeyboard();
            //MobileH5.UnFollowWeChatOffcialAccount();
            //MobileH5.FollowWeChatOffcialAccount();
            //MobileAndroidDriver.GetScreenshot(filePath,"H5添加一条回复");
            //Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("hello，谢谢关注")));
            //MobileH5.BackButtonClick();

            FollowedAutoReplyPage.Delete();
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "Portal删除一条回复");
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "hello，谢谢关注"));
        

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
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();

            FollowedAutoReplyPage.AddAutoReplyText("法轮功");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "添加非法字符");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.Alert_Failure), "抱歉，您的回复中包含了不当内容，请修改后重新保存。");
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Alert_Failure_Confirm);
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_AddText_href")]
        [TestMethod]
        [TestProperty("description", "添加超链接")]
        public void FollowedAutoReply_AddText_href()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\超链接");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();

            FollowedAutoReplyPage.AddAutoReplyText("<a href='http://www.sina.com.cn'>新浪</a>");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "超链接");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "新浪"));           
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_AddText_script")]
        [TestMethod]
        [TestProperty("description", "添加脚本")]
        public void FollowedAutoReply_AddText_script()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\超链接");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
            FollowedAutoReplyPage.AddAutoReplyText("<script type='text/javascript'>document.write('< h1 > Hello World!</ h1 >')</script>");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "添加脚本");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "<script type='text/javascript'>document.write('< h1 > Hello World!</ h1 >')</script>"));          
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_AddText_href_Image")]
        [TestMethod]
        [TestProperty("description", "图片")]
        public void FollowedAutoReply_AddText_href_Image()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\是否能打开一张图片");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();

            FollowedAutoReplyPage.AddAutoReplyText("<a href='http://www.sinaimg.cn/dy/deco/2013/0604/loader.gif'>图片</a>");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "图片");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "图片"));
        }

        //[TestCategory("FollowedAutoReply")]
        //[TestCategory("AddText_FollowedAutoReply")]
        //[TestMethod]
        //[TestProperty("description", "添加超链接")]
        //public void AddText_Multi_href_script_FollowedAutoReply()
        //{
        //    string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\超链接");
        //    WeChatManagermentPage.GoTo_AutoReply_Page();
        //    FollowedAutoReplyPage.Delete();

        //    FollowedAutoReplyPage.AddAutoReplyText("<a href='http://www.sina.com.cn'>新浪</a><a href='http://www.sina.com.cn'>新浪</a><a href='http://www.sina.com.cn'>新浪</a><a href='http://www.sina.com.cn'>新浪</a><a href='http://www.sina.com.cn'>新浪</a><a href='http://www.sina.com.cn'>新浪</a><a href='http://www.sina.com.cn'>新浪</a><a href='http://www.sina.com.cn'>新浪</a>");
        //    Thread.Sleep(2 * 1000);
        //    PortalChromeDriver.TakeScreenShot(filePath, "超链接");
        //    Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "新浪"));
        //}

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_AddImageAndText")]
        [TestMethod]
        [TestProperty("description", "添加图文回复")]
        public void FollowedAutoReply_AddNews()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图文回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
            FollowedAutoReplyPage.AddAutoReplyNews();
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "jdw"));

            MobileAndroidDriver.AndroidInitializeWithoutChangingKeyboard();
            MobileH5.UnFollowWeChatOffcialAccount();
            MobileH5.FollowWeChatOffcialAccount();
            Thread.Sleep(5 * 1000);
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("jdw")));

            FollowedAutoReplyPage.Delete();
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "jdw"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_AddImageAndText_NextPage")]
        [TestMethod]
        [TestProperty("description", "添加图文翻页")]
        public void FollowedAutoReply_AddImageAndText_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图文回复_翻页");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
            FollowedAutoReplyPage.AddAutoReply_News_NextPage();
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "e"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("AddImageAndText_FollowedAutoReply_NextPage")]
        [TestMethod]
        [TestProperty("description", "添加图文翻页")]
        public void FollowedAutoReply_AddImageAndText_NextPageInput()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图文回复_翻页");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
            FollowedAutoReplyPage.AddAutoReply_News_NextPageInput();
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "e"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("AddText_AutoReply")]
        [TestMethod]
        [TestProperty("description", "添加图片回复")]
        public void FollowedAutoReply_AddImage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图片回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
            FollowedAutoReplyPage.AddAutoReplyImage();
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImage, "1114.png"));

            MobileAndroidDriver.AndroidInitializeWithoutChangingKeyboard();
            //MobileAndroidDriver.AndroidInitialize();
           

            MobileH5.UnFollowWeChatOffcialAccount();
            MobileH5.FollowWeChatOffcialAccount();
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(MobileAndroidDriver.IsAt("//android.widget.FrameLayout[contains(@resource-id,'com.tencent.mm:id/a48')]",""));

            FollowedAutoReplyPage.Delete();
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedImage, "1114.png"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("AddImageAndText_FollowedAutoReply_NextPage")]
        [TestMethod]
        [TestProperty("description", "添加图文翻页")]
        public void FollowedAutoReply_AddImage_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图文回复_翻页");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
            FollowedAutoReplyPage.AddAutoReply_Image_NextPage();
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImage, "fefwe.jpg"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("AddImageAndText_FollowedAutoReply_NextPage")]
        [TestMethod]
        [TestProperty("description", "添加图文翻页")]
        public void FollowedAutoReply_AddImage_NextPageInput()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加图文回复_翻页");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
            FollowedAutoReplyPage.AddAutoReply_Image_NextPage();
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImage, "fefwe.jpg"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("AddText_AutoReply")]
        [TestMethod]
        [TestProperty("description", "添加视频回复")]
        public void FollowedAutoReply_AddVideo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\添加视频回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
            FollowedAutoReplyPage.AddAutoReplyVideo(FollowedAutoReplyElement.VideoEdit);
            PortalChromeDriver.TakeScreenShot(filePath, "添加");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedVideo, "测试视频9"));
            MobileAndroidDriver.AndroidInitializeWithoutChangingKeyboard();
            MobileH5.UnFollowWeChatOffcialAccount();
            MobileH5.FollowWeChatOffcialAccount();
            Thread.Sleep(5 * 1000);
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("测试视频9")));

            FollowedAutoReplyPage.Delete();
            Assert.IsFalse(Utility.IsAt(FollowedAutoReplyElement.AddedVideo, "测试视频9"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("AddText_FollowedAutoReply")]
        [TestMethod]
        [TestProperty("description", "修改文字回复")]
        public void FollowedAutoReply_EditText()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\修改文字回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();

            FollowedAutoReplyPage.AddAutoReplyText("hello，谢谢关注");
            Thread.Sleep(2 * 1000);
            FollowedAutoReplyPage.EditAutoReplyText("我是更改的文字回复");
            Thread.Sleep(2*1000);
            PortalChromeDriver.TakeScreenShot(filePath, "修改文字回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedAutoReply, "hello，谢谢关注我是更改的文字回复"));         
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("EditImageAndText_FollowedAutoReply")]
        [TestMethod]
        [TestProperty("description", "修改图文回复")]
        public void FollowedAutoReply_EditNews()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\修改图文回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();

            FollowedAutoReplyPage.AddAutoReplyNews();
            Thread.Sleep(2 * 1000);
            FollowedAutoReplyPage.Delete_Image();
            Thread.Sleep(2 * 1000);
            FollowedAutoReplyPage.AddAutoReply_News_NextPage();
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "修改图文回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImageAndText, "e"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_EditImage_NextPage")]
        [TestMethod]
        [TestProperty("description", "添加图片翻页")]
        public void FollowedAutoReply_EditImage_NextPage()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\修改图片回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();

            FollowedAutoReplyPage.AddAutoReplyImage(); ;
            Thread.Sleep(2 * 1000);
            FollowedAutoReplyPage.Delete_Image();
            Thread.Sleep(2 * 1000);
            FollowedAutoReplyPage.AddAutoReply_Image_NextPage();
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "修改图片回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedImage, "fefwe.jpg"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_EditImage_NextPage")]
        [TestMethod]
        [TestProperty("description", "添加图片翻页")]
        public void FollowedAutoReply_EditVedio()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\修改图片回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();

            FollowedAutoReplyPage.AddAutoReplyVideo(FollowedAutoReplyElement.VideoChoose);
            Thread.Sleep(2 * 1000);
            FollowedAutoReplyPage.Delete_Image();
            Thread.Sleep(2 * 1000);
            FollowedAutoReplyPage.AddAutoReplyVideo(FollowedAutoReplyElement.VideoEdit);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "修改音频回复");
            Assert.IsTrue(Utility.IsAt(FollowedAutoReplyElement.AddedVideo, "测试音频9"));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAutoReply_EditImage_NextPage")]
        [TestMethod]
        [TestProperty("description", "同时添加所有回复素材，video会上传至微信平台")]
        public void FollowedAutoReply_AddedAll_VideoFirst()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\同时添加所有回复素材，video会上传至微信平台");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();

            FollowedAutoReplyPage.AddAutoReplyText("hello，谢谢关注");
            FollowedAutoReplyPage.AddAutoReplyImage();
            FollowedAutoReplyPage.AddAutoReplyNews();
            FollowedAutoReplyPage.AddAutoReplyVideo(FollowedAutoReplyElement.VideoEdit);

            MobileAndroidDriver.AndroidInitializeWithoutChangingKeyboard();
            MobileH5.UnFollowWeChatOffcialAccount();
            MobileH5.FollowWeChatOffcialAccount();

            MobileAndroidDriver.GetScreenshot(filePath, "同时添加所有回复素材，video会上传至微信平台");
            Assert.IsTrue((MobileH5.GetLatestMessageWithMenu().Text.Contains("测试视频")));
        }

        [TestCategory("FollowedAutoReply")]
        [TestCategory("FollowedAuto_Reply_NoMaterial_Tips")]
        [TestMethod]
        [TestProperty("description", "当没有有图文素材的时候，检查图片消息界面是否显示正确")]
        public void FollowedAuto_Reply_NoMaterial_Tips()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自定义菜单\当没有有图文素材的时候，检查图片消息界面是否显示正确");
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
        [TestMethod]
        [TestProperty("description", "当回复素材（文本/图文/图片/语音 ）为空的时候，点击“删除回复”")]
        public void FollowedAuto_Reply_Delete_null()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"被关注自动回复\当回复素材（文本/图文/图片/语音 ）为空的时候，点击“删除回复”");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            FollowedAutoReplyPage.Delete();
            FollowedAutoReplyPage.Delete();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(MenuElement.Notification, "空菜单不能删除"));
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
