using Common.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
