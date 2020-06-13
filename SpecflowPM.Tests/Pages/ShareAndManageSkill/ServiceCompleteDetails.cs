using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using ProjectMars.Framework.Helper;
using ProjectMars.Framework.Extension;

namespace SpecflowPM.Tests.Pages.ShareAndManageSkill
{
    public class ServiceCompleteDetails: Account.Profile
    {
        public ServiceCompleteDetails(IWebDriver driver) : base(driver)
        {
            ExcelHelper.PopulateInCollection(PathHelper.GetCurrentPath("ExcelTestData/ShareSkillData.xlsx"), "ShareSkill");
        }

        #region  Initialize Web Elements
        private IWebElement Title => 
            Driver.WaitForElement(By.XPath("//div[@class='ui grid service-details']/div[@class='row'][2]/div[1]/descendant::span[@class='skill-title']"));
        private IWebElement Description => Driver.WaitForElement(By.XPath("//div[@class='ui grid service-details']/div[@class='row'][2]/div[1]/descendant::div[@class='description'][1]"));
        private IWebElement Category => Driver.WaitForElement(By.XPath("//div[@class='ui grid service-details']/div[@class='row'][2]/div[1]/descendant::div[@class='description'][2]"));
        private IWebElement SubCategory => Driver.WaitForElement(By.XPath("//div[@class='ui grid service-details']/div[@class='row'][2]/div[1]/descendant::div[@class='description'][3]"));
        private IWebElement ServiceType => Driver.WaitForElement(By.XPath("//div[@class='ui grid service-details']/div[@class='row'][2]/div[1]/descendant::div[@class='description'][4]"));       
        private IWebElement LocationType => Driver.WaitForElement(By.XPath("//div[@class='ui grid service-details']/div[@class='row'][2]/div[1]/descendant::div[@class='description'][7]"));
        
        // we need to get the following details from DB or from Test Data to match on UI
        private IWebElement TraderName => Driver.WaitForElement(By.XPath("//div[@class='ui grid service-details']/div[@class='row'][2]/div[2]/descendant::div[@class='user-info']/a/h3"));
        private IWebElement StartDate => Driver.WaitForElement(By.XPath("//div[@class='ui grid service-details']/div[@class='row'][2]/div[1]/descendant::div[@class='description'][5]"));
        private IWebElement EndDate => Driver.WaitForElement(By.XPath("//div[@class='ui grid service-details']/div[@class='row'][2]/div[1]/descendant::div[@class='description'][6]"));
        #endregion

        // Check if user can see the same service on which he/she clicked for further details
        public bool isTheCorrectServiceDisplayed(int rowNumber)
        {
            Driver.wait(10);
            if (Title.Text.Equals(ExcelHelper.ReadData(rowNumber, "Title"))
                && Description.Text.Equals(ExcelHelper.ReadData(rowNumber, "Description"))
                && Category.Text.Equals(ExcelHelper.ReadData(rowNumber, "Category"))
                && SubCategory.Text.Equals(ExcelHelper.ReadData(rowNumber, "SubCategory"))
                && ServiceType.Text.Equals(ExcelHelper.ReadData(rowNumber, "ServiceType"))
                && LocationType.Text.Equals(ExcelHelper.ReadData(rowNumber, "LocationType")))
            {
                return true;
            }
            return false;
        }
    }
}
