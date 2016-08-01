using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NP6Api;
using NP6Api.Models;

namespace DriverTest
{
    [TestClass]
    public class SegmentTest
    {
        private static Driver _driver;
        private static SegmentModel _segment;

        [ClassInitialize()]
        public static void ActionTestInitialize(TestContext testContext)
        {
            var config = new Dictionary<string, string>();

            config["xKey"] = "YOUR XKEY";
            config["url"] = "http://127.0.0.1:8888/";
            _driver = new Driver(config);
            _segment = new SegmentModel();
            _segment.Name = "Test Segment";
            _segment.Description = "test";
            _segment.IsTest = true;
            _segment.Type = "static";
            _segment.Expiration = "2026-08-08T12:11:00Z";
        }

        [TestMethod]
        public void TestCreate()
        {
            var response = _driver.Segment.Create(_segment);

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestUpdate()
        {
            _segment.Description = "updated";
            var response = _driver.Segment.Update("12345", _segment);

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestGet()
        {
            var response = _driver.Segment.Get("12345");

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestList()
        {
            var response = _driver.Segment.List();

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestDelete()
        {
            var response = _driver.Segment.Delete("12345");

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }

        [TestMethod]
        public void TestAddToSegment()
        {
            var response = _driver.Segment.AddToSegment("12345", "1234ABC");

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }

        [TestMethod]
        public void TestRemove()
        {
            var response = _driver.Segment.Remove("12345", "1234ABC");

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }
    }
}