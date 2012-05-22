using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace MvcMusicStore.Tests.UI.PageModels
{
    public class Homepage
    {
        IWebDriver _driver;
        public Homepage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SelectItem(string name)
        {
            _driver.FindElement(By.LinkText(name)).Click();
        }
    }
}
