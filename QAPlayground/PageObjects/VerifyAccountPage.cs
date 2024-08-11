using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class VerifyAccountPage : BasePage
    {
        public readonly IWebDriver _driver;

        public VerifyAccountPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IReadOnlyCollection<IWebElement> numInputs => _driver.FindElements(By.XPath("//input"));
        private IWebElement successMessage => _driver.FindElement(By.XPath("//small[@class='info success']"));
        public void EnterInputs(string number)
        {
            foreach(var input in numInputs)
            {
                input.SendKeys(number);
            }
        }

        public bool ValidateSuccessMessage()
        {
            return successMessage.Displayed;
        }
    }
}
