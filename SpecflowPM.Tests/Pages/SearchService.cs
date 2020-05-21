using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectMars.Framework.Extension;
using NUnit.Framework;
using Newtonsoft.Json;

namespace SpecflowPM.Tests.Pages
{
    public class SearchService : BasePage
    {
        private readonly IWebDriver Driver;

        public SearchService(IWebDriver driver)
        {
            this.Driver = driver;
        }

        #region Initialize the WebElements
        //  private IWebElement searchBoxUp => Driver.WaitForElement()
        private IWebElement seachBoxDown => Driver.WaitForElement(By.XPath("//section[@class='search-results']/descendant::div[@class='four wide column']/descendant::input[@placeholder='Search skills']"));

        private IWebElement searchUser => Driver.WaitForElement(By.XPath("//section[@class='search-results']/descendant::div[@class='four wide column']/descendant::input[@placeholder='Search user']"));

        private IWebElement searchPage => Driver.WaitForElement(By.Id("service-search-section"));

        private IWebElement skillResult => Driver.WaitForElement(By.ClassName("search-results"));

        private IList<IWebElement> Categories;

        //private IList<IWebElement> ResultList;

        //private IWebElement ResultMessage;
        private IWebElement ResultArea => Driver.WaitForElement(By.XPath("//section[@class='search-results']/descendant::div[@class='twelve wide column']/div[@class='ui grid']"));

        private IList<IWebElement> ResultList => Driver.WaitForElements(By.XPath("//section[@class='search-results']/descendant::div[@class='twelve wide column']/div[@class='ui grid']/descendant::div[@class='ui stackable three cards']/div[@class='ui card']"));

        private IWebElement ResultMessage => Driver.WaitForElement(By.XPath("//section[@class='search-results']/descendant::div[@class='twelve wide column']/div[@class='ui grid']/h3"));

        // Filter web elements
        private IWebElement online => Driver.FindElementWithText("button", "Online");
        private IWebElement onsite => Driver.FindElementWithText("button", "Onsite");
        private IWebElement showAll => Driver.FindElementWithText("button", "ShowAll");

        #endregion Initialized WebElements

        public void ClickOnSubCategory(string subcat)
        {
            IWebElement subCategory = Driver.FindElementWithText("a", subcat);
            subCategory.Click();
            Categories = Driver.FindElements(By.XPath("//section[@class='search-results']/descendant::div[@class='ui link list']/a"));

        }

