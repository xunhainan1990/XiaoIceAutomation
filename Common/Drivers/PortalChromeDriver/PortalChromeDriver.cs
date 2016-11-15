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
            if (null == PortalChromeDriver.Instance)
            {
                Instance = new ChromeDriver(@"C:\Users\v-haxun\Documents\Visual Studio 2015\Projects\XiaoIceAutomation\XiaoIceAutomation\bin\Debug\Tools");
                Instance.Manage().Window.Maximize();
                ReadConfig();
                Instance.Navigate().GoToUrl(testUrl);
            }
        }

        public static void ReadConfig()
        {
            string line;
            StreamReader srTestAgainstConfig = new StreamReader(@"D:\work\XiaoIceAutomation\Common\Drivers\PortalChromeDriver\TestAgainstConfig.txt");

            while ((line = srTestAgainstConfig.ReadLine()) != null&& line!="")
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
            return Instance.FindElement(By.Id(id));
        }
        public static IWebElement GetElementByName(string name)
        {
            return Instance.FindElement(By.Name(name));
        }

        public static IWebElement GetElementByClassName(string className)
        {
            return Instance.FindElement(By.ClassName(className));
        }
        public static List<IWebElement> GetElementsByClassName(string className)
        {
            return Instance.FindElements(By.ClassName(className)).ToList();
        }
        public static IWebElement GetElementByXpath(string Xpath)
        {
            return Instance.FindElement(By.XPath(Xpath));
        }

        public static List<IWebElement> GetElementsByXpath(string Xpath)
        {
            return Instance.FindElements(By.XPath(Xpath)).ToList();
        }

        public static List<IWebElement> GetElementByTagName(string tagName)
        {
            return Instance.FindElements(By.TagName(tagName)).ToList();
        }

        public static void TakeScreenShot(string fileName)
        {
            try
            {
               //string timeStamp = string.Format("{0}_{1}_{2}_{3}{4}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute);
                string filePath = @"D:\TestResult\";
                Screenshot ss = ((ITakesScreenshot)Instance).GetScreenshot();
                string path = filePath  + fileName;
                if(Directory.Exists(path))
                {
                    Directory.Delete(path,true);
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
