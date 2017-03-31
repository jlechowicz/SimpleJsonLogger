using System;

namespace SimpleJsonLogger.Model
{
    public class LogEntry
    {
        public string Message { get; set; }
        public DateTimeOffset LoggedOn { get; set; }
        public int DetailLevel { get; set; }
        public string Id { get; internal set; }
    }
}