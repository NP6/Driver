using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NP6Api.Implementation;
using System.Net;
using NP6Api.Models;

namespace DriverTest.Implementation
{
    [TestClass]
    public class ImportTest
    {
        private static Wrapper _wrapper;
        private static ImportModel _import;

        [ClassInitialize]
        public static void ImportTestInitialize(TestContext testContext)
        {
            var config = new Dictionary<string, string>();

            config["xKey"] = "YOUR XKEY";
            config["url"] = "http://127.0.0.1:8888/";
            _wrapper = new Wrapper(config);
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
                        ContactGuids = new string[] {"01234ABC"},
                    },
                    new Feature() {
                        Type = "database",
                        UpdateExisting = true,
                        CrushData = false,
                    }
                },
                Binding = 1234
            };
        }

        [TestMethod]
        public void TestRunImport()
        {
            var response = _wrapper.Import(_import, "./assets/import.csv");

            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);
        }
    }
}
