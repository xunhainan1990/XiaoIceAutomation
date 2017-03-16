using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal;
using Portal.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases.PortalTests.Weibo
{
    public class PortalTestInit_Weibo
    {
        [TestInitialize]
        public void Inti()
        {
            //    if (PortalChromeDriver.Instance == null)
            //    {
            PortalChromeDriver.ChromeInitialize();
            //}
            //LoginPage.GoTo();
            HomePage.ClickWeChatApp("啊_荀");
        }

        [TestCleanup]
        public void CleanUp()
        {
            LoginPage.GoTo();
            if (PortalChromeDriver.Instance != null)
            {
                PortalChromeDriver.Instance.Dispose();
            }
            //Thread.Sleep(60*1000);
        }
    }
}
