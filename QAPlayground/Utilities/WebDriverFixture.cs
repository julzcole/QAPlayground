using OpenQA.Selenium;
using QAPlayground.DriverFactory;
using QAPlayground.TestingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Utilities
{
    public class WebDriverFixture : IDisposable
    {
        private TestData _testData;
        public IWebDriver Driver { get; private set; }

        public WebDriverFixture()
        {
            _testData = TestDataHelper.LoadTestData(Path.Combine(Directory.GetCurrentDirectory(), "TestingData/testData.json"));
            var factory = new WebDriverFactory();
            Driver = factory.CreateDriver(_testData.Browser);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
