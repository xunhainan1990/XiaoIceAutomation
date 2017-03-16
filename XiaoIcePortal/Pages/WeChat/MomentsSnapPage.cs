using Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIcePortal.UIElement;

namespace XiaoIcePortal.Pages
{
    public class MomentsSnapPage
    {
        public static void CreateCampaign(string trigger)
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.createCampaign);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.SendKeysPerXpath(MomentsSnapshotElement.text_input, "a");
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.addKeyword);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.SendKeysPerXpath(MomentsSnapshotElement.Keyword_Input, trigger);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.addTextContent);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.SendKeysPerXpath(MomentsSnapshotElement.Response, "ok");
                Thread.Sleep(5 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.OK);
                Thread.Sleep(10 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.OK);
            }
            catch (Exception e)
            {
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.OK);
            }

        }

        public static void CreateCampaign_News()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.createCampaign);
                PortalChromeDriver.SendKeysPerXpath(MomentsSnapshotElement.text_input, "a");
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.addKeyword);
                PortalChromeDriver.SendKeysPerXpath(MomentsSnapshotElement.Keyword_Input, "河北");
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.addImageContent);
                Thread.Sleep(2*1000);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.image);
                PortalChromeDriver.ClickElementPerXpath(CommonElement.ImageConfirm);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.OK);
                Thread.Sleep(2 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.OK);
            }
            catch (Exception e)
            {

            }

        }

        public static void DeleteCampain()
        {
            try
            {
                var campain = PortalChromeDriver.GetElementsByClassName("entity_panel");
                if (campain != null)
                {
                    PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.removeCampain);
                    PortalChromeDriver.ClickElementPerXpath(CommonElement.Confirm);
                }             
            }
            catch (Exception e)
            {

            }
        }

        public static void EditCampain()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.expand);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.CampainTitle);
                PortalChromeDriver.SendKeysPerXpath(MomentsSnapshotElement.text_input, "update");
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.UpdateCampain);
            }
            catch (Exception e)
            {

            }
        }

        public static void DeleteKeyword()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.expand);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.DeleteKeyword);
                Thread.Sleep(1*1000);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.UpdateCampain);
            }
            catch (Exception e)
            {

            }

        }

        public static void DeleteResponse()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.expand);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.DeleteResponse);
                Thread.Sleep(1 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.UpdateCampain);
            }
            catch (Exception e)
            {

            }
        }

        public static void EditKeyword()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.expand);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.UpdateKeyword);
                PortalChromeDriver.SendKeysPerXpath(MomentsSnapshotElement.Keyword_Input,"update");
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.UpdateCampain);
            }
            catch (Exception e)
            {

            }
        }

        public static void EditResponse()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.expand);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.UpdateResponse);
                Thread.Sleep(1 * 1000);
                PortalChromeDriver.SendKeysPerXpath(MomentsSnapshotElement.Response, "update");
                Thread.Sleep(1 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.UpdateCampain);
                Thread.Sleep(1 * 1000);
                PortalChromeDriver.ClickElementPerXpath(MomentsSnapshotElement.UpdateCampain);
            }
            catch (Exception e)
            {

            }
        }
    }
}
