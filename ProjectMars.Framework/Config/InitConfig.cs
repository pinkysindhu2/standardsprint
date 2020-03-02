using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using ProjectMars.Framework.Helper;

namespace ProjectMars.Framework.Config
{
    public class InitConfig
    {
        public InitConfig()
        {
            // json file path 
            var jsonFile = PathHelper.GetCurrentPath("Config/config.json");
            using (StreamReader reader = new StreamReader(jsonFile))
            {
                var json = reader.ReadToEnd();
                JsonConvert.DeserializeObject<Settings>(json);
            }
        }
    }
}
