using System;
using System.Text;
using System.Collections.Generic;
using AventStack.ExtentReports.Reporter;
using ProjectMars.Framework.Helper;
using ProjectMars.Framework.Config;

namespace ProjectMars.Framework.Base
{
    public class ExtendReportContext
    {
        public static AventStack.ExtentReports.ExtentReports ExtentReport { get; set; }
        public ExtendReportContext()
        {
            ExtentReport = new AventStack.ExtentReports.ExtentReports();
            // store the Report
            var path = PathHelper.GetCurrentPath(Settings.ExtendReportPath);
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            ExtentReport.AttachReporter(htmlReporter); 
        }

    }
}
