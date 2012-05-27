using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CassiniDev;
using System.IO;

namespace CassiniDevHostingExample.Tests.Integration
{
    [TestFixture]
    public class ExampleTests
    {
        [Test]
        public void Example1()
        {
            CassiniDevServer server = new CassiniDevServer();
            server.StartServer(Path.Combine(Environment.CurrentDirectory, @"..\..\..\CassiniDevHostingExample"));
            string url = server.NormalizeUrl("/");
            Console.WriteLine(url);
            var dom = CsQuery.Server.CreateFromUrl(url);
            Console.WriteLine(dom.Text());
            StringAssert.Contains("Welcome to ASP.NET MVC!", dom.Text());
        }
    }
}
