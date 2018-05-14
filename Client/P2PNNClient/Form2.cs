using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2PNNClient
{
    public partial class Form2 : Form
    {
        private Form1 parentForm;

        public Form2(Form1 form)
        {
            InitializeComponent();
            parentForm = form;

            textBox1.Text = Config.URL;
        }

        private void button1_Click(object sender, EventArgs e)//Update button. remove
        {
            MessageBox.Show (Form1.testVaribale123);
        }

        private void button2_Click(object sender, EventArgs e) //save button
        {
            parentForm.label12.Text = textBox1.Text;
            Config.URL = textBox1.Text;
            Config.saveConfig();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Config.someField = textBox1.Text;
            
        }
    }
}
