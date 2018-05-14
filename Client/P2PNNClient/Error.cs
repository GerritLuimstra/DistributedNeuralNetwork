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
    public partial class Error : Form
    {

        public Error(String message)
        {
            InitializeComponent();
            label1.Text = message;
        }

        private void Error_Load(object sender, EventArgs e)
        {

        }
    }
}
