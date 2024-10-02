using OpenQA.Selenium;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class NavigationMenu : BaseTest
    {
        public NavigationMenu(WebDriverFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void NavigationMenuTest()
        {
            string[] links = { "About", "Blog", "Portfolio", "Contact" };
            string[] content = {"Welcome to the About Page", "Welcome to the Blog Page",
                "Welcome to the Portfolio Page", "Welcome to the Contact Page"};
            var navigationMenuPage = basePage.ClickNavigationMenuLink();

            for (int i = 0; i < links.Length; i++)
            {
                string titleText = navigationMenuPage.ValidateLinksAndContentTitleText(links[i]);
                Assert.Equal(content[i], titleText);
                navigationMenuPage.ClickBackButton();
            }
        }
    }
}

