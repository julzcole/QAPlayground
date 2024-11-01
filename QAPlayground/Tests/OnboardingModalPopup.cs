﻿using OpenQA.Selenium;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    [Collection("SequentialTests")]
    public class OnboardingModalPopup : BaseTest
    {
        public OnboardingModalPopup(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Validate title based on background color when clicking popup link.
        /// </summary>
        [Fact]
        public void OnboardingModalPopupTest()
        {
            extentTest = extent.CreateTest(this.GetType().Name);

            try
            {
                var onboardingModalPopupPage = basePage.ClickOnboardingModalPopup();
                bool isWhite = onboardingModalPopupPage.GetBackgroundColor();
                string titleText = onboardingModalPopupPage.ValidateTitleText(isWhite);

                if (isWhite)
                {
                    Assert.Contains("Welcome Peter Parker!", titleText);
                }
                else
                {
                    Assert.Contains("Application successfully launched!", titleText);
                }

                string screenshotPath = CaptureScreenshot(_driver, "OnboardingModalPopup_Pass");
                extentTest.Pass("The Onboarding Modal Popup test has passed!");
            }
            catch (Exception ex)
            {
                string screenshotPath = CaptureScreenshot(_driver, "OnboardingModalPopup_Fail");
                extentTest.Fail(ex);
                throw;
            }
        }
    }
}
