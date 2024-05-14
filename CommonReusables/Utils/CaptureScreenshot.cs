using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.Driver;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCodingChallangeSDET.CommonReusables.Utils
{
    internal class CaptureScreenshot
    {
        public WebDriver driver;

        public CaptureScreenshot(IWebDriver driver)
        {
            this.driver = (WebDriver)driver;
        }
        public string CaptureScreen()
        {
            string screenshotDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Screenshots");
            if (!Directory.Exists(screenshotDirectory))
                Directory.CreateDirectory(screenshotDirectory);

            string screenshotPath = Path.Combine(screenshotDirectory, $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMddHHmmss}.png");

            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(screenshotPath);

            return screenshotPath;
        }
    }
}
