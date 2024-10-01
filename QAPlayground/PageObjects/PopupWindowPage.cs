using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class PopupWindowPage : BasePage
    {
        IWebDriver _driver;

        public PopupWindowPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement LoginButton => _driver.FindElement(By.Id("login"));
        private IWebElement SubmitButton => _driver.FindElement(By.TagName("button"));
        private IWebElement InfoTextElement => _driver.FindElement(By.Id("info"));

        public string ValidatePopupWindow()
        {
            string existingWindowHandle = _driver.CurrentWindowHandle;
            LoginButton.Click();
            IList<string> windowHandles = _driver.WindowHandles;

            foreach (string handle in windowHandles)
            {
                if (handle != existingWindowHandle)
                {
                    _driver.SwitchTo().Window(handle);
                    break;
                }
            }

            SubmitButton.Click();
            _driver.SwitchTo().Window(existingWindowHandle);
            return InfoTextElement.Text;
        }

    }
}
