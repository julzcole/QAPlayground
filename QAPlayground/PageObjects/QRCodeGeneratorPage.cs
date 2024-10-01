using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class QRCodeGeneratorPage : BasePage
    {
        private IWebDriver _driver;

        public QRCodeGeneratorPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement TextInputElement => _driver.FindElement(By.XPath("//input[@placeholder='Enter text or URL']"));
        private IWebElement QRCodeButton => _driver.FindElement(By.XPath("//button[normalize-space()='Generate QR Code']"));
        private IWebElement QRCodeElement => _driver.FindElement(By.XPath("//img[@alt='qr-code']"));
        private static By QRCodeElementBy => By.XPath("//img[@alt='qr-code']");

        public bool ValidateQRCode()
        {
            TextInputElement.SendKeys("One Piece");
            QRCodeButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(QRCodeElementBy));
            return QRCodeElement.Displayed;
        }

    }
}
