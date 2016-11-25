using Common.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;
using Portal.UIElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoIcePortal.Pages;

namespace TestCases.PortalTests
{
    [TestClass]
    public class DocChatTests : PortalTestInit
    {
        [TestMethod]
        [TestCategory("DocChat")]
        [TestProperty("description", "1.检查'自主学习技能'功能是否显示在技能插件的页面上")]
        public void Is_Doc_Chat_Show()
        {
           
            WeChatManagermentPage.GoToCS_Skill_Page();           
            PortalChromeDriver.TakeScreenShot("1.检查'自主学习技能'功能是否显示在技能插件的页面上");
            Assert.IsTrue(Common.Utility.IsAt(DocChatElement.cs_skills_doc_chat));
        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestProperty("description", "3.检查选择图文消息页面是否显示正常（文章为空）；4.	是否可以正常开启‘自主学习技能'功能（图文库素材小于10篇的时候）")]
        public void Check_Doc_Chat_With_NotEnoughArticle()
        {
            WeChatManagermentPage.GoToCS_Skill_Page();
            DocChatPage.Click_Doc_Chat_Skill();
            DocChatPage.TurnOn_Docchat();
            PortalChromeDriver.TakeScreenShot("1.检查'自主学习技能'功能是否显示在技能插件的页面上");
            Assert.IsTrue(Common.Utility.IsAt(DocChatElement.NotTurnOn_Validator));
        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestProperty("description", "5.是否可以正常开启'自主学习技能'功能（图文库素材大于等于10篇的时候）")]
        public void Check_Doc_Chat_UI()
        {
            PortalChromeDriver.ChromeInitializeWithWechat();
            DocChatPage.AddMaterialFromWechat();

            WeChatManagermentPage.GoToCS_Skill_Page();
            DocChatPage.Click_Doc_Chat_Skill();
            DocChatPage.TurnOn_Docchat();
            PortalChromeDriver.TakeScreenShot("1.检查'自主学习技能'功能是否显示在技能插件的页面上");
            Assert.IsTrue(Common.Utility.IsAt(DocChatElement.TurnOn_validator));
        }

    }
}
