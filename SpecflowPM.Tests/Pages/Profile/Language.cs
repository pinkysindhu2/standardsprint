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
    public class Language : ProfileSection
    {
        public Language(IWebDriver driver) : base(driver) {
            ExcelHelper.PopulateInCollection(PathHelper.GetCurrentPath("ExcelTestData/ProfileData.xlsx"),"Language");
        }

        #region initialize Language elements
        private IWebElement form => Driver.WaitForElement(By.XPath("//div[@data-tab='first']/descendant::div[@class='fields']"));
        private IWebElement addNew => Driver.WaitForElement(By.XPath("//div[@data-tab='first']/descendant::table/thead/tr/th[3]/div"));
        private IWebElement langName => Driver.WaitForElement(By.XPath("//input[@name='name']"));
        private IWebElement langLevel => Driver.WaitForElement(By.XPath("//div[@data-tab='first']/descendant::select"));
        private IWebElement addLang => Driver.WaitForElement(By.XPath("//input[@value='Add']"));
        private IWebElement cancelLang => Driver.WaitForElement(By.XPath("//input[@value='Cancel']"));
        private IList<IWebElement> tbody => Driver.WaitForElements(By.XPath("//div[@data-tab='first']/descendant::table/tbody"));
        private IWebElement editBtn => Driver.WaitForElement(By.XPath("//div[@data-tab='first']/descendant::table/tbody[1]/tr/td[3]/span[1]"));
        private IWebElement updateBtn => Driver.WaitForElement(By.XPath("//input[@value='Update']"));
        private IWebElement deleteBtn => Driver.WaitForElement(By.XPath("//div[@data-tab='first']/descendant::table/tbody[1]/tr/td[3]/span[2]"));
        #endregion

        public void AddLanguage()
        {
            addNew.Click();
            Driver.wait(2);
            langName.SendKeys(ExcelHelper.ReadData(2, "Language"));
            langLevel.selectFromDDL(ExcelHelper.ReadData(2, "Level"));
            Driver.wait(3);
            addLang.Click();
        }

        public bool AddLangSuccess()
        {
           return LanguageSuccess(ExcelHelper.ReadData(2, "Language"), ExcelHelper.ReadData(2, "Level"));

        }

        //check if 1 or more language is available for edit or delete
        public int ISLangAvailable()
        {
            //count how many tbody is present into table
            return tbody.Count;

        }

        // Edit the First Language 
        public void EditLanguage()
        {
            editBtn.Click();
            Driver.wait(10);
            langName.Clear();
            langName.SendKeys(ExcelHelper.ReadData(3,"Language"));
            langLevel.selectFromDDL(ExcelHelper.ReadData(3, "Level"));
            Driver.wait(3);
            updateBtn.Click();
          
        }

        public bool UpdateEditLangSuccess()
        {
            return LanguageSuccess(ExcelHelper.ReadData(3, "Language"), ExcelHelper.ReadData(3, "Level"));
        }
        // Delete the Language 
        public void DeleteLanguage()
        {
            Driver.wait(10);
            deleteBtn.Click();
        }
        public bool DeleteLangSuccess()
        {
            return LanguageSuccess(ExcelHelper.ReadData(3, "Language"), ExcelHelper.ReadData(3, "Level"));
        }

        public void CancelLanguage()
        {
            addNew.Click();
            Driver.wait(2);
            cancelLang.Click();
        }
        public bool CancelLangSuccess()
        {
            return form.Displayed ? true : false;
        }

        private bool LanguageSuccess(string lang, string level)
        {
            Driver.wait(15);
            bool status = false;
            if(tbody.Count > 0)
            {
                for (int i = 0; i < tbody.Count; i++)
                {
                    var Lang = tbody[i].FindElement(By.XPath("//tr/td[1]"));
                    var Level = tbody[i].FindElement(By.XPath("//tr/td[2]"));

                    if (Lang.Text == lang && Level.Text == level)
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

