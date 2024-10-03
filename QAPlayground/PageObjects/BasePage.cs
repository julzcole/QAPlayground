using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QAPlayground.TestingData;
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
        protected WebDriverWait wait;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        //Page Elements 
        private IWebElement DynamicTableLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Dynamic Table']"));
        private IWebElement VerifyAccountLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Verify Your Account']"));
        private IWebElement TagsInputBoxLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Tags Input Box']"));
        private IWebElement MultiLevelDropdownLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Multi Level Dropdown']"));
        private IWebElement SortableListLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Sortable List']"));
        private IWebElement NewTabLink => _driver.FindElement(By.XPath("//h3[normalize-space()='New Tab']"));
        private IWebElement PopupWindowLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Pop-Up Window']"));
        private IWebElement NestedIFrameLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Nested Iframe']"));
        private IWebElement ShadowDOMLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Shadow DOM']"));
        private IWebElement StarsRatingWidget => _driver.FindElement(By.XPath("//h3[normalize-space()='Stars Rating Widget']"));
        private IWebElement CoveredElementsLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Covered Elements']"));
        private IWebElement UploadFileLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Upload File']"));
        private IWebElement DownloadFileLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Download File']"));
        private IWebElement OnboardingModalPopupLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Onboarding Modal Popup']"));
        private IWebElement BudgetTrackerLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Budget Tracker']"));
        private IWebElement RightClickContextMenuLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Right-Click Context Menu']"));
        private IWebElement MouseHoverLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Mouse Hover']"));
        private IWebElement GeolocationLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Geolocation']"));
        private IWebElement NavigationMenuLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Navigation Menu']"));
        private IWebElement RedirectChainLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Redirect Chain']"));
        private IWebElement FetchingDataLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Mouse Hover']"));
        private IWebElement QRCodeGeneratorLink => _driver.FindElement(By.XPath("//h3[normalize-space()='QR Code Generator']"));
        private IWebElement ChangeableIframeLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Changable Iframe']"));
        private IWebElement RatingRangeSlider => _driver.FindElement(By.XPath("//h3[normalize-space()='Rating Range Slider']"));

        //Page Actions
        public DynamicTablePage ClickDynamicTableLink()
        {
            DynamicTableLink.Click();
            return new DynamicTablePage(_driver);
        }

        public VerifyAccountPage ClickVerifyAccountLink()
        {
            VerifyAccountLink.Click();
            return new VerifyAccountPage(_driver);
        }

        public TagsInputBoxPage ClickTagsInputBoxLink()
        {
            TagsInputBoxLink.Click();
            return new TagsInputBoxPage(_driver);
        }
        public MultiLevelDropdownPage ClickMultiLevelDropdownLink()
        {
            MultiLevelDropdownLink.Click();
            return new MultiLevelDropdownPage(_driver);
        }

        public DynamicTablePage ClickSortableListLink()
        {
            SortableListLink.Click();
            return new DynamicTablePage(_driver);
        }

        public NewTabPage ClickNewTabLink()
        {
            NewTabLink.Click();
            return new NewTabPage(_driver);
        }

        public PopupWindowPage ClickPopupWindowLink()
        {
            PopupWindowLink.Click();
            return new PopupWindowPage(_driver);
        }

        public NestedIFramesPage ClickNestedIFrameLink()
        {
            NestedIFrameLink.Click();
            return new NestedIFramesPage(_driver);
        }

        public ShadowDomPage ClickShadowDOMLink()
        {
            ShadowDOMLink.Click();
            return new ShadowDomPage(_driver);
        }

        public StarsRatingPage ClickStarsRatingWidgetLink()
        {
            StarsRatingWidget.Click();
            return new StarsRatingPage(_driver);
        }

        public HiddenButtonPage ClickHiddenButtonLink()
        {
            CoveredElementsLink.Click();
            return new HiddenButtonPage(_driver);
        }

        public FileUploadPage ClickUploadFileLink()
        {
            UploadFileLink.Click();
            return new FileUploadPage(_driver);
        }

        public DownloadPage ClickDownloadFileLink()
        {
            DownloadFileLink.Click();
            return new DownloadPage(_driver);
        }

        public OnboardingModalPopupPage ClickOnboardingModalPopup()
        {
            OnboardingModalPopupLink.Click();
            return new OnboardingModalPopupPage(_driver);
        }
        public BudgetTrackerPage ClickBudgetTrackerLink()
        {
            BudgetTrackerLink.Click();
            return new BudgetTrackerPage(_driver);
        }
        public RightClickContextMenuPage ClickRightClickContextMenuLink()
        {
            RightClickContextMenuLink.Click();
            return new RightClickContextMenuPage(_driver);
        }
        public MouseHover ClickMouseHoverLink()
        {
            MouseHoverLink.Click();
            return new MouseHover(_driver);
        }
        public GeolocationPage ClickGeolocationLink()
        {
            GeolocationLink.Click();
            return new GeolocationPage(_driver);
        }
        public NavigationMenuPage ClickNavigationMenuLink()
        {
            NavigationMenuLink.Click();
            return new NavigationMenuPage(_driver);
        }
        public RedirectChainPage ClickRedirectChainLink()
        {
            RedirectChainLink.Click();
            return new RedirectChainPage(_driver);
        }
        public QRCodeGeneratorPage ClickQRCodeGeneratorLink()
        {
            QRCodeGeneratorLink.Click();
            return new QRCodeGeneratorPage(_driver);
        }
    }
}
