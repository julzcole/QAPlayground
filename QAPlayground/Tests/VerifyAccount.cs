using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAPlayground.PageObjects;
using QAPlayground.Utilities;
using System.Net.NetworkInformation;

namespace QAPlayground.Tests
{
    [Collection("SequentialTests")]
    public class VerifyAccount : BaseTest
    {
        public VerifyAccount(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        ///Enter valid code by pressing the key-up button or typing number and assert success message
        /// </summary>
        [Fact]
        public void VerifyAccountTest()
        {
            extentTest = extent.CreateTest(this.GetType().Name);

            try
            {
                var verifyAccountPage = basePage.ClickVerifyAccountLink();
                verifyAccountPage.EnterInputs("9");
                Assert.True(verifyAccountPage.ValidateSuccessMessage());
                string screenshotPath = CaptureScreenshot(_driver, "VerifyAccount_Pass");
                extentTest.Pass("The Verify Account test has passed!").AddScreenCaptureFromPath(screenshotPath);
            }
            catch (Exception ex)
            {
                string screenshotPath = CaptureScreenshot(_driver, "VerifyAccount_Fail");
                extentTest.Fail(ex).AddScreenCaptureFromPath(screenshotPath);
                throw;
            }
        }
    }
}
