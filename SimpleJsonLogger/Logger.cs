using SimpleJsonLogger.Enum;
using SimpleJsonLogger.Model;
using SimpleJsonLogger.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger
{
    public class Logger
    {
        private LogUtility _logUtility;
        private Logger(LogUtility util) { _logUtility = util; }
        public static Logger GetLogger()
        {
            var logger = new Logger(new LogUtility());
            return logger;
        }

        public async Task Log(string message, DetailLevel level)
        {
            await Task.Run(() => _logUtility.Log(message, level));
        }

        public LogEntry[] GetEntries()
        {
            return _logUtility.GetLogEntries();
        }

        public LogEntry[] GetEntries(string logName)
        {
            return _logUtility.GetLogEntries(logName);
        }
    }
}
