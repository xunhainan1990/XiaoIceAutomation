using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal;
using Portal.Pages;
using System.Threading;
using XiaoIcePortal.UIElement;

namespace TestCases.PortalTests
{
    [TestClass]
    public class SettingTests : PortalTestInit
    {
        [TestInitialize]
        public void IntiMomentsSnapshot()
        {
            WeChatManagermentPage.GoTo_Setting_Page();
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "是否可以成功设置文章推荐级别为激进")]
        public void Setting_Article_Level()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查公众号文章推介级别设置默认显示平衡");
            //check default
            //Assert.IsTrue(Utility.IsAtPerClass(SettingElement.CheckedRadio, "平衡：觉得贴切才推荐"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.article_setting_Button);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.StrongRecommend);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ArticleSetSave);
            Thread.Sleep(1*1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.ArticleCheck, "激进（和话题沾边就推荐）"));
            Thread.Sleep(1*1000);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.article_setting_Button);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.MidRecommend);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ArticleSetSave);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.ArticleCheck, "平衡（觉得贴切才推荐）"));
            Thread.Sleep(1 * 1000);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.article_setting_Button);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.WeakRecommend);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ArticleSetSave);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.ArticleCheck, "婉约（仅在最恰当的时候才推荐）"));
            //set back
            PortalChromeDriver.ClickElementPerXpath(SettingElement.article_setting_Button);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.MidRecommend);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ArticleSetSave);
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查公众号文章推介级别设置默认显示平衡")]
        public void Setting_Article_Level_Cancle()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查公众号文章推介级别设置默认显示平衡");

            PortalChromeDriver.ClickElementPerXpath(SettingElement.article_setting_Button);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.StrongRecommend);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ArticleSetCancle);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.ArticleCheck, "平衡（觉得贴切才推荐）"));
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Setting_Chat_Style()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");

            PortalChromeDriver.ClickElementPerXpath(SettingElement.ChatStyle_Button);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.Strict);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ChatStyleSave);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.ChatStyleCheck, "严谨（聊天语言较为谨慎）"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.ChatStyle_Button);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.Active);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ChatStyleSave);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.ChatStyleCheck, "活泼（聊天语言较为轻松活泼）"));
           
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ChatStyle_Button);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.Streetwise);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ChatStyleSave);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.ChatStyleCheck, "调皮（聊天语言较为丰富且带有小冰个性）"));

            //set back
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ChatStyle_Button);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.Active);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ChatStyleSave);
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Setting_Chat_Style_Cancle()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");

            PortalChromeDriver.ClickElementPerXpath(SettingElement.ChatStyle_Button);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.Strict);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ChatStyCancle);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.ChatStyleCheck, "活泼（聊天语言较为轻松活泼）"));
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Add_AutoReply_Text()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));
            
            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddText);
            PortalChromeDriver.SendKeysPerXpath(SettingElement.TextInput,"北京欢迎你");
            PortalChromeDriver.ClickElementPerXpath(SettingElement.TextSave);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave); 
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.TextAddedCheck, "北京欢迎你"));

            //turn off if on
            if(Utility.IsAt(SettingElement.IsTurnOn, "已开启"))
            {
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOffConfirm);
            }
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Delete_Text()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddText);
            PortalChromeDriver.SendKeysPerXpath(SettingElement.TextInput, "北京欢迎你");
            PortalChromeDriver.ClickElementPerXpath(SettingElement.TextSave);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Thread.Sleep(1 * 1000);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.EditReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteTextReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteConfirm);
            Assert.IsTrue(Utility.IsAt(SettingElement.reply_empty_tips, "只能添加一条回复，请添加回复。"));

            //turn off if on
            if (Utility.IsAt(SettingElement.IsTurnOn, "已开启"))
            {
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOffConfirm);
            }
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Edit_Text()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddText);
            PortalChromeDriver.SendKeysPerXpath(SettingElement.TextInput, "北京欢迎你");
            PortalChromeDriver.ClickElementPerXpath(SettingElement.TextSave);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Thread.Sleep(1 * 1000);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.EditReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.EditText);
            PortalChromeDriver.SendKeysPerXpath(SettingElement.TextInput, "北京欢迎我");
            PortalChromeDriver.ClickElementPerXpath(SettingElement.TextSave);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Assert.IsTrue(Utility.IsAt(SettingElement.TextAddedCheck, "北京欢迎我"));

            //turn off if on
            if (Utility.IsAt(SettingElement.IsTurnOn, "已开启"))
            {
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOffConfirm);
            }
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Add_AutoReply_News()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddNews);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Select_first); 
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.NewsAddedCheck, "关于“东方万里行” 相关问题"));

            //turn off if on
            if (Utility.IsAt(SettingElement.IsTurnOn, "已开启"))
            {
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOffConfirm);
            }
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Delete_News()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddNews);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Select_first);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Thread.Sleep(1 * 1000);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.EditReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteNewsReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteConfirm);
            Assert.IsTrue(Utility.IsAt(SettingElement.reply_empty_tips, "只能添加一条回复，请添加回复。"));

            //turn off if on
            if (Utility.IsAt(SettingElement.IsTurnOn, "已开启"))
            {
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOffConfirm);
            }
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "更改图文素材, 检查是否能更改成功")]
        public void Edit_News()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddNews);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Select_first);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            Thread.Sleep(1 * 1000);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteNewsReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteConfirm);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddNews);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Select_second);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Assert.IsTrue(Utility.IsAt(SettingElement.News_Second_AddedCheck, "jdw"));

        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Add_AutoReply_Photo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddPhoto);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.Photo_Select_first);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.Photo_Added_Check, "u=115503548,1566568049&fm=23&gp=0.jpg"));

            //turn off if on
            if (Utility.IsAt(SettingElement.IsTurnOn, "已开启"))
            {
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOffConfirm);
            }
        }


        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Delete_Photo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddPhoto);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Select_first);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Thread.Sleep(1 * 1000);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.EditReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteNewsReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteConfirm);
            Assert.IsTrue(Utility.IsAt(SettingElement.reply_empty_tips, "只能添加一条回复，请添加回复。"));

            //turn off if on
            if (Utility.IsAt(SettingElement.IsTurnOn, "已开启"))
            {
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOffConfirm);
            }
        }


        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "更改图片素材, 检查是否能更改成功")]
        public void Edit_Photo()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddPhoto);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Select_first);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            Thread.Sleep(1 * 1000);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteNewsReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteConfirm);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddPhoto);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Select_second);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Assert.IsTrue(Utility.IsAt(SettingElement.Photo_Added_Check,"1114.png"));
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Add_AutoReply_Video()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddVideo);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.Video_Select_first);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.Video_Added_Check, "测试视频11"));

            //turn off if on
            if (Utility.IsAt(SettingElement.IsTurnOn, "已开启"))
            {
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOffConfirm);
            }
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Delete_Video()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddVideo);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Select_first);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Thread.Sleep(1 * 1000);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.EditReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteNewsReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteConfirm);
            Assert.IsTrue(Utility.IsAt(SettingElement.reply_empty_tips, "只能添加一条回复，请添加回复。"));

            //turn off if on
            if (Utility.IsAt(SettingElement.IsTurnOn, "已开启"))
            {
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOffConfirm);
            }
        }


        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "更改语音素材, 检查是否能更改成功")]
        public void Edit_Video()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddVideo);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Select_first);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            Thread.Sleep(1 * 1000);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteNewsReply);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.DeleteConfirm);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddVideo);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Select_second);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Assert.IsTrue(Utility.IsAt(SettingElement.Video_Added_Check, "测试视频10"));
        }

        [TestCategory("Setting_BVT")]
        [TestCategory("AddText_AutoReply")]
        [TestCategory("BVT")]
        [TestMethod]
        [TestProperty("description", "检查聊天风格设置默认显示保守")]
        public void Add_All()
        {
            string filePath = PortalChromeDriver.CreateFolder(@"自动回复\检查聊天风格设置默认显示保守");
            Assert.IsTrue(Utility.IsAt(SettingElement.IsTurnOn, "未开启"));

            PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddText);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddNews);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Select_first);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddPhoto);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.Photo_Select_first);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            Thread.Sleep(1*1000);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.replace_Confirm);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.AddVideo);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.Video_Select_first);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.News_Save);
            PortalChromeDriver.ClickElementPerXpath(SettingElement.replace_Confirm);

            PortalChromeDriver.ClickElementPerXpath(SettingElement.ReplySave);
            Thread.Sleep(1 * 1000);
            Assert.IsTrue(Utility.IsAt(SettingElement.Video_Added_Check, "测试视频11"));

            //turn off if on
            if (Utility.IsAt(SettingElement.IsTurnOn, "已开启"))
            {
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOffConfirm);
            }
        }

        [TestCleanup]
        public void AndroidCleanUp()
        {
            if (Utility.IsAt(SettingElement.IsTurnOn, "已开启"))
            {
                Thread.Sleep(1*1000);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOnAutoReplyButton);
                PortalChromeDriver.ClickElementPerXpath(SettingElement.TurnOffConfirm);
            }
        }
    }
}
