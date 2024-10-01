using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class NestedIFrames : BaseTest
    {
        [Fact]
        public void NestedIFramesTest()
        {
            var nestedIFramesPage = basePage.ClickNestedIFrameLink();
            string messageText = nestedIFramesPage.FindIFrameButton();
            Assert.Equal("Button Clicked", messageText);
        }
    }
}
