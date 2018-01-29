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
        public Log GetLogEntries(string logName)
        {
            var service = Unity.Instance.Resolve<ILogBusinessService>();
            var logs = service.GetLog(logName);
            return logs;
        }

        public Log GetLogEntries()
        {
            var config = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection();
            string logName = config.LogName;
            var service = Unity.Instance.Resolve<ILogBusinessService>();
            var log = service.GetLog(logName);
            if (log == null)
            {
                log = new Log()
                {
                    LogDescription = config.LogDescription,
                    Name = logName,
                    CreatedOn = DateTimeOffset.UtcNow
                };
            }
            return log;
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
                    var timestamp = DateTimeOffset.UtcNow;

                    var log = GetLogEntries();

                    if(log.Messages != null)
                    {
                        var tempList = new List<Log.LogMessage>(log.Messages)
                        {
                            new Log.LogMessage { Data = message, TimeStamp = timestamp, DetailLevel = (int)level }
                        };
                        log.Messages = tempList.ToArray();
                    }
                    else
                    {
                        log.Messages = new Log.LogMessage[] {
                            new Log.LogMessage { Data = message, TimeStamp = timestamp, DetailLevel = (int)level }
                        };
                    }
                    
                    service.SaveLog(log);
                }
            }
        }
    }
}
