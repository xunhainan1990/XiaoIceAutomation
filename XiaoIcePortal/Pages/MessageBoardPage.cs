using Common.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoIcePortal.UIElement;

namespace XiaoIcePortal.Pages
{
    public class MessageBoardPage
    {
        public static void ClickMessageBoard()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(MessageBoardElement.MessageBoard).Click();
            }
            catch (Exception e)
            {
                PortalChromeDriver.GetElementByXpath(MessageBoardElement.AllSkillLink).Click();
                PortalChromeDriver.GetElementByXpath(MessageBoardElement.MessageBoard).Click();
            }
        }
    }
}
