using Common;
using CSH5;
using CSH5.UIElement;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mobile.UIElement;

namespace Mobile
{
    public class Mobile_Weibo_Utility
    {
        public static void GoTo_Chat()
        {
            MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Message);
            MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Account);
        }

        public static void FollowStateChanged()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Myself);
                MobileAndroidDriver.GetElementByXpath(MobileCommonElement_Weibo.Follow).Click();
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.AllFollowed);
                MobileAndroidDriver.GetElementByName(MobileCommonElement_Weibo.Followed_Search).SendKeys("啊");
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.FollowedAccount);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Followed);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.UnFollowed);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.UnFollowed_Confirm);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Chat);
            }
            catch (Exception e)
            {
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Cancle);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Back);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Discovery);
                MobileAndroidDriver.GetElementByXpath(MobileCommonElement_Weibo.SearchEdit).SendKeys("啊");
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.FollowedAccount);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.AddFollow);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.SaveButton);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Followed);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Chat);
            }
        }

        public static void UnFollow()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Myself);
                MobileAndroidDriver.GetElementByXpath(MobileCommonElement_Weibo.Follow).Click();
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.AllFollowed);
                //MobileAndroidDriver.GetElementByName(Element_Weibo.Followed_Search).SendKeys("啊");
                //ResetKeyboard("搜狗输入法小米版");
                //MobileAndroidDriver.androidDriver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_ENTER);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.FollowedAccount);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Chat);
                //clearAllMessage
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Setting);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.ClearHistory);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.ClearConfirm);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Back);

                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Back);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Followed);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.UnFollowed);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.UnFollowed_Confirm);
                Mobile_WeChat_Utility.BackButtonClick();
                //MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement.Cancle);
                Mobile_WeChat_Utility.BackButtonClick();
            }
            catch (Exception e)
            {
                Mobile_WeChat_Utility.BackButtonClick();
            }
        }

        public static void Follow()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Discovery);
                MobileAndroidDriver.GetElementByXpath(MobileCommonElement_Weibo.SearchEdit).SendKeys("啊_");
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.FollowedAccount);
                if (Mobile_WeChat_Utility.IsAtPerName("加关注"))
                {
                    MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.AddFollow);
                    MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.SaveButton);
                }
                MobileAndroidDriver.GetElementsByName("啊_荀")[1].Click();
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Chat);
            }
            catch (Exception e)
            {

            }
        }

        public static void SendMessage(string input)
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(MobileCommonElement_Weibo.EditBox).SendKeys(input);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Send);
            }
            catch(Exception e)
            {

            }
        }

        public static AppiumWebElement GetLatestMessage()
        {
            try
            {
                var textMessageBefore = MobileAndroidDriver.GetElementsByXpath("//android.widget.TextView[contains(@resource-id,'com.sina.weibo:id/message_content')]");
                return textMessageBefore[textMessageBefore.Count - 1];
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static void ClearAllMessage()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Chat);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Setting);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.ClearHistory);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.ClearConfirm);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_Weibo.Back);
            }
            catch (Exception e)
            {

            }

        }

        public static void ResetKeyboard(string keyboard)
        {
            Mobile_WeChat_Utility.BackToHome();
            MobileAndroidDriver.GetElementByXpath("//android.widget.FrameLayout[contains(@content-desc,'设置')]").Click();
            FaceRankingMobilePage_WeChat.SwipeSetting();
            MobileAndroidDriver.ClickElemnetPerName("语言和输入法");
            MobileAndroidDriver.ClickElemnetPerName("当前输入法");
            MobileAndroidDriver.ClickElemnetPerName(keyboard);
            Mobile_WeChat_Utility.BackToHome();
            OpenWeChatFromHome();
        }
         public static void OpenWeChatFromHome()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.WeiBo).Click();
                Thread.Sleep(5 * 1000);
            }
            catch (Exception e) { }
        }

    }
}
