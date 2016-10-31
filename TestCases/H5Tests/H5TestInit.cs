using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoIceH5;

namespace TestCases.H5Tests
{
    public class H5TestInit
    {
        [TestInitialize]
        public void Inti()
        {
            if (AndroidDriver.androidDriver == null)
            {
                AndroidDriver.AndroidInitialize();
            }
        }
        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
