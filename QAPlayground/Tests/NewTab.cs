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
    public class NewTab : BaseTest
    {
        public NewTab(WebDriverFixture fixture) : base(fixture)
        {
        }


        /// <summary>
        /// Validate title message on new tab displays.
        /// </summary>
        [Fact]
        public void NewTabTest()
        {
            extentTest = extent.CreateTest(this.GetType().Name);

            try
            {
                var newTabPage = basePage.ClickNewTabLink();
                string newTabTitle = newTabPage.ValidateNewTabOpened();
                Assert.Equal("Welcome to the new page!", newTabTitle);
                string screenshotPath = CaptureScreenshot(_driver, "NewTab_Pass");
                extentTest.Pass("The New Tab test has passed!").AddScreenCaptureFromPath(screenshotPath);
            }
            catch (Exception ex)
            {
                string screenshotPath = CaptureScreenshot(_driver, "NewTab_Fail");
                extentTest.Fail(ex).AddScreenCaptureFromPath(screenshotPath);
                throw;
            }
        }
    }
}
