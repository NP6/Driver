using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RestSharp;
using NP6Api.Implementation;
using System.Net;

namespace DriverTest.Implementation
{
    [TestClass]
    public class TargetTest
    {
        private static Wrapper _wrapper;
        private static JsonObject _target;
        private static string _actionId;
        private static string _segmentId;

        [ClassInitialize]
        public static void CampaignTestInitialize(TestContext testContext)
        {
            var config = new Dictionary<string, string>();

            config["xKey"] = "YOUR XKEY";
            config["url"] = "http://127.0.0.1:8888/";
            _wrapper = new Wrapper(config);
            _target = new JsonObject();
            _target.Add("civilité", "Mr");
            _target.Add("1234", "Doe");
            _target.Add("1234", "test@test.com");
            _actionId = "000ABC";
            _segmentId = "12345";
        }

        [TestMethod]
        public void TestCreateOrModifyTarget()
        {
            var response = _wrapper.CreateOrModifyTarget(_target);

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestAddTargetAndSendMessage()
        {
            var response = _wrapper.AddTargetAndSendMessage(_target, _actionId);

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }

        [TestMethod]
        public void TestCreateTargetAndAddToSegment()
        {
            var response = _wrapper.CreateTargetAndAddToSegment(_target, _segmentId);

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }
    }
}
