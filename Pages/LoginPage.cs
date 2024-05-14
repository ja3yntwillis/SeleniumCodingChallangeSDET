using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCodingChallangeSDET.Pages
{
    public class LoginPage
    {

        public By UsernameInput = By.Id("user-name");
        public By PasswordInput = By.Id("password");
        public By LoginButton = By.Id("login-button");
        public By ErrorMessage = By.XPath("//h3[@data-test='error']");

    }
}
