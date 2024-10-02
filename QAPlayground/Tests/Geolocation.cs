using OpenQA.Selenium;
using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class Geolocation : BaseTest
    {
        public Geolocation(WebDriverFixture fixture) : base(fixture)
        {
        }

        //Seems like the geolocation on the site is broken, can't even get the geolocation manually.
        //[Fact]
        public void GeolocationTest()
        {
            //This test is failing due to the site not working properly at this time - Geolocation returns Undefined
            var geolocationPage = basePage.ClickGeolocationLink();
            string locationInfo = geolocationPage.ValidateGeolocation();
            Assert.Contains("Cupertino", locationInfo);
        }
    }
}
