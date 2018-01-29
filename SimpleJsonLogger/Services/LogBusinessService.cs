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
        public Log GetLog(string logName)
        {
            using(var ds = Util.Unity.Instance.Resolve<ILogDataService<LogDocument>>())
            {
                var log = ds.Query(l => l.Name == logName).AsEnumerable().SingleOrDefault();
                if(log == null)
                {
                    return null;
                }
                else
                {
                    var model = new Log { Id = log.Id,
                        CreatedOn = log.Created,
                        LastModified = log.LastModified,
                        LogDescription = log.Description,
                        Messages = log.Messages.Select(m => new Log.LogMessage { Data = m.Data, TimeStamp = m.TimeStamp, DetailLevel = m.DetailLevel }).ToArray(),
                        Name = log.Name };

                    return model;
                }
                
            }
        }

        public void SaveLog(Log log)
        {
            using (var ds = Util.Unity.Instance.Resolve<ILogDataService<LogDocument>>())
            {
                if (string.IsNullOrWhiteSpace(log.Id))
                {
                    var document = new LogDocument()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Created = log.CreatedOn,
                        Description = log.LogDescription,
                        Name = log.Name,
                        LastModified = log.LastModified
                    };
                    document.Messages = log.Messages.Select(d => new LogDocument.LogMessage { Data = d.Data, TimeStamp = d.TimeStamp, DetailLevel = d.DetailLevel }).ToArray();
                    ds.Create(document);
                }
                else
                {
                    var document = ds.Find(log.Id);
                    document.Messages = log.Messages.Select(d => new LogDocument.LogMessage { Data = d.Data, TimeStamp = d.TimeStamp, DetailLevel = d.DetailLevel }).ToArray();
                    ds.Update(document);
                }
            }
        }
    }
}
