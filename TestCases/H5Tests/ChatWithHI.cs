using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaoIceH5;
using XiaoIceH5.UIElement;

namespace TestCases.H5Tests
{
    [TestClass]
    public class ChatWithHI:H5TestInit
    {

        /// <summary>
        /// 3.	是否可以触发人工客服card，当输入含有找客服意向的语句
        /// </summary>
        [TestMethod]
        public void TriggerHICard()
        {
            //H5 Action
            var contactlist = AndroidDriver.GetElementByName(WeChatCommonElement.ContactList);
            contactlist.Click();
            Thread.Sleep(2 * 1000);

            var officialaccount = AndroidDriver.GetElementByName(WeChatCommonElement.OfficialAccount);
            officialaccount.Click();
            Thread.Sleep(2 * 1000);

            var bibilog = AndroidDriver.GetElementByName(WeChatCommonElement.TestAccout);
            bibilog.Click();
            Thread.Sleep(5 * 1000);

            var input = AndroidDriver.GetElmentByXpath(HIChatElement.KeyBoardSwichXpath);
            input.Click();
            Thread.Sleep(5 * 1000);

            var sendMessage = AndroidDriver.GetElmentByXpath(HIChatElement.EditTextXpath);
            sendMessage.SendKeys("客服");
            Thread.Sleep(5 * 1000);

            Assert.IsTrue(XiaoIceH5.HI.IsHiCardShow());
        }

      

    }
}
