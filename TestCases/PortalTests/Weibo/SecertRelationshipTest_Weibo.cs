using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mobile;
using Portal;
using Portal.Pages;
using Portal.UIElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.Pages;
using XiaoIcePortal.Pages.Weibo;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests.Weibo
{
    [TestClass]
    public class SecertRelationshipTest_Weibo : PortalTestInit_Weibo
    {
        public static int count = 0;
        public static string 美男美女 = "mmexport1489564591824.jpg";
        public static string 美女丑男 = "mmexport1489565195576.jpg";
        public static string 丑女丑女 = "mmexport1489565909223.jpg";
        public static string 年轻男少男 = "mmexport1489566281487.jpg";
        public static string 年轻男小孩 = "mmexport1489566417815.jpg";
        public static string 美女美女 = "mmexport1489566595596.jpg";
        public static string 小孩小孩 = "mmexport1489566669941.jpg";
        public static string 一男一女 = "mmexport1489566194229.jpg";
        string filePath = string.Empty;

        [TestInitialize]
        public void IntiSecretRelationship()
        {
            try {
                PortalChromeDriver.ClickElementPerXpath(DocChatElement.CS_SKills_Weibo);
                FaceRankingPage.ClickFaceRanking();
                Utility.TurnOn();
                WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
                if (!Utility.IsAt(MenuElement.FaceRankingMenu, "关系识别"))
                {
                    MenuPage.DeleteMenuItem();
                    PortalChromeDriver.ClickElementPerXpath(DocChatElement.CS_SKills_Weibo);
                    SecretRelationshipPage.ClickSecretRelationship_Weibo();
                    SecretRelationshipPage.TurnOn();
                    string link = FaceRankingPage.CopyLink();
                    FaceRankingPage.CopyAlertConfirm();
                    WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
                    MenuPage.AddMenu("关系识别");
                    MenuPage.AddMenu_Link_Wait(link);
                    PortalChromeDriver.ClickElementPerXpath(DocChatElement.CS_SKills_Weibo);
                    SecretRelationshipPage.ClickSecretRelationship_Weibo();
                }
                else
                {
                    PortalChromeDriver.ClickElementPerXpath(DocChatElement.CS_SKills_Weibo);
                    SecretRelationshipPage.ClickSecretRelationship_Weibo();
                }

            }
            catch (Exception e)
            {
                LoginPage_Weibo.AddWeiboAccount();
                HomePage.ClickWeChatApp("啊_荀");
                PortalChromeDriver.ClickElementPerXpath(DocChatElement.CS_SKills_Weibo);
                FaceRankingPage.ClickFaceRanking();
                Utility.TurnOn();
                WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
                if (!Utility.IsAt(MenuElement.FaceRankingMenu, "关系识别"))
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

        }


        [TestCategory("SecretRelationship_BVT")]
        [TestCategory("Can_secretRelationship_TurnOn")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "1.检查'关系识别'功能是否显示在技能插件的页面上;3.是否可以正常开启'关系识别'功能")]
        public void Can_secretRelationship_TurnOn()
        {
            Utility.TurnOff();
            Thread.Sleep(2 * 1000);
            if (!Utility.IsTurnOn())
            {
                PortalChromeDriver.ClickElementPerXpath(CommonElement.TurnOnAndOFF);
            }
            Thread.Sleep(2 * 1000);
            SecretRelationshipPage.SetNow();
            filePath = PortalChromeDriver.CreateFolder(@"关系识别\3.是否可以正常开启'关系识别'功能");
            PortalChromeDriver.TakeScreenShot(filePath, @"点击奖项设置，是否可以正常开启'关系识别'功能");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.IsTurnOff, "停用"), "点击奖项设置，是否可以正常开启'关系识别'功能");
            Utility.TurnOff();
            Thread.Sleep(1 * 1000);
            if (!Utility.IsTurnOn())
            {
                PortalChromeDriver.ClickElementPerXpath(CommonElement.TurnOnAndOFF);
            }
            Thread.Sleep(2 * 1000);
            SecretRelationshipPage.SetLater();
            PortalChromeDriver.TakeScreenShot(filePath, @"点击稍后设置，是否可以正常开启'关系识别'功能");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.IsTurnOff, "停用"), "点击稍后设置，是否可以正常开启'关系识别'功能");
            Utility.TurnOff();
            Thread.Sleep(2 * 1000);
            if (!Utility.IsTurnOn())
            {
                PortalChromeDriver.ClickElementPerXpath(CommonElement.TurnOnAndOFF);
            }
            Thread.Sleep(2 * 1000);
            SecretRelationshipPage.CancleButtonClick();
            PortalChromeDriver.TakeScreenShot(filePath, @"点击取消按钮，是否可以正常开启'关系识别'功能");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.IsTurnOff, "停用"), "点击取消按钮，是否可以正常开启'关系识别'功能");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "4.检查'技能设置'页面的功能按钮是否正常工作;5.复制的link是否可以打开;10.是否可以正常使用'关系识别'功能（检查portal 和 手机端）;11.可以上传照片测试;12.测试结果是否可以分享;13.分享后是否可以返回到关系识别页面")]
        public void Can_secretRelationship_ShareToWeibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\4.检查'技能设置'页面的功能按钮是否正常工作");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "4"), "100", "100");


            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            Utility.BackToAllSkill();
            PortalChromeDriver.TakeScreenShot(filePath, "返回技能插件页面，拼颜值是否开通");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.IsTurnOn_AllSkillPage, "（已开启）"), "返回技能插件页面，拼颜值是否开通");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.UnFollow();
            Mobile_Weibo_Utility.Follow();

            //HI上关系识别正常使用
            string filePath5 = PortalChromeDriver.CreateFolder(@"关系识别\5.复制的link是否可以打开");
            string filePath10 = PortalChromeDriver.CreateFolder(@"关系识别\10.是否可以正常使用'关系识别'功能");
            string filePath11 = PortalChromeDriver.CreateFolder(@"关系识别\11.可以上传照片测试");
            ChoosePhotoAndCheck(美女美女);
            MobileAndroidDriver.GetScreenshot(filePath5, "图片显示是否正确");
            MobileAndroidDriver.GetScreenshot(filePath10, "是否可以正常使用'关系识别'功能");
            MobileAndroidDriver.GetScreenshot(filePath11, "是否可以正常使用'关系识别'功能");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_4"), "奖励是否显示");


            filePath = PortalChromeDriver.CreateFolder(@"关系识别\13.分享后是否可以返回到关系识别页面");
            FaceRankingMobilePage_Weibo.ShareToWeibo();
            MobileAndroidDriver.GetScreenshot(filePath, "分享后回到关系识别页面");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerName("黑科技揭秘：合影中的秘密！"), "分享后回到关系识别页面");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "4.检查'技能设置'页面的功能按钮是否正常工作;5.复制的link是否可以打开;10.是否可以正常使用'关系识别'功能（检查portal 和 手机端）;11.可以上传照片测试;12.测试结果是否可以分享;13.分享后是否可以返回到关系识别页面")]
        public void Can_secretRelationship_ShareToWechat()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\4.检查'技能设置'页面的功能按钮是否正常工作");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "4"), "100", "100");


            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            Utility.BackToAllSkill();
            PortalChromeDriver.TakeScreenShot(filePath, "返回技能插件页面，拼颜值是否开通");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.IsTurnOn_AllSkillPage, "（已开启）"), "返回技能插件页面，拼颜值是否开通");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.UnFollow();
            Mobile_Weibo_Utility.Follow();

            //HI上关系识别正常使用
            string filePath5 = PortalChromeDriver.CreateFolder(@"关系识别\5.复制的link是否可以打开");
            string filePath10 = PortalChromeDriver.CreateFolder(@"关系识别\10.是否可以正常使用'关系识别'功能");
            string filePath11 = PortalChromeDriver.CreateFolder(@"关系识别\11.可以上传照片测试");
            ChoosePhotoAndCheck(美女美女);
            MobileAndroidDriver.GetScreenshot(filePath5, "图片显示是否正确");
            MobileAndroidDriver.GetScreenshot(filePath10, "是否可以正常使用'关系识别'功能");
            MobileAndroidDriver.GetScreenshot(filePath11, "是否可以正常使用'关系识别'功能");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_4"), "奖励是否显示");

            filePath = PortalChromeDriver.CreateFolder(@"关系识别\13.分享后是否可以返回到关系识别页面");
            FaceRankingMobilePage_Weibo.ShareToWeChat();
            MobileAndroidDriver.GetScreenshot(filePath, "分享后回到关系识别页面");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语");

        }

        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "7.检查'奖项设置'页面的功能按钮是否正常工作(2)")]
        public void Can_secretRelationship_RewardSetting_Work2_BVT_WeiBo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\7.检查'奖项设置'页面的功能按钮是否正常工作(2)");

            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            Thread.Sleep(1 * 1000);
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.cs_awards_edit);
            PortalChromeDriver.ClickElementsPerClassName(secretRelationshipElement.cs_awards_checkbox);
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.cs_awards_edit_ongoing);
            PortalChromeDriver.TakeScreenShot(filePath, "提示正常");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.Awards_NotZeroTip, "发奖数量不能为0"), "发奖量能否为空");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.Awards_Rate_NotZeroTip, "中奖机率需大于0"), "中奖率能否为空");

            PortalChromeDriver.ClickElementsPerClassName(secretRelationshipElement.cs_awards_checkbox);
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.cs_awards_edit_ongoing);
            SecretRelationshipPage.InputAwardNumber("50", "50");
            Thread.Sleep(1 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "输入正常");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.Award1, "50"), "最高发奖量保存失败");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.AwardRate1, "50%"), "中奖几率保存失败");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "15.在没有设置奖项的情况下:上传一张单个人物的照片；34.在设置奖项的情况下:上传一张单个人物的照片")]
        public void Can_secretRelationship_Single_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\15.在没有设置奖项的情况下上传一张单个人物的照片");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            FaceRankingMobilePage_Weibo.ClickFaceRanking();
            FaceRankingMobilePage_Weibo.FaceRankingFromFile("mmexport1489570800142.jpg");
            Thread.Sleep(5 * 1000);

            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment, "杨洋"), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            Assert.IsFalse(Mobile_WeChat_Utility.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
            MobileAndroidDriver.androidDriver.Dispose();

            //设置中奖概率
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "1"), "100", "100");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            FaceRankingMobilePage_Weibo.ClickFaceRanking();
            FaceRankingMobilePage_Weibo.FaceRankingFromFile("mmexport1489570800142.jpg");
            Thread.Sleep(5 * 1000);
            filePath = PortalChromeDriver.CreateFolder(@"关系识别\34.在设置奖项的情况下上传一张单个人物的照片");
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            Assert.IsFalse(Mobile_WeChat_Utility.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "17.在没有设置奖项的情况下:上传一张政治人物图片；36.在设置奖项的情况下:上传一张政治人物图片")]
        public void Can_secretRelationship_Political_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\17.在没有设置奖项的情况下上传一张政治人物图片");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            FaceRankingMobilePage_Weibo.ClickFaceRanking();
            FaceRankingMobilePage_Weibo.FaceRankingFromFile("mmexport1489570645729.jpg");
            Thread.Sleep(5 * 1000);

            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            Assert.IsFalse(Mobile_WeChat_Utility.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
            //MobileAndroidDriver.androidDriver.Dispose();
            //设置中奖概率
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "1"), "100", "100");

            //MobileAndroidDriver.AndroidInitialize();
            //HIMobileH5.GetToTestAccount();
            FaceRankingMobilePage_Weibo.FaceRankingFromFile("mmexport1489570645729.jpg");
            Thread.Sleep(5 * 1000);
            filePath = PortalChromeDriver.CreateFolder(@"关系识别\36.在设置奖项的情况下上传一张政治人物图片");
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            Assert.IsFalse(Mobile_WeChat_Utility.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "18.在没有设置奖项的情况下:上传一张非人物图片；37.在设置奖项的情况下:上传一张非人物图片")]
        public void Can_secretRelationship_NoneHuman_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\18.在没有设置奖项的情况下上传一张非人物图片");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            FaceRankingMobilePage_Weibo.ClickFaceRanking();
            FaceRankingMobilePage_Weibo.FaceRankingFromFile("mmexport1489570865737.jpg");
            Thread.Sleep(5 * 1000);

            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            Assert.IsFalse(Mobile_WeChat_Utility.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");

            //设置中奖概率
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "1"), "100", "100");

            FaceRankingMobilePage_WeChat.FaceRankingFromFile("mmexport1489570865737.jpg");
            Thread.Sleep(5 * 1000);
            filePath = PortalChromeDriver.CreateFolder(@"关系识别\37.在设置奖项的情况下上传一张非人物图片");
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            Assert.IsFalse(Mobile_WeChat_Utility.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "20.是否可以获得“公众号最亲密恋人”奖项")]
        public void Can_secretRelationship_Couple_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\20.是否可以获得“公众号最亲密恋人”奖项");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            //设置
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "1"), "100", "100");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            ChoosePhotoAndCheck(美男美女);
            MobileAndroidDriver.GetScreenshot(filePath, "美男美女_公众号最亲密恋人");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id,"reward_25_1"), "奖励是否显示");

            FaceRankingMobilePage_Weibo.FaceRankingFromFile(一男一女);
            MobileAndroidDriver.GetScreenshot(filePath, "一男一女_公众号最亲密恋人");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示"); 
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_1"), "奖励是否显示");

            //ChoosePhotoAndCheck(丑男丑女);
            //MobileAndroidDriver.GetScreenshot(filePath, "丑男丑女_公众号最亲密恋人");
            //Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_1"), "奖励是否显示");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "21.是否可以获得“公众号最纯真友谊”奖项")]
        public void Can_secretRelationship_Friend_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\21.是否可以获得“公众号最纯真友谊”奖项");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "2"), "100", "100");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            ChoosePhotoAndCheck(美女丑男);
            MobileAndroidDriver.GetScreenshot(filePath, "美女丑男_公众号最纯真友谊");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_2"), "奖励是否显示");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "22.是否可以获得“公众号最佳亲子组合”奖项")]
        public void Can_secretRelationship_Parent_Child_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\22.是否可以获得“公众号最佳亲子组合”奖项");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "3"), "100", "100");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Thread.Sleep(5 * 1000);
            ChoosePhotoAndCheck(年轻男小孩);

            MobileAndroidDriver.GetScreenshot(filePath, "年轻男小孩_公众号最佳亲子组合");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_3"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(年轻女小孩);
            //Thread.Sleep(5 * 1000);
            //FaceRankingH5Page.FaceRankingFromFile(年轻女小孩);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_3"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(一家人小孩);
            //Thread.Sleep(5 * 1000);
            //FaceRankingH5Page.FaceRankingFromFile(一家人小孩);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_3"), "奖励是否显示");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "23.是否可以获得“公众号最佳姐妹淘”奖项")]
        public void Can_secretRelationship_Sisters_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\23.是否可以获得“公众号最佳姐妹淘”奖项");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "4"), "100", "100");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            ChoosePhotoAndCheck(美女美女);

            MobileAndroidDriver.GetScreenshot(filePath, "美女美女_公众号最佳姐妹淘");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_4"), "奖励是否显示");

            ChoosePhotoAndCheck(丑女丑女);
            MobileAndroidDriver.GetScreenshot(filePath, "丑女丑女_公众号最佳姐妹淘");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_4"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(年轻女中性男);
            //Thread.Sleep(5 * 1000);
            //FaceRankingH5Page.FaceRankingFromFile(年轻女中性男);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_4"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(年轻女少女);
            //Thread.Sleep(5 * 1000);
            //FaceRankingH5Page.FaceRankingFromFile(年轻女少女);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_4"), "奖励是否显示");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "24.是否可以获得“公众号最佳兄弟组合”奖项")]
        public void Can_secretRelationship_Brothers_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\24.是否可以获得“公众号最佳兄弟组合”奖项");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "5"), "100", "100");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            ChoosePhotoAndCheck(年轻男少男);

            MobileAndroidDriver.GetScreenshot(filePath, "年轻男少男_公众号最佳兄弟组合");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_5"), "奖励是否显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(美男中性女);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_5"), "奖励是否显示");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestCategory("Can_secretRelationship_Angle")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "25.是否可以获得“公众号最萌小天使”奖项")]
        public void Can_secretRelationship_Angle_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\25.是否可以获得“公众号最萌小天使”奖项");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "6"), "100", "100");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            ChoosePhotoAndCheck(小孩小孩, 6);

            MobileAndroidDriver.GetScreenshot(filePath, "小孩小孩_公众号最萌小天使");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_6"), "奖励是否显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "26.是否可以获得“公众号最高颜值组合”奖项")]
        public void Can_secretRelationship_GoodLook_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\26.是否可以获得“公众号最高颜值组合”奖项");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "7"), "100", "100");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            ChoosePhotoAndCheck(美女美女);

            MobileAndroidDriver.GetScreenshot(filePath, "美女美女公_众号最高颜值组合图片");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_7"), "奖励是否显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(美男美女);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_7"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(美男美男);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_7"), "奖励是否显示");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "26.是否可以获得“公众号最佳旅行拍档”奖项")]
        public void Can_secretRelationship_TravelPartners_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\是否可以获得“公众号最佳旅行拍档”奖项");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "8"), "100", "100");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            ChoosePhotoAndCheck(美女美女);

            MobileAndroidDriver.GetScreenshot(filePath, "美女美女公_众号最高颜值组合图片");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_7"), "奖励是否显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(美男美女);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_7"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(美男美男);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_7"), "奖励是否显示");
        }


        [TestCategory("SecretRelationship_BVT")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "是否可以获得“公众号最配阿哥阿妹”奖项")]
        public void Can_secretRelationship_Bro_Sis_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\26.是否可以获得“公众号最配阿哥阿妹”奖项");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "9"), "100", "100");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            ChoosePhotoAndCheck(一男一女);
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "美女美女公_众号最高颜值组合图片");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_7"), "奖励是否显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");

        }


        [TestCategory("SecretRelationship_BVT")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "是否可以获得“公众号最帅苗寨女婿”奖项")]
        public void Can_secretRelationship_MiaoZhai_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\是否可以获得“公众号最帅苗寨女婿”奖项");

            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "10"), "100", "100");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow(); ;

            ChoosePhotoAndCheck(一男一女);

            MobileAndroidDriver.GetScreenshot(filePath, "美女美女公_众号最高颜值组合图片");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_7"), "奖励是否显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "27.设置最高发奖数量为1,中奖机率为100%,检查发送第1张有效图片的时候就能中奖（所有奖项都试一遍）;28.设置最高发奖数量为1， 中奖机率为100%， 检查发送第2张有效图片的时候能否中奖（所有奖项都试一遍）")]
        public void Can_secretRelationship_1_100_Weibo()
        {

            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\27.设置最高发奖数量为1,中奖机率为100%,检查发送第1张有效图片的时候就能中奖（所有奖项都试一遍）");
            string filePath28 = PortalChromeDriver.CreateFolder(@"关系识别\28.设置最高发奖数量为1,中奖机率为100%.检查发送第2张有效图片的时候能否中奖（所有奖项都试一遍）");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            //设置奖励中奖概率
            for (int i = 1; i < 11; i++)
            {
                count = 0;
                PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
                SecretRelationshipPage.ClearAllAward();
                SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", i + ""), "1", "100");

                string file = string.Empty;
                switch (i)
                {
                    case 1:
                        file = 美男美女;
                        break;
                    case 2:
                        file = 美女丑男;
                        break;
                    case 3:
                        file = 年轻男小孩;
                        break;
                    case 4:
                        file = 美女美女;
                        break;
                    case 5:
                        file = 年轻男少男;
                        break;
                    case 6:
                        file = 小孩小孩;
                        break;
                    case 7:
                        file = 美女美女;
                        break;
                    case 8:
                        file = 美女美女;
                        break;
                    case 9:
                        file = 一男一女;
                        break;
                    case 10:
                        file = 一男一女;
                        break;
                }

                ChoosePhotoAndCheck(file, i);
                MobileAndroidDriver.GetScreenshot(filePath, file + i);
                Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
                Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
                //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_" + i), "奖励是否显示");
                //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
                //if(count<2)
                //{
                //    FaceRankingH5Page.BackWards();
                //    FaceRankingH5Page.ClickFaceRanking();
                //    FaceRankingH5Page.FaceRankingFromFile(file);
                //    Thread.Sleep(5 * 1000);
                //}
                FaceRankingMobilePage_WeChat.FaceRankingFromFile(file);
                Thread.Sleep(5 * 1000);
                MobileAndroidDriver.GetScreenshot(filePath28, file + i);
                Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
                Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
                Assert.IsFalse(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
            }
        }

        [TestCategory("SecretRelationship_BVT")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "29.设置最高发奖数量为5， 中奖机率为100%， 检查发送的前5张有效图片都能中奖（所有奖项都试一遍）;30.设置最高发奖数量为5， 中奖机率为100%， 检查发送的第6张有效图片能否中奖（所有奖项都试一遍）")]
        public void Can_secretRelationship_5_100_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\29.设置最高发奖数量为5， 中奖机率为100%， 检查发送的前5张有效图片都能中奖（所有奖项都试一遍）");
            string filePath30 = PortalChromeDriver.CreateFolder(@"关系识别\30.设置最高发奖数量为5， 中奖机率为100%， 检查发送的第6张有效图片能否中奖（所有奖项都试一遍）");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            for (int i = 1; i < 11; i++)
            {
                count = 0;
                WeChatManagermentPage.GoToCS_Skill_Page();
                SecretRelationshipPage.ClickSecretRelationship();
                SecretRelationshipPage.TurnOn();
                //设置奖励中奖概率
                PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
                SecretRelationshipPage.ClearAllAward();
                SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", i + ""), "6", "100");
                string file = string.Empty;
                switch (i)
                {
                    case 1:
                        file = 美男美女;
                        break;
                    case 2:
                        file = 美女丑男;
                        break;
                    case 3:
                        file = 年轻男小孩;
                        break;
                    case 4:
                        file = 美女美女;
                        break;
                    case 5:
                        file = 小孩小孩;
                        break;
                    case 6:
                        file = 小孩小孩;
                        break;
                    case 7:
                        file = 美女美女;
                        break;
                    case 8:
                        file = 小孩小孩;
                        break;
                    case 9:
                        file = 小孩小孩;
                        break;
                    case 10:
                        file = 小孩小孩;
                        break;
                }

                for (int j = 1; j <= 5; j++)
                {
                    ChoosePhotoAndCheck(file, i);
                    MobileAndroidDriver.GetScreenshot(filePath, file + i);
                    Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
                    Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
                    //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_" + i), "奖励是否显示");
                    FaceRankingMobilePage_WeChat.BackWards();
                }

                //for(int m=1;m<=10-count;m++)
                //{
                //    FaceRankingH5Page.ClickFaceRanking();
                //    FaceRankingH5Page.FaceRankingFromFile(file);
                //    Thread.Sleep(10 * 1000);
                //}

                FaceRankingMobilePage_WeChat.FaceRankingFromFile(file);
                Thread.Sleep(5 * 1000);
                MobileAndroidDriver.GetScreenshot(filePath, file + i);
                Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
                Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
                Assert.IsFalse(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_" + i), "奖励是否显示");
                FaceRankingMobilePage_WeChat.BackWards();
            }

        }


        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "32.只选中任一一个奖项后，上传一张跟该奖项无关的人物图片，是否会中奖（所有奖项都试一遍）")]
        public void Can_secretRelationship_1_100_DiffPhoto_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\32.只选中任一一个奖项后，上传一张跟该奖项无关的人物图片，是否会中奖（所有奖项都试一遍）");

            for (int i = 1; i < 8; i++)
            {
                WeChatManagermentPage.GoToCS_Skill_Page();
                SecretRelationshipPage.ClickSecretRelationship();
                SecretRelationshipPage.TurnOn();
                //设置奖励中奖概率
                PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
                SecretRelationshipPage.ClearAllAward();
                SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", i + ""), "1", "100");

                MobileAndroidDriver.AndroidInitialize_Weibo();
                Mobile_Weibo_Utility.Follow();
                string file = string.Empty;
                switch (i)
                {
                    case 1:
                        file = 美女美女;
                        break;
                    case 2:
                        file = 美男美女;
                        break;
                    case 3:
                        file = 美男美女;
                        break;
                    case 4:
                        file = 美男美女;
                        break;
                    case 5:
                        file = 美男美女;
                        break;
                    case 6:
                        file = 美男美女;
                        break;
                    case 7:
                        file = 小孩小孩;
                        break;
                }
                //上传不同图片             
                FaceRankingMobilePage_WeChat.FaceRankingFromFile(file);
                MobileAndroidDriver.GetScreenshot(filePath, file + i);
                Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerXpath(Mobile.UIElement.FaceRankingMobileElement.Comment), "图片显示描述语是否正确");
                Assert.IsTrue(FaceRankingMobilePage_WeChat.CheckOficailAccountShow("啊_荀"), "公众号名称是否正确显示");
                Assert.IsFalse(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_" + i), "奖励是否显示");
                MobileAndroidDriver.androidDriver.Dispose();
            }

        }

        [TestCategory("SecretRelationship_BVT")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestProperty("description", "停用'关系识别'功能后，输入含有'关系识别'的文本消息或点击相应link，是否能够触发该功能")]
        public void Can_secretRelationship_TurnOff_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\停用'关系识别'功能后，输入含有'关系识别'的文本消息或点击相应link，是否能够触发该功能");

            Utility.TurnOff();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(!Utility.IsTurnOn());

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();

            Mobile_WeChat_Utility.SendMessageWithMenu("关系识别");
            Thread.Sleep(2 * 1000);
            //Assert.IsTrue(Mobile_WeChat_Utility.GetLatestMessage("管理员"), "'拼颜值trigger'");
            Assert.IsTrue(Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("关闭"));
            FaceRankingMobilePage_WeChat.ClickFaceRanking();
            Assert.IsTrue(!Mobile_WeChat_Utility.IsAtPerClassName("android.widget.Button"), "点击拼颜值menu");
        }


        [TestMethod]
        [TestCategory("FaceRanking_BVT")]
        [TestCategory("BVT")]
        [TestCategory("1")]
        [TestProperty("description", "检查在没有关闭拼颜值功能的情况下，解绑小冰该功能是否被关闭")]
        public void SecretRelationship_Unbind_WeiBo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\检查在没有关闭拼颜值功能的情况下，解绑小冰该功能是否被关闭");
            LoginPage_Weibo.Unbundling();
            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Mobile_Weibo_Utility.SendMessage("关系识别");
            Assert.IsTrue(Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("关系识别"));
        }

        public static void ChoosePhotoAndCheck(string file, int i = 0)
        {
            try
            {
                count++;
                FaceRankingMobilePage_Weibo.ClickFaceRanking();
                FaceRankingMobilePage_Weibo.FaceRankingFromFile(file);
                //MobileAndroidDriver.GetElementByXpath(secretRelationshipElement.H5Reward_Resource_id);
                //MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_" + i);
            }
            catch (Exception e)
            {
                //count++;
                //FaceRankingH5Page.BackWards();
                //FaceRankingH5Page.ClickFaceRanking();
                //FaceRankingH5Page.FaceRankingFromFile(file);
                //Thread.Sleep(10 * 1000);
            }

        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }
    }

