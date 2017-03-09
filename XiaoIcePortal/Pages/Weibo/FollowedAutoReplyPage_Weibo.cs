using AutoItX3Lib;
using Common.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.UIElement;

namespace XiaoIcePortal.Pages.Weibo
{
    public class FollowedAutoReplyPage_Weibo
    {
        public static void AddAutoReplyImage(string image)
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabimage);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            AutoItX3 au3 = new AutoItX3();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            au3.ControlFocus("Open", "", "Edit1");
            au3.ControlSetText("Open", "", "Edit1", @"C:\Users\v-haxun\Desktop\Image\"+ image);
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            au3.ControlClick("Open", "", "Button1");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
            //Thread.Sleep(2 * 1000);
        }

        public static void AddAutoReplyVoice(string video)
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabvoice);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            AutoItX3 au3 = new AutoItX3();
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(10));
            au3.ControlFocus("Open", "", "Edit1");
            au3.ControlSetText("Open", "", "Edit1", @"D:\Test case\Test case\测试素材\Test AMR\" + video);
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(2));
            au3.ControlClick("Open", "", "Button1");
            PortalChromeDriver.Wait(TimeSpan.FromSeconds(5));

            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
        }
    }
}
