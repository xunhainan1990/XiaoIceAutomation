using Portal;
using System;
using XiaoIcePortal.UIElement;

namespace XiaoIcePortal.Pages
{
    public class ChitChatSkillPage
    {
        public static void ClickChitChatSkill()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(ChitChatSkillElement.ChitChatSkill).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
