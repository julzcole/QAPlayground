/*using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.WrapperFactory
{
    public class DriverHelper
    {
        IWebDriver _driver;
        public DriverHelper()
        {
            SetUpDriver();
        }

        public void SetUpDriver()
        {
            WebDriverFactory.InitBrowser("Chrome");
            WebDriverFactory.LoadApplication("https://qaplayground.dev");
            _driver = WebDriverFactory.Driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
        }
    }
}
*/