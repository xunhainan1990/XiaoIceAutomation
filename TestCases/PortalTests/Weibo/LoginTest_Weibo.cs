using Common;
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
using XiaoIcePortal.Pages.Weibo;

namespace TestCases.PortalTests.Weibo
{
    [TestClass]
    public class LoginTest_Weibo: PortalTestInitNoCookies
    {
        [TestCategory("BVT")]
        [TestCategory("Login")]
        [TestCategory("Login_Weibo")]
        [TestCategory("LoginWith_Outer_AddWeibo")]
        [TestMethod]
        public void LoginWith_Outer_AddWeibo()
        {
            LoginPage_Weibo.Unbundling();
            LoginPage_Weibo.WeiboRegister();
            MobileAndroidDriver.AndroidMmsInitialize();
            LoginPage.LoginWithPhoneNumber("13269120258");
            Thread.Sleep(10 * 1000);
            Mobile.Mobile_WeChat_Utility.GetLoginCode_Bind();
            PortalChromeDriver.TakeScreenShot("手机号码获取登陆密码进行登陆");
            Assert.IsTrue(LoginPage_Weibo.GetApp("啊_荀"));
        }

        [TestCategory("BVT")]
        [TestCategory("Login_Weibo")]
        [TestCategory("Login")]
        [TestCategory("LoginWith_Inner_AddWeibo")]
        [TestMethod]
        public void LoginWith_Inner_AddWeibo()
        {
            LoginPage_Weibo.Unbundling();
            MobileAndroidDriver.AndroidMmsInitialize();
            LoginPage.LoginWithPhoneNumber("13269120258");
            Thread.Sleep(10 * 1000);
            Mobile.Mobile_WeChat_Utility.GetLoginCode();
            LoginPage_Weibo.AddWeiboAccount();
            PortalChromeDriver.TakeScreenShot("手机号码获取登陆密码进行登陆");
            Assert.IsTrue(LoginPage_Weibo.GetApp("啊_荀"));
        }
    }
}
