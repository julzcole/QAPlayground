using QAPlayground.PageObjects;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class NewTab : BaseTest
    {
        public NewTab(WebDriverFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void NewTabTest()
        {
            var newTabPage = basePage.ClickNewTabLink();
            string newTabTitle = newTabPage.ValidateNewTabOpened();
            Assert.Equal("Welcome to the new page!", newTabTitle);
        }
    }
}
