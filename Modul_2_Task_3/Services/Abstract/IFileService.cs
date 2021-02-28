using Modul_2_Task_3.Model;

namespace Modul_2_Task_3.Services.Abstract
{
    public interface IFileService
    {
        public void Write(string text, LogConfigData writeConfig);
    }
}
