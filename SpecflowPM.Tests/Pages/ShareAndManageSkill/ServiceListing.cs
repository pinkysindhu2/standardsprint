using OpenQA.Selenium;
using ProjectMars.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectMars.Framework.Extension;

namespace SpecflowPM.Tests.Pages.ShareAndManageSkill
{
    public class ServiceListing : Account.Profile
    {
        public ServiceListing(IWebDriver driver) : base(driver)
        {
            ExcelHelper.PopulateInCollection("ExcelTestData/ShareSkillData.xlsx", "ShareSkill");
        }
        #region Service Listing Page Elements 
        private IWebElement Title => Driver.WaitForElement(By.Name("title"));
        private IWebElement Description => Driver.WaitForElement(By.Name("description"));
        private IWebElement CategoryDropDown => Driver.WaitForElement(By.Name("categoryId"));
        private IWebElement SubCategoryDropDown => Driver.WaitForElement(By.Name("subcategoryId"));
        private IWebElement Tags => Driver.WaitForElement(By.XPath("//div[@class='listing']/descendant::input[@placeholder='Add new tag'][1]"));
        //Select the Service type
        private IWebElement ServiceTypeOptions => Driver.WaitForElement(By.XPath("//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']"));
        //Select the Location Type
        private IWebElement LocationTypeOptions => Driver.WaitForElement(By.XPath("//form/div[6]/div[@class='twelve wide column']/div/div[@class='field']"));
        //Click on Start Date dropdown
        /* private IWebElement StartDateDropDown => Driver.WaitForElement(By.Name("startDate"));
         //Click on End Date dropdown
         private IWebElement EndDateDropDown => Driver.WaitForElement(By.Name("endDate"));
         //Storing the table of available days
         private IWebElement Days => Driver.WaitForElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]"));
         //Storing the starttime
         private IWebElement StartTime => Driver.WaitForElement(By.XPath("//div[3]/div[2]/input[1]"));
         //Click on StartTime dropdown
         private IWebElement StartTimeDropDown => Driver.WaitForElement(By.XPath("//div[3]/div[2]/input[1]"));
         //Click on EndTime dropdown
         private IWebElement EndTimeDropDown => Driver.WaitForElement(By.XPath("//div[3]/div[3]/input[1]"));*/
        //Click on Skill Trade option
        private IWebElement SkillTradeOption => Driver.WaitForElement(By.XPath("//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']"));
        //Enter Skill Exchange
        // "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")
        private IWebElement SkillExchange => Driver.WaitForElement(By.XPath("//div[@class='listing']/descendant::input[@placeholder='Add new tag'][1]"));
        //Enter the amount for Credit
        private IWebElement CreditAmount => Driver.WaitForElement(By.CssSelector("input[placeholder='Amount']"));
        //Click on Active/Hidden option
        private IWebElement ActiveOption => Driver.WaitForElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']"));
        //Click on upload button
        private IWebElement fileUpload => Driver.WaitForElement(By.CssSelector("i[class='huge plus circle icon padding-25']"));
        private IWebElement SaveBtn => Driver.WaitForElement(By.CssSelector("input[value='Save']"));
        private IWebElement CancelBtn => Driver.WaitForElement(By.CssSelector("input[value='Cancel']"));
        #endregion

        public void EnterShareSkill()
        {
            //Enter the data on HTML form
            Title.EnterText(ExcelHelper.ReadData(2, "Title"));
            Driver.wait(10);

            Description.EnterText(ExcelHelper.ReadData(2, "Description"));
            Driver.wait(10);

            //Select Category and Subcategory
            CategoryDropDown.selectFromDDL(ExcelHelper.ReadData(2, "Category"));
            Driver.wait(10);
            SubCategoryDropDown.selectFromDDL(ExcelHelper.ReadData(2, "SubCategory"));
            Driver.wait(10);

            //Enter tag
            Tags.EnterText(ExcelHelper.ReadData(2, "Tags"));
            Tags.EnterText(Keys.Enter);
            Driver.wait(10);

            //Select Radio button
            selectServiceRadioButton(ServiceTypeOptions, ExcelHelper.ReadData(2, "ServiceType"));
            Driver.wait(10);

            selectLocationRadioButton(LocationTypeOptions, ExcelHelper.ReadData(2, "LocationType"));
            Driver.wait(10);

            // select start and end data and time
            //selectStartDateAndTime(); 
            Driver.wait(20);

            // select skill trade: Skill exchange or credit
            selectSkillTrade(SkillTradeOption, ExcelHelper.ReadData(2, "Credit"));
            Driver.wait(10);

            // Upload work sample.docx
            fileUpload.Click();
            FileUpload.uploadFileUsingAutoIT(PathHelper.GetCurrentPath("ExcelTestData/WorkSample.docx"));

            Driver.wait(20);

            // select Active Radio button: Active or Hidden
            selectActiveRadioButton(ActiveOption, ExcelHelper.ReadData(2, "Active"));


        }

