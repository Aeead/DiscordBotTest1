using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Discord_Bot
{
    class Util
    {
        private static Dictionary<string, string> alerts;

        static Util()
        {
            string Json = File.ReadAllText("SystemLan/alerts.json");
            var Data = JsonConvert.DeserializeObject<dynamic>(Json);
            alerts = Data.ToObject<Dictionary<string, string>>();
        }
        public static string GetAlert(string Key)
        {
            if (alerts.ContainsKey(Key)) return alerts[Key];
            return "";
        }
    }
}
