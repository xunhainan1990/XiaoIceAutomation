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

        public static void AddWeiboAccount()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(HomePageElement.AddAccount).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement.Weiboauth).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement.AuthButton).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement.WeiboAccount).SendKeys("18660207496");
                PortalChromeDriver.GetElementByXpath(LoginElement.WeiboPassword).SendKeys("dongni816721");
                Thread.Sleep(5*1000);
                PortalChromeDriver.GetElementByXpath(LoginElement.WeiboSubmit).Click();
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.GetElementByXpath(LoginElement.AuthSubmitButton).Click();
                Thread.Sleep(15* 1000);
                PortalChromeDriver.GetElementByXpath(HomePageElement.AuthComeplete).Click();
                Thread.Sleep(5 * 1000);
            }
            catch (Exception e)
            {

            }
        }

        public static void Unbundling()
        {
            try
            {
                PortalChromeDriver.Instance.Navigate().GoToUrl(@"http://weibo.com/login.php#_loginLayer_1482828075835");
                PortalChromeDriver.SendKeysPerXpath("//*[@id='loginname']", "18660207496");
                PortalChromeDriver.GetElementByXpath("//*[@id='pl_login_form']/div/div[3]/div[2]/div/input").SendKeys("dongni816721");
                PortalChromeDriver.ClickElementPerXpath("//*[@id='pl_login_form']/div/div[3]/div[6]/a");
                Thread.Sleep(10*1000);
                PortalChromeDriver.ClickElementPerXpath("//*[@id='plc_top']/div/div/div[3]/div[1]/ul/li[5]/a");

                PortalChromeDriver.ClickElementPerXpath("//*[@id='Pl_Official_Nav__2']/div/div/table/tbody/tr/td[3]/a");
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.ClickElementPerXpath("//*[@id='Pl_Official_LeftManageCenter__74']/div/ul/li[7]/a");
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.ClickElementPerXpath("//*[@id='Pl_Official_LeftManageCenter__74']/div/ul/li[7]/ul/li[1]/a");
                Thread.Sleep(5 * 1000);
                if (Utility.IsAt("//*[@id='Pl_Core_AppList__77']/div/div/div[2]/div/ul/li[1]/div[2]/p[1]/a", "微软小冰服务平台"))
                {
                    PortalChromeDriver.ClickElementPerXpath("//*[@id='Pl_Core_AppList__77']/div/div/div[2]/div/ul/li[1]/div[2]/p[3]/span[2]/a");
                    Thread.Sleep(10 * 1000);
                    var a = PortalChromeDriver.GetElementsByTagName("span");
                    Thread.Sleep(10 * 1000);
                    foreach (var item in a)
                    {
                        if (item.Text == "确定")
                            Thread.Sleep(3 * 1000);
                        item.Click();
                    }

                }
                else
                {
                    PortalChromeDriver.Instance.Navigate().GoToUrl(PortalChromeDriver.BaseProductAddress);
                }
                PortalChromeDriver.Instance.Navigate().GoToUrl(PortalChromeDriver.BaseProductAddress);
            }
            catch (Exception e)
            {
                PortalChromeDriver.Instance.Navigate().GoToUrl(PortalChromeDriver.BaseProductAddress);
            }
        }

        public static bool GetApp(string appName)
        {
            var items=PortalChromeDriver.GetElementsByClassName("body");
            foreach (var item in items)
            {
                if (item.FindElement(By.TagName("a")).Text.Contains(appName))
                    return true;
            }
            return false;
        }
    }
}
