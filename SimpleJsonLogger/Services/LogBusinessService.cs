using SimpleJsonLogger.DataContext;
using SimpleJsonLogger.Document;
using SimpleJsonLogger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Services
{
    internal class LogBusinessService
    {
        public Log GetLog(string logName)
        {
            using(var ds = new LogDataService(new LogContext()))
            {
                var log = ds.Query(d => d.Name.Equals(logName)).AsEnumerable().SingleOrDefault();
                var model = new Log();
                model.LogEntries = new List<LogEntry>();
                if (log != null)
                {
                    model.Id = log.Id;
                    model.CreatedOn = log.Created;
                    model.LogDescription = log.Description;
                    model.Name = log.Name;
                    model.LastModified = log.LastModified;
                    model.LogEntries.AddRange(log.Entries.Select(d => new LogEntry { DetailLevel = d.DetailLevel, LoggedOn = d.Created, Message = d.Message, Id = d.Id }));
                }
                else
                {
                    model.Name = logName;
                    model.CreatedOn = DateTimeOffset.UtcNow;
                }
                return model;
            }
        }

        public void SaveLog(Log log)
        {
            using (var ds = new LogDataService(new LogContext()))
            {
                var document = new LogDocument()
                {
                    Created = log.CreatedOn,
                    Description = log.LogDescription,
                    Name = log.Name,
                    LastModified = log.LastModified,
                    Entries = log.LogEntries.Select(m => new LogEntryDocument { Id = m.Id, Created = m.LoggedOn, DetailLevel = m.DetailLevel, Message = m.Message }).ToArray()
                };
                if (string.IsNullOrWhiteSpace(log.Id))
                {
                    document.Id = Guid.NewGuid().ToString();
                    ds.Create(document);
                }
                else
                {
                    document.Id = log.Id;
                    ds.Update(document);
                }
            }
        }
    }
}
