using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V124.HeadlessExperimental;
using OpenQA.Selenium.Support.UI;
using QAPlayground.PageObjects;
using QAPlayground.TestingData;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace QAPlayground.Tests
{
    public class BaseTest : IClassFixture<WebDriverFixture>, IDisposable
    {
        protected IWebDriver _driver;
        private TestData _testData;
        protected BasePage basePage;
        private readonly WebDriverFixture _fixture;
        protected static ExtentReports extent;
        protected ExtentTest extentTest;
        private static bool _reportInitialized = false; //to ensure that the report is not created multiple times

        //Initialize resources used in every test as every test inherits from the base test and the base test creates an instance of WebDriverFixture
        public BaseTest(WebDriverFixture fixture)
        {   
            //Sets the WebDriverFixture and the Test Data as properties of the base test
            _fixture = fixture;
            _testData = _fixture.GetTestData();

            //Initialize Extent Report for all tests in this run if not already done for this test execution
            if (!_reportInitialized)
            {
                SetUpExtentReports();
                _reportInitialized = true;
            }
            
            //Initialize the driver and go to the base URL for QA Playground
            _driver = _fixture.Driver;
            _driver.Navigate().GoToUrl(_testData.Url);
            basePage = new BasePage(_driver);
        }

        //Creates the extent reports
        private void SetUpExtentReports()
        {
            //create a dynamic report path for pipeline runs
            var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults", "ExtentReport" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html");
            
            //Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            extent = new ExtentReports();
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent.AttachReporter(htmlReporter);
        }

        //Used by test classes to capture a screenshot on test pass and failure
        public string CaptureScreenshot(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots", screenshotName + ".png");

            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }

            screenshot.SaveAsFile(filePath);
            return filePath;
        }

        //Dispose Extent Reports and creates the report file
        public void Dispose()
        {
            extent.Flush();
        }
    }
}
