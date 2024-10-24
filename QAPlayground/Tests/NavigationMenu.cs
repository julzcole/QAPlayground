using OpenQA.Selenium;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    [Collection("SequentialTests")]
    public class NavigationMenu : BaseTest
    {
        public NavigationMenu(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Click all the links and assert the correct title displays.
        /// </summary>
        [Fact]
        public void NavigationMenuTest()
        {
            extentTest = extent.CreateTest(this.GetType().Name);

            try
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

                string screenshotPath = CaptureScreenshot(_driver, "NavigationMenu_Pass");
                extentTest.Pass("The Navigation Menu test has passed").AddScreenCaptureFromPath(screenshotPath);
            }
            catch (Exception ex)
            {
                string screenshotPath = CaptureScreenshot(_driver, "NavigationMenu_Fail");
                extentTest.Fail(ex).AddScreenCaptureFromPath(screenshotPath);
                throw;
            }
        }
    }
}

