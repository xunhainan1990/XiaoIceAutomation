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
        public static void EditAutoReplyText(string text)
        {
            PortalChromeDriver.SendKeysPerXpath(FollowedAutoReplyElement.TextInput, text);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
        }

        public static void AddAutoReplyNews()
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabnews);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Pic);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Confirm);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
        }

        public static void AddAutoReplyImage()
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabimage);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.PicChoose);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Confirm);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
        }

        public static void AddAutoReply_Image_NextPage()
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabimage);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.SendKeysPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input, "2");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input_Go);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.PicChoose);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Confirm);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
        }

        public static void AddAutoReply_Image_NextPageInput()
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabimage);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.SendKeysPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input, "2");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input_Go);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page_Image);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Confirm);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
        }

        public static void AddAutoReply_News_NextPage()
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabnews);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page_Image);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Confirm);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
        }

        public static void AddAutoReply_News_NextPageInput()
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabnews);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.SendKeysPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input,"2");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input_Go);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page_Image);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Confirm);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
        }

        public static void AddAutoReplyVideo(string video)
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.tabvideo);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.autoreply_content);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(video);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Confirm);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Bottom_Save);
        }



        public static void Delete()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Delete);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Delete_Confirm);
                Thread.Sleep(2 * 1000);
            }
            catch(Exception e)
            {
                PortalChromeDriver.Refresh();
            }

        }

        public static void Delete_Image()
        {
            PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.DeleteImage);
        }
    }
}
