using System;

namespace SimpleJsonLogger.Model
{
    public class JsonLogEntry
    {
        public string Message { get; set; }
        public DateTimeOffset LoggedOn { get; set; }
        public int DetailLevel { get; set; }
    }
}