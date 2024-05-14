using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCodingChallangeSDET.Pages
{
    internal class InventoryPage
    {
        public By HBIcon = By.XPath("//div[@class='bm-burger-button']");
        public By LogOut = By.XPath("//a[text()='Logout']");
        public By ResetAppState = By.XPath("//a[text()='Reset App State']");
        public By AllItems = By.XPath("//a[text()='All Items']");
        public By Productfilter = By.XPath("//select[@class='product_sort_container']");
        public By SpanText = By.XPath("//span[@class='active_option']");
        public By PriceDiv = By.XPath("//div[@class='inventory_item_price']");
        public By ProductAddToCartOrRemoveButton(string name) => By.XPath($"//div[text()='{name}']//..//..//..//div[@class='pricebar']//button");
        public By ProductPrice(string name) => By.XPath($"//div[text()='{name}']//..//..//..//div[@class='pricebar']//div[@class='inventory_item_price']");
        public By CartIcon = By.XPath("//a[@class='shopping_cart_link']");
        public By SocialMediaIcon(string name) => By.XPath($"//a[text()='{name}']");
    }
}
