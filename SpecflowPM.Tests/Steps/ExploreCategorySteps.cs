using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ProjectMars.Framework.Config;
using SpecflowPM.Tests.Pages;
using ProjectMars.Framework.Helper;
using ProjectMars.Framework.Extension;
using System.Threading;

namespace SpecflowPM.Tests.Steps
{
    [Binding]
    public class ExploreCategorySteps
    {
        private readonly IWebDriver Driver;
        private Category category;
        private SearchService SearchService;

        public ExploreCategorySteps(IWebDriver driver)
        {
            this.Driver = driver;
            category = new Category(Driver);
        }

        [Given(@"I visit to Home page")]
        public void GivenIVisitToHomePage()
        {
            Driver.Navigate().GoToUrl(Settings.DockerBaseURL);
        }

        [Given(@"I scroll down to Explore category")]
        public void GivenIScrollDownToExploreCategory()
        {
            category.scrollDownToCategory();
        }

        /*   [When(@"I click on Category")]
           public void WhenIClickOnCategory(Table table)
           {
               var cat = table.CreateSet<CategoryTable>();
               SearchService = category.SearchCateory(cat.CategoryName);
           }*/

        [When(@"I click on Category (.*)")]
        public void WhenIClickOnCategoryGraphicDesign(string cat)
        {
            SearchService = category.SearchCateory(cat);
        }

        [Then(@"I should successfully view service per (.*) and (.*)")]
        public void ThenIShouldSuccessfullyViewServicePerGraphicDesignAnd(string cat, int index)
        {
            Thread.Sleep(10);
            SearchService.VerifyCategorySearch(cat, index);
            Thread.Sleep(10);
        }

    }
}
