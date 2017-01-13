using Common.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Utility
    {
        public static bool IsAt(string xpath)
        {
            try
            {
                var element = PortalChromeDriver.GetElementByXpath(xpath);
                return true;
            }
            catch(Exception e) { return false; }
        }
    
        public static bool IsAt(string xpath,string expected)
        {
            try
            {
                var element = PortalChromeDriver.GetElementByXpath(xpath);
                if(element.Text.Contains(expected)) return true;
                else { return false; }
                
            }
            catch (Exception e) { return false; }
        }

        public static bool IsAtPerClass(string className, string expected)
        {
            try
            {
                var element = PortalChromeDriver.GetElementByClassName(className);
                if (element.Text == expected) return true;
                return false;
            }
            catch (Exception e) { return false; }
        }

        public static void TurnOn(string Xpath)
        {
            try
            {
                var turnOn = PortalChromeDriver.GetElementByXpath(Xpath);

                if (turnOn.Text == "开启")
                    turnOn.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void TurnOff(string Xpath,string confirm)
        {
            try
            {
                var turnOn = PortalChromeDriver.GetElementByXpath(Xpath);

                if (turnOn.Text == "停用")
                {
                    turnOn.Click();
                    PortalChromeDriver.GetElementByXpath(confirm).Click();
                }
                    
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void BackToAllSkill()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(CommonElement.AllSkills).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void Input(string xpath,string content)
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(xpath).Clear();
                PortalChromeDriver.GetElementByXpath(xpath).SendKeys(content) ;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
