using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CsQuery;
using EasyHttp.Http;

namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void csquery()
        {
            var dom = CsQuery.Server.CreateFromUrl("https://www.google.com/#q=ASP.net&fp=476a205d5fa78915");
            StringAssert.Contains("Get Started with ASP.NET & ASP.NET MVC : Official Microsoft Site", dom.Text()); //Fails. JS / Progressive enhancement.
        }

        [Test]
        public void easyhttp()
        {
            var httpClient = new HttpClient();
            var response = httpClient.Get("http://search.twitter.com/search.json?q=prognet&&rpp=5&include_entities=true&result_type=mixed");
            Assert.That(response.DynamicBody.results.Length > 0);
        }
    }
}
