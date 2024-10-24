using OpenQA.Selenium;
using QAPlayground.PageObjects;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    [Collection("SequentialTests")]
    public class HiddenButton : BaseTest
    {
        public HiddenButton(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Click hidden button and assert that Mission Accomplished is displayed.
        /// </summary>
        [Fact]
        public void HiddenButtonTest()
        {
            extentTest = extent.CreateTest(this.GetType().Name);

            try
            {
                var hiddenButtonPage = basePage.ClickHiddenButtonLink();
                string infoText = hiddenButtonPage.ValidateButtonClick();
                Assert.Contains("Mission accomplished", infoText);
                string screenshotPath = CaptureScreenshot(_driver, "HiddenButton_Pass");
                extentTest.Pass("The Hidden Button test has passed!");
            }
            catch (Exception ex)
            {
                string screenshotPath = CaptureScreenshot(_driver, "HiddenButton_Fail");
                extentTest.Fail(ex).AddScreenCaptureFromPath(screenshotPath);
                throw;
            }
        }
    }
}
