using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.IE;
using System.IO;
using NUnit.Framework;

namespace MvcMusicStore.Tests.UI
{
    public static class LaunchBrowser
    {
        public static IWebDriver Open(SupportedBrowser browser)
        {
            var driver = CreateBrowser(browser); 
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30)); //Wait while searching for an element.
            return driver;
        }

        public static void Close(IWebDriver driver)
        {
            if (driver != null)
                driver.Close();  //Close window.
        }

        public static void Wait(IWebDriver driver)
        {
            Thread.Sleep(5000);
        }

        public static T ExecuteJS<T>(IWebDriver driver, string js)
        {
            IJavaScriptExecutor jsExecute = driver as IJavaScriptExecutor;
            return (T)jsExecute.ExecuteScript(js);
        }

        public static string TakeScreenshot(IWebDriver driver)
        {
            string file = Path.GetTempFileName() + ".png";
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(file, System.Drawing.Imaging.ImageFormat.Png);
            return file;
        }
        public static void TakeScreenshotOnFailure(IWebDriver driver, Action action)
        {
            try
            {
                action();
            }
            catch
            {
                string file = TakeScreenshot(driver);
                Console.WriteLine(file);
                throw;
            }
        }

        private static IWebDriver CreateBrowser(SupportedBrowser browser)
        {
            switch (browser)
            {
                case SupportedBrowser.Firefox:
                    return new FirefoxDriver(new FirefoxProfile()); //OpenQA.Selenium.Firefox
                case SupportedBrowser.Chrome:
                    return new ChromeDriver(@"."); //OpenQA.Selenium.Chrome
                case SupportedBrowser.IE:
                    return new OpenQA.Selenium.IE.InternetExplorerDriver();
                default:
                    throw new ArgumentException("Browser creation not supported");
            }
        }
    }

    public enum SupportedBrowser
    {
        Firefox,
        Chrome,
        IE
    }
}
