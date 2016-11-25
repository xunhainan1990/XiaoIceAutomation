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
            catch
            {
              
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
            { }
        }
    }
}
