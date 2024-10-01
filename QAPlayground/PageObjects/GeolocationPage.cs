using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.PageObjects
{
    public class GeolocationPage : BasePage
    {
        private IWebDriver _driver;

        public GeolocationPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement GetLocationButton => _driver.FindElement(By.Id("location-info"));
        private IWebElement LocationInfo => _driver.FindElement(By.Id("location-info"));

        public string ValidateGeolocation()
        {
            //Create variables for longitude and latitude
            double latitude = 37.33182;
            double longitude = -122.03118;

            //Create javascript for setting the geolocation in chrome browser
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;

            string script = $@"
            navigator.geolocation.getCurrentPosition = function(success) {{
                var position = {{
                    'coords': {{
                        'latitude': {latitude},
                        'longitude': {longitude}
                    }}
                }};
                success(position);
            }};
        ";
            //Click Geolocation button and assert that the location is Cupertino
            GetLocationButton.Click();
            return LocationInfo.Text;
        }
    }
}
