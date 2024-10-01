using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class MouseHover : BasePage
    {
        private IWebDriver _driver;

        public MouseHover(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement PosterElement => _driver.FindElement(By.ClassName("poster"));
        private IWebElement PriceElement => _driver.FindElement(By.ClassName("current-price"));

        public IWebElement ValidateMouseOver()
        {
            Actions a = new Actions(_driver);
            a.MoveToElement(PosterElement).Build().Perform();
            return PriceElement;
        }
    }
}
