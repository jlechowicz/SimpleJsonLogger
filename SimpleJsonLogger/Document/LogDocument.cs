using DocumentDbClient.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DocumentDbClient.Utilities;

namespace SimpleJsonLogger.Document
{
    public class LogDocument : DocumentBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("messages")]
        public LogMessage[] Messages { get; set; }
        

        public class LogMessage
        {
            [JsonProperty("Data")]
            public string Data { get; set; }
            [JsonProperty("TimeStamp")]
            public DateTimeOffset TimeStamp { get; set; }
            [JsonProperty("detailLevel")]
            public int DetailLevel { get; set; }
        }
    }
}
