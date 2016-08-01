using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NP6Api;
using System.Net;

namespace DriverTest
{
    [TestClass]
    public class SendTest
    {
        private static Driver _driver;

        [ClassInitialize()]
        public static void ActionTestInitialize(TestContext testContext)
        {
            var config = new Dictionary<string, string>();

            config["xKey"] = "YOUR XKEY";
            config["url"] = "http://127.0.0.1:8888/";
            _driver = new Driver(config);
        }

        [TestMethod]
        public void testSendMessage()
        {
            var response = _driver.Send.Message("12345", "12345");

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }

        [TestMethod]
        public void testSendMessageNull()
        {
            try
            {
                var response = _driver.Send.Message(null, "12345");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "Parameter is null");
            }
        }
    }
}
