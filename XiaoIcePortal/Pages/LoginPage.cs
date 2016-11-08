using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Driver;

namespace Portal.Pages
{
    public class LoginPage
    {
        public static void GoTo()
        {
            PortalChromeDriver.Instance.Navigate().GoToUrl(PortalChromeDriver.BaseProductAddress);
        }

        public static void LoginWithPhoneNumber(string phoneNumber)
        {
            //Input phoneNumber
            var loginInput = PortalChromeDriver.GetElementByID("phoneNumber");
            loginInput.SendKeys(phoneNumber);
            //Send Verification
            var sendVrificationButton = PortalChromeDriver.GetElementByID("sendverification");
            sendVrificationButton.Click();
        }
    }
}
