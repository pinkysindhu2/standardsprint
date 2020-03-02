using OpenQA.Selenium;
using SpecflowPM.Tests.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using ProjectMars.Framework.Extension;
using OpenQA.Selenium.Interactions;

namespace SpecflowPM.Tests.Pages
{
    public class Category : BasePage
    {
        private readonly IWebDriver Driver;

        public Category(IWebDriver driver)
        {
            this.Driver = driver;
        }

        #region Initialize the WebElements

        private IWebElement exploreCategory => Driver.WaitForElement(By.XPath("//h3[contains(text(),'Explore categories>')]"));
        private IWebElement GraphicDesign => Driver.FindElement(By.XPath("//div[@class='ui grid explore-category']//div[1]//div[1]"));

        private IWebElement digitalMarketing => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[1]//div[2]"));

        private IWebElement writtingTranslation => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[1]//div[3]"));

        private IWebElement videoAnimation => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[1]//div[4]"));

        private IWebElement musicAudio => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[2]//div[1]"));

        private IWebElement progTech => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[2]//div[2]"));

        private IWebElement business => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[2]//div[3]"));

        private IWebElement funLifestyle => Driver.WaitForElement(By.XPath("//div[@class='ui grid explore-category']//div[2]//div[4]"));
        #endregion

       public void scrollDownToCategory()
       {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(exploreCategory);
            actions.Perform();
       }

       public SearchService SearchCateory(string cat)
       {
            SearchService searchService = null;
            switch (cat)
            {
                case "Graphics Design":           
                    GraphicDesign.Click();
                    searchService = new SearchService(Driver);                
                    break;
                case "Digital Marketing":
                    digitalMarketing.Click();
                    searchService = new SearchService(Driver);
                    break;
                case "Writing Translation":
                    writtingTranslation.Click();
                    searchService = new SearchService(Driver);
                    break;
                case "Video Animation":
                    videoAnimation.Click();
                    searchService = new SearchService(Driver);
                    break;
                case "Music Audio":
                    musicAudio.Click();
                    searchService = new SearchService(Driver);
                    break;
                case "Programming Tech":
                    progTech.Click();
                    searchService = new SearchService(Driver);
                    break;
                case "Business":
                    business.Click();
                    searchService = new SearchService(Driver);
                    break;
                case "Fun Lifestyle":
                    funLifestyle.Click();
                    searchService = new SearchService(Driver);
                    break;
            }
            return searchService;
       }
        


    }
}
