using Common;
using Common.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    //[TestClass]
    public class LoginTest_Weibo: PortalTestInitNoCookies
    {
        [TestCategory("BVT")]
        [TestCategory("LoginWith_Outer_AddWeibo")]
        [TestMethod]
        public void LoginWith_Outer_AddWeibo()
        {
            LoginPage_Weibo.Unbundling();
            LoginPage_Weibo.WeiboRegister();
            MobileAndroidDriver.AndroidMmsInitialize();
            LoginPage.LoginWithPhoneNumber("13269120258");
            Thread.Sleep(10 * 1000);
            CSH5.MobileH5.GetLoginCode_Bind();
            PortalChromeDriver.TakeScreenShot("手机号码获取登陆密码进行登陆");
            Assert.IsTrue(LoginPage_Weibo.GetApp("啊_荀"));
        }

        [TestCategory("BVT")]
        [TestCategory("Login")]
        [TestMethod]
        public void LoginWith_Inner_AddWeibo()
        {
            LoginPage_Weibo.Unbundling();
            MobileAndroidDriver.AndroidMmsInitialize();
            LoginPage.LoginWithPhoneNumber("13269120258");
            Thread.Sleep(10 * 1000);
            CSH5.MobileH5.GetLoginCode();
            LoginPage_Weibo.AddWeiboAccount();
            PortalChromeDriver.TakeScreenShot("手机号码获取登陆密码进行登陆");
            Assert.IsTrue(LoginPage_Weibo.GetApp("啊_荀"));
        }
    }
}
