using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using XiaoIcePortal.Pages;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using System.IO;

namespace XiaoIcePortal.Driver
{
    public static class PortalChromeDriver
    {
        public static IWebDriver Instance { get; set; }

        public static void ChromeInitialize()
        {
            if (null == PortalChromeDriver.Instance)
            {
                Instance = new ChromeDriver(@"C:\Users\v-haxun\Documents\Visual Studio 2015\Projects\XiaoIceAutomation\XiaoIceAutomation\bin\Debug\Tools");
                Instance.Manage().Window.Maximize();
                LoginPage.GoTo();        
                string line;
                StreamReader sr = new StreamReader(@"C:\Users\v-haxun\Documents\Visual Studio 2015\Projects\XiaoIceAutomation\XiaoIcePortal\Driver\ChromeCookies.txt");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] cookies = line.Split(';', '=', '{');
                    Cookie cookie = new Cookie(cookies[1], cookies[2], "/");
                    Instance.Manage().Cookies.AddCookie(cookie);
                }
                LoginPage.GoTo();
            }
        }

        public static string BaseAddress
        {
            get
            {
                return "http://e.msxiaobing.com/";
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
                string filePath = @"D:\TestResult\";
                Screenshot ss = ((ITakesScreenshot)Instance).GetScreenshot();
                string path = filePath  + fileName;
                Directory.CreateDirectory(path);
                ss.SaveAsFile(filePath + fileName + "\\" + fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to take screenshot.Error:" + e.ToString());
            }

        }

    }
}
