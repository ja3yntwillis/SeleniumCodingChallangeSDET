using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.UIReusables;
using SeleniumCodingChallangeSDET.Pages;

namespace SeleniumCodingChallangeSDET.PageSteps
{
    public class CartPageActions : WebPageActions
    {
        private CartPage cartPage;

        public CartPageActions(IWebDriver driver) : base(driver)
        {
            cartPage = new CartPage();
        }

        public void ClickCart()
        {
            Click(cartPage.CartIcon);
        }

        public string CapturePriceAtCart(string Product)
        {
            return GetText(cartPage.ProductPrice(Product));
        }

        public void RemoveProduct(string Product)
        {
            Click(cartPage.ProductRemove(Product));
        }

        public string GetProductQty(string Product)
        {
            return GetText(cartPage.ProductQty(Product));
        }

        public void ClickCheckOut()
        {
            Click(cartPage.CheckOut);
        }
    }
}
