using QAPlayground.DriverFactory;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    [Collection("SequentialTests")]
    public class Download : BaseTest
    {
        public Download(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Tests that the sample file is downloaded to the correct directory.
        /// </summary>
        [Fact]
        public void DownloadTest()
        {
            //Create the extent report for this test
            extentTest = extent.CreateTest(this.GetType().Name);
            try
            {
                var fileDownloadPage = basePage.ClickDownloadFileLink();
                fileDownloadPage.DownloadFile();
                string downloadedFile = Path.Combine(WebDriverFactory.GetDownloadDirectory(), "sample.pdf");
                Thread.Sleep(2000);
                Assert.True(File.Exists(downloadedFile));

                if (File.Exists(downloadedFile))
                {
                    File.Delete(downloadedFile);
                }
                string screenshotPath = CaptureScreenshot(_driver, "DownloadTest_Pass");
                extentTest.Pass("The Download test has passed!").AddScreenCaptureFromPath(screenshotPath);
            }
            catch(Exception ex)
            {
                string screenshotPath = CaptureScreenshot(_driver, "DownloadTest_Fail");
                extentTest.Fail(ex).AddScreenCaptureFromPath(screenshotPath);
                throw;
            }
        }
    }
}
