using SimpleJsonLogger.DataContext;
using SimpleJsonLogger.Document;
using SimpleJsonLogger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace SimpleJsonLogger.Services
{
    internal class LogBusinessService : ILogBusinessService
    {
        public LogBusinessService() { }
        public Log[] GetLog(string logName)
        {
            using(var ds = Util.Unity.Instance.Resolve<ILogDataService<LogDocument>>())
            {
                var logs = ds.Query(l => l.Name == logName).AsEnumerable().ToArray();
                var models = logs.Select(l => new Log { Id = l.Id, CreatedOn = l.Created, DetailLevel = l.DetailLevel, LastModified = l.LastModified, LogDescription = l.Description, Message = l.Message, Name = l.Name });
                
                return models.ToArray();
            }
        }

        public void SaveLog(Log log)
        {
            using (var ds = Util.Unity.Instance.Resolve<ILogDataService<LogDocument>>())
            {
                var document = new LogDocument()
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = log.CreatedOn,
                    Description = log.LogDescription,
                    Name = log.Name,
                    LastModified = log.LastModified,
                    DetailLevel = log.DetailLevel,
                    Message = log.Message
                };
                ds.Create(document);
            }
        }
    }
}
