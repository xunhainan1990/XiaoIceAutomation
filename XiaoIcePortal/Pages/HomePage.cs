using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoIcePortal.UIElement;

namespace XiaoIcePortal.Pages
{
    public class HomePage
    {
        public static void ClickWeChatApp()
        {
            try
            {
                var weChatapp = Driver.PortalChromeDriver.GetElementByXpath(HomePageElement.weChatApp);
                weChatapp.Click();
            }
            catch
            {
                Driver.PortalChromeDriver.TakeScreenShot(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}
