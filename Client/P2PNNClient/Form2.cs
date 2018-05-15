using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2PNNClient
{
    public partial class Form2 : Form
    {
        private Form1 parentForm;
        private bool isValid = false;

        public Form2(Form1 form)
        {
            InitializeComponent();
            parentForm = form;
        }

        private void button2_Click(object sender, EventArgs e) //save button
        {
            parentForm.label12.Text = websiteInput.Text;
            Config.URL = websiteInput.Text;
            Config.token = tokenInput.Text;
            TestConn(websiteInput.Text);
            if(isValid == true)
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
            bool pinging = false;
            Ping isPing = new Ping();

            try
            {
                PingReply reply = isPing.Send(url);
                pinging = reply.Status == IPStatus.Success;
                isValid = true;
            }
            catch (PingException)
            {
                new Error("Invalid host error", "Website link is invalid.").ShowDialog();
            }
        }

        private void debugBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work in progress");
            // TODO add debug window
        }

        // TODO add token check. Maybe sent it to website and get a response?
    }
}
