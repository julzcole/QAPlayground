using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class MultiLevelDropdownPage : BasePage
    {
        IWebDriver _driver;

        public MultiLevelDropdownPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private static readonly By AnimalMenuLocator = By.XPath("//a[@href='#animals']");
        private IWebElement ArrowDropdown => _driver.FindElement(By.XPath("//li[4]/a"));
        private IWebElement SettingsLink => _driver.FindElement(By.XPath("//a[@href='#settings']"));
        private ReadOnlyCollection<IWebElement> MenuItems => _driver.FindElements(By.XPath("//div[@class='menu menu-secondary-enter-done']/a"));
        private IWebElement BackButton => _driver.FindElement(By.XPath("//div[@class='menu menu-secondary-enter-done']/a/h2"));
        private IWebElement AnimalsLink => _driver.FindElement(AnimalMenuLocator);
        private ReadOnlyCollection<IWebElement> AnimalMenuItems => _driver.FindElements(By.XPath("//div[@class='menu menu-secondary-enter-done']/a"));


        public ReadOnlyCollection<IWebElement> ValidateSettingsMenuItems()
        {
            ArrowDropdown.Click();
            SettingsLink.Click();
            return MenuItems;
        }

        public ReadOnlyCollection<IWebElement> ValidateAnimalMenuItems()
        {
            BackButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AnimalMenuLocator));
            AnimalsLink.Click();
            return AnimalMenuItems;
        }
    }
}
