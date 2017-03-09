using Common;
using CSH5;
using CSH5.UIElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal;

namespace XiaoIceH5
{
    public class FaceRankingH5Page
    {
        public static void ClickFaceRanking()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/a35')]").Click();

            }
            catch (Exception e)
            {
                MobileAndroidDriver.ClickElemnetPerName("服务按钮");
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/a35')]").Click();
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
                MobileAndroidDriver.GetElementByXpath(FaceRankingH5Element.More).Click();
                MobileAndroidDriver.GetElementByName(FaceRankingH5Element.SendToFriend).Click();
                MobileAndroidDriver.GetElementByName(FaceRankingH5Element.NewChat).Click();
                MobileAndroidDriver.GetElementByName(FaceRankingH5Element.FriendAccount).Click();
                MobileAndroidDriver.GetElementByName(FaceRankingH5Element.OK).Click();
                MobileAndroidDriver.GetElementByName(FaceRankingH5Element.Send).Click();
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
                MobileAndroidDriver.GetElementByXpath(FaceRankingH5Element.BackToWeChat).Click();
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
                FaceRankingH5Page.BackWards();
                FaceRankingH5Page.BackWards();
                MobileAndroidDriver.GetElementByName(MobileCommonElement.ContactList).Click();
                MobileAndroidDriver.GetElementByName(MobileCommonElement.ShareUser).Click();
                Thread.Sleep(2*1000);
                MobileAndroidDriver.GetElementByName(FaceRankingH5Element.ChatWith).Click();
                MobileH5.GetLatestMessageElement().Click();
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

                MobileAndroidDriver.Swipe(MobileAndroidDriver.GetElementByXpath(FaceRankingH5Element.SwipItem));
                MobileAndroidDriver.LongPress(MobileAndroidDriver.GetElementsByXpath(FaceRankingH5Element.QRCode)[2]);
                MobileAndroidDriver.GetElementByName(FaceRankingH5Element.QRCodeDetect).Click();
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
                string comment = MobileAndroidDriver.GetElementByXpath(CSH5.UIElement.FaceRankingH5Element.Comment).GetAttribute("name") ;
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

        

    }
}
