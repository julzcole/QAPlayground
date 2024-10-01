using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class FileUpload : BaseTest
    {
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
