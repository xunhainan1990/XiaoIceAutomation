using Common;
using CSH5;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoIceH5.UIElement;

namespace XiaoIceH5
{
    public class Mobile_Weibo
    {
        public static void GoTo_Chat()
        {
            MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Message);
            MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Account);
        }

        public static void FollowStateChanged()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Myself);
                MobileAndroidDriver.GetElementByXpath(Element_Weibo.Follow).Click();
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.AllFollowed);
                MobileAndroidDriver.GetElementByName(Element_Weibo.Followed_Search).SendKeys("啊");
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.FollowedAccount);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Followed);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.UnFollowed);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.UnFollowed_Confirm);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Chat);
            }
            catch (Exception e)
            {
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Cancle);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Back);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Discovery);
                MobileAndroidDriver.GetElementByXpath(Element_Weibo.SearchEdit).SendKeys("啊");
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.FollowedAccount);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.AddFollow);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.SaveButton);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Followed);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Chat);
            }
        }

        public static void UnFollow()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Myself);
                MobileAndroidDriver.GetElementByXpath(Element_Weibo.Follow).Click();
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.AllFollowed);
                MobileAndroidDriver.GetElementByName(Element_Weibo.Followed_Search).SendKeys("啊");
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.FollowedAccount);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Followed);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.UnFollowed);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.UnFollowed_Confirm);
                MobileH5.BackButtonClick();
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement.Cancle);
                MobileH5.BackButtonClick();
            }
            catch (Exception e)
            {
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement.Cancle);
                MobileH5.BackButtonClick();
            }
        }

        public static void Follow()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Discovery);
                MobileAndroidDriver.GetElementByXpath(Element_Weibo.SearchEdit).SendKeys("啊");
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.FollowedAccount);
                if (MobileH5.IsAtPerName("加关注"))
                {
                    MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.AddFollow);
                    MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.SaveButton);
                }
                MobileAndroidDriver.GetElementsByName("啊_荀")[1].Click();
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Chat);
            }
            catch (Exception e)
            {

            }
        }

        public static void SendMessage(string input)
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(Element_Weibo.EditBox).SendKeys(input);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Send);
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
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Chat);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Setting);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.ClearHistory);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.ClearConfirm);
                MobileAndroidDriver.ClickElemnetPerName(Element_Weibo.Back);
            }
            catch (Exception e)
            {

            }

        }

    }
}
