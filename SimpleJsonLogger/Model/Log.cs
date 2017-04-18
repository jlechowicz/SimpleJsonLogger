using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Model
{
    public class Log
    {
        private List<LogEntry> _entries;
        public string Id { get; set; }
        public string Name { get; set; }
        public string LogDescription { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public List<LogEntry> LogEntries => _entries;
        public DateTimeOffset? LastModified { get; internal set; }

        public Log()
        {
            _entries = new List<LogEntry>();
        }
    }
}
