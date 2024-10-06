using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAPlayground.PageObjects;
using QAPlayground.Utilities;

namespace QAPlayground.Tests
{
    public class MultiLevelDropdown : BaseTest
    {
        public MultiLevelDropdown(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        ///Navigate into the sub-menus and assert menu items text and links
        /// </summary>

        string baseUrl = "https://qaplayground.dev/apps/multi-level-dropdown/";
        string[] expectedMenuItemText = { "My Tutorial", "HTML", "CSS", "JavaScript", "Awesome!" };
        string[] expectedMenuItemLinks = { "#main", "#!HTML", "#!CSS", "#!JavaScript", "#!Awesome" };
        string[] expectedAnimalText = { "Animals", "Kangaroo", "Frog", "Horse", "Hedgehog" };
        string[] expectedAnimalLinks = { "#main", "#!Kangaroo", "#!Frog", "#!Horse", "#!Hedgehog" };

        [Fact]
        public void MultiLevelDropdownTest()
        {
            var multiLevelDropdownPage = basePage.ClickMultiLevelDropdownLink();
            ReadOnlyCollection<IWebElement> settingsMenuItems = multiLevelDropdownPage.ValidateSettingsMenuItems();

            for (int i = 0; i < settingsMenuItems.Count; i++)
            {
                Assert.Equal(expectedMenuItemText[i], settingsMenuItems[i].Text);
                Assert.Equal(baseUrl + expectedMenuItemLinks[i], settingsMenuItems[i].GetAttribute("href").ToString());
            }

            
            ReadOnlyCollection<IWebElement> animalMenuItems = multiLevelDropdownPage.ValidateAnimalMenuItems();
            
            for (int i = 0;i < animalMenuItems.Count; i++)
            {
                Assert.Contains(expectedAnimalText[i], animalMenuItems[i].Text);
                Assert.Equal(baseUrl + expectedAnimalLinks[i], animalMenuItems[i].GetAttribute("href").ToString());
            }
        }
        
    }
}
