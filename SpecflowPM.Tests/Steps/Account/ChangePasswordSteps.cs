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
using SpecflowPM.Tests.Pages.Account;

namespace SpecflowPM.Tests.Steps.Account
{
    [Binding]
    public class ChangePasswordSteps: Config.PageInstances 
    {
        private readonly IWebDriver Driver;
        public ChangePasswordSteps(IWebDriver driver) {
            this.Driver = driver;
           // profile = new Pages.Account.Profile(Driver);
        }

        [Given(@"I click change password")]
        public void GivenIClickChangePassword()
        {
            profileSettings = profile.HoverOnProfileName();
        }

        [When(@"I enter (.*) and (.*)"), Scope(Tag ="Password")]
        public void WhenIEnterAnd(string oldPassword, string newPassword)
        {
            profileSettings.ChangePassword();
        }

        [Then(@"NewPassword should get saved")]
        public void ThenNewPasswordShouldGetSaved()
        {
            
        }

    }
}
