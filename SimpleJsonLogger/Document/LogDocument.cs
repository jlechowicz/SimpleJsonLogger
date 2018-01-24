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
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("detailLevel")]
        public int DetailLevel { get; set; }
    }
}
