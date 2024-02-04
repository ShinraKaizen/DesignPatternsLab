using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace DesignPatternsLibrary.Singleton
{
    public class ConfigurationManager
    {
        private static ConfigurationManager _instance;
        private static object _instanceLock = new object();
        private static IConfiguration _settings;

        private ConfigurationManager()
        {
            LoadConfigurationSettings();
        }

        public static ConfigurationManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }

            return _instance;
        }

        public string GetSetting(string key)
        {
            return _settings[key]; 
        }

        private void LoadConfigurationSettings()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(basePath, "Singleton", "appsettings.json");

            _settings = new ConfigurationBuilder()
                .SetBasePath(basePath) 
                .AddJsonFile(configPath, optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
