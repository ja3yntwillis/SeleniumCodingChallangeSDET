using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.Configuration;
using SeleniumCodingChallangeSDET.CommonReusables.UI;
using SeleniumCodingChallangeSDET.CommonReusables.Utils;
using SeleniumCodingChallangeSDET.Modules;
using SeleniumCodingChallangeSDET.PageSteps;
using SeleniumCodingChallangeSDET.TestData;

namespace SeleniumCodingChallangeSDET.Tests
{
    public class LoginTest:LoginTestData
    {
        private Reporting extent;
        private ExtentTest test;
        private System.Configuration.Configuration config;
        private Config ConfigObject;
        private IWebDriver driver;
        private Login LoginObject;
        private BrowserActions BrowserActionsObj;
        private InventoryPageActions InventoryPageSteps;
        private CaptureScreenshot CaptureScreenshotObj;
        private string url;

        public LoginTest(Reporting extent, IWebDriver driver):base()
        {
            this.extent = extent;
            ConfigObject = new Config();
            
            config = ConfigObject.GetConfig();
            url = ConfigObject.findValueOfAConfiguration(config, "url");
            this.driver = driver;
            LoginObject = new Login(driver);
            InventoryPageSteps = new InventoryPageActions(driver);
            CaptureScreenshotObj = new CaptureScreenshot(driver);
            BrowserActionsObj = new BrowserActions(driver);
        }

        public void TestCase_SuccessfulLoginAndLogout()
        {
            test = extent.GetTestIntent("TestCase_SuccessfulLoginAndLogout", "Verify successful login and logout");
            try
            {
                // Start Test
                BrowserActionsObj.OpenUrl(url);
                test.Log(Status.Info, "Browser Opened");

                // Login to the Website
                LoginObject.LoggingIn(standard_user, standarduserpassword);
                test.Log(Status.Pass, "Login Successful.", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());

                // Process Logging out
                InventoryPageSteps.ClickOpenItemsMenu();
                InventoryPageSteps.ClickLogOut();
                test.Log(Status.Pass, "Logged out successfully.", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.StackTrace, MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
            }
        }

        public void TestCase_FailedLogin()
        {
            test = extent.GetTestIntent("TestCase_FailedLogin", "Verify a Failed Login");
            try
            {
                // Start Test
                BrowserActionsObj.OpenUrl(url);
                test.Log(Status.Info, "Browser Opened");

                // Login to the Website
                LoginObject.LoggingIn(locked_out_user, lockedoutuserpassword);

                // Validation of error message
                LoginObject.ValidateLoginErrorMessage(lockedoutusererror);
                test.Log(Status.Pass, "Login unsuccessful.", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.StackTrace, MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
            }
        }
    }
}
