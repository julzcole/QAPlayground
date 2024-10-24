using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    [Collection("SequentialTests")]
    public class QRCodeGeneratorTests : BaseTest
    {
        public QRCodeGeneratorTests(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Validate QR Code is displayed when text is entered and button is clicked
        /// </summary>
        [Fact]
        public void QRCodeGeneratorTest()
        {
            extentTest = extent.CreateTest(this.GetType().Name);

            try
            {
                var qrCodeGeneratorPage = basePage.ClickQRCodeGeneratorLink();
                bool qrCodeIsDisplayed = qrCodeGeneratorPage.ValidateQRCode();
                Assert.True(qrCodeIsDisplayed);
                string screenshotPath = CaptureScreenshot(_driver, "QRCode_Pass");
                extentTest.Pass("The QR Code Generator test has passed!").AddScreenCaptureFromPath(screenshotPath);
            }
            catch (Exception ex)
            {
                string screenshotPath = CaptureScreenshot(_driver, "QRCode_Fail");
                extentTest.Fail(ex).AddScreenCaptureFromPath(screenshotPath);
                throw;
            }
        }
    }
}
