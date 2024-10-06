using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
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
            var qrCodeGeneratorPage = basePage.ClickQRCodeGeneratorLink();
            bool qrCodeIsDisplayed = qrCodeGeneratorPage.ValidateQRCode();
            Assert.True(qrCodeIsDisplayed);
        }
    }
}