        internal ManageListing clickOnSaveBtn()
        {
            Driver.wait(20);
            // Click on Save button
            SaveBtn.Click();
            return new ManageListing();
            
        }
        // Update the description
        internal string EditShareSkill()
        {
            Description.Clear();
            string str = "2 hours session for Selenium!";
            Description.EnterText(str);
            return str;
        }

        // Select Radio button
        private void selectServiceRadioButton(IWebElement element, string type)
        {
            if (type == "One-off service")
            {
                element.FindElement(By.XPath("//div[@class='ui radio checkbox']/input[@value= '1' and @name='serviceType']")).Click();
            }
            else
            {
                element.FindElement(By.XPath("//div[@class='ui radio checkbox']/input[@value = '0' and @name='serviceType']")).Click();
            }
        }

        private void selectLocationRadioButton(IWebElement element, string type)
        {
            if (type == "On-site")
            {
                element.FindElement(By.XPath("//div[@class='ui radio checkbox']/input[@value = '0' and @name='locationType']")).Click();
            }
            else
            {
                element.FindElement(By.XPath("//div[@class='ui radio checkbox']/input[@value = '1' and @name = 'locationType']")).Click();
            }
        }

       /* private void selectStartDateAndTime()
        {

            StartDateDropDown.setDate(ExcelHelper.ReadData(2, "Startdate"));

            Driver.wait(20);

            EndDateDropDown.setDate(ExcelHelper.ReadData(2, "Enddate"));


            string weekDay = ExcelHelper.ReadData(2, "Selectday");

            switch (weekDay)
            {   //MOnday is default value
                case "Sun":
                    Days.FindElement(By.XPath("//div[2]/descendant::input[@index='0' and @name='Available']")).Click();
                    Days.FindElement(By.XPath("//div[2]/descendant::input[@index='0' and @name='StartTime']")).
                        setTime(ExcelHelper.ReadData(2, "Starttime"));
                    Days.FindElement(By.XPath("//div[2]/descendant::input[@index='0' and @name='EndTime']")).
                        setTime(ExcelHelper.ReadData(2, "Endtime"));
                    break;
                case "Tue":
                    Days.FindElement(By.XPath("//div[4]/descendant::input[@index='2' and @name='Available']")).Click();
                    Days.FindElement(By.XPath("//div[4]/descendant::input[@index='2' and @name='StartTime']")).
                        setTime(ExcelHelper.ReadData(2, "Starttime"));
                    Days.FindElement(By.XPath("//div[4]/descendant::input[@index='2' and @name='EndTime']")).
                        setTime(ExcelHelper.ReadData(2, "Endtime"));
                    break;
                case "Wed":
                    Days.FindElement(By.XPath("//div[5]/descendant::input[@index='3' and @name='Available']")).Click();
                    Days.FindElement(By.XPath("//div[5]/descendant::input[@index='3' and @name='StartTime']")).
                       setTime(ExcelHelper.ReadData(2, "Starttime"));
                    Days.FindElement(By.XPath("//div[5]/descendant::input[@index='3' and @name='EndTime']")).
                        setTime(ExcelHelper.ReadData(2, "Endtime"));
                    break;
                case "Thu":
                    Days.FindElement(By.XPath("//div[6]/descendant::input[@index='4' and @name='Available']")).Click();
                    Days.FindElement(By.XPath("//div[6]/descendant::input[@index='4' and @name='StartTime']")).
                        setTime(ExcelHelper.ReadData(2, "Starttime"));
                    Days.FindElement(By.XPath("//div[6]/descendant::input[@index='4' and @name='EndTime']")).
                        setTime(ExcelHelper.ReadData(2, "Endtime"));
                    break;
                case "Fri":
                    Days.FindElement(By.XPath("//div[7]/descendant::input[@index='5' and @name='Available']")).Click();
                    Days.FindElement(By.XPath("//div[7]/descendant::input[@index='5' and @name='StartTime']")).
                        setTime(ExcelHelper.ReadData(2, "Starttime"));
                    Days.FindElement(By.XPath("//div[7]/descendant::input[@index='5' and @name='EndTime']")).
                        setTime(ExcelHelper.ReadData(2, "Endtime"));
                    break;
                case "Sat":
                    Days.FindElement(By.XPath("//div[8]/descendant::input[@index='6' and @name='Available']")).Click();
                    Days.FindElement(By.XPath("//div[8]/descendant::input[@index='6' and @name='StartTime']")).
                        setTime(ExcelHelper.ReadData(2, "Starttime"));
                    Days.FindElement(By.XPath("//div[8]/descendant::input[@index='6' and @name='EndTime']")).
                        setTime(ExcelHelper.ReadData(2, "Endtime"));
                    break;
                default:
                    Days.FindElement(By.XPath("//div[3]/descendant::input[@index='1' and @name='Available']")).Click();
                    Days.FindElement(By.XPath("//div[3]/descendant::input[@index='1' and @name='StartTime']")).
                        setTime(ExcelHelper.ReadData(2, "Starttime"));
                    Days.FindElement(By.XPath("//div[3]/descendant::input[@index='1' and @name='EndTime']")).
                        setTime(ExcelHelper.ReadData(2, "Endtime"));
                    break;
            }

        }*/

