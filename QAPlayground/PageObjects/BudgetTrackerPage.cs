using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class BudgetTrackerPage : BasePage
    {
        private IWebDriver _driver;

        public BudgetTrackerPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement NewEntryButton => _driver.FindElement(By.XPath("//button[normalize-space()='New Entry']"));
        private IWebElement TotalField => _driver.FindElement(By.XPath("//span[@class='total']"));

        public string EnterBudgetData()
        {
            for (int i = 1; i <= 3; i++)
            {
                NewEntryButton.Click();
                _driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[1]/input")).SendKeys("07/24/2024");
                _driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[2]/input")).SendKeys("Budgeting");
                _driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[4]/input")).Clear();
                _driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[4]/input")).SendKeys("10");
                _driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[4]/input")).SendKeys(Keys.Enter);
            }

            return TotalField.Text;
        }

        public string RemoveTableRow(int index)
        {
            _driver.FindElement(By.XPath($"//tbody[1]/tr[{index}]/td[5]/button")).Click();
            return TotalField.Text;
        }

        public string ModifyTableRow(int index, int amount)
        {
            _driver.FindElement(By.XPath($"//tbody[1]/tr[2]/td[4]/input")).Clear();
            _driver.FindElement(By.XPath($"//tbody[1]/tr[2]/td[4]/input")).SendKeys(amount.ToString());
            _driver.FindElement(By.XPath($"//tbody[1]/tr[2]/td[4]/input")).SendKeys(Keys.Enter);
            return TotalField.Text;
        }
    }
}
