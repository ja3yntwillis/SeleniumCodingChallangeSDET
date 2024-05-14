using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCodingChallangeSDET.Pages
{
    internal class CheckoutPage
    {
        public By FirstName = By.XPath("//input[@id='first-name']");
        public By LastName = By.XPath("//input[@id='last-name']");
        public By PostalCode = By.XPath("//input[@id='postal-code']");
        public By ContinueBtn = By.Id("continue");
        public By ItemTotal = By.XPath("//div[@class='summary_subtotal_label']");
        public By FinishBtn = By.Id("finish");


    }
}
