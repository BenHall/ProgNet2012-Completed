using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace MvcMusicStore.Tests.UI.PageModels
{
    public class ShoppingCart
    {
        IWebDriver _driver;
        public ShoppingCart(IWebDriver driver)
        {
            _driver = driver;
        }

        public int HeaderCount()
        {
            var cartCount = _driver.FindElement(By.Id("cart-status")).Text;
            var regex = new Regex(@"^Cart \((\d+)\)$");
            var match = regex.Match(cartCount);
            var i = match.Groups[1].Captures[0].Value;
            return Convert.ToInt32(i);
        }

        public bool IsInCart(string title)
        {
            return _driver.FindElement(By.Id("cart-contents")).Text.Contains(title);
        }
    }
}
