using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class QRCodeGeneratorTests : BaseTest
    {
        [Fact]
        public void QRCodeGeneratorTest()
        {
            var qrCodeGeneratorPage = basePage.ClickQRCodeGeneratorLink();
            bool qrCodeIsDisplayed = qrCodeGeneratorPage.ValidateQRCode();
            Assert.True(qrCodeIsDisplayed);
        }
    }
}
