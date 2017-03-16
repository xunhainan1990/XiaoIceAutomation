using Common;
using CSH5.UIElement;
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
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.FaceRanking);
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
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.UploadImage);
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.FromFile);
                MobileAndroidDriver.GetElementByName("显示根目录").Click();
                MobileAndroidDriver.GetElementByName("图片").Click();
                MobileAndroidDriver.GetElementByName("WeiXin").Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.MoreButton).Click();
                //MobileAndroidDriver.GetElementByName(PhotoFileElement.ListView).Click();
                MobileAndroidDriver.GetElementByName(file, true).Click();
                Thread.Sleep(5 * 1000);
            }
            catch (Exception e)
            {

            }
        }

        public static void ShareToWeibo()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.ShaiChuQu);
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.Share);
            }
            catch (Exception e)
            {

            }
        }

        public static void CheckLinkAvailable()
        {
            try
            {
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.GoToMyWeibo);
                MobileAndroidDriver.ClickElemnetPerName(FaceRankingMobileElement.Share);
            }
            catch (Exception e)
            {

            }
        }
    }
}
