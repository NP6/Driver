using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NP6Api;
using System.Net;
using NP6Api.Models;

namespace DriverTest
{
    [TestClass]
    public class ActionTest
    {
        private static Driver _driver;
        private static SmsMessageModel _action;
        private static ValidationModel _validation;
        private static TestModel _test;

        [ClassInitialize()]
        public static void ActionTestInitialize(TestContext testContext)
        {
            var config = new Dictionary<string, string>();

            config["xKey"] = "YOUR XKEY";
            config["url"] = "http://127.0.0.1:8888/";
            _driver = new Driver(config);
            _action = new SmsMessageModel();
            _action.Type = "smsMessage";
            _action.Name = "SMS Message C# (Driver)";
            _action.Description = "SMS message description";
            _action.Informations = new Information() {
               Folder = null,
               Category = null
            };
            _action.Content = new SMSContent() {
               TextContent = "Message text test"
            };
            _validation = new ValidationModel()
            {
                Fortest = false,
                CampaignAnalyser = false,
                TestSegments = new int[] { 12345 },
                MediaForTest = null,
                TextandHtml = false,
                Comments = null
            };
            _test = new TestModel()
            {
                Fortest = true,
                CampaignAnalyser = false,
                TestSegments = new int[] { 12345 },
                TextandHtml = false,
            };
        }

        [TestMethod]
        public void TestList()
        {
            var response = _driver.Action.List();

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestGet()
        {
            var response = _driver.Action.Get("12345");

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestGetNull()
        {
            try
            {
                var response = _driver.Action.Get(null);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "Parameter is null");
            }
        }

        [TestMethod]
        public void TestCreate()
        {
            var response = _driver.Action.Create(_action);

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestCreateNull()
        {
            try
            {
                var response = _driver.Action.Create(null);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "Parameter is null");
            }
        }

        [TestMethod]
        public void TestUpdate()
        {
            var response = _driver.Action.Update("12345", _action);

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestUpdateNull()
        {
            try
            {
                var response = _driver.Action.Update(null, null);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "Parameter is null");
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            var response = _driver.Action.Delete("12345");

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }
   
        [TestMethod]
        public void TestDeleteNull()
        {
            try
            {
                var response = _driver.Action.Delete(null);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "Parameter is null");
            }
        }

        [TestMethod]
        public void TestValidate()
        {
            var response = _driver.Action.Validate("12345", _validation);

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }

        [TestMethod]
        public void TestValidateNull()
        {
            try
            {
                var response = _driver.Action.Validate(null, null);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "Parameter is null");
            }
        }

        [TestMethod]
        public void TestTest()
        {
            var response = _driver.Action.Test("12345", _test);

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }

        [TestMethod]
        public void TestTestNull()
        {
            try
            {
                var response = _driver.Action.Test(null, null);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.Message, "Parameter is null");
            }
        }
    }
}
