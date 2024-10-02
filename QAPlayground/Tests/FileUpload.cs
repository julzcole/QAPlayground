using OpenQA.Selenium;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class FileUpload : BaseTest
    {
        public FileUpload(WebDriverFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void FileUploadTest()
        {
            var fileUploadPage = basePage.ClickUploadFileLink();
            fileUploadPage.UploadFile();
            string caption = fileUploadPage.ValidateCaption();
            Assert.Equal("tired.jpg", caption);
        }
    }
}
