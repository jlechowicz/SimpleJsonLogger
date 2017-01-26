using Newtonsoft.Json;
using SimpleJsonLogger.Configuration;
using SimpleJsonLogger.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Util
{
    internal class FileUtility
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

            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembl‌​y().Location);
            var path = $"{directory}\\{filename}";

            if (!File.Exists(path))
            {
                string logId = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().LogId;
                string logDescription = ConfigurationSectionFactory.GetSimpleJsonLoggerConfigurationSection().LogDescription;
                var log = new JsonLog() { CreatedOn = DateTimeOffset.Now, Id = logId, LogDescription = logDescription };
                return log;
            }
            else
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<JsonLog>(json);
            }
        }

        public void SaveLogFile(JsonLog log, string filename)
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembl‌​y().Location);
            var path = $"{directory}\\{filename}";
            string json = JsonConvert.SerializeObject(log);
            File.WriteAllText(path, json);
        }
    }
}
