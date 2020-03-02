using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ProjectMars.Framework.Extension
{
    public static class DriverExtensionMethods
    {
        public static void wait(this IWebDriver driver, int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }

        public static IWebElement WaitForElement(this IWebDriver driver, By ele, int timeOutinSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return (wait.Until(ExpectedConditions.ElementIsVisible(ele)));
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                throw ex;
            }
            
        }

        public static void pageLoad(this IWebDriver driver, int timeOutinSeconds = 30)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeOutinSeconds);
        }
    }
}
