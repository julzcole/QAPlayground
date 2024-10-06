using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAPlayground.PageObjects;
using QAPlayground.TestingData;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace QAPlayground.Tests
{
    public class BaseTest : IClassFixture<WebDriverFixture>
    {
        protected IWebDriver _driver;
        private TestData _testData;
        protected BasePage basePage;
        private readonly WebDriverFixture _fixture;

        public BaseTest(WebDriverFixture fixture)
        {
            _fixture = fixture;
            _driver = _fixture.Driver;
            _testData = TestDataHelper.LoadTestData(Path.Combine(Directory.GetCurrentDirectory(), "TestingData/testData.json"));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl(_testData.Url);
            basePage = new BasePage(_driver);
        }
    }
}
