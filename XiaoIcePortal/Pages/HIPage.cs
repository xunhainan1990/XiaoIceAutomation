using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.Driver;
using XiaoIcePortal.UIElement;

namespace XiaoIcePortal.Pages
{
    public class HIPage
    {
        public static void ClickSettings()
        {
            try
            {
                IWebElement setting = null ;
                if (HIPage.IsHiChat())
                {
                    setting = PortalChromeDriver.GetElementByXpath(HIPageUIElement.HISettingTurnOn);
                }
                else
                {
                    setting = PortalChromeDriver.GetElementByXpath(HIPageUIElement.HISetting);
                }          
                setting.Click();
            }
            catch (Exception e)
            {
                LoginPage.GoTo();
            }
        }

        public static bool IsSetting()
        {
            try
            {
                var setting = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.IsSetting);
                if (setting.Text.ToString().Equals("人工客服"))
                    return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void TurnOn()
        {
            try
            {
                var turnOn = PortalChromeDriver.GetElementByXpath(HIPageUIElement.HITurnOnButton);
                turnOn.Click();
            }
            catch (Exception e)
            {
                Driver.PortalChromeDriver.TakeScreenShot(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public static void TurnOff()
        {
            try
            {
                var turnOff = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.HITurnOffButton);
                turnOff.Click();
                Thread.Sleep(5 * 1000);
                var confirmButton = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.HITurnOffConfirm);
                Thread.Sleep(5 * 1000);
                confirmButton.Click();
                Thread.Sleep(5 * 1000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to Turn Off HI.Error" + e.ToString());
            }
        }

        public static void InputTrigger(string input)
        {
            try
            {
                var inputTrigger = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.TriggerAddBox);
                inputTrigger.Clear();
                inputTrigger.SendKeys(input);
                var addTriggerButton = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.TriggerAddButton);
                addTriggerButton.Click();
            }
            catch (Exception e)
            {
                //加log
            }         
        }

        public static void InputTriggerWithoutSave(string input)
        {
            try
            {
                var inputKeywords = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.TriggerAddBox);
                inputKeywords.Clear();
                inputKeywords.SendKeys(input);
            }
            catch (Exception e) { }         
        }

        public static void DeleteTrigger()
        {
            try
            {
                var deleteButton = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.DeleteTriggerButton);
                deleteButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to delete keyword.Error" + e.ToString());
            }           
        }

        public static void EditTrigger(string appendText)
        {
            try
            {
                var editButton = PortalChromeDriver.GetElementByXpath(HIPageUIElement.EditTriggerButton);
                editButton.Click();
                var editCurrentTrigger = PortalChromeDriver.GetElementByClassName(HIPageUIElement.EditCurrentTrigger);
                editCurrentTrigger.SendKeys(appendText);
            }
            catch (Exception e)
            {
               
            }          
        }

