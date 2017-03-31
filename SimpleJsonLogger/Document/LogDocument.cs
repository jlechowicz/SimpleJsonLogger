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
    [DocumentDbDocumentCollectionData("LogDocumentCollection")]
    internal class LogDocument : DocumentBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("entries")]
        public LogEntryDocument[] Entries { get; set; }
    }
}
