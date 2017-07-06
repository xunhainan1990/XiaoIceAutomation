using Common;
using Mobile;
using Mobile.UIElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal;

namespace Mobile
{
    public class FaceRankingMobilePage_WeChat
    {
        public static void ClickFaceRanking()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/a3l')]").Click();

            }
            catch (Exception e)
            {
                MobileAndroidDriver.ClickElemnetPerName("服务按钮");
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/a3l')]").Click();
            }
        }

        public static void FaceRankingFromCamera()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/a34')]").Click();
                //MobileAndroidDriver.GetElementByName("拼颜值").Click();
                MobileAndroidDriver.GetElementByClassName("android.widget.Button").Click();
                MobileAndroidDriver.GetElementByName("相机").Click();
                MobileAndroidDriver.GetElementByXpath("//android.widget.ImageView[contains(@resource-id,'com.android.camera:id/v6_shutter_button_internal')]").Click();
                MobileAndroidDriver.GetElementByXpath("//android.widget.ImageView[contains(@resource-id,'com.android.camera:id/v6_btn_done')]").Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void FaceRankingFromFile(string fileName)
        {
            try
            {
                //MobileAndroidDriver.GetElementByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/a34')]").Click();
                //MobileAndroidDriver.GetElementByName("拼颜值").Click();
                MobileAndroidDriver.GetElementByClassName("android.widget.Button").Click();
                MobileAndroidDriver.GetElementByName("文档").Click();
                MobileAndroidDriver.GetElementByName("显示根目录").Click();
                MobileAndroidDriver.GetElementByName("图片").Click();
                MobileAndroidDriver.GetElementByName("WeiXin").Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.MoreButton).Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.ListView).Click();
                MobileAndroidDriver.GetElementByName(fileName,true).Click();
                Thread.Sleep(5*1000);
            }
            catch (Exception e)
            {
                try
                {
                    var top = MobileAndroidDriver.GetElementByXpath("//android.widget.FrameLayout[@index='1']");
                    MobileAndroidDriver.Swipe(top);
                    MobileAndroidDriver.GetElementByName(fileName, true).Click();
                }
                catch
                {
                    try
                    {
                        var top = MobileAndroidDriver.GetElementByXpath("//android.widget.FrameLayout[@index='1']");
                        MobileAndroidDriver.Swipe(top);
                        MobileAndroidDriver.GetElementByName(fileName, true).Click();
                        Thread.Sleep(5 * 1000);
                    }
                    catch
                    {
                        var top = MobileAndroidDriver.GetElementByXpath("//android.widget.FrameLayout[@index='1']");
                        MobileAndroidDriver.Swipe(top);
                        MobileAndroidDriver.GetElementByName(fileName, true).Click();
                        Thread.Sleep(5 * 1000);
                    }
                }
            }
        }

        public static void SwipeSetting()
        {
            try
            {

                bool flag = true;
                while(true)
                {
                    var elements = MobileAndroidDriver.GetElementsByXpath("//android.widget.TextView[contains(@resource-id,'android:id/title')]");
                    foreach (var item in elements)
                    {
                        if (item.Text == "更多设置")
                        {
                            item.Click();
                            flag = false;
                            return;
                        }                            
                    }
                    MobileAndroidDriver.Swipe(MobileAndroidDriver.GetElementByXpath("//android.widget.FrameLayout[@index='10']"));
                }  
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void ShareToSomeOne()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(FaceRankingMobileElement.More).Click();
                MobileAndroidDriver.GetElementByName(FaceRankingMobileElement.SendToFriend).Click();
                MobileAndroidDriver.GetElementByName(FaceRankingMobileElement.NewChat).Click();
                MobileAndroidDriver.GetElementByName(FaceRankingMobileElement.FriendAccount).Click();
                MobileAndroidDriver.GetElementByName(FaceRankingMobileElement.OK).Click();
                MobileAndroidDriver.GetElementByName(FaceRankingMobileElement.Send).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void BackWards()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(FaceRankingMobileElement.BackToWeChat).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void CheckLinkAvailable()
        {
            try
            {
                FaceRankingMobilePage_WeChat.BackWards();
                FaceRankingMobilePage_WeChat.BackWards();
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.ContactList).Click();
                MobileAndroidDriver.GetElementByName(MobileCommonElement_WeChat.ShareUser).Click();
                Thread.Sleep(2*1000);
                MobileAndroidDriver.GetElementByName(FaceRankingMobileElement.ChatWith).Click();
                Mobile_WeChat_Utility.GetLatestMessageElement().Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void ClickQRCode()
        {
            try
            {

                MobileAndroidDriver.Swipe(MobileAndroidDriver.GetElementByXpath(FaceRankingMobileElement.SwipItem));
                MobileAndroidDriver.LongPress(MobileAndroidDriver.GetElementsByXpath(FaceRankingMobileElement.QRCode)[2]);
                MobileAndroidDriver.GetElementByName(FaceRankingMobileElement.QRCodeDetect).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string Getfraction(ref double before,ref double after)
        {
            try
            {             
                string comment = MobileAndroidDriver.GetElementByXpath(Mobile.UIElement.FaceRankingMobileElement.Comment).GetAttribute("name") ;
                Regex r = new Regex(@"\d(\.\d+)");
                int start = 0;
                Match m = r.Match(comment, start);
                if (m.Success)
                {
                    m = m.NextMatch();
                    if (m.Length ==4) {
                        before = double.Parse(m.Value.ToString());                        
                    }
                    m = m.NextMatch();
                    if (m.Length == 4)
                    {
                        after = double.Parse(m.Value.ToString());
                    }

                }
                return null;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static bool CheckOficailAccountShow(string Account= "公众号名称：平台测试账号2")
        {
            try
            {
                MobileAndroidDriver.GetElementByName(Account);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

       

    }
}
