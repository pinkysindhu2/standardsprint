using OpenQA.Selenium;
using SpecflowPM.Tests.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using ProjectMars.Framework.Extension;

namespace SpecflowPM.Tests.Pages.Account
{
    public class Login: Home.HomePage
    {
        public Login(IWebDriver driver): base(driver) { }

        #region  Initialize Web Elements 
        private IWebElement Email =>    Driver.WaitForElement(By.Name("email"));
        private IWebElement Password => Driver.WaitForElement(By.Name("password"));
        private IWebElement LoginBtn => Driver.WaitForElement(By.XPath("//button[contains(text(),'Login')]"));
        #endregion

        //login into the website
        public Account.Profile LoginWebsite(string email, string password)
        {
            Driver.pageLoad();
            Email.SendKeys(email);
            Password.SendKeys(password);
            LoginBtn.Click();
            return new Account.Profile(Driver);
            //Assert.AreEqual("Log", "Login");
        }
    }
}
