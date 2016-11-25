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
        public static string OkButton= "//*[@id='confirmbox_wrapper']/div/div[3]/a[1]";
        public static string KeyWordsReply = "/html/body/div/div[2]/div[2]/div[2]/div/div[1]/div[1]/div[2]/a";
        public static string AddAutoReply= "//*[@id='addreply']";
        public static string RegulationText = "text";
        public static string AddTrigger = "//*[@id='keywordsreplies']/div/div[3]/div/div/a";
        public static string AddTriggerParent = "//*[@id='keywordsreplies']/div/div[3]/div/ul/li/div[2]/div[2]/div/div[1]";
        public static string AddTriggerInput= "text";
        public static string AddReplyText = "//*[@id='keywordsreplies']/div/div[4]/div/div[1]/div[2]";
        public static string ReplyInput= "//*[@id='keywordsreplies']/div/div[4]/div/ul/li/div[2]/div[2]/div/div[1]/div[1]/div[2]";
        public static string SaveButton= "//*[@id='keywordsreplies']/div/div[4]/div/div[2]/a";
        public static string DeleteButton= "entity_delete";
        public static string DeleteButtonXpath= "//*[@id='keywordsreplies']/div/div[1]/a[2]";
        public static string ok_btn= "//*[@id='confirmbox_wrapper']/div/div[3]/a[1]";
    }
}
