using Common;
using Common.Driver;
using CSH5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests
{
    [TestClass]
    public class AutoReplyTest : PortalTestInit
    {

        [TestInitialize]
        public void IntiMomentsSnapshot()
        {
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
        }
        [TestCategory("AutoReply_BVT")]
        [TestCategory("AutoReply_ClearAll_TurnOff")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "老用户删除所有创建的规则后，停用并且启用关键词回复功能")]
        public void AutoReply_ClearAll_TurnOff()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\老用户删除所有创建的规则后，停用并且启用关键词回复功能");
            AutoReplyPage.TurnOffAutoReply();

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.FollowWeChatOffcialAccount();
            //MobileH5.GetToTestAccount();
            MobileH5.SendMessageWithMenu("a");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(!MobileH5.GetLatestMessage("[平台测试账号2]说："));
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "添加关键词回复")]
        public static void AddText_AutoReply_BVT()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加关键词回复");
            AutoReplyPage.AddAutoReply("A", "A", "第一个自动回复");
            PortalChromeDriver.TakeScreenShot(filePath, "添加关键词回复");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.RuleContent, "规则1：A"));

            AutoReplyPage.ClearReply();
            AutoReplyPage.AddAutoReply("", "A", "第一个自动回复");
            PortalChromeDriver.TakeScreenShot(filePath, "规则名为空");
            Assert.IsTrue(Utility.IsAt(CommonElement.notification), "规则名为空");
        }

        [TestCategory("AutoReply")]
        [TestCategory("AddText_AutoReply")]
        [TestMethod]
        [TestProperty("description", "添加关键词回复")]
        public void AddText_AutoReply()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加关键词回复");

            AutoReplyPage.AddAutoReply("", "Hi", "第一个自动回复");
            Assert.IsTrue(Utility.IsAt(CommonElement.notification), "规则名不能为空");

            AutoReplyPage.AddAutoReply("A", "", "第一个自动回复");
            Assert.IsTrue(Utility.IsAt(CommonElement.notification), "关键词不能为空");

            AutoReplyPage.AddAutoReply("A", "Hi", "");
            Assert.IsTrue(Utility.IsAt(CommonElement.notification), "回复文本不能为空");

            AutoReplyPage.AddAutoReply("012345678901234567890123456789012345678901234567890", "0123456789012345678901234567890", "0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "字数限制");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.RuleContent, "01234567890123456789012345678901234567890123456789"));
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.TrigerContent.Replace("{0}", 1 + ""), "012345678901234567890123456789"));
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.ReplyContent.Replace("[{0}]", "[" + 1 + "]"), "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789"));
            AutoReplyPage.DeleteReply();
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("DeleteText_AutoReply")]
        [TestMethod]
        [TestProperty("description", "删除自动回复")]
        public void DeleteAutoReply_AutoReply()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\删除自动回复");

            AutoReplyPage.AddAutoReply("A", "Hi", "第一个自动回复");
            AutoReplyPage.DeleteReply();
            PortalChromeDriver.TakeScreenShot(filePath, "删除自动回复");
            Assert.IsFalse(Utility.IsAt(AutoReplyElement.RuleContent, "规则1：A"));

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.SendMessage("A");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(!MobileH5.GetLatestMessage("[平台测试账号2]说："));
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("DeleteText_AutoReply")]
        [TestMethod]
        [TestProperty("description", "删除Trigger")]
        public void DeleteTrigger_AutoReply()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\删除Trigger");
            AutoReplyPage.AddAutoReply("A", "Hi", "第一个自动回复");
            AutoReplyPage.DeleteTrigger();
            PortalChromeDriver.TakeScreenShot(filePath, "删除Trigger");
            Assert.IsFalse(Utility.IsAt(AutoReplyElement.TrigerContent.Replace("[{0}]", "[" + 1 + "]"), 1 + ""));
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("DeleteText_AutoReply")]
        [TestMethod]
        [TestProperty("description", "删除reply")]
        public void DeleteReply_AutoReply()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\删除reply");

            AutoReplyPage.AddAutoReply("A", "Hi", "第一个自动回复");
            AutoReplyPage.DeleteReplyInner();
            PortalChromeDriver.TakeScreenShot(filePath, "删除reply");
            Assert.IsFalse(Utility.IsAt(AutoReplyElement.ReplyContent.Replace("[{0}]", "[" + 1 + "]"), 1 + ""));
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("EditReply_AutoReply")]
        [TestMethod]
        [TestProperty("description", "编辑关键词回复")]
        public void EditReply_AutoReply()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\编辑关键词回复");
     
            AutoReplyPage.AddAutoReply("A", "Hi", "第一个自动回复");
            Thread.Sleep(2 * 1000);
            PortalChromeDriver.Refresh();
            AutoReplyPage.EditRule("修改的Rule");
            PortalChromeDriver.TakeScreenShot(filePath, "修改的Rule");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.RuleContent, "修改的Rule"));

            AutoReplyPage.EditTriger("修改的Trigger");
            PortalChromeDriver.TakeScreenShot(filePath, "修改的Trigger");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.TrigerContent.Replace("[{0}]", ""), "修改的Trigger"));

            AutoReplyPage.EditReply("修改的Reply");
            PortalChromeDriver.TakeScreenShot(filePath, "修改的Reply");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.ReplyContent.Replace("[{0}]", ""), "修改的Reply"));

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.SendMessage("修改的Trigger");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(!MobileH5.GetLatestMessage("修改的Reply"));
        }

        [TestCategory("AutoReply")]
        [TestCategory("DeleteText_AutoReply")]
        [TestMethod]
        [TestProperty("description", "添加200自动回复")]
        public void AddReply_Total_200()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加200自动回复");
         
            for (int i = 1; i <= 200; i++)
            {
                AutoReplyPage.AddAutoReply(i + "", "Hi", "第一个自动回复");
                Thread.Sleep(3 * 1000);
                Assert.IsTrue(Utility.IsAt(AutoReplyElement.RuleContent, "规则" + i));
            }
            PortalChromeDriver.TakeScreenShot(filePath, "添加200自动回复");
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("AddReply_AddTrigger_Total_10")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "添加10个关键词")]
        public void AddReply_AddTrigger_Total_10()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加10个关键词");
         
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddAutoReply);
            var regulationTextes = PortalChromeDriver.GetElementByClassName(AutoReplyElement.RegulationText);
            regulationTextes.Clear();
            regulationTextes.SendKeys("这是rule");
            for (int i = 1; i <= 10; i++)
            {
                AutoReplyPage.AddTrigger(i + "", i + "");
                Thread.Sleep(3 * 1000);
                PortalChromeDriver.ClickElementPerXpath("/html/body/div/div[2]/div[2]/div[2]/div/div[1]/div[1]/div[2]/span");
                Assert.IsTrue(Utility.IsAt(AutoReplyElement.TrigerContent.Replace("[{0}]", "[" + i + "]"), i + ""));
            }
            PortalChromeDriver.TakeScreenShot(filePath, "添加10个关键词");
            AutoReplyPage.AddTrigger(11 + "", 11 + "");
            Assert.IsFalse(Utility.IsAt(AutoReplyElement.TrigerContent.Replace("[{0}]", "[" + 11 + "]"), 11 + ""));
        }

        [TestCategory("AutoReply")]
        [TestCategory("AddReply_AddReply_Total_5_AllText")]
        [TestMethod]
        [TestProperty("description", "添加5个文字reply")]
        public void AddReply_AddReply_Total_5_AllText()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加5个文字reply");

            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddAutoReply);
            var regulationTextes = PortalChromeDriver.GetElementByClassName(AutoReplyElement.RegulationText);
            regulationTextes.Clear();
            regulationTextes.SendKeys("这是rule");
            AutoReplyPage.AddTrigger(1 + "", 1 + "");
            Assert.IsFalse(Utility.IsAt(AutoReplyElement.TrigerContent.Replace("[{0}]", "[" + 1 + "]"), 1 + ""));
            for (int i = 1; i <= 5; i++)
            {
                AutoReplyPage.AddReply_Text(i + "", i + "");
                Thread.Sleep(3 * 1000);
                PortalChromeDriver.ClickElementPerXpath("/html/body/div/div[2]/div[2]/div[2]/div/div[1]/div[1]/div[2]/span");
                Assert.IsTrue(Utility.IsAt(AutoReplyElement.ReplyContent.Replace("[{0}]", "[" + i + "]"), i + ""));
            }
            PortalChromeDriver.TakeScreenShot(filePath, "添加5个文字reply");
            AutoReplyPage.AddReply_Text(6 + "", 6 + "");
            Assert.IsFalse(Utility.IsAt(AutoReplyElement.ReplyContent.Replace("[{0}]", "[" + 6 + "]"), 6 + ""));
        }

        [TestCategory("AutoReply")]
        [TestCategory("DeleteText_AutoReply")]
        [TestMethod]
        [TestProperty("description", "添加2个问题关键词3个图文关键词")]
        public void AddReply_AddReply_Total_5_HalfText()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加2个问题关键词3个图文关键词");
           
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddAutoReply);
            var regulationTextes = PortalChromeDriver.GetElementByClassName(AutoReplyElement.RegulationText);
            regulationTextes.Clear();
            regulationTextes.SendKeys("这是rule");
            AutoReplyPage.AddTrigger(1 + "", 1 + "");

            for (int i = 1; i <= 2; i++)
            {
                AutoReplyPage.AddReply_Text(i + "", i + "");
                Thread.Sleep(3 * 1000);
                PortalChromeDriver.ClickElementPerXpath("/html/body/div/div[2]/div[2]/div[2]/div/div[1]/div[1]/div[2]/span");
                Assert.IsTrue(Utility.IsAt(AutoReplyElement.ReplyContent.Replace("[{0}]", "[" + i + "]"), i + ""));
            }

            AutoReplyPage.AddReply_News(3);
            PortalChromeDriver.TakeScreenShot(filePath, "添加2个问题关键词3个图文关键词");
            Thread.Sleep(3 * 1000);
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.PicValidator, "h"));
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("Rule_Add_Delete_Response_News")]
        [TestMethod]
        [TestProperty("description", "添加1个图片素材")]
        public void Rule_Add_Delete_Response_News()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加1个图片素材");
          
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddAutoReply);
            var regulationTextes = PortalChromeDriver.GetElementByClassName(AutoReplyElement.RegulationText);
            regulationTextes.Clear();
            regulationTextes.SendKeys("这是rule");
            AutoReplyPage.AddTrigger("abc" + "", 1 + "");

            AutoReplyPage.AddReply_News(1);
            Thread.Sleep(3 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "添加1个图片素材");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.PicValidator1, "关于“东方万里行” 相关问题"));

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.SendMessageWithMenu("abc");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(MobileH5.IsAtPerName("关于“东方万里行” 相关问题"));

            filePath = PortalChromeDriver.CreateFolder(@"自动回复\删除图文");
            AutoReplyPage.DeletePicReply(1);
            PortalChromeDriver.TakeScreenShot(filePath, "删除图文");
            Assert.IsFalse(Utility.IsAt(AutoReplyElement.PicValidator, "关于“东方万里行” 相关问题"));
        }

        [TestCategory("AutoReply")]
        [TestCategory("Rule_Add_Delete_Response_AllNews")]
        [TestMethod]
        [TestProperty("description", "添加5个图片素材")]
        public void Rule_Add_Delete_Response_AllNews()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加5个图片素材");
         
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddAutoReply);
            var regulationTextes = PortalChromeDriver.GetElementByClassName(AutoReplyElement.RegulationText);
            regulationTextes.Clear();
            regulationTextes.SendKeys("这是rule");
            AutoReplyPage.AddTrigger(1 + "", 1 + "");

            AutoReplyPage.AddReply_News(5);
            Thread.Sleep(3 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "添加5个图片素材");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.PicValidator, "i"));
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("Rule_Add_Response_Emoj")]
        [TestMethod]
        [TestProperty("description", "添加表情回复")]
        public void Rule_Add_Response_Emoj()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加表情回复");
           
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddAutoReply);
            var regulationTextes = PortalChromeDriver.GetElementByClassName(AutoReplyElement.RegulationText);
            regulationTextes.Clear();
            regulationTextes.SendKeys("我是rule");
            AutoReplyPage.AddTrigger("trigger", 1 + "");
            AutoReplyPage.AddEmoj();
            PortalChromeDriver.TakeScreenShot(filePath, "添加表情回复");
            Assert.IsTrue(PortalChromeDriver.GetElementByXpath(AutoReplyElement.Emoj).GetAttribute("title") == "微笑");

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.SendMessageWithMenu("trigger");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(MobileH5.GetLatestMessage("[平台测试账号2] 说:"));
        }

        [TestCategory("AutoReply")]
        [TestCategory("AddAutoReply_IllegalTrigger")]
        [TestMethod]
        [TestProperty("description", "不能添加包含敏感词汇的关键词")]
        public void AddAutoReply_IllegalTrigger()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\不能添加包含敏感词汇的关键词");
           
            AutoReplyPage.AddAutoReply("A", "法轮功", "第一个自动回复");
            PortalChromeDriver.TakeScreenShot(filePath, "不能添加包含敏感词汇的关键词");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.Alert_Failure, "抱歉，您的回复中包含了不当内容，请修改后重新保存。"));
            AutoReplyPage.Alert_Failure_OK();
        }

        [TestCategory("AutoReply")]
        [TestCategory("AddAutoReply_IllegalReply")]
        [TestMethod]
        [TestProperty("description", "不能添加包含敏感词汇的回复")]
        public void AddAutoReply_IllegalReply()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\不能添加包含敏感词汇的回复");
          
            AutoReplyPage.AddAutoReply("A", "Hi", "法轮功");
            PortalChromeDriver.TakeScreenShot(filePath, "不能添加包含敏感词汇的回复");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.Alert_Failure, "抱歉，您的回复中包含了不当内容，请修改后重新保存。"));
            AutoReplyPage.Alert_Failure_OK();
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("TurnOff_AutoReply")]
        [TestMethod]
        [TestProperty("description", "关键词自动回复Mobile可用；停用关键词回复Mobile无关键词回复")]
        public void TurnOff_AutoReply()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\关键词自动回复Mobile可用");
           
            AutoReplyPage.AddAutoReply("A", "A", "我是美女");

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.SendMessageWithMenu("A");
            Thread.Sleep(2 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "关键词自动回复Mobile可用");
            Assert.IsTrue(MobileH5.GetLatestMessage("我是美女"));

            filePath = PortalChromeDriver.CreateFolder(@"自动回复\停用关键词回复Mobile无关键词回复");
            AutoReplyPage.TurnOffAutoReply();
            MobileH5.SendMessageWithMenu("A");
            Thread.Sleep(2 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "停用关键词回复Mobile无关键词回复");
            Assert.IsFalse(MobileH5.GetLatestMessage("我是美女"));
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("Rule_Add_Response_href_script")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "回复为超链接和脚本")]
        public void Rule_Add_Response_href_script()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\回复为超链接和脚本");

            AutoReplyPage.AddAutoReply("A", "A", "<a href='http://bing.com'>必应</a>");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.ReplyContent.Replace("[{0}]", "[" + 1 + "]"), "http://bing.com"));
            AutoReplyPage.AddAutoReply("B", "B", "<script>alert(“123”);</script>");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.ReplyContent.Replace("[{0}]", "[" + 1 + "]"), "<script>alert(“123”);</script>"));

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.SendMessageWithMenu("A");
            PortalChromeDriver.TakeScreenShot(filePath, "关键词为超链接");
            Assert.IsTrue(MobileH5.GetLatestMessage("必应"));
            MobileH5.SendMessage("B");
            PortalChromeDriver.TakeScreenShot(filePath, "关键词为脚本");
            Assert.IsTrue(MobileH5.GetLatestMessage("<script>alert(“123”);</script>"));
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("Rule_Trigger_SameWith_Material")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "如果设置关键词的内容跟素材的名称一致，优先回复关键词")]
        public void Rule_Trigger_SameWith_Material()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\如果设置关键词的内容跟素材的名称一致，优先回复关键词");
          
            AutoReplyPage.AddAutoReply("A", "jdw", "我不是素材");
            PortalChromeDriver.TakeScreenShot(filePath, "Portal如果设置关键词的内容跟素材的名称一致，优先回复关键词");

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.SendMessageWithMenu("jdw");
            Thread.Sleep(1*1000);
            MobileAndroidDriver.GetScreenshot(filePath, "H5如果设置关键词的内容跟素材的名称一致，优先回复关键词");
            Assert.IsTrue(MobileH5.GetLatestMessage("我不是素材"));
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("Rule_Fuzzy_Matching")]
        [TestMethod]
        [TestProperty("description", "模糊匹配")]
        public void Rule_Fuzzy_Matching()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\模糊匹配");
          
            AutoReplyPage.AddAutoReply_Fuzzy_Matching("A", "abcdef", "我不是素材");

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.SendMessageWithMenu("abcdef123");
            Thread.Sleep(2 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "模糊匹配");
            Assert.IsTrue(MobileH5.GetLatestMessage("我不是素材"));
        }

        [TestCategory("AutoReply_BVT")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("ARule_Exact_Match")]
        [TestMethod]
        [TestProperty("description", "关键词精确匹配")]
        public void Rule_Exact_Match()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\关键词精确匹配");
           
            AutoReplyPage.AddAutoReply("A", "A", "我不是素材");
            PortalChromeDriver.TakeScreenShot(filePath, "关键词精确匹配");

            MobileAndroidDriver.AndroidInitialize();
            MobileH5.GetToTestAccount();
            MobileH5.SendMessageWithMenu("A");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(MobileH5.GetLatestMessage("我不是素材"));
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
