using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CassiniDev;
using System.IO;

namespace MvcMusicStore.Tests.Controller
{
    [TestFixture]
    public class ListHomepageTests
    {
        [Test]
        public void FiveTrackNamesAppearOnHomepage()
        {
            CassiniDevServer server = new CassiniDevServer();
            server.StartServer(Path.Combine(Environment.CurrentDirectory, @"..\..\..\MvcMusicStore"));
            string url = server.NormalizeUrl("/");
            var client = new EasyHttp.Http.HttpClient();
            var response = client.Get(url);
            var html = response.RawText;

            StringAssert.Contains("The Best Of Men At Work", html);
            StringAssert.Contains("For Those About To Rock We Salute You", html);
            StringAssert.Contains("Let There Be Rock", html);
            StringAssert.Contains("Balls to the Wall", html);
            StringAssert.Contains("Restless and Wild", html);

            server.StopServer();
        }

        [Test]
        public void FiveItemsAppearHomepage()
        {
            CassiniDevServer server = new CassiniDevServer();
            server.StartServer(Path.Combine(Environment.CurrentDirectory, @"..\..\..\MvcMusicStore"));
            string url = server.NormalizeUrl("/");

            var dom = CsQuery.Server.CreateFromUrl(url);
            Assert.AreEqual(5, dom.Find("#album-list").Find("li").Length);

            server.StopServer();
        }
    }
}
