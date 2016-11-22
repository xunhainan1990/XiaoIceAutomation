using Portal.UIElement;
using Common.Driver;
using System;

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


    }
}
