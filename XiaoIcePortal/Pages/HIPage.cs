using AutoItX3Lib;
using Common.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Portal.UIElement;

namespace Portal.Pages
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
                    setting = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HISettingTurnOn);
                }
                else
                {
                    setting = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HISetting);
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
                var setting = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.IsSetting);
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
                var turnOn = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HITurnOnButton);
                turnOn.Click();
            }
            catch (Exception e)
            {
                PortalChromeDriver.TakeScreenShot(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public static void TurnOff()
        {
            try
            {
                var turnOff = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HITurnOffButton);
                turnOff.Click();
                PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HITurnOffConfirm);
                var confirmButton = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HITurnOffConfirm);
                confirmButton.Click();

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
                var inputTrigger = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.TriggerAddBox);
                inputTrigger.Clear();
                inputTrigger.SendKeys(input);
                var addTriggerButton = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.TriggerAddButton);
                addTriggerButton.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(1));
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
                var inputKeywords = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.TriggerAddBox);
                inputKeywords.Clear();
                inputKeywords.SendKeys(input);
            }
            catch (Exception e) { }         
        }

        public static void DeleteTrigger()
        {
            try
            {
                var deleteButton = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.DeleteTriggerButton);
                deleteButton.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(1));
            }
            catch (Exception e)
            {
            }           
        }

        public static void EditTrigger(string appendText)
        {
            try
            {
                var editButton = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.EditTriggerButton);
                editButton.Click();
                var editCurrentTrigger = PortalChromeDriver.GetElementByClassName(HIPortalPageUIElement.EditCurrentTrigger);
                editCurrentTrigger.SendKeys(appendText);
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(1));
            }
            catch (Exception e)
            {
               
            }          
        }

        public static void DeleteTriggerByEditButton()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.EditTriggerButton).Click();
                PortalChromeDriver.GetElementByClassName(HIPortalPageUIElement.EditCurrentTrigger).Clear();
                PortalChromeDriver.GetElementByClassName(HIPortalPageUIElement.EditCurrentTrigger).SendKeys("");
                PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.OtherButton).Click();
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
                PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.EditTriggerButton).Click();
                PortalChromeDriver.GetElementByClassName(HIPortalPageUIElement.EditCurrentTrigger).Clear();
                PortalChromeDriver.GetElementByClassName(HIPortalPageUIElement.EditCurrentTrigger).SendKeys(text);
                PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.OtherButton).Click();
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
                var setting = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HIIsOn);
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
                var setting = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HIIsOff);
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
                var keywords =PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.Trigger);
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
                var alert_failure = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.Alert_Trigger);
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
                var keywords = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.SecondTrigger);
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
                var editButton = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.EditTriggerButton);
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
                var deleteButton = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.DeleteTriggerButton);
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
                if (PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.TriggerAddBox).GetAttribute("placeholder").ToString().Equals(text))
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
                PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HiChatPortal).Click();
                Thread.Sleep(5*1000);
            }
            catch (Exception e)
            {

            }       
        }

        public static bool IsHiChat()
        {
            try
            {
                if (PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.SendBox).Text.ToString().Equals("发送"))
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
                if (PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HiStaffNotVerified).Text.ToString().Trim().Equals("抱歉！非认证公众号无法绑定客服，可通过网页版对话窗口进行客服回复"))
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
                if (PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HiStaffNotVerified).Text.ToString().Trim().Contains("当前无客服"))
                {
                    return true;
                }
                else if(PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HaveBindStaff).Text.ToString().Trim().Contains("当前客服"))
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
                if (PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.HaveBindStaff).Text.ToString().Trim().Contains("当前客服"))
                {
                    PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.DeleteStaff).Click();
                    PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.DeleteStaffConfirm).Click();
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
                if (PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.Big_New_Msg_tip).GetAttribute("style")== "")
                    return true;
                return false;
            }
            catch (Exception e) { return false; }         
        }

        public static bool Is_Small_New_Msg_Tip()
        {
            try
            {
                for (int i = 1; i < 6; i++)
                {
                    var user = PortalChromeDriver.GetElementByXpath("//*[@id='msgListDiv']/div[" + i + "]/div[2]/div[1]/div[1]");
                    if (user.Text == "chrysanthemum")
                    {
                        var smallTip = PortalChromeDriver.GetElementByClassName("hichat_msg_tip");
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

        public static void OpenHiChatWindow()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.SubTabHiChat).Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            }
            catch (Exception e)
            {

            }       
        }

        public static bool IsStaffAvatar()
        {
            try
            {
                if (PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.StaffAvatar) != null)
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
                PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.timer).Click();
                Thread.Sleep(1*1000);
                return PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.LoginCodeText).GetAttribute("value");
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
                if (PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.timer).Text.ToString().Trim().Contains("后重新获取"))
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
                var text = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.LoginCodeText);
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
                if(PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.LoginCodeText).Text.Length==6)
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
                PortalChromeDriver.TakeScreenShot(System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                var okButton = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.ModifyButton);
                okButton.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(1));
            }
            catch(Exception e)
            {

            }         
        }

        public static void ClickSomewhereToSave()
        {
            try
            {
                var someWhere = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.SomewhereToSave);
                someWhere.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(1));
            }
            catch (Exception e)
            {

            }          
        }

        public static bool IsLengthWithin300()
        {
            try
            {
                var elementChatBody = PortalChromeDriver.GetElementsByClassName("conversation_item");
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
                        SendMessage("我是xun");
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
                var inputBox = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.msgInputBox);
                inputBox.Clear();
                inputBox.SendKeys(text);
                var sendButton = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.msgSendBtn);
                sendButton.Click();
            }
            catch (Exception e)
            {                

            }  
        }

        public static void SendImage()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.addimg_hidden_input).Click();
                AutoItX3 au3 = new AutoItX3();
                au3.ControlFocus("Open", "", "Edit1");
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
                au3.ControlSetText("Open", "", "Edit1", "Test.png");
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
                au3.ControlClick("Open", "", "Button1");
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            }
            catch(Exception e)
            {

            }
           
        }

        public static void TurnOnSetup()
        {
            try
            {
                LoginPage.GoTo();
                HomePage.ClickWeChatApp();
                //Go to AI Page
                WeChatManagermentPage.GoToHIPage();
                //click settings
                ClickSettings();
                //Turn on HI
                if (isOff()) { TurnOn(); DisTurnOnDialogByClickOK(); }
            }
            catch(Exception e)
            { }

        }

        public static void DisTurnOnDialogByClickOK()
        {
            try
            {
                var turnOnDialog = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.TurnOnDialog);
                turnOnDialog.Click();
            }
            catch (Exception e) { }
           
        }

        public static void DisTurnOnDialogByCancle()
        {
            try
            {
                var turnOnDialogCancle = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.TurnOnDialogCancle);
                turnOnDialogCancle.Click();
            }
            catch(Exception e)
            {

            }

        }

        public static IWebElement GetTheLastMsg()
        {
            try {
                var elementChatBody = PortalChromeDriver.GetElementsByXpath("//*[@id='page_bodyof5NLw3-cVZ0Xn14jQ3gssqS6XD4']/div");
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

        public static bool IsStaffBindOnPortal()
        {
            try
            {
                var retainButton = PortalChromeDriver.GetElementByName("重新获取");
                return true;
            }
            catch { return false; }
        }

        public static bool Can_ReceiveMesageFromMobile()
        {
            try
            {
                var elementChatBody = PortalChromeDriver.GetElementsByClassName("conversation_item");

                foreach (var item in elementChatBody)
                {
                    if (item.Text == "这里是测试账号")
                        return true;
                }
                return false;
            }
            catch(Exception e) { return false; }
        }

        public static bool Can_ReceiveImageFromMobile()
        {
            try
            {
                var elementChatBody = PortalChromeDriver.GetElementsByTagName("img");
                return true;
            }
            catch (Exception e) { return false; }
        }

        public static bool CheckTheTopUser()
        {
            try
            {
                //判断置顶的客户为发送消息的客户
                var userName = PortalChromeDriver.GetElementByXpath(HIPortalPageUIElement.TopUser).Text;
                if (userName == "chrysanthemum") return true;
                return false;
            }
            catch(Exception e)
            { return false; }

        }

        public static void ClearTriggers()
        {
            try {
                var triggers = PortalChromeDriver.GetElementsByClassName("contentText");
                if (triggers != null)
                {
                    foreach (var item in triggers)
                    {
                        DeleteTrigger();
                    }
                }
            }
            catch(Exception e)
            { }
           
           
        }
    }
}
