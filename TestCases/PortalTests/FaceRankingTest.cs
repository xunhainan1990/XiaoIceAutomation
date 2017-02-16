using Common;
using Common.Driver;
using CSH5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;
using System;
using System.IO;
using System.Threading;
using XiaoIceH5;
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests
{
    [TestClass]
    public class FaceRankingTest : PortalTestInit
    {
        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("FaceRanking")]
        [TestProperty("description", "3.是否可以正常开启'拼颜值'功能")]
        public void FaceRanking_TurnOn()
        {            
            HomePage.ClickWeChatApp("平台测试账号2");
            //Go to AI Page
            WeChatManagermentPage.GoToCS_Skill_Page();
            FaceRankingPage.ClickFaceRanking();
            Utility.TurnOn();
            Assert.IsTrue(Utility.IsAt(FaceRankingElement.IsTurnOn),"拼颜值正确开启");
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
        [TestCategory("FaceRanking")]
        [TestCategory("BVT")]
        [TestProperty("description", "4.检查复制的链接是否可以设置到菜单里;5检查在手机端”拼颜值“功能是否可以正常使用；16测试结果是否可以分享")]
        public void FaceRanking_Link_Available()
        {
            //Go to FaceRanking Page
            WeChatManagermentPage.GoToCS_Skill_Page();
            FaceRankingPage.ClickFaceRanking();
            Utility.TurnOn();
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();

            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
     
            MenuPage.AddMenu("拼颜值"); MenuPage.AddMenu_Link_Wait(link);
            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\4.检查复制的链接是否可以设置到菜单里");
            PortalChromeDriver.TakeScreenShot(filePath, "拼颜值菜单是否正确生成");
            Assert.IsTrue(Utility.IsAt(MenuElement.FaceRankingMenu), "拼颜值菜单是否正确生成");
            //拼颜值功能是否正常使用
            filePath = PortalChromeDriver.CreateFolder(@"拼颜值\5.检查在手机端”拼颜值“功能是否可以正常使用");
            FaceRankingH5Page.ClickFaceRanking();

            FaceRankingH5Page.FaceRankingFromFile("mmexport1481102839261.jpg");
            MobileAndroidDriver.GetScreenshot(filePath, "图片显示描述语");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "图片显示描述语");

            //分享出去后是否能正常打开
            filePath = PortalChromeDriver.CreateFolder(@"拼颜值\16.测试结果是否可以分享");
            FaceRankingH5Page.ShareToSomeOne();
            FaceRankingH5Page.BackWards();
            FaceRankingH5Page.CheckLinkAvailable();
            MobileAndroidDriver.GetScreenshot(filePath, "分享出去后是否能正常打开");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "分享出去后是否能正常打开");

            //分享之后能否正常使用
            FaceRankingH5Page.FaceRankingFromFile("mmexport1481102839261.jpg");
            MobileAndroidDriver.GetScreenshot(filePath, "分享出去后是否能正常使用");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "分享出去后是否能正常使用");

            //再次分享后是否正常打开
            FaceRankingH5Page.ShareToSomeOne();
            FaceRankingH5Page.CheckLinkAvailable();
            MobileAndroidDriver.GetScreenshot(filePath, "第二次分享出去后是否能正常打开");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "分享出去后是否能正常打开");
            //二次分享之后能否正常使用
            FaceRankingH5Page.FaceRankingFromFile("mmexport1481102839261.jpg");
            MobileAndroidDriver.GetScreenshot(filePath, "第二次分享出去后是否能正常使用");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "第二次分享出去后是否能正常使用");
        }

        [TestMethod]
        [TestCategory("FaceRanking")]
        [TestCategory("BVT")]
        [TestProperty("description", "9.检查上传明星图片的效果")]
        public void FaceRanking_Celebrity()
        {
            //Go to FaceRanking Page
            WeChatManagermentPage.GoToCS_Skill_Page();
            FaceRankingPage.ClickFaceRanking();
            Utility.TurnOn();
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            if (!Utility.IsAt(MenuElement.FaceRankingMenu,"拼颜值"))
            {
                MenuPage.DeleteMenuItem();
                MenuPage.AddMenu("拼颜值");
                MenuPage.AddMenu_Link_Wait(link);
            }

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount(); 
            FaceRankingH5Page.ClickFaceRanking(); 
            FaceRankingH5Page.FaceRankingFromFile("mmexport1484563134540.jpg");
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\9.检查上传明星图片的效果");
            MobileAndroidDriver.GetScreenshot(filePath,"9.检查上传明星图片的效果");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment,"杨洋"), "未显示明星名字，当前case为林丹");
        }


        [TestMethod]
        [TestCategory("FaceRanking")]
        [TestCategory("BVT")]
        [TestProperty("description", "10.检查上传政治人物图片的效果")]
        public void FaceRanking_Political()
        {
            //Go to FaceRanking Page
            WeChatManagermentPage.GoToCS_Skill_Page();
            FaceRankingPage.ClickFaceRanking();
            Utility.TurnOn();
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            if (!HIPage.IsAt(MenuElement.FaceRankingMenu))
            {
                MenuPage.AddMenu("拼颜值");
                MenuPage.AddMenu_Link_Wait(link);
            }

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("mmexport1481256514269.jpg");
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\10.检查上传政治人物图片的效果");
            MobileAndroidDriver.GetScreenshot(filePath, "10.检查上传政治人物图片的效果");
            Assert.IsFalse(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment, "李克强"), "Comment里不出现人名，不出现评分");
            Assert.IsFalse(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment, "公众号颜值"), "Comment不出现评分");
        }

        [TestMethod]
        [TestCategory("FaceRanking")]
        [TestCategory("BVT")]
        [TestProperty("description", "11.检查上传非人物图片的效果")]
        public void FaceRanking_NoneHuman()
        {
            //Go to FaceRanking Page
            WeChatManagermentPage.GoToCS_Skill_Page();
            FaceRankingPage.ClickFaceRanking();
            Utility.TurnOn();
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            if (!HIPage.IsAt(MenuElement.FaceRankingMenu))
            {
                MenuPage.AddMenu("拼颜值");
                MenuPage.AddMenu_Link_Wait(link);
            }

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            FaceRankingH5Page.ClickFaceRanking(); 
            FaceRankingH5Page.FaceRankingFromFile("mmexport1463116029472.jpg");
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\11.检查上传非人物图片的效果");
            MobileAndroidDriver.GetScreenshot(filePath, "11.检查上传非人物图片的效果");
            Assert.IsFalse(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment, "公众号颜值"), "Comment不出现评分");
        }

        [TestMethod]
        [TestCategory("FaceRanking")]
        [TestProperty("description", "12.检查多次上传测试后，平均值是否被拉高或拉低了")]
        public void FaceRanking_ChangeTheAverage()
        {
            //Go to FaceRanking Page
            WeChatManagermentPage.GoToCS_Skill_Page();
            FaceRankingPage.ClickFaceRanking();
            Utility.TurnOn();
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            if (!HIPage.IsAt(MenuElement.FaceRankingMenu))
            {
                MenuPage.AddMenu("拼颜值");
                MenuPage.AddMenu_Link_Wait(link);
            }

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            FaceRankingH5Page.ClickFaceRanking();
            double before1 =0;
            double after1 = 0;
            double before2 = 0;
            double after2 = 0;
            double before3 = 0;
            double after3 = 0;
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\12.检查多次上传测试后，平均值是否被拉高或拉低了");
            FaceRankingH5Page.FaceRankingFromFile("mmexport1481102839261.jpg");
            FaceRankingH5Page.Getfraction(ref before1, ref after1);
            MobileAndroidDriver.GetScreenshot(filePath, "第一次上传");
            FaceRankingH5Page.BackWards();
            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("mmexport1481102839261.jpg");
            FaceRankingH5Page.Getfraction(ref before2, ref after2);
            MobileAndroidDriver.GetScreenshot(filePath, "第二次上传");
            FaceRankingH5Page.BackWards();
            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("mmexport1481102839261.jpg");
            FaceRankingH5Page.Getfraction(ref before3, ref after3);
            MobileAndroidDriver.GetScreenshot(filePath, "第三次上传");
            Assert.IsTrue(before1<=after1 && before2<=after2 && before3 <= after3);
            Assert.IsTrue(after1 == before2 && after2== before3);
        }

        [TestMethod]
        [TestCategory("FaceRanking")]
        [TestCategory("BVT")]
        [TestProperty("description", "14.检查是否可以正常关闭”拼颜值“的功能;19.是否可以停用'拼颜值'功能")]
        public void FaceRanking_TurnOff()
        {
            //Go to FaceRanking Page
            WeChatManagermentPage.GoToCS_Skill_Page();
            FaceRankingPage.ClickFaceRanking();
            Utility.TurnOn();
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            if (!HIPage.IsAt(MenuElement.FaceRankingMenu))
            {
                MenuPage.AddMenu("拼颜值");
                MenuPage.AddMenu_Link_Wait(link);
            }
            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("mmexport1484563134540.jpg");
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\14.检查是否可以正常关闭”拼颜值“的功能");
            MobileAndroidDriver.GetScreenshot(filePath, "关闭前拼颜值正常使用，图片显示描述语");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "关闭前拼颜值正常使用，图片显示描述语");      
            //停用拼颜值
            WeChatManagermentPage.GoToCS_Skill_Page();
            FaceRankingPage.ClickFaceRanking();
            FaceRankingPage.TurnOffFaceRanking();
            string turnOffPath = PortalChromeDriver.CreateFolder(@"拼颜值\19.是否可以停用'拼颜值'功能");
            PortalChromeDriver.TakeScreenShot(turnOffPath, "Portal是否能正常关闭拼颜值");          
            Assert.IsTrue(Utility.IsAt(FaceRankingElement.IsTurnOn), "Portal是否能正常关闭拼颜值");
           

            FaceRankingH5Page.BackWards();           
            FaceRankingH5Page.ClickFaceRanking();
            MobileAndroidDriver.GetScreenshot(filePath, "关闭拼颜值技能后H5端是否能正常使用");
            Assert.IsFalse(MobileH5.IsAt(CSH5.UIElement.FaceRankingH5Element.AccountFaceRanking), "关闭拼颜值技能后H5端是否能正常使用");
        }

        [TestMethod]
        [TestCategory("FaceRanking")]
        [TestCategory("BVT")]
        [TestProperty("description", "17.检查手机端拼颜值页面下面的二位码是否可以正常使用")]
        public void FaceRanking_QRCode_Available()
        {
            //Go to FaceRanking Page
            string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\17.检查手机端拼颜值页面下面的二位码是否可以正常使用");
            WeChatManagermentPage.GoToCS_Skill_Page();
            FaceRankingPage.ClickFaceRanking();

            Utility.TurnOn();
            string link = FaceRankingPage.CopyLink();
            FaceRankingPage.CopyAlertConfirm();
            WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
            MenuPage.DeleteMenuItem();
            try
            {
                HIPage.IsAt(MenuElement.FaceRankingMenu);
            }
            catch
            {
                MenuPage.AddMenu("拼颜值");
                MenuPage.AddMenu_Link_Wait(link);
            }           

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            FaceRankingH5Page.ClickFaceRanking();

            FaceRankingH5Page.ClickQRCode();
            MobileAndroidDriver.GetScreenshot(filePath, "点击二维码是否进入公众号");
            Assert.IsTrue(MobileH5.IsAt(CSH5.UIElement.FaceRankingH5Element.FaceRanking));
            FaceRankingH5Page.ClickFaceRanking();
            FaceRankingH5Page.FaceRankingFromFile("mmexport1460546134950.jpg");
            MobileAndroidDriver.GetScreenshot(filePath, "二维码进去公众号后是否能正常使用拼颜值");
            Assert.IsTrue(MobileH5.IsAtPerXpath(CSH5.UIElement.FaceRankingH5Element.Comment), "二维码进去公众号后是否能正常使用拼颜值");
        }

        //[TestMethod]
        //[TestCategory("FaceRanking")]
        //[TestCategory("1")]
        //[TestProperty("description", "检查输入以下trigger，是否会触发拼颜值功能：")]
        //public void FaceRanking_Trigger()
        //{
        //    //Go to FaceRanking Page
        //    string filePath = PortalChromeDriver.CreateFolder(@"拼颜值\检查输入以下trigger，是否会触发拼颜值功能：");
        //    WeChatManagermentPage.GoToCS_Skill_Page();
        //    FaceRankingPage.ClickFaceRanking();

        //    Utility.TurnOn(FaceRankingElement.FaceRankingTurnOnButton);

            
        //    MobileAndroidDriver.AndroidInitialize();
        //    MobileH5.GetToTestAccount();
        //    string[] trigger_a = { "群里谁最丑", "群里谁最美" };
        //    string[] trigger_b_1 = {"谁","哪个","哪位" };
        //    string[] trigger_b_2 = { "拉低", "降低" };
        //    string trigger_b_3 =  "颜值" ;
        //    string[] trigger_c_1 = { "提升", "拉高" ,"拔高","拉升","提高","带动"};
        //    string[] trigger_d = { "拼颜值", "比拼颜值" };
        //    string[] trigger_e = { "比拼", "大比拼","比较","排序" };
        //    string[] trigger_e_1 = { "颜值最高 ", " 颜值最低 ", " 最美 ", " 最好看 ", " 最漂亮 ", " 最美 ", " 最帅 ", " 最丑 ", " 最难看" };

        //    foreach (var trigger in trigger_a)
        //    {
        //        IsValidatorTurnOn(trigger);               
        //    }

        //    foreach (var item1 in trigger_b_1)
        //    {
        //        foreach (var item2 in trigger_b_2)
        //        {
        //            IsValidatorTurnOn(item1+item2+trigger_b_3);
        //        }
        //    }

        //    foreach (var item1 in trigger_b_1)
        //    {
        //        foreach (var item2 in trigger_c_1)
        //        {
        //            IsValidatorTurnOn(item1 + item2 + trigger_b_3);
        //        }
        //    }

        //    foreach (var item1 in trigger_e)
        //    {
        //        IsValidatorTurnOn(item1  + trigger_b_3);
        //    }
        //    foreach (var item in trigger_d)
        //    {
        //        IsValidatorTurnOn(item);
        //    }


        //    foreach (var item1 in trigger_b_1)
        //    {
        //        foreach (var item2 in trigger_e_1)
        //        {
        //            IsValidatorTurnOn(item1 + item2);
        //        }
        //    }

        //    FaceRankingPage.TurnOffFaceRanking();
        //    foreach (var trigger in trigger_a)
        //    {
        //        IsValidatorTurnOff(trigger);
        //    }

        //    foreach (var item1 in trigger_b_1)
        //    {
        //        foreach (var item2 in trigger_b_2)
        //        {
        //            IsValidatorTurnOff(item1 + item2 + trigger_b_3);
        //        }
        //    }

        //    foreach (var item1 in trigger_b_1)
        //    {
        //        foreach (var item2 in trigger_c_1)
        //        {
        //            IsValidatorTurnOff(item1 + item2 + trigger_b_3);
        //        }
        //    }

        //    foreach (var item1 in trigger_e)
        //    {
        //        IsValidatorTurnOff(item1 + trigger_b_3);
        //    }
        //    foreach (var item in trigger_d)
        //    {
        //        IsValidatorTurnOff(item);
        //    }


        //    foreach (var item1 in trigger_b_1)
        //    {
        //        foreach (var item2 in trigger_e_1)
        //        {
        //            IsValidatorTurnOff(item1 + item2);
        //        }
        //    }

        //}

        //public static void IsValidatorTurnOn(string trigger)
        //{
        //    MobileH5.SendMessage(trigger);
        //    string[] validators = { "来这试试", "进来试试", "戳这看结果", "点这里", "看这里", "点我吧", "点我","来测测呗" };
           
        //        foreach (var validator in validators)
        //        {
        //            if (MobileH5.GetLatestMessage().Text.Contains(validator))
        //            {
        //                Assert.IsTrue(true, "Trigger:" + trigger + "Validator:" + MobileH5.GetLatestMessage().Text);
        //                break;
        //            }
        //        }           
        //}

        //public static void IsValidatorTurnOff(string trigger)
        //{
        //    MobileH5.SendMessage(trigger);
        //    string validator = "关闭";
        //    if (MobileH5.GetLatestMessage().Text.Contains(validator))
        //    {
        //        Assert.IsTrue(true, "Trigger:" + trigger + "Validator:" + MobileH5.GetLatestMessage().Text);
        //    }
        //}

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if(MobileAndroidDriver.androidDriver!=null)
            MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
