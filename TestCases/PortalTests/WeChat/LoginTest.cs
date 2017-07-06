using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;
using Common;
using System.Threading;
using XiaoIcePortal.UIElement;
using Portal;
using Mobile;

namespace TestCases.PortalTests
{
    public class ZLoginTest : PortalTestInitNoCookies
    {
        [TestCategory("Login")]
        [TestCategory("LoginWith_PhoneNumber")]
        [TestMethod]
        [TestCategory("BVT")]
        public void LoginWith_PhoneNumber()
        {
            LoginPage.LoginWithPhoneNumber("13269120258");
            Thread.Sleep(10 * 1000);
            MobileAndroidDriver.AndroidMmsInitialize();
            Mobile.Mobile_WeChat_Utility.GetLoginCode();
            PortalChromeDriver.TakeScreenShot("手机号码获取登陆密码进行登陆");
            Assert.IsTrue(Utility.IsAt("/html/body/div/div[2]/div/div[1]/div/div[2]/a/span", "添加账号"));
        }

        [TestCategory("Login")]
        [TestCategory("LoginWith_WrongPhoneNumber")]
        [TestMethod]
        public void LoginWith_WrongPhoneNumber()
        {
            LoginPage.LoginWithPhoneNumber("fsfsdf34234234");
            Assert.IsTrue(Utility.IsAt(LoginElement.warp_phoneNumber_tips, "输入中包含不合法字符，请修改后重试"));
            PortalChromeDriver.GetElementByXpath("//*[@id='verification']").SendKeys("123456");
            PortalChromeDriver.ClickElementPerClassName("sbtn");
            Assert.IsTrue(Utility.IsAt(LoginElement.warp_verification_tips, "用户名或验证码不正确"));
        }

        ////[TestCategory("BVT")]
        ////[TestCategory("Login")]
        ////[TestMethod]
        ////public void LoginWith_Outer_AddWeChat()
        ////{
        ////    LoginPage.WechatRegister();
        ////    MobileAndroidDriver.AndroidMmsInitialize();
        ////    LoginPage.LoginWithPhoneNumber("13269120258");
        ////    CSH5.MobileH5.GetLoginCode();
        ////    PortalChromeDriver.TakeScreenShot("手机号码获取登陆密码进行登陆");
        ////}

        //[TestCategory("BVT")]
        //[TestCategory("Login")]
        //[TestMethod]
        //public void LoginWith_Inner_AddWeChat()
        //{
        //    LoginWith_PhoneNumber();
        //    LoginPage.AddWechatAccount();
        //    PortalChromeDriver.TakeScreenShot("手机号码获取登陆密码进行登陆");
        //    Assert.IsTrue(Utility.IsAt("/html/body/div/div[2]/div/div[1]/div/div[2]/a/span", "添加账号"));
        //}


        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
