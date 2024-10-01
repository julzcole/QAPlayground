using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using static System.Net.Mime.MediaTypeNames;
using Xunit.Abstractions;
using System.Collections.ObjectModel;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;
using QAPlayground.WrapperFactory;

namespace QAPlayground
{
    public class TestsOld
    {
        private readonly ITestOutputHelper _output;
        private IWebDriver _driver;
        private WebDriverWait wait;
        public TestsOld(ITestOutputHelper output)
        {
            _output = output;
            WebDriverFactory.InitBrowser("Chrome");
            _driver = WebDriverFactory.Driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));


        }

        [Fact]
        public void DynamicTable()
        {
            //Find the Spider-Man in a table that changes the order of rows and assert his real name
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/dynamic-table/");
            driver.FindElement(By.XPath("//h3[normalize-space()='Dynamic Table']")).Click();
            var spiderManTableRow = driver.FindElement(By.XPath("//div[normalize-space()='Spider-Man']/ancestor::tr"));
            var spiderManName = spiderManTableRow.FindElement(By.XPath("td[normalize-space()='Peter Parker']")).Text;
            Assert.Equal("Peter Parker", spiderManName);
            driver.Quit();
        }

        [Fact]
        public void VerifyAccount()
        {
            /*Enter valid code by pressing the key-up button or 
             typing number and assert success message*/

            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/verify-account/");
            var numInputs = driver.FindElements(By.XPath("//input"));
            foreach(var input in numInputs )
            {
                input.SendKeys("9");
            }

            Assert.True(driver.FindElement(By.XPath("//small[@class='info success']")).Displayed);
        }

        [Fact]
        public void TagsInputBox()
        {
            //Add and remove tags and assert tag's presence and count
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/tags-input-box/");
            string[] tags = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
            var tagIcons = driver.FindElements(By.XPath("//li/i"));
            var textBox = driver.FindElement(By.XPath("//input[@type='text']"));

            foreach ( var icon in tagIcons )
            {
                icon.Click();
            }

            Assert.Equal("10", driver.FindElement(By.XPath("//div[@class='details']/p/span")).Text);

            foreach(var tag in tags)
            {
                textBox.SendKeys(tag);
                textBox.SendKeys(Keys.Enter);
            }

            Assert.Equal("0", driver.FindElement(By.XPath("//div[@class='details']/p/span")).Text);
        }

        [Fact]
        public void MultiLevelDropdown()
        {
            //Navigate into the sub-menus and assert menu items text and links
            string baseUrl = "https://qaplayground.dev/apps/multi-level-dropdown/";
            string[] expectedMenuItemText = { "My Tutorial", "HTML", "CSS", "JavaScript", "Awesome!" };
            string[] expectedMenuItemLinks = { "#main", "#!HTML", "#!CSS", "#!JavaScript", "#!Awesome" };
            string[] expectedAnimalText = { "Animals", "Kangaroo", "Frog", "Horse", "Hedgehog" };
            string[] expectedAnimalLinks = { "#main", "#!Kangaroo", "#!Frog", "#!Horse", "#!Hedgehog" };
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));  
            driver.Navigate().GoToUrl(baseUrl);
            driver.FindElement(By.XPath("//li[4]/a")).Click();
            driver.FindElement(By.XPath("//a[@href='#settings']")).Click();
            ReadOnlyCollection<IWebElement> menuItems = driver.FindElements(By.XPath("//div[@class='menu menu-secondary-enter-done']/a"));

            for(int i = 0; i < menuItems.Count; i++)
            {
                Assert.Equal(expectedMenuItemText[i], menuItems[i].Text);
                Assert.Equal(baseUrl + expectedMenuItemLinks[i], menuItems[i].GetAttribute("href").ToString());
            }

            driver.FindElement(By.XPath("//div[@class='menu menu-secondary-enter-done']/a/h2")).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='#animals']")));
            driver.FindElement(By.XPath("//a[@href='#animals']")).Click();
            //Thread.Sleep(2);
            ReadOnlyCollection<IWebElement> animalMenuItems = driver.FindElements(By.XPath("//div[@class='menu menu-secondary-enter-done']/a"));

            for (int i = 0; i < animalMenuItems.Count; i++)
            {
                Assert.Contains(expectedAnimalText[i], animalMenuItems[i].Text);
                Assert.Equal(baseUrl + expectedAnimalLinks[i], animalMenuItems[i].GetAttribute("href").ToString());
            }
        }

        [Fact]
        public void SortableList()
        {
            //Drag and drop list items to make the correct order and then click on the button and
            //assert that all have green text


        }

        [Fact]
        public void NewTab()
        {
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/new-tab/");
            string existingWindowHandle = driver.CurrentWindowHandle;
            driver.FindElement(By.Id("open")).Click();
            IList<string> windowHandles = driver.WindowHandles;

            foreach(string handle in windowHandles)
            {
                if(handle != existingWindowHandle)
                {
                    driver.SwitchTo().Window(handle);
                    break;
                }
            }

            Assert.Equal("Welcome to the new page!", driver.FindElement(By.XPath("//div[@id='wrapper']/h1")).Text);
            //driver.Quit();
        }

        [Fact]
        public void PopupWindow()
        {
            //Open pop-up and click on the button in it and assert text on the main window
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/popup/");
            string existingWindowHandle = driver.CurrentWindowHandle;
            driver.FindElement(By.Id("login")).Click();
            IList<string> windowHandles = driver.WindowHandles;

            foreach (string handle in windowHandles)
            {
                if (handle != existingWindowHandle)
                {
                    driver.SwitchTo().Window(handle);
                    break;
                }
            }

            driver.FindElement(By.TagName("button")).Click();
            driver.SwitchTo().Window(existingWindowHandle);
            Assert.Equal("Button Clicked", driver.FindElement(By.Id("info")).Text);
        }

        [Fact]
        public void NestedIFrames()
        {
            //Click on the button in the iframe that is in another iframe and assert a success message
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/iframe/");
            driver.SwitchTo().Frame("frame1");
            driver.SwitchTo().Frame("frame2");
            driver.FindElement(By.XPath("//a[@class='btn btn-green-outline']")).Click();
            string msgText = driver.FindElement(By.Id("msg")).Text;
            Assert.Equal("Button Clicked", msgText);
        }

        [Fact]
        public void ShadowDOM()
        {
            //Click on the button and assert that progress is on the 95 percent
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/shadow-dom/");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string shadowHostSelector = "body > main > div > progress-bar";
            string shadowButtonSelector = "div:nth-child(3) > button";
            string shadowProgressSelector = "div.container > div";
            string script = @"
            return document.querySelector(arguments[0])
                .shadowRoot.querySelector(arguments[1]);
        ";
            IWebElement shadowButton = (IWebElement)js.ExecuteScript(script, shadowHostSelector, shadowButtonSelector);
            shadowButton.Click();

            IWebElement shadowProgress = (IWebElement)js.ExecuteScript(script, shadowHostSelector, shadowProgressSelector);
            string shadowProgressBar = shadowProgress.GetAttribute("style");
            Assert.Contains("95", shadowProgressBar);
        }

        [Fact]
        public void StarsRating()
        {
            //WebDriver Setup
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/rating/");

            //Set up a for loop to loop through the ratings and assert on text, rating number, and image
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            int labelCount = driver.FindElements(By.TagName("label")).Count;
            string[] ratingPhrases = { "I just hate it", "I don't like it", "This is awesome", "I just like it", "I just love it" };

            for (int i = 0; i < labelCount; i++)
            {
                driver.FindElement(By.XPath($"//label[@for='star-{i + 1}']")).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                IWebElement imageElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"img[src='emojis/emoji-{i + 1}.png']")));
                IWebElement ratingTextField = driver.FindElement(By.XPath("//span[@class='text']"));
                IWebElement numberTextField = driver.FindElement(By.XPath("//span[@class='numb']"));
                string ratingText = (string)js.ExecuteScript("return window.getComputedStyle(arguments[0], '::before').getPropertyValue('content').replace(/^\"|\"$/g, '');", ratingTextField);
                string numberText = (string)js.ExecuteScript("return window.getComputedStyle(arguments[0], '::before').getPropertyValue('content').replace(/^\"|\"$/g, '');", numberTextField);
                Assert.Equal(ratingPhrases[i], ratingText);
                Assert.Equal($"{i + 1} out of 5", numberText);
                Assert.True(imageElement.Displayed);
            }

            driver.Quit();
        }

        [Fact]
        public void HiddenButton()
        {
            //WebDriver Setup
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/covered/");

            //Find the hidden button, click it, then assert on its text
            IWebElement fugitiveButton = driver.FindElement(By.Id("fugitive"));
            fugitiveButton.Click();
            Assert.Contains("Mission accomplished", driver.FindElement(By.Id("info")).Text);

            driver.Quit();
        }

        [Fact]
        public void FileUpload()
        {
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/upload/");
            //Send the input field the path to the image file
            driver.FindElement(By.Id("file-input")).SendKeys(@"C:\Users\xXJul\Pictures\tired.jpg");
            Assert.Equal("tired.jpg", driver.FindElement(By.TagName("figcaption")).Text);

            driver.Quit();
        }

        [Fact]
        public void Download()
        {
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/download/");

            driver.FindElement(By.Id("file")).Click();
            string filePath = @"C:\Users\xXJul\Downloads\sample.pdf";
            Thread.Sleep(2000);
            Assert.True(File.Exists(filePath));

            driver.Quit();
        }

        [Fact]
        public void OnboardingModalPopup()
        {
            //Close the modal popup if displayed and assert the message
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/onboarding-modal/");

            IWebElement modalButton = driver.FindElement(By.CssSelector("label[for='active']"));
            string backgroundColor = modalButton.GetCssValue("background");
            if (backgroundColor.Contains("rgb(255, 255, 255)"))
            {
                driver.FindElement(By.CssSelector("label[for='active']")).Click();
                Assert.Contains("Welcome Peter Parker!", driver.FindElement(By.XPath("//div[@class='title']")).Text);
            }
            else
            {
                Assert.Contains("Application successfully launched!", driver.FindElement(By.XPath("//div[@class='title']")).Text);
            }

            driver.Quit();
        }

        [Fact]
        public void BudgetTracker()
        {
            /* Add, modify and remove income and expense records
             * and assert their appearance,persistance, and the total amount */

            //WebDriver/Test Setup
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/budget-tracker/");
            IWebElement newEntryButton = driver.FindElement(By.XPath("//button[normalize-space()='New Entry']"));
            IWebElement totalField = driver.FindElement(By.XPath("//span[@class='total']"));

            //Start by adding 3 budget entries and assert the values of all 3 and assert total
            for (int i = 1; i <= 3; i++)
            {
                newEntryButton.Click();
                driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[1]/input")).SendKeys("07/24/2024");
                driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[2]/input")).SendKeys("Budgeting");
                driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[4]/input")).Clear();
                driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[4]/input")).SendKeys("10");
                driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[4]/input")).SendKeys(Keys.Enter);
            }

            Assert.Equal("$30.00", totalField.Text);

            //Remove one and assert count of table rows and total
            driver.FindElement(By.XPath("//tbody[1]/tr[3]/td[5]/button")).Click();
            Assert.Equal("$20.00", totalField.Text);

            //modify one row and assert modified values then assert total
            driver.FindElement(By.XPath("//tbody[1]/tr[2]/td[4]/input")).Clear();
            driver.FindElement(By.XPath("//tbody[1]/tr[2]/td[4]/input")).SendKeys("20");
            driver.FindElement(By.XPath($"//tbody[1]/tr[2]/td[4]/input")).SendKeys(Keys.Enter);
            Assert.Equal("$30.00", totalField.Text);

            driver.Quit();
        }

        [Fact]
        public void RightClickContextMenu()
        {
            //Click on each menu and sub-menu item and assert the message
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/context-menu/");

            //Test Setup
            IWebElement message = driver.FindElement(By.Id("msg"));
            string[] menuItems = { "Settings", "Delete", "Rename", "Get Link", "Preview" };
            string[] shareOptions = { "Twitter", "Instagram", "Dribble", "Telegram" };
            string[] messageOptions = { "Menu item Settings clicked", "Menu item Delete clicked", "Menu item Rename clicked", "Menu item Get Link clicked", "Menu item Preview clicked" };
            string[] shareMessageOptions = { "Menu item Twitter clicked", "Menu item Instagram clicked", "Menu item Dribble clicked", "Menu item Telegram clicked"};
            Actions action = new Actions(driver);

            // Get the viewport dimensions using JavaScript
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
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
                action.ScrollToElement(driver.FindElement(By.CssSelector($"li[onclick=\"itemClicked('{menuItems[i]}')\"]"))).Build().Perform();
                driver.FindElement(By.CssSelector($"li[onclick=\"itemClicked('{menuItems[i]}')\"]")).Click();
                Assert.Equal(messageOptions[i], message.Text);
            }

            for(int i = 0; i < shareOptions.Length; i++)
            {
                js.ExecuteScript(script, randomX, randomY);
                action.ScrollToElement(driver.FindElement(By.CssSelector("li[class='menu-item share']"))).Build().Perform();
                action.MoveToElement(driver.FindElement(By.CssSelector("li[class='menu-item share']"))).Build().Perform();
                driver.FindElement(By.CssSelector($"li[onclick=\"itemClicked('{shareOptions[i]}')\"]")).Click();
                Assert.Equal(shareMessageOptions[i], message.Text);
            }

            driver.Quit();
        }

        [Fact]
        public void MouseHover()
        {
            //put mouse pointer on an image and assert movie price

            //use the actions class to navigate to element and hover then assert the price
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/mouse-hover/");

            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.ClassName("poster"))).Build().Perform();
            Assert.True(driver.FindElement(By.ClassName("current-price")).Displayed);
            Assert.Equal("$24.96", driver.FindElement(By.ClassName("current-price")).Text);

            driver.Quit();
        }

        [Fact]
        public void Geolocation()
        {
            //Set browser geolocation to longitude: -122.03118 and latitude:37.33182 and assert Cupertino

            //Initialize Driver and set ChromeOptions to disable geolocation
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--disable-geolocation");
            var driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/geolocation/");

            //Create variables for longitude and latitude
            double latitude = 37.33182;
            double longitude = -122.03118;

            //Create javascript for setting the geolocation in chrome browser
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            string script = $@"
            navigator.geolocation.getCurrentPosition = function(success) {{
                var position = {{
                    'coords': {{
                        'latitude': {latitude},
                        'longitude': {longitude}
                    }}
                }};
                success(position);
            }};
        ";
            //Click Geolocation button and assert that the location is Cupertino
            driver.FindElement(By.Id("get-location")).Click();
            Assert.Contains("Cupertino", driver.FindElement(By.Id("location-info")).Text);
        }

        [Fact]
        public void NavigationMenu()
        {
            //Task: Click each navigation link and assert the pages content (title)

            //Set up driver
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/links/");

            //Create lists of links and lists of the correct content and loop through the lists and assert content
            string[] links = { "About", "Blog", "Portfolio", "Contact" };
            string[] content = {"Welcome to the About Page", "Welcome to the Blog Page",
                "Welcome to the Portfolio Page", "Welcome to the Contact Page"};

            for(int i = 0; i < links.Length; i++)
            {
                driver.FindElement(By.XPath($"//a[normalize-space()='{links[i]}']")).Click();
                Assert.Equal(content[i], driver.FindElement(By.Id("title")).Text);
                driver.FindElement(By.XPath($"//a[normalize-space()='Go Back']")).Click();
            }
        }

        [Fact]
        public void RedirectChain()
        {
            //I think this kind of test is either way too difficult with Selenium or not possible and the example is in Playwright which has asynchronous operations for this type of test
            //Click on the button and assert each redirected page

            //Set up webdriver and get current URL 
            var driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://qaplayground.dev/apps/redirect/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            //Create a list of strings representing the info on each page and assert the title whenever the page loads
            string[] pageTitles = {"Welcome to Second Page", "Welcome to Third Page" , "Welcome to Fourth Page" , 
                "Welcome to Fifth Page" , "Welcome to Sixth Page" , "Welcome to the Last Page" };

            string[] urls = { "redirect", "#", "second", "third", "fourth", "fifth", "sixth", "last" };

            driver.FindElement(By.Id("redirect")).Click();
            //Loop through titles and assert title whenever a new page is loaded
            for (int i = 0; i < pageTitles.Length; i++)
            {
                wait.Until(ExpectedConditions.UrlContains(urls[i]));
                _output.WriteLine($"Hello - This is the {urls[i]} callout");
            }
        }

        [Fact]
        public void QRCodeGenerator()
        {
            _driver.Navigate().GoToUrl("https://qaplayground.dev/apps/qr-code-generator/");
            

            _driver.FindElement(By.XPath("//input[@placeholder='Enter text or URL']")).SendKeys("One Piece");
            _driver.FindElement(By.XPath("//button[normalize-space()='Generate QR Code']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//img[@alt='qr-code']")));
            Assert.True(_driver.FindElement(By.XPath("//img[@alt='qr-code']")).Displayed);

        }
    }

}