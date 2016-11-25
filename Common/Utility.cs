using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Utility
    {
        public static bool IsAt(string xpath)
        {
            try
            {
                var element = Driver.PortalChromeDriver.GetElementByXpath(xpath);
                return true;
            }
            catch(Exception e) { return false; }
        }
    }
}
