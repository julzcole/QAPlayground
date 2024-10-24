using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    [Collection("SequentialTests")]
    public class MouseOver : BaseTest
    {
        public MouseOver(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Mouse over the price element and ensure that the price is 24.96
        /// </summary>
        [Fact]
        public void MouseOverTest()
        {
            extentTest = extent.CreateTest(this.GetType().Name);

            try
            {
                var mouseOverPage = basePage.ClickMouseHoverLink();
                var priceElement = mouseOverPage.ValidateMouseOver();
                Assert.True(priceElement.Displayed);
                Assert.Equal("$24.96", priceElement.Text);
                extentTest.Pass("The Mouse Over test has passed!");
            }
            catch (Exception ex)
            {
                extentTest.Fail(ex);
                throw;
            }
        }
    }
}
