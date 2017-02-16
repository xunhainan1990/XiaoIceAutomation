using Portal.UIElement;
using Common.Driver;
using System;
using System.Collections.Generic;
using System.Threading;

namespace XiaoIcePortal.Pages
{
    public class DocChatPage
    {
        public static void Click_Doc_Chat_Skill()
        {
            try
            {
                var cs_skills_doc_chat = PortalChromeDriver.GetElementByXpath(DocChatElement.cs_skills_doc_chat);
                cs_skills_doc_chat.Click();
            }
            catch(Exception e)
            { }
        }

        public static void AddMaterialFromWechat()
        {
            try
            {
                var wechat_Material = PortalChromeDriver.GetElementByXpath(DocChatElement.Wechat_Material);
                wechat_Material.Click();
                var btn_add = PortalChromeDriver.GetElementByXpath(DocChatElement.Wechat_btn_add);
                btn_add.Click();
                string currentWindow = PortalChromeDriver.WechatInstance.CurrentWindowHandle;

                foreach (var item in PortalChromeDriver.WechatInstance.CurrentWindowHandle)
                {
                    if (item.Equals(currentWindow))
                        continue;
                    PortalChromeDriver.WechatInstance.SwitchTo();
                }
                //ISet<String> handles = PortalChromeDriver.WechatInstance.WindowHandles;
                PortalChromeDriver.WechatInstance.SwitchTo();
            }
            catch(Exception e) { }
        }

        public static void TurnToNextPage_Input(string page_Input)
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(DocChatElement.Next_Page_Input).Clear();
                PortalChromeDriver.SendKeysPerXpath(DocChatElement.Next_Page_Input, page_Input);
                PortalChromeDriver.ClickElementPerXpath(DocChatElement.pagejump_btn);
                System.Threading.Thread.Sleep(3 * 1000);
            }
            catch (Exception e)
            {

            }
        }

    }
}
