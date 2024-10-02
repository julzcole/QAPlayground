using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class MouseOver : BaseTest
    {
        public MouseOver(WebDriverFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void MouseOverTest()
        {
            var mouseOverPage = basePage.ClickMouseHoverLink();
            var priceElement = mouseOverPage.ValidateMouseOver();
            Assert.True(priceElement.Displayed);
            Assert.Equal("$24.96", priceElement.Text);
        }
    }
}
