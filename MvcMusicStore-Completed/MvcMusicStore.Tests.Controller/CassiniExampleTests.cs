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
    public class CassiniExampleTests
    {
        [Test]
        public void ServerReturnsAResponse()
        {
            CassiniDevServer server = new CassiniDevServer();
            server.StartServer(Path.Combine(Environment.CurrentDirectory, @"..\..\..\MvcMusicStore"));
            string url = server.NormalizeUrl("/");
            Console.WriteLine(url);
            var client = new EasyHttp.Http.HttpClient();
            var response = client.Get(url);
            Console.WriteLine(response.RawText);
            Assert.IsFalse(string.IsNullOrEmpty(response.RawText));
        }
    }
}
