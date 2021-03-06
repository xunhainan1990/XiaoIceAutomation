﻿using Common;
using System;
using System.Collections.Generic;
using System.Threading;
using Mobile.UIElement;
using Portal;
using Portal.Pages;
using Portal.UIElement;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using Mobile;

namespace Mobile
{
    public class Mobile_WeChat_Utility
    {

        public static bool IsAt(string selector)
        {
            try
            {
                MobileAndroidDriver.GetElementByName(selector);
                return true;
            }
            catch (Exception e)
            {
               
                return false;
            }
        }
        public static bool IsAtPerName(string selector)
        {
            try
            {
                MobileAndroidDriver.GetElementByName(selector);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool IsAtPerXpath(string xpathSelector)
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(xpathSelector);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool IsAtPerClassName(string className)
        {
            try
            {
                MobileAndroidDriver.GetElementByClassName(className);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool IsAtPerXpath(string xpathSelector,string compare)
        {
            try
            {
                if(MobileAndroidDriver.GetElementByXpath(xpathSelector).GetAttribute("name").Contains(compare))
                return true;
                return false; 
            }
            catch (Exception e)
            {
                return false;
            }
        }      

        public static void ClearAllRecord()
        {
            try
            {
                MobileAndroidDriver.GetElementByName(HIMobileH5Element.chatwith_Meg).Click();
                MobileAndroidDriver.GetElementByName("更多").Click();
                MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.ClearAll).Click();
                MobileAndroidDriver.GetElementByName(HIMobileH5Element.ClearAllConfirm).Click();
                BackButtonClick();
            }
            catch (Exception e)
            { }
        }

        public static bool IsStaffBind()
        {
            try
            {
                var text = MobileAndroidDriver.GetElementByName("客服接入成功！");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void GetToTestAccount()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_WeChat.ContactList);
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.ContactList).Click();
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_WeChat.OfficialAccount);
                MobileAndroidDriver.GetElementByXpath(MobileCommonElement_WeChat.Search).Click();
                MobileAndroidDriver.GetElementByXpath(MobileCommonElement_WeChat.SearchBox).SendKeys("平台测试账号");
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_WeChat.TestAccout);
                Thread.Sleep(1*1000);
            }
            catch(Exception e)
            {

            }           
        }

        public static void SendMessageWithMenu(string text)
        {
            try
            {
                //ResetKeyboard("Appium Android Input Manager for Unicode");
                var textInputSwich = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.TextInput);
                textInputSwich.Click();

                //var keyBoardSwich = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.KeyBoardSwichXpath);
                //keyBoardSwich.Click();

                var sendMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.EditTextXpath);

                sendMessage.SendKeys(text);

