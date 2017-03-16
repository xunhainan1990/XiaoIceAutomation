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
    public class MaterialPage
    {
        public static void TurnToNextPage()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MaterialElement.NextPage);
            }
            catch (Exception e)
            {

            }
        }

        public static void TurnToNextPage_Input(string page_Input)
        {
            try
            {
                PortalChromeDriver.GetElementByXpath(MaterialElement.NextPage_Input).Clear();
                PortalChromeDriver.SendKeysPerXpath(MaterialElement.NextPage_Input, page_Input);
                PortalChromeDriver.ClickElementPerXpath(MaterialElement.pagejump_btn);
                System.Threading.Thread.Sleep(3 * 1000);
            }
            catch (Exception e)
            {

            }

        }

        public static bool IsClickable(string xpath)
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(xpath);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool IsClickablePerCssSelector(string cssSelector)
        {
            try
            {
                PortalChromeDriver.GetElementsByCssSelector(cssSelector);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void Set_All()
        {
            try
            {
                PortalChromeDriver.ClickElementPerXpath(MaterialElement.Article_Button);
                PortalChromeDriver.ClickElementPerXpath(MaterialElement.Set_All);
                PortalChromeDriver.ClickElementPerXpath(MaterialElement.Save_Button);
                System.Threading.Thread.Sleep(2*1000);
            }
            catch (Exception e)
            {

            }
        }
       
    }
}
