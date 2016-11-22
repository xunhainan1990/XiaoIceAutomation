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
        public static string testUrl = "";
        public static string cookiePath = "";

        public static void ChromeInitialize()
        {
            Instance = new ChromeDriver(@"D:\work\XiaoIceAutomation\Common\bin\Debug\Tools");

            Instance.Manage().Window.Maximize();
            string line;
            ReadConfig();
            Instance.Navigate().GoToUrl(testUrl);
            StreamReader sr = new StreamReader(cookiePath);
            while ((line = sr.ReadLine()) != null)
            {
                string[] cookies = line.Split(';', '=', '{');
                Cookie cookie = new Cookie(cookies[1], cookies[2], "/");
                Instance.Manage().Cookies.AddCookie(cookie);
            }
            Instance.Navigate().GoToUrl(testUrl);
        }

        public static void ChromeInitializeWithNoCookies()
        {
            Instance = new ChromeDriver(@"C:\Users\v-haxun\Documents\Visual Studio 2015\Projects\XiaoIceAutomation\XiaoIceAutomation\bin\Debug\Tools");
            Instance.Manage().Window.Maximize();
            ReadConfig();
            Instance.Navigate().GoToUrl(testUrl);
        }

        public static IWebElement  WaitForPageElementToLoad(By by, IWebDriver driver, int timeInSeconds=5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(by));
            return driver.FindElement(by);
        }
        public static List<IWebElement> WaitForPageElementsToLoad(By by, IWebDriver driver, int timeInSeconds=5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(by));
            return driver.FindElements(by).ToList(); ;
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
            StreamReader srTestAgainstConfig = new StreamReader(@"D:\work\XiaoIceAutomation\Common\Drivers\PortalChromeDriver\TestAgainstConfig.txt");

            while ((line = srTestAgainstConfig.ReadLine()) != null && line != "")
            {
                string para = line;
                if (para == "product")
                {
                    testUrl = PortalChromeDriver.BaseProductAddress;
                    cookiePath = @"D:\work\XiaoIceAutomation\Common\Drivers\PortalChromeDriver\ChromeCookies.txt";
                }
                else
                {
                    testUrl = PortalChromeDriver.BaseIntAddress;
                    cookiePath = @"D:\work\XiaoIceAutomation\Common\Drivers\PortalChromeDriver\IntCookies.txt";
                }
            }
        }

        public static string BaseIntAddress
        {
            get
            {
                return "http://csint.trafficmanager.cn";
            }
        }

        public static string BaseProductAddress
        {
            get
            {
                return "http://e.msxiaobing.com";
            }
        }

        public static void Refresh()
        {
            Instance.Navigate().Refresh();
        }
        public static IWebElement GetElementByID(string id)
        {
            return WaitForPageElementToLoad(By.Id(id), PortalChromeDriver.Instance);
        }
        public static IWebElement GetElementByName(string name)
        {
            return WaitForPageElementToLoad(By.Name(name), PortalChromeDriver.Instance);
        }

        public static IWebElement GetElementByClassName(string className)
        {
            return WaitForPageElementToLoad(By.ClassName(className), PortalChromeDriver.Instance);
        }
        public static List<IWebElement> GetElementsByClassName(string className)
        {
            return WaitForPageElementsToLoad(By.ClassName(className), PortalChromeDriver.Instance);
        }
        public static IWebElement GetElementByXpath(string Xpath)
        {
            return WaitForPageElementToLoad(By.XPath(Xpath), PortalChromeDriver.Instance);
        }

        public static List<IWebElement> GetElementsByXpath(string Xpath)
        {
            return WaitForPageElementsToLoad(By.XPath(Xpath), PortalChromeDriver.Instance);
        }

        public static List<IWebElement> GetElementsByTagName(string tagName)
        {
            return WaitForPageElementsToLoad(By.TagName(tagName), PortalChromeDriver.Instance);
        }

        public static IWebElement GetElementByTagName(string tagName)
        {
            return WaitForPageElementToLoad(By.TagName(tagName), PortalChromeDriver.Instance);
        }

        public static void TakeScreenShot(string fileName)
        {
            try
            {
                //string timeStamp = string.Format("{0}_{1}_{2}_{3}{4}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute);
                string filePath = @"D:\TestResult\";
                Screenshot ss = ((ITakesScreenshot)Instance).GetScreenshot();
                string path = filePath + fileName;
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
                Directory.CreateDirectory(path);
                ss.SaveAsFile(path + "\\" + fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to take screenshot.Error:" + e.ToString());
            }

        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }

    }
}
