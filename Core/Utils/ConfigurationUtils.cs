using Microsoft.Extensions.Configuration;

namespace Core.Utils
{
    public static class ConfigurationUtils
    {
        private static IConfiguration _config;
        public static IConfiguration ReadConfiguration(string path)
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path)
                .Build();
            return _config;
        }
        public static string GetConfigurationByKey(string key, IConfiguration? config = null)
        {
            var value = config == null ? _config[key] : config[key];

            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            throw new InvalidDataException($"Attribute [{key}] has not been set in appsettings.json");
        }
        public static IEnumerable<string> GetBrowserArgs(string key, IConfiguration? config = null)
        {
            config = config ?? _config;
            foreach (KeyValuePair<string, string?> pair in config.AsEnumerable())
            {
                if (pair.Key.Contains(key) && pair.Value!=null)
                {
                    yield return pair.Value;
                }
            }
        }
        
    }
}