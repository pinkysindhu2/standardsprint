using OpenQA.Selenium;
using SpecflowPM.Tests.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using ProjectMars.Framework.Extension;

namespace SpecflowPM.Tests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver Driver;
        public LoginPage(IWebDriver driver)
        {
            this.Driver = driver;
        }
        #region  Initialize Web Elements 
        private IWebElement SignIntab => Driver.WaitForElement(By.XPath("//a[contains(text(),'Sign')]"));
        private IWebElement Email => Driver.WaitForElement(By.Name("email"));
        private IWebElement Password => Driver.FindElement(By.Name("password"));
        private IWebElement LoginBtn => Driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        #endregion

        //login to the website
        public void LoginWebsite(string email, string password)
        {
            
            Driver.Navigate().GoToUrl(ProjectMars.Framework.Config.Settings.DockerBaseURL);
            //Thread.Sleep(1500);
            //SignIntab.Click();
            Email.SendKeys(email);
            Password.SendKeys(password);
            LoginBtn.Click();
            //Assert.AreEqual("Log", "Login");
        }
    }
}
