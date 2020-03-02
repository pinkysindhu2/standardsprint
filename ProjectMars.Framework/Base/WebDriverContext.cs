using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using BoDi;

namespace ProjectMars.Framework.Base
{
    public class WebDriverContext
    {
        public IWebDriver Driver { get; set; }
        public static IObjectContainer _objectContainer;

        public WebDriverContext(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

            Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();

            _objectContainer.RegisterInstanceAs(Driver);
        }
    }
}
