using Common;
using Common.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;

namespace TestCases.PortalTests
{
    public class PortalTestInitNoCookies
    {
        [TestInitialize]
        public void Inti()
        {
            if (PortalChromeDriver.Instance == null)
            {
                PortalChromeDriver.ChromeInitializeWithNoCookies();
            }
            MobileAndroidDriver.AndroidMmsInitialize();
            //MobileAndroidDriver
        }
        
    }
}
