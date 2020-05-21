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
    public class Education: ProfileSection
    {
        public Education(IWebDriver driver): base(driver) { 
            ExcelHelper.PopulateInCollection(PathHelper.GetCurrentPath("ExcelTestData/ProfileData.xlsx"), "Education"); 
        }

        #region initialize Education web elements
        private IWebElement EduForm => Driver.WaitForElement(By.XPath("//div[@data-tab='third']/descendant::div[@class='fields']"));
        private IWebElement addNew => Driver.WaitForElement(By.XPath("//div[@data-tab='third']/descendant::table/thead/tr/th[6]/div"));
        private IWebElement uniName => Driver.WaitForElement(By.CssSelector("input[name='instituteName'"));
        private IWebElement country => Driver.WaitForElement(By.CssSelector("select[name='country']"));
        private IWebElement title => Driver.WaitForElement(By.CssSelector("select[name='title']"));
        private IWebElement degree => Driver.WaitForElement(By.CssSelector("input[name='degree']"));
        private IWebElement year => Driver.WaitForElement(By.CssSelector("select[name='yearOfGraduation'"));
        private IWebElement addEdu => Driver.WaitForElement(By.CssSelector("input[value='Add']"));
        private IWebElement cancelEdu => Driver.WaitForElement(By.CssSelector("input[value='Cancel']"));
        private IList<IWebElement> tbody => Driver.WaitForElements(By.XPath("//div[@data-tab='third']/descendant::table/tbody"));
        private IWebElement editBtn => Driver.WaitForElement(By.XPath("//div[@data-tab='third']/descendant::table/tbody[1]/tr/td[6]/span[1]"));
        private IWebElement updateBtn => Driver.WaitForElement(By.XPath("//input[@value='Update']"));
        private IWebElement deleteBtn => Driver.WaitForElement(By.XPath("//div[@data-tab='third']/descendant::table/tbody[1]/tr/td[6]/span[2]"));
        #endregion

        public void AddEducation()
        {
            addNew.Click();
            Driver.wait(4);
            uniName.SendKeys(ExcelHelper.ReadData(2, "University"));
            country.selectFromDDL(ExcelHelper.ReadData(2,"Country"));
            Driver.wait(2);
            title.selectFromDDL(ExcelHelper.ReadData(2, "Title"));
            Driver.wait(2);
            degree.SendKeys(ExcelHelper.ReadData(2,"Degree"));
            year.selectFromDDL(ExcelHelper.ReadData(2, "Graduated"));
            Driver.wait(2);
            addEdu.Click();
        }

        public bool AddEducationSuccess()
        {
            return EducationSuccess(ExcelHelper.ReadData(2, "University"),
                ExcelHelper.ReadData(2, "Country"),
                ExcelHelper.ReadData(2, "Title"),
                ExcelHelper.ReadData(2, "Degree"),
                ExcelHelper.ReadData(2, "Graduated"));
        }

        //check if 1 or more language is available for edit or delete
        public int IsEducationAvailable()
        {
            //count how many tbody is present into table
            return tbody.Count;

        }
        // Edit the First Education 
        public void UpdateEducation()
        {
            editBtn.Click();
            Driver.wait(4);
            uniName.Clear();
            uniName.SendKeys(ExcelHelper.ReadData(3, "University"));
            country.selectFromDDL(ExcelHelper.ReadData(3, "Country"));
            Driver.wait(2);
            title.selectFromDDL(ExcelHelper.ReadData(3, "Title"));
            Driver.wait(2);
            degree.Clear();
            degree.SendKeys(ExcelHelper.ReadData(3, "Degree"));
            year.selectFromDDL(ExcelHelper.ReadData(3, "Graduated"));
            Driver.wait(2);
            updateBtn.Click();
        }

        public bool UpdateEducationSuccess()
        {
            return EducationSuccess(ExcelHelper.ReadData(3, "University"),
                ExcelHelper.ReadData(3, "Country"),
                ExcelHelper.ReadData(3, "Title"),
                ExcelHelper.ReadData(3, "Degree"),
                ExcelHelper.ReadData(3, "Graduated"));
        }

        public void DeleteEducation()
        {
            Driver.wait(6);
            deleteBtn.Click();
        }

        public bool DeleteEducationSuccess()
        {
            return EducationSuccess(ExcelHelper.ReadData(3, "University"),
               ExcelHelper.ReadData(3, "Country"),
               ExcelHelper.ReadData(3, "Title"),
               ExcelHelper.ReadData(3, "Degree"),
               ExcelHelper.ReadData(3, "Graduated"));
        }

        public void CancelEducation()
        {
            addNew.Click();
            Driver.wait(2);
            cancelEdu.Click();
        }
        public bool CancelEducationSuccess()
        {
            return EduForm.Displayed ? true : false;
        }
        private bool EducationSuccess(string uni, string country, string title, string degree, string year)
        {
            Driver.wait(15);
            bool status = false;
            if (tbody.Count > 0)
            {
                for (int i = 0; i < tbody.Count; i++)
                {
                    var Country = tbody[i].FindElement(By.XPath("//tr/td[1]"));
                    var Uni = tbody[i].FindElement(By.XPath("//tr/td[2]"));
                    var Title = tbody[i].FindElement(By.XPath("//tr/td[3]"));
                    var Degree = tbody[i].FindElement(By.XPath("//tr/td[4]"));
                    var Year = tbody[i].FindElement(By.XPath("//tr/td[5]"));

                    if (Uni.Text == uni && Country.Text == country &&
                        Title.Text == title && Degree.Text == degree && Year.Text == year)
                    {
                        status = true;
                        Console.WriteLine("Test Success");
                    }
                }
            }
            return status;
        }
    }
}
