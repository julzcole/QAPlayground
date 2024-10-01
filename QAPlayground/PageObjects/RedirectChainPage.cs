using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V124.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class RedirectChainPage : BasePage
    {
        private IWebDriver _driver;

        public RedirectChainPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement RedirectButton => _driver.FindElement(By.Id("redirect"));
        
        public void ClickRedirectButton()
        {
            RedirectButton.Click();
        }

        public string ValidateUrls()
        {
            return _driver.Url;
        }
    }
}
