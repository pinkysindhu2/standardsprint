﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMars.Framework.Extension
{
    public static class WebElementExtensionMethod
    {
        public static void selectFromDDL(this IWebElement element, string text)
        {
            new SelectElement(element).SelectByText(text);
        }
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }
        public static void setDate(this IWebElement element, string value)
        {
            if (value != null)
            {
                IList<string> txt = value.Split('/');
                for (int i = 0; i < txt.Count; i++)
                {
                    element.EnterText(txt[i]);
                    Console.WriteLine(txt[i]);
                    if (i < txt.Count && i == 1)
                    {
                        element.EnterText(Keys.Tab);
                    }
                }
            }
            else
            {
                Console.WriteLine($"{value} is null!");
            }
            Console.WriteLine("Get the Date from Date Picker: " + element.GetAttribute("value"));
/*            //string dateFormat = "dd/MM/yyyy";
            string dateFormat = "ddMMyyyy";
            string newDate = DateTime.Parse(value).ToString(dateFormat);

            element.EnterText(newDate);
            // Actions a = new Actions(driver);
            // a.keyDown(Keys.TAB).perform();
            //Driver.wait(30);

            Console.WriteLine("Date Formated: " + newDate);*/

        }

        public static void setTime(this IWebElement element, string value)
        {
            string timeFormat = "hh:mmtt";
            string newTime = DateTime.Parse(value).ToString(timeFormat);
            element.EnterText(newTime);
            Console.WriteLine("Time Formated: " + newTime);
            //Driver.wait(10);
        }
    }
}
