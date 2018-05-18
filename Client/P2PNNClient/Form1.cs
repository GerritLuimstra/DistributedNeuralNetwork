using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace P2PNNClient
{
    public partial class Form1 : Form
    {
        static string website = "http://www.karinkreeft.nl/";
        static string jsonLocation = website + "datasets.json";
        string dataset = "";
        string path = "";


        private static String NNProgressLocation = "nnprogress.dnn";

        public Form1()//main fucnction
        {
            InitializeComponent();
            AutoPing();
            JsonPrint();
            ReadableJson();

            /*Starting all the necessary checks*/
            ConnTest();
            //TokenCheck();
            //NNProgress();
            //UploadProgress();
            /*Starting all the necessary checks*/

            label12.Text = Config.URL;
        }

        private void button1_Click(object sender, EventArgs e)//Pinging custom url
        {
            bool pinging = false;
            Ping isPing = new Ping();
            label3.Text = "UNSUCCESSFUL";

            try
            {
                PingReply reply = isPing.Send(textBox1.Text);
                pinging = reply.Status == IPStatus.Success;
                label3.Text = "SUCCESSFUL";
            }
            catch(PingException)
            {

            }
        }

        private void AutoPing()//pinging predetermined ftp server on start
        {
            FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://localhost"));
            requestDir.Credentials = new NetworkCredential("user", "user123");
            requestDir.Method = WebRequestMethods.Ftp.ListDirectory;

            try
            {
                FtpWebResponse response = (FtpWebResponse)requestDir.GetResponse();

                label5.Text = "Connection to FTP server was succsessful";
            }
            catch (/*PingException*/ Exception)
            {
                label5.Text = "Connection to FTP server was not succsessful";
                //new Error("Connection to FTP server was not succsessful").ShowDialog();
            }
        }

        private void JsonPrint()//Printing Json file
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(jsonLocation);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            label6.Text = responseFromServer;
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        public void ReadableJson()
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create("http://www.karinkreeft.nl/datasets.json");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();



            dynamic json = JsonConvert.DeserializeObject(responseFromServer);
            
            int i = 0;
            string token = json.token;
            string splitSize = json.splitSize;
            dataset = json.datasets[i];
            
            label7.Text = "Token: " + token;
            label8.Text = "Split size: " + splitSize;
            label9.Text = "Dataset " + i + ": " + dataset;
        }

        private void button2_Click(object sender, EventArgs e)//Download dataset TODO make better
        {
            string downloadLocation = "";
            string userName = Environment.UserName;

            //checking if download location has been changed by the user
            if(path == "")
            {
                string dirCheck = "C:/Users/" + userName + "/AppData/Local/Temp/DNN/";
                bool exists = System.IO.Directory.Exists(dirCheck);
                if (!exists)
                    System.IO.Directory.CreateDirectory(dirCheck);
                downloadLocation = dirCheck + dataset;
            }

            //checking wether user has set custom download location
            if (path != "")
                downloadLocation = path + "/" + dataset;

            string remoteUri = "http://www.karinkreeft.nl/"; //optimize
            string fileName = dataset, myStringWebResource = null;
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri + fileName;
            label10.Text = "Downloading File " + dataset + " from " + remoteUri;
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(myStringWebResource, @downloadLocation);
            label10.Text = "Successfully Downloaded File " + fileName + " from " + myStringWebResource;
            label11.Text = "Downloaded file saved in the following file system folder: " + downloadLocation;
            System.Diagnostics.Process.Start(@downloadLocation);

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
                PingReply reply = isPing.Send(Config.URL);
                pinging = reply.Status == IPStatus.Success;
                connected = true;
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


        private void TokenCheck()
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

        private void NNProgress()
        {
            string nnProgress = File.ReadAllText(@NNProgressLocation);
            //MessageBox.Show(json); //debug
            //dynamic nnPercent = JsonConvert.DeserializeObject(nnProgress);
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

            try
            {
                PingReply reply = isPing.Send(Config.URL);
                pinging = reply.Status == IPStatus.Success;
                connected = true;
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

        private void launchNN_Click(object sender, EventArgs e)
        {
            PingPage();
        }
    }
}
