using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.UIReusables;
using SeleniumCodingChallangeSDET.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCodingChallangeSDET.PageSteps
{
    public class FinishPageActions : WebPageActions
    {
        private FinishPage finishPage;

        public FinishPageActions(IWebDriver driver) : base(driver)
        {
            finishPage = new FinishPage();
        }

        public string GetFinishText()
        {
            return GetText(finishPage.FinishText);
        }
    }
}
