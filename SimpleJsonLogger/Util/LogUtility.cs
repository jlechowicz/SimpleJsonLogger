using SimpleJsonLogger.Configuration;
using SimpleJsonLogger.Enum;
using SimpleJsonLogger.Model;
using SimpleJsonLogger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Util
{
    internal class LogUtility
    {
        public LogEntry[] GetLogEntries(string logName)
        {
            var service = new LogBusinessService();
            var log = service.GetLog(logName);
            return log.LogEntries.ToArray();
        }

        public LogEntry[] GetLogEntries()
        {
            string logName = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().LogName;
            var service = new LogBusinessService();
            var log = service.GetLog(logName);
            return log.LogEntries.ToArray();
        }

        public void Log(string message, DetailLevel level)
        {
            if (level != DetailLevel.None)
            {
                string logDescription = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().LogDescription;
                string logName = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().LogName;
                int configurationLevel = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().DetailLevelToLog;

                var service = new LogBusinessService();
                var log = service.GetLog(logName);

                log.LogDescription = logDescription;

                if (configurationLevel >= (int)level)
                {
                    log.LogEntries.Add(new LogEntry { DetailLevel = (int)level, Id = new Guid().ToString(), Message = message, LoggedOn = DateTimeOffset.UtcNow });
                }

                service.SaveLog(log);
            }
        }
    }
}
