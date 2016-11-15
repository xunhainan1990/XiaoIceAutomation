﻿using Common;
using Common.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSH5.UIElement;
using Portal;
using Portal.Pages;
using Portal.UIElement;

namespace CSH5
{
    public class HIMobileH5
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

        public static void ClearAllRecord()
        {
            try
            {
                MobileAndroidDriver.GetElementByName(HIMobileH5Element.chatwith_Meg).Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
                MobileAndroidDriver.GetElementByName("更多").Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
                MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.ClearAll).Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
                MobileAndroidDriver.GetElementByName(HIMobileH5Element.ClearAllConfirm).Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
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
            var contactlist = MobileAndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
            contactlist.Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

            var officialaccount = MobileAndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
            officialaccount.Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

            var testAccout = MobileAndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
            testAccout.Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
        }

        public static void SendMessage(string text)
        {
            try {
                var keyBoardSwich = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.KeyBoardSwichXpath);
                keyBoardSwich.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

                var sendMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.EditTextXpath);
                sendMessage.SendKeys(text);
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

                var sendButton = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.SendButtonXpath);
                sendButton.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            }
            catch (Exception e) {
                Thread.Sleep(5*1000);
                var sendMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.EditTextXpath);
                sendMessage.Click();
                sendMessage.SendKeys(text);
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

                var sendButton = MobileAndroidDriver.GetElementByName(HIMobileH5Element.SendButtonXpath);
                sendButton.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            }

        }

        public static void GetHiCard(string text)
        {
            try
            {
                var keyBoardSwich = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.KeyBoardSwichXpath);
                keyBoardSwich.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

                var sendMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.EditTextXpath);
                sendMessage.SendKeys(text);
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

                var sendButton = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.SendButtonXpath);
                sendButton.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

                ClickHICard();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(30));
            }
            catch (Exception e)
            {
                var sendMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.EditTextXpath);
                sendMessage.SendKeys(text);
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

                var sendButton = MobileAndroidDriver.GetElementByName(HIMobileH5Element.SendButtonXpath);
                sendButton.Click();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));

                ClickHICard();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(30));
            }
        }

        public static void XB_SendMessage(string text)
        {

            var xb_inputbox = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.xb_inputboxXpath);
            xb_inputbox.SendKeys(text);
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

            var xb_add_btn = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.xb_add_btnXpath);
            xb_add_btn.Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            xb_add_btn.Click();
        }

        public static void BindStaff()
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

        public static void XB_SendPhotoPerXiangJi()
        {

            var xb_addimg_image = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.xb_addimg_image);
            xb_addimg_image.Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

            var xiangji = MobileAndroidDriver.GetElementByName("相机");
            xiangji.Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

            var takePhoto = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.TakePhoto);
            takePhoto.Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

            var sendImageConfirm = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.SendImageConfirm);
            sendImageConfirm.Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
        }

        public static void XB_SendPhotoPerXiangCe()
        {
            var xb_addimg_image = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.xb_addimg_image);
            xb_addimg_image.Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

            var xiangce = MobileAndroidDriver.GetElementByName("文档");
            xiangce.Click();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));

            var documentSelect = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.DocumentSelect);
            MobileAndroidDriver.androidDriver.Pinch(documentSelect);
            MobileAndroidDriver.androidDriver.Swipe(10, 10, 0, 0, 5);
            documentSelect.Tap(1, 2);
            documentSelect.Zoom();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
        }

        public static void GetImageMessage()
        {
            var textMessageBefore = MobileAndroidDriver.GetElementByXpath("//android.webkit.WebView[contains(@content-desc,'人工客服窗口')]");
            string a= "/android.view.View[@index = '1']//android.view.View[@index='0'";
            var id = textMessageBefore.Location.X;
            var imageMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.imageMessage+ "/android.view.View[@index='"+ id + "']");
            imageMessage.Click();
        }

        public static void GetLoginCode()
        {
            MobileAndroidDriver.GetElementByName(SMSElement.TextMessage).Click();
            var text = MobileAndroidDriver.GetElementByXpath(SMSElement.messageContent).Text;
            string[] texts = text.Split('，', '：');
            PortalChromeDriver.GetElementByXpath("//*[@id='verification']").SendKeys(texts[2]);
            //Click SendButton
            var loginButton = PortalChromeDriver.GetElementByClassName("sbtn");
            loginButton.Click();
        }

        public static void BackButtonClick()
        {
            //退出当前对话窗口
            MobileAndroidDriver.GetElementByName(HIMobileH5Element.backFromHI).Click();
        }

        public static void ClickHICard()
        {
            //点击HICard
            var HICard = MobileAndroidDriver.GetElementByName(HIMobileH5Element.HiCardXpath);
            HICard.Click();
        }
    }
}
