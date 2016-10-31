using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoIcePortal.Pages;
using XiaoIcePortal.Driver;

namespace TestCases.PortalTests
{
    public class PortalTestInit
    {
        [TestInitialize]
        public void Inti()
        {
            if (PortalChromeDriver.Instance == null)
            {
                PortalChromeDriver.ChromeInitialize();
                LoginPage.GoTo();             
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            LoginPage.GoTo();
        }
    }
}
