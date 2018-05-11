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
        public static string testVar1;
        //System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Form2"];

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "New sample text";
            testVar1 = "Text from Form2";
            Form1.testVaribale123 = "Test message123";
            MessageBox.Show (Form1.testVaribale123);
        }
    }
}
