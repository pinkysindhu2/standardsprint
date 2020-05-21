using OpenQA.Selenium;
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
    public sealed class LogoutSteps
    {
        private IWebDriver Driver;
        private HomePage home;
        public LogoutSteps(IWebDriver driver) {
            this.Driver = driver;
        }

        [When(@"I click on Logout")]
        public void WhenIClickOnLogout()
        {
            Logout logout = new Logout(Driver);
            home = logout.ClickOnLogout();
        }

        [Then(@"I should be in Home page")]
        public void ThenIShouldBeInHomePage()
        {
            home.LogoutSuccess();
        }

    }
}
