using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;
using Common;
using Common.Driver;

namespace TestCases.PortalTests
{
    [TestClass]
    public class LoginTest: PortalTestInitNoCookies
    {
        [TestMethod]
        public void LoginWith_PhoneNumber()
        {
            LoginPage.LoginWithPhoneNumber("13269120258");
            CSH5.HIMobileH5.GetLoginCode();
        }
    }
}
