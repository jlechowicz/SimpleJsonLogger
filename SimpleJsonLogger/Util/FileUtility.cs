using Newtonsoft.Json;
using SimpleJsonLogger.Configuration;
using SimpleJsonLogger.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Util
{
    public class FileUtility
    {
        public JsonLog GetLogFile(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException(nameof(filename), "Parameter cannot be null or empty");
            }
            if (!filename.ToLower().EndsWith(".json"))
            {
                throw new ArgumentException("Filename given must have .json extension", nameof(filename));
            }
            if (!File.Exists(filename))
            {
                string logId = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().LogId;
                string logDescription = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().LogDescription;
                var log = new JsonLog() { CreatedOn = DateTimeOffset.Now, Id = logId, LogDescription = logDescription };
                return log;
            }
            else
            {
                string json = File.ReadAllText(filename);
                return JsonConvert.DeserializeObject<JsonLog>(json);
            }
        }

        public void SaveLogFile(JsonLog log, string filename)
        {
            string json = JsonConvert.SerializeObject(log);
            File.WriteAllText(filename, json);
        }
    }
}
