using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.UIReusables;
using NUnit.Framework;
using System;
using SeleniumCodingChallangeSDET.Pages;

namespace SeleniumCodingChallangeSDET.PageSteps
{
    public class InventoryPageSteps : WebPageActions
    {
        private InventoryPage inventoryPage;

        public InventoryPageSteps(IWebDriver driver) : base(driver)
        {
            inventoryPage = new InventoryPage();
        }

        public void ClickLogOut()
        {
            Click(inventoryPage.LogOut);
        }
        public void ClickResetAppState()
        {
            Click(inventoryPage.ResetAppState);
        }
        public void ClickAllItems()
        {
            Click(inventoryPage.AllItems);
        }
        public void ClickOpenItemsMenu()
        {
            Click(inventoryPage.HBIcon);
        }

        public void SelectFilter(string value)
        {
            SelectElement(inventoryPage.Productfilter, value);
        }

        public void ValidateFilter(string value)
        {
            var text = GetText(inventoryPage.SpanText);
            Assert.AreEqual(value, text);
        }

        public void ValidateIfPricesAreInSortedOrder()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            var list = GetTexts(inventoryPage.PriceDiv);
            int flag = 1;
            for (int i = 0; i < list.Count - 1; i++)
            {
                try
                {
                    double a = double.Parse(list[i].Substring(1));
                    double b = double.Parse(list[i + 1].Substring(1));
                    if (double.Parse(list[i].Substring(1).Trim()) > double.Parse(list[i + 1].Substring(1).Trim()))
                    {
                        flag = 0;
                        break;
                    }
                }
                catch
                {
                    Exception e;
                }
            }
            Assert.AreEqual(flag, 1);
        }

        public void AddToCartOrRemove(string product)
        {
            Click(inventoryPage.ProductAddToCartOrRemoveButton(product));
        }
        public void OpenSocicalMediaLink(string socialMedia)
        {
            Click(inventoryPage.SocialMediaIcon(socialMedia));
        }
        public void ValidateButtonTextIs(string product, string option)
        {
            By obj = inventoryPage.ProductAddToCartOrRemoveButton(product);
            var element = (WebElement)driver.FindElement(obj);
            Assert.IsTrue(element.Enabled);
            var buttonText = GetText(obj).Trim();
            Assert.AreEqual(option, buttonText);
        }

        public void ValidateButtonTextIsNot(string product, string option)
        {
            var buttonText = GetText(inventoryPage.ProductAddToCartOrRemoveButton(product)).Trim();
            Assert.AreNotEqual(option, buttonText);
        }

        public string GetPrice(string product)
        {
            return GetText(inventoryPage.ProductPrice(product)).Trim();
        }

        public string GetCartCount()
        {
            var text = GetText(inventoryPage.CartIcon);
            return text;
        }
    }
}
