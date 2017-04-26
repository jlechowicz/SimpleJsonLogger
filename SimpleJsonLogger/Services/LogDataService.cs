using SimpleJsonLogger.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentDbClient.Context;

namespace SimpleJsonLogger.Services
{
    internal class LogDataService : DataServiceBase<LogDocument>, ILogDataService<LogDocument>
    {
        public LogDataService(IDocumentDbContext context) : base(context)
        {
        }
    }
}
