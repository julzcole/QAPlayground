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

        [Fact]
        public void HiddenButtonTest()
        {
            var hiddenButtonPage = basePage.ClickHiddenButtonLink();
            string infoText = hiddenButtonPage.ValidateButtonClick();
            Assert.Contains("Mission accomplished", infoText);
        }
    }
}
