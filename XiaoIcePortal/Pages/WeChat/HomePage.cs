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
        public static void ClickWeChatApp(string WeChatAccount)
        {
            try
            {
                for(int i=2;i<=5;i++)
                {
                    var weChatapp = PortalChromeDriver.GetElementByXpath(HomePageElement.weChatApp.Replace("{0}", i+""));
                    if(weChatapp.Text== WeChatAccount)
                    weChatapp.Click();
                }
            }
            catch
            {
                
            }
        }
    }
}
