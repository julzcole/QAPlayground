﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class BudgetTracker : BaseTest
    {
        [Fact]
        public void BudgetTrackerTest()
        {
            string totalFieldText;
            var budgetTrackerPage = basePage.ClickBudgetTrackerLink();
            totalFieldText = budgetTrackerPage.EnterBudgetData();
            Assert.Equal("$30.00", totalFieldText);
            totalFieldText = budgetTrackerPage.RemoveTableRow(3);
            Assert.Equal("$20.00", totalFieldText);
            totalFieldText = budgetTrackerPage.ModifyTableRow(2,20);
            Assert.Equal("$30.00", totalFieldText);
        }
    }
}
