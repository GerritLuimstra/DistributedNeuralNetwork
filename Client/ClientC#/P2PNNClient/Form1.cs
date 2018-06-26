using Renci.SshNet;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net.Mime;
using System.Net.Http;
using System.Diagnostics;

namespace P2PNNClient
{
    public partial class Form1 : Form
    {
        //setting some basic variables to be acessed by all methods
        bool connected = false;
        string downloadLocation = "";
        int count = 1;
        string filename = "";

        private static String NNProgressLocation = "nnprogress.dnn";

        public Form1()//main fucnction
        {
            InitializeComponent();
            DebugCheck();
            ConnTest();
        }

        private void settingsBtn_Click(object sender, EventArgs e) //opening settings menu
        {
            Form2 f2 = new Form2(this);
            f2.ShowDialog();
        }

        public void ConnTest() //testing connection to the given host
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
            pictureBox1.Location = new System.Drawing.Point(12, 43);

            if (connected)
            {
                string result = "";
                bool isTrue = false;
                using (var client = new WebClient()) //reading from the page whether the token is valid
                {
                    result = client.DownloadString(Config.URL + "system/api.php?check=" + Config.token);
                }

                if (result == "true")
                {
                    tokenCheck.Text = "Token check ... OK";

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

                    try
                    {
                        pictureBox1.Location = new System.Drawing.Point(12, 66);

                        //checking wether user has set custom download location
                        if (customLocation != "")
                            downloadLocation = customLocation;


                        //string remoteUri = Config.URL + "mnist/original_files/"; //URL that we download from
                        string remoteUri = Config.URL + "system/api.php?token=" + Config.token;
                        //string fileName = Config.token, myStringWebResource = null;
                        // Create a new WebClient instance.
                        //WebClient myWebClient = new WebClient();
                        // Concatenate the domain with the Web resource filename.
                        //myStringWebResource = remoteUri + /*fileName*/ "myfile.zip";
                        // Download the Web resource and save it into the current filesystem folder.
                        //myWebClient.DownloadFile(myStringWebResource, @downloadLocation);

                        WebRequest request = WebRequest.Create(remoteUri);
                        WebResponse response = request.GetResponse();
                        ContentDisposition contentDisposition = new ContentDisposition(response.Headers["Content-Disposition"]);
                        filename = contentDisposition.FileName;
                        Stream streamWithFileBody = response.GetResponseStream();
                        
                        using (File.Create(downloadLocation + "\\" + filename));
                        using (Stream output = File.OpenWrite(downloadLocation + "\\" + filename))
                        using (Stream input = response.GetResponseStream())
                        {
                            input.CopyTo(output);
                        }

                        downloadCheckTXT.Text = "Download and extraction ... SUCCESSFUL";
                        //System.Diagnostics.Process.Start(@downloadLocation); //Opening the file

                        isTrue = true;
                    }
                    catch
                    {
                        new Error("No more data sets.", "The data set pool appears to be empty.", 300, 80).ShowDialog();
                        pictureBox1.Location = new System.Drawing.Point(12, 20);
                    }
                    if (isTrue)
                    {
                        UnzipArchive(filename);
                    }
                        
                }
                else if(result == "false")
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

        private void CleanUp()
        {

        }

        private string GetPythonPath()
        {
            string path = Path.GetPathRoot(Environment.SystemDirectory);
            return path + "Users\\" + Environment.UserName + "\\AppData\\Local\\Programs\\Python\\Python36\\python.exe";
        }

        private void LaunchNN() //TODO Make custom path to nn in the settings menu
        {
            pictureBox1.Location = new System.Drawing.Point(12, 89);

            createBatchFile();

            var startInfo = new ProcessStartInfo();
            startInfo.FileName = @Config.downloadLocation + "\\DNNExtracted\\start.cmd";
            startInfo.WorkingDirectory = @Config.downloadLocation + "\\DNNExtracted\\"; // working directory
            Process proc = Process.Start(startInfo);
            timer2.Start();
        }

        private void createBatchFile()
        {
            string file = @Config.downloadLocation + "\\DNNExtracted\\start.cmd";
            using (StreamWriter sw = File.CreateText(file))
            {
                sw.WriteLine("@echo off");
                sw.WriteLine("start network.py");
            }
        }

        private void NNProgress() //reading the current progress of the neural network
        {
            string nnProgress = File.ReadAllText(@NNProgressLocation);
            nnProgressTXT.Text = "Neural network progress ... " + nnProgress + "%";

        }

        private void PingPage() //method that is executed every 3 seconds to make sure there is a connection to the server with url modifiers built in
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

            //add check for Completed.txt
            if(File.Exists(@Config.downloadLocation + "\\extracted\\Completed.txt") && count == 1)
            {
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

        private void UnzipArchive(string archive)
        {
            if (Directory.Exists(Config.downloadLocation + "\\DNNExtracted"))
            {
                Directory.Delete(Config.downloadLocation + "\\DNNExtracted", true);
            }
            if (Directory.Exists(Config.downloadLocation + "\\DNNResult"))
            {
                Directory.Delete(Config.downloadLocation + "\\DNNResult", true);
            }

            ZipFile.ExtractToDirectory(Config.downloadLocation + "\\" + archive, Config.downloadLocation + "\\DNNExtracted");
            File.Delete(Config.downloadLocation + "\\" + archive);

            LaunchNN();
        }

        private void ZipArchive() //Modify before final release
        {
            string[] files = System.IO.Directory.GetFiles(@Config.downloadLocation + "\\DNNExtracted", "*.csv");


            foreach (string file in files)
            {
                System.IO.File.Delete(file);
            }

            if (File.Exists(@Config.downloadLocation + "\\DNNExtracted\\done.txt")) File.Delete(@Config.downloadLocation + "\\DNNExtracted\\done.txt");
            if (File.Exists(@Config.downloadLocation + "\\DNNExtracted\\network.py")) File.Delete(@Config.downloadLocation + "\\DNNExtracted\\network.py");
            if (File.Exists(@Config.downloadLocation + "\\DNNExtracted\\start.cmd")) File.Delete(@Config.downloadLocation + "\\DNNExtracted\\start.cmd");

            System.IO.Directory.CreateDirectory(@Config.downloadLocation + "\\DNNResult");
            ZipFile.CreateFromDirectory(@Config.downloadLocation + "\\DNNExtracted", @Config.downloadLocation + "\\DNNResult\\" + filename);

            FileUploadToPHP();
        }

        public async void FileUploadSFTP() //connecting to sftp server with predetermined link, port, and credentials
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

        private void FileUploadToPHP()
        {
            pictureBox1.Location = new System.Drawing.Point(12, 135);

            string uploadFile = @Config.downloadLocation + "\\DNNResult\\" + filename;
            
            WebClient wc = new WebClient();
            wc.Headers.Add("Content-Type", "binary/octet-stream");
            string url = Config.URL + "system/api.php?token=" + Config.token;
            byte[] result = wc.UploadFile(url, "POST", uploadFile);
            string res = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);

            pictureBox1.Location = new System.Drawing.Point(12, 159);

            Directory.Delete(Config.downloadLocation + "\\DNNExtracted", true);
            Directory.Delete(Config.downloadLocation + "\\DNNResult", true);

            pictureBox1.Visible = true;

        }

        private void EasterEgg_DoubleClick(object sender, EventArgs e) //easter egg
        {
            new Error("Easter egg?", "/╲ ︵ ╱\\ \r\n|  (◉) (◉)  | \r\n\\ ︶ V ︶ / \r\n/↺↺↺↺\\ \r\n↺↺↺↺↺ \r\n\\↺↺↺↺/ \r\n¯¯/\\¯/\\¯¯ \r\n\r\nMade by Erik Naljota", 175, 200).ShowDialog();
        }

        private void UploadBtn_Click(object sender, EventArgs e) //shows custom message box if everything was successful
        {
            LaunchNN();
            pictureBox1.Visible = true;
            pictureBox1.Location = new System.Drawing.Point(12, 20);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if(nnProgressTXT.Text == "Training the neural network ...")
            {
                nnProgressTXT.Text = "Training the neural network ... Training";
            } else
            {
                nnProgressTXT.Text = "Training the neural network ...";
            }

            if (File.Exists(Config.downloadLocation + "\\DNNExtracted\\done.txt"))
            {
                timer2.Stop();
                ZipArchive();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
