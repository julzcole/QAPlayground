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

        /// <summary>
        /// Tests a successful file upload to QAPlayground
        /// </summary>
        [Fact]
        public void FileUploadTest()
        {
            //Create the extent report for this test
            extentTest = extent.CreateTest(this.GetType().Name);

            try
            {
                var fileUploadPage = basePage.ClickUploadFileLink();
                fileUploadPage.UploadFile();
                string caption = fileUploadPage.ValidateCaption();
                Assert.Equal("tired.jpg", caption);
                extentTest.Pass("The File Upload Test has passed!");
            }
            catch (Exception ex)
            {
                extentTest.Fail(ex);
                throw;
            }
        }
    }
}
