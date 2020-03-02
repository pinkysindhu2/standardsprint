using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMars.Framework.Config
{
    public class Settings
    {
        [JsonProperty(PropertyName = "BaseUrl")]
        public static string BaseUrl { get; set; }

        [JsonProperty(PropertyName = "DockerBaseUrl")]
        public static string DockerBaseURL { get; set; }

        [JsonProperty(PropertyName = "ExtendReportPath")]
        public static string ExtendReportPath { get; set; }

        [JsonProperty(PropertyName = "ConfigPath")]
        public static string ConfigPath { get; set; }
    }
}
