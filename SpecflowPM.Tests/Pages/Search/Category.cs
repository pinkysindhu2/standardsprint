using OpenQA.Selenium;
using SpecflowPM.Tests.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using ProjectMars.Framework.Extension;
using OpenQA.Selenium.Interactions;
using SpecflowPM.Tests.Pages;


namespace SpecflowPM.Tests.Pages.Search
{
    public class Category: Home.HomePage
    {

        public Category(IWebDriver driver): base(driver) { }

        public SearchService ClickOnSearchBtn()
        {
            searchBtn.Click();
            Driver.pageLoad();
            return new SearchService(Driver);
        }
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
