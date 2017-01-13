using Common;
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

        public static void KeywordsTab()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            }
            catch (Exception e)
            {
            }
        }

        public static void TurnOnAutoReply()
        {
            try
            {
                var turnOn = PortalChromeDriver.GetElementByXpath(AutoReplyElement.TurnOnAutoReply);
                if (turnOn.Text.Equals("开启"))
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

        public static void TurnOffAutoReply()
        {
            try
            {
                var turnOn = PortalChromeDriver.GetElementByXpath(AutoReplyElement.TurnOnAutoReply);
                if (turnOn.Text.Equals("停用"))
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

        public static void AddAutoReply(string rule, string trigger, string replyContent)
        {
            try
            {
                //PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
                //TurnOnAutoReply();

                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddAutoReply);
                var regulationTextes = PortalChromeDriver.GetElementByClassName(AutoReplyElement.RegulationText);
                regulationTextes.Clear();
                regulationTextes.SendKeys(rule);
                AddTrigger(trigger,1+"");
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddReplyText);
                var replyInput = PortalChromeDriver.GetElementByXpath(AutoReplyElement.EditReply.Replace("[{0}]", "[" + 1 + "]"));
                replyInput.SendKeys(replyContent);
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.SaveButton);
            }
            catch (Exception e)
            {
            }
        }

        public static void AddAutoReply_Fuzzy_Matching(string rule, string trigger, string replyContent)
        {
            try
            {
                //PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
                //TurnOnAutoReply();

                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddAutoReply);
                var regulationTextes = PortalChromeDriver.GetElementByClassName(AutoReplyElement.RegulationText);
                regulationTextes.Clear();
                regulationTextes.SendKeys(rule);
                AddTrigger(trigger, 1 + "");
                PortalChromeDriver.ClickElementPerXpath("/html/body/div/div[2]/div[2]/div[2]/div/div[1]/div[1]/div[2]/span");
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.Fuzzy_Matching);
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddReplyText);
                var replyInput = PortalChromeDriver.GetElementByXpath(AutoReplyElement.EditReply.Replace("[{0}]", "[" + 1 + "]"));
                replyInput.SendKeys(replyContent);
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.SaveButton);
            }
            catch (Exception e)
            {
            }
        }

        public static void AddReply_Text(string reply,string count)
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddReplyText);
                PortalChromeDriver.GetElementByXpath(AutoReplyElement.EditReply.Replace("[{0}]", "[" + count + "]")).Clear();
                PortalChromeDriver.GetElementByXpath(AutoReplyElement.EditReply.Replace("[{0}]", "[" + count + "]")).SendKeys(reply);
            }
            catch (Exception e)
            {
            }
        }

        public static void AddReply_Pic(int count)
        {
            try
            {
                if(count>3)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.ReplyPic);
                        Thread.Sleep(2 * 1000);
                        PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.PicLink.Replace("{1}", "1").Replace("{0}", i + ""));
                        Thread.Sleep(2 * 1000);
                        PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.PicConfirm);
                        Thread.Sleep(2 * 1000);
                    }

                    for (int i = 1; i <= count - 3; i++)
                    {
                        PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.ReplyPic);
                        Thread.Sleep(2 * 1000);
                        PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.PicLink.Replace("{1}", 2 + "").Replace("{0}", i + ""));
                        Thread.Sleep(2 * 1000);
                        PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.PicConfirm);
                        Thread.Sleep(2 * 1000);
                    }
                }
                else
                {
                    for (int i = 1; i <= count; i++)
                    {
                        PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.ReplyPic);
                        Thread.Sleep(2 * 1000);
                        PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.PicLink.Replace("{1}", "1").Replace("{0}", i + ""));
                        Thread.Sleep(2 * 1000);
                        PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.PicConfirm);
                        Thread.Sleep(2 * 1000);
                    }
                }
               

            }
            catch (Exception e)
            {
            }
        }

        public static void AddTrigger(string trigger,string count)
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddTrigger);
                var triggerInput = PortalChromeDriver.GetElementByXpathByClassName(AutoReplyElement.AddTriggerParent.Replace("{0}", count), AutoReplyElement.AddTriggerInput);
                triggerInput.Clear();
                triggerInput.SendKeys(trigger);
            }
            catch (Exception e)
            {
            }
        }

        public static void DeleteReply()
        {
            try
            {
                var deleteButton = PortalChromeDriver.GetElementByXpath(AutoReplyElement.DeleteButtonXpath);
                deleteButton.Click();
                var ok_btn = PortalChromeDriver.GetElementByXpath(AutoReplyElement.ok_btn);
                ok_btn.Click();
                Thread.Sleep(1 * 1000);
            }
            catch (Exception e)
            {
                PortalChromeDriver.Refresh();
            }
        }

        public static void ClearReply()
        {

            try
            {
                var deleteButtons = PortalChromeDriver.GetElementsByClassName(AutoReplyElement.DeleteButton);
                foreach (var deleteButton in deleteButtons)
                {
                    DeleteReply();
                }
            }
            catch (Exception e) { }
        }


        public static void EditRule(String rule)
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.entity_expand);
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.EditRule);
                var regulationTextes = PortalChromeDriver.GetElementByXpathByClassName(AutoReplyElement.RegulationTextParent, AutoReplyElement.RegulationText);
                regulationTextes.Click();
                regulationTextes.Clear();
                regulationTextes.SendKeys(rule);
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.SaveButton);
                Thread.Sleep(2 * 1000);
            }
            catch (Exception e)
            {
            }
        }
        public static void EditTriger(String trigger)
        {
            try
            {
                //PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.entity_expand); 
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.EditTrigger);
                var regulationTextes = PortalChromeDriver.GetElementByXpathByClassName(AutoReplyElement.AddTriggerParent.Replace("{0}", 1+""), AutoReplyElement.AddTriggerInput);
                regulationTextes.Click();
                regulationTextes.Clear();
                regulationTextes.SendKeys(trigger);
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.SaveButton);
                Thread.Sleep(2 * 1000);
            }
            catch (Exception e)
            { }
        }

        public static void DeleteTrigger()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.DeleteTrigger);
            }
            catch (Exception e)
            { }
        }
        public static void EditReply(String reply)
        {
            try
            {
                //PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.entity_expand);
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.ReplyContent.Replace("{0}","1"));
                PortalChromeDriver.GetElementByXpath(AutoReplyElement.EditReply.Replace("{0}", "1")).Clear();
                PortalChromeDriver.GetElementByXpath(AutoReplyElement.EditReply.Replace("{0}", "1")).SendKeys(reply);
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.SaveButton);
            }
            catch (Exception e)
            {
            }
        }
        public static void DeleteReplyInner()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.DeleteReply);
            }
            catch (Exception e)
            { }
        }
        
        public static void AddEmoj()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddReplyText);
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddEmoj);
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.SmileFace);
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.SaveButton);
            }
            catch (Exception e)
            {
            }
        }

        public static void DeletePicReply(int count)
        {
            try
            {
                for (int i = 1; i <= count; i++)
                {
                    PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.DeletePicReply.Replace("{0}", i + ""));
                }
            }
            catch (Exception e)
            {
            }
        }

        public static void Alert_Failure_OK()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.OK_btn);
            }
            catch (Exception e)
            {
            }
        }

    }
}
