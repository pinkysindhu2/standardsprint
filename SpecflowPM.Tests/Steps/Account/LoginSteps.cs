using OpenQA.Selenium;
using ProjectMars.Framework.Config;
using SpecflowPM.Tests.Pages.Account;
using SpecflowPM.Tests.Pages.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowPM.Tests.Steps.Account
{
    [Binding]
    public class LoginSteps
    {
        protected readonly IWebDriver Driver;
        private HomePage home;
        private Login login;
        public Pages.Account.Profile profile;

        public LoginSteps(IWebDriver driver)
        {
            this.Driver = driver;
        }

        [Given(@"I visit to Home page")]
        public void GivenIVisitToHomePage()
        {
            Driver.Navigate().GoToUrl(Settings.DockerBaseURL);
            home = new HomePage(Driver);
        }

        [Given(@"I click on Sigin button")]
        public void GivenIClickOnSiginButton()
        {
            login = home.ClickOnSignInBtn();
        }

        [When(@"I enter (.*) and (.*)")]
        public void WhenIEnterAnd(string email, string password)
        {
            profile = login.LoginWebsite(email, password);
        }


        [Then(@"I should be in Profile page")]
        public void ThenIShouldBeInProfilePage()
        {
            profile.LoginSuccess();
        }
    }
}
