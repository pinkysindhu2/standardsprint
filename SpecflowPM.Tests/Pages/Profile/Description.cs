using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectMars.Framework.Extension;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using ProjectMars.Framework.Helper;

namespace SpecflowPM.Tests.Pages.Profile
{
    public class Description: ProfileSection
    {
        public Description(IWebDriver driver) : base(driver)
        {
            ExcelHelper.PopulateInCollection(PathHelper.GetCurrentPath("ExcelTestData/ProfileData.xlsx"), "Description");
        }

        #region initialize Description web elements
        private IWebElement textAreaDes => Driver.WaitForElement(By.TagName("textarea"));
        private IWebElement save => Driver.WaitForElement(By.XPath("//button[@class='ui teal button' and @type='button']"));
        private IWebElement shtDescription => Driver.WaitForElement(By.XPath("//div[@id='account-profile-section']" +
                "/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        #endregion

        public void AddDescription()
        {
            textAreaDes.Clear();
            textAreaDes.SendKeys(ExcelHelper.ReadData(2, "A short Description"));
            save.Click();
        }

        public bool IsDescriptionSaved()
        {
            return shtDescription.Text.Equals(ExcelHelper.ReadData(2, "A short Description"))? true : false;
        }
        public void UpdateDescription()
        {
            textAreaDes.Clear();
            textAreaDes.SendKeys(ExcelHelper.ReadData(2, "Update Description"));
            save.Click();
        }
        public bool IsDescriptionUpdated()
        {
            return shtDescription.Text.Equals(ExcelHelper.ReadData(2, "Update Description")) ? true : false;
        }
    }
}
