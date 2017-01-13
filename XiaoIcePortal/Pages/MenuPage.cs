using System;
using XiaoIcePortal.UIElement;
using Common.Driver;
using System.Threading;
using Common;
using Portal.Pages;

namespace XiaoIcePortal.Pages
{
    public class MenuPage
    {

        public static void AddMenu(string menuName)
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(MenuElement.add_menu_item_btn).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.MenuInputBox).SendKeys(menuName);
                PortalChromeDriver.GetElementByXpath(MenuElement.MenuAddConfirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void AddMenu_Link(string link)
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(MenuElement.Jump_Page_Button).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.JumpLinkInput).SendKeys(link);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
                //Thread.Sleep(300*1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void SubMenu_AddLink(string link)
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(MenuElement.SubMenu_Jump_Page_Button).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.JumpLinkInput).SendKeys(link);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
                //Thread.Sleep(300*1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddMenu_Text(string text)
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.SendKeysPerXpath(MenuElement.TextInput, text);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();

                Thread.Sleep(300 * 1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddMenu_Image()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabImage);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageLink);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
                Thread.Sleep(300 * 1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void SubMenu_AddImage()
        {
            PortalChromeDriver.ClickElementPerXpath(MenuElement.SubMenu_Send_Message);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.tabImage);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageLink);
            PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
            PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
        }

        public static void AddMenu_News()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabNews);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.NewsLink);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
                Thread.Sleep(300 * 1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddMenu_Voice()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabVoice);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.VoiceLink);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
                //Thread.Sleep(300 * 1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void SubMenu_AddVoice()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.SubMenu_Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabVoice);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.VoiceLink);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public static void AddMenu_Video()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabVideo);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.VideoLink);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void SubMenu_AddVideo()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.SubMenu_Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabVideo);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.VideoLink);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void Delete()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Delete);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
            }
            catch (Exception e)
            {

            }
        }

        public static bool Deleted()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static void DeleteMenuItem()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(MenuElement.DeleteMenuButton).Click();
                Thread.Sleep(1 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.DeleteMenuButtonConfirm).Click();
                Thread.Sleep(1 * 1000);
            }
            catch (Exception e)
            {
                PortalChromeDriver.Refresh();
            }
        }

        public static void AddMenu_GoBack()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.GoBack);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Confirm);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddSubMenu(string menuName)
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.AddSubMenu);
                PortalChromeDriver.GetElementByXpath(MenuElement.MenuInputBox).SendKeys(menuName);
                PortalChromeDriver.GetElementByXpath(MenuElement.MenuAddConfirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddSubMenu_LevelTwo(string menuName)
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.AddSubMenu_LevelTwo);
                PortalChromeDriver.GetElementByXpath(MenuElement.MenuInputBox).SendKeys(menuName);
                PortalChromeDriver.GetElementByXpath(MenuElement.MenuAddConfirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddSubMenu_Text(string text)
        {
            try
            {

                PortalChromeDriver.ClickElementPerXpath(MenuElement.SubMenu_SendMessage);
                PortalChromeDriver.SendKeysPerXpath(MenuElement.TextInput, text);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddSubMenu_News()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.SubMenu_SendMessage);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabNews);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.NewsLink);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public static void ClickFirstLevelMenu()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/a2g')]").Click();
                Thread.Sleep(10 * 1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void ClickSubMenu()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/a2g')]").Click();
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView").Click();
                Thread.Sleep(10 * 1000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddImage_NextPage()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabImage);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageLink);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddImage_NextPageInput()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabImage);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.SendKeysPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input, "2");
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input_Go);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageLink);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddNews_NextPage()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabNews);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.NewsLink);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddNews_NextPageInput()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabNews);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.SendKeysPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input, "2");
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input_Go);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.NewsLink);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddVoice_NextPage()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabVoice);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.VoiceLink);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddVoice_NextPageInput()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabVoice);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.SendKeysPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input, "2");
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input_Go);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.VoiceLink);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddVideo_NextPage()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabVideo);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.VideoLink);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void AddVideo_NextPageInput()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MenuElement.Send_Message);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.tabVideo);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ImageChoose);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.SendKeysPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input, "2");
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(FollowedAutoReplyElement.Next_Page_Image_Input_Go);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.VideoLink);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MenuElement.ChooseConfirm);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.GetElementByXpath(MenuElement.bottom_save).Click();
                PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void ResetMenuContent()
        {
            PortalChromeDriver.ClickElementPerXpath(MenuElement.ResetMenu);
            PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            AddMenu_Text("修改的菜单内容");
        }

        public static void ResetSubMenuContent()
        {
            PortalChromeDriver.ClickElementPerXpath(MenuElement.ResetMenu);
            PortalChromeDriver.GetElementByXpath(MenuElement.Confirm).Click();
            AddSubMenu_Text("修改的菜单内容");
        }

    }
}
