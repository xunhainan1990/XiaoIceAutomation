using Portal.UIElement;
using System;

namespace Portal.Pages
{
    public class WeChatManagermentPage
    {
        public static void GoToHIPage()
        {
            try
            {
                var HIPage = PortalChromeDriver.GetElementByXpath(ManagermentElement.HILinkXpath);
                HIPage.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        public static void GoToCS_Skill_Page()
        {
            try
            {
                var CS_Skill_Page = PortalChromeDriver.GetElementByXpath(DocChatElement.CS_SKills);
                CS_Skill_Page.Click();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void GoToCS_Skill_Page_WithHiOff()
        {
            try
            {
                var CS_Skill_Page = PortalChromeDriver.GetElementByXpath(ManagermentElement.AllSlillsWithHiOFF);
                CS_Skill_Page.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        

        public static void GoTo_AutoReply_Page()
        {
            try
            {
                var autoReply = PortalChromeDriver.GetElementByXpath(ManagermentElement.AutoReplyXpath);
                autoReply.Click();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void GoTo_Menu_Page_FaceRanking()
        {
            try
            {
                var autoReply = PortalChromeDriver.GetElementByXpath(ManagermentElement.Menu_FaceRanking);
                autoReply.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void GoTo_Menu_Page()
        {
            try
            {
                var autoReply = PortalChromeDriver.GetElementByXpath(ManagermentElement.Menu);
                autoReply.Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void GoTo_Setting_Page()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(ManagermentElement.Setting);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void GoTo_Material_Page()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(ManagermentElement.Material);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void GoTo_MomentsSnapshot_Page()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(ManagermentElement.MomentsSnapshot);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



    }
}
