using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoIcePortal.UIElement
{
    public class AutoReplyElement
    {
        public static string TurnOnAutoReply = "/html/body/div/div[2]/div[2]/div[2]/div/div[1]/div[2]/a";
        public static string OkButton = "//*[@id='confirmbox_wrapper']/div/div[3]/a[1]";
        public static string KeyWordsReply = "/html/body/div/div[2]/div[2]/div[2]/div/div[1]/div[1]/div[2]/a";
        public static string AddAutoReply = "//*[@id='addreply']";
        public static string RegulationTextParent ="//*[@id='keywordsreplies']/div/div[2]/div/div[2]/div";
        public static string RegulationText = "text";
        public static string EditRule= "//*[@id='keywordsreplies']/div/div[2]/div/div[2]/div/div[2]";
        public static string AddTrigger = "//*[@id='keywordsreplies']/div/div[3]/div/div/a";
        public static string AddTriggerParent = "//*[@id='keywordsreplies']/div/div[3]/div/ul/li[{0}]/div[2]/div[2]/div/div[1]";
        public static string AddTriggerInput = "text";
        public static string AddReplyText = "//*[@id='keywordsreplies']/div/div[4]/div/div[1]/div[2]";
        public static string ReplyInput = "//*[@id='keywordsreplies']/div/div[4]/div/ul/li[{0}]/div[2]/div[2]/div/div[1]/div[1]/div[2]";
        //*[@id="keywordsreplies"]/div/div[4]/div/div[1]/div[2]
        //*[@id="keywordsreplies"]/div/div[4]/div/ul/li/div[2]/div[2]/div/div[2]/div[1]
        public static string SaveButton = "//*[@id='keywordsreplies']/div/div[4]/div/div[2]/a";
        public static string DeleteButton = "entity_delete";
        public static string DeleteButtonXpath = "//*[@id='keywordsreplies']/div/div[1]/a[2]";
        public static string ok_btn = "//*[@id='confirmbox_wrapper']/div/div[3]/a[1]";
        public static string RuleContent = "//*[@id='keywordsreplies']/div/div[1]/div";
        public static string TrigerContent = "//*[@id='keywordsreplies']/div/div[3]/div/ul/li[{0}]/div[2]/div[2]/div/div[2]";
        public static string ReplyContent= "//*[@id='keywordsreplies']/div/div[4]/div/ul/li[{0}]/div[2]/div[2]/div/div[2]/div[2]";
        public static string EditReply = "//*[@id='keywordsreplies']/div/div[4]/div/ul/li[{0}]/div[2]/div[2]/div/div[1]/div[1]/div[2]";
        public static string EditTrigger = "//*[@id='keywordsreplies']/div/div[3]/div/ul/li/div[2]/div[2]/div/div[2]";
        public static string DeleteTrigger = "//*[@id='keywordsreplies']/div/div[3]/div/ul/li/div[2]/div[1]/a[3]";
        public static string entity_expand  ="//*[@id='keywordsreplies']/div/div[1]/a[1]";
        public static string EditReplyTrigger= "//*[@id='keywordsreplies']/div/div[4]/div/ul/li/div[2]/div[1]/a[1]";
        public static string DeleteReply ="//*[@id='keywordsreplies']/div/div[4]/div/ul/li/div[2]/div[1]/a[2]";
        public static string AddEmoj = "//*[@id='keywordsreplies']/div/div[4]/div/ul/li/div[2]/div[2]/div/div[1]/div[2]/a";
        public static string SmileFace= "//*[@id='keywordsreplies']/div/div[4]/div/ul/li/div[2]/div[2]/div/div[1]/div[2]/div/ul/li[1]/span/img";
        public static string Emoj= "//*[@id='keywordsreplies']/div/div[4]/div/ul/li/div[2]/div[2]/div/div[2]/div[2]/img";
        public static string ReplyPic = "//*[@id='keywordsreplies']/div/div[4]/div/div[1]/div[3]";
        public static string PicLink= "//*[@id='choosetbox_wrapper']/div/div[2]/div[{1}]/div[{0}]/div[1]/div[2]/img";
        public static string PicConfirm ="//*[@id='choosetbox_wrapper']/div/div[5]/a[1]";
        public static string PicValidator = "//*[@id='keywordsreplies']/div/div[4]/div/ul/li[5]/div[2]/div[2]/div/div[1]/h4/a";
       public static string PicValidator1="//*[@id='keywordsreplies']/div/div[4]/div/ul/li/div[2]/div[2]/div/div[1]/h4/a";
        public static string DeletePicReply = "//*[@id='keywordsreplies']/div/div[4]/div/ul/li[{0}]/div[2]/div[1]/a";
        public static string Alert_Failure = "//*[@id='alertbox_wrapper']/div/div[2]/span[2]";
        public static string OK_btn= "//*[@id='alertbox_wrapper']/div/div[3]/a";
        public static string Fuzzy_Matching="//*[@id='keywordsreplies']/div/div[3]/div/ul/li/div[2]/div[1]/a[1]";
    }
} 