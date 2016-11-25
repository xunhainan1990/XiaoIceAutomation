using Common;
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
using System.Collections;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

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
                MobileAndroidDriver.GetScreenshot("H5.2.删除设置的关键词，是否还能触发人工客服card");
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
                var contactlist = MobileAndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
                contactlist.Click();

                var officialaccount = MobileAndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
                officialaccount.Click();

                var testAccout = MobileAndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
                testAccout.Click();
            }
            catch(Exception e)
            {

            }
           
        }

        public static void SendMessage(string text)
        {
            try {
                var keyBoardSwich = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.KeyBoardSwichXpath);
                keyBoardSwich.Click();

                var sendMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.EditTextXpath);
                sendMessage.SendKeys(text);

                var sendButton = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.SendButtonXpath);
                sendButton.Click();

            }
            catch (Exception e) {
                var sendMessage = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.EditTextXpath);
                sendMessage.Click();
                sendMessage.SendKeys(text);

                var sendButton = MobileAndroidDriver.GetElementByName(HIMobileH5Element.SendButtonXpath);
                sendButton.Click();
            }
        }

        public static void GetHiCard(string text)
        {
            try
            {
                //var keyBoardSwich = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.KeyBoardSwichXpath);
                //keyBoardSwich.Click();

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

        public static void XB_SendPhotoPerXiangCe()
        {
            try
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
            catch(Exception e)
            { }
           
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
                Thread.Sleep(2*1000);
            }
            catch(Exception e)
            {

            }

        }

    }
}
