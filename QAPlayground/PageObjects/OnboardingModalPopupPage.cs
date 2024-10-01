using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class OnboardingModalPopupPage : BasePage
    {
        private IWebDriver _driver;

        public OnboardingModalPopupPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement ModalButton => _driver.FindElement(By.CssSelector("label[for='active']"));
        private IWebElement Title => _driver.FindElement(By.XPath("//div[@class='title']"));

        public bool GetBackgroundColor()
        {
            string backgroundColor = ModalButton.GetCssValue("background");
            if (backgroundColor.Contains("rgb(255, 255, 255)"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ValidateTitleText(bool isWhite)
        {
            if (isWhite)
            {
                ModalButton.Click();
                return Title.Text;
            }
            else
            {
                return Title.Text;
            }
        }
    }
}
