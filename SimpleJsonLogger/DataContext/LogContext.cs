using DocumentDbClient.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentDbClient.Utilities;

namespace SimpleJsonLogger.DataContext
{
    public class LogContext : DocumentDbContextBase
    {
        public LogContext(IDocumentDbLogger logger = null) : base(System.Configuration.ConfigurationManager.AppSettings.Get("SimpleJsonLogger.ConnectionName"), logger)
        {
            if (!DoesDatabaseExist())
            {
                CreateDatabase();
            }
            if (!DoesDocumentCollectionExist())
            {
                CreateDocumentCollection();
            }
        }
    }
}
