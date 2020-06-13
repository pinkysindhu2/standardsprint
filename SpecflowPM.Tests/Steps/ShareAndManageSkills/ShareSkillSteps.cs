using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SpecflowPM.Tests.Steps.ShareAndManageSkills
{
    [Binding]
    public class ShareSkillSteps: Config.PageInstances
    {
        private readonly IWebDriver Driver;
        // Total Rows before Deleting the Service
        private int before;

        public ShareSkillSteps(IWebDriver driver)
        {
            this.Driver = driver;
            profile = new Pages.Account.Profile(Driver);
        }

        [Given(@"I click on ShareSkill button")]
        public void GivenIClickOnShareSkillButton()
        {
            service = profile.ClickOnShareSkillBtn();
        }

        [When(@"I add service")]
        public void WhenIAddService()
        {
            manageListing = service.EnterShareSkill();             
        }

        [Then(@"The service should be displayed on my listing under ManageListing page")]
        public void ThenTheServiceShouldBeDisplayedOnMyListingUnderManageListingPage()
        {
            Assert.That(manageListing.isServiceSaved(2));
        }

        [When(@"I cancel service")]
        public void WhenICancelService()
        {
            profile =  service.CancelService();
        }

        [Then(@"The service should be cancelled and not be displayed under ManageListing page")]
        public void ThenTheServiceShouldBeCancelledAndNotBeDisplayedUnderManageListingPage()
        {
            Assert.AreEqual(Driver.Url, "http://192.168.99.100:5000/Account/Profile");
            manageListing = profile.ClickOnManageListingTab();
            Assert.That(manageListing.isServiceSaved(4), Is.EqualTo(false));
        }

        [Given(@"I click on the ManageListings")]
        public void GivenIClickOnTheManageListings()
        {
            manageListing = profile.ClickOnManageListingTab();
        }

        [When(@"I edit a service")]
        public void WhenIEditAService()
        {
            service = manageListing.clickOnEdit();
            manageListing = service.EditShareSkill();
        }

        [Then(@"The service should be updated on my listings under ManageListing page")]
        public void ThenTheServiceShouldBeUpdatedOnMyListingsUnderManageListingPage()
        {
            Assert.That(manageListing.isServiceSaved(3));
        }

        [When(@"I view a service")]
        public void WhenIViewAService()
        {
            viewService = manageListing.clickOnView();
        }

        [Then(@"The service should be displayed with more detailed information")]
        public void ThenTheServiceShouldBeDisplayedWithMoreDetailedInformation()
        {
            Assert.That(viewService.isTheCorrectServiceDisplayed(2));
        }

        [When(@"I delete a service")]
        public void WhenIDeleteAService()
        {
           before = manageListing.clickOnDelete();
        }

        [Then(@"The service should be deleted and not be displayed on my listings under ManageListing page")]
        public void ThenTheServiceShouldBeDeletedAndNotBeDisplayedOnMyListingsUnderManageListingPage()
        {
            Assert.Less(manageListing.GetTotalRowsIntoTable(), before);
        }

    }
}
