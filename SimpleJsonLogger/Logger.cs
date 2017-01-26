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
        public static Logger GetLogger(string filename = null)
        {
            var logger = new Logger(new LogUtility(filename));
            return logger;
        }

        public void Log(string message, DetailLevel level)
        {
            _logUtility.Log(message, level);
        }

        public JsonLogEntry[] GetEntries()
        {
            return _logUtility.Entries;
        }
    }
}
