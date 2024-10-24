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
    public class ShadowDOM : BaseTest
    {
        public ShadowDOM(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Clicks button in shadow DOM and validates that the progress bar is at 95%
        /// </summary>
        [Fact]
        public void ShadowDomTest()
        {
            extentTest = extent.CreateTest(this.GetType().Name);

            try
            {
                var shadowDOMPage = basePage.ClickShadowDOMLink();
                string shadowProgressBar = shadowDOMPage.FindShadowButton();
                Assert.Contains("95", shadowProgressBar);
                string screenshotPath = CaptureScreenshot(_driver, "ShadowDOM_Pass");
                extentTest.Pass("The ShadowDOM test has passed!").AddScreenCaptureFromPath(screenshotPath);
            }
            catch (Exception ex)
            {
                string screenshotPath = CaptureScreenshot(_driver, "ShadowDOM_Fail");
                extentTest.Fail(ex).AddScreenCaptureFromPath(screenshotPath);
                throw;
            }
        }
    }
}
