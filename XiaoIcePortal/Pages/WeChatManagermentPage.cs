using Common.Driver;
using System;

namespace Portal.Pages
{
    public class WeChatManagermentPage
    {
        public static void GoToHIPage()
        {
            try
            {
                var HIPage = PortalChromeDriver.GetElementByXpath(UIElement.WeChatManagermentPageUIElement.HILinkXpath);
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
                var CS_Skill_Page = PortalChromeDriver.GetElementByXpath(UIElement.DocChatElement.cs_skills);
                CS_Skill_Page.Click();
            }
            catch(Exception e)
            {

            }
        }
    }
}
