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
    public class Skill: ProfileSection
    {
        public Skill(IWebDriver driver): base(driver) {
            ExcelHelper.PopulateInCollection(PathHelper.GetCurrentPath("ExcelTestData/ProfileData.xlsx"), "Skill");
        }
        #region initialize Skill web elements
        private IWebElement skillForm => Driver.WaitForElement(By.XPath("//div[@data-tab='second']/descendant::div[@class='fields']"));
        private IWebElement addNew => Driver.WaitForElement(By.XPath("//div[@data-tab='second']/descendant::table/thead/tr/th[3]/div"));
        private IWebElement skillName => Driver.WaitForElement(By.XPath("//input[@name='name']"));
        private IWebElement skillLevel => Driver.WaitForElement(By.XPath("//div[@data-tab='second']/descendant::select"));
        private IWebElement addSkill => Driver.WaitForElement(By.CssSelector("input[value='Add']"));
        private IList<IWebElement> tbody => Driver.WaitForElements(By.XPath("//div[@data-tab='second']/descendant::table/tbody"));
        private IWebElement cancelSkill => Driver.WaitForElement(By.CssSelector("input[value='Cancel']"));
        private IWebElement editBtn => Driver.WaitForElement(By.XPath("//div[@data-tab='second']/descendant::table/tbody[1]/tr/td[3]/span[1]"));
        private IWebElement updateBtn => Driver.WaitForElement(By.XPath("//input[@value='Update']"));
        private IWebElement deleteBtn => Driver.WaitForElement(By.XPath("//div[@data-tab='second']/descendant::table/tbody[1]/tr/td[3]/span[2]"));
        #endregion

        public void AddSkill()
        {
            addNew.Click();
            Driver.wait(2);
            skillName.SendKeys(ExcelHelper.ReadData(2, "Skill"));
            skillLevel.selectFromDDL(ExcelHelper.ReadData(2, "Level"));
            Driver.wait(3);
            addSkill.Click();
        }

        public bool AddSkillSuccess()
        {
            return SkillSuccess(ExcelHelper.ReadData(2, "Skill"), ExcelHelper.ReadData(2, "Level"));

        }

        //check if 1 or more Skill is available for edit or delete
        public int ISSkillAvailable()
        {     //count how many tbody is present into table
            return tbody.Count;
        }

        // Edit the First Skill 
        public void EditSkill()
        {
            editBtn.Click();
            Driver.wait(10);
            skillName.Clear();
            skillName.SendKeys(ExcelHelper.ReadData(3, "Skill"));
            skillLevel.selectFromDDL(ExcelHelper.ReadData(3, "Level"));
            Driver.wait(3);
            updateBtn.Click();
        }

        public bool UpdateEditSkilllSuccess()
        {
            return SkillSuccess(ExcelHelper.ReadData(3, "Skill"), ExcelHelper.ReadData(3, "Level"));
        }

        // Delete the Skill
        public void DeleteSkill()
        {
            Driver.wait(10);
            deleteBtn.Click();
        }
        public bool DeleteSkillSuccess()
        {
            return SkillSuccess(ExcelHelper.ReadData(3, "Skill"), ExcelHelper.ReadData(3, "Level"));
        }

        public void CancelSkill()
        {
            addNew.Click();
            Driver.wait(2);
            cancelSkill.Click();
        }
        public bool CancelSkillSuccess()
        {
            return skillForm.Displayed ? true : false;
        }
        private bool SkillSuccess(string lang, string level)
        {
            Driver.wait(10);
            bool status = false;
            if (tbody.Count > 0)
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
