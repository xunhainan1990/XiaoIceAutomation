using Common;
using Common.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;
using System.Threading;

namespace TestCases.PortalTests
{
    public class PortalTestInitNoCookies
    {
        [TestInitialize]
        public void Inti()
        {
            if (PortalChromeDriver.Instance!= null)
            {
                PortalChromeDriver.Instance.Close();
                PortalChromeDriver.Instance.Dispose();
            }
            PortalChromeDriver.ChromeInitializeWithNoCookies();
            MobileAndroidDriver.AndroidMmsInitialize();
            //MobileAndroidDriver
        }
        [TestCleanup]
        public void CleanUp()
        {
            PortalChromeDriver.Instance.Close();
            PortalChromeDriver.Instance.Dispose();
            MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
