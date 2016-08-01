using Microsoft.VisualStudio.TestTools.UnitTesting;
using NP6Api.Implementation;
using NP6Api.Models;
using System.Collections.Generic;
using System.Net;

namespace DriverTest.Implementation
{
    [TestClass]
    public class CampaignTest
    {
        private static Wrapper _wrapper;
        private static IActionModel _action;
        private static ValidationModel _validation;

        [ClassInitialize]
        public static void CampaignTestInitialize(TestContext testContext)
        {
            var config = new Dictionary<string, string>();

            config["xKey"] = "YOUR XKEY";
            config["url"] = "http://127.0.0.1:8888/";
            _wrapper = new Wrapper(config);
            _action = new MailCampaignModel()
            {
                Name = "Mail Campaign Test (C#)"
            };

            _validation = new ValidationModel()
            {
                Fortest = false,
                CampaignAnalyser = false,
                TestSegments = null,
                MediaForTest = null,
                TextandHtml = true,
                Comments = null
            };
        }

        [TestMethod]
        public void TestCreateCampaign()
        {
            var response = _wrapper.CreateCampaign(_action);

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestCreateAndTestCampaign()
        {
            TestModel test = new TestModel();

            var response = _wrapper.CreateAndTestCampaign(_action, test);

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }

        [TestMethod]
        public void TestValidateCampaign()
        {
            var response = _wrapper.ValidateCampaign("012ABC", _validation);

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }
    }
}
