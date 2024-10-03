using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QAPlayground.PageObjects
{
    public class RightClickContextMenuPage : BasePage
    {
        private IWebDriver _driver;

        public RightClickContextMenuPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement MenuItemShareButton => _driver.FindElement(By.CssSelector("li[class='menu-item share']"));
        private IWebElement message => _driver.FindElement(By.Id("msg"));

        public List<string> RightClickContextMenu(string[] menuItems, string[] shareOptions)
        {
            Actions action = new Actions(_driver);
            List<string> actualMessageOptionText = new List<string>();

            // Get the viewport dimensions using JavaScript
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            int viewportWidth = Convert.ToInt32(js.ExecuteScript("return window.innerWidth;"));
            int viewportHeight = Convert.ToInt32(js.ExecuteScript("return window.innerHeight;"));

            // Generate random coordinates within the viewport
            Random random = new Random();
            int randomX = random.Next(0, viewportWidth);
            int randomY = random.Next(0, viewportHeight);

            string script = @"
                var element = document.elementFromPoint(arguments[0], arguments[1]);
                if (element) {
                    var evt = new MouseEvent('contextmenu', {
                        bubbles: true,
                        cancelable: true,
                        view: window,
                        clientX: arguments[0],
                        clientY: arguments[1],
                        button: 2
                    });
                    element.dispatchEvent(evt);
                }
            ";

            for (int i = 0; i < menuItems.Length; i++)
            {
                js.ExecuteScript(script, randomX, randomY);
                action.ScrollToElement(_driver.FindElement(By.CssSelector($"li[onclick=\"itemClicked('{menuItems[i]}')\"]"))).Build().Perform();
                js.ExecuteScript("arguments[0].click();", _driver.FindElement(By.CssSelector($"li[onclick=\"itemClicked('{menuItems[i]}')\"]")));
                actualMessageOptionText.Add(message.Text);
            }

            for (int i = 0; i < shareOptions.Length; i++)
            {
                js.ExecuteScript(script, randomX, randomY);
                action.ScrollToElement(_driver.FindElement(By.CssSelector("li[class='menu-item share']"))).Build().Perform();
                action.MoveToElement(_driver.FindElement(By.CssSelector("li[class='menu-item share']"))).Build().Perform();
                js.ExecuteScript("arguments[0].click();", _driver.FindElement(By.CssSelector($"li[onclick=\"itemClicked('{shareOptions[i]}')\"]")));
                actualMessageOptionText.Add(message.Text);
            }

            return actualMessageOptionText;
        }
    }
}
