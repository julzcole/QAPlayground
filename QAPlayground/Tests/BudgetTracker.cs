using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class BudgetTracker : BaseTest
    {
        public BudgetTracker(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Tests that the total matches what is entered in the budget table rows summed.
        /// </summary>
        [Fact]
        public void BudgetTrackerTest()
        {
            //Create a test entry for the extent report
            extentTest = extent.CreateTest(this.GetType().Name);

            //Test Actions
            try
            {
                string totalFieldText;
                var budgetTrackerPage = basePage.ClickBudgetTrackerLink();
                totalFieldText = budgetTrackerPage.EnterBudgetData();
                Assert.Equal("$30.00", totalFieldText);
                totalFieldText = budgetTrackerPage.RemoveTableRow(3);
                Assert.Equal("$20.00", totalFieldText);
                totalFieldText = budgetTrackerPage.ModifyTableRow(2, 20);
                Assert.Equal("$30.00", totalFieldText);
                extentTest.Pass("Budget Tracker test has passed!");
            }
            catch (Exception ex)
            {
                extentTest.Fail(ex);
                throw;
            }

        }
    }
}
