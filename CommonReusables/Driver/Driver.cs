using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;

namespace SeleniumCodingChallangeSDET.CommonReusables.Driver
{
    public class Driver
    {

        // Base method to get the WebDriver based on the browser name
        public static IWebDriver GetDriver(string browserName)
        {
            IWebDriver driver;

            switch (browserName.ToLower())
            {
                case "ie":
                case "internet explorer":
                    driver = new InternetExplorerDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                case "chromeheadless":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--headless");
                    driver = new ChromeDriver(chromeOptions);
                    break;
                default:
                    throw new Exception();
            }


            return driver;
        }
    }
}
