using SeleniumCodingChallangeSDET.CommonReusables.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCodingChallangeSDET.TestData
{
    public class LoginTestData:Config
    {
        public LoginTestData():base() { }
        public string standard_user = ParseJson(".TestCase_SuccessfulLoginAndLogout.username");
        public string standarduserpassword = ParseJson(".TestCase_SuccessfulLoginAndLogout.password");
        public string locked_out_user = ParseJson(".TestCase_FailedLogin.username");
        public string lockedoutuserpassword = ParseJson(".TestCase_FailedLogin.password");
        public string lockedoutusererror = ParseJson(".TestCase_FailedLogin.error");
        
    }
}
