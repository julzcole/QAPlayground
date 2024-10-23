using QAPlayground.DriverFactory;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
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
                extentTest.Pass("The Download test has passed!");
            }
            catch(Exception ex)
            {
                extentTest.Fail(ex);
                throw;
            }
        }
    }
}
