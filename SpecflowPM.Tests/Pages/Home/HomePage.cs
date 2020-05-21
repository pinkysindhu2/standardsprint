using OpenQA.Selenium;
using SpecflowPM.Tests.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using ProjectMars.Framework.Extension;

namespace SpecflowPM.Tests.Pages.Home
{
    public class HomePage
    {
        protected readonly IWebDriver Driver;

        public HomePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        #region  Initialize WebElements for First_Section on Home page
        protected IWebElement SignIntab => Driver.WaitForElement(By.XPath("//a[contains(text(),'Sign')]"));
        protected IWebElement JoinTab => Driver.WaitForElement(By.XPath("//button[contains(text(),'Join')]"));
        protected IWebElement searchTextBox => Driver.WaitForElement(By.XPath("//div[@class='main-search']/descendant::input"));
        protected IWebElement searchBtn => Driver.WaitForElement(By.XPath("//div[@class='main-search']/descendant::button"));
        #endregion

        #region  Initialize WebElements for Explore Section on Home page
        protected IWebElement exploreCategory => Driver.WaitForElement(By.XPath("//h3[contains(text(),'Explore categories>')]"));
        protected IWebElement GraphicDesign => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[1]//div[1]"));
        protected IWebElement digitalMarketing => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[1]//div[2]"));
        protected IWebElement writtingTranslation => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[1]//div[3]"));
        protected IWebElement videoAnimation => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[1]//div[4]"));
        protected IWebElement musicAudio => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[2]//div[1]"));
        protected IWebElement progTech => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[2]//div[2]"));
        protected IWebElement business => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[2]//div[3]"));
        protected IWebElement funLifestyle => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[2]//div[4]"));
        #endregion

        #region Initialize WebElements for Suggestions_Section on Home page
        #endregion
        #region Initialize WebElements for Visions_Section on Home page
        #endregion
        #region Initialize WebElements for GuideLines_Section on Home page
        #endregion
        #region Initialize WebElements for Category_Section on Home page
        #endregion

        public Account.Login ClickOnSignInBtn()
        {
            SignIntab.Click();
            return new Account.Login(Driver);
        }

        public void LogoutSuccess()
        {
            Assert.Multiple(() =>
            {
                Assert.That(SignIntab.Displayed, Is.EqualTo(true));
                Assert.That(Driver.Url, Is.EqualTo("http://192.168.99.100:5000/Home"));
            });
        }
    }
}
