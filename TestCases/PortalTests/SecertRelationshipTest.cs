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
    public class SecretRelationshipTest : PortalTestInit
    {
        public static int count = 0;
        string 美男美女 = "mmexport1482389090835.jpg";
        string 美女丑男 = "mmexport1482374446184.jpg";
        string 美男美男 = "mmexport1482390985399.jpg";
        string 美女丑女= "mmexport1482390407535.jpg";
        string 丑女丑女 = "mmexport1482390529652.jpg";
        string 丑男丑女 = "mmexport1482389081784.jpg";
        string 年轻女少女 = "mmexport1482390524611.jpg";
        string 年轻男少男 = "mmexport1482294770944.jpg";
        string 年轻女小孩 = "mmexport1482390127156.jpg";
        string 一家人小孩 = "mmexport1482390134999.jpg";
        string 年轻女中性男 = "mmexport1482391680070.jpg";
        string 美男中性女 = "mmexport1482390702388.jpg";
        string 年轻男小孩= "mmexport1482390131153.jpg"; 
        string 美女美女 = "mmexport1481102839261.jpg";
        string 小孩小孩 = "mmexport1482217944394.jpg";
        string 一男一女 = "mmexport1482395212867.jpg";

        [TestCategory("secretRelationship")]
        [TestCategory("Can_secretRelationship_TurnOn")]
        [TestMethod]
        [TestProperty("description", "1.检查'关系识别'功能是否显示在技能插件的页面上;3.是否可以正常开启'关系识别'功能")]
        public void Can_secretRelationship_TurnOn()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\1.检查'关系识别'功能是否显示在技能插件的页面上");
            WeChatManagermentPage.GoToCS_Skill_Page();
            PortalChromeDriver.TakeScreenShot(filePath,@"1.检查'关系识别'功能是否显示在技能插件的页面上");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.secretRelationship, "关系识别"), "检查'关系识别'功能是否显示在技能插件的页面上");
            SecretRelationshipPage.ClickSecretRelationship();
            Utility.TurnOff(secretRelationshipElement.TurnOff,secretRelationshipElement.TurnOffConfirm);
            Thread.Sleep(2*1000);
            Utility.TurnOn(secretRelationshipElement.SecretRelationshipTurnOn);
            Thread.Sleep(2 * 1000);
            SecretRelationshipPage.SetNow();
            filePath = PortalChromeDriver.CreateFolder(@"关系识别\3.是否可以正常开启'关系识别'功能");
            PortalChromeDriver.TakeScreenShot(filePath, @"点击奖项设置，是否可以正常开启'关系识别'功能");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.IsTurnOff, "停用"), "点击奖项设置，是否可以正常开启'关系识别'功能");
            Utility.TurnOff(secretRelationshipElement.TurnOff, secretRelationshipElement.TurnOffConfirm);
            Thread.Sleep(1*1000);
            Utility.TurnOn(secretRelationshipElement.SecretRelationshipTurnOn);
            Thread.Sleep(2 * 1000);
            SecretRelationshipPage.SetLater();
            PortalChromeDriver.TakeScreenShot(filePath, @"点击稍后设置，是否可以正常开启'关系识别'功能");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.IsTurnOff, "停用"), "点击稍后设置，是否可以正常开启'关系识别'功能");
            Utility.TurnOff(secretRelationshipElement.TurnOff, secretRelationshipElement.TurnOffConfirm);
            Thread.Sleep(2 * 1000);
            Utility.TurnOn(secretRelationshipElement.SecretRelationshipTurnOn);
            Thread.Sleep(2 * 1000);
            SecretRelationshipPage.CancleButtonClick();
            PortalChromeDriver.TakeScreenShot(filePath, @"点击取消按钮，是否可以正常开启'关系识别'功能");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.IsTurnOff, "停用"), "点击取消按钮，是否可以正常开启'关系识别'功能");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "4.检查'技能设置'页面的功能按钮是否正常工作;5.复制的link是否可以打开;10.是否可以正常使用'关系识别'功能（检查portal 和 手机端）;11.可以上传照片测试;12.测试结果是否可以分享;13.分享后是否可以返回到关系识别页面")]
        public void Can_secretRelationship_KeepSharing()
     {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\4.检查'技能设置'页面的功能按钮是否正常工作");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}","4"),"100","100");

          
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            Utility.BackToAllSkill();
            PortalChromeDriver.TakeScreenShot(filePath, "返回技能插件页面，拼颜值是否开通");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.IsTurnOn_AllSkillPage, "（已开启）"), "返回技能插件页面，拼颜值是否开通");
            

            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);
            PortalChromeDriver.TakeScreenShot(filePath, "关系识别菜单是否正确生成");
            Assert.IsTrue(Utility.IsAt(MenuElement.FaceRankingMenu), "关系识别菜单是否正确生成");       
              

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            //HI上关系识别正常使用
            string filePath5 = PortalChromeDriver.CreateFolder(@"关系识别\5.复制的link是否可以打开");
            string filePath10 = PortalChromeDriver.CreateFolder(@"关系识别\10.是否可以正常使用'关系识别'功能");
            string filePath11 = PortalChromeDriver.CreateFolder(@"关系识别\11.可以上传照片测试");
            ChoosePhotoAndCheck(美女美女);
            MobileAndroidDriver.GetScreenshot(filePath5, "图片显示是否正确");
            MobileAndroidDriver.GetScreenshot(filePath10, "是否可以正常使用'关系识别'功能");
            MobileAndroidDriver.GetScreenshot(filePath11, "是否可以正常使用'关系识别'功能");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_4"), "奖励是否显示");


            filePath = PortalChromeDriver.CreateFolder(@"关系识别\13.分享后是否可以返回到关系识别页面");
            FaceRankingH5Page.ShareToSomeOne();
            MobileAndroidDriver.GetScreenshot(filePath, "分享后回到关系识别页面");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "分享后回到关系识别页面");
            FaceRankingH5Page.BackWards();
            FaceRankingH5Page.CheckLinkAvailable();
            filePath = PortalChromeDriver.CreateFolder(@"关系识别\12.测试结果是否可以分享");
            MobileAndroidDriver.GetScreenshot(filePath, "分享出去后是否能正常打开");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "分享出去后是否能正常打开");

            //分享之后能否正常使用
            FaceRankingH5Page.FaceRankingFromFile(美女美女);
            Thread.Sleep(5 * 1000);
            FaceRankingH5Page.CheckLinkAvailable();
            FaceRankingH5Page.FaceRankingFromFile(美女美女);
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "分享出去后是否能正常使用");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "分享出去后是否能正常使用");

            //再次分享后是否正常打开
            FaceRankingH5Page.ShareToSomeOne();
            FaceRankingH5Page.CheckLinkAvailable();
            MobileAndroidDriver.GetScreenshot(filePath, "第二次分享出去后是否能正常打开");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "分享出去后是否能正常打开");

            //再次分享后再次分享
            FaceRankingH5Page.ShareToSomeOne();
            FaceRankingH5Page.CheckLinkAvailable();
            FaceRankingH5Page.FaceRankingFromFile(美女美女);
            Thread.Sleep(5 * 1000);
            FaceRankingH5Page.CheckLinkAvailable();
            FaceRankingH5Page.FaceRankingFromFile(美女美女);
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "第二次分享出去后是否能正常使用");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "再次分享后能否正常使用");
        }

        //[TestCategory("secretRelationship")]
        //[TestMethod]
        //[TestProperty("description", "6.检查'奖项设置'页面的功能按钮是否正常工作(1)")]
        //public void Can_secretRelationship_RewardSetting_Work()
        //{
        //    WeChatManagermentPage.GoToCS_Skill_Page();
        //    SecretRelationshipPage.ClickSecretRelationship();
        //    Utility.TurnOn(secretRelationshipElement.SecretRelationshipTurnOn);
        //    SecretRelationshipPage.SetLater();

        //    string link = FaceRankingPage.CopyLink();
        //    FaceRankingPage.CopyAlertConfirm();
        //    WeChatManagermentPage.GoTo_Menu();
        //    MenuPage.DeleteMenuItem();
        //    MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

        //    //正常显示
        //    MobileAndroidDriver.AndroidInitialize();
        //    HIMobileH5.GetToTestAccount();
        //    string filePath = PortalChromeDriver.CreateFolder(@"关系识别\4.检查'技能设置'页面的功能按钮是否正常工作");
        //    Assert.IsTrue(Utility.IsAt(MenuElement.FaceRankingMenu), "关系识别菜单是否正确生成");
        //    PortalChromeDriver.TakeScreenShot(filePath, "关系识别菜单是否正确生成");
        //    Utility.BackToAllSkill();
        //    Assert.IsTrue(Utility.IsAt(secretRelationshipElement.IsTurnOn_AllSkillPage, "（已开启）"), "返回技能插件页面，拼颜值是否开通");
        //    PortalChromeDriver.TakeScreenShot(filePath, "返回技能插件页面，拼颜值是否开通");

        //    //HI上关系识别正常使用
        //    filePath = PortalChromeDriver.CreateFolder(@"关系识别\5.复制的link是否可以打开");
        //    MobileAndroidDriver.ClickElemnetPerName("关系识别");
        //    FaceRankingH5Page.FaceRankingFromFile("美女美女");
        //    MobileAndroidDriver.GetScreenshot(filePath, "图片显示描述语");
        //    Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语");

        //}

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "7.检查'奖项设置'页面的功能按钮是否正常工作(2)")]
        public void Can_secretRelationship_RewardSetting_Work2()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\7.检查'奖项设置'页面的功能按钮是否正常工作(2)");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            Utility.TurnOn(secretRelationshipElement.SecretRelationshipTurnOn);
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
            SecretRelationshipPage.InputAwardNumber("50","50");
            Thread.Sleep(1*1000);
            PortalChromeDriver.TakeScreenShot(filePath, "输入正常");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.Award1,"50"),"最高发奖量保存失败");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.AwardRate1, "50%"), "中奖几率保存失败");

            //判定发奖量非法输入
            //判定中奖几率非法输入
            SecretRelationshipPage.InputAwardNumber("a", "-1");
            PortalChromeDriver.TakeScreenShot(filePath, "-1非法输入");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.awards_tip_Class, "发奖数量必须为正整数"), "最高发奖量是否能输入字母");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.award_rate_tip, "请输入正整数"), "中奖几率能否为负数");
            PortalChromeDriver.Refresh();
            SecretRelationshipPage.InputAwardNumber("你好", "0");
            PortalChromeDriver.TakeScreenShot(filePath, "0非法输入");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.awards_tip_Class, "发奖数量必须为正整数"), "最高发奖量是否能输入字母");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.award_rate_tip, "中奖机率需大于0"), "中奖几率能否为0");
            PortalChromeDriver.Refresh();
            SecretRelationshipPage.InputAwardNumber("*", "0.1");
            PortalChromeDriver.TakeScreenShot(filePath, "0.1非法输入");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.awards_tip_Class, "发奖数量必须为正整数"), "最高发奖量是否能输入字母");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.award_rate_tip, "请输入正整数"), "中奖几率能否为小数");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "8.“技能设置”，“奖项设置”和“使用说明” Tab是否可以相互切换)")]
        public void Can_secretRelationship_SwitchTab()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\8.“技能设置”，“奖项设置”和“使用说明” Tab是否可以相互切换)");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            Utility.TurnOn(secretRelationshipElement.SecretRelationshipTurnOn);
            PortalChromeDriver.TakeScreenShot(filePath, "点击稍后设置后，是否focus在技能设置上");
            Assert.IsTrue(Utility.IsAt(FaceRankingElement.copiedLink), "点击稍后设置后，是否focus在技能设置上");
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            PortalChromeDriver.TakeScreenShot(filePath, "点击现在设置后，是否focus在奖项设置上");
            Assert.IsTrue(Utility.IsAt(secretRelationshipElement.cs_awards_edit), "点击现在设置后，是否focus在奖项设置上");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "15.在没有设置奖项的情况下:上传一张单个人物的照片；34.在设置奖项的情况下:上传一张单个人物的照片")]
        public void Can_secretRelationship_Single()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\15.在没有设置奖项的情况下上传一张单个人物的照片");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("IMG_20161215_154530.jpg");
            Thread.Sleep(5*1000);
            
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            Assert.IsFalse(MobileH5.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
            MobileAndroidDriver.androidDriver.Dispose();

            //设置中奖概率
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "1"), "100", "100");

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("IMG_20161215_154530.jpg");
            Thread.Sleep(5* 1000);
            filePath = PortalChromeDriver.CreateFolder(@"关系识别\34.在设置奖项的情况下上传一张单个人物的照片");
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            Assert.IsFalse(MobileH5.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "16.在没有设置奖项的情况下:上传一张明星图片；35.在设置奖项的情况下:上传一张明星图片")]
        public void Can_secretRelationship_Celebrity()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\16.在没有设置奖项的情况下上传一张明星图片");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("1480498437278.jpg");            
            Thread.Sleep(10 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment,"林丹"), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            Assert.IsFalse(MobileH5.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示"); 

            //设置中奖概率
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "3"), "100", "100");

            MobileH5.BackButtonClick();
            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("1480498437278.jpg");
            Thread.Sleep(5* 1000);          
            filePath = PortalChromeDriver.CreateFolder(@"关系识别\35.在设置奖项的情况下上传一张明星图片");
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment, "林丹"), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            Assert.IsFalse(MobileH5.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id, "reward_25_3"), "奖励是否显示");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "17.在没有设置奖项的情况下:上传一张政治人物图片；36.在设置奖项的情况下:上传一张政治人物图片")]
        public void Can_secretRelationship_Political()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\17.在没有设置奖项的情况下上传一张政治人物图片");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("mmexport1481256514269.jpg");
            Thread.Sleep(5 * 1000);        

            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            Assert.IsFalse(MobileH5.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
            //MobileAndroidDriver.androidDriver.Dispose();
            //设置中奖概率
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "1"), "100", "100");

            //MobileAndroidDriver.AndroidInitialize();
            //HIMobileH5.GetToTestAccount();
            FaceRankingH5Page.BackWards();
            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("mmexport1481256514269.jpg");
            Thread.Sleep(5 * 1000);
            filePath= PortalChromeDriver.CreateFolder(@"关系识别\36.在设置奖项的情况下上传一张政治人物图片");
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            Assert.IsFalse(MobileH5.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "18.在没有设置奖项的情况下:上传一张非人物图片；37.在设置奖项的情况下:上传一张非人物图片")]
        public void Can_secretRelationship_NoneHuman()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\18.在没有设置奖项的情况下上传一张非人物图片");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("IMG_20161222_110551.jpg");        
            Thread.Sleep(5 * 1000);
           
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            Assert.IsFalse(MobileH5.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");

            //设置中奖概率
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "1"), "100", "100");


            FaceRankingH5Page.BackWards();
            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("IMG_20161222_110551.jpg");
            Thread.Sleep(5 * 1000);
            filePath = PortalChromeDriver.CreateFolder(@"关系识别\37.在设置奖项的情况下上传一张非人物图片");
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            Assert.IsFalse(MobileH5.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "19.在没有设置奖项的情况下:上传人物面部不清晰的图片;38.	在没有设置奖项的情况下:上传人物面部不清晰的图片")]
        public void Can_secretRelationship_Humanvague()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\19.在没有设置奖项的情况下上传人物面部不清晰的图片");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("IMG_20161222_110551.jpg");
            Thread.Sleep(5 * 1000);

            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            Assert.IsFalse(MobileH5.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
            //MobileAndroidDriver.androidDriver.Dispose();

            //设置中奖概率
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "1"), "100", "100");

            //MobileAndroidDriver.AndroidInitialize();
            //HIMobileH5.GetToTestAccount();
            MobileH5.BackButtonClick();
            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("IMG_20161222_110551.jpg");
            Thread.Sleep(5 * 1000);
            filePath = PortalChromeDriver.CreateFolder(@"关系识别\38.在没有设置奖项的情况下上传人物面部不清晰的图片");
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            Assert.IsFalse(MobileH5.IsAtPerXpath(secretRelationshipElement.H5Reward_Resource_id), "奖励是否显示");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "20.是否可以获得“公众号最亲密恋人”奖项")]
        public void Can_secretRelationship_Couple()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\20.是否可以获得“公众号最亲密恋人”奖项");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            //设置
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "1"), "100", "100");
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            ChoosePhotoAndCheck(美男美女);
            MobileAndroidDriver.GetScreenshot(filePath, "美男美女_公众号最亲密恋人");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id,"reward_25_1"), "奖励是否显示");

            ChoosePhotoAndCheck(一男一女);
            MobileAndroidDriver.GetScreenshot(filePath, "一男一女_公众号最亲密恋人");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_1"), "奖励是否显示");

            ChoosePhotoAndCheck(丑男丑女);
            MobileAndroidDriver.GetScreenshot(filePath, "丑男丑女_公众号最亲密恋人");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_1"), "奖励是否显示");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "21.是否可以获得“公众号最纯真友谊”奖项")]
        public void Can_secretRelationship_Friend()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\21.是否可以获得“公众号最纯真友谊”奖项");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "2"), "100", "100");
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            ChoosePhotoAndCheck(美女丑男);
            MobileAndroidDriver.GetScreenshot(filePath, "美女丑男_公众号最纯真友谊");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_2"), "奖励是否显示");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "22.是否可以获得“公众号最佳亲子组合”奖项")]
        public void Can_secretRelationship_Parent_Child()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\22.是否可以获得“公众号最佳亲子组合”奖项");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "3"), "100", "100");
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            Thread.Sleep(5*1000);
            ChoosePhotoAndCheck(年轻男小孩);

            MobileAndroidDriver.GetScreenshot(filePath, "年轻男小孩_公众号最佳亲子组合");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_3"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(年轻女小孩);
            //Thread.Sleep(5 * 1000);
            //FaceRankingH5Page.FaceRankingFromFile(年轻女小孩);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_3"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(一家人小孩);
            //Thread.Sleep(5 * 1000);
            //FaceRankingH5Page.FaceRankingFromFile(一家人小孩);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_3"), "奖励是否显示");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "23.是否可以获得“公众号最佳姐妹淘”奖项")]
        public void Can_secretRelationship_Sisters()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\23.是否可以获得“公众号最佳姐妹淘”奖项");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "4"), "100", "100");
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            ChoosePhotoAndCheck(美女美女);
           
            MobileAndroidDriver.GetScreenshot(filePath, "美女美女_公众号最佳姐妹淘");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_4"), "奖励是否显示");

            ChoosePhotoAndCheck(丑女丑女);
            MobileAndroidDriver.GetScreenshot(filePath, "丑女丑女_公众号最佳姐妹淘");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_4"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(年轻女中性男);
            //Thread.Sleep(5 * 1000);
            //FaceRankingH5Page.FaceRankingFromFile(年轻女中性男);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_4"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(年轻女少女);
            //Thread.Sleep(5 * 1000);
            //FaceRankingH5Page.FaceRankingFromFile(年轻女少女);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_4"), "奖励是否显示");

        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "24.是否可以获得“公众号最佳兄弟组合”奖项")]
        public void Can_secretRelationship_Brothers()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\24.是否可以获得“公众号最佳兄弟组合”奖项");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "5"), "100", "100");
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            ChoosePhotoAndCheck(年轻男少男);

            MobileAndroidDriver.GetScreenshot(filePath, "年轻男少男_公众号最佳兄弟组合");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_5"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(美男中性女);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_5"), "奖励是否显示");


        }

        [TestCategory("secretRelationship")]
        [TestCategory("Can_secretRelationship_Angle")]       
        [TestMethod]
        [TestProperty("description", "25.是否可以获得“公众号最萌小天使”奖项")]
        public void Can_secretRelationship_Angle()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\25.是否可以获得“公众号最萌小天使”奖项");
            PortalChromeDriver.ChromeInitialize();
            LoginPage.GoTo();
            HomePage.ClickWeChatApp("平台测试账号2");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "6"), "100", "100");
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);
            Thread.Sleep(300 * 1000);
            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            ChoosePhotoAndCheck(小孩小孩);
            //FaceRankingH5Page.ClickFaceRanking();
            //FaceRankingH5Page.FaceRankingFromFile(小孩小孩);
            //Thread.Sleep(5 * 1000);
            //FaceRankingH5Page.BackWards();
            //FaceRankingH5Page.ClickFaceRanking();
            //FaceRankingH5Page.FaceRankingFromFile(小孩小孩);
            //Thread.Sleep(5 * 1000);

            MobileAndroidDriver.GetScreenshot(filePath, "小孩小孩_公众号最萌小天使");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_6"), "奖励是否显示");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "26.是否可以获得“公众号最高颜值组合”奖项")]
        public void Can_secretRelationship_GoodLook()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\26.是否可以获得“公众号最高颜值组合”奖项");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();
            //设置奖励中奖概率
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
            SecretRelationshipPage.ClearAllAward();
            SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", "7"), "100", "100");
            //添加关系识别菜单
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SkillSetting);
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            ChoosePhotoAndCheck(美女美女);

            MobileAndroidDriver.GetScreenshot(filePath, "美女美女公_众号最高颜值组合图片");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_7"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(美男美女);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_7"), "奖励是否显示");

            //FaceRankingH5Page.FaceRankingFromFile(美男美男);
            //Thread.Sleep(1 * 1000);
            //MobileAndroidDriver.GetScreenshot(filePath, "图片显示是否正确");
            //Assert.IsTrue(HIMobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
            //Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
            ////Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_7"), "奖励是否显示");
        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "27.设置最高发奖数量为1,中奖机率为100%,检查发送第1张有效图片的时候就能中奖（所有奖项都试一遍）;28.设置最高发奖数量为1， 中奖机率为100%， 检查发送第2张有效图片的时候能否中奖（所有奖项都试一遍）")]
        public void Can_secretRelationship_One_Handred()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\27.设置最高发奖数量为1,中奖机率为100%,检查发送第1张有效图片的时候就能中奖（所有奖项都试一遍）");
            string filePath28 = PortalChromeDriver.CreateFolder(@"关系识别\28.设置最高发奖数量为1,中奖机率为100%.检查发送第2张有效图片的时候能否中奖（所有奖项都试一遍）");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            //添加关系识别菜单
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);
            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();

            //设置奖励中奖概率
            for (int i=1;i<8;i++)
            {
                WeChatManagermentPage.GoToCS_Skill_Page();
                SecretRelationshipPage.ClickSecretRelationship();
                SecretRelationshipPage.TurnOn();
                PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
                SecretRelationshipPage.ClearAllAward();
                SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", i+""), "2", "100");
                             
                string file = string.Empty;
                switch (i)
                {
                    case 1:
                        file =美男美女;
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
                }


                FaceRankingH5Page.ClickFaceRanking();
                FaceRankingH5Page.FaceRankingFromFile(file);
                Thread.Sleep(5 * 1000);
                FaceRankingH5Page.BackWards();
                FaceRankingH5Page.ClickFaceRanking();
                FaceRankingH5Page.FaceRankingFromFile(file);
                Thread.Sleep(5 * 1000);
                MobileAndroidDriver.GetScreenshot(filePath, file+i);
                Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
                Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
                //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_" + i), "奖励是否显示");

                FaceRankingH5Page.FaceRankingFromFile(file);
                Thread.Sleep(5 * 1000);               
                MobileAndroidDriver.GetScreenshot(filePath28, file+i);
                Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
                Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
                Assert.IsFalse(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_" + i), "奖励是否显示");
                FaceRankingH5Page.BackWards();
            }
           
        }


        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "29.设置最高发奖数量为5， 中奖机率为100%， 检查发送的前5张有效图片都能中奖（所有奖项都试一遍）;30.设置最高发奖数量为5， 中奖机率为100%， 检查发送的第6张有效图片能否中奖（所有奖项都试一遍）")]
        public void Can_secretRelationship_Five_Handred()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\29.设置最高发奖数量为5， 中奖机率为100%， 检查发送的前5张有效图片都能中奖（所有奖项都试一遍）");
            string filePath30 = PortalChromeDriver.CreateFolder(@"关系识别\30.设置最高发奖数量为5， 中奖机率为100%， 检查发送的第6张有效图片能否中奖（所有奖项都试一遍）");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            //添加关系识别菜单
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别");
            MenuPage.AddMenu_Link(link);
            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            for (int i = 1; i < 8; i++)
            {
                count = 0;
                WeChatManagermentPage.GoToCS_Skill_Page();
                SecretRelationshipPage.ClickSecretRelationship();
                SecretRelationshipPage.TurnOn();
                //设置奖励中奖概率
                PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
                SecretRelationshipPage.ClearAllAward();
                SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", i + ""), "10", "100");
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
                }

                for (int j=1;j<=5;j++)
                {
                    ChoosePhotoAndCheck(file);
                    MobileAndroidDriver.GetScreenshot(filePath, file + i);
                    Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
                    Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
                    //Assert.IsTrue(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_" + i), "奖励是否显示");
                    FaceRankingH5Page.BackWards();                               
                }
                
                //for(int m=1;m<=10-count;m++)
                //{
                //    FaceRankingH5Page.ClickFaceRanking();
                //    FaceRankingH5Page.FaceRankingFromFile(file);
                //    Thread.Sleep(10 * 1000);
                //}

                FaceRankingH5Page.ClickFaceRanking();
                FaceRankingH5Page.FaceRankingFromFile(file);
                Thread.Sleep(5 * 1000);
                MobileAndroidDriver.GetScreenshot(filePath, file + i);
                Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
                Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
                Assert.IsFalse(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_" + i), "奖励是否显示");
                FaceRankingH5Page.BackWards();
            }

        }

        public static void ChoosePhotoAndCheck(string file)
        {
            try
            {
                //count++;
                Thread.Sleep(5 * 1000);
                FaceRankingH5Page.ClickFaceRanking();
                Thread.Sleep(10 * 1000);
                FaceRankingH5Page.FaceRankingFromFile(file);
                Thread.Sleep(10 * 1000);
                //PortalChromeDriver.GetElementByXpath(secretRelationshipElement.H5Reward_Resource_id);
                //MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_" + i);
            }
            catch(Exception e)
            {
                //count++;
                //FaceRankingH5Page.BackWards();
                //FaceRankingH5Page.ClickFaceRanking();
                //FaceRankingH5Page.FaceRankingFromFile(file);
                //Thread.Sleep(10 * 1000);
            }

        }

        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "32.只选中任一一个奖项后，上传一张跟该奖项无关的人物图片，是否会中奖（所有奖项都试一遍）")]
        public void Can_secretRelationship_One_Handred_DiffPhoto()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\32.只选中任一一个奖项后，上传一张跟该奖项无关的人物图片，是否会中奖（所有奖项都试一遍）");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            //添加关系识别菜单
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            MenuPage.AddMenu("关系识别"); MenuPage.AddMenu_Link(link);
            for (int i = 1; i < 8; i++)
            {
                WeChatManagermentPage.GoToCS_Skill_Page();
                SecretRelationshipPage.ClickSecretRelationship();
                SecretRelationshipPage.TurnOn();
                //设置奖励中奖概率
                PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.RewartSetting);
                SecretRelationshipPage.ClearAllAward();
                SecretRelationshipPage.CheckAward(secretRelationshipElement.Award.Replace("{0}", i + ""), "1", "100");
               
                MobileAndroidDriver.AndroidInitialize();
                MobileH5.GetToTestAccount();
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
                FaceRankingH5Page.ClickFaceRanking();                           
                //上传不同图片             
               
                FaceRankingH5Page.FaceRankingFromFile(file);
                MobileAndroidDriver.GetScreenshot(filePath,file+i);
                Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语是否正确");
                Assert.IsTrue(SecretRelationshipPage.CheckOficailAccountShow(), "公众号名称是否正确显示");
                Assert.IsFalse(MobileAndroidDriver.IsAt(secretRelationshipElement.H5Reward_Resource_id, "reward_25_" + i), "奖励是否显示");
                MobileAndroidDriver.androidDriver.Dispose();
            }

        }


        [TestCategory("secretRelationship")]
        [TestMethod]
        [TestProperty("description", "32.只选中任一一个奖项后，上传一张跟该奖项无关的人物图片，是否会中奖（所有奖项都试一遍）")]
        public void Can_SecretRelationship_Trigger()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"关系识别\4.检查'技能设置'页面的功能按钮是否正常工作");
            WeChatManagermentPage.GoToCS_Skill_Page();
            SecretRelationshipPage.ClickSecretRelationship();
            SecretRelationshipPage.TurnOn();


            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.SendMessage("群里谁最丑");
            //Assert.IsTrue();
        }

        //[TestCategory("secretRelationship")]
        //[TestMethod]
        //[TestProperty("description", "32.只选中任一一个奖项后，上传一张跟该奖项无关的人物图片，是否会中奖（所有奖项都试一遍）")]
        //public void Can_secretRelationship_TurnOff()
        //{

        //    WeChatManagermentPage.GoToCS_Skill_Page();
        //    SecretRelationshipPage.ClickSecretRelationship();

        //    SecretRelationshipPage.TurnOff();
        //    MobileAndroidDriver.AndroidInitialize();
        //    HIMobileH5.GetToTestAccount();
        //    HIMobileH5.SendMessage("关系识别");
            
        //    string comment = "'管理员最近断舍离，这项技能被关闭了。。。。,管理员如果心情好就会给我增加这项技能的',管理员最近闭关修炼，等过段时间你再来试',涅，该技能因管理员心情原因暂时无法被召唤，过段日子来试试~',管理员告别单身后就会打开该技能，期待吧',传说中我可以具备这个技能哦~ 下次你运气好说不定就激活了',你挺清楚我的特异功能啊，只是现在被关闭咯~ 过段日子来试试'";
        //    Assert.IsTrue(comment.Contains(HIMobileH5.GetLatestMessage().Text));
                         

        //}



        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
