using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using NP6Api;
using NP6Api.Models;
using RestSharp;

namespace DriverTest
{
    [TestClass]
    public class ImportTest
    {
        private static Driver _driver;
        private static ImportModel _import;
        private static JsonObject _importTest;

        [ClassInitialize()]
        public static void ImportTestInitialize(TestContext testContext)
        {
            var config = new Dictionary<string, string>();

            config["xKey"] = "YOUR XKEY";
            config["url"] = "http://127.0.0.1:8888/";
            _driver = new Driver(config);
            _import = new ImportModel()
            {
                Name = "Manual Import CSharp",
                Features = new Feature[]
                {
                    new Feature() {
                        Type = "segmentation",
                        SegmentId = 12345,
                        EmptyExistingSegment = false
                    },
                    new Feature() {
                        Type = "duplicate",
                        Rules = new Rule() { Ignore = true }
                    },
                    new Feature() {
                        Type = "report",
                        SendFinalReport = true,
                        SendErrorReport = true,
                        ContactGuids = new string[] {"0123ABC"},
                    },
                    new Feature() {
                        Type = "database",
                        UpdateExisting = true,
                        CrushData = false,
                    }
                },
                Binding = 1234
            };

            _importTest = new JsonObject
            {
                {"name", "Manual Import C#"},
                {"features", new JsonObject[] {

                    new JsonObject {
                        {"type", "segmentation"},
                        {"segmentId", 12345},
                        {"emptyExistingSegment", false}
                    },
                    new JsonObject {
                        {"type", "duplicate"},
                        {"rules", new JsonObject {
                             {"ignore", true}
                                    }
                        }
                    },
                    new JsonObject {
                        {"type", "report"},
                        {"sendFinalReport", true},
                        {"sendErrorReport", true},
                        {"contactGuids", new string[] {"01234ABC"} },
                        {"groupIds", new string[0] }
                    },
                    new JsonObject {
                        {"type", "database"},
                        {"updateExisting", true},
                        {"crushData", false},
                    }
                    }
                },
                {"binding", 1234}
            };
        }

        [TestMethod]
        public void TestCreate()
        {
            var response = _driver.Import.Create(_import);

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestExecute()
        {
            var response = _driver.Import.Execute("12345", "./import.csv");

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestGet()
        {
            var response = _driver.Import.Get("12345");

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestList()
        {
            var response = _driver.Import.List();

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }

        [TestMethod]
        public void TestDelete()
        {
            var response = _driver.Import.Delete("12345");

            Assert.AreEqual((HttpStatusCode)204, response.StatusCode);
        }
    }
}
