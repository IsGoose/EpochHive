using EpochHive.Exceptions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System;

namespace EpochHive
{
    public class Configuration
    {
        [JsonProperty("Host")]
        public static string Host { get; set; }
        [JsonProperty("Username")]
        public static string Username { get; set; }
        [JsonProperty("Password")]
        public static string Password { get; set; }
        [JsonProperty("Schema")]
        public static string Schema { get; set; }
        [JsonProperty("LogLevel")]
        public static string LogLevel { get; set; }
        [JsonProperty("Time")]
        public static string Time { get; set; }
        [JsonProperty("Hour")]
        public static int? Hour { get; set; }
        [JsonProperty("Instance")]
        public static int? Instance { get; set; }
        [JsonProperty("StartingHumanity")]
        public static int? StartingHumanity { get; set; }

        public static void Load()
        {
            //TODO: Get Server Configuration Path
            var path = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                var cfg = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(path + "EpochHiveConfiguration.json"));

                var exception = new InvalidConfigurationException();
                exception.ErrorMessage = "One or more Configuration Fields are null:";

                foreach (var propInfo in typeof(Configuration).GetProperties(BindingFlags.Static | BindingFlags.Public))
                {
                    var propValue = propInfo.GetValue(cfg);
                    if(propValue == null)
                        exception.Details.Add(propInfo.Name);
                }

                if (exception.Details.Count > 0)
                    throw exception;

            } catch(Exception e)
            {
                if (e is JsonException)
                    throw InvalidConfigurationException.JsonException(e as JsonException);

                if (e is FileNotFoundException)
                    throw InvalidConfigurationException.FileNotFound(new string[] { path });

                if (e is UnauthorizedAccessException)
                    throw InvalidConfigurationException.AccessDenied(path);

                if (e is InvalidConfigurationException)
                    throw e;

                throw new InvalidConfigurationException(true,e) { };
            }
        }
    }
}
