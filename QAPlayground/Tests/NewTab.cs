using QAPlayground.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class NewTab : BaseTest
    {
        [Fact]
        public void NewTabTest()
        {
            var newTabPage = basePage.ClickNewTabLink();
            string newTabTitle = newTabPage.ValidateNewTabOpened();
            Assert.Equal("Welcome to the new page!", newTabTitle);
        }
    }
}
