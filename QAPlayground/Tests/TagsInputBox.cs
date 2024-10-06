﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAPlayground.PageObjects;
using QAPlayground.Utilities;

namespace QAPlayground.Tests
{
    public class TagsInputBox : BaseTest
    {
        public TagsInputBox(WebDriverFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        ///Add and remove tags and assert tag's presence and count
        /// </summary>
        [Fact]
        public void TagsInputBoxTest()
        {
            
            //Setup - May want to parameterize this at some point
            string[] tags = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
            
            //Actions
            var tagsInputBoxPage = basePage.ClickTagsInputBoxLink();
            tagsInputBoxPage.ClickAllIcons();
            Assert.Equal("10", tagsInputBoxPage.ValidateRemainingTags());
            tagsInputBoxPage.EnterTags(tags);
            Assert.Equal("0", tagsInputBoxPage.ValidateRemainingTags());
        }
    }
}
