using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using System.IO;
using System.Threading;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace Common.Driver
{
    public static class PortalChromeDriver
    {
        public static IWebDriver Instance { get; set; }
        public static IWebDriver WechatInstance { get; set; }
        public static IWebDriver NewInstance { get; set; }
        public static string testUrl = "";
        public static string cookiePath = "";
        public static string wechatUrl = "https://mp.weixin.qq.com/";

        public static void ChromeInitialize()
        {
            Instance = new ChromeDriver(@"C:\Users\v-haxun\Source\Repos\XiaoIceAutomation\TestCases\bin\Debug\Drivers\PortalChromeDriver");

            Instance.Manage().Window.Maximize();
            string line;
            ReadConfig();

            Instance.Navigate().GoToUrl(testUrl);
            //var loginInput = WaitForPageElementToLoad(By.Id("phoneNumber"), PortalChromeDriver.Instance);
            //loginInput.SendKeys("18613881880");
            ////Send Verification
            //var sendVrificationButton = GetElementByID("sendverification");
            //sendVrificationButton.Click();
            //Instance.Navigate().GoToUrl(testUrl);
            //var allCookie = Instance.Manage().Cookies.AllCookies;

            StreamReader sr = new StreamReader(cookiePath);
            while ((line = sr.ReadLine()) != null)
            {
                string[] cookies = line.Split(';', '=', '{');
                Cookie cookie = new Cookie(cookies[1], cookies[2], "/");
                Instance.Manage().Cookies.AddCookie(cookie);
            }
            Instance.Navigate().GoToUrl(testUrl);
         
        }

        public static void ChromeInitializeWithWechat()
        {
            WechatInstance = new ChromeDriver(@"C:\Users\v-haxun\Source\Repos\XiaoIceAutomation\TestCases\bin\Debug\Drivers\PortalChromeDriver");

            WechatInstance.Manage().Window.Maximize();
            string line;
            ReadConfig();
            WechatInstance.Navigate().GoToUrl(wechatUrl);
            StreamReader sr = new StreamReader(@"C:\Users\v-haxun\Source\Repos\XiaoIceAutomation\Common\Drivers\PortalChromeDriver\mp.weixin.txt");
            while ((line = sr.ReadLine()) != null)
            {
                string[] cookies = line.Split(';', '=', '{');
                Cookie cookie = new Cookie(cookies[1], cookies[2], "/");
                WechatInstance.Manage().Cookies.AddCookie(cookie);
            }
            WechatInstance.Navigate().GoToUrl(wechatUrl);
        }

        public static ChromeDriver ChromeInitializeNewWindow(string url)
        {
            NewInstance = new ChromeDriver(@"C:\Users\v-haxun\Source\Repos\XiaoIceAutomation\TestCases\bin\Debug\Drivers\PortalChromeDriver");

            NewInstance.Manage().Window.Maximize();
            ReadConfig();
            NewInstance.Navigate().GoToUrl(url);
            return (ChromeDriver)NewInstance;
        }

        public static void ChromeInitializeWithNoCookies()
        {
            Instance = new ChromeDriver(@"C:\Users\v-haxun\Source\Repos\XiaoIceAutomation\TestCases\bin\Debug\Drivers\PortalChromeDriver");
            Instance.Manage().Window.Maximize();
            ReadConfig();
            Instance.Navigate().GoToUrl(testUrl);
        }

        public static IWebElement  WaitForPageElementToLoad(By by, IWebDriver driver, int timeInSeconds=5)
        {
            WebDriverWait wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(by));
            return Instance.FindElement(by);
        }
        public static List<IWebElement> WaitForPageElementsToLoad(By by, IWebDriver driver, int timeInSeconds=5)
        {
            WebDriverWait wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(by));
            return Instance.FindElements(by).ToList(); ;
        }
    
        public static void WaitForPageElementToBeRemoved(By by, IWebDriver driver, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(by);
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        public static void ReadConfig()
        {
            string line;
            StreamReader srTestAgainstConfig = new StreamReader(@"C:\Users\v-haxun\Source\Repos\XiaoIceAutomation\Common\bin\Debug\Drivers\PortalChromeDriver\TestAgainstConfig.txt");

            while ((line = srTestAgainstConfig.ReadLine()) != null && line != "")
            {
                string para = line;
                if (para == "product")
                {
                    testUrl = PortalChromeDriver.BaseProductAddress;
                    cookiePath = @"C:\Users\v-haxun\Source\Repos\XiaoIceAutomation\Common\bin\Debug\Drivers\PortalChromeDriver\ChromeCookies.txt";
                }
                else if(para=="int")
                {
                    testUrl = PortalChromeDriver.BaseIntAddress;
                    cookiePath = @"C:\Users\v-haxun\Source\Repos\XiaoIceAutomation\Common\bin\Debug\Drivers\PortalChromeDriver\IntCookies.txt";
                }
                else
                {
                    testUrl = PortalChromeDriver.StagingAddress;
                    cookiePath = @"C:\Users\v-haxun\Source\Repos\XiaoIceAutomation\Common\bin\Debug\Drivers\PortalChromeDriver\ChromeCookies.txt";
                }
            }
        }

        public static string BaseIntAddress
        {
            get
            {
                return "https://csint.trafficmanager.cn";
            }
        }

        public static string StagingAddress
        {
            get
            {
                return "https://prod-cswechat-websites-0-staging.chinacloudsites.cn";
            }
        }

        public static string BaseProductAddress
        {
            get
            {
                return "https://e.msxiaobing.com";
            }
        }

        public static void Refresh()
        {
            Instance.Navigate().Refresh();
        }
        public static IWebElement GetElementByID(string id, IWebDriver driver=null)
        {
            if(driver==null)
            {
                return WaitForPageElementToLoad(By.Id(id), Instance);
            }
            else
            {
                return WaitForPageElementToLoad(By.Id(id), driver);
            }
         
        }

        public static List<IWebElement> GetElementsByID(string id, IWebDriver driver = null)
        {
            if (driver == null)
            {
                return WaitForPageElementsToLoad(By.Id(id), Instance);
            }
            else
            {
                return WaitForPageElementsToLoad(By.Id(id), driver);
            }

        }
        public static IWebElement GetElementByName(string name, IWebDriver driver=null)
        {
            if (driver == null)
            {
                return WaitForPageElementToLoad(By.Name(name),Instance);
            }
            else
            {
                return WaitForPageElementToLoad(By.Name(name), driver);
            }
        }

        public static IWebElement GetElementByClassName(string className, IWebDriver driver = null)
        {
            if (driver == null)
            {
                return WaitForPageElementToLoad(By.ClassName(className), Instance);
            }
            else
            {
                return WaitForPageElementToLoad(By.ClassName(className), driver);
            }
        }
        public static List<IWebElement> GetElementsByClassName(string className, IWebDriver driver = null)
        {
            if (driver == null)
            {
                return WaitForPageElementsToLoad(By.ClassName(className),Instance);
            }
            else
            {
                return WaitForPageElementsToLoad(By.ClassName(className), driver);
            }
        }
        public static IWebElement GetElementByXpath(string Xpath, IWebDriver driver = null)
        {
            if (driver == null)
            {
                return WaitForPageElementToLoad(By.XPath(Xpath),Instance);
            }
            else
            {
                return WaitForPageElementToLoad(By.XPath(Xpath), driver);
            }

        }

        public static List<IWebElement> GetElementsByXpath(string Xpath, IWebDriver driver = null)
        {
            if (driver == null)
            {
                return WaitForPageElementsToLoad(By.XPath(Xpath),Instance);
            }
            else
            {
                return WaitForPageElementsToLoad(By.XPath(Xpath), driver);
            }
        }

        public static List<IWebElement> GetElementsByTagName(string tagName, IWebDriver driver = null)
        {
            if (driver == null)
            {
                return WaitForPageElementsToLoad(By.TagName(tagName),Instance);
            }
            else
            {
                return WaitForPageElementsToLoad(By.TagName(tagName),driver);
            }
        }

        public static IWebElement GetElementByTagName(string tagName, IWebDriver driver = null)
        {
            if (driver == null)
            {
                return WaitForPageElementToLoad(By.TagName(tagName),Instance);
            }
            else
            {
                return WaitForPageElementToLoad(By.TagName(tagName), driver);
            }
        }

        public static IWebElement GetElementByXpathByClassName(string xpath,string className,IWebDriver driver = null)
        {
            if (driver == null)
            {
                return WaitForPageElementToLoad(By.XPath(xpath),Instance).FindElement(By.ClassName(className));
            }
            else
            {
                return WaitForPageElementToLoad(By.XPath(xpath), driver).FindElement(By.ClassName(className));
            }
        }

        public static IWebElement GetElementByXpathByCssSelector(string cssSelector,IWebDriver driver = null)
        {
            if (driver == null)
            {
                return WaitForPageElementToLoad(By.CssSelector(cssSelector), Instance);
            }
            else
            {
                return WaitForPageElementToLoad(By.CssSelector(cssSelector), driver);
            }
        }

        public static List<IWebElement> GetElementsByCssSelector(string cssSelector, IWebDriver driver = null)
        {
            if (driver == null)
            {
                return WaitForPageElementsToLoad(By.CssSelector(cssSelector), Instance);
            }
            else
            {
                return WaitForPageElementsToLoad(By.CssSelector(cssSelector), driver);
            }
        }

        public static void TakeScreenShot(string filePath, string fileName)
        {
            try
            {
                Thread.Sleep(2 * 1000);
                Screenshot ss = ((ITakesScreenshot)Instance).GetScreenshot();
                //string path = filePath + @"\" + fileName;
                //if (Directory.Exists(path))
                //{
                //    Directory.Delete(path, true);
                //}
                //Directory.CreateDirectory(path);
                ss.SaveAsFile(filePath + "\\" + fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
               
            }

        }

        public static void TakeScreenShot(string fileName)
        {
            try
            {
                Thread.Sleep(2 * 1000);
                string filePath = Environment.CurrentDirectory;
                Screenshot ss = ((ITakesScreenshot)Instance).GetScreenshot();
                string path = filePath+"\\" + fileName;
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
                Directory.CreateDirectory(path);
                ss.SaveAsFile(path + "\\" + fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
               
            }
        }

        public static string CreateFolder(string path)
        {
            //string filePath = @"D:\TestResult\";
            string filePath = Environment.CurrentDirectory+"\\";
            return Directory.CreateDirectory(filePath+path).FullName.ToString();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }

        public static void ClickElementPerXpath(string xpath)
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(xpath).Click(); ;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void SendKeysPerXpath(string xpath,string content)
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(xpath).SendKeys(content); 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void ClearPerXpath(string xpath)
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(xpath).Clear();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public static void ClickElementsPerClassName(string className)
        {
            try
            {
                foreach (var item in GetElementsByClassName(className))
                {
                    item.Click();
                } 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void ClickElementPerClassName(string className)
        {
            try
            {
                GetElementByClassName(className).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
