using SimpleJsonLogger.Configuration;
using SimpleJsonLogger.Enum;
using SimpleJsonLogger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Util
{
    internal class LogUtility
    {
        private readonly string _fileName;
        private readonly FileUtility _fileUtility;

        public JsonLogEntry[] Entries
        {
            get
            {
                var logFile = _fileUtility.GetLogFile(_fileName);
                List<JsonLogEntry> entries;
                var hasEntries = logFile.LogEntries?.Any();
                if (hasEntries.GetValueOrDefault(false))
                {
                    entries = new List<JsonLogEntry>(logFile.LogEntries);
                }
                else
                {
                    entries = new List<JsonLogEntry>();
                }
                return entries.ToArray();
            }
        }

        public LogUtility(string fileName = null)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                _fileName = fileName;
            }
            else
            {
                _fileName = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().FileName;
            }
            _fileUtility = new FileUtility();
        }

        public void Log(string message, DetailLevel level)
        {
            if(level != DetailLevel.None)
            {
                int configurationLevel = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().DetailLevelToLog;
                if (configurationLevel >= (int)level)
                {
                    var logFile = _fileUtility.GetLogFile(_fileName);
                    List<JsonLogEntry> entries;
                    var hasEntries = logFile.LogEntries?.Any();
                    if (hasEntries.GetValueOrDefault(false))
                    {
                        entries = new List<JsonLogEntry>(logFile.LogEntries);
                    }
                    else
                    {
                        entries = new List<JsonLogEntry>();
                    }
                    entries.Add(new JsonLogEntry { DetailLevel = (int)level, LoggedOn = DateTimeOffset.Now, Message = message });
                    logFile.LogEntries = entries.ToArray();
                    _fileUtility.SaveLogFile(logFile, _fileName);
                }
            }
        }
    }
}
