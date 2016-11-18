using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;
using Common;
using Common.Driver;
using System.Threading;

namespace TestCases.PortalTests
{
    [TestClass]
    public class LoginTest: PortalTestInitNoCookies
    {
        /// <summary>
        /// 登陆
        /// </summary>
        [TestCategory("1")]
        [TestMethod]
        public void LoginWith_PhoneNumber()
        {
            LoginPage.LoginWithPhoneNumber("13269120258");
            Thread.Sleep(10*1000);
            CSH5.HIMobileH5.GetLoginCode();
            PortalChromeDriver.TakeScreenShot("手机号码获取登陆密码进行登陆");
        }

    }
}
