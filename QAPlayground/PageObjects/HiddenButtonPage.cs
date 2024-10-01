using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class HiddenButtonPage : BasePage
    {
        private IWebDriver _driver;

        public HiddenButtonPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement FugitiveButton => _driver.FindElement(By.Id("fugitive"));
        private IWebElement InfoTextElement => _driver.FindElement(By.Id("info"));

        public string ValidateButtonClick()
        {
            FugitiveButton.Click();
            return InfoTextElement.Text;
        }
    }
}
