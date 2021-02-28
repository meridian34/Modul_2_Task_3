using Modul_2_Task_3.Model.Enum;

namespace Modul_2_Task_3.Services.Abstract
{
    public interface ILoggerService
    {
        public void Log(LogType logType, string message);
        public void LogInfo(string message);
        public void LogWarning(string message);
        public void LogError(string message);
    }
}
