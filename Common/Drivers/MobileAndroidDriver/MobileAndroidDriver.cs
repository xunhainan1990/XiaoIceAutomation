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
        public static void AndroidInitializeWithoutChangingKeyboard()
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
            capabilities.SetCapability("unicodeKeyboard", "False");
            capabilities.SetCapability("resetKeyboard", "True");
            capabilities.SetCapability("newCommandTimeout", 120);

            androidDriver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
        }
        public static void AndroidWeiboInitialize()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability(CapabilityType.Platform, "Windows");
            capabilities.SetCapability("deviceName", "MI 4W");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "23");
            //WeChat
            capabilities.SetCapability("appPackage", "com.sina.weibo");
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

        public static AppiumWebElement WaitForPageElementToLoad(By by, IWebDriver driver, int timeInSeconds = 25, bool conti= false)
        {
            if (conti)
            {
                return (AppiumWebElement)(driver.FindElement(by));
            }
            else
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
                wait.Until(ExpectedConditions.ElementExists(by));
                return (AppiumWebElement)(driver.FindElement(by));
           
            }

        }
        public static List<AppiumWebElement> WaitForPageElementsToLoad(By by, IWebDriver driver, int timeInSeconds=20)
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
        public static AppiumWebElement GetElementByName(string name, bool conti = false)
        { 
            return WaitForPageElementToLoad(By.Name(name), androidDriver,25, conti);
        }
        public static AppiumWebElement GetElementByXpath(string xpath, bool conti = false)
        {
            return WaitForPageElementToLoad(By.XPath(xpath), androidDriver,25, conti);
        }
        public static AppiumWebElement GetElementByClassName(string className)
        {
            return WaitForPageElementToLoad(By.ClassName(className), androidDriver);
        }

        public static List<AppiumWebElement> GetElementsByClassName(string className)
        {
            return WaitForPageElementsToLoad(By.ClassName(className), androidDriver);
        }
            
        public static List<AppiumWebElement> GetElementsByXpath(string xpath)
        {
            return WaitForPageElementsToLoad(By.XPath(xpath), androidDriver);
        }

        public static void GetScreenshot(string filePath, string fileName)
        {
            Thread.Sleep(4 * 1000);
            try
            {
                //string filePath = @"D:\TestResult\";
                Screenshot ss = androidDriver.GetScreenshot();
                //string path = filePath + fileName;
                //if (Directory.Exists(path))
                //{
                //    Directory.Delete(path, true);
                //}
                //Directory.CreateDirectory(path);
                ss.SaveAsFile(filePath + "\\" + fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch(Exception e)
            { }
           
        }

        public static void LongPress(AppiumWebElement appiumElement)
        {
            try
            {
                androidDriver.Tap(1, appiumElement,5*1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void Swipe(AppiumWebElement appiumElement)
        {
            try
            {
                var a = appiumElement.Location;
                androidDriver.Swipe(a.X+1000,a.Y+1000,a.X,a.Y,1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AndroidCleanUp()
        {
            androidDriver.Dispose();
        }

        public static void ClickElemnetPerName(string name)
        {
            try
            {
                MobileAndroidDriver.GetElementByName(name).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static bool IsAt(string path,string value)
        {
            try
            {
                if (MobileAndroidDriver.GetElementByXpath(path).Text.Contains(value))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
