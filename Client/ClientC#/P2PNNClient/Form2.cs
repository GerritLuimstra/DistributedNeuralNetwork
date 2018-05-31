using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace P2PNNClient
{
    public partial class Form2 : Form
    {
        private Form1 parentForm;
        private bool isValid = false;
        private bool connected = false;

        public Form2(Form1 form)
        {
            InitializeComponent();
            parentForm = form;
        }

        private void button2_Click(object sender, EventArgs e) //save button
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            Config.URL = websiteInput.Text;
            Config.token = tokenInput.Text;
            TestConn(websiteInput.Text);
            if (isValid)
            {
                Config.saveConfig();
                parentForm.ConnTest();
                this.Close();
            }
        }

        private void downloadChange_Click(object sender, EventArgs e) //change download location
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select folder to download dataset into" };
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                Config.downloadLocation = path;
            }
        }

        private void downloadShow_Click(object sender, EventArgs e) //show download location
        {
            MessageBox.Show(Config.downloadLocation);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            websiteInput.Text = Config.URL;
            tokenInput.Text = Config.token;
        }

        private void TestConn(String url)
        {
            /////////////////////////////////////////////////////////////

            string newUrl = url;
            Ping isPing = new Ping();
            bool pinging = false;

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

            /////////////////////////////////////////////////////////////

            try
            {
                PingReply reply = isPing.Send(newUrl);
                pinging = reply.Status == IPStatus.Success;
                isValid = true;
            }
            catch (PingException)
            {
                new Error("Invalid host ERROR", "Website link is invalid.", 170,100).ShowDialog();
            }
        }

        private void websiteInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SaveConfig();
            }
        }

        // TODO add token check. Maybe sent it to website and get a response?
    }
}
