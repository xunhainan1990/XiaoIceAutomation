 using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
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
        public static AppiumWebElement GetElementByName(string name)
        {
            return androidDriver.FindElement(By.Name(name));
        }
        public static AppiumWebElement GetElementByXpath(string xpath)
        {
            return androidDriver.FindElementByXPath(xpath);
        }
        public static AppiumWebElement GetElementByClassName(string className)
        {
            return androidDriver.FindElementByClassName(className);
        }

        public static List<AppiumWebElement> GetElmentsByXpath(string xpath)
        {
            return androidDriver.FindElementsByXPath(xpath).ToList();
        }

        public static void AndroidCleanUp()
        {
            androidDriver.Dispose();
        }
    }
}
