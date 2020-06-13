using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectMars.Framework.Extension;
using NUnit.Framework;
using SpecflowPM.Tests.Pages.ShareAndManageSkill;

namespace SpecflowPM.Tests.Pages.Account
{
    public class Profile
    {
        protected readonly IWebDriver Driver;

        public Profile(IWebDriver driver)
        {
            this.Driver = driver;
            this.Driver.pageLoad();
        }

        #region Initilize First Menu Web Elements
        protected IWebElement marsLogo => Driver.WaitForElement(By.XPath("//a[contains(text(),'Mars Logo')]"));
        protected IWebElement searchBar => Driver.WaitForElement(By.XPath("//div[@class='ui secondary menu']//input[@placeholder=\"Search skills\"]"));
        protected IWebElement notification => Driver.WaitForElement(By.XPath("//div[@class='ui compact menu']/div"));
        protected IWebElement chat => Driver.WaitForElement(By.XPath("//div[@class='ui compact menu']/a[contains(text(),'Chat')]"));
        protected IWebElement profileName => Driver.WaitForElement(By.XPath("//div[@class='ui compact menu']/child::span"));
        protected IWebElement logout => Driver.WaitForElement(By.XPath("//div[@class='ui compact menu']/descendant::button[contains(text(), 'Sign Out')]"));
        #endregion

        #region Initilize Second Menu Web Elements
        protected IWebElement dashboard => Driver.WaitForElement(By.LinkText("Dashboard"));
        protected IWebElement profile => Driver.WaitForElement(By.CssSelector("section[class='nav-secondary'] a[href='/Account/Profile']"));
        protected IWebElement manageListing => Driver.WaitForElement(By.LinkText("Manage Listings"));
        protected IWebElement manageRequest => Driver.WaitForElement(By.LinkText("Manage Requests"));
        protected IWebElement receivedRequest => Driver.WaitForElement(By.LinkText("Received Requests"));
        protected IWebElement sentRequest => Driver.WaitForElement(By.LinkText("Sent Requests"));
        protected IWebElement shareSkillBtn => Driver.WaitForElement(By.LinkText("Share Skill"));
        #endregion
        #region Initilize Section Web Elements
        #endregion


        public void LoginSuccess()
        {
            Assert.Multiple(() =>
            {
                Assert.That(marsLogo.Text, Is.EqualTo("Mars Logo"));
                Assert.That(Driver.Url, Is.EqualTo("http://192.168.99.100:5000/Account/Profile"));
            });
        }

        public ProfileSettings HoverOnProfileName()
        {
            profileName.Click();
            return new ProfileSettings(Driver);
        }

        public ServiceListing ClickOnShareSkillBtn()
        {
            shareSkillBtn.Click();
            return new ServiceListing(Driver);
        }

        public ManageListing ClickOnManageListingTab()
        {
            manageListing.Click();
            return new ManageListing(Driver);
        }
    }
}
