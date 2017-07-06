using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal;
using Portal.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests.Weibo
{
    [TestClass]
    public class SettingTest_Weibo:PortalTestInit_Weibo
    {
        [TestInitialize]
        public void IntiMomentsSnapshot()
        {
            WeChatManagermentPage.GoTo_Setting_Page();
        }

        //[TestCategory("Setting")]
        //[TestCategory("Setting_Article_Level_Weibo")]
        //[TestCategory("BVT")]
        //[TestMethod]
        //[TestProperty("description", "检查公众号文章推介级别设置默认显示平衡")]
        //public void Setting_Article_Level_Weibo()
        //{
        //    string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查公众号文章推介级别设置默认显示平衡");

        //    Assert.IsTrue(Utility.IsAtPerClass(SettingElement.CheckedRadio, "平衡：觉得贴切才推荐"));

        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.RadioCheck_2);
        //    Thread.Sleep(2 * 1000);
        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.Confirm);
        //    Thread.Sleep(2 * 1000);
        //    Assert.IsTrue(Utility.IsAtPerClass(SettingElement.CheckedRadio, "激进：和话题沾边儿就推荐"));

        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.RadioCheck_0);
        //    Thread.Sleep(2 * 1000);
        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.Confirm);
        //    Thread.Sleep(2 * 1000);
        //    Assert.IsTrue(Utility.IsAtPerClass(SettingElement.CheckedRadio, "婉约：仅在最恰当的时候才推荐"));

        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.RadioCheck_1);
        //    Thread.Sleep(2 * 1000);
        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.Confirm);
        //}

        //[TestCategory("Setting")]
        //[TestCategory("Setting_Chat_Style_Weibo")]
        //[TestCategory("BVT")]
        //[TestMethod]
        //[TestProperty("description", "检查聊天风格设置默认显示保守")]
        //public void Setting_Chat_Style_Weibo()
        //{
        //    string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
        //    Assert.IsTrue(PortalChromeDriver.GetElementByXpathByClassName(SettingElement.Chat_Style_Div, SettingElement.CheckedRadio).Text.Contains("严谨：聊天语言较为谨慎"));
        //    //Assert.IsTrue(Utility.IsAt(SettingElement.Chat_Style_Conservative, "保守：聊天语言较为谨慎（系统默认）"));

        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.Chat_Style_Lively);
        //    Thread.Sleep(2 * 1000);
        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.Confirm);
        //    Thread.Sleep(2 * 1000);
        //    //Assert.IsTrue(Utility.IsAt(SettingElement.Chat_Style_Lively, "活泼：聊天语言较为轻松"));
        //    Assert.IsTrue(PortalChromeDriver.GetElementByXpathByClassName(SettingElement.Chat_Style_Div, SettingElement.CheckedRadio).Text.Contains("活泼：聊天语言较为轻松活泼"));

        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.Chat_Style_naughty);
        //    Thread.Sleep(2 * 1000);
        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.Confirm);
        //    Thread.Sleep(2 * 1000);
        //    Assert.IsTrue(PortalChromeDriver.GetElementByXpathByClassName(SettingElement.Chat_Style_Div, SettingElement.CheckedRadio).Text.Contains("调皮：聊天语言较为丰富且带有小冰个性"));


        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.Chat_Style_Lively);
        //    Thread.Sleep(2 * 1000);
        //    PortalChromeDriver.ClickElementPerXpath(SettingElement.Confirm);
        //}
    }
}
