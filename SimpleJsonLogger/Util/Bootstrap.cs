using SimpleJsonLogger.Document;
using SimpleJsonLogger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DocumentDbClient.Context;
using SimpleJsonLogger.DataContext;

namespace SimpleJsonLogger.Util
{
    public static class Bootstrap
    {
        public static void Init()
        {
            Unity.Instance.RegisterType<ILogDataService<LogDocument>, LogDataService>();
            Unity.Instance.RegisterInstance<IDocumentDbContext>(new LogContext());
            Unity.Instance.RegisterType<ILogBusinessService, LogBusinessService>();

        }
    }
}
