using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;
using OpenQA.Selenium.Support.Extensions;

namespace SeleniumCodingChallangeSDET.CommonReusables.UIReusables
{
    public class WebPageActions
    {
        public WebDriver driver;

        public WebPageActions(IWebDriver driver)
        {
            this.driver = (WebDriver)driver;
        }

        public void ClickUsingJS(By by)
        {
            WebElement element = (WebElement)driver.FindElement(by);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);
            driver.ExecuteJavaScript("arguments[0].click();", element);
        }
        public void SendValue(By by, String value)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                driver.FindElement(by).SendKeys(value);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }
        }
        public void Click(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                driver.FindElement(by).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);

            }
        }
        public string GetText(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Text;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
                return null;
            }
        }
        public void SelectElement(By by, string value)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                SelectElement select = new SelectElement(driver.FindElement(by));
                select.SelectByValue(value);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);


            }
        }
        public List<String> GetTexts(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                var ListElement = driver.FindElements(by);
                List<String> List = new List<String>();
                for (int i = 0; i < ListElement.Count; i++)
                {
                    List.Add(ListElement[i].Text);
                }
                return List;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
                return null;

            }
        }
    }
    }
