using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    [Collection("SequentialTests")]
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
            extentTest = extent.CreateTest(this.GetType().Name);

            try
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

                string screenshotPath = CaptureScreenshot(_driver, "RightClickContext_Pass");
                extentTest.Pass("The Right Click Context Menu test has passed!").AddScreenCaptureFromPath(screenshotPath);
            }
            catch (Exception ex)
            {
                string screenshotPath = CaptureScreenshot(_driver, "RightClickContext_Fail");
                extentTest.Fail(ex).AddScreenCaptureFromPath(screenshotPath);
                throw;
            }

        }
    }
}
