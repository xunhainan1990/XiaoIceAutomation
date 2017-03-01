using Common;
using Common.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;
using Portal.UIElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.Pages;

namespace TestCases.PortalTests
{
    [TestClass]
    public class DocChatTests : PortalTestInit
    {
        [TestInitialize]
        public void IntiDoc_Chat()
        {
            WeChatManagermentPage.GoToCS_Skill_Page();
            DocChatPage.Click_Doc_Chat_Skill();
            Utility.TurnOn();
        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "5.是否可以正常开启'自主学习技能'功能（图文库素材大于等于10篇的时候）")]
        public void Doc_Chat_TurnOn()
        {
            //默认有>=10条素材
            PortalChromeDriver.TakeScreenShot("1.检查'自主学习技能'功能是否显示在技能插件的页面上");
            Assert.IsTrue(Utility.IsAt(DocChatElement.TurnOn_validator));
        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "6.在技能设置页面，检查全选按钮是否可用")]
        public void AllSelect()
        {
            //默认有>=10条素材
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.checkBoxDocChatAll);
            Assert.IsTrue(Utility.IsAt(DocChatElement.CurrentSelectNum, "10"));
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.checkBoxDocChatAll);
            Assert.IsTrue(Utility.IsAt(DocChatElement.CurrentSelectNum, "0"));

            PortalChromeDriver.ClickElementPerXpath(DocChatElement.checkBoxDocChatAll);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            Assert.IsTrue(Utility.IsAt(DocChatElement.CurrentSelectNum, "9"));
            PortalChromeDriver.TakeScreenShot("在技能设置页面，检查全选按钮是否可用");

        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "在技能设置页面，检查是否支持跨页选择")]
        public void Select_AcrossPages()
        {
            //默认有>=10条素材
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.checkBoxDocChatAll);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.checkBoxDocChatAll);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.Page_Next);
            Thread.Sleep(2*1000);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            Assert.IsTrue(Utility.IsAt(DocChatElement.CurrentSelectNum, "2"));
        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "在技能设置页面，检查更新时间按钮是否可用")]
        public void Sort()
        {
            //默认有>=10条素材
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.checkBoxDocChatAll);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.checkBoxDocChatAll);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.Sort);
            Thread.Sleep(2*1000);
            Assert.IsTrue(Utility.IsAt(DocChatElement.FirstArticle, "a"));
            Assert.IsTrue(Utility.IsAt(DocChatElement.CurrentSelectNum, "0"));
        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "检查技能设置页面是否显示翻页和跳转按钮，当文章数大于10篇")]
        public void TurnTo_NextPage()
        {
            //默认有>=10条素材
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.Page_Next);
            Thread.Sleep(2*1000);
            Assert.IsTrue(Utility.IsAt(DocChatElement.FirstArticle, "b"));
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.Page_Before);
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(DocChatElement.FirstArticle, "关于“东方万里行” 相关问题"));
        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "检查技能设置页面是否显示翻页和跳转按钮，当文章数大于10篇")]
        public void TurnTo_NextPage_Input()
        {
            //默认有>=10条素材

            DocChatPage.TurnToNextPage_Input("2");
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(DocChatElement.FirstArticle, "b"));
            Thread.Sleep(2 * 1000);
            DocChatPage.TurnToNextPage_Input("1");
            Assert.IsTrue(Utility.IsAt(DocChatElement.FirstArticle, "关于“东方万里行” 相关问题"));

            //DocChatPage.TurnToNextPage_Input("");
            //Assert.IsTrue(Utility.IsAt(DocChatElement.FirstArticle, "a"), "输入空格");

            //DocChatPage.TurnToNextPage_Input("sd");
            //Assert.IsTrue(Utility.IsAt(DocChatElement.FirstArticle, "a"), "输入字母");

            //DocChatPage.TurnToNextPage_Input("一");
            //Assert.IsTrue(Utility.IsAt(DocChatElement.FirstArticle, "a"), "输入汉字");
        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "是否可以设置一篇或几篇未学习的文章为已学习状态")]
        public void Study()
        {
            //默认有>=10条素材

            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.NotStudy);
            Thread.Sleep(2*1000);
            Assert.IsTrue(Utility.IsAt(DocChatElement.First_StudyStatus.Replace("{0}", 1 + ""), "未学习"));

            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.HasStudy);
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(DocChatElement.First_StudyStatus.Replace("{0}", 1 + ""), "已学习"));
        }


        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "已学习的文章是否可以重复学习")]
        public void ReStudy()
        {
            //默认有>=10条素材

            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.HasStudy);
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(DocChatElement.First_StudyStatus.Replace("{0}", 1 + ""), "已学习"));
            //Assert.IsTrue(Utility.IsAt(DocChatElement.notification, "文章状态编辑成功，将于4小时之内生效！"));
        }


        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "是否可以设置一篇或几篇已学习的文章为未学习状态")]
        public void NotStudy()
        {
            //默认有>=10条素材

            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.NotStudy);
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(DocChatElement.First_StudyStatus.Replace("{0}", 1 + ""), "未学习"));
        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "是否设置为已学习，当同时选择已学习和未学习的文章后，点击“开始学习”")]
        public void Set_HasStudy_TwoArticle()
        {
            //默认有>=10条素材

            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.NotStudy);
            Thread.Sleep(1 * 1000);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.SecondCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.HasStudy);
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(DocChatElement.First_StudyStatus.Replace("{0}", 1 + ""), "已学习"));
            Assert.IsTrue(Utility.IsAt(DocChatElement.Second_StudyStatus.Replace("{0}", 2 + ""), "已学习"));

        }


        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "是否设置为未学习，当同时选择已学习和未学习的文章后，点击“取消学习”（PS:已学习的文章不能小于10篇）")]
        public void Set_NotStudy_TwoArticle()
        {
            //默认有>=10条素材

            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.NotStudy);
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.FirstCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.SecondCheck);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.NotStudy);
            Thread.Sleep(2 * 1000);
            Assert.IsTrue(Utility.IsAt(DocChatElement.First_StudyStatus.Replace("{0}", 1 + ""), "未学习"));
            Assert.IsTrue(Utility.IsAt(DocChatElement.Second_StudyStatus.Replace("{0}", 2 + ""), "未学习"));

        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "检查是否设置为已学习，选择当前页所有文章后，点击“开始学习”")]
        public void Set_All_HasStudy()
        {
            //默认有>=10条素材
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.checkBoxDocChatAll);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.HasStudy);
            Thread.Sleep(2 * 1000);

            for (int i = 1; i < 11; i++)
            {
                Assert.IsTrue(Utility.IsAt(DocChatElement.First_StudyStatus.Replace("{0}", i + ""), "已学习"));
            }

        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "检查是否设置为未学习，选择当前页所有文章后，点击“取消学习”")]
        public void Set_All_NotStudy()
        {
            //默认有>=10条素材
            Thread.Sleep(1 * 1000);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.checkBoxDocChatAll);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.NotStudy);
            Assert.IsTrue(Utility.IsAt(DocChatElement.Confirm, "为保证使用效果，请至少保证已学习10篇以上的图文素材"));
        }

        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "检查是否设置为已学习，选择所有页的所有文章后，点击“开始学习”")]
        public void Set_AllPage_HasStudy()
        {
            //默认有>=10条素材
            Thread.Sleep(1 * 1000);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.checkBoxDocChatAll);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.SelectAllPages);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.HasStudy);
            Thread.Sleep(2 * 1000);
            for (int i = 1; i < 11; i++)
            {
                Assert.IsTrue(Utility.IsAt(DocChatElement.First_StudyStatus.Replace("{0}", i + ""), "已学习"), i + "应显示为已学习");
            }
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.Page_Next);
            Thread.Sleep(2 * 1000);
            for (int i = 1; i < 3; i++)
            {
                Assert.IsTrue(Utility.IsAt(DocChatElement.First_StudyStatus.Replace("{0}", i + ""), "已学习"), i + "应显示为已学习");
            }
        }


        [TestMethod]
        [TestCategory("DocChat")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "检查是否设置为未学习，选择所有页面的所有文章后，点击“取消学习”")]
        public void Set_AllPage_NotStudy()
        {
            //默认有>=10条素材
            Thread.Sleep(1 * 1000);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.checkBoxDocChatAll);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.SelectAllPages);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.docChatArrow);
            PortalChromeDriver.ClickElementPerXpath(DocChatElement.NotStudy);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(DocChatElement.Confirm, "为保证使用效果，请至少保证已学习10篇以上的图文素材"));

        }

    }
}
