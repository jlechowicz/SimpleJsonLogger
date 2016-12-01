using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleJsonLogger.Enum;
using SimpleJsonLogger.Configuration;
using SimpleJsonLogger.Model;
using Newtonsoft.Json;

namespace SimpleJsonLogger.Tests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void WriteLogTest()
        {
            var logger = Logger.GetLogger();
            logger.Log("You should see this", DetailLevel.Medium);
            logger.Log("You should see this too", DetailLevel.Medium);
            logger.Log("You should not see this", DetailLevel.High);

            var config = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection();

            Assert.IsTrue(File.Exists(config.FileName));

            JsonLog log = JsonConvert.DeserializeObject<JsonLog>(File.ReadAllText(config.FileName));

            Assert.IsTrue(log.LogEntries.Any(x => x.Message.Equals("You should see this")));
            Assert.IsTrue(log.LogEntries.Any(x => x.Message.Equals("You should see this too")));
            Assert.IsFalse(log.LogEntries.Any(x => x.Message.Equals("You should not see this")));
        }
    }
}
