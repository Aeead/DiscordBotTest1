using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Discord_Bot
{
    class Config
    {
        private const string configFolder = "Recs";
        private const string configFile = "Config.json";

        public static BotConfig _Bot;

        static Config()
        {
            if (!Directory.Exists(configFolder))
                Directory.CreateDirectory(configFolder);

            if (!File.Exists(configFolder + "/" + configFile))
            {
                _Bot = new BotConfig();
                string Json = JsonConvert.SerializeObject(_Bot, Formatting.Indented);
                File.WriteAllText(configFolder + "/" + configFile , Json);
            }
            else
            {
                string Json = File.ReadAllText(configFolder + "/" + configFile);
                _Bot = JsonConvert.DeserializeObject<BotConfig>(Json);
            }
        }
    }

    public struct BotConfig
    {
        public string Token;
        public string CmdPrefix;
    }
}
