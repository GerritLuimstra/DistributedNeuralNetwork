using Newtonsoft.Json;
using System;


namespace P2PNNClient
{
    static class Config
    {
        public static String URL = "CHANGE.THIS";
        public static String downloadLocation;
        public static String token;
        public static String debug;

        private static String Location = "config.dnnconf";

        static Config()
        {
            try
            {
                loadConfig();
            }
            catch
            {
                String text = "{URL: \"" + "CHANGE.THIS" + "\", downloadLocation: \"" + "" + "\", token: \"" + "" + "\", debug: \"" + "FALSE" + "\"}";
                System.IO.File.WriteAllText(@Config.Location, text);
                new Error("Config file ERROR", "Please re-enter settings in the settings menu.", 250, 100).ShowDialog();
            }

            //loadConfig();
        }

        public static void loadConfig()
        {
            string json = System.IO.File.ReadAllText(@Config.Location);
            dynamic configContents = JsonConvert.DeserializeObject(json);
            URL = configContents.URL;//setting variable 
            downloadLocation = configContents.downloadLocation;
            token = configContents.token;
            debug = configContents.debug;
        }

        public static void saveConfig() //writing to confing file
        {
            LinkCheck();
            String text = "{URL: \"" + Config.URL + "\", downloadLocation: \"" + Config.downloadLocation.Replace("\\", "\\\\") + "\", token: \"" + Config.token + "\", debug: \"" + "false" + "\"}";
            System.IO.File.WriteAllText(@Config.Location, text);
        }

        private static void LinkCheck() //pinging website with link modification (becuase ping does not support http)
        {
            //checking if the link has http:// and or https, and www. in it
            bool httpCheck = URL.Contains("http://");
            bool httpsCheck = URL.Contains("https://");
            bool wwwCheck = URL.Contains("www.");
            //Checking the whole start of the link to make sure the start is correct
            bool websiteStartCheckHttp = URL.Contains("http://www.");
            bool websiteStartCheckHttps = URL.Contains("https://www.");
            bool lastIsSlash = false;
            char linkLastChar = URL[URL.Length - 1];
            if (linkLastChar.ToString() == "/")
                lastIsSlash = true;

            //checking for link starts and adding if not found
            if(URL != "localhost")
            {
                if (!websiteStartCheckHttp && !websiteStartCheckHttps)
                {
                    if (!httpCheck && !wwwCheck)
                        URL = "http://www." + URL;
                    else if (!httpCheck && wwwCheck)
                        URL = "http://" + URL;
                    //else if (!httpsCheck && !wwwCheck)
                    //    URL = "https://www." + URL;
                    else if (!httpsCheck && wwwCheck)
                        URL = "http://" + URL;
                }
            }
            
            //adding slash to the end if needed
            if (!lastIsSlash)
                URL += "/";
        }
    }
}
