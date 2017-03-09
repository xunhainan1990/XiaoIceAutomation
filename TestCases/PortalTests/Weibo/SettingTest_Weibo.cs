using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases.PortalTests.Weibo
{
    //[TestClass]
    public class SettingTest_Weibo:PortalTestInit_Weibo
    {
        [TestCategory("Setting")]
        [TestCategory("Setting_Article_Level_Weibo")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查公众号文章推介级别设置默认显示平衡")]
        public void Setting_Article_Level_Weibo()
        {
            SettingTests.Setting_Article_Level();
        }

        [TestCategory("Setting")]
        [TestCategory("Setting_Chat_Style_Weibo")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Setting_Chat_Style_Weibo()
        {
            SettingTests.Setting_Chat_Style();
        }
    }
}
