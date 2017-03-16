using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal;
using Portal.Pages;

namespace TestCases.PortalAndH5Tests
{

    public class PortalAndH5TestInit
    {
        [TestInitialize]
        public void Inti()
        {
            if (PortalChromeDriver.Instance == null)
            {
                PortalChromeDriver.ChromeInitialize();
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            LoginPage.GoTo();
        }
    }
}
