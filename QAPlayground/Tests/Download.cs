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

        [Fact]
        public void DownloadTest()
        {
            var fileDownloadPage = basePage.ClickDownloadFileLink();
            fileDownloadPage.DownloadFile();
            string filePath = @"C:\Users\xXJul\Downloads\sample.pdf";
            Thread.Sleep(2000);
            Assert.True(File.Exists(filePath));
        }
    }
}
