using Common;
using CSH5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mobile;
using Portal;
using Portal.Pages;
using System.Threading;
using TestCases.PortalTests;
using XiaoIcePortal.Pages;

namespace TestCases
{
    [TestClass]
    public class MomentsSnapshotTest : PortalTestInit
    {
        [TestInitialize]
        public void IntiMomentsSnapshot()
        {
            WeChatManagermentPage.GoToCS_Skill_Page();
            WeChatManagermentPage.GoTo_MomentsSnapshot_Page();
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("TurnOn")]
        [TestProperty("description", "2.是否可以正常开启“朋友圈截图”功能")]
        public void TurnOn()
        {
            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\是否可以正常开启“朋友圈截图”功能");
            //确保HI是Turn on的状态
            Utility.TurnOn();
            Assert.IsTrue(Utility.IsTurnOn(), "朋友圈截图开启失败");
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddCampaign")]
        [TestProperty("description", "是否可以成功添加一个新规则；是否可以编辑修改规则名；是否可以删除一个规则")]
        public void AddCampaign()
        {
            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\是否可以成功添加一个新规则；是否可以编辑修改规则名；是否可以删除一个规则");
            //确保HI是Turn on的状态
            Utility.TurnOn();
            Thread.Sleep(1 * 1000);
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(10 * 1000);
            MomentsSnapPage.CreateCampaign("河北");
            PortalChromeDriver.TakeScreenShot(folder, "创建规则");
            Assert.IsTrue(Utility.IsAt(CommonElement.notification, "创建规则成功"), "创建规则成功");

            Thread.Sleep(10 * 1000);
            MomentsSnapPage.EditCampain();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(CommonElement.notification, "更新规则成功"), "更新规则成功");

            Thread.Sleep(10 * 1000);
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(CommonElement.notification, "删除规则成功"), "删除规则成功");
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("AddCampain_News")]
        [TestProperty("description", "成功添加一个回复图文")]
        public void AddCampain_News()
        {
            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\成功添加一个回复图文");
            Utility.TurnOn();
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(1 * 1000);
            MomentsSnapPage.CreateCampaign_News();
            PortalChromeDriver.TakeScreenShot(folder, "创建规则");
            Assert.IsTrue(Utility.IsAt(CommonElement.notification, "创建规则成功"), "创建规则成功");
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("DeleteKeyword")]
        [TestProperty("description", "成功删除一个包含文字")]
        public void DeleteKeyword()
        {
            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\成功删除一个包含文字");
            Utility.TurnOn();
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(1 * 1000);
            MomentsSnapPage.CreateCampaign("河北");
            Thread.Sleep(1 * 1000);
            MomentsSnapPage.DeleteKeyword();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(CommonElement.notification, "请添加包含文字"), "删除包含文字");
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("DeleteReponse")]
        [TestProperty("description", "成功删除一个回复图文")]
        public void DeleteReponse()
        {
            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\成功删除一个包含文字");
            Utility.TurnOn();
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(1 * 1000);
            MomentsSnapPage.CreateCampaign("河北");
            Thread.Sleep(1 * 1000);
            MomentsSnapPage.DeleteResponse();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(CommonElement.notification, "请添加回复设置"), "删除回复成功");
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("DeleteReponse")]
        [TestProperty("description", "是否可以编辑修改包含文字")]
        public void EditKeyword()
        {
            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\是否可以编辑修改包含文字");
            Utility.TurnOn();
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(1 * 1000);
            MomentsSnapPage.CreateCampaign("河北");
            Thread.Sleep(1 * 1000);
            MomentsSnapPage.EditKeyword();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(CommonElement.notification, "更新规则成功"), "是否可以编辑修改包含文字");
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("EditResponse")]
        [TestProperty("description", "可以编辑一条回复文本内容")]
        public void EditResponse()
        {
            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\可以编辑一条回复文本内容");
            Utility.TurnOn();
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(1 * 1000);
            MomentsSnapPage.CreateCampaign("河北");
            Thread.Sleep(1 * 1000);
            MomentsSnapPage.EditResponse();
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(CommonElement.notification, "更新规则成功"), "可以编辑一条回复文本内容");
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("CheckOnMobile_Moments")]
        [TestProperty("description", "是否支持朋友圈截图")]
        public void CheckOnMobile_Moments()
        {
            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\是否支持朋友圈截图");
            Utility.TurnOn();
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(2*1000);
            MomentsSnapPage.CreateCampaign("河北");
           
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.GetToTestAccount();
            Mobile_WeChat_Utility.SendPhotoFromFileWithMenu("图片 1, 2017-03-15 17:44");
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(Mobile_WeChat_Utility.GetLatestMessageWithMenu().Text.Contains("[平台测试账号2] 说:ok"));
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("CheckOnMobile_Album")]
        [TestProperty("description", "是否支持微信相册截图")]
        public void CheckOnMobile_Album()
        {

            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\是否支持微信相册截图");
            Utility.TurnOn();
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(2 * 1000);
            MomentsSnapPage.CreateCampaign("河北");

            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.GetToTestAccount();
            Mobile_WeChat_Utility.SendPhotoFromFileWithMenu("图片 1, 2017-03-15 17:46");
            Thread.Sleep(5 * 1000);
            MobileAndroidDriver.GetScreenshot(folder, "是否支持微信相册截图");
            Assert.IsTrue(Mobile_WeChat_Utility.GetLatestMessageWithMenu().Text.Contains("[平台测试账号2] 说:ok"));
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("CheckOnMobile_Details")]
        [TestProperty("description", "是否支持微信详情页截图")]
        public void CheckOnMobile_Details()
        {
            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\是否支持微信详情页截图");
            Utility.TurnOn();
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(2 * 1000);
            MomentsSnapPage.CreateCampaign("脸盲");

            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.GetToTestAccount();
            Mobile_WeChat_Utility.SendPhotoFromFileWithMenu("图片 1, 2017-03-15 17:47");
            Thread.Sleep(5 * 1000);
            Assert.IsTrue(Mobile_WeChat_Utility.GetLatestMessageWithMenu().Text.Contains("[平台测试账号2] 说:ok"));
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("CheckOnMobile_OtherPhoto")]
        [TestProperty("description", "是否支持其他格式图片")]
        public void CheckOnMobile_OtherPhoto()
        {
            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\是否支持其他格式图片");
            Utility.TurnOn();
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(2 * 1000);
            MomentsSnapPage.CreateCampaign("河北");

            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.GetToTestAccount();
            Mobile_WeChat_Utility.SendPhotoFromFileWithMenu("图片 1, 2017-03-15 17:49");
            Thread.Sleep(5 * 1000);
            Assert.IsFalse(Mobile_WeChat_Utility.GetLatestMessageWithMenu().Text.Contains("[平台测试账号2] 说:ok"));
        }

        [TestMethod]
        [TestCategory("MomentsSnapshot_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("CheckOnMobile_Details")]
        [TestProperty("description", "是否可以停用朋友圈识图功能")]
        public void TurnOff()
        {
            string folder = PortalChromeDriver.CreateFolder(@"朋友圈截图\是否可以停用朋友圈识图功能");
            Utility.TurnOn();
            MomentsSnapPage.DeleteCampain();
            Thread.Sleep(2 * 1000);
            MomentsSnapPage.CreateCampaign("河北");

            Utility.TurnOff();

            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.GetToTestAccount();
            Mobile_WeChat_Utility.SendPhotoFromFileWithMenu("图片 1, 2017-03-15 17:44");
            Thread.Sleep(5 * 1000);
            Assert.IsFalse(Mobile_WeChat_Utility.GetLatestMessageWithMenu().Text.Contains("[平台测试账号2] 说:ok"));
        }
        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }

    }

