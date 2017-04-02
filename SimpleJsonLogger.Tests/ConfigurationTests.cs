using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleJsonLogger.Configuration;
using SimpleJsonLogger.Enum;

namespace SimpleJsonLogger.Tests
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void GetConfigurationValuesTest()
        {
            var config = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection();
            Assert.AreEqual(DetailLevel.Diagnostic, (DetailLevel)config.DetailLevelToLog);
            Assert.AreEqual("Log Test", config.LogName);
            Assert.AreEqual("This is just a typical description.", config.LogDescription);
        }
    }
}
