﻿using Common;
using Mobile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal;
using Portal.Pages;
using System.Threading;
using Mobile;
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests
{
    [TestClass]
    public class FaceRankingTest : PortalTestInit
    {
        [TestInitialize]
        public void IntiFaceRanking()
        {
            WeChatManagermentPage.GoToCS_Skill_Page();
            FaceRankingPage.ClickFaceRanking();
            Utility.TurnOn();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            if (!Utility.IsAt(MenuElement.FaceRankingMenu, "拼颜值"))
            {
                MenuPage.DeleteMenuItem();
                WeChatManagermentPage.GoToCS_Skill_Page();
                FaceRankingPage.ClickFaceRanking();
                string link = FaceRankingPage.CopyLink();
                FaceRankingPage.CopyAlertConfirm();
                WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
                MenuPage.AddMenu("拼颜值");
                MenuPage.AddMenu_Link_Wait(link);
                WeChatManagermentPage.GoToCS_Skill_Page();
                FaceRankingPage.ClickFaceRanking();
            }
            else
            {
                WeChatManagermentPage.GoToCS_Skill_Page();
                FaceRankingPage.ClickFaceRanking();
            }

        }

        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("FaceRanking_BVT")]
        [TestProperty("description", "3.是否可以正常开启'拼颜值'功能")]
        public void FaceRanking_TurnOn()
        {            
            //Go to AI Page
            Assert.IsTrue(Utility.IsTurnOn(),"拼颜值正确开启");
            string filePath=PortalChromeDriver.CreateFolder(@"拼颜值\3.是否可以正常开启'拼颜值'功能");
            PortalChromeDriver.TakeScreenShot(filePath,"拼颜值正确开启");
            Assert.IsTrue(Utility.IsAt(FaceRankingElement.SkillSetting),"技能设置是否正确显示");
            PortalChromeDriver.TakeScreenShot(filePath, "技能设置是否正确显示");
            Assert.IsTrue(Utility.IsAt(FaceRankingElement.cs_skilldetail_copiable), "技能链接是否生成");
            PortalChromeDriver.TakeScreenShot(filePath, "技能链接是否生成");

            Utility.BackToAllSkill();
            Assert.IsTrue(Utility.IsAt(FaceRankingElement.IsTurnOn_AllSkillPage, "（已开启）"), "返回技能插件页面，拼颜值是否开通");
        }
        
        [TestMethod]
        [TestCategory("FaceRanking_BVT")]
        [TestCategory("BVT")]
        [TestProperty("description", "4.检查复制的链接是否可以设置到菜单里;5检查在手机端”拼颜值“功能是否可以正常使用；16测试结果是否可以分享")]
        public void FaceRanking_Link_Available()
        {
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.FollowWeChatOffcialAccount();
            //拼颜值功能是否正常使用
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\5.检查在手机端”拼颜值“功能是否可以正常使用");
            FaceRankingMobilePage_WeChat.ClickFaceRanking();

            FaceRankingMobilePage_WeChat.FaceRankingFromFile(SecretRelationshipTest.美女美女);
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示描述语");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语");

            //分享出去后是否能正常打开
            filePath = PortalChromeDriver.CreateFolder(@"拼颜值\16.测试结果是否可以分享");
            FaceRankingMobilePage_WeChat.ShareToSomeOne();
            FaceRankingMobilePage_WeChat.BackWards();
            FaceRankingMobilePage_WeChat.BackWards();
            FaceRankingMobilePage_WeChat.BackWards();

            FaceRankingMobilePage_WeChat.CheckLinkAvailable();
            MobileAndroidDriver.GetScreenshot(filePath, "分享出去后是否能正常打开");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "分享出去后是否能正常打开");

            //分享之后能否正常使用
            FaceRankingMobilePage_WeChat.FaceRankingFromFile(SecretRelationshipTest.美女美女);
            MobileAndroidDriver.GetScreenshot(filePath, "分享出去后是否能正常使用");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "分享出去后是否能正常使用");

            //再次分享后是否正常打开
            FaceRankingMobilePage_WeChat.ShareToSomeOne();
            FaceRankingMobilePage_WeChat.CheckLinkAvailable();
            MobileAndroidDriver.GetScreenshot(filePath, "第二次分享出去后是否能正常打开");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "分享出去后是否能正常打开");
            //二次分享之后能否正常使用
            FaceRankingMobilePage_WeChat.FaceRankingFromFile(SecretRelationshipTest.美女美女);
            MobileAndroidDriver.GetScreenshot(filePath, "第二次分享出去后是否能正常使用");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "第二次分享出去后是否能正常使用");
        }

        [TestMethod]
        [TestCategory("FaceRanking_BVT")]
        [TestCategory("BVT")]
        [TestProperty("description", "9.检查上传明星图片的效果")]
        public void FaceRanking_Celebrity()
        {
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.FollowWeChatOffcialAccount(); 
            FaceRankingMobilePage_WeChat.ClickFaceRanking(); 
            FaceRankingMobilePage_WeChat.FaceRankingFromFile("mmexport1489570800142.jpg");
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\9.检查上传明星图片的效果");
            MobileAndroidDriver.GetScreenshot(filePath,"9.检查上传明星图片的效果");

            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment,"杨洋"), "未显示明星名字，当前case为林丹");
        }


        [TestMethod]
        [TestCategory("FaceRanking_BVT")]
        [TestCategory("BVT")]
        [TestProperty("description", "10.检查上传政治人物图片的效果")]
        public void FaceRanking_Political()
        {
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.FollowWeChatOffcialAccount();
            FaceRankingMobilePage_WeChat.ClickFaceRanking();
            FaceRankingMobilePage_WeChat.FaceRankingFromFile("mmexport1489570645729.jpg");
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\10.检查上传政治人物图片的效果");
            MobileAndroidDriver.GetScreenshot(filePath, "10.检查上传政治人物图片的效果");
            Assert.IsFalse(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment, "李克强"), "Comment里不出现人名，不出现评分");
            Assert.IsFalse(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment, "公众号颜值"), "Comment不出现评分");
        }

        [TestMethod]
        [TestCategory("FaceRanking_BVT")]
        [TestCategory("BVT")]
        [TestProperty("description", "11.检查上传非人物图片的效果")]
        public void FaceRanking_NoneHuman()
        {
            MobileAndroidDriver.AndroidInitialize();
                Mobile_WeChat_Utility.FollowWeChatOffcialAccount();
            FaceRankingMobilePage_WeChat.ClickFaceRanking(); 
            FaceRankingMobilePage_WeChat.FaceRankingFromFile("mmexport1489570865737.jpg");
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\11.检查上传非人物图片的效果");
            MobileAndroidDriver.GetScreenshot(filePath, "11.检查上传非人物图片的效果");
            Assert.IsFalse(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment, "公众号颜值"), "Comment不出现评分");
        }

        [TestMethod]
        [TestCategory("FaceRanking")]
        [TestProperty("description", "12.检查多次上传测试后，平均值是否被拉高或拉低了")]
        public void FaceRanking_ChangeTheAverage()
        {
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.FollowWeChatOffcialAccount();
            FaceRankingMobilePage_WeChat.ClickFaceRanking();
            double before1 =0;
            double after1 = 0;
            double before2 = 0;
            double after2 = 0;
            double before3 = 0;
            double after3 = 0;
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\12.检查多次上传测试后，平均值是否被拉高或拉低了");
            FaceRankingMobilePage_WeChat.FaceRankingFromFile(SecretRelationshipTest.美女美女);
            FaceRankingMobilePage_WeChat.Getfraction(ref before1, ref after1);
            MobileAndroidDriver.GetScreenshot(filePath, "第一次上传");
            FaceRankingMobilePage_WeChat.BackWards();
            FaceRankingMobilePage_WeChat.ClickFaceRanking();
            FaceRankingMobilePage_WeChat.FaceRankingFromFile(SecretRelationshipTest.美女美女);
            FaceRankingMobilePage_WeChat.Getfraction(ref before2, ref after2);
            MobileAndroidDriver.GetScreenshot(filePath, "第二次上传");
            FaceRankingMobilePage_WeChat.BackWards();
            FaceRankingMobilePage_WeChat.ClickFaceRanking();
            FaceRankingMobilePage_WeChat.FaceRankingFromFile(SecretRelationshipTest.美女美女);
            FaceRankingMobilePage_WeChat.Getfraction(ref before3, ref after3);
            MobileAndroidDriver.GetScreenshot(filePath, "第三次上传");
            Assert.IsTrue(before1<=after1 && before2<=after2 && before3 <= after3);
            Assert.IsTrue(after1 == before2 && after2== before3);
        }

        [TestMethod]
        [TestCategory("FaceRanking_BVT")]
        [TestCategory("BVT")]
        [TestProperty("description", "14.检查是否可以正常关闭”拼颜值“的功能;19.是否可以停用'拼颜值'功能")]
        public void FaceRanking_TurnOff()
        {
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.FollowWeChatOffcialAccount();
            FaceRankingMobilePage_WeChat.ClickFaceRanking();
            FaceRankingMobilePage_WeChat.FaceRankingFromFile(SecretRelationshipTest.美男美女);
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\14.检查是否可以正常关闭”拼颜值“的功能");
            MobileAndroidDriver.GetScreenshot(filePath, "关闭前拼颜值正常使用，图片显示描述语");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "关闭前拼颜值正常使用，图片显示描述语");      
            //停用拼颜值
            Utility.TurnOff();;
            string turnOffPath = PortalChromeDriver.CreateFolder(@"拼颜值\19.是否可以停用'拼颜值'功能");
            PortalChromeDriver.TakeScreenShot(turnOffPath, "Portal是否能正常关闭拼颜值");          
            Assert.IsTrue(!Utility.IsTurnOn(), "Portal是否能正常关闭拼颜值");
           

            FaceRankingMobilePage_WeChat.BackWards();           
            FaceRankingMobilePage_WeChat.ClickFaceRanking();
            MobileAndroidDriver.GetScreenshot(filePath, "关闭拼颜值技能后H5端是否能正常使用");
            Assert.IsFalse(Mobile_WeChat_Utility.IsAt(Mobile.UIElement.FaceRankingMobileElement.AccountFaceRanking), "关闭拼颜值技能后H5端是否能正常使用");
        }

        [TestMethod]
        [TestCategory("FaceRanking_BVT")]
        [TestCategory("BVT")]
        [TestProperty("description", "17.检查手机端拼颜值页面下面的二位码是否可以正常使用")]
        public void FaceRanking_QRCode_Available()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\检查手机端拼颜值页面下面的二位码是否可以正常使用");
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.FollowWeChatOffcialAccount();
            FaceRankingMobilePage_WeChat.ClickFaceRanking();

            FaceRankingMobilePage_WeChat.ClickQRCode();
            MobileAndroidDriver.GetScreenshot(filePath, "点击二维码是否进入公众号");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerName(Mobile.UIElement.FaceRankingMobileElement.Menuitem));
            FaceRankingMobilePage_WeChat.ClickFaceRanking();
            FaceRankingMobilePage_WeChat.FaceRankingFromFile(SecretRelationshipTest.美男美女);
            MobileAndroidDriver.GetScreenshot(filePath, "二维码进去公众号后是否能正常使用拼颜值");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "二维码进去公众号后是否能正常使用拼颜值");
        }

        [TestMethod]
        [TestCategory("FaceRanking_BVT")]
        [TestCategory("BVT")]
        [TestCategory("1")]
        [TestProperty("description", "检查输入以下trigger，是否会触发拼颜值功能：")]
        public void FaceRanking_Trigger()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\检查输入以下trigger，是否会触发拼颜值功能：");
            Utility.TurnOff();
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.FollowWeChatOffcialAccount();
            Mobile_WeChat_Utility.ClearAllRecord();
            Mobile_WeChat_Utility.SendMessageWithMenu("拼颜值");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue( Mobile_WeChat_Utility.GetLatestMessage("关闭"));
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if(MobileAndroidDriver.androidDriver!=null)
            MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
