using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
//using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;

namespace P2PNNClient
{
    public partial class Form1 : Form
    {
        static string website = "http://www.karinkreeft.nl/";
        static string jsonLocation = website + "datasets.json";
        string dataset = "";
        string path = "";

        public static string testVaribale123;
        public static string testVar123 = Form2.testVar1;

        public Form1()//main fucnction
        {
            InitializeComponent();
            AutoPing();
            JsonTest();
            Test();
        }
        
        public void TestClass()
        {
            label12.Text = Form2.testVar1;
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void AutoPing()
        {
            //bool tryPing = false;
            //Ping isPing = new Ping();
            //label5.Text = "Not connected to ip";

            FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://localhost"));
            requestDir.Credentials = new NetworkCredential("user", "user123");
            requestDir.Method = WebRequestMethods.Ftp.ListDirectory;

            try
            {
                //PingReply reply = isPing.Send("217.122.28.164");
                //tryPing = reply.Status == IPStatus.Success;
                //label5.Text = "Connection to ip was successful";

                FtpWebResponse response = (FtpWebResponse)requestDir.GetResponse();
                label5.Text = "Connection to FTP server was succsessful";
            }
            catch (/*PingException*/ Exception)
            {
                label5.Text = "Connection to FTP server was not succsessful";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void JsonTest()
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(jsonLocation);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            //Console.WriteLine(response.StatusDescription);
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

        public void Test()
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
            //string datasets = json.datasets[i];
            dataset = json.datasets[i];
            
            label7.Text = "Token: " + token;
            label8.Text = "Split size: " + splitSize;
            label9.Text = "Dataset " + i + ": " + dataset;
        }

        private void button2_Click(object sender, EventArgs e)
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

            //Creating a folder in Temp if it doesn't exist
            //string subPath = "C:/Users/" + userName + "/AppData/Local/Temp/DNN/"; // your code goes here
            //bool exists = System.IO.Directory.Exists(subPath);
            //if (!exists)
            //    System.IO.Directory.CreateDirectory(subPath);
            
            //string downloadLocation = "C:/Users/" + userName + "/AppData/Local/Temp/DNN/" + dataset;

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

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fbd.Tag = "Select folder to download dataset to";
                path = fbd.SelectedPath;
                MessageBox.Show(path);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Form2.testVar1);
        }
    }
}
