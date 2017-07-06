using Common;
using Mobile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal;
using Portal.Pages;
using System.Threading;
using Mobile;
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests.Weibo
{

    public class AutoReplyTest_Weibo: PortalTestInit_Weibo
    {
        [TestCategory("AutoReply_Weibo")]
        [TestCategory("AutoReply_ClearAll_TurnOff_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "老用户删除所有创建的规则后，停用并且启用关键词回复功能")]
        public void AutoReply_ClearAll_TurnOff_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\老用户删除所有创建的规则后，停用并且启用关键词回复功能");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();

            AutoReplyPage.TurnOffAutoReply();

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Mobile_Weibo_Utility.ClearAllMessage();
            Mobile_Weibo_Utility.SendMessage("A");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(!Mobile_WeChat_Utility.IsAtPerName("[啊_荀] 说:a"));
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "添加关键词回复")]
        public void AddText_AutoReply_BVT_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加关键词回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
            AutoReplyPage.AddAutoReply("A", "A", "第一个自动回复");
            PortalChromeDriver.TakeScreenShot(filePath, "添加关键词回复");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.RuleContent, "规则1：A"));

            AutoReplyPage.ClearReply();
            AutoReplyPage.AddAutoReply("", "A", "第一个自动回复");
            PortalChromeDriver.TakeScreenShot(filePath, "规则名为空");
            Assert.IsTrue(Utility.IsAt(CommonElement.notification), "规则名为空");
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("DeleteAutoReply_AutoReply_Weibo")]
        [TestMethod]
        [TestProperty("description", "删除自动回复")]
        public void DeleteAutoReply_AutoReply_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\删除自动回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
            AutoReplyPage.AddAutoReply("A", "Hi", "第一个自动回复");
            AutoReplyPage.DeleteReply();
            PortalChromeDriver.TakeScreenShot(filePath, "删除自动回复");
            Assert.IsFalse(Utility.IsAt(AutoReplyElement.RuleContent, "规则1：A"));

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Mobile_Weibo_Utility.ClearAllMessage();
            Mobile_Weibo_Utility.SendMessage("A");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(!Mobile_WeChat_Utility.IsAtPerName("[啊_荀] 说:Hi"));
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("DeleteTrigger_AutoReply_Weibo")]
        [TestMethod]
        [TestProperty("description", "删除Trigger")]
        public void DeleteTrigger_AutoReply_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\删除Trigger");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
            AutoReplyPage.AddAutoReply("A", "Hi", "第一个自动回复");
            AutoReplyPage.DeleteTrigger();
            PortalChromeDriver.TakeScreenShot(filePath, "删除Trigger");
            Assert.IsFalse(Utility.IsAt(AutoReplyElement.TrigerContent.Replace("[{0}]", "[" + 1 + "]"), 1 + ""));
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("DeleteReply_AutoReply_Weibo")]
        [TestMethod]
        [TestProperty("description", "删除reply")]
        public void DeleteReply_AutoReply_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\删除reply");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
            AutoReplyPage.AddAutoReply("A", "Hi", "第一个自动回复");
            AutoReplyPage.DeleteReplyInner();
            PortalChromeDriver.TakeScreenShot(filePath, "删除reply");
            Assert.IsFalse(Utility.IsAt(AutoReplyElement.ReplyContent.Replace("[{0}]", "[" + 1 + "]"), 1 + ""));
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("EditReply_AutoReply_Weibo")]
        [TestMethod]
        [TestProperty("description", "编辑关键词回复")]
        public void EditReply_AutoReply_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\编辑关键词回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
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

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Mobile_Weibo_Utility.ClearAllMessage();
            Mobile_Weibo_Utility.SendMessage("修改的Trigger");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerName("[啊_荀] 说:修改的Reply"));
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("AddReply_AddTrigger_Total_10_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "添加10个关键词")]
        public void AddReply_AddTrigger_Total_10_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加10个关键词");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
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

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("Rule_Add_Delete_Response_News_Weibo")]
        [TestMethod]
        [TestProperty("description", "添加1个图片素材")]
        public void Rule_Add_Delete_Response_News_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加1个图片素材");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddAutoReply);
            var regulationTextes = PortalChromeDriver.GetElementByClassName(AutoReplyElement.RegulationText);
            regulationTextes.Clear();
            regulationTextes.SendKeys("这是rule");
            AutoReplyPage.AddTrigger(1 + "", 1 + "");

            AutoReplyPage.AddReply_News(1);
            Thread.Sleep(3 * 1000);
            PortalChromeDriver.TakeScreenShot(filePath, "添加1个图片素材");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.PicValidator1, "g"));

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Mobile_Weibo_Utility.ClearAllMessage();
            Mobile_Weibo_Utility.SendMessage("1");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerName("g"));

            filePath = PortalChromeDriver.CreateFolder(@"自动回复\删除图文");
            AutoReplyPage.DeletePicReply(1);
            PortalChromeDriver.TakeScreenShot(filePath, "删除图文");
            Assert.IsFalse(Utility.IsAt(AutoReplyElement.PicValidator, "g"));
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("Rule_Add_Response_Emoj_Weibo")]
        [TestMethod]
        [TestProperty("description", "添加表情回复")]
        public void Rule_Add_Response_Emoj_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\添加表情回复");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.AddAutoReply);
            var regulationTextes = PortalChromeDriver.GetElementByClassName(AutoReplyElement.RegulationText);
            regulationTextes.Clear();
            regulationTextes.SendKeys("我是rule");
            AutoReplyPage.AddTrigger("我是trigger", 1 + "");
            AutoReplyPage.AddEmoj();
            PortalChromeDriver.TakeScreenShot(filePath, "添加表情回复");
            Assert.IsTrue(PortalChromeDriver.GetElementByXpath(AutoReplyElement.Emoj).GetAttribute("title") == "发红包啦");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Mobile_Weibo_Utility.ClearAllMessage();
            Mobile_Weibo_Utility.SendMessage("我是trigger");
            MobileAndroidDriver.GetScreenshot(filePath, "添加表情回复");
            Assert.IsTrue(Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("[啊_荀] 说:"));
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("TurnOff_AutoReply_Weibo")]
        [TestMethod]
        [TestProperty("description", "关键词自动回复Mobile可用；停用关键词回复Mobile无关键词回复")]
        public void TurnOff_AutoReply_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\关键词自动回复Mobile可用");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
            AutoReplyPage.AddAutoReply("A", "怎么办", "我是美女");


            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Mobile_Weibo_Utility.ClearAllMessage();
            Mobile_Weibo_Utility.SendMessage("怎么办");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(Mobile_WeChat_Utility.IsAtPerName("[啊_荀] 说:我是美女"));

            filePath = PortalChromeDriver.CreateFolder(@"自动回复\停用关键词回复Mobile无关键词回复");
            AutoReplyPage.TurnOffAutoReply();
            Mobile_WeChat_Utility.BackButtonClick();
            Mobile_Weibo_Utility.ClearAllMessage();
            Mobile_WeChat_Utility.SendMessage("怎么办");
            Thread.Sleep(2 * 1000);
            MobileAndroidDriver.GetScreenshot(filePath, "停用关键词回复Mobile无关键词回复");
            Assert.IsFalse(Mobile_WeChat_Utility.IsAtPerName("[啊_荀] 说:[我是美女]"));
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("Rule_Add_Response_href_script_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "回复为超链接和脚本")]
        public void Rule_Add_Response_href_script_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\回复为超链接和脚本");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
            AutoReplyPage.AddAutoReply("A", "怎么办", "<a href='http://bing.com'>必应</a>");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.ReplyContent.Replace("[{0}]", "[" + 1 + "]"), "http://bing.com"));
            AutoReplyPage.AddAutoReply("B", "这么办", "<script>alert(“123”);</script>");
            Assert.IsTrue(Utility.IsAt(AutoReplyElement.ReplyContent.Replace("[{0}]", "[" + 1 + "]"), "<script>alert(“123”);</script>"));

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Mobile_Weibo_Utility.ClearAllMessage();
            Mobile_Weibo_Utility.SendMessage("怎么办");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("必应"));
            Mobile_Weibo_Utility.SendMessage("这么办");
            PortalChromeDriver.TakeScreenShot(filePath, "关键词为脚本");
            Assert.IsTrue(Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("[啊_荀] 说:<script>alert(“123”);</script>"));
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("Rule_Trigger_SameWith_Material")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "如果设置关键词的内容跟素材的名称一致，优先回复关键词")]
        public void Rule_Trigger_SameWith_Material_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\如果设置关键词的内容跟素材的名称一致，优先回复关键词");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
            AutoReplyPage.AddAutoReply("A", "g", "我不是素材");
            PortalChromeDriver.TakeScreenShot(filePath, "Portal如果设置关键词的内容跟素材的名称一致，优先回复关键词");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Mobile_Weibo_Utility.ClearAllMessage();
            Mobile_Weibo_Utility.SendMessage("g");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("我不是素材")); ;
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("Rule_Fuzzy_Matching")]
        [TestMethod]
        [TestProperty("description", "模糊匹配")]
        public void Rule_Fuzzy_Matching_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\模糊匹配");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
            AutoReplyPage.AddAutoReply_Fuzzy_Matching("A", "abcdef", "我不是素材");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Mobile_Weibo_Utility.ClearAllMessage();
            Mobile_Weibo_Utility.SendMessage("abcdef123");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("我不是素材")); ;
        }

        [TestCategory("AutoReply_Weibo")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestCategory("ARule_Exact_Match")]
        [TestMethod]
        [TestProperty("description", "关键词精确匹配")]
        public void Rule_Exact_Match_Weibo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\关键词精确匹配");
            WeChatManagermentPage.GoTo_AutoReply_Page();
            PortalChromeDriver.ClickElementPerXpath(AutoReplyElement.KeyWordsReply);
            AutoReplyPage.TurnOnAutoReply();
            AutoReplyPage.ClearReply();
            AutoReplyPage.AddAutoReply("A", "谁是最漂亮的人", "我不是素材");
            PortalChromeDriver.TakeScreenShot(filePath, "关键词精确匹配");

            MobileAndroidDriver.AndroidInitialize_Weibo();
            Mobile_Weibo_Utility.Follow();
            Mobile_Weibo_Utility.ClearAllMessage();
            Mobile_Weibo_Utility.SendMessage("谁是最漂亮的人");
            MobileAndroidDriver.GetScreenshot(filePath, "H5关键词精确匹配");
            Assert.IsTrue(Mobile_Weibo_Utility.GetLatestMessage().Text.Contains("我不是素材")); ;
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
