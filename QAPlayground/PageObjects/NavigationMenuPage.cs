using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class NavigationMenuPage : BasePage
    {
        private IWebDriver _driver;

        public NavigationMenuPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement BackButton => _driver.FindElement(By.XPath($"//a[normalize-space()='Go Back']"));
        private IWebElement TitleElement => _driver.FindElement(By.Id("title"));

        public string ValidateLinksAndContentTitleText(string link)
        {
            _driver.FindElement(By.XPath($"//a[normalize-space()='{link}']")).Click();
            return TitleElement.Text;
        }

        public void ClickBackButton()
        {
            BackButton.Click();
        }
    }
}
