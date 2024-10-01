using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class Geolocation : BaseTest
    {
        [Fact]
        public void GeolocationTest()
        {
            //This test is failing due to the site not working properly at this time - Geolocation returns Undefined
            var geolocationPage = basePage.ClickGeolocationLink();
            string locationInfo = geolocationPage.ValidateGeolocation();
            Assert.Contains("Cupertino", locationInfo);
        }
    }
}
