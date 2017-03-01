using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Driver;
using OpenQA.Selenium;
using XiaoIcePortal.UIElement;
using Portal.UIElement;

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
            var loginInput=PortalChromeDriver.WaitForPageElementToLoad(By.Id("phoneNumber"), PortalChromeDriver.Instance);
            loginInput.SendKeys(phoneNumber);
            //Send Verification
            var sendVrificationButton = PortalChromeDriver.GetElementByID("sendverification");
            sendVrificationButton.Click();
        }

        public static void WechatRegister()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(LoginElement.register).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement.Wechatauth).Click();
                while (PortalChromeDriver.WaitForPageElementToLoad(By.XPath(LoginElement.PhoneNumber), PortalChromeDriver.Instance,300).Text!="手机号")
                {
                    Thread.Sleep(1*1000);
                }

            }
            catch (Exception e)
            {

            }
        }

        public static void WeiboRegister()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(LoginElement.register).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement.Weiboauth).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement.AuthButton).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement.WeiboAccount).SendKeys("18660207496");
                PortalChromeDriver.GetElementByXpath(LoginElement.WeiboPassword).SendKeys("dongni816721");
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(LoginElement.WeiboSubmit).Click();
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(LoginElement.AuthSubmitButton).Click();
                //PortalChromeDriver.GetElementByXpath(HomePageElement.AuthComeplete).Click();

            }
            catch (Exception e)
            {

            }
        }

        public static void AddWechatAccount()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(HomePageElement.AddAccount).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement.Wechatauth).Click();
                while (PortalChromeDriver.WaitForPageElementToLoad(By.XPath(HomePageElement.AuthComeplete), PortalChromeDriver.Instance, 300).Text != "授权完成并返回首页")
                {
                    Thread.Sleep(1 * 1000);
                }
                PortalChromeDriver.GetElementByXpath(HomePageElement.AuthComeplete).Click();
            }
            catch (Exception e)
            {

            }
        }

   



    }
}
