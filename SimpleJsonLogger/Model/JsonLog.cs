using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Model
{
    public class JsonLog
    {
        public string Id { get; set; }
        public string LogDescription { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public JsonLogEntry[] LogEntries { get; set; }
    }
}
