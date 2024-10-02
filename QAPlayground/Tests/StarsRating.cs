using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class StarsRating : BaseTest
    {
        public StarsRating(WebDriverFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void StarsRatingTest()
        {
            string[] ratingPhrases = { "I just hate it", "I don't like it", "This is awesome", "I just like it", "I just love it" };
            var starsRatingPage = basePage.ClickStarsRatingWidgetLink();
            int labelCount = starsRatingPage.GetLabelCount();
            for(int i = 0; i < labelCount; i++)
            {
                Dictionary<string,string> ratingAndNumberText = starsRatingPage.ValidateRatingCounts(i);
                Assert.Equal(ratingPhrases[i], ratingAndNumberText["rating text"]);
                Assert.Equal($"{i + 1} out of 5", ratingAndNumberText["number text"]);
                Assert.True(starsRatingPage.GetImageElement(i).Displayed);
            }
        }
    }
}
