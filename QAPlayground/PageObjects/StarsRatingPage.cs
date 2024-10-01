using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class StarsRatingPage : BasePage
    {
        private IWebDriver _driver;
        
        public StarsRatingPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private ReadOnlyCollection<IWebElement> LabelCountElement => _driver.FindElements(By.TagName("label"));

        private IWebElement RatingTextField => _driver.FindElement(By.XPath("//span[@class='text']"));
        private IWebElement NumberTextField => _driver.FindElement(By.XPath("//span[@class='numb']"));


        public Dictionary<string, string> ValidateRatingCounts(int labelCounter)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            _driver.FindElement(By.XPath($"//label[@for='star-{labelCounter + 1}']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"img[src='emojis/emoji-{labelCounter + 1}.png']")));
            Dictionary<string,string> ratingAndNumberText = new Dictionary<string,string>();
            ratingAndNumberText.Add("rating text", (string)js.ExecuteScript("return window.getComputedStyle(arguments[0], '::before').getPropertyValue('content').replace(/^\"|\"$/g, '');", RatingTextField));
            ratingAndNumberText.Add("number text", (string)js.ExecuteScript("return window.getComputedStyle(arguments[0], '::before').getPropertyValue('content').replace(/^\"|\"$/g, '');", NumberTextField));
            return ratingAndNumberText;
        }

        public int GetLabelCount()
        {
            return LabelCountElement.Count;
        }

        public IWebElement GetImageElement(int ratingCounter)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"img[src='emojis/emoji-{ratingCounter + 1}.png']")));
        }
    }
}
