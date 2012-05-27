using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace MvcMusicStore.Tests.UI.Home
{
    [TestFixture]
    public class ListItemsTests
    {
        [Test]
        public void FeaturedProductsAppearOnHomepage()
        {
            var driver = new FirefoxDriver(new FirefoxProfile());
            driver.Navigate().GoToUrl(WebApp.Url);

            StringAssert.Contains("The Best Of Men At Work", driver.FindElement(By.Id("album-list")).Text);
            StringAssert.Contains("For Those About To Rock We Salute You", driver.FindElement(By.Id("album-list")).Text);
            StringAssert.Contains("Let There Be Rock", driver.FindElement(By.Id("album-list")).Text);
            StringAssert.Contains("Balls to the Wall", driver.FindElement(By.Id("album-list")).Text);
            StringAssert.Contains("Restless and Wild", driver.FindElement(By.Id("album-list")).Text);


            driver.Close();
        }
    }
}
