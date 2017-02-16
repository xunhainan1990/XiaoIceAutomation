using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSH5.UIElement
{
    public class HIMobileH5Element
    {
        public static string TextInput = "//android.widget.ImageView[contains(@content-desc,'消息')]";
        public static string KeyBoardSwichXpath = "//android.widget.ImageButton[contains(@content-desc,'切换到键盘')]";
        public static string EditTextXpath = "//android.widget.EditText[contains(@resource-id,'com.tencent.mm:id/a2v')]";
        public static string SendButtonXpath = "发送";
        public static string HiCardXpath = "接入人工客服";
        public static string xb_inputboxXpath = "//android.widget.EditText[contains(@resource-id,'xb_inputbox')]";
        public static string xb_add_btnXpath = "//android.widget.Button[contains(@resource-id,'xb_add_btn')]";
        public static string xb_chatwith_text = "//android.view.View[contains(@resource-id,'xb_chatwith_text')]";
        public static string xb_chatwith_texttest = "//android.view.View[contains(@content-desc,'平台测试账号2')]";
        public static string xb_addimg_image= "//android.widget.Image[contains(@resource-id,'xb_addimg_image')]";
        public static string TakePhoto= "//android.widget.ImageView[contains(@resource-id,'com.android.camera:id/v6_shutter_button_internal')]";
        public static string backFromHI = "返回";
        public static string HIMessageFromCustom = "点击卡片，进行回复";
        public static string chatwith_Meg = "聊天信息";
        public static string moreInfo = "//android.widget.TextView[contains(@content-desc,'更多')]"; 
        public static string ClearAll = "//android.widget.LinearLayout[@index='1']";
        public static string ClearAllConfirm = "清空内容";
        public static string MsgTexts= "//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/ho')]";
        public static string xb_page_body = "//android.view.View[contains(@resource-id,'xb_page_body')]";
        public static string SendImageConfirm = "//android.widget.ImageView[contains(@resource-id,'com.android.camera:id/v6_btn_done')]";
        public static string ReplyCardFromHI = "客服人员已回复您的问题";
        public static string imageMessage= "//android.webkit.WebView[contains(@content-desc,'人工客服窗口')]/android.view.View[@index='1']";
        public static string HIOffError = "//android.view.View[contains(@content-desc,'抱歉，客服功能已关闭（错误代码：40）')]";
        public static string ReplyFromHi = "//android.view.View[contains(@content-desc,'{0}')]";
        public static string WeChat = "//android.widget.FrameLayout[contains(@content-desc,'微信')]";
        public static string CustomerServiceRequest = "收到来自[{0}]的客服请求";
        public static string NoMessage = "当前没有新的客服消息";



    }
}
