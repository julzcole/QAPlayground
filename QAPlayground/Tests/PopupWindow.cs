using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class PopupWindow : BaseTest
    {
        [Fact]
        public void PopupWindowTest()
        {
            var popupWindowPage = basePage.ClickPopupWindowLink();
            string infoText = popupWindowPage.ValidatePopupWindow();
            Assert.Equal("Button Clicked", infoText);
        }
    }
}
