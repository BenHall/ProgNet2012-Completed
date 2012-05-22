using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MvcMusicStore.Tests.UI
{
    public static class LaunchBrowser
    {
        public static IWebDriver Open()
        {
            var driver = new FirefoxDriver(new FirefoxProfile()); //OpenQA.Selenium.Firefox
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30)); //Wait while searching for an element.
            return driver;
        }

        public static void Close(IWebDriver driver)
        {
            if (driver != null)
                driver.Close();  //Close window.
        }
    }
}
