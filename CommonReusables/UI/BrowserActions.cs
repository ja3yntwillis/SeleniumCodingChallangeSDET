using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCodingChallangeSDET.CommonReusables.Driver;
using SeleniumCodingChallangeSDET.CommonReusables.Utils;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCodingChallangeSDET.CommonReusables.UI
{
    internal class BrowserActions
    {
        public WebDriver driver;

        public BrowserActions(IWebDriver driver)
        {
            this.driver = (WebDriver)driver;
        }
        public void OpenUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

        }
        public void refreshPage()
        {
            driver.Navigate().Refresh();
        }
        public void QuitDriver()
        {
            driver.Quit();
        }
        public void CloseDriver()
        {
            driver.Close();
        }
        public string GetTitle()
        {
            return driver.Title;
        }
        public void CloseTab(string title,string swaglabstitle)
        {
            try
            {
                string currentWindowHandle = driver.CurrentWindowHandle;
                var windowHandles = driver.WindowHandles.ToList();
                string targetWindowHandle = null;
                
                foreach (var windowHandle in windowHandles)
                {
                    
                    driver.SwitchTo().Window(windowHandle);
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(driver => !string.IsNullOrEmpty(driver.Title));
                    if (driver.Title.Contains(title))
                    {
                        targetWindowHandle = windowHandle;
                        break;
                    }
                }
               
                driver.SwitchTo().Window(targetWindowHandle);
                driver.Close();
                windowHandles = driver.WindowHandles.ToList();
                foreach (var windowHandle in windowHandles)
                {
                    driver.SwitchTo().Window(windowHandle);
                    if (driver.Title.Contains(swaglabstitle))
                    {
                        targetWindowHandle = windowHandle;
                        break;
                    }
                }
                driver.SwitchTo().Window(targetWindowHandle);
     
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        public void SwitchTab(string title)
        {
            try
            {
                string currentWindowHandle = driver.CurrentWindowHandle;
                var windowHandles = driver.WindowHandles.ToList();
                string targetWindowHandle = null;

                foreach (var windowHandle in windowHandles)
                {
                    driver.SwitchTo().Window(windowHandle);
                    if (driver.Title.Contains(title))
                    {
                        targetWindowHandle = windowHandle;
                        break;
                    }
                }
                driver.SwitchTo().Window(targetWindowHandle);
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }
    }
}
