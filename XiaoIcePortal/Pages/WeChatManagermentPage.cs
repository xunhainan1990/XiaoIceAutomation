using Common.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
