using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.UIReusables;
using SeleniumCodingChallangeSDET.PageSteps;

namespace SeleniumCodingChallangeSDET.Modules
{
    public class CheckOut : WebPageActions
    {
        private CheckoutPageSteps checkoutPageSteps;

        public CheckOut(IWebDriver driver) : base(driver)
        {
            checkoutPageSteps = new CheckoutPageSteps(driver);
        }

        public void FillCheckOutForm(string fn, string ln, string zip)
        {
            checkoutPageSteps.EnterFirstname(fn);
            checkoutPageSteps.EnterLastname(ln);
            checkoutPageSteps.EnterZip(zip);
        }
    }
}
