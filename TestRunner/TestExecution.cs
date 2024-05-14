using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.Configuration;
using SeleniumCodingChallangeSDET.CommonReusables.Driver;
using SeleniumCodingChallangeSDET.CommonReusables.UI;
using SeleniumCodingChallangeSDET.CommonReusables.Utils;
using SeleniumCodingChallangeSDET.Tests;

namespace SeleniumCodingChallangeSDET.TestRunner
{
    internal class TestExecution
    {
        Reporting extent;
        IWebDriver driver;
        Config ConfigObject;
        LoginTest loginTest;
        WorkflowTest workflowTest;
        System.Configuration.Configuration config;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent = new Reporting();
            ConfigObject = new Config();
            config = ConfigObject.GetConfig();
            driver = Driver.GetDriver(ConfigObject.findValueOfAConfiguration(config, "browsername"));
            loginTest = new LoginTest(extent, driver);
            workflowTest = new WorkflowTest(extent, driver);

        }
        [Test]
        public void TestCase1_SuccessfulLoginAndLogoutTestFlow()
        {
            loginTest.TestCase_SuccessfulLoginAndLogout();
        }
        [Test]
        public void TestCase2__FailedLoginTestFlow()
        {
            loginTest.TestCase_FailedLogin();
        }
        [Test]
        public void TestCase3_MultipleScenarioWorkflow() {

            workflowTest.TestCase_MultipleScenarioWorkflow();
        }
        [Test]
        public void TestCase4_ErrorUserTestFlow()
        {

            workflowTest.TestCase_ErrorUser();
        }
        [Test]
        public void TestCase5_BorwserRefreshTestFlow()
        {

            workflowTest.TestCase_BrowserRefresh();
        }
        [Test]
        public void TestCase6_PerformenceUserTestFlow()
        {

            workflowTest.TestCase_PerformenceUser();
        }
        [Test]
        public void TestCase7_BounsTestFlow()
        {
            workflowTest.TestCase_BonusTest();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            driver.Quit();
            extent.FlushExtent();
        }
    }
}
