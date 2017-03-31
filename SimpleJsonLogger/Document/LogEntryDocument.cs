using DocumentDbClient.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleJsonLogger.Document
{
    internal class LogEntryDocument : SubDocumentBase
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("detailLevel")]
        public int DetailLevel { get; set; }
    }
}
