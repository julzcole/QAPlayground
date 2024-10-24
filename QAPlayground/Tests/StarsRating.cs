using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    [Collection("SequentialTests")]
    public class StarsRating : BaseTest
    {
        public StarsRating(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Clicks stars on page and validates the text and rating counts are displayed.
        /// </summary>
        [Fact]
        public void StarsRatingTest()
        {
            extentTest = extent.CreateTest(this.GetType().Name);

            try
            {
                string[] ratingPhrases = { "I just hate it", "I don't like it", "This is awesome", "I just like it", "I just love it" };
                var starsRatingPage = basePage.ClickStarsRatingWidgetLink();
                int labelCount = starsRatingPage.GetLabelCount();
                for (int i = 0; i < labelCount; i++)
                {
                    Dictionary<string, string> ratingAndNumberText = starsRatingPage.ValidateRatingCounts(i);
                    Assert.Equal(ratingPhrases[i], ratingAndNumberText["rating text"]);
                    Assert.Equal($"{i + 1} out of 5", ratingAndNumberText["number text"]);
                    Assert.True(starsRatingPage.GetImageElement(i).Displayed);
                }

                string screenshotPath = CaptureScreenshot(_driver, "StarsRating_Pass");
                extentTest.Pass("The Stars Rating test has passed!").AddScreenCaptureFromPath(screenshotPath);
            }
            catch (Exception ex)
            {
                string screenshotPath = CaptureScreenshot(_driver, "StarsRating_Fail");
                extentTest.Fail(ex).AddScreenCaptureFromPath(screenshotPath);
                throw;
            }
        }
    }
}
