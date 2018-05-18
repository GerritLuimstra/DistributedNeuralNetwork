using System;
using System.Windows.Forms;

namespace P2PNNClient
{
    public partial class Error : Form
    {

        public Error(String title, String message, int width, int height)
        {
            InitializeComponent();
            this.Text = title;
            this.Width = width;
            this.Height = height;
            label1.Text = message;
        }

        private void Error_Load(object sender, EventArgs e)
        {

        }

        private void Error_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
