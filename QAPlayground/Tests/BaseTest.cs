using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAPlayground.PageObjects;
using QAPlayground.TestingData;
using QAPlayground.WrapperFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace QAPlayground.Tests
{
    public class BaseTest :IDisposable
    {
        protected IWebDriver _driver;
        private TestData _testData;
        protected BasePage basePage;

        public BaseTest()
        {
            _testData = TestDataHelper.LoadTestData("C:\\Users\\xXJul\\source\\repos\\QAPlayground\\QAPlayground\\TestingData\\testData.json");
            WebDriverFactory.InitBrowser(_testData.Browser);
            WebDriverFactory.LoadApplication(_testData.Url);
            _driver = WebDriverFactory.Driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            basePage = new BasePage(_driver);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
