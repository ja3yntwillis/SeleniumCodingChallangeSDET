﻿using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.UIReusables;
using SeleniumCodingChallangeSDET.Pages;

namespace SeleniumCodingChallangeSDET.PageSteps
{
    public class LoginPageActions : WebPageActions
    {
        private LoginPage loginPage;

        public LoginPageActions(IWebDriver driver) : base(driver)
        {
            loginPage = new LoginPage();
        }

        public void EnterUsername(string username)
        {
            SendValue(loginPage.UsernameInput, username);
        }

        public void EnterPassword(string password)
        {
            SendValue(loginPage.PasswordInput, password);
        }

        public void ClickLogin()
        {
            Click(loginPage.LoginButton);
        }

        public string GetErrorMessage()
        {
            return GetText(loginPage.ErrorMessage);
        }
    }
}
