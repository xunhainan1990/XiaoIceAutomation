using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoIcePortal.Pages
{
    public class WeChatManagermentPage
    {
        public static void GoToHIPage()
        {
            try
            {
                var HIPage = Driver.PortalChromeDriver.GetElementByXpath(UIElement.WeChatManagermentPageUIElement.HILinkXpath);
                HIPage.Click();
            }
            catch
            {
                Driver.PortalChromeDriver.TakeScreenShot(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
           
        }
    }
}
