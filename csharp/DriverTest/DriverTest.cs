using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DriverTest
{
    [TestClass]
    public class DriverTest
    {
        private static string _xKey = "xkey";

        [TestMethod]
        public void TestDriverConstructor()
        {
            var config = new Dictionary<string, string>();

            config["xKey"] = _xKey;
            var _driver = new NP6Api.Driver(config);

        }
    }
}