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
        private IWebElement VerifyAccountLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Verify Your Account']"));
        private IWebElement TagsInputBoxLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Tags Input Box']"));
        private IWebElement MultiLevelDropdownLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Multi Level Dropdown']"));
        private IWebElement SortableListLink => _driver.FindElement(By.XPath("//h3[normalize-space()='Sortable List']"));
        private IWebElement NewTabLink => _driver.FindElement(By.XPath("//h3[normalize-space()='New Tab Link']"));
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
        public DynamicTablePage ClickMultiLevelDropdownLink()
        {
            MultiLevelDropdownLink.Click();
            return new DynamicTablePage(_driver);
        }

        public DynamicTablePage ClickSortableListLink()
        {
            SortableListLink.Click();
            return new DynamicTablePage(_driver);
        }

        public DynamicTablePage ClickNewTabLink()
        {
            NewTabLink.Click();
            return new DynamicTablePage(_driver);
        }

        public DynamicTablePage ClickPopupWindowLink()
        {
            PopupWindowLink.Click();
            return new DynamicTablePage(_driver);
        }

        public DynamicTablePage ClickNestedIFrameLink()
        {
            NestedIFrameLink.Click();
            return new DynamicTablePage(_driver);
        }

        public DynamicTablePage ClickShadowDOMLink()
        {
            ShadowDOMLink.Click();
            return new DynamicTablePage(_driver);
        }

        public DynamicTablePage ClickStarsRatingWidgetLink()
        {
            StarsRatingWidget.Click();
            return new DynamicTablePage(_driver);
        }

        public DynamicTablePage ClickCoveredElementsLink()
        {
            CoveredElementsLink.Click();
            return new DynamicTablePage(_driver);
        }

        public DynamicTablePage ClickUploadFileLink()
        {
            UploadFileLink.Click();
            return new DynamicTablePage(_driver);
        }

        public DynamicTablePage ClickDownloadFileLink()
        {
            DownloadFileLink.Click();
            return new DynamicTablePage(_driver);
        }

        public DynamicTablePage ClickOnboardingModalPopup()
        {
            OnboardingModalPopupLink.Click();
            return new DynamicTablePage(_driver);
        }
        public DynamicTablePage ClickBudgetTrackerLink()
        {
            BudgetTrackerLink.Click();
            return new DynamicTablePage(_driver);
        }
        public DynamicTablePage ClickRightClickContextMenuLink()
        {
            RightClickContextMenuLink.Click();
            return new DynamicTablePage(_driver);
        }
        public DynamicTablePage ClickMouseHoverLink()
        {
            MouseHoverLink.Click();
            return new DynamicTablePage(_driver);
        }
        public DynamicTablePage ClickGeolocationLink()
        {
            GeolocationLink.Click();
            return new DynamicTablePage(_driver);
        }
        public DynamicTablePage ClickNavigationMenuLink()
        {
            NavigationMenuLink.Click();
            return new DynamicTablePage(_driver);
        }
        public DynamicTablePage ClickRedirectChainLink()
        {
            RedirectChainLink.Click();
            return new DynamicTablePage(_driver);
        }
        public DynamicTablePage ClickFetchingData()
        {
            FetchingDataLink.Click();
            return new DynamicTablePage(_driver);
        }
        public DynamicTablePage ClickQRCodeGeneratorLink()
        {
            QRCodeGeneratorLink.Click();
            return new DynamicTablePage(_driver);
        }
        public DynamicTablePage ClickChangeableIframeLink()
        {
            ChangeableIframeLink.Click();
            return new DynamicTablePage(_driver);
        }
        public DynamicTablePage ClickRatingRangeSlider()
        {
            RatingRangeSlider.Click();
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
