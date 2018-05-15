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
        public static String downloadLocation;
        public static String token;

        private static String Location = "config.dnnconf";

        static Config()
        {
            loadConfig();
        }

        

        public static void loadConfig()
        {
            string json = System.IO.File.ReadAllText(@Config.Location);
            //MessageBox.Show(json); //debug
            dynamic configContents = JsonConvert.DeserializeObject(json);
            URL = configContents.URL;//setting variable 
            downloadLocation = configContents.downloadLocation;
            token = configContents.token;
        }

        public static void saveConfig()
        {
            String text = "{URL: \"" + Config.URL + "\", downloadLocation: \"" + Config.downloadLocation.Replace("\\", "\\\\") + "\", token: \"" + Config.token + "\"}";
            System.IO.File.WriteAllText(@Config.Location, text);
        }
    }
}
