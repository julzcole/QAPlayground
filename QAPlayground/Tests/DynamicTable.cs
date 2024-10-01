using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAPlayground.WrapperFactory;
using QAPlayground.TestingData;
using QAPlayground.PageObjects;

namespace QAPlayground.Tests
{
    public class DynamicTable : BaseTest
    {
        [Fact]
        public void DynamicTableTest()
        {
            var basePage = new BasePage(_driver);
            var dynamicTablePage = basePage.ClickDynamicTableLink();
            string spiderManName = dynamicTablePage.FindSpiderMan();
            Assert.Equal("Peter Parker", spiderManName);
        }
    }
}
