using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace P2PNNClient
{
    public partial class Debug : Form
    {
        //showing raw data

        public Debug()
        {
            InitializeComponent();
        }

        private void ShowDloadLocationBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Config.downloadLocation);
        }

        private void WebsiteBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Config.URL);
        }

        private void TokenBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Config.token);
        }

        private void OpenDloadLocationBtn_Click(object sender, EventArgs e)
        {
            Process.Start(@Config.downloadLocation);
        }

        private void TestErrorBtn_Click(object sender, EventArgs e)
        {
            new Error("Test Error", "Test Error window with width 300 and height 100", 300, 100).ShowDialog();
        }

        private void RawJsonBtn_Click(object sender, EventArgs e)
        {
            string jsonLocation = Config.URL + "datasets.json";

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
            MessageBox.Show(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}