        private void selectSkillTrade(IWebElement element, string skillTrade)
        {
            if (skillTrade == "Skill-Exchange")
            {
                element.FindElement(By.XPath("//div[@class='ui radio checkbox']/input[@value = 'true' and @name='skillTrades']")).Click();
                if (SkillExchange.Displayed && SkillExchange.Enabled)
                {
                    SkillExchange.SendKeys(ExcelHelper.ReadData(2, "Skill-Exchange"));
                    SkillExchange.SendKeys(Keys.Enter);
                }
                else
                {
                    Console.WriteLine("Skill Exchange textbox is not avaiable");
                    return;
                }
            }
            else if (skillTrade == "Credit")
            {
                IWebElement credit = element.FindElement(By.XPath("//div[@class='ui radio checkbox']/input[@value = 'false' and @name = 'skillTrades']"));
                credit.Click();
                Driver.wait(5);
                if (CreditAmount.Displayed && CreditAmount.Enabled)
                {
                    CreditAmount.SendKeys("1");
                }
                else
                {
                    Console.WriteLine("Credit textbox is not avaiable");
                    return;
                }
            }
        }

        private void selectActiveRadioButton(IWebElement element, string active)
        {
            if (active == "Active")
            {
                element.FindElement(By.XPath("//div[@class='ui radio checkbox']/input[@value = 'true' and @name='isActive']")).Click();

            }
            else if (active == "Hidden")
            {
                element.FindElement(By.XPath("//div[@class='ui radio checkbox']/input[@value = 'false' and @name ='isActive']")).Click();
            }
        }


        private void chooseSkillTrade(IWebElement element, string trade, string skillExc, string credit)
        {
            if (trade == "Skill-Exchange")
            {
                element.FindElement(By.XPath("//div[@class='ui radio checkbox']/input[@value = 'true' and @name='skillTrades']")).Click();
                if (SkillExchange.Displayed && SkillExchange.Enabled)
                {
                    SkillExchange.EnterText(skillExc);
                    SkillExchange.EnterText(Keys.Enter);
                }
                else
                {
                    Console.WriteLine("Skill Exchange textbox is not avaiable");
                    return;
                }
            }
            else if (trade == "Credit")
            {
                IWebElement Credit = element.FindElement(By.XPath("//div[@class='ui radio checkbox']/input[@value = 'false' and @name = 'skillTrades']"));
                Credit.Click();
                Driver.wait(5);
                if (CreditAmount.Displayed && CreditAmount.Enabled)
                {
                    CreditAmount.EnterText(credit);
                }
                else
                {
                    Console.WriteLine("Credit textbox is not avaiable");
                    return;
                }
            }
        }

    }
}
