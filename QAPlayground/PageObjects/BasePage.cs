using OpenQA.Selenium;
using QAPlayground.TestingData;
using QAPlayground.WrapperFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class BasePage
    {
        private readonly IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        //Page Elements 
        private IWebElement DynamicTableLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Dynamic Table']"));
        //Page Actions
        public DynamicTablePage ClickDynamicTableLink()
        {
            DynamicTableLink.Click();
            return new DynamicTablePage(_driver);
        }
/*        public IWebElement GetPuzzleLink(string puzzleName)
        {
            string xpath = $"//h3[normalize-space()='{puzzleName}']";
            return _driver.FindElement(By.XPath(xpath));
        }
*/
/*        public void ClickPuzzleLink(string puzzleName)
        {
            GetPuzzleLink(puzzleName).Click();
            
        }*/
    }
}
