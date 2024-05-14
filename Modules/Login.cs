using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.UIReusables;
using SeleniumCodingChallangeSDET.CommonReusables.Utils;
using SeleniumCodingChallangeSDET.Pages;
using SeleniumCodingChallangeSDET.PageSteps;

namespace SeleniumCodingChallangeSDET.Modules
{
    public class Login : WebPageActions
    {
        private LoginPageSteps loginPageSteps;

        public Login(IWebDriver driver) : base(driver)
        {
            loginPageSteps = new LoginPageSteps(driver);
        }

        public void LoggingIn(string username, string password)
        {
            loginPageSteps.EnterUsername(username);
            loginPageSteps.EnterPassword(password);
            loginPageSteps.ClickLogin();
        }

        public void ValidateLoginErrorMessage(string ExpectedErrorMessage)
        {
            Assert.AreEqual(ExpectedErrorMessage, loginPageSteps.GetErrorMessage());
        }
    }
}
