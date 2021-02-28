using System;
using Modul_2_Task_3.Model;
using Modul_2_Task_3.Model.Enum;
using Modul_2_Task_3.Services.Abstract;

namespace Modul_2_Task_3.Services
{
    public class Logger : ILoggerService
    {
        private readonly IFileService _fileService;
        private readonly LogConfigData _logConfig;
        private static readonly Logger _instance = new Logger();

        private Logger()
        {
            var configService = new ConfigService();
            _fileService = new FileService();
            _logConfig = configService.GetConfig().LogConfigData;
        }

        public static Logger Instance
        {
            get { return _instance; }
        }

        public void Log(LogType logType, string message)
        {
            var logMessage = $"{DateTime.UtcNow}: {logType}: {message}";
            _fileService.Write(logMessage, _logConfig);
        }

        public void LogInfo(string message)
        {
            Log(LogType.Info, message);
        }

        public void LogWarning(string message)
        {
            Log(LogType.Warning, message);
        }

        public void LogError(string message)
        {
            Log(LogType.Error, message);
        }
    }
}
