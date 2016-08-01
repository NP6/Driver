using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace DriverTest
{
    [TestClass]
    public class TargetTest
    {
        private static NP6Api.Driver _driver;

        [ClassInitialize()]
        public static void TargetTestInitialize(TestContext testContext)
        {
            var config = new Dictionary<string, string>();

            config["xKey"] = "YOUR XKEY";
            config["url"] = "http://127.0.0.1:8080/";
            _driver = new NP6Api.Driver(config);
        }

        [TestMethod]
        public void TestCreate()
        {
            var data = new JsonObject
            {
                {"1234", "test@test.com"},
                {"1234", "Test"}, 
                {"1234", "Mr"}
            };

            var response = _driver.Target.Create(data);

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var data = new JsonObject
            {
                {"1234", "test@test.com"},
                {"1234", "Test"}, 
                {"1234", "Mr"}
            };

            var response = _driver.Target.Update("01234ABC", data);

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestGet()
        {
            var response = _driver.Target.Get("01234ABC");

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestList()
        {
            var response = _driver.Target.List();

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestFind()
        {
            var response = _driver.Target.Find("test@np6.com");
            
            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestDelete()
        {
            var response = _driver.Target.Delete("01234ABC");

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }
    }
}
