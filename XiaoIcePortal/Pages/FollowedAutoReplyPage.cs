using Common;
using Common.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.UIElement;

namespace XiaoIcePortal.Pages
{
    public class FollowedAutoReplyPage
    {
        public static void ClearReply()
        {
            throw new NotImplementedException();
        }

        public static void AddAutoReplyText(string text)
        {
            PortalChromeDriver.ClearPerXpath(FollowedAutoReplyElement.TextInput);
            PortalChromeDriver.SendKeysPerXpath(FollowedAutoReplyElement.TextInput, text);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
        }

        public static void AddAutoReplyNews(string newsPath)
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabnews);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(newsPath);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Confirm);
            Thread.Sleep(1 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
            Thread.Sleep(2 * 1000);
        }

        public static void AddAutoReplyImage(string picChoose)
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabimage);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(picChoose);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Confirm);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
                Thread.Sleep(2 * 1000);
            }
            catch(Exception e)
            {

            }
        }

        public static void AddAutoReplyVideo(string video)
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabvideo);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(video);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Confirm);
            Thread.Sleep(1* 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
            Thread.Sleep(2 * 1000);
        }



        public static void Delete()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Delete);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Delete_Confirm);
                System.Threading.Thread.Sleep(2 * 1000);
            }
            catch(Exception e)
            {
                PortalChromeDriver.Refresh();
            }

        }

        public static void Delete_Image()
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.DeleteImage);
            Thread.Sleep(2 * 1000);
        }
    }
}
