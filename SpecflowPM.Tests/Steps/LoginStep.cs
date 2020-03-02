using OpenQA.Selenium;
using SpecflowPM.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowPM.Tests.Steps

{   [Binding]
    public class LoginStep
    {
        private readonly IWebDriver Driver;

        public LoginStep(IWebDriver driver)
        {
            this.Driver = driver;
        }
        [Given(@"I login as trader")]
        public void GivenILoginAsTrader()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.LoginWebsite("","");
        }

    }
}
