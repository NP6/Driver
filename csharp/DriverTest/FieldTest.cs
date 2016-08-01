using Microsoft.VisualStudio.TestTools.UnitTesting;
using NP6Api;
using System.Collections.Generic;
using System.Net;

namespace DriverTest
{
    [TestClass]
    public class FieldTest
    {
        private static Driver _driver;

        [ClassInitialize()]
        public static void FieldTestInitialize(TestContext testContext)
        {
            var config = new Dictionary<string, string>();

            config["xKey"] = "YOUR XKEY";
            config["url"] = "http://127.0.0.1:8888/";
            _driver = new Driver(config);
        }

        [TestMethod]
        public void TestList()
        {
            var response = _driver.Field.List();

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }
    }
}
