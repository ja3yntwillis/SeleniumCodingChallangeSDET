using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;

namespace SeleniumCodingChallangeSDET.CommonReusables.Utils
{
    public class Reporting
    {
        private ExtentReports extent;

        public Reporting()
        {
            extent = new ExtentReports();
            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
            Directory.CreateDirectory(reportPath);
            ExtentSparkReporter spark = new ExtentSparkReporter(Path.Combine(reportPath, "Report_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html"));
            extent.AttachReporter(spark);
        }

        public ExtentTest GetTestIntent(string testName, string testDesc)
        {
            ExtentTest test = extent.CreateTest(testName, testDesc);
            return test;
        }

        public void FlushExtent()
        {
            extent.Flush();
        }
    }
}
