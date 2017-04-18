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
            return log.LogEntries.Value.ToArray();
        }

        public LogEntry[] GetLogEntries()
        {
            string logName = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().LogName;
            var service = new LogBusinessService();
            var log = service.GetLog(logName);
            return log.LogEntries.Value.ToArray();
        }

        public void Log(string message, DetailLevel level)
        {
            if (level != DetailLevel.None)
            {
                var config = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection();
                string logDescription = config.LogDescription;
                string logName = config.LogName;
                int configurationLevel = config.DetailLevelToLog;

                var service = new LogBusinessService();
                var log = service.GetLog(logName);

                log.LogDescription = logDescription;

                if (configurationLevel >= (int)level)
                {
                    log.LogEntries.Value.Add(new LogEntry { DetailLevel = (int)level, Id = Guid.NewGuid().ToString(), Message = message, LoggedOn = DateTimeOffset.UtcNow });
                    service.SaveLog(log);
                }
            }
        }
    }
}
