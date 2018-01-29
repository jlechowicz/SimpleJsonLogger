using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Linq;
using SimpleJsonLogger.Util;

namespace SimpleJsonLogger.Tests
{
    [TestClass]
    public class LogTests
    {
        [ClassInitialize]
        public static void Setup(TestContext context) => Bootstrap.Init();

        [TestMethod]
        public void TestLogWriteWithinDetailLevel()
        {
            var l = SimpleJsonLogger.Logger.GetLogger();
            string message = $"Test write {DateTimeOffset.UtcNow.ToString()}";
            Task.Run(() => l.Log(message, Enum.DetailLevel.Low)).Wait();

            Assert.IsTrue(l.GetLog().Messages.Any(m => m.Data.Equals(message)));
        }

        [TestMethod]
        public void TestLogWriteOutsideOfDetailLevel()
        {
            var l = SimpleJsonLogger.Logger.GetLogger();
            string message = $"This should not exist.";
            Task.Run(() => l.Log(message, Enum.DetailLevel.Diagnostic)).Wait();

            Assert.IsFalse(l.GetLog().Messages.Any(m => m.Data.Equals(message)));
        }
    }
}
