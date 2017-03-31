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
            Assert.AreEqual(DetailLevel.Low, (DetailLevel)config.DetailLevelToLog);
            Assert.AreEqual("Test Logger", config.LogName);
            Assert.AreEqual("This is just a typical description.", config.LogDescription);
        }
    }
}
