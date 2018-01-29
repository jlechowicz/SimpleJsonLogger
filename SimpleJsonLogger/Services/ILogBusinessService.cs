using SimpleJsonLogger.Model;

namespace SimpleJsonLogger.Services
{
    internal interface ILogBusinessService
    {
        Log GetLog(string logName);
        void SaveLog(Log log);
    }
}