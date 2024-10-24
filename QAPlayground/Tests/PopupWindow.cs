using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    [Collection("SequentialTests")]
    public class PopupWindow : BaseTest
    {
        public PopupWindow(WebDriverFixture fixture) : base(fixture)
        {
        }


        /// <summary>
        /// Validate text on page when popup window is clicked.
        /// </summary>
        [Fact]
        public void PopupWindowTest()
        {
            extentTest = extent.CreateTest(this.GetType().Name);

            try
            {
                var popupWindowPage = basePage.ClickPopupWindowLink();
                string infoText = popupWindowPage.ValidatePopupWindow();
                Assert.Equal("Button Clicked", infoText);
                extentTest.Pass("The Popup Window test has passed!");
            }
            catch (Exception ex)
            {
                extentTest.Fail(ex);
                throw;
            }

        }
    }
}
