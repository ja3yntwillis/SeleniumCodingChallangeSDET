using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using SeleniumCodingChallangeSDET.CommonReusables.Configuration;
using SeleniumCodingChallangeSDET.CommonReusables.UI;
using SeleniumCodingChallangeSDET.CommonReusables.Utils;
using SeleniumCodingChallangeSDET.Modules;
using SeleniumCodingChallangeSDET.Pages;
using SeleniumCodingChallangeSDET.PageSteps;
using SeleniumCodingChallangeSDET.TestData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SeleniumCodingChallangeSDET.Tests
{
    public class WorkflowTest:MultipleWorkFlowTestData
    {
        Reporting extent;
        ExtentTest test;
        System.Configuration.Configuration config;
        Config ConfigObject;
        IWebDriver driver;
        Login LoginObject;
        BrowserActions BrowserActionsObj;
        InventoryPageActions InventoryPageSteps;
        CartPageActions CartPageSteps;
        CaptureScreenshot CaptureScreenshotObj;
        CheckoutPageActions CheckoutPageSteps;
        CheckOut checkOut;
        string url;
        FinishPageActions FinishPageSteps;

        public WorkflowTest(Reporting extent, IWebDriver driver):base()
        {
            this.extent = extent;
            ConfigObject = new Config();
            config = ConfigObject.GetConfig();
            url = ConfigObject.findValueOfAConfiguration(config, "url");
            this.driver = driver;
            LoginObject = new Login(driver);
            InventoryPageSteps = new InventoryPageActions(driver);
            CaptureScreenshotObj = new CaptureScreenshot(driver);
            BrowserActionsObj = new BrowserActions(driver);
            CartPageSteps = new CartPageActions(driver);
            CheckoutPageSteps = new CheckoutPageActions(driver);
            FinishPageSteps = new FinishPageActions(driver);
            checkOut = new CheckOut(driver);

        }
        public void TestCase_MultipleScenarioWorkflow()
        {
            Dictionary<string, string> prices = new Dictionary<string, string>();
            string cartQty;
            test = extent.GetTestIntent("MultipleScenarioWorkflow", "Verification of multiple scenarios");
            try
            {
                //Start Test
                BrowserActionsObj.OpenUrl(url);
                test.Log(Status.Info, "Browser Opened");

                //Login to the Website
                LoginObject.LoggingIn(standard_user, standarduserpassword);
                test.Log(Status.Pass, "Login Successful.", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());

                //changing the price to low to high
                InventoryPageSteps.SelectFilter(filtervalue);
                InventoryPageSteps.ValidateFilter(filtertext);
                //validation if prices are already sorted
                InventoryPageSteps.ValidateIfPricesAreInSortedOrder();
                //Adding Product to cart
                InventoryPageSteps.AddToCartOrRemove(Product1);
                InventoryPageSteps.AddToCartOrRemove(Product2);
                //Validation of removal of Add to cart
                InventoryPageSteps.ValidateButtonTextIsNot(Product1, AddToCart);
                InventoryPageSteps.ValidateButtonTextIsNot(Product2, AddToCart);
                //Validation of button text chnaged to Remove
                InventoryPageSteps.ValidateButtonTextIs(Product1, RemoveCart);
                InventoryPageSteps.ValidateButtonTextIs(Product2, RemoveCart);
                test.Log(Status.Info, "Button Validations Completed", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
                //capturing price
                prices.Add(Product1, InventoryPageSteps.GetPrice(Product1));
                prices.Add(Product2, InventoryPageSteps.GetPrice(Product2));
                //Cart Count validation
                cartQty = InventoryPageSteps.GetCartCount();
                Assert.AreEqual(cartQty, CardQty);
                test.Log(Status.Info, "Cart Product count validated", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
                //clicking on cart
                CartPageSteps.ClickCart();
                // cart price validation with product page
                Assert.AreEqual(prices[Product1], CartPageSteps.CapturePriceAtCart(Product1));
                Assert.AreEqual(prices[Product2], CartPageSteps.CapturePriceAtCart(Product2));
                CartPageSteps.RemoveProduct(Product2);
                // Validation of the Cart Qty is matching with Jackets
                Assert.AreEqual(CartPageSteps.GetProductQty(Product1), InventoryPageSteps.GetCartCount());
                test.Log(Status.Info, "Cart Validations Completed", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
                //Start CheckOut
                CartPageSteps.ClickCheckOut();

                // Fill checkOut form 
                checkOut.FillCheckOutForm(GenerateRandomData.GenerateRandomText(), GenerateRandomData.GenerateRandomText(), GenerateRandomData.GenerateRandomZip());
                CheckoutPageSteps.ContinueToCheckOutOverviewPage();
                test.Log(Status.Info, "Overview Page", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
                Assert.AreEqual(CheckoutPageSteps.GetTotalAmt(), prices[Product1]);
                //Go to Finish Page
                CheckoutPageSteps.FinishPage();
                test.Log(Status.Info, "Finish Page", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
                Assert.AreEqual(finishPageAssertText, FinishPageSteps.GetFinishText());
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.StackTrace, MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
            }
        }
            public void TestCase_ErrorUser()
            {
            test = extent.GetTestIntent("ErrorUserWorkflow", "Verification of ErrorUser");
            try
            {
                //Start Test
                BrowserActionsObj.OpenUrl(url);
                test.Log(Status.Info, "Browser Opened");

                //Login to the Website
                LoginObject.LoggingIn(error_user, erroruserpassword);
                test.Log(Status.Pass, "Login Successful.", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
                // choose product
                InventoryPageSteps.AddToCartOrRemove(errorUserProduct);
                //clicking on cart
                CartPageSteps.ClickCart();
                //Start CheckOut
                CartPageSteps.ClickCheckOut();

                // Fill checkOut form 
                checkOut.FillCheckOutForm(GenerateRandomData.GenerateRandomText(), GenerateRandomData.GenerateRandomText(), GenerateRandomData.GenerateRandomZip());
                CheckoutPageSteps.ContinueToCheckOutOverviewPage();
                test.Log(Status.Info, "Overview Page", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
                //Go to Finish Page
                CheckoutPageSteps.FinishPage();
                test.Log(Status.Info, "Finish Page", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
                //Intentionally Adding this assert to fail as the click on Finish button is not working for the error user as disered
                Assert.AreEqual(finishPageAssertText, FinishPageSteps.GetFinishText());

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.StackTrace, MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
            }
        }
        public void TestCase_PerformenceUser()
        {
            Dictionary<string, string> prices = new Dictionary<string, string>();
            string cartQty;
            test = extent.GetTestIntent("PerformenceUserTest", "Verification of Performence User");
            try
            {
                //Start Test
                BrowserActionsObj.OpenUrl(url);
                test.Log(Status.Info, "Browser Opened");

                //Login to the Website
                LoginObject.LoggingIn(performence_user, performenceuserpassword);
                test.Log(Status.Pass, "Login Successful.", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());

                //Adding Product to cart
                InventoryPageSteps.AddToCartOrRemove(performenceUserProduct);

                //clicking on cart
                CartPageSteps.ClickCart();

                //All Items
                InventoryPageSteps.ClickOpenItemsMenu();
                InventoryPageSteps.ClickAllItems();

                //Remove Product 
                InventoryPageSteps.AddToCartOrRemove(performenceUserProduct);
                //Log Out
                InventoryPageSteps.ClickOpenItemsMenu();
                InventoryPageSteps.ClickLogOut();

                test.Log(Status.Info, "Logged Out", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.StackTrace, MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
            }
        }
        public void TestCase_BonusTest()
        {
            test = extent.GetTestIntent("Bonus Test case", "Verification of Bonus Test case");
            try
            {
                BrowserActionsObj.OpenUrl(url);
                test.Log(Status.Info, "Browser Opened");

                //Login to the Website
                LoginObject.LoggingIn(bonususer, bonuspassword);
                test.Log(Status.Pass, "Login Successful.", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
                InventoryPageSteps.OpenSocicalMediaLink(twitter);
                InventoryPageSteps.OpenSocicalMediaLink(facebook);
                InventoryPageSteps.OpenSocicalMediaLink(linkedin);
                test.Log(Status.Pass, "Opened Tabs.", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
                //Closing Facebook tab
                BrowserActionsObj.CloseTab(facebooktitle, swaglabstitle);
                //Closing Twitter tab
                BrowserActionsObj.CloseTab(twittertitle, swaglabstitle);
                //Switch tab to Swag Labs tab
                BrowserActionsObj.SwitchTab(swaglabstitle);
                //Log Out
                InventoryPageSteps.ClickOpenItemsMenu();
                InventoryPageSteps.ClickLogOut();
                //Closing LinkedIn tab
                BrowserActionsObj.CloseTab(linkedintitle, swaglabstitle);
                test.Log(Status.Pass, "Test Completed.", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.StackTrace, MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
            }
        }
        public void TestCase_BrowserRefresh()
        {
            test = extent.GetTestIntent("BrowserRefreshWorkflow", "Verification of BrowserRefresh");
            try
            {
                //Start Test
                BrowserActionsObj.OpenUrl(url);
                test.Log(Status.Info, "Browser Opened");

                //Login to the Website
                LoginObject.LoggingIn(browserRefreshuser, browserRefreshUserPass);
                test.Log(Status.Pass, "Login Successful.", MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
                // choose product
                InventoryPageSteps.AddToCartOrRemove(browserRefreshUserProduct);
                //Reset app state
                InventoryPageSteps.ClickOpenItemsMenu();
                InventoryPageSteps.ClickResetAppState();
                //Refresh Browser
                BrowserActionsObj.refreshPage();
                //Button Validations
                InventoryPageSteps.ValidateButtonTextIsNot(browserRefreshUserProduct,browserrefreshRemoveCart);
                InventoryPageSteps.ValidateButtonTextIs(browserRefreshUserProduct, browserRefreshAddToCart);
                //cart count validation
                Assert.AreEqual(browserrefreshRemoveCartQty, InventoryPageSteps.GetCartCount().Trim());
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.StackTrace, MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenshotObj.CaptureScreen()).Build());
            }
        }

    }
}
