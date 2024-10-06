using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAPlayground.TestingData;
using QAPlayground.PageObjects;
using QAPlayground.Utilities;

namespace QAPlayground.Tests
{
    public class DynamicTable : BaseTest
    {
        public DynamicTable(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Finds the table containing Spider-Man and checks if the name is Peter Parker
        /// </summary>
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
