using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Example1
{
    [TestFixture]
    public class GoogleTests_1Example
    {
        [Test]
        public void Search_for_ASPnet_returns_aspnet_homepage_as_result() {
            IWebDriver driver = new OpenQA.Selenium.Firefox.FirefoxDriver(new FirefoxProfile());
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30)); //Wait while searching for an element.

            driver.Navigate().GoToUrl("http://www.google.co.uk");
            IWebElement searchbox = driver.FindElement(By.Name("q"));

            searchbox.SendKeys("ASP.net");
            searchbox.SendKeys(Keys.Enter);

            Assert.IsNotNull(driver.FindElement(By.LinkText("Get Started with ASP.NET & ASP.NET MVC : Official Microsoft Site")));
        }
    }
}
