using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectMars.Framework.Extension;
using ProjectMars.Framework.Helper;
using ProjectMars.Framework.Config;

namespace SpecflowPM.Tests.Pages.Profile
{   /*
        This class represents the Content Area of User's Profile where user can add, update, delete
        the information regarding his profile eg lang, skill, edu, certificates, hours, upload image,
        description, availability and hours  
    */
    public class ProfileSection: Account.Profile
    {
        public ProfileSection(IWebDriver driver): base(driver) {
            ExcelHelper.PopulateInCollection(PathHelper.GetCurrentPath("ExcelTestData\\ProfileData.xlsx"), "Profile");
        }

        #region Initialize the User Details Web elements
        private IWebElement profileImg => Driver.WaitForElement(By.CssSelector(".user-details .image "));
        private IWebElement editName => Driver.WaitForElement(By.ClassName("title"));
        private IWebElement firstName => Driver.WaitForElement(By.CssSelector("input[name='firstName']"));
        private IWebElement lastName => Driver.WaitForElement(By.CssSelector("input[name='lastName']"));
       
        //this is Save btn for saving your name
        private IWebElement updateNameBtn => Driver.WaitForElement(By.XPath("//div[@class='user-details']/descendant::div[@class='content']/descendant::button"));
        private IWebElement availableTime => Driver.WaitForElement(By.XPath("//div[@class='user-details']/descendant::div[@class='extra content']/div/div[2]/div/span"));
        private IWebElement editAvailability => Driver.WaitForElement(By.XPath("//div[@class='user-details']/descendant::div[@class='extra content']/div/div[2]/div/span/i"));
        private IWebElement availabilityDDL => Driver.WaitForElement(By.XPath("//div[@class='user-details']/descendant::div[@class='extra content']/div/div[2]/div/span/select"));
        private IWebElement availableHours => Driver.WaitForElement(By.XPath("//div[@class='user-details']/descendant::div[@class='extra content']/div/div[3]/div/span"));
        private IWebElement editHours => Driver.WaitForElement(By.XPath("//div[@class='user-details']/descendant::div[@class='extra content']/div/div[3]/div/span/i"));
        private IWebElement hoursDDL => Driver.WaitForElement(By.XPath("//div[@class='user-details']/descendant::div[@class='extra content']/div/div[3]/div/span/select"));
        private IWebElement availableEarnings => Driver.WaitForElement(By.XPath("//div[@class='user-details']/descendant::div[@class='extra content']/div/div[4]/div/span"));
        private IWebElement editEarns => Driver.WaitForElement(By.XPath("//div[@class='user-details']/descendant::div[@class='extra content']/div/div[4]/div/span/i"));
        private IWebElement earnsDDL => Driver.WaitForElement(By.XPath("//div[@class='user-details']/descendant::div[@class='extra content']/div/div[4]/div/span/select"));
        #endregion

        #region Initialize web elements for Description
        protected IWebElement description => Driver.WaitForElement(By.XPath("//div[@id='account-profile-section']/div/section[2]" +
        "/div/div/div/div[3]/div/div/div/h3/span"));
        #endregion

        #region  Language Tab
        protected IWebElement langTab => Driver.WaitForElement(By.CssSelector("a[data-tab='first']"));
        #endregion
        #region Skill Tab
        protected IWebElement skillTab => Driver.WaitForElement(By.CssSelector("a[data-tab='second']"));
        #endregion
        #region Education Tab
        protected IWebElement eduTab => Driver.WaitForElement(By.CssSelector("a[data-tab='third']"));
        #endregion
        #region Certificate Tab
        protected IWebElement certificateTab => Driver.WaitForElement(By.CssSelector("a[data-tab='fourth']"));
        #endregion
        
        public void UpdateAvailability()
        {
            editAvailability.Click();
            Driver.wait(5);
            availabilityDDL.selectFromDDL(ExcelHelper.ReadData(2, "Available Time"));
        }

        public bool AvailableTimeSuccess()
        {
            Driver.wait(5);
            return availableTime.Text == ExcelHelper.ReadData(2, "Available Time") ? true : false;
        }

        public void UpdateHours()
        {
            editHours.Click();
            Driver.wait(5);
            hoursDDL.selectFromDDL(ExcelHelper.ReadData(2, "Hours"));
        }

        public bool AvailableHoursSuccess()
        {
            Driver.wait(5);
            return availableHours.Text == ExcelHelper.ReadData(2, "Hours") ? true : false;
        }

        public void UpdateEarnTarget()
        {
            editEarns.Click();
            Driver.wait(5);
            earnsDDL.selectFromDDL(ExcelHelper.ReadData(2, "Earn Target"));
        }

        public bool EarnTargetSuccess()
        {
            Driver.wait(5);
            return availableEarnings.Text == ExcelHelper.ReadData(2, "Earn Target") ? true : false;
        }
        public Language ClickOnLanguageTab()
        {
            langTab.Click();
            return new Language(Driver);
        }
        public Skill ClickOnSkillTab()
        {
            skillTab.Click();
            return new Skill(Driver);
        }
        public Education ClickOnEducationTab()
        {
            eduTab.Click();
            return new Education(Driver);
        }
        public Certificate ClickOnCertificateTab()
        {
            certificateTab.Click();
            return new Certificate(Driver);
        }
        public Description ClickOnDescription()
        {
            description.Click();
            return new Description(Driver);
        }
    }
}
