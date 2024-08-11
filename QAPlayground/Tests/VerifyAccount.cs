using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAPlayground.PageObjects;

namespace QAPlayground.Tests
{
    public class VerifyAccount : BaseTest
    {

        [Fact]
        public void VerifyAccountTest()
        {
            /*Enter valid code by pressing the key-up button or 
             typing number and assert success message*/

            var basePage = new BasePage(_driver);
            var verifyAccountPage = basePage.ClickVerifyAccountLink();
            verifyAccountPage.EnterInputs("9");
            Assert.True(verifyAccountPage.ValidateSuccessMessage());

        }
    }
}
