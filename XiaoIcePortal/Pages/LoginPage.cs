using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.Driver;

namespace XiaoIcePortal.Pages
{
    public class LoginPage
    {
        public static void GoTo()
        {
            PortalChromeDriver.Instance.Navigate().GoToUrl(PortalChromeDriver.BaseAddress);
        }

        public static void LoginWithPhoneNumber(string phoneNumber)
        {
            //Input phoneNumber
            var loginInput = PortalChromeDriver.GetElementByID("phoneNumber");
            loginInput.SendKeys(phoneNumber);

            //Send Verification
            var sendVrificationButton = PortalChromeDriver.GetElementByID("sendverification");
            sendVrificationButton.Click();

            //Wait the customer to input Verification Code
            var verification = PortalChromeDriver.GetElementByID("verification");
            while (verification.GetAttribute("value").Length < 6)
            {
                Thread.Sleep(1 * 1000);
            }

            //Click SendButton
            var loginButton = PortalChromeDriver.GetElementByClassName("sbtn");
            loginButton.Click();


        }
    }
}
