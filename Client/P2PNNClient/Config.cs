using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;


namespace P2PNNClient
{
    static class Config
    {
        public static String URL;
        public static String sample;

        private static String Location = "config.dnnconf";

        static Config()
        {
            loadConfig();
        }

        

        public static void loadConfig()
        {
            string json = System.IO.File.ReadAllText(@Config.Location);
            dynamic configContents = JsonConvert.DeserializeObject(json);
            URL = configContents.URL;
            sample = configContents.sample;
        }

        public static void saveConfig()
        {
            String text = "{URL: \"" + Config.URL + "\", sample: \"" + Config.sample + "\"}";
            System.IO.File.WriteAllText(@Config.Location, text);
        }
    }
}
