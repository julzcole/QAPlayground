using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class ShadowDomPage : BasePage
    {
        private IWebDriver _driver;
        public ShadowDomPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public string FindShadowButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            string shadowHostSelector = "body > main > div > progress-bar";
            string shadowButtonSelector = "div:nth-child(3) > button";
            string shadowProgressSelector = "div.container > div";
            string script = @"
            return document.querySelector(arguments[0])
                .shadowRoot.querySelector(arguments[1]);
        ";
            IWebElement shadowButton = (IWebElement)js.ExecuteScript(script, shadowHostSelector, shadowButtonSelector);
            shadowButton.Click();

            IWebElement shadowProgress = (IWebElement)js.ExecuteScript(script, shadowHostSelector, shadowProgressSelector);
            string shadowProgressBar = shadowProgress.GetAttribute("style");

            return shadowProgressBar;
        }
    }
}
