using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleJsonLogger.Tests
{
    [TestClass]
    public class LogTests
    {
        [TestMethod]
        public void TestLogWrite()
        {
            var l = SimpleJsonLogger.Logger.GetLogger();
            l.Log($"Test write {DateTimeOffset.UtcNow}", Enum.DetailLevel.Diagnostic);
        }
    }
}
