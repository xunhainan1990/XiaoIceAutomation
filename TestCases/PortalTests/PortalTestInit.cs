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
            //    if (PortalChromeDriver.Instance == null)
            //    {
            PortalChromeDriver.ChromeInitialize();
            //}
            //LoginPage.GoTo();
            HomePage.ClickWeChatApp("平台测试账号2");
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
