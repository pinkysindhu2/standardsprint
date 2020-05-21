using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowPM.Tests.Steps
{
    [Binding]
    public class BaseSteps: Config.PageInstances
    {
        [Given(@"I am in Profile page")]
        public void GivenIAmInProfilePage()
        {
            profile.LoginSuccess();

        }
    }
}
