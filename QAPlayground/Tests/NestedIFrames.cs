using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    [Collection("SequentialTests")]
    public class NestedIFrames : BaseTest
    {
        public NestedIFrames(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Validate that the iFrame message displays on button click.
        /// </summary>
        [Fact]
        public void NestedIFramesTest()
        {
            extentTest = extent.CreateTest(this.GetType().Name);

            try
            {
                var nestedIFramesPage = basePage.ClickNestedIFrameLink();
                string messageText = nestedIFramesPage.FindIFrameButton();
                Assert.Equal("Button Clicked", messageText);
                extentTest.Pass("The Nested Iframes test has passed!");
            }
            catch (Exception ex)
            {
                extentTest.Fail(ex);
                throw;
            }
        }
    }
}
