using System;
using System.Threading;


namespace Portal
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

        public static bool IsAtPerClass(string className, string expected="")
        {
            try
            {
                var element = PortalChromeDriver.GetElementByClassName(className);
                if (element.Text .Contains(expected)) return true;
                return false;
            }
            catch (Exception e) { return false; }
        }

        public static bool IsAtPerCssSelector(string className)
        {
            try
            {
                var element = PortalChromeDriver.GetElementByXpathByCssSelector(className);
                return true;
            }
            catch (Exception e) { return false; }
        }

        public static void TurnOn()
        {
            try
            {
                var turnOn = PortalChromeDriver.GetElementByXpath(CommonElement.TurnOnAndOFF);

                if (turnOn.Text == "开启")
                    turnOn.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static bool IsTurnOn()
        {
            try
            {
                var setting = PortalChromeDriver.GetElementByXpath(CommonElement.TurnOnAndOFF);
                if (setting.Text.ToString().Equals("停用"))
                    return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void TurnOff()
        {
            try
            {
                var turnOn = PortalChromeDriver.GetElementByXpath(CommonElement.TurnOnAndOFF);

                if (turnOn.Text == "停用")
                {
                    turnOn.Click();
                    PortalChromeDriver.GetElementByXpath(CommonElement.Confirm).Click();
                }
                    
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void NextPage()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(CommonElement.Next_Page);
                Thread.Sleep(2 * 1000);
            }
            catch (Exception e)
            {

            }
        }
        public static void NextPageInput(string page_input)
        {
            PortalChromeDriver.SendKeysPerXpath(CommonElement.Next_Page_Input, page_input);
            PortalChromeDriver.ClickElementPerXpath(CommonElement.Next_Page_Input_Go);
            Thread.Sleep(2 * 1000);
        }

        public static void PreviousPage()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(CommonElement.Previous_Page);
                Thread.Sleep(2 * 1000);
            }
            catch (Exception e)
            {

            }
        }

        public static void DisTurnOnDialogByClickOK()
        {
            try
            {
                var turnOnDialog = PortalChromeDriver.GetElementByXpath(CommonElement.Confirm);
                turnOnDialog.Click();
            }
            catch (Exception e) { }

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
