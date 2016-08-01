using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NP6Api.Implementation;
using System.Net;
using NP6Api.Models;

namespace DriverTest.Implementation
{
    [TestClass]
    public class SegmentTest
    {
        private static Wrapper _wrapper;
        private static SegmentModel _segment;

        [ClassInitialize]
        public static void SegmentTestInitialize(TestContext testContext)
        {
            var config = new Dictionary<string, string>();

            config["xKey"] = "YOUR XKEY";
            config["url"] = "http://127.0.0.1:8888/";
            _wrapper = new Wrapper(config);
            _segment = new SegmentModel()
            {
                Name = "Segment static (C#)",
                Description = "From wrapper",
                IsTest = true,
                Type = "static",
                Expiration = "2026-08-08T12:11:00Z"
            };
        }

        [TestMethod]
        public void TestCreateSegment()
        {
            var response = _wrapper.CreateSegment(_segment);

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }
    }
}
