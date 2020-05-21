using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMars.Framework.CustomExceptions;
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

        public static IList<IWebElement> WaitForElements(this IWebDriver driver, By ele, int timeOutinSeconds = 20)
        {
            IList<IWebElement> list;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                list = (wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(ele)));
                
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex)
                list = driver.FindElements(ele);
                //throw new TimeOutException("List is empty!!");
            }
            return list;
        }

        public static void pageLoad(this IWebDriver driver, int timeOutinSeconds = 30)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeOutinSeconds);
        }

        public static IWebElement FindElementWithText(this IWebDriver driver, string tagName, string text)
        {
            return driver.WaitForElement(By.XPath("//"+tagName+"[contains(text(),'"+text+"')]"));
        }

    }
}