        public void VerifyCategorySearch(string cat, int index, int subIndex)
        {
            Driver.wait(20);
            bool active = false;
            bool subactive = false;
            bool resultStatus = false;

            if (skillResult.Displayed && skillResult.Enabled && Categories.Count != 0)
            {
                // First the url
                var currentUrl = Driver.Url;
                var expectedURL = "http://192.168.99.100:5000/Home/Search?cat=" + cat.Replace(" ", "") + "&subcat=" + subIndex;

                /*// correct index presernt into searchPage arttribute in the list:            
                var jsonString = searchPage.GetAttribute("data-search-terms");
                var attribute = jsonString.Contains("categoryIndex:'" + index + "' ");
                Console.WriteLine(attribute);
                */

                // Active category
                foreach (var ele in Categories)
                {
                    if (ele.GetAttribute("class").StartsWith("active") && ele.GetAttribute("class").EndsWith("category"))
                    {
                        active = true;
                        break;
                    }
                    Console.WriteLine("Element {0} with class attributes {1}", ele, ele.GetAttribute("class"));

                }
                // Active subcategory
                foreach (var ele in Categories)
                {
                    if (ele.GetAttribute("class").StartsWith("active") && ele.GetAttribute("class").EndsWith("subcategory"))
                    {
                        subactive = true;
                        break;
                    }
                    Console.WriteLine("Element {0} with class attributes {1}", ele, ele.GetAttribute("class"));
                }
                // Check the search result
                //Console.WriteLine(ResultMessage.FindElement(By.TagName("h3")).Text);
                resultStatus = isResultListEmptyOrMsg();


                if (resultStatus)
                {
                    // Assertions
                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual(expectedURL, currentUrl);
                        Assert.AreEqual(true, active);
                        Assert.AreEqual(true, subactive);
                        Assert.Greater(ResultList.Count, 0);

                    });
                }
                else
                {
                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual(expectedURL, currentUrl);
                        Assert.AreEqual(true, active);
                        Assert.AreEqual(true, subactive);
                        Assert.AreEqual(ResultMessage.Text, "No results found, please select a new category!");

                    });
                }

            }
            else
            {
                Assert.Fail("Categories, Subcategories and Results are not found!!!");
            }
        }

        //Verify AllCategory WebElement is active and Skills are displayed if available 
        public int TotalSkillsDisplayed()
        {
            int totals = 0;
            if (skillResult.Displayed && skillResult.Enabled)
            {
                totals = Int16.Parse(GetAllCategoryTotals());

            }
            else
            {
                Assert.Fail("No skill is displayed so come again!");
            }
            return totals;

        }

        //Click on Filters: Online , Offline and ShowAll
        public int ClickOnFilers(string filter)
        {
            int total;
            switch (filter)
            {
                case "Online":
                    online.Click();
                    total = Int16.Parse(GetAllCategoryTotals());
                    break;
                case "Onsite":
                    onsite.Click();
                    total = Int16.Parse(GetAllCategoryTotals());
                    break;
                default: //ShowAll
                    showAll.Click();
                    total = Int16.Parse(GetAllCategoryTotals());
                    break;
            }
            return total;

        }

        // Verify Result with Filters: Online , Offline and ShowAll
        public void VerifyResultwithFilter(int totalSkills, int refineSkills, string filter)
        {
            int current = Int16.Parse(GetAllCategoryTotals());
            if (filter == "Online" || filter == "Onsite")
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(current, refineSkills);
                    Assert.Less(current, totalSkills);
                });
            }
            else if (filter == "ShowAll")
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(current, refineSkills);
                    Assert.LessOrEqual(current, totalSkills);
                });
            }
            else
            {
                Assert.Fail("Result is not successfully refined!");
            }
        }

        //Check the user is present into the list and Click on the user
        public void GetUserFromDDL(string name)
        {
            if (searchUser.Displayed)
            {
                searchUser.SendKeys(name);
                // Get the users
                IList<IWebElement> UsersDDL = Driver.WaitForElements(By.XPath("//div[@class='results transition visible']/div[@class='result']"));

                if (UsersDDL.Count != 0)
                {
                    foreach (var user in UsersDDL)
                    {
                        string userName = user.FindElement(By.XPath("//div/span")).Text;
                        if (userName.Equals(name))
                        {
                            user.Click();
                            break;
                        }
                    }
                }
            }
        }

        // Verify Result is listed as per user
        public void VerifyUserServicesListed(string name)
        {
            int total = Int16.Parse(GetAllCategoryTotals());
            int countSuccessRate = 0;
            if (total >= 1)
            {
                if(ResultList.Count != 0)
                {
                    //check result contains searched skill
                    foreach (var item in ResultList)
                    {
                        string sellerName = item.FindElement(By.XPath("//div/a[@class='seller-info']")).Text.ToLower();
                        if (sellerName.Equals(name.ToLower()))
                        {
                            countSuccessRate++;
                        }
                    }
                    Assert.Multiple(() =>
                    {
                        Assert.GreaterOrEqual(countSuccessRate, ResultList.Count);
                        //Assert.AreEqual(Driver.Url, "http://192.168.99.100:5000/Home/Search?searchString=" + skill);
                    });
                }
            }
            else
            {
                Assert.Fail(name + " is not registered!");
            }
        }

        public void TypeSkillIntoSearchBox(string skill)
        {
            if (seachBoxDown.Displayed)
            {
                seachBoxDown.SendKeys(skill + Keys.Enter);
            }
        }

        /* 
         * Verfiy Skills are displyed regarding the word typed into search box
         * Going to check on first Page as the most relevant result should be displayed on first page of the serach result
         */
        public void VerifySearchedSkill(string skill)
        {
            Driver.wait(10);
            int total = Int16.Parse(GetAllCategoryTotals());
            int countSuccessRate = 0;
            if (total != 0)
            {
                if(ResultList.Count != 0) {
                    //check result contains searched skill
                    foreach (var item in ResultList)
                    {
                        string serviceName = item.FindElement(By.XPath("//div/a[@class='service-info']/p")).Text.ToLower();
                        if (serviceName.Contains(skill.ToLower()))
                        {
                            countSuccessRate++;
                        }
                    }
                    Assert.Multiple(() =>
                    {
                        Assert.GreaterOrEqual(countSuccessRate, 1);
                        //Assert.AreEqual(Driver.Url, "http://192.168.99.100:5000/Home/Search?searchString="+skill);
                    });
                }

            }
            else if (total == 0 && ResultMessage.Displayed)
            {
                Assert.AreEqual(ResultMessage.Text, "No results found, please select a new category!");
            }
            else
            {
                Assert.Fail(skill + " is not found!");
            }
        }



        //check AllCategory is active as well as the totals are changing
        private string GetAllCategoryTotals()
        {
            var AllCat = Driver.WaitForElement(By.XPath("//a[@class='active item']"));
            string total = null;
            Driver.wait(10);
            if (AllCat.Displayed && AllCat.Enabled)
            {
                var span = AllCat.FindElement(By.XPath(".//span"));
                total = span.Text;
            }
            return total;
        }

        // Check if Result List is empty or it has no skill into list 
        private bool isResultListEmptyOrMsg()
        {
            bool resultStatus = false;
/*            if(ResultArea.Displayed && ResultArea.Enabled)
             {
                 Console.WriteLine("Length of ARea "+ ResultArea.FindElement())
             }*/
             
            if (ResultList.Count > 0)
            {
                resultStatus = true;
            }
            else if (ResultMessage.Displayed && ResultArea.Text.Equals("No results found, please select a new category!"))
            {
                resultStatus = false;
            }
            else
            {
                Assert.Fail("Something went wrong!! when trying to fetch the list or displaying the result message!!");
            }
            return resultStatus;
        }

        /*private void  SetResultListOrMsg()
        {
            ResultList = ResultArea.FindElements(By.XPath("//descendant::div[@class='ui stackable three cards']/div[@class='ui card']"));
            ResultMessage = ResultArea.FindElement(By.TagName("h3"));
        }*/
    }
}
