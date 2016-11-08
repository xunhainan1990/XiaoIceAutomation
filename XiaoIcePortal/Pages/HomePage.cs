using Common.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.UIElement;

namespace Portal.Pages
{
    public class HomePage
    {
        public static void ClickWeChatApp()
        {
            try
            {
                var weChatapp = PortalChromeDriver.GetElementByXpath(HomePageElement.weChatApp);
                weChatapp.Click();
            }
            catch
            {
                
            }
        }
    }
}
