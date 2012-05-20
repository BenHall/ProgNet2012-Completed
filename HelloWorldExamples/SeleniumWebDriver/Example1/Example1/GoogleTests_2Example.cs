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
    public class GoogleTests_2Example
    {
        IWebDriver _driver;

        [TestFixtureSetUp]
        public void CreateDriver()
        {
            _driver = new OpenQA.Selenium.Firefox.FirefoxDriver(new FirefoxProfile());
            _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30)); //Wait while searching for an element.
        }

        [SetUp]
        public void NavigateToWebpage()
        {
            _driver.Navigate().GoToUrl("http://www.google.co.uk");
        }

        [Test]
        public void Search_for_ASPnet_returns_aspnet_homepage_as_result() 
        {   
            IWebElement searchbox = _driver.FindElement(By.Name("q"));

            searchbox.SendKeys("ASP.net");
            searchbox.SendKeys(Keys.Enter);

            Assert.IsNotNull(_driver.FindElement(By.LinkText("Get Started with ASP.NET & ASP.NET MVC : Official Microsoft Site")));
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            if (_driver != null) 
                _driver.Close();  //Close window.
        }
    }
}
