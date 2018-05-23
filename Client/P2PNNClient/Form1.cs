using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace P2PNNClient
{
    public partial class Form1 : Form
    {
        string dataset = "dataset0.csv";

        private static String NNProgressLocation = "nnprogress.dnn";

        public Form1()//main fucnction
        {
            InitializeComponent();
            DebugCheck();
            ConnTest();
        }

        private void settingsBtn_Click(object sender, EventArgs e) //settings
        {
            Form2 f2 = new Form2(this);
            f2.ShowDialog();
        }

        public void ConnTest()
        {
            bool pinging = false;
            Ping isPing = new Ping();
            bool connected = false;

            try
            {
                if(Config.URL == "")
                {
                    connected = false;
                    //new Error("Blank link ERROR", "Please update the link via settings menu", 150, 100).ShowDialog();
                }
                else
                {
                    PingReply reply = isPing.Send(Config.URL);
                    pinging = reply.Status == IPStatus.Success;
                    connected = true;
                }
            }
            catch (PingException)
            {
                //MessageBox.Show(pe.ToString());
            }

            if (connected)
            {
                TokenCheck();
                ConnToServerTXT.Text = "Connection to server ... OK";
            }
            else
            {
                ConnToServerTXT.Text = "Connection to server ... FALSE";
            }
        }


        private void TokenCheck() //TODO Fix
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://stackoverflow.com/questions/1949610/how-can-i-catch-a9876876-404");
            //request.Method = "HEAD";
            //request.Credentials = CredentialCache.DefaultCredentials;

            //try
           // {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/tokencheck/index.php?token=" + Config.token);
                request.Method = "HEAD";
                request.Credentials = CredentialCache.DefaultCredentials;
                //MessageBox.Show(Config.token);
                try
                {
                    HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
                MessageBox.Show(resp.StatusCode.ToString());
                    if (resp.StatusCode.ToString() == "TOKEN_VALID")
                    {
                    MessageBox.Show("is valid");
                }
                } catch
                {
                    tokenCheck.Text = "Token check ... False";
                }
                
                
                //tokenCheck.Text = "Token check ... OK";
            //}
            //catch
            //{
             //   tokenCheck.Text = "Token check ... False";
            //}
        }

        private void DownloadCheck()
        {
            string downloadLocation = "";
            string customLocation = Config.downloadLocation;
            string userName = Environment.UserName;

            //checking if download location has been changed by the user
            if (customLocation == "")
            {
                string dirCheck = "C:/Users/" + userName + "/AppData/Local/Temp/DNN/";
                bool exists = System.IO.Directory.Exists(dirCheck);
                if (!exists)
                    System.IO.Directory.CreateDirectory(dirCheck);
                downloadLocation = dirCheck + dataset;
            }

            //checking wether user has set custom download location
            if (customLocation != "")
                downloadLocation = customLocation + "/" + dataset;

            string remoteUri = Config.URL ; //optimize
            string fileName = dataset, myStringWebResource = null;
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri + fileName;
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(myStringWebResource, @downloadLocation);
            downloadCheckTXT.Text = "Download ... SUCCESSFUL";
            System.Diagnostics.Process.Start(@downloadLocation);
        }

        private void LaunchNN() //TODO Make custom path to nn in the settings menu
        {

        }

        private void NNProgress()
        {
            string nnProgress = File.ReadAllText(@NNProgressLocation);
            nnProgressTXT.Text = "Neural network progress ... " +  nnProgress + "%";

        }

        private void UploadProgress()
        {

        }

        private void PingPage()
        {
            bool pinging = false;
            Ping isPing = new Ping();
            bool connected = false;
            String newUrl = Config.URL;

            try
            {
                if (Config.URL == "")
                {
                    connected = false;
                    //new Error("Blank link ERROR", "Please update the link via settings menu", 150, 100).ShowDialog();
                }
                else
                {
                    char last = Config.URL[Config.URL.Length - 1];
                    bool isSlash = false;
                    if (last.ToString() == "/")
                        isSlash = true;
                    if (newUrl.Contains("http://") && isSlash)
                    {
                        newUrl = newUrl.Remove(0, 7);
                        newUrl = newUrl.Replace("/", "");
                    }
                    PingReply reply = isPing.Send(newUrl);
                    pinging = reply.Status == IPStatus.Success;
                    connected = true;
                }
            }
            catch (PingException)
            {
            }

            if (connected)
            {
                ConnToServerTXT.Text = "Connection to server ... OK";
            }
            else
            {
                ConnToServerTXT.Text = "Connection to server ... FALSE";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PingPage();
            if (File.Exists(NNProgressLocation))
            {
                NNProgress();
            }
            else
            {
                nnProgressTXT.Text = "Neural network progress ... NOT RUNNING";
            }
        }

        private void launchDNNBtn_Click(object sender, EventArgs e) // Launching the DNN
        {
            DownloadCheck();
        }

        private void debugBtn_Click(object sender, EventArgs e) //Opening the debug menu
        {
            Debug debug = new Debug();
            debug.ShowDialog();
        }

        private void DebugCheck() // Checking the config file whether the debug has been enabled
        {
            if (Config.debug == "DNNDEBUG")
                debugBtn.Visible = true;
            else if (Config.debug == "TRUE" || Config.debug == "true")
            {
                debugBtn.Visible = false;
                new Error("Easter egg?", "That would be too easy, wouldn't it? :)", 230, 90).ShowDialog();
            }
            else
                debugBtn.Visible = false;
        }

        private void EasterEgg_DoubleClick(object sender, EventArgs e)
        {
            new Error("Easter egg?", "/╲ ︵ ╱\\ \r\n|  (◉) (◉)  | \r\n\\ ︶ V ︶ / \r\n/↺↺↺↺\\ \r\n↺↺↺↺↺ \r\n\\↺↺↺↺/ \r\n¯¯/\\¯/\\¯¯ \r\n\r\nMade by Erik Naljota", 175, 200).ShowDialog();
        }
    }
}
