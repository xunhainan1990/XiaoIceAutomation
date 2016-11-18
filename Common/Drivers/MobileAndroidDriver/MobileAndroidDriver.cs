using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Common
{
    public class MobileAndroidDriver
    {
        public static AndroidDriver<AppiumWebElement> androidDriver;
        public static void AndroidInitialize()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability(CapabilityType.Platform, "Windows");
            capabilities.SetCapability("deviceName", "MI 4W");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "23");
            //WeChat
            capabilities.SetCapability("appPackage", "com.tencent.mm");
            capabilities.SetCapability("appActivity", "com.tencent.mm.ui.LauncherUI");
            capabilities.SetCapability("unicodeKeyboard", "True");
            capabilities.SetCapability("resetKeyboard", "True");
            capabilities.SetCapability("newCommandTimeout", 120);

            androidDriver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
        }

        public static void AndroidMmsInitialize()
        {

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability(CapabilityType.Platform, "Windows");
            capabilities.SetCapability("deviceName", "MI 4W");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "23");
            //WeChat
            capabilities.SetCapability("appPackage", "com.android.mms");
            capabilities.SetCapability("appActivity", "com.android.mms.ui.ConversationList");
            capabilities.SetCapability("unicodeKeyboard", "True");
            capabilities.SetCapability("resetKeyboard", "True");
            capabilities.SetCapability("newCommandTimeout", 120);

            androidDriver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
        }

        public static AppiumWebElement WaitForPageElementToLoad(By by, IWebDriver driver, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(by));
            return (AppiumWebElement)(driver.FindElement(by));
        }
        public static List<AppiumWebElement> WaitForPageElementsToLoad(By by, IWebDriver driver, int timeInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(by));
            List<AppiumWebElement> appiumElements = new List<AppiumWebElement>();
            var items = driver.FindElements(by).ToList();
            foreach (var item in items)
            {
                appiumElements.Add((AppiumWebElement)item);
            }
            return appiumElements;
        }
        public static AppiumWebElement GetElementByName(string name)
        { 
            return WaitForPageElementToLoad(By.Name(name), androidDriver, 5);
        }
        public static AppiumWebElement GetElementByXpath(string xpath)
        {
            return WaitForPageElementToLoad(By.XPath(xpath), androidDriver, 5);
        }
        public static AppiumWebElement GetElementByClassName(string className)
        {
            return WaitForPageElementToLoad(By.ClassName(className), androidDriver, 5);
        }

        public static List<AppiumWebElement> GetElementsByClassName(string className)
        {
            return WaitForPageElementsToLoad(By.ClassName(className), androidDriver, 5);
        }
            
        public static List<AppiumWebElement> GetElementsByXpath(string xpath)
        {
            return androidDriver.FindElementsByXPath(xpath).ToList();
        }

        public static void GetScreenshot(string fileName)
        { 

            string filePath = @"D:\TestResult\";
            Screenshot ss = androidDriver.GetScreenshot();
            string path = filePath + fileName;
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
            ss.SaveAsFile(path + "\\" + fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);

        }

        public static void AndroidCleanUp()
        {
            androidDriver.Dispose();
        }
    }
}
