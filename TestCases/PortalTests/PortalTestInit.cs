using Common.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;
using System.Threading;

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
            }
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
        }

        [TestCleanup]
        public void CleanUp()
        {
            LoginPage.GoTo();
            //PortalChromeDriver.Instance.Close();
            //Thread.Sleep(60*1000);
        }
    }
}
