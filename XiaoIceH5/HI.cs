using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIceH5.UIElement;
using XiaoIcePortal;
using XiaoIcePortal.Pages;
using XiaoIcePortal.UIElement;

namespace XiaoIceH5
{
    public class HI
    {
        public static bool IsHiCardShow()
        {
            try
            {
                if (AndroidDriver.GetElmentByXpath(HIChatElement.HiCardXpath) != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            { return false; }
        }

        public static bool IsOfficialAccountNameShow()
        {
            try
            {
                if(AndroidDriver.GetElmentByXpath(HIChatElement.xb_chatwith_texttest)!=null)
                {
                    return true;
                }
                return false;                                                                     
            }
            catch (Exception e)
            { return false; }
        }

        public static bool IsReplyFromHI()
        {
            try
            {
                var replyCard = AndroidDriver.GetElementByName(HIChatElement.ReplyCardFromHI);
                if (replyCard != null)
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {

                return false;
            }
        }

        public static void ClearAllRecord()
        {
            try
            {
                AndroidDriver.GetElementByName(HIChatElement.chatwith_Meg).Click();
                Thread.Sleep(5*1000);
                AndroidDriver.GetElementByName("更多").Click();
                Thread.Sleep(5 * 1000);
                AndroidDriver.GetElmentByXpath("//android.widget.LinearLayout[@index='1']").Click();
                Thread.Sleep(5 * 1000);
                AndroidDriver.GetElmentByXpath(HIChatElement.ClearAllConfirm).Click();
                Thread.Sleep(5 * 1000);
                AndroidDriver.GetElmentByXpath(HIChatElement.backFromHI).Click();
                Thread.Sleep(5 * 1000);
            }
            catch (Exception e)
            { }
        }

        public static bool IsStaffBind()
        {
            try
            {
                var list = AndroidDriver.GetElmentsByXpath(HIChatElement.MsgTexts);
                foreach (var item in list)
                {
                    if (item.Text.Equals("客服接入成功！"))
                        return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void  GetToTestAccount()
        {
            var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
            contactlist.Click();
            Thread.Sleep(2 * 1000);

            var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
            officialaccount.Click();
            Thread.Sleep(2 * 1000);

            var testAccout = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
            testAccout.Click();
            Thread.Sleep(5 * 1000);
        }

        public static void SendMessage(string text)
        {
            var keyBoardSwich = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
            keyBoardSwich.Click();
            Thread.Sleep(5 * 1000);

            var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
            sendMessage.SendKeys(text);
            Thread.Sleep(5 * 1000);

            var sendButton = AndroidDriver.GetElmentByXpath(HIChatElement.SendButtonXpath);
            sendButton.Click();
            Thread.Sleep(10 * 1000);
        }

        public static void XB_SendMessage(string text)
        {

            var xb_inputbox = AndroidDriver.GetElmentByXpath(HIChatElement.xb_inputboxXpath);
            xb_inputbox.SendKeys(text);
            Thread.Sleep(5 * 1000);

            var xb_add_btn = AndroidDriver.GetElmentByXpath(HIChatElement.xb_add_btnXpath);
            xb_add_btn.Click();          
            Thread.Sleep(5 * 1000);
            xb_add_btn.Click();
        }

        public static bool CanBindStaff()
        {
            try
            {
                var text = AndroidDriver.GetElementByName("客服接入成功！");
                if(text!=null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void BindStaff()
        {
            //切换到Hi的设置Tab页
            HIPage.SwichHISettingTab(HIPageUIElement.SubTabHIStaff);
            //判断是否已经绑定客服，如果绑定，则删除客服
            HIPage.DeleteStaff();
            //获取绑定客服验证码
            var value = HIPage.GetLoginCode();
            //H5页面进入平台测试账号对话窗口     
            GetToTestAccount();
            //删除聊天记录
            ClearAllRecord();
            Thread.Sleep(5 * 1000);
            //发送验证码
            SendMessage(value);
        }

    }
}
