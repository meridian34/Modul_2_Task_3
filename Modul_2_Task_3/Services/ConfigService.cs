using System.IO;
using Modul_2_Task_3.Model;
using Modul_2_Task_3.Services.Abstract;
using Newtonsoft.Json;

namespace Modul_2_Task_3.Services
{
    public class ConfigService : IConfigService
    {
        public Config GetConfig()
        {
            var configFile = File.ReadAllText("Config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            return config;
        }
    }
}
