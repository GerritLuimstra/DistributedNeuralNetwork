using Renci.SshNet;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace P2PNNClient
{
    public partial class Form1 : Form
    {
        bool connected = false;
        string downloadLocation = "";
        int count = 1;

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

        private void DownloadCheck()
        {
            if (connected)
            {
                try
                {
                    string customLocation = Config.downloadLocation;
                    string userName = Environment.UserName;

                    //checking if download location has been changed by the user
                    if (customLocation == "")
                    {
                        string dirCheck = "C:/Users/" + userName + "/AppData/Local/Temp/DNN/";
                        bool exists = System.IO.Directory.Exists(dirCheck);
                        if (!exists)
                            System.IO.Directory.CreateDirectory(dirCheck);
                        downloadLocation = dirCheck + Config.token;
                    }

                    //checking wether user has set custom download location
                    if (customLocation != "")
                        downloadLocation = customLocation + "\\" + Config.token + ".zip";

                    string remoteUri = Config.URL + "mnist/original_files/";
                    string fileName = Config.token, myStringWebResource = null;
                    // Create a new WebClient instance.
                    WebClient myWebClient = new WebClient();
                    // Concatenate the domain with the Web resource filename.
                    myStringWebResource = remoteUri + fileName;
                    // Download the Web resource and save it into the current filesystem folder.
                    myWebClient.DownloadFile(myStringWebResource, @downloadLocation);
                    downloadCheckTXT.Text = "Download ... SUCCESSFUL";
                    //System.Diagnostics.Process.Start(@downloadLocation); //Opening the file

                    tokenCheck.Text = "Token check ... OK";
                    UnzipArchive();
                }
                catch
                {
                    tokenCheck.Text = "Token check ... INVALID TOKEN";
                    new Error("Inavlid token ERROR", "Server refused the given token.", 200, 85).ShowDialog();
                }
            }
            else
            {
                new Error("No connection ERROR", "No connection could me made to the server.", 255, 100).ShowDialog();
            }
        }

        private void LaunchNN() //TODO Make custom path to nn in the settings menu
        {
            //read txt file to start nn with custom settings
        }

        private void NNProgress()
        {
            string nnProgress = File.ReadAllText(@NNProgressLocation);
            nnProgressTXT.Text = "Neural network progress ... " +  nnProgress + "%";

        }

        private void PingPage()
        {
            bool pinging = false;
            Ping isPing = new Ping();
            String newUrl = Config.URL;

            try
            {
                if (Config.URL == "")
                {
                    connected = false;
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

        private void timer1_Tick(object sender, EventArgs e)  //timer method that refreshes every 3 seconds
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

            //add check for Completed.txt
            if(File.Exists(@Config.downloadLocation + "\\extracted\\Completed.txt") && count == 1)
            {
                ZipArchive();
                count ++;
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

        private void UnzipArchive()
        {
            Directory.Delete(@Config.downloadLocation + "\\extracted", true); //deleting directory if it already exists
            ZipFile.ExtractToDirectory(Config.downloadLocation + "\\" + Config.token + ".zip", Config.downloadLocation + "\\extracted");

            ZipArchive(); // should go to launchNN
        }

        private void ZipArchive() //Modify before final release
        {
            File.Delete(Config.downloadLocation + "\\extracted\\Nieuwe map\\someconfig.dnncnf");
            File.Delete(Config.downloadLocation + "\\" + Config.token + ".zip");
            ZipFile.CreateFromDirectory(@Config.downloadLocation + "\\extracted", @Config.downloadLocation + "\\" + Config.token + ".zip");

            FileUploadSFTP();
        }

        public async void FileUploadSFTP()
        {
            String host = "projectdnn.serverict.nl";
            int port = 22;
            String username = "projectdnn";
            String password = "N_rjpG1833";

            // path for file you want to upload
            var uploadFile = @Config.downloadLocation + "\\" + Config.token + ".zip";

            sftpConnTXT.Text = "Connection to SFTP server ... CONNECTING";

            using (var client = new SftpClient(host, port, username, password))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    sftpConnTXT.Text = "Connection to SFTP server ... OK";
                    uploadStatus.Text = "Upload status ... UPLOADING FILES";

                    using (var fileStream = new FileStream(uploadFile, FileMode.Open))
                    {
                        client.BufferSize = 4 * 1024; // bypass Payload error large files
                        client.UploadFile(fileStream, "/httpdocs/mnist/upload/" + Path.GetFileName(uploadFile));
                        await Task.Delay(3000);
                        uploadStatus.Text = "Upload status ... SUCCESSFUL";
                        new Error("Success!", "Trained neural network has been successfully uploaded to the server!", 380, 90).ShowDialog();
                    }
                }
                else
                {
                    sftpConnTXT.Text = "Connection to SFTP server ... FALSE";
                }
            }
        }

        private void EasterEgg_DoubleClick(object sender, EventArgs e)
        {
            new Error("Easter egg?", "/╲ ︵ ╱\\ \r\n|  (◉) (◉)  | \r\n\\ ︶ V ︶ / \r\n/↺↺↺↺\\ \r\n↺↺↺↺↺ \r\n\\↺↺↺↺/ \r\n¯¯/\\¯/\\¯¯ \r\n\r\nMade by Erik Naljota", 175, 200).ShowDialog();
        }

        private void UploadBtn_Click(object sender, EventArgs e)
        {
            new Error("Success!", "Trained neural network has been successfully uploaded to the server!", 380, 90).ShowDialog();
        }
    }
}
