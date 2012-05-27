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
            //Fails. Google loads search results as a second stage.
            StringAssert.Contains("Get Started with ASP.NET & ASP.NET MVC : Official Microsoft Site", dom.Text()); 
        }

        [Test]
        public void easyhttp()
        {
            var httpClient = new HttpClient();
            var response = httpClient.Get("http://www.amazon.co.uk/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=Testing+ASP.net&x=0&y=0");
            var dom = CsQuery.CQ.Create(response.RawText);
            StringAssert.Contains("Ben Hall", dom.Find(".ptBrand").Text());
        }

        [Test]
        public void easyhttp_json()
        {
            var httpClient = new HttpClient();
            var response = httpClient.Get("http://search.twitter.com/search.json?q=prognet&&rpp=5&include_entities=true&result_type=mixed");
            Assert.That(response.DynamicBody.results.Length > 0);
        }
    }
}
