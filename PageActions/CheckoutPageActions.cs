using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.UIReusables;
using SeleniumCodingChallangeSDET.Pages;

namespace SeleniumCodingChallangeSDET.PageSteps
{
    public class CheckoutPageActions : WebPageActions
    {
        private CheckoutPage checkoutPage;

        public CheckoutPageActions(IWebDriver driver) : base(driver)
        {
            checkoutPage = new CheckoutPage();
        }

        public void EnterFirstname(string Name)
        {
            SendValue(checkoutPage.FirstName, Name);
        }

        public void EnterLastname(string LN)
        {
            SendValue(checkoutPage.LastName, LN);
        }

        public void EnterZip(string Zip)
        {
            SendValue(checkoutPage.PostalCode, Zip);
        }

        public void ContinueToCheckOutOverviewPage()
        {
            Click(checkoutPage.ContinueBtn);
        }

        public void FinishPage()
        {
            Click(checkoutPage.FinishBtn);
        }

        public string GetTotalAmt()
        {
            return GetText(checkoutPage.ItemTotal).Replace("Item total: ", "");
        }
    }
}
