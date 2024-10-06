using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class RightClickContextMenu : BaseTest
    {
        public RightClickContextMenu(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Click all links on page and validate link text
        /// </summary>
        [Fact]
        public void RightClickContextMenuTest()
        {
            //Arrange
            string[] expectedMessages = { 
                "Menu item Settings clicked",
                "Menu item Delete clicked",
                "Menu item Rename clicked",
                "Menu item Get Link clicked",
                "Menu item Preview clicked",
                "Menu item Twitter clicked",
                "Menu item Instagram clicked",
                "Menu item Dribble clicked",
                "Menu item Telegram clicked"
            };
            string[] menuItems = { "Settings", "Delete", "Rename", "Get Link", "Preview" };
            string[] shareOptions = { "Twitter", "Instagram", "Dribble", "Telegram" };
            var rightClickContextMenuPage = basePage.ClickRightClickContextMenuLink();
            
            //Act
            List<string> actualMessageText = rightClickContextMenuPage.RightClickContextMenu(menuItems, shareOptions);

            //Assert
            for (int i = 0; i < expectedMessages.Length; i++)
            {
                Assert.Equal(expectedMessages[i], actualMessageText[i]);
            }

        }
    }
}
