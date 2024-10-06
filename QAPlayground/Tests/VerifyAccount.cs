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
            var verifyAccountPage = basePage.ClickVerifyAccountLink();
            verifyAccountPage.EnterInputs("9");
            Assert.True(verifyAccountPage.ValidateSuccessMessage());

        }
    }
}
