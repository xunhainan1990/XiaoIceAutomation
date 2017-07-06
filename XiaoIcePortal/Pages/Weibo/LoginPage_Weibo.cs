using Common;
using OpenQA.Selenium;
using Portal;
using Portal.UIElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.UIElement.Weibo;

namespace XiaoIcePortal.Pages.Weibo
{
    public class LoginPage_Weibo
    {
        public static void Unbundling()
        {
            try
            {
                PortalChromeDriver.Instance.Navigate().GoToUrl(@"http://weibo.com/login.php#_loginLayer_1482828075835");
                PortalChromeDriver.SendKeysPerXpath("//*[@id='loginname']", "18660207496");
                PortalChromeDriver.GetElementByXpath("//*[@id='pl_login_form']/div/div[3]/div[2]/div/input").SendKeys("dongni816721");
                PortalChromeDriver.ClickElementPerXpath("//*[@id='pl_login_form']/div/div[3]/div[6]/a");
                PortalChromeDriver.ClickElementPerXpath("//*[@id='plc_top']/div/div/div[3]/div[1]/ul/li[5]/a");

                PortalChromeDriver.ClickElementPerXpath("//*[@id='Pl_Official_Nav__2']/div/div/table/tbody/tr/td[3]/a");
                Thread.Sleep(10 * 1000);
                PortalChromeDriver.ClickElementPerXpath("//*[@id='Pl_Official_LeftManageCenter__72']/div/ul/li[7]/a/span");
               // Thread.Sleep(10* 1000);
                PortalChromeDriver.ClickElementPerXpath("//*[@id='Pl_Official_LeftManageCenter__72']/div/ul/li[7]/ul/li[1]/a");

                if (Utility.IsAt("//*[@id='Pl_Core_AppList__75']/div/div/div[2]/div/ul/li[1]/div[2]/p[1]/a", "微软小冰服务平台"))
                {
                    PortalChromeDriver.ClickElementPerXpath("//*[@id='Pl_Core_AppList__75']/div/div/div[2]/div/ul/li[1]/div[2]/p[3]/span[2]/a");

                    var a = PortalChromeDriver.GetElementsByTagName("span");
                    foreach (var item in a)
                    {
                        if (item.Text == "确定")
                        {
                            Thread.Sleep(10 * 1000);
                            item.Click();
                        }

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
            var items = PortalChromeDriver.GetElementsByClassName("body");
            foreach (var item in items)
            {
                if (item.FindElement(By.TagName("a")).Text.Contains(appName))
                    return true;
            }
            return false;
        }

        public static void WeiboRegister()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.register).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.Weiboauth).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.AuthButton).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.WeiboAccount).SendKeys("18660207496");
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.WeiboPassword).SendKeys("dongni816721");
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.WeiboSubmit).Click();
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.AuthSubmitButton).Click();
                //PortalChromeDriver.GetElementByXpath(HomePageElement.AuthComeplete).Click();

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
                //tab switch
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.Weiboauth).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.I_Agree).SendKeys(Keys.Space);
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.I_Agree).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.AuthButton).Click();
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.WeiboAccount).SendKeys("18660207496");
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.WeiboPassword).SendKeys("dongni816721");
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.WeiboSubmit).Click();
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.GetElementByXpath(LoginElement_Weibo.AuthSubmitButton).Click();
                Thread.Sleep(15 * 1000);
                PortalChromeDriver.GetElementByXpath(HomePageElement.AuthComeplete).Click();
                Thread.Sleep(5 * 1000);
            }
            catch (Exception e)
            {

            }
        }

        public static void Bind()
        {

        }

    }
}
