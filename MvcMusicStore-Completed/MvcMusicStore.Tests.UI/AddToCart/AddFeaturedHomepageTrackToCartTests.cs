using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using MvcMusicStore.Tests.UI.PageModels;

namespace MvcMusicStore.Tests.UI.AddToCart
{
    class AddFeaturedHomepageTrackToCartTests
    {
        IWebDriver _driver;

        [TestFixtureSetUp]
        public void CreateDriver()
        {
            _driver = LaunchBrowser.Open();
        }

        [SetUp]
        public void NavigateToWebpage()
        {
            _driver.Navigate().GoToUrl(WebApp.Url);
        }

        [Test]
        public void AddingItemShouldIncreaseCartNumber()
        {
            string title = "The Best Of Men At Work";
            new Homepage(_driver).SelectItem(title);
            new ItemListing(_driver).AddToCart();
            
            var cart = new ShoppingCart(_driver);
            Assert.AreEqual(1, cart.HeaderCount(), "Header count different");
            Assert.IsTrue(cart.IsInCart(title));
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            LaunchBrowser.Close(_driver);
        }
    }
}
