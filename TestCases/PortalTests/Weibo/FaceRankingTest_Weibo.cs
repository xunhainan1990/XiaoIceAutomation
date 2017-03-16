using Common;
using CSH5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal;
using Portal.Pages;
using Portal.UIElement;
using Mobile;
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests.Weibo
{
    //[TestClass]
    public class FaceRankingTest_Weibo:PortalTestInit_Weibo
    {

        [TestInitialize]
        public void IntiFaceRanking()
        {
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.CS_SKills_Weibo);
            FaceRankingPage.ClickFaceRanking();
            Utility.TurnOn();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            if (!Utility.IsAt(MenuElement.FaceRankingMenu, "拼颜值"))
            {
                MenuPage.DeleteMenuItem();
                PortalChromeDriver.ClickElementPerXpath(DocChatElement.CS_SKills_Weibo);
                FaceRankingPage.ClickFaceRanking();
                string link = FaceRankingPage.CopyLink();
                FaceRankingPage.CopyAlertConfirm();
                WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
                MenuPage.AddMenu("拼颜值");
                MenuPage.AddMenu_Link_Wait(link);
                PortalChromeDriver.ClickElementPerXpath(DocChatElement.CS_SKills_Weibo);
                FaceRankingPage.ClickFaceRanking();
            }
            else
            {
                PortalChromeDriver.ClickElementPerXpath(DocChatElement.CS_SKills_Weibo);
                FaceRankingPage.ClickFaceRanking();
            }

        }
        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("FaceRanking_BVT_Weibo")]
        [TestProperty("description", "3.是否可以正常开启'拼颜值'功能")]
        public void FaceRanking_TurnOn_Weibo()
        {
            //Go to AI Page
            Assert.IsTrue(Utility.IsTurnOn(), "拼颜值正确开启");
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\3.是否可以正常开启'拼颜值'功能");
            PortalChromeDriver.TakeScreenShot(filePath, "拼颜值正确开启");
            Assert.IsTrue(Utility.IsAt(FaceRankingElement.SkillSetting), "技能设置是否正确显示");
            PortalChromeDriver.TakeScreenShot(filePath, "技能设置是否正确显示");
            Assert.IsTrue(Utility.IsAt(FaceRankingElement.cs_skilldetail_copiable), "技能链接是否生成");
            PortalChromeDriver.TakeScreenShot(filePath, "技能链接是否生成");

            Utility.BackToAllSkill();
            Assert.IsTrue(Utility.IsAt(FaceRankingElement.IsTurnOn_AllSkillPage, "（已开启）"), "返回技能插件页面，拼颜值是否开通");
        }

        [TestMethod]
        [TestCategory("FaceRanking_BVT_Weibo")]
        [TestCategory("BVT")]
        [TestProperty("description", "4.检查复制的链接是否可以设置到菜单里;5检查在手机端”拼颜值“功能是否可以正常使用；16测试结果是否可以分享")]
        public void FaceRanking_Link_Available_Weibo()
        {
            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            //拼颜值功能是否正常使用
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\5.检查在手机端”拼颜值“功能是否可以正常使用");
            FaceRankingMobilePage_Weibo.ClickFaceRanking();
            FaceRankingMobilePage_Weibo.FaceRankingFromFile("mmexport1481102839261.jpg");
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示描述语");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(CSH5.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语");

            //分享出去后是否能正常打开
            filePath = PortalChromeDriver.CreateFolder(@"拼颜值\16.测试结果是否可以分享");
            FaceRankingMobilePage_Weibo.ShareToWeibo();

            FaceRankingMobilePage_Weibo.CheckLinkAvailable();
            MobileAndroidDriver.GetScreenshot(filePath, "分享出去后是否能正常打开");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(CSH5.UIElement.FaceRankingMobileElement.Comment), "分享出去后是否能正常打开");

            //分享之后能否正常使用
            FaceRankingMobilePage_WeChat.FaceRankingFromFile("mmexport1481102839261.jpg");
            MobileAndroidDriver.GetScreenshot(filePath, "分享出去后是否能正常使用");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(CSH5.UIElement.FaceRankingMobileElement.Comment), "分享出去后是否能正常使用");

            //再次分享后是否正常打开
            FaceRankingMobilePage_WeChat.ShareToSomeOne();
            FaceRankingMobilePage_WeChat.CheckLinkAvailable();
            MobileAndroidDriver.GetScreenshot(filePath, "第二次分享出去后是否能正常打开");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(CSH5.UIElement.FaceRankingMobileElement.Comment), "分享出去后是否能正常打开");
            //二次分享之后能否正常使用
            FaceRankingMobilePage_WeChat.FaceRankingFromFile("mmexport1481102839261.jpg");
            MobileAndroidDriver.GetScreenshot(filePath, "第二次分享出去后是否能正常使用");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(CSH5.UIElement.FaceRankingMobileElement.Comment), "第二次分享出去后是否能正常使用");
        }
    }
}
