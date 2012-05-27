using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using MvcMusicStore.Tests.UI.PageModels;

namespace MvcMusicStore.Tests.UI.AddToCart
{
    public class RemoveTrackFromCartTests
    {
        IWebDriver _driver;
        private string _title;

        [TestFixtureSetUp]
        public void CreateDriver()
        {
            _driver = LaunchBrowser.Open(SupportedBrowser.Chrome);
        }

        [SetUp]
        public void NavigateToWebpage()
        {
            _driver.Navigate().GoToUrl(WebApp.Url);
            _title = "The Best Of Men At Work";
            new Homepage(_driver).SelectItem(_title);
            new ItemListing(_driver).AddToCart();
        }

        [Test]
        public void RemovingItemShouldDecreaseCartCount()
        {
            var cart = new ShoppingCart(_driver);
            cart.RemoveItem(_title); //Ajax call... will return straight away.
            LaunchBrowser.Wait(_driver);

            Assert.IsTrue(_driver.FindElement(By.Id("update-message")).Displayed);
            Assert.AreEqual(0, cart.HeaderCount(), "Header count different");
            Assert.IsFalse(cart.IsInCart(_title));
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            LaunchBrowser.Close(_driver);
        }
    }
}
