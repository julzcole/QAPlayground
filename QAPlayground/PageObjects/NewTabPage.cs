using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class NewTabPage : BasePage
    {
        IWebDriver _driver;

        public NewTabPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement OpenTabButton => _driver.FindElement(By.Id("open"));
        private IWebElement NewTabTitleElement => _driver.FindElement(By.XPath("//div[@id='wrapper']/h1"));

        public string ValidateNewTabOpened()
        {
            string existingWindowHandle = _driver.CurrentWindowHandle;
            OpenTabButton.Click();
            IList<string> windowHandles = _driver.WindowHandles;
            

            foreach(string handle in windowHandles)
            {
                if (handle != existingWindowHandle)
                {
                    _driver.SwitchTo().Window(handle);
                    break;
                }
            }

            return NewTabTitleElement.Text;
        }
    }
}
