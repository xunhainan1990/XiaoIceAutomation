using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal;
using Portal.Pages;
using System.Threading;
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests
{
    [TestClass]
    public class MaterialTest : PortalTestInit
    {
        [TestInitialize]
        public void IntiMomentsSnapshot()
        {
            WeChatManagermentPage.GoTo_Material_Page();
        }

        [TestCategory("Material_BVT")]
        [TestCategory("Material_News")]
        [TestMethod]
        [TestProperty("description", "当有图文素材的时候，检查图文消息界面是否显示正确")]
        public void Material_News()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"素材管理\当有图文素材的时候，检查图文消息界面是否显示正确");

            Assert.IsTrue(PortalChromeDriver.GetElementsByClassName("cs_appmsg_delete_area").Count == 10, "每个素材下面有“删除”按钮");

            MaterialPage.TurnToNextPage();
            Assert.IsTrue(PortalChromeDriver.GetElementsByClassName("cs_appmsg_delete_area").Count == 2, "翻页后每个素材下面有“删除”按钮");

            MaterialPage.TurnToNextPage_Input("1");
            Assert.IsTrue(PortalChromeDriver.GetElementsByClassName("cs_appmsg_delete_area").Count == 10, "每个素材下面有“删除”按钮");

            MaterialPage.TurnToNextPage_Input("");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));

            MaterialPage.TurnToNextPage_Input("a");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));

            MaterialPage.TurnToNextPage_Input("一");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));


            MaterialPage.TurnToNextPage_Input("3");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不正确"));

            MaterialPage.TurnToNextPage_Input("0");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不正确"));

        }

        [TestCategory("Material_BVT")]
        [TestCategory("Material_Image")]
        [TestMethod]
        [TestProperty("description", "当有图片素材的时候，检查图片库界面是否显示正确")]
        public void Material_Image()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"素材管理\当有图片素材的时候，检查图片库界面是否显示正确");
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.ImageTab);
            Assert.IsTrue(PortalChromeDriver.GetElementsByClassName("cs_appmsg_delete_area").Count == 10, "每个素材下面有“删除”按钮");

            MaterialPage.TurnToNextPage();
            Assert.IsTrue(PortalChromeDriver.GetElementsByClassName("cs_appmsg_delete_area").Count == 10, "翻页后每个素材下面有“删除”按钮");

            PortalChromeDriver.ClickElementPerXpath(MaterialElement.NextPage_SecondPage);
            Assert.IsTrue(PortalChromeDriver.GetElementsByClassName("cs_appmsg_delete_area").Count == 3, "翻页后每个素材下面有“删除”按钮");

            MaterialPage.TurnToNextPage_Input("1");
            Assert.IsTrue(Utility.IsAt(MaterialElement.ImageLink, "u=115503548,1566568049&fm=23&gp=0.jpg"));

            MaterialPage.TurnToNextPage_Input("");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));

            MaterialPage.TurnToNextPage_Input("a");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));

            MaterialPage.TurnToNextPage_Input("一");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));


            MaterialPage.TurnToNextPage_Input("4");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不正确"));

            MaterialPage.TurnToNextPage_Input("0");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不正确"));
        }

        [TestCategory("Material_BVT")]
        [TestCategory("Material_News")]
        [TestMethod]
        [TestProperty("description", "当有图文素材的时候，检查图文消息界面是否显示正确")]
        public void Material_Audio()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"素材管理\当有图文素材的时候，检查图文消息界面是否显示正确");
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.AudioTab);
            Assert.IsTrue(PortalChromeDriver.GetElementsByClassName("cs_appmsg_delete_area").Count == 10, "每个素材下面有“删除”按钮");

            MaterialPage.TurnToNextPage();
            Assert.IsTrue(PortalChromeDriver.GetElementsByClassName("cs_appmsg_delete_area").Count == 1, "翻页后每个素材下面有“删除”按钮");

            MaterialPage.TurnToNextPage_Input("1");
            Assert.IsTrue(Utility.IsAt(MaterialElement.AudioLink, "香水有毒.amr"));

            MaterialPage.TurnToNextPage_Input("");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));

            MaterialPage.TurnToNextPage_Input("a");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));

            MaterialPage.TurnToNextPage_Input("一");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));


            MaterialPage.TurnToNextPage_Input("3");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不正确"));

            MaterialPage.TurnToNextPage_Input("0");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不正确"));
        }

        [TestCategory("Material_BVT")]
        [TestCategory("Material_Video")]
        [TestMethod]
        [TestProperty("description", "当有视频素材的时候，检查视频界面是否显示正确")]
        public void Material_Video()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"素材管理\当有视频素材的时候，检查视频界面是否显示正确");
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.Video);
            Assert.IsTrue(PortalChromeDriver.GetElementsByClassName("cs_appmsg_delete_area").Count == 10, "每个素材下面有“删除”按钮");

            MaterialPage.TurnToNextPage();
            Assert.IsTrue(PortalChromeDriver.GetElementsByClassName("cs_appmsg_delete_area").Count == 1, "翻页后每个素材下面有“删除”按钮");

            MaterialPage.TurnToNextPage_Input("1");
            Assert.IsTrue(Utility.IsAt(MaterialElement.VideoLink, "测试视频11"));

            MaterialPage.TurnToNextPage_Input("");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));

            MaterialPage.TurnToNextPage_Input("a");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));

            MaterialPage.TurnToNextPage_Input("一");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不是数字"));


            MaterialPage.TurnToNextPage_Input("3");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不正确"));

            MaterialPage.TurnToNextPage_Input("0");
            Assert.IsTrue(Utility.IsAt(MaterialElement.Page_Input_Warning, "输入页码不正确"));
        }

        [TestCategory("Material_BVT")]
        [TestCategory("Material_Video")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "”设置推荐” 功能是否可用")]
        public void Material_Article_Button()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"素材管理\”设置推荐” 功能是否可用");
            MaterialPage.Set_All();
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.Article_Button);
            //Assert.IsTrue(MaterialPage.IsFlaged() == 10, "”设置推荐” 功能是否可用");
            Assert.IsTrue(PortalChromeDriver.GetElementsByCssSelector("div.custom_checkbox.checked").Count == 11);
            Thread.Sleep(5 * 1000);
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.First_checked);
            Assert.IsFalse(MaterialPage.IsClickable(MaterialElement.FirstAward));
        }

        [TestCategory("Material_BVT")]
        [TestCategory("Material_Set_All")]
        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestProperty("description", "“设置推荐”中的全选框只能设置当前素材页的内容")]
        public void Material_Set_All()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"素材管理\“设置推荐”中的全选框只能设置当前素材页的内容");
            //重置
            MaterialPage.Set_All();
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.Article_Button);
            Thread.Sleep(2*1000);
            //取消全部选中
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.Set_All);
            Assert.IsFalse(MaterialPage.IsClickablePerCssSelector("custom_checkbox"));

            PortalChromeDriver.ClickElementPerXpath(MaterialElement.First_checked);
            Assert.IsTrue(Utility.IsAtPerCssSelector("div.custom_checkbox.checked"));
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.Save_Button);

            MaterialPage.TurnToNextPage_Input("2");
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.Article_Button);
            Assert.IsTrue(PortalChromeDriver.GetElementsByCssSelector("div.custom_checkbox.checked").Count == 2);
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.Save_Button);
        }

        [TestCategory("Material_BVT")]
        [TestCategory("Material_Set_All")]
        [TestCategory("BVT")]
        [TestCategory("Staging")]
        [TestMethod]
        [TestProperty("description", "选择多个图文推荐后没有保存，切换到其他页面，被选中的图文不会被保存")]
        public void Material_Select_NoSave()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"素材管理\选择多个图文推荐后没有保存，切换到其他页面，被选中的图文不会被保存");
            //重置
            MaterialPage.Set_All();
            MaterialPage.Set_All();
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.Article_Button);
            PortalChromeDriver.ClickElementPerXpath(MaterialElement.First_checked);

            MaterialPage.TurnToNextPage_Input("2");
            MaterialPage.TurnToNextPage_Input("1");
            Assert.IsFalse(MaterialPage.IsClickablePerCssSelector("custom_checkbox"));
        }
    }
}
