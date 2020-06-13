using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMars.Framework.Extension;
using ProjectMars.Framework.Helper;

namespace SpecflowPM.Tests.Pages.ShareAndManageSkill
{
    public class ManageListing : Account.Profile
    {
        public ManageListing(IWebDriver driver) : base(driver)
        {
            ExcelHelper.PopulateInCollection(PathHelper.GetCurrentPath("ExcelTestData/ShareSkillData.xlsx"), "ShareSkill");
        }

        #region Initlize web elements
        // table element
        private IWebElement table => Driver.WaitForElement(By.TagName("table"));
        // Delete the first Service into the table
        private IWebElement deleteBtn => Driver.WaitForElement(By.XPath("(//i[@class='remove icon'])[1]"));
        //Click on Yes or No
        private IWebElement clickActionsButton => Driver.WaitForElement(By.XPath("//div[@class='actions']"));

        #endregion

        // Click on Edit Button to update the Service
        public ServiceListing clickOnEdit()
        {
            int rowNumber = GetRowNumber(2);
            if (rowNumber >= 0)
            {
                IWebElement editBtn = Driver.WaitForElement(By.XPath($"(//i[@class='outline write icon'])[{rowNumber+1}]"));
                editBtn.Click();
                return new ServiceListing(Driver);
            }
            else
            {
                throw new Exception("Unable to find the service to edit into Table under Manage Listing");
            }
        }

        // Click on view Button to view the full info about Service
        public ServiceCompleteDetails clickOnView()
        {
            int rowNumber = GetRowNumber(2);
            if (rowNumber >= 0)
            {
                IWebElement viewBtn = Driver.WaitForElement(By.XPath($"(//i[@class='eye icon'])[{rowNumber+1}]")); ;
                viewBtn.Click();
                return new ServiceCompleteDetails(Driver);
            }
            else
            {
                throw new Exception("Unable to find the service to view into Table under Manage Listing");
            }
        }

        public int clickOnDelete()
        {
            int before = GetTotalRowsIntoTable();
            deleteBtn.Click();
            if (clickActionsButton.Displayed && clickActionsButton.Enabled)
            {
                clickActionsButton.FindElement(By.XPath("//div[@class='actions']/button[2]")).Click();
                Driver.wait(15);
            }
            else
            {
                throw new Exception("Unbale to see the popup for Deleting the service"); 
            }
            return before;
        }
        // newly created service is listed or not
        public bool isServiceSaved(int rowNumber)
        {
            IWebElement tbody = table.FindElement(By.XPath("//tbody"));
            IList<IWebElement> rows = tbody.FindElements(By.XPath("//tbody/tr"));
            for (int i = 0; i < rows.Count; i++)
            {                
                if(rows[i].FindElement(By.XPath("//td[2]")).Text.Equals(ExcelHelper.ReadData(rowNumber, "Category"))
                    && rows[i].FindElement(By.XPath("//td[3]")).Text.Equals(ExcelHelper.ReadData(rowNumber, "Title"))
                    && rows[i].FindElement(By.XPath("//td[4]")).Text.Equals(ExcelHelper.ReadData(rowNumber, "Description")))
                {
                    return true;
                }
            }
            return false;
        }

        private int GetRowNumber(int rowNumber)
        {
            {
                IWebElement tbody = table.FindElement(By.XPath("//tbody"));
                IList<IWebElement> rows = tbody.FindElements(By.XPath("//tbody/tr"));
                for (int i = 0; i < rows.Count; i++)
                {
                    if (rows[i].FindElement(By.XPath("//td[2]")).Text.Equals(ExcelHelper.ReadData(rowNumber, "Category"))
                        && rows[i].FindElement(By.XPath("//td[3]")).Text.Equals(ExcelHelper.ReadData(rowNumber, "Title"))
                        && rows[i].FindElement(By.XPath("//td[4]")).Text.Equals(ExcelHelper.ReadData(rowNumber, "Description")))
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        public int GetTotalRowsIntoTable()
        {
            Driver.Navigate().Refresh();
            IWebElement tbody = table.FindElement(By.XPath("//tbody"));
            IList<IWebElement> rows = tbody.FindElements(By.XPath("//tbody/tr"));
            return rows.Count;
        }
/*
        

        internal ServiceListing viewListedService()
        {
            GlobalDefinitions.wait(10);
            IList<String> list = new List<String>();
            if (verifyListingAvabilability())
            {

                var title = table.FindElement(By.XPath("//table/tbody/tr[1]/td[3]")).Text;
                list.Add(title);
                var category = table.FindElement(By.XPath("//table/tbody/tr[1]/td[2]")).Text;
                list.Add(category);
                var description = table.FindElement(By.XPath("//table/tbody/tr[1]/td[4]")).Text;
                list.Add(description);
                var serviceType = table.FindElement(By.XPath("//table/tbody/tr[1]/td[5]")).Text;
                list.Add(serviceType);

                view.Click();

            }
            if (list.Count != 0)
            {
                return new ServiceListing(list);
            }
            else
            {
                return null;
            }
        }

        //Check the edit is success or not
        internal void isServiceUpdated(string description)
        {
            GlobalDefinitions.wait(10);
            if (verifyListingAvabilability())
            {
                IWebElement desc = table.FindElement(By.XPath("//table/tbody/tr[1]/td[4]"));
                Assert.That(desc.Text, Is.EqualTo(description));
            }

        }


        // Checking the Deleted  Service is not listed
        private void isServiceListed(int totalRows, int currentRows, string methodName)
        {
            Console.WriteLine("Total Rows: " + totalRows + " Current Rows: " + currentRows);
            if (methodName == "Delete")
            {
                Driver.wait(30);
                Assert.That(currentRows, Is.LessThan(totalRows));
            }
            else if (methodName == "Save")
            {
                Assert.Multiple(() => {
                    Driver.wait(30);
                    Assert.That(GlobalDefinitions.driver.Url, Is.EqualTo(url));
                    Assert.That(currentRows, Is.GreaterThan(totalRows));
                });

            }

        }

        // Delete a service with name of Selenium
        internal void deleteListedService()
        {
            //click on Manage Listimg tab
            clickOnManageListing();
            // Click on Delete button
            if (verifyListingAvabilability())
            {
                // Before Delete option
                int totalRow = getTotalRows();

                delete.Click();

                if (clickActionsButton.Displayed && clickActionsButton.Enabled)
                {
                    clickActionsButton.FindElement(By.XPath("//div[@class='actions']/button[2]")).Click();
                    GlobalDefinitions.wait(15);
                    if (verifyListingAvabilability())
                    {

                        int currentRows = getTotalRows();
                        isServiceListed(totalRow, currentRows, "Delete");

                    }
                }
                else
                {
                    Assert.Fail("Unable to delete");
                }
            }
            else
            {
                Assert.Warn("No Service is listed for delete!");
            }



        }

        // check the Selenium named Service is available to perform Actions: View, Edit and delete
        private bool verifyListingAvabilability()
        {
            return table.Displayed && table.Enabled;
        }

        private int getTotalRows()
        {
            Driver.wait(20);
            IWebElement tbody = table.FindElement(By.XPath("//tbody"));
            IList<IWebElement> rows = tbody.FindElements(By.XPath("//tbody/tr"));
            return rows.Count;
        }*/
    }
}
