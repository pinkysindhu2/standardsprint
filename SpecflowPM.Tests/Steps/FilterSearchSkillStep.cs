using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecflowPM.Tests.Pages;
using NUnit.Framework;

namespace SpecflowPM.Tests.Steps
{
    [Binding]
    public class FilterSearchSkillStep
    {
        private readonly IWebDriver Driver;
        private Category category;
        private SearchService searchService;
        private int totalSkills;
        private int filteredSkills;

        public FilterSearchSkillStep(IWebDriver driver)
        {
            this.Driver = driver;
            category = new Category(driver);
        }
        [Given(@"I click on Search button")]
        public void GivenIClickOnSearchButton()
        {
            searchService = category.ClickOnSearchBtn();
        }

        [Given(@"I type (.*) and select the trader")]
        public void GivenITypePinkySinghAndSelectTheTrader(string traderName)
        {
            searchService.GetUserFromDDL(traderName);
        }


        [Then(@"Skills should be successfully displayed")]
        public void ThenSkillsShouldBeSuccessfullyDisplayed()
        {
            totalSkills = searchService.TotalSkillsDisplayed();
        }


        [When(@"I click on (.*) Button")]
        public void WhenIClickOnOnlineButton(string filter)
        {
            filteredSkills = searchService.ClickOnFilers(filter);
        }

        [Then(@"Skill should be refined acording to (.*)")]
        public void ThenSkillShouldBeRefinedAcordingToOnline(string filter)
        {
            searchService.VerifyResultwithFilter(totalSkills, filteredSkills, filter);
        }

        [When(@"I enter (.*)")]
        public void WhenIEnterCypress(string skill)
        {
            searchService.TypeSkillIntoSearchBox(skill);
        }


        [Then(@"(.*)'s skills should be listed")]
        public void ThenPinkySinghSSkillsShouldBeListed(string traderName)
        {
            searchService.VerifyUserServicesListed(traderName);
        }

        [Then(@"Result should be displayed acording to (.*)")]
        public void ThenResultShouldBeDisplayedAcordingToCypress(string skill)
        {
            searchService.VerifySearchedSkill(skill);
        }

    }
}
