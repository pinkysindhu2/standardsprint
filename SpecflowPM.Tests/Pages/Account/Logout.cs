using OpenQA.Selenium;
using SpecflowPM.Tests.Pages.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowPM.Tests.Pages.Account
{
    public class Logout: Profile
    {
        public Logout(IWebDriver driver): base(driver) { }

        public HomePage ClickOnLogout()
        {
            logout.Click();
            return new HomePage(Driver);
        }

    }
}