        public static void DeleteTriggerByEditButton()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(HIPageUIElement.EditTriggerButton).Click();
                PortalChromeDriver.GetElementByClassName(HIPageUIElement.EditCurrentTrigger).Clear();
                PortalChromeDriver.GetElementByClassName(HIPageUIElement.EditCurrentTrigger).SendKeys("");
                PortalChromeDriver.GetElementByXpath(HIPageUIElement.OtherButton).Click();
                PortalChromeDriver.Instance.Navigate().Refresh();
            }
            catch (Exception e)
            {
                
            }
        }

        public static void ReplaceTrigger(string text)
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(HIPageUIElement.EditTriggerButton).Click();
                PortalChromeDriver.GetElementByClassName(HIPageUIElement.EditCurrentTrigger).Clear();
                PortalChromeDriver.GetElementByClassName(HIPageUIElement.EditCurrentTrigger).SendKeys(text);
                PortalChromeDriver.GetElementByXpath(HIPageUIElement.OtherButton).Click();
                PortalChromeDriver.Instance.Navigate().Refresh();
            }
            catch (Exception e)
            {
                
            }         
        }

        public static bool IsOn()
        {
            try
            {
                var setting = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.HIIsOn);
                if (setting.Text.ToString().Equals("停用"))
                    return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }         
        }

        public static bool isOff()
        {
            try
            {
                var setting = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.HIIsOff);
                if (setting.Text.ToString().Equals("开启"))
                    return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }        
        }

        public static bool iskeywordAdded(string keyword)
        {
            try
            {

                var keywords = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.Trigger);
                if (keywords.Text.ToString().Equals(keyword)) return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }        
        }

        public static bool HasAlert_Failure()
        {
            try
            {
                var alert_failure = PortalChromeDriver.GetElementByXpath(HIPageUIElement.Alert_Trigger);
                if (alert_failure.Text.Contains("保存失败")) return true;
                return false;
            }
            catch(Exception e)
            {
                return false;
            }         
        }

        public static bool isTheSameKeywordAdded(string secondKeyword)
        {
            try
            {
                var keywords = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.SecondTrigger);
                if (keywords.Text.ToString().Equals(secondKeyword)) return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }        
        }

        public static bool HasEditButton()
        {
            try
            {
                var editButton = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.EditTriggerButton);
                if (editButton!=null) return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }         
        }

        public static bool HasDeleteButton()
        {
            try
            {
                var deleteButton = Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.DeleteTriggerButton);
                if (deleteButton.GetAttribute("class").ToString().Equals("deleteHiTriggerBtn")) return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }       
        }

        public static bool AddedFiveTrigger(string text)
        {
            try
            {
                if (Driver.PortalChromeDriver.GetElementByXpath(HIPageUIElement.TriggerAddBox).GetAttribute("placeholder").ToString().Equals(text))
                    return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void SwichHISettingTab(string Xpath)
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(Xpath).Click();
            }
            catch (Exception e)
            {

            }        
        }

        public static void HiChatPoartal()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(HIPageUIElement.HiChatPortal).Click();
            }
            catch (Exception e)
            {

            }       
        }

        public static bool IsHiChat()
        {
            try
            {
                if (PortalChromeDriver.GetElementByXpath(HIPageUIElement.SendBox).Text.ToString().Equals("发送"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }         
        }

        public static bool IsNotVerified()
        {
            try
            {
                if (PortalChromeDriver.GetElementByXpath(HIPageUIElement.HiStaffNotVerified).Text.ToString().Trim().Equals("抱歉！非认证公众号无法绑定客服，可通过网页版对话窗口进行客服回复"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }      
        }

        public static bool IsVerified()
        {
            try
            {
                if (PortalChromeDriver.GetElementByXpath(HIPageUIElement.HiStaffNotVerified).Text.ToString().Trim().Contains("当前无客服"))
                {
                    return true;
                }
                else if(PortalChromeDriver.GetElementByXpath(HIPageUIElement.HaveBindStaff).Text.ToString().Trim().Contains("当前客服"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }     
        }

        public static void DeleteStaff()
        {
            try
            {
                //如果有客服就删除
                if (PortalChromeDriver.GetElementByXpath(HIPageUIElement.HaveBindStaff).Text.ToString().Trim().Contains("当前客服"))
                {
                    PortalChromeDriver.GetElementByXpath(HIPageUIElement.DeleteStaff).Click();
                    PortalChromeDriver.GetElementByXpath(HIPageUIElement.DeleteStaffConfirm).Click();
                }
            }
            catch (Exception e)
            {

            }        
        }

        public static bool Is_Big_New_Msg_Tip()
        {
            try
            {
                if (PortalChromeDriver.GetElementByXpath(HIPageUIElement.Big_New_Msg_tip) != null)
                    return true;
                return false;
            }
            catch (Exception e) { return false; }         
        }

        public static void OpenHiChatWindow()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(HIPageUIElement.SubTabHiChat).Click();
            }
            catch (Exception e)
            {

            }       
        }

        public static bool IsStaffAvatar()
        {
            try
            {
                if (PortalChromeDriver.GetElementByXpath(HIPageUIElement.StaffAvatar) != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e) { return false; }       
        }

        public static string GetLoginCode()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(HIPageUIElement.timer).Click();
                Thread.Sleep(5 * 1000);
                return  PortalChromeDriver.GetElementByXpath(HIPageUIElement.LoginCodeText).GetAttribute("value");
            }
            catch (Exception e)
            {
                return null;
            }       
        }

        public static bool IsSendLoginCode()
        {
            try
            {
                if (PortalChromeDriver.GetElementByXpath(HIPageUIElement.timer).Text.ToString().Trim().Contains("后重新获取"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e) { return false; }        
        }

        public static bool IsLoginCodeTextDisable()
        {
            try
            {
                var text = PortalChromeDriver.GetElementByXpath(HIPageUIElement.LoginCodeText);
                text.SendKeys("123456");
                if (!text.Text.Equals("123456"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool LengthOfLoginCode()
        {
            try
            {
                if(PortalChromeDriver.GetElementByXpath(HIPageUIElement.LoginCodeText).Text.Length==6)
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                Driver.PortalChromeDriver.TakeScreenShot(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public static bool CanSendVarousPhotos()
        {
            try
            {
                var elementChatBody = PortalChromeDriver.GetElementsByClassName("conversation_item");

                foreach (var item in elementChatBody)
                {
                    if (item.FindElement(By.TagName("img")).GetAttribute("class") == "xb_sendimg")
                    {
                        return true;
                    }            
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }         
        }

        public static void ClickModifyButton()
        {
            try
            {
                var okButton = PortalChromeDriver.GetElementByXpath(HIPageUIElement.ModifyButton);
                okButton.Click();
            }
            catch(Exception e)
            {

            }         
        }

        public static void ClickSomewhereToSave()
        {
            try
            {
                var someWhere = PortalChromeDriver.GetElementByXpath(HIPageUIElement.SomewhereToSave);
                someWhere.Click();
            }
            catch (Exception e)
            {

            }          
        }

        public static bool IsLengthWithin300()
        {
            try
            {
                var elementChatBody = XiaoIcePortal.Driver.PortalChromeDriver.GetElementsByClassName("conversation_item");
                List<String> list = new List<string>();
                foreach (var item in elementChatBody)
                {
                    if(item.Text!="")
                    {
                        list.Add(item.Text);
                    }                    
                }
                if (list[list.Count - 1] == "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789")
                    return true;
                return false;
            }
            catch(Exception e)
            {
                return false;
            }        
        }

        public static void GetTestUserFromUserList()
        {
            try
            {
                for (int i = 1; i < 7; i++)
                {
                    var user = PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[" + i + "]/div[2]/div[1]/div[1]");
                    if (user.Text == "chrysanthemum")
                    {
                        user.Click();
                    }
                }
            }
            catch(Exception e)
            {

            }       
        }
        
        public static void GetOtherUserFromUserList()
        {
            try
            {
                for (int i = 1; i < 7; i++)
                {
                    var user = PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[" + i + "]/div[2]/div[1]/div[1]");
                    if (user.Text == "xun")
                    {
                        user.Click();
                    }
                }
            }
            catch (Exception e)
            {

            }
        }   

        public static void SendMessage(string text)
        {
            try
            {
                var inputBox = PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgInputBox);
                inputBox.SendKeys(text);
                var sendButton = PortalChromeDriver.GetElementByXpath(HIPageUIElement.msgSendBtn);
                sendButton.Click();


            }
            catch (Exception e)
            {
                
            }  
        }

        public static void TurnOnSetup()
        {
            LoginPage.GoTo();
            HomePage.ClickWeChatApp();
            //Go to AI Page
            WeChatManagermentPage.GoToHIPage();
            Thread.Sleep(2 * 1000);
            //click settings
            ClickSettings();
            Thread.Sleep(2 * 1000);
            //Turn on HI
            if (isOff()) { TurnOn(); }
        }

        public static IWebElement GetTheLastMsg()
        {
            try {
                var elementChatBody = PortalChromeDriver.GetElementsByXpath("//*[@id='page_bodyo9CrYwU3juCHvh-BaVSQiiivpLl4']/div");
                List<IWebElement> eleList = new List<IWebElement>();
                foreach (var item in elementChatBody)
                {
                    eleList.Add(item);
                }
                if (eleList.Count != 0)
                {
                    return eleList[eleList.Count - 1];
                }
                return null;
            }
            catch(Exception e)
            {
                return null;
            }
           
        }
    }
}
