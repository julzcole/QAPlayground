using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class DynamicTablePage :BasePage
    {
        private readonly IWebDriver _driver;
        public DynamicTablePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        //Page Elements
        private IWebElement SpiderManTableRow => _driver.FindElement(By.XPath("//div[normalize-space()='Spider-Man']/ancestor::tr"));
        private IWebElement SpiderManName => SpiderManTableRow.FindElement(By.XPath("td[normalize-space()='Peter Parker']"));

        //Page Actions
        public string FindSpiderMan()
        {
            return SpiderManName.Text;    
        }
    }
}
