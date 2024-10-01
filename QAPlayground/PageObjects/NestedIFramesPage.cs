using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V124.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class NestedIFramesPage : BasePage
    {
        private IWebDriver _driver;
        public NestedIFramesPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement IFrameButton => _driver.FindElement(By.XPath("//a[@class='btn btn-green-outline']"));
        private IWebElement MessageTextElement => _driver.FindElement(By.Id("msg"));

        public string FindIFrameButton()
        {
            _driver.SwitchTo().Frame("frame1");
            _driver.SwitchTo().Frame("frame2");
            IFrameButton.Click();
            return MessageTextElement.Text;
        }
    }
}
