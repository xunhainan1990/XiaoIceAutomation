using Common;
using Mobile.UIElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mobile
{
    public class FaceRankingMobilePage_Weibo
    {
        public static void ClickFaceRanking()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_WeChat.Menu);
                MobileAndroidDriver.GetElementByXpath(FaceRankingMobileElement.Menuitem).Click();
            }
            catch (Exception e)
            {
                MobileAndroidDriver.ClickElemnetPerName("服务按钮");
                MobileAndroidDriver.GetElementByXpath("//android.widget.TextView[contains(@resource-id,'com.tencent.mm:id/a35')]").Click();
            }
        }

        public static void FaceRankingFromFile(string file)
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(FaceRankingMobileElement.UploadImage).Click();
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.FromFile);
                MobileAndroidDriver.GetElementByName("显示根目录").Click();
                MobileAndroidDriver.GetElementByName("图片").Click();
                MobileAndroidDriver.GetElementByName("WeiXin").Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.MoreButton).Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.ListView).Click();
                MobileAndroidDriver.GetElementByName(file).Click();
                Thread.Sleep(5 * 1000);
            }
            catch (Exception e)
            {

                try
                {
                    var top = MobileAndroidDriver.GetElementByXpath("//android.widget.FrameLayout[@index='1']");
                    MobileAndroidDriver.Swipe(top);
                    MobileAndroidDriver.GetElementByName(file, true).Click();
                }
                catch
                {
                    try
                    {
                        var top = MobileAndroidDriver.GetElementByXpath("//android.widget.FrameLayout[@index='1']");
                        MobileAndroidDriver.Swipe(top);
                        MobileAndroidDriver.GetElementByName(file, true).Click();
                        Thread.Sleep(5 * 1000);
                    }
                    catch
                    {
                        var top = MobileAndroidDriver.GetElementByXpath("//android.widget.FrameLayout[@index='1']");
                        MobileAndroidDriver.Swipe(top);
                        MobileAndroidDriver.GetElementByName(file, true).Click();
                        Thread.Sleep(5 * 1000);
                    }
                }
            }
        }

        public static void ShareToWeibo()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.ShaiChuQu);
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.Share);
                MobileAndroidDriver.GetElementByXpath(FaceRankingMobileElement.CheckWeiboShare).Click();
            }
            catch (Exception e)
            {

            }
        }

        public static void ShareToWeChat()
        {
            try
            {
                MobileAndroidDriver.GetElementByXpath(FaceRankingMobileElement.Weibo_More).Click();
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.WeChat_Moment);
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.Send);
                Mobile_WeChat_Utility.BackToHome();
                MobileAndroidDriver.androidDriver.Dispose();
                MobileAndroidDriver.AndroidInitialize();
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_WeChat.Discover);
                MobileAndroidDriver.ClickElemnetPerName(MobileCommonElement_WeChat.Moments);
                MobileAndroidDriver.GetElementByXpath(FaceRankingMobileElement.Webo_Share).Click();
            }
            catch (Exception e)
            {

            }
        }

        
    }
}
