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
    public class Certificate: ProfileSection
    {
        public Certificate(IWebDriver driver) : base(driver)
        {
            ExcelHelper.PopulateInCollection(PathHelper.GetCurrentPath("ExcelTestData/ProfileData.xlsx"), "Certification");
        }

        #region initialize Certificate web elements
        private IWebElement CertificateForm => Driver.WaitForElement(By.XPath("//div[@data-tab='fourth']/descendant::div[@class='fields']"));
        private IWebElement addNew => Driver.WaitForElement(By.XPath("//div[@data-tab='fourth']/descendant::table/thead/tr/th[4]/div"));
        private IWebElement certificateName => Driver.WaitForElement(By.CssSelector("input[name='certificationName'"));
        private IWebElement certifiedFrom => Driver.WaitForElement(By.CssSelector("input[name='certificationFrom']"));
        private IWebElement year => Driver.WaitForElement(By.CssSelector("select[name='certificationYear'"));
        private IWebElement addCertificate => Driver.WaitForElement(By.CssSelector("input[value='Add']"));
        private IWebElement cancelCertificate => Driver.WaitForElement(By.CssSelector("input[value='Cancel']"));
        private IList<IWebElement> tbody => Driver.WaitForElements(By.XPath("//div[@data-tab='fourth']/descendant::table/tbody"));
        private IWebElement editBtn => Driver.WaitForElement(By.XPath("//div[@data-tab='fourth']/descendant::table/tbody[1]/tr/td[4]/span[1]"));
        private IWebElement updateBtn => Driver.WaitForElement(By.XPath("//input[@value='Update']"));
        private IWebElement deleteBtn => Driver.WaitForElement(By.XPath("//div[@data-tab='fourth']/descendant::table/tbody[1]/tr/td[4]/span[2]"));
        #endregion

        public void AddCertificate()
        {
            addNew.Click();
            Driver.wait(4);
            certificateName.SendKeys(ExcelHelper.ReadData(2, "Certification/Award Name"));
            certifiedFrom.SendKeys(ExcelHelper.ReadData(2, "Certified From"));
            year.selectFromDDL(ExcelHelper.ReadData(2, "Year"));
            Driver.wait(2);
            addCertificate.Click();
        }

        public bool AddCertificateSuccess()
        {
            return CertificateSuccess(ExcelHelper.ReadData(2, "Certification/Award Name"),
                ExcelHelper.ReadData(2, "Certified From"),
                ExcelHelper.ReadData(2, "Year"));
        }

        //check if 1 or more Certificate is available for edit or delete
        public int IsCertificateAvailable()
        {
            //count how many tbody is present into table
            return tbody.Count;

        }
        // Edit the First Education 
        public void UpdateCertificate()
        {
            editBtn.Click();
            Driver.wait(4);
            certificateName.Clear();
            certificateName.SendKeys(ExcelHelper.ReadData(3, "Certification/Award Name"));
            certifiedFrom.Clear();
            certifiedFrom.SendKeys(ExcelHelper.ReadData(3, "Certified From"));
            year.selectFromDDL(ExcelHelper.ReadData(3, "Year"));
            Driver.wait(2);
            updateBtn.Click();
        }

        public bool UpdateCertificateSuccess()
        {
            return CertificateSuccess(ExcelHelper.ReadData(3, "Certification/Award Name"),
                ExcelHelper.ReadData(3, "Certified From"),
                ExcelHelper.ReadData(3, "Year"));
        }

        public void DeleteCertificate()
        {
            Driver.wait(6);
            deleteBtn.Click();
        }

        public bool DeleteCertificateSuccess()
        {
            return CertificateSuccess(ExcelHelper.ReadData(3, "Certification/Award Name"),
                ExcelHelper.ReadData(3, "Certified From"),
                ExcelHelper.ReadData(3, "Year"));
        }

        public void CancelCertificate()
        {
            addNew.Click();
            Driver.wait(2);
            cancelCertificate.Click();
        }
        public bool CancelCertificateSuccess()
        {
            return CertificateForm.Displayed ? true : false;
        }
        private bool CertificateSuccess(string name, string from, string year)
        {
            Driver.wait(15);
            bool status = false;
            if (tbody.Count > 0)
            {
                for (int i = 0; i < tbody.Count; i++)
                {
                    var Name = tbody[i].FindElement(By.XPath("//tr/td[1]"));
                    var From = tbody[i].FindElement(By.XPath("//tr/td[2]"));
                    var Year = tbody[i].FindElement(By.XPath("//tr/td[3]"));


                    if (Name.Text == name && From.Text == from && Year.Text == year)
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
