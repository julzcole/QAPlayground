using QAPlayground.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class ShadowDOM : BaseTest
    {
        [Fact]
        public void ShadowDomTest()
        {
            var shadowDOMPage = basePage.ClickShadowDOMLink();
            string shadowProgressBar = shadowDOMPage.FindShadowButton();
            Assert.Contains("95", shadowProgressBar);
        }
    }
}
