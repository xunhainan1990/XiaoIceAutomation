using Common.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.UIElement;

namespace XiaoIcePortal.Pages
{
    public class FaceRankingPage
    {
        public static void ClickFaceRanking()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(FaceRankingElement.FaceRanking).Click();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string CopyLink()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(FaceRankingElement.cs_skilldetail_button).Click();
                return PortalChromeDriver.GetElementByXpath(FaceRankingElement.copiedLink).GetAttribute("value");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void CopyAlertConfirm()
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(FaceRankingElement.CopyConfirmAlert).Click();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

      

        
    }
}
