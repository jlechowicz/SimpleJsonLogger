using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Model
{
    public class Log
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LogDescription { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string Message { get; set; }
        public int DetailLevel { get; set; }
        public DateTimeOffset? LastModified { get; internal set; }
    }
}
