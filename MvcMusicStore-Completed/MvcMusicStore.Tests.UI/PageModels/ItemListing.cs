using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace MvcMusicStore.Tests.UI.PageModels
{
    public class ItemListing
    {
        IWebDriver _driver;
        public ItemListing(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddToCart()
        {
            _driver.FindElement(By.Id("addToCart")).Click();
        }
    }
}
