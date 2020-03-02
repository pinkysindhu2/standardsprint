using BoDi;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using SpecflowPM.Tests.Config;
using AventStack.ExtentReports;
using System.Collections.Generic;
using ProjectMars.Framework.Base;
using SpecflowFeature = AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Gherkin.Model;

namespace SpecflowPM.Tests.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private static ExtentTest _featureName;
        private static ExtentTest _scenario;

        [BeforeTestRun]
        public static void BeforeTestRun(IObjectContainer objectContainer)
        {
            //TODO: implement logic that has to run before executing each test 
            // Initiate the all the framework settings such as base url, extend reports
            new InitFrameworkHook().InitFramework(objectContainer);

        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureName = ExtendReportContext.ExtentReport.CreateTest<SpecflowFeature.Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            //TODO: implement logic that has to run before executing each scenario
            _scenario = _featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            switch (stepType)
            {
                case "Given":
                    if(scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text)
                            .Fail(scenarioContext.TestError.Message)
                            .Log(Status.Error, scenarioContext.TestError.Message);
                    }
                    else
                    {
                        _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                    }
                    break;
                case "When":
                    if (scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text)
                            .Fail(scenarioContext.TestError.Message)
                            .Log(Status.Error, scenarioContext.TestError.Message);
                    }
                    else
                    {
                        _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                    }
                    break;
                case "Then":
                    if (scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text)
                            .Fail(scenarioContext.TestError.Message)
                            .Log(Status.Error, scenarioContext.TestError.Message);
                    }
                    else
                    {
                        _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                    }
                    break;
                case "And":
                    if (scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text)
                            .Fail(scenarioContext.TestError.Message)
                            .Log(Status.Error, scenarioContext.TestError.Message);
                    }
                    else
                    {
                        _scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
                    }
                    break;
            }
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            //TODO: implement logic that has to run after executing each scenario
            //scenarioContext;
        }

        
        [AfterTestRun]
        public static void AfterTestRun(IWebDriver driver)
        {
            driver.Close();
            ExtendReportContext.ExtentReport.Flush();
        }
    }
}