                var sendButton = MobileAndroidDriver.GetElementByName(HIMobileH5Element.SendButtonXpath);
                sendButton.Click();
                Thread.Sleep(2 * 1000);

            }
            catch (Exception e)
            {
                var sendMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.EditTextXpath);
                sendMessage.Click();
                sendMessage.SendKeys(text);

                var sendButton = MobileAndroidDriver.GetElementByName(HIMobileH5Element.SendButtonXpath);
                sendButton.Click();
            }
        }

        public static void SendMessage(string text)
        {
            try {

                var sendMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.EditTextXpath);
               
                sendMessage.SendKeys(text);

                var sendButton = MobileAndroidDriver.GetElementByName(HIMobileH5Element.SendButtonXpath);
               sendButton.Click();
                Thread.Sleep(2*1000);

            }
            catch (Exception e) {
            }
        }

        public static void GetHiCard(string text)
        {
            try
            {
                var textInputSwich = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.TextInput);
                textInputSwich.Click();

                var keyBoardSwich = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.KeyBoardSwichXpath);
                keyBoardSwich.Click();

                var sendMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.EditTextXpath);
                sendMessage.SendKeys(text);

                var sendButton = MobileAndroidDriver.GetElementByName(HIMobileH5Element.SendButtonXpath);
                sendButton.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
                ClickHICard();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(20));
            }
            catch (Exception e)
            {
                var sendMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.EditTextXpath);
                sendMessage.Click();
                sendMessage.SendKeys(text);

                var sendButton = MobileAndroidDriver.GetElementByName(HIMobileH5Element.SendButtonXpath);
                sendButton.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
                ClickHICard();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(20));
            }
        }

        public static void XB_SendMessage(string text)
        {
            try
            {
                var xb_inputbox = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.xb_inputboxXpath);
                xb_inputbox.SendKeys(text);
                var xb_add_btn = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.xb_add_btnXpath);
                xb_add_btn.Click();
                xb_add_btn.Click();

            }
            catch(Exception e) { }
           
        }

        public static void BindStaff()
        {
            try
            {
                //切换到Hi的设置Tab页
                HIPage.SwichHISettingTab(HIPortalPageUIElement.SubTabHIStaff);
                //判断是否已经绑定客服，如果绑定，则删除客服
                HIPage.DeleteStaff();
                //获取绑定客服验证码
                var value = HIPage.GetLoginCode();
                //H5页面进入平台测试账号对话窗口     
                GetToTestAccount();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
                //发送验证码
                SendMessage(value);
            }
            catch(Exception e) { }
          
        }

        public static void XB_SendPhotoPerXiangJi()
        {
            try
            {
                var xb_addimg_image = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.xb_addimg_image);
                xb_addimg_image.Click();

                var xiangji = MobileAndroidDriver.GetElementByName("相机");
                xiangji.Click();

                var takePhoto = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.TakePhoto);
                takePhoto.Click();

                var sendImageConfirm = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.SendImageConfirm);
                sendImageConfirm.Click();

            }
            catch(Exception e)
            { }
           
        }

        public static void XB_SendPhotoFromFile(string fileName)
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.xb_addimg_image).Click() ;
                MobileAndroidDriver.GetElementByName("文档").Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.MoreButton).Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.ListView).Click();
                MobileAndroidDriver.GetElementByName(fileName, true).Click();
            }
            catch(Exception e)
            { }
           
        }

        public static void SendPhotoFromFileWithMenu(string fileName)
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.TextInput).Click();
                //MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.xb_addimg_image).Click();
                MobileAndroidDriver.GetElementByName("更多功能按钮，已折叠").Click();
                MobileAndroidDriver.GetElementByName("相册").Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.MoreButton).Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.ListView).Click();
                MobileAndroidDriver.GetElementByName(fileName, true).Click();
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.Send).Click();

            }
            catch (Exception e)
            {
                MobileAndroidDriver.GetElementByName("更多功能按钮，已折叠").Click();
                MobileAndroidDriver.GetElementByName("相册").Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.MoreButton).Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.ListView).Click();
                MobileAndroidDriver.GetElementByName(fileName, true).Click();
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.Send).Click();
            }

        }


        public static bool GetImageMessage(bool isMagnify)
        {
            try
            {              
                var textMessageBefore = MobileAndroidDriver.GetElementsByXpath("//android.view.View[@index='0']");
                
                List<AppiumWebElement> elements = new List<AppiumWebElement>();
                foreach (var item in textMessageBefore)
                {
                    elements.Add(item);
                }
                if (elements[elements.Count - 3].Location.X == 225)
                {
                    elements[elements.Count - 3].Click();
                    PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }          
        }

        public static bool GetAudioMessage()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/a72')]");
                    return true;                   
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool GetMagnifyImage()
        {

            try
            {
                var textMessageBefore = MobileAndroidDriver.GetElementsByXpath("//android.widget.Image[@index='0']");
                List<AppiumWebElement> elements = new List<AppiumWebElement>();
                foreach (var item in textMessageBefore)
                {
                    elements.Add(item);
                }
                if (elements[elements.Count - 1].Location.X == 81)
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

        public static  bool GetLatestMessage(string compare=null)
        {
            var textMessageBefore = MobileAndroidDriver.GetElementsByXpath("//android.widget.TextView[@index='0']");
            List<AppiumWebElement> elements = new List<AppiumWebElement>();
            foreach (var item in textMessageBefore)
            {
                elements.Add(item);
            }
    
            return elements[2].Text.Contains(compare);

        }

        public static AppiumWebElement GetLatestMessageElement()
        {
            var textMessageBefore = MobileAndroidDriver.GetElementsByXpath("//android.widget.TextView[@index='0']");
            List<AppiumWebElement> elements = new List<AppiumWebElement>();
            foreach (var item in textMessageBefore)
            {
                elements.Add(item);
            }
            
            return elements[2];      
        }

        public static AppiumWebElement GetLatestMessageWithMenu()
        {

            try
            {
                var textMessageBefore = MobileAndroidDriver.GetElementsByXpath("//android.widget.TextView[@index='0']");
                List<AppiumWebElement> elements = new List<AppiumWebElement>();
                foreach (var item in textMessageBefore)
                {
                    elements.Add(item);
                }
                return elements[elements.Count - 4];

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool GetMessage(string msg)
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(string.Format(HIMobileH5Element.ReplyFromHi,msg));
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public static void GetLoginCode()
        {
            try
            {
                MobileAndroidDriver.GetElementByName(SMSElement.TextMessage).Click();
                Thread.Sleep(5 * 1000);
                var text = MobileAndroidDriver.GetElementByXpath(SMSElement.messageContent).Text;
                string[] texts = text.Split('，', '：');
                PortalChromeDriver.GetElementByXpath("//*[@id='verification']").SendKeys(texts[2]);
                //Click SendButton
                var loginButton = PortalChromeDriver.GetElementByClassName("sbtn");
                loginButton.Click();
            }
            catch(Exception e) { }

        }

        public static void GetLoginCode_Bind()
        {
            try
            {
                MobileAndroidDriver.GetElementByName(SMSElement.TextMessage).Click();
                Thread.Sleep(5 * 1000);
                var text = MobileAndroidDriver.GetElementByXpath(SMSElement.messageContent).Text;
                string[] texts = text.Split('，', '：');
                PortalChromeDriver.GetElementsByXpath("//*[@id='verification']")[1].Click();
                PortalChromeDriver.GetElementsByXpath("//*[@id='verification']")[1].SendKeys(texts[2]);
                //Click SendButton
                var loginButton = PortalChromeDriver.GetElementByClassName("sbtn");
                loginButton.Click();
            }
            catch (Exception e) { }

        }

        public static void BackButtonClick()
        {
            try
            {
                //退出当前对话窗口
                MobileAndroidDriver.GetElementByName(HIMobileH5Element.backFromHI).Click();
            }
            catch(Exception e)
            {

            }

        }

        public static void ClickHICard()
        {
            try
            {
                //点击HICard
                var HICard = MobileAndroidDriver.GetElementByName(HIMobileH5Element.HiCardXpath);
                HICard.Click();
            }
            catch(Exception e) { }

        }

        public static bool GetMoreItmes()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.moreInfo).Click();
                var moreItems = MobileAndroidDriver.GetElementsByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/et')]");
                if (moreItems.Count>2)
                {
                    return false;
                }
                return true;
            }
            catch(Exception e)
            {
                return true;
            }
        }

        public static void BackToHome()
        {
            try
            {
                MobileAndroidDriver.androidDriver.PressKeyCode(AndroidKeyCode.Home);
            }
            catch(Exception e) { }
            
        }

        public static void OpenWeChatFromHome()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.WeChat).Click();
                Thread.Sleep(5*1000);
            }
            catch (Exception e) { }
        }

        public static void ClickReplyCard()
        {
            try
            {
                MobileAndroidDriver.GetElementByName(HIMobileH5Element.ReplyCardFromHI).Click();
                Thread.Sleep(5*1000);
            }
            catch(Exception e)
            {

            }

        }

        public static void UnFollowWeChatOffcialAccount()
        {
            try
            {
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.ContactList).Click();
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.OfficialAccount).Click();    
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.TestAccout).Click();
                //MobileAndroidDriver.GetElementByXpath("com.tencent.mm:id/qa").Click();
                //MobileAndroidDriver.GetElementByXpath(FollowedAutoReplyElement.H5OfficialAccount).Click();
                MobileAndroidDriver.GetElementByName("聊天信息").Click();
                MobileAndroidDriver.GetElementByName("更多").Click();
                MobileAndroidDriver.GetElementByXpath("//android.widget.LinearLayout[@index='3']").Click();
                Thread.Sleep(3*1000);
                MobileAndroidDriver.GetElementByName("不再关注").Click();
                //MobileAndroidDriver.GetElementByXpath("//android.widget.Button[contains(@resource-id,'com.tencent.mm:id/a_y')]").Click(); 
            }
            catch (Exception e)
            {
                Mobile_WeChat_Utility.BackButtonClick();
            }
        }

        public static void FollowWeChatOffcialAccount()
        {
            try
            {
                //ResetKeyboard("搜狗输入法小米版");
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.ContactList).Click();
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.OfficialAccount).Click();
                MobileAndroidDriver.GetElementByName("添加").Click();
                MobileAndroidDriver.GetElementByName("搜索公众号").SendKeys("cstest-2");
                Thread.Sleep(5*1000);
                //MobileAndroidDriver.androidDriver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_ENTER);
                MobileAndroidDriver.GetElementByName("微信号：cstest-2").Click();
                Thread.Sleep(3 * 1000);
            }
            catch (Exception e)
            {
                MobileAndroidDriver.GetElementByName("关注").Click();
            }
        }

        public static void ResetKeyboard(string keyboard)
        {
            BackToHome();
            MobileAndroidDriver.GetElementByXpath("//android.widget.FrameLayout[contains(@content-desc,'设置')]").Click();
            FaceRankingMobilePage_WeChat.SwipeSetting();
            MobileAndroidDriver.ClickElemnetPerName("语言和输入法");
            MobileAndroidDriver.ClickElemnetPerName("当前输入法");
            MobileAndroidDriver.ClickElemnetPerName(keyboard);
            BackToHome();
            OpenWeChatFromHome();
        }

        public static void ClickFirstLevelMenu(string menuName)
        {
            try
            {
                //确保Menu已经更新过来了
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.backFromHI).Click();
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.TestAccout).Click();
                MobileAndroidDriver.ClickElemnetPerName(menuName);
                System.Threading.Thread.Sleep(10 * 1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public static void ClickSubMenu()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/a2g')]").Click();
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView").Click();
                System.Threading.Thread.Sleep(10 * 1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public static void Moments()
        //{
        //    MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement.Discover);
        //    MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement.Moments);
        //    MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement.More);
        //    MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement.ChoosePhoto);
        //    MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement.MomentShare_Photo);
        //    MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement.Done);
        //    MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement.Send);
        //}

    }
}
