using AutoItX3Lib;
using Common.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoIcePortal.UIElement;

namespace XiaoIcePortal.Pages.Weibo
{
    public class MebuPage_Weibo
    {
        public static void AddMenu_Image()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabImage);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);

                AutoItX3 au3 = new AutoItX3();
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
                au3.ControlFocus("Open", "", "Edit1");
                au3.ControlSetText("Open", "", "Edit1", @"C:\Users\v-haxun\Desktop\Image\efwe.jpg");
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
                au3.ControlClick("Open", "", "Button1");
                PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
