using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KonchuSugoizeNotifyLambda.Resources
{
    public class Config
    {
        [JsonPropertyName("NHK")]
        public NhkApiConfig NhkApiConfig { get; set; }

        [JsonPropertyName("Twitter")]
        public TwitterConfig TwitterConfig { get; set; }

        public static Config ReadConfig()
        {
            const string filePath = @"/opt/config/ConfigForLambdaLayer.json";
            Console.WriteLine($"File.Exists({filePath}) = {File.Exists(filePath)}");
            string configStr;
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                configStr = sr.ReadToEnd();
            }
            Config? config = JsonSerializer.Deserialize<Config>(configStr);
            if (config == null ||
                config.NhkApiConfig == null || config.TwitterConfig == null ||
                String.IsNullOrEmpty(config.NhkApiConfig.ApiKey) ||
                String.IsNullOrEmpty(config.TwitterConfig.ConsumerKey) ||
                String.IsNullOrEmpty(config.TwitterConfig.ConsumerSecret) ||
                String.IsNullOrEmpty(config.TwitterConfig.AccessToken) ||
                String.IsNullOrEmpty(config.TwitterConfig.AccessSecret))
            {
                throw new InvalidDataException("Failed to read config file.");
            }
            return config;
        }
    }

    public class NhkApiConfig
    {
        [JsonPropertyName("ApiKey")]
        public string ApiKey { get; set; }
    }

    public class TwitterConfig
    {
        [JsonPropertyName("ConsumerKey")]
        public string ConsumerKey { get; set; }

        [JsonPropertyName("ConsumerSecret")]
        public string ConsumerSecret { get; set; }

        [JsonPropertyName("AccessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("AccessSecret")]
        public string AccessSecret { get; set; }
    }
}
