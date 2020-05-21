using OpenQA.Selenium;
using SpecflowPM.Tests.Pages.Home;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectMars.Framework.Extension;

namespace SpecflowPM.Tests.Pages.Account
{
    public class ProfileSettings: Profile
    {
        public ProfileSettings(IWebDriver driver): base(driver) { }

        #region Initialize the webelements under the Trader Names(Hi Pinky)
        private IWebElement changePassword => Driver.WaitForElement(By.XPath("//a[contains(text(),'Change Password')]"));
        #endregion

        public void ChangePassword()
        {
            changePassword.Click();
        }
        
    }
}
