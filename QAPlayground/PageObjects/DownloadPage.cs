using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class DownloadPage : BasePage
    {
        private IWebDriver _driver;

        public DownloadPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement FileInputField => _driver.FindElement(By.Id("file"));

        public void DownloadFile()
        {
            FileInputField.Click();
        }
    }
}
