using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class OnboardingModalPopup : BaseTest
    {
        [Fact]
        public void OnboardingModalPopupTest()
        {
            var onboardingModalPopupPage = basePage.ClickOnboardingModalPopup();
            bool isWhite = onboardingModalPopupPage.GetBackgroundColor();
            string titleText = onboardingModalPopupPage.ValidateTitleText(isWhite);

            if(isWhite)
            {
                Assert.Contains("Welcome Peter Parker!", titleText);
            }
            else
            {
                Assert.Contains("Application successfully launched!", titleText);
            }
        }
    }
}
