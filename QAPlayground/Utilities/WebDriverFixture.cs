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
        private TestData TestData { get; }
        public IWebDriver Driver { get; private set; }

        public WebDriverFixture()
        {
            //Get the test data from TestDataHelper
            TestData = TestDataHelper.LoadTestData(Path.Combine(Directory.GetCurrentDirectory(), "TestingData/testData.json"));

            //Instantiates WebDriverFactory then creates the driver for each test execution
            var factory = new WebDriverFactory();
            Driver = factory.CreateDriver(TestData.Browser);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public TestData GetTestData()
        {
            return TestData;
        }

        //Disposes of the driver object after test completion
        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
