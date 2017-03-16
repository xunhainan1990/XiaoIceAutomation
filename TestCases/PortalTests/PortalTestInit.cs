using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal;
using Portal.Pages;
using System.Threading;
using XiaoIcePortal.Pages;

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
            //WeChatManagermentPage.GoTo_Menu_Page();
            //MenuPage.DeleteMenuItem();
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
