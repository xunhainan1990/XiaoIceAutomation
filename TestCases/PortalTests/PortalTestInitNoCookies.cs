using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mobile;
using Portal;
using Portal.Pages;
using System.Threading;

namespace TestCases.PortalTests
{
    public class PortalTestInitNoCookies
    {
        [TestInitialize]
        public void Inti()
        {
            if (PortalChromeDriver.Instance== null)
            {
                PortalChromeDriver.ChromeInitializeWithNoCookies();
            }
            LoginPage.GoTo();
            //MobileAndroidDriver
        }
        [TestCleanup]
        public void CleanUp()
        {
            //if (PortalChromeDriver.Instance != null)
            //{
                PortalChromeDriver.Instance.Close();
                PortalChromeDriver.Instance.Dispose();
            //}
            if(MobileAndroidDriver.androidDriver!=null) MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
