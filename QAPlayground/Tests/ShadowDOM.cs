using QAPlayground.PageObjects;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class ShadowDOM : BaseTest
    {
        public ShadowDOM(WebDriverFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void ShadowDomTest()
        {
            var shadowDOMPage = basePage.ClickShadowDOMLink();
            string shadowProgressBar = shadowDOMPage.FindShadowButton();
            Assert.Contains("95", shadowProgressBar);
        }
    }
}
