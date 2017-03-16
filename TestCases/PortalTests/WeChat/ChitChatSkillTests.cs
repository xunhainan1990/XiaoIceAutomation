using Common;
using CSH5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mobile;
using Portal;
using Portal.Pages;
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
    public class ChitChatSkillTests:PortalTestInit
    {
        [TestInitialize]
        public void IntiChitChatSkill()
        {
            WeChatManagermentPage.GoToCS_Skill_Page();
            ChitChatSkillPage.ClickChitChatSkill();
            Utility.TurnOn();
        }

        [TestCategory("ChitChatSkill_TurnOn")]
        [TestCategory("ChitChatSkill")]
        [TestMethod]
        [TestCategory("BVT")]
        public void ChitChatSkill_TurnOn()
        {
            Assert.IsTrue(Utility.IsTurnOn(), "聊天技能包正确开启");
        }

        [TestCategory("ChitChatSkill")]
        [TestCategory("ChitChatSkill_Divination")]
        [TestMethod]
        [TestCategory("BVT")]
        public void ChitChatSkill_Ice_Joke()
        {
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.GetToTestAccount();
            Mobile_WeChat_Utility.SendMessage("讲个笑话");
            Assert.IsTrue(Mobile_WeChat_Utility.GetLatestMessage(null));
        }

        [TestCategory("ChitChatSkill")]
        [TestCategory("ChitChatSkill_Divination")]
        [TestMethod]
        [TestCategory("BVT")]
        public void ChitChatSkill_Divination()
        {
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.GetToTestAccount();
            Mobile_WeChat_Utility.SendMessage("天蝎座运势");
            Assert.IsTrue(Mobile_WeChat_Utility.GetLatestMessage("今日幸运色"));

            Utility.TurnOff();
            Thread.Sleep(60*1000);
            Mobile_WeChat_Utility.SendMessage("天蝎座运势");
            Thread.Sleep(60 * 1000);
            Mobile_WeChat_Utility.SendMessage("天蝎座运势");
            Assert.IsTrue(!Mobile_WeChat_Utility.GetLatestMessage("今日幸运色"));
        }

        [TestCategory("ChitChatSkill")]
        [TestCategory("ChitChatSkill_Weather_Sun")]
        [TestMethod]
        [TestCategory("BVT")]
        public void ChitChatSkill_Weather_Sun()
        {
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.GetToTestAccount();
            Mobile_WeChat_Utility.SendMessage("北京天气");
            Assert.IsTrue(Mobile_WeChat_Utility.GetLatestMessage("℃"));

            Utility.TurnOff();
            Thread.Sleep(60 * 1000);
            Mobile_WeChat_Utility.SendMessage("北京天气");
            Thread.Sleep(60 * 1000);
            Mobile_WeChat_Utility.SendMessage("北京天气");
            Assert.IsTrue(!Mobile_WeChat_Utility.GetLatestMessage("℃"));
        }

        [TestCategory("ChitChatSkill")]
        [TestCategory("ChitChatSkill_Star_Arena")]
        [TestMethod]
        [TestCategory("BVT")]
        public void ChitChatSkill_Star_Arena()
        {
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.GetToTestAccount();
            Mobile_WeChat_Utility.SendMessage("韩寒和小四谁更火");
            Assert.IsTrue(Mobile_WeChat_Utility.GetLatestMessage("郭敬明"));

            Utility.TurnOff();
            Thread.Sleep(60 * 1000);
            Mobile_WeChat_Utility.SendMessage("韩寒和小四谁更火");
            Thread.Sleep(60 * 1000);
            Mobile_WeChat_Utility.SendMessage("韩寒和小四谁更火");
            Assert.IsTrue(!Mobile_WeChat_Utility.GetLatestMessage("郭敬明"));
        }

        [TestCategory("ChitChatSkill")]
        [TestCategory("ChitChatSkill_Bing")]
        [TestMethod]
        [TestCategory("BVT")]
        public void ChitChatSkill_Bing()
        {
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.GetToTestAccount();
            Mobile_WeChat_Utility.SendMessage("搜索周杰伦");
            Assert.IsTrue(Mobile_WeChat_Utility.GetLatestMessage("关于周杰伦"));

            Utility.TurnOff();
            Thread.Sleep(60 * 1000);
            Mobile_WeChat_Utility.SendMessage("搜索周杰伦");
            Thread.Sleep(60 * 1000);
            Mobile_WeChat_Utility.SendMessage("搜索周杰伦");
            Assert.IsTrue(!Mobile_WeChat_Utility.GetLatestMessage("关于周杰伦"));
        }

        [TestCategory("ChitChatSkill")]
        [TestCategory("ChitChatSkill_Usual_Translation")]
        [TestMethod]
        [TestCategory("BVT")]
        public void ChitChatSkill_BedTime_Story()
        {
            MobileAndroidDriver.AndroidInitialize();
            Mobile_WeChat_Utility.GetToTestAccount();
            Mobile_WeChat_Utility.SendMessage("讲个税前故事");
            Assert.IsTrue(Mobile_WeChat_Utility.GetLatestMessage(null));
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (MobileAndroidDriver.androidDriver != null)
                MobileAndroidDriver.androidDriver.Dispose();
        }
    }
}
