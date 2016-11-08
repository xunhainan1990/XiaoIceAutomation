﻿using Common.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;

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
        }

        [TestCleanup]
        public void CleanUp()
        {
            LoginPage.GoTo();
            //PortalChromeDriver.Instance.Close();
        }
    }
}
