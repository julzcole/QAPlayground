using OpenQA.Selenium;
using QAPlayground.PageObjects;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class HiddenButton : BaseTest
    {
        public HiddenButton(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Click hidden button and assert that Mission Accomplished is displayed.
        /// </summary>
        [Fact]
        public void HiddenButtonTest()
        {
            var hiddenButtonPage = basePage.ClickHiddenButtonLink();
            string infoText = hiddenButtonPage.ValidateButtonClick();
            Assert.Contains("Mission accomplished", infoText);
        }
    }
}
