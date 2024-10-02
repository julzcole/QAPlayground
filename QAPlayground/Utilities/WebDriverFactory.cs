using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.DriverFactory
{
    public class WebDriverFactory
    {
        public IWebDriver CreateDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("headless"); // Optional, for headless mode
                    return new ChromeDriver(chromeOptions);

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    return new FirefoxDriver(firefoxOptions);

                case "edge":
                    return new EdgeDriver();

                default:
                    throw new ArgumentException($"Browser {browser} is not supported");
            }
        }
    }
}
