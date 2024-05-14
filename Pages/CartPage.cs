using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCodingChallangeSDET.Pages
{
    public class CartPage
    {
        public By CartIcon = By.XPath("//a[@class='shopping_cart_link']");
        public By CheckOut = By.XPath("//button[@id='checkout']");
        public By ProductPrice(string name) => By.XPath($"//div[text()='{name}']//..//following::div[@class='inventory_item_price']");
        public By ProductRemove(string name) => By.XPath($" //div[text()='{name}']//..//..//button");
        public By ProductQty(string name) => By.XPath($" //div[text()='{name}']//..//..//..//div[@class='cart_quantity']");

    }
}
