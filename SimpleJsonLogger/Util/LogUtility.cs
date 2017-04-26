using SimpleJsonLogger.Configuration;
using SimpleJsonLogger.Enum;
using SimpleJsonLogger.Model;
using SimpleJsonLogger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace SimpleJsonLogger.Util
{
    internal class LogUtility
    {
        public Log[] GetLogEntries(string logName)
        {
            var service = Unity.Instance.Resolve<ILogBusinessService>();
            var logs = service.GetLog(logName);
            return logs;
        }

        public Log[] GetLogEntries()
        {
            string logName = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().LogName;
            var service = Unity.Instance.Resolve<ILogBusinessService>();
            var logs = service.GetLog(logName);
            return logs;
        }

        public void Log(string message, DetailLevel level)
        {
            if (level != DetailLevel.None)
            {
                var config = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection();
                string logDescription = config.LogDescription;
                string logName = config.LogName;
                int configurationLevel = config.DetailLevelToLog;

                var service = Unity.Instance.Resolve<ILogBusinessService>();
                

                if (configurationLevel >= (int)level)
                {
                    var log = new Log();
                    log.CreatedOn = DateTimeOffset.UtcNow;
                    log.DetailLevel = (int)level;
                    log.LogDescription = logDescription;
                    log.Message = message;
                    log.Name = logName;
                    service.SaveLog(log);
                }
            }
        }
    }
}
