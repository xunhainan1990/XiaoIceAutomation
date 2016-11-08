﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSH5.UIElement
{
    public class HIMobileH5Element
    {
        public static string KeyBoardSwichXpath = "//android.widget.ImageButton[contains(@content-desc,'切换到键盘')]";
        public static string EditTextXpath = "//android.widget.EditText[contains(@resource-id,'com.tencent.mm:id/a1o')]";
        public static string SendButtonXpath = "//android.widget.Button[contains(@resource-id,'com.tencent.mm:id/a1u')]";
        public static string HiCardXpath = "//android.widget.LinearLayout[contains(@resource-id,'com.tencent.mm:id/a2b')]";
        public static string xb_inputboxXpath = "//android.widget.EditText[contains(@resource-id,'xb_inputbox')]";
        public static string xb_add_btnXpath = "//android.widget.Button[contains(@resource-id,'xb_add_btn')]";
        public static string xb_chatwith_text = "//android.view.View[contains(@resource-id,'xb_chatwith_text')]";
        public static string xb_chatwith_texttest = "//android.view.View[contains(@content-desc,'平台测试账号2')]";
        public static string xb_addimg_image= "//android.widget.Image[contains(@resource-id,'xb_addimg_image')]";
        public static string TakePhoto= "//android.widget.ImageView[contains(@resource-id,'com.android.camera:id/v6_shutter_button_internal')]";
        public static string backFromHI = "//android.widget.ImageView[contains(@resource-id,'com.tencent.mm:id/ft')]";
        public static string HIMessageFromCustom = "点击卡片，进行回复";
        public static string chatwith_Meg = "聊天信息";
        public static string moreInfo = "//android.view.View[contains(@content-desc,'更多')]";
        public static string ClearAll = "//android.widget.LinearLayout[@index='1']";
        public static string ClearAllConfirm = "//android.widget.Button[contains(@resource-id,'com.tencent.mm:id/bln')]";
        public static string MsgTexts= "//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/ho')]";
        public static string xb_page_body = "//android.view.View[contains(@resource-id,'xb_page_body')]";
        public static string SendImageConfirm = "//android.widget.ImageView[contains(@resource-id,'com.android.camera:id/v6_btn_done')]";
        public static string DocumentSelect = "//android.widget.FrameLayout[@index='1']";
        public static string ReplyCardFromHI = "客服人员已回复您的问题";
        public static string imageMessage= "//android.webkit.WebView[contains(@content-desc,'人工客服窗口')]/android.view.View[@index='1']";
        public static string ModifiedImage = "//android.webkit.WebView[contains(@content-desc,'人工客服窗口')]/android.view.View[@index='2']";
        public static string HIOffError = "//android.view.View[contains(@content-desc,'抱歉，客服功能已关闭（错误代码：40）')]";
    }
}