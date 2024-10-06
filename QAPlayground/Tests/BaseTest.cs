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

        //Initialize resources used in every test as every test inherits from the base test and the base test creates an instance of WebDriverFixture
        public BaseTest(WebDriverFixture fixture)
        {   
            //Sets the WebDriverFixture and the Test Data as properties of the base test
            _fixture = fixture;
            _testData = _fixture.GetTestData();

            //Initialize the driver and go to the base URL for QA Playground
            _driver = _fixture.Driver;
            _driver.Navigate().GoToUrl(_testData.Url);
            basePage = new BasePage(_driver);
        }
    }
}
