using Common.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.UIElement;

namespace XiaoIcePortal.Pages
{
    public class AutoReplyPage
    {
        public static void TurnOnAutoReply()
        {
            try
            {
                var turnOn = PortalChromeDriver.GetElementByXpath(AutoReplyElement.TurnOnAutoReply);
                if(turnOn.Text.Equals("开启"))
                {
                    turnOn.Click();
                    var ok_btn = PortalChromeDriver.GetElementByXpath(AutoReplyElement.ok_btn);
                    ok_btn.Click();
                }
                
            }
            catch (Exception e)
            {

            }
        }

        public static void AddReply(string trigger)
        {
            try
            {
                var keyWordsReply = PortalChromeDriver.GetElementByXpath(AutoReplyElement.KeyWordsReply);
                keyWordsReply.Click();
                TurnOnAutoReply();
                ClearTrigger();
                var addAutoReply = PortalChromeDriver.GetElementByXpath(AutoReplyElement.AddAutoReply);
                addAutoReply.Click();
                var regulationTextes = PortalChromeDriver.GetElementByClassName(AutoReplyElement.RegulationText);
                regulationTextes.Clear();
                regulationTextes.SendKeys("A");
                var addTrigger = PortalChromeDriver.GetElementByXpath(AutoReplyElement.AddTrigger);
                addTrigger.Click();
                var triggerInput = PortalChromeDriver.GetElementByXpathByClassName(AutoReplyElement.AddTriggerParent, AutoReplyElement.AddTriggerInput);
                triggerInput.Clear();
                triggerInput.SendKeys("Hi");
                var AddReplyText = PortalChromeDriver.GetElementByXpath(AutoReplyElement.AddReplyText);
                AddReplyText.Click();
                var replyInput = PortalChromeDriver.GetElementByXpath(AutoReplyElement.ReplyInput);
                replyInput.SendKeys("这里是自动回复");
                var saveButton = PortalChromeDriver.GetElementByXpath(AutoReplyElement.SaveButton);
                saveButton.Click();
            }
            catch (Exception e)
            { }
        }

        public static void DeleteTrigger()
        {
            try
            {
                var deleteButton = PortalChromeDriver.GetElementByXpath(AutoReplyElement.DeleteButtonXpath);
                deleteButton.Click();
                var ok_btn = PortalChromeDriver.GetElementByXpath(AutoReplyElement.ok_btn);
                ok_btn.Click();
                Thread.Sleep(1 * 1000);
            }
            catch (Exception e) { }
        }

        public static void ClearTrigger()
        {

            try
            {
                var deleteButtons = PortalChromeDriver.GetElementsByClassName(AutoReplyElement.DeleteButton);
                foreach (var deleteButton in deleteButtons)
                {
                    DeleteTrigger();
                }
            }
            catch (Exception e) { }
        }
    }
}
