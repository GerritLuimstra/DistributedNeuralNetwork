using Newtonsoft.Json;
using System;


namespace P2PNNClient
{
    static class Config
    {
        public static String URL = "CHANGE.THIS";
        public static String downloadLocation;
        public static String token;

        private static String Location = "config.dnnconf";

        static Config()
        {
            try
            {
                loadConfig();
            }
            catch
            {
                String text = "{URL: \"" + "CHANGE.THIS" + "\", downloadLocation: \"" + "" + "\", token: \"" + "" + "\",  token: \"" + "" + "\"}";
                System.IO.File.WriteAllText(@Config.Location, text);
                new Error("Config file ERROR", "Please re-enter settings in the settings menu.", 250, 100).ShowDialog();
            }

            //loadConfig();
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
