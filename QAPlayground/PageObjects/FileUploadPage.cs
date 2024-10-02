using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class FileUploadPage : BasePage
    {
        private IWebDriver _driver;

        public FileUploadPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement FileInputField => _driver.FindElement(By.Id("file-input"));
        private IWebElement Caption => _driver.FindElement(By.TagName("figcaption"));

        public void UploadFile()
        {
            string relativePath = @"../../../TestingData/Images/tired.jpg";
            FileInputField.SendKeys(Path.GetFullPath(relativePath));
        }

        public string ValidateCaption()
        {
            return Caption.Text;
        }
    }
}
