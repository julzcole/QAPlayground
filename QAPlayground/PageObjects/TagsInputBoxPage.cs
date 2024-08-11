using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class TagsInputBoxPage : BasePage
    {
        IWebDriver _driver;
        public TagsInputBoxPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private ReadOnlyCollection<IWebElement> tagIcons => _driver.FindElements(By.XPath("//li/i"));
        private IWebElement TextBox => _driver.FindElement(By.XPath("//input[@type='text']"));
        private IWebElement RemainingTags => _driver.FindElement(By.XPath("//div[@class='details']/p/span"));
        public void ClickAllIcons()
        {
            foreach (var icon in tagIcons)
            {
                icon.Click();
            }
        }

        public void EnterTags(string[] tags)
        {
            foreach (string tag in tags)
            {
                TextBox.SendKeys(tag);
                TextBox.SendKeys(Keys.Enter);
            }
        }

        public string ValidateRemainingTags()
        {
            return RemainingTags.Text;
        }
    }
}