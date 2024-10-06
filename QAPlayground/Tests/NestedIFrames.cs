using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
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
            var nestedIFramesPage = basePage.ClickNestedIFrameLink();
            string messageText = nestedIFramesPage.FindIFrameButton();
            Assert.Equal("Button Clicked", messageText);
        }
    }
}
