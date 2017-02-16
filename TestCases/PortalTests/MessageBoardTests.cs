using Common;
using Common.Driver;
using CSH5;
using CSH5.UIElement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIceH5;
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests
{

    //[TestClass]
    //public class MessageBoardTests : PortalTestInit
    //{
    //    [TestCategory("MessageBoard")]
    //    [TestCategory("Can_secretRelationship_TurnOn")]
    //    [TestMethod]
    //    [TestProperty("description", "是否可以正常开启“留言板”功能")]
    //    public void Can_MessageBoard_TurnOn()
    //    {
    //        string filePath = PortalChromeDriver.CreateFolder(@"关系识别\是否可以正常开启“留言板”功能");
    //        WeChatManagermentPage.GoToCS_Skill_Page();
    //        PortalChromeDriver.TakeScreenShot(filePath, @"1.检查'留言板'功能是否显示在技能插件的页面上");
    //        Assert.IsTrue(Utility.IsAt(MessageBoardElement.MessageBoard, "留言板"), "检查'留言板'功能是否显示在技能插件的页面上");
    //        MessageBoardPage.ClickMessageBoard();
    //        //Utility.TurnOff(secretRelationshipElement.TurnOff, secretRelationshipElement.TurnOffConfirm);
    //        Thread.Sleep(2 * 1000);
    //        Utility.TurnOn(MessageBoardElement.TurnOn);
    //        Thread.Sleep(2 * 1000);
    //        PortalChromeDriver.TakeScreenShot(filePath, @"是否可以正常开启'留言板'功能");
    //        Assert.IsTrue(Utility.IsAt(MessageBoardElement.IsTurnOff, "停用"), "是否可以正常开启留言板'功能");

    //        PortalChromeDriver.GetElementByXpath(MessageBoardElement.AllSkillLink).Click();
    //        Assert.IsTrue(Utility.IsAt(MessageBoardElement.IsOnAtAllSkill, "已开启"));
    //    }

    //    [TestCategory("MessageBoard")]
    //    [TestCategory("Can_secretRelationship_TurnOn")]
    //    [TestMethod]
    //    [TestProperty("description", "是否可以正常开启“留言板”功能")]
    //    public void Can_MessageBoard_Work()
    //    {
    //        string filePath = PortalChromeDriver.CreateFolder(@"关系识别\是否可以正常开启“留言板”功能");

    //        WeChatManagermentPage.GoToHIPage();
    //        HIPage.ClickSettings();
    //        HIPage.TurnOff();

    //        WeChatManagermentPage.GoToCS_Skill_Page_WithHiOff();
    //        MessageBoardPage.ClickMessageBoard();
    //        Thread.Sleep(2 * 1000);
    //        Utility.TurnOn(MessageBoardElement.TurnOn);
    //        Thread.Sleep(2 * 1000);

    //        WeChatManagermentPage.GoTo_Menu_Page_FaceRanking();
    //        MenuPage.DeleteMenuItem();
    //        MenuPage.AddMenu("留言反馈");
    //        MenuPage.AddMenu_Text("发送'@管理员+留言内容'的文本信息就可以给管理员留言啦");

    //        MobileAndroidDriver.AndroidInitialize();
    //        MobileH5.GetToTestAccount();
    //        FaceRankingH5Page.ClickFaceRanking();
    //        Assert.IsTrue(MobileH5.GetLatestMessageWithMenu().Text == "发送'@管理员+留言内容'的文本信息就可以给管理员留言啦");
    //        //MobileH5.SendMessage("@管理员，你好么");
    //        var sendButton = MobileAndroidDriver.GetElementByXpath(HIMobileH5Element.SendButtonXpath);
    //        sendButton.Click();
    //    }

    //    [TestCategory("MessageBoard")]
    //    [TestCategory("Can_secretRelationship_TurnOn")]
    //    [TestMethod]
    //    [TestProperty("description", "是否可以正常开启“留言板”功能")]
    //    public void Can_MessageBoard_TurnOff()
    //    {
    //        string filePath = PortalChromeDriver.CreateFolder(@"关系识别\是否可以正常开启“留言板”功能");
    //        WeChatManagermentPage.GoToCS_Skill_Page();
    //        MessageBoardPage.ClickMessageBoard();

    //        Thread.Sleep(2 * 1000);
    //        Utility.TurnOn(MessageBoardElement.TurnOn);
    //        Thread.Sleep(2 * 1000);

    //        Utility.TurnOff(MessageBoardElement.TurnOn, MessageBoardElement.Confirm);
    //        Assert.IsTrue(Utility.IsAt(MessageBoardElement.IsTurnOff, "停用"), "是否可以正常停用留言板'功能");

    //        MobileAndroidDriver.AndroidInitialize();
    //        MobileH5.GetToTestAccount();
    //        FaceRankingH5Page.ClickFaceRanking();
    //        Assert.IsTrue(MobileH5.GetLatestMessage().Text == "发送'@管理员+留言内容'的文本信息就可以给管理员留言啦");
    //        MobileH5.SendMessage("@管理员，你好么");
    //        //Mobile验证
    //    }

    //}
}
