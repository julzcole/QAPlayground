using QAPlayground.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAPlayground.Tests
{
    public class RedirectChain : BaseTest
    {
        public RedirectChain(WebDriverFixture fixture) : base(fixture)
        {
        }

        //Due to difficulty with asynchronous testing with Selenium this test will fail.
        //[Fact]
        public void RedirectChainTest()
        {
            //Having trouble with this as this type of test would be much easier with playwright or similar due to asynchronous testing
            string[] pageTitles = {"Welcome to Second Page", "Welcome to Third Page" , "Welcome to Fourth Page" ,
                "Welcome to Fifth Page" , "Welcome to Sixth Page" , "Welcome to the Last Page" };

            string[] urls = { "redirect", "#", "second", "third", "fourth", "fifth", "sixth", "last" };
            var redirectChainPage = basePage.ClickRedirectChainLink();
            redirectChainPage.ClickRedirectButton();

            for(int i = 0; i < pageTitles.Length; i++)
            {
                Assert.Contains(pageTitles[i], redirectChainPage.ValidateUrls());
            }
        }
    }
}
