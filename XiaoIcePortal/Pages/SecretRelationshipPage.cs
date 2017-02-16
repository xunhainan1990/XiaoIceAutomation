using Common;
using Common.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;

namespace XiaoIcePortal.Pages
{
    public class SecretRelationshipPage
    {
        public static void ClickSecretRelationship()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(secretRelationshipElement.secretRelationship).Click(); 
            }
            catch (Exception e)
            {
                PortalChromeDriver.GetElementByXpath(secretRelationshipElement.AllSkillLink).Click();
                PortalChromeDriver.GetElementByXpath(secretRelationshipElement.secretRelationship).Click();
            }
        }

        public static void SetNow()
        {
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.SetNow);
        }

        public static void SetLater()
        {
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.LaterSet);
        }

        public static void TurnOn()
        {
            if (!Utility.IsTurnOn())
            {
                PortalChromeDriver.ClickElementPerXpath(CommonElement.TurnOnAndOFF);
                Thread.Sleep(1*1000);
                PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.LaterSet);
            }

        }

        public static void CancleButtonClick()
        {
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.CancleButton);
        }

        public static void ClearAllAward()
        {
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.cs_awards_edit);
            var elements = PortalChromeDriver.GetElementsByXpath("//*[@id='count']");
            foreach (var item in elements)
            {
                item.Clear();
            }
            var rateElements = PortalChromeDriver.GetElementsByXpath("//*[@id='rate']");
            foreach (var item in rateElements)
            {
                item.Clear();
              
            }           
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.cs_awards_edit_ongoing);
            System.Threading.Thread.Sleep(1 * 1000);
        }

        public static void InputAwardNumber(string award_Number_Input,string award_Rate_Input)
        {
            System.Threading.Thread.Sleep(2* 1000);
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.cs_awards_edit);
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.MaxAwardNumble);
            Utility.Input(secretRelationshipElement.MaxAwardNumble, award_Number_Input);
            Utility.Input(secretRelationshipElement.AwardRate, award_Rate_Input);
            PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.cs_awards_edit_ongoing);
        }

        public static bool CheckOficailAccountShow()
        {
            try
            {
                MobileAndroidDriver.GetElementByName("公众号名称：平台测试账号2");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public static void CheckAward(string path, string award_Number_Input, string award_Rate_Input)
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.cs_awards_edit);
                var count = PortalChromeDriver.GetElementByXpath(path).FindElement(By.Id("count"));
                var rate = PortalChromeDriver.GetElementByXpath(path).FindElement(By.Id("rate"));
                count.Clear();
                rate.Clear();
                count.Click();
                count.SendKeys(award_Number_Input);
                rate.SendKeys(award_Rate_Input);
                PortalChromeDriver.ClickElementPerXpath(secretRelationshipElement.cs_awards_edit_ongoing);
            }
            catch (Exception e)
            {

            }

        }

       

    }
}
