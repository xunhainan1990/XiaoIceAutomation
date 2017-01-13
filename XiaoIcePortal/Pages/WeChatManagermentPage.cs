using Common.Driver;
using Portal.UIElement;
using System;

namespace Portal.Pages
{
    public class WeChatManagermentPage
    {
        public static void GoToHIPage()
        {
            try
            {
                var HIPage = PortalChromeDriver.GetElementByXpath(WeChatManagermentPageUIElement.HILinkXpath);
                HIPage.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        public static void GoToCS_Skill_Page()
        {
            try
            {
                var CS_Skill_Page = PortalChromeDriver.GetElementByXpath(DocChatElement.CS_SKills);
                CS_Skill_Page.Click();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void GoTo_AutoReply_Page()
        {
            try
            {
                var autoReply = PortalChromeDriver.GetElementByXpath(WeChatManagermentPageUIElement.AutoReplyXpath);
                autoReply.Click();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void GoTo_Menu_Page_FaceRanking()
        {
            try
            {
                var autoReply = PortalChromeDriver.GetElementByXpath(WeChatManagermentPageUIElement.Menu_FaceRanking);
                autoReply.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void GoTo_Menu_Page()
        {
            try
            {
                var autoReply = PortalChromeDriver.GetElementByXpath(WeChatManagermentPageUIElement.Menu);
                autoReply.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
